// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Properties;

using static Vanara.PInvoke.User32;

namespace WinFormium;
public partial class Formium : IDisposable, IWin32Window
{

    private FormBorderStyle? _lastFormBorderStyle;
    private FormWindowState? _lastFormWindowState;
    private string? _appTitle;

    const int SYSMENU_ABOUT_ID = 0x9001;
    const int SYSMENU_FULL_SCREEN_ID = 0x9002;

    //private CefBrowserSettings? _browserSettings;

    internal WebView WebView { get; }

    internal FormiumWebViewHost WebViewHost { get; }

    private SplashScreen? _splashScreen = null;

    private BrowserRenderWidgetHostMessageInterceptor? _browserRenderWidgetMessageInterceptor = null;

    private Dictionary<string, Func<JavaScriptValue, JavaScriptValue>> JavaScriptBrowserRequestHandlers { get; } = new();

    private Dictionary<string, Action<JavaScriptValue, JavaScriptPromise>> JavaScriptBrowserRequestAsyncHandlers { get; } = new();

    private Dictionary<string, Action<JavaScriptValue>> JavaScriptBrowserMessageHandlers { get; } = new();

    internal StandardWindowBase? HostWindow { get; private set; }

    internal FormStyle CurrentFormStyle { get; }

    private bool _enabled = true;

    protected Formium(Control? container = null)
    {
        ApplicationContext = WinFormiumApp.Current!;

        ChromiumEnviroment = Services.GetRequiredService<ChromiumEnvironment>()!;

        WebViewHost = new FormiumWebViewHost(this);

        WebView = new WebView(WebViewHost);

        OnBrowserClientCreatedCore();

        var hostWindowBuilder = new WindowStyleBuilder(this, container);

        CurrentFormStyle = ConfigureWindowStyle(hostWindowBuilder);

        CreateHostWindowCore();
    }



    private WebViewColorMode GetCurrentSystemColorMode()
    {

        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        static extern bool ShouldSystemUseDarkMode();


        try
        {
            if (ColorMode == FormiumColorMode.SystemPreference)
            {
                return ShouldSystemUseDarkMode() ? WebViewColorMode.Dark : WebViewColorMode.Light;
            }
            else
            {
                return ColorMode == FormiumColorMode.Dark ? WebViewColorMode.Dark : WebViewColorMode.Light;
            }
        }
        catch
        {
            return WebViewColorMode.Light;
        }

    }


    private void SystemColorModeChangedCore()
    {
        WebView.ColorMode = GetCurrentSystemColorMode();
    }

    internal void CreateHostWindowCore()
    {
        CurrentFormStyle.OnWndProc = WndProcCore;
        CurrentFormStyle.OnDefWndProc = DefWndProcCore;

        var target = HostWindow = CurrentFormStyle.CreateHostWindow()?.Invoke()!;



        if (target == null)
        {
            throw new ArgumentNullException(nameof(HostWindow));
        }

        target.ShowInTaskbar = CurrentFormStyle.ShowInTaskbar;


        target.Icon = CurrentFormStyle.Icon;

        UsePageTitle = CurrentFormStyle.UsePageTitle;

        ColorMode = CurrentFormStyle.ColorMode;

        AppTitle = CurrentFormStyle.DefaultAppTitle;

        target.Text = BuildTitleString();


        target.MinimumSize = CurrentFormStyle.MinimumSize;

        target.MaximumSize = CurrentFormStyle.MaximumSize;

        target.Size = CurrentFormStyle.Size;

        target.MinimizeBox = CurrentFormStyle.Minimizable;

        target.MaximizeBox = CurrentFormStyle.Maximizable;


        if(target.Icon == null && !CurrentFormStyle.Sizable )
        {
            target.ControlBox = false;
        }



        WindowState = CurrentFormStyle.WindowState;



        target.TopMost = CurrentFormStyle.TopMost;

        if (target.Icon == null && !CurrentFormStyle.Sizable)
        {
            target.ControlBox = false;
        }

        target.Load += (sender, args) =>
        {
            var target = (Form)sender!;
            HostWindowCreatedCore(target);

            if (CurrentFormStyle.StartCentered != StartCenteredMode.None)
            {
                if (target.Owner == null)
                {
                    target.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    if(CurrentFormStyle.StartCentered == StartCenteredMode.CenterParent)
                    {
                        target.StartPosition = FormStartPosition.CenterParent;
                    }
                    else
                    {
                        target.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
            }
            else
            {
                if (CurrentFormStyle.IsLocationSet)
                {
                    target.StartPosition = FormStartPosition.Manual;

                    target.Location = CurrentFormStyle.Location;
                }
            }
        };

        target.Shown += (_, args) =>
        {
            OnActivatedCore();

            OnShown(args);
        };

        RegisterHostWindowEvents();


        CurrentFormStyle.OverwriteHostWindowProperties(target);

        CreateWindow(target);


    }

    private string BuildTitleString()
    {
        if (UsePageTitle)
        {
            if (string.IsNullOrEmpty(PageTitle))
            {
                return AppTitle;
            }
            else
            {
                return string.Format(TitlePattern, PageTitle, AppTitle);
            }
        }
        else
        {
            return AppTitle;
        }
    }


    internal void HostWindowCreatedCore(Form target)
    {

        WindowHandle = target.Handle;

        OwnerHandle = target.Owner?.Handle ?? IntPtr.Zero;

        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> WindowCreated");

        _splashScreen = new SplashScreen(target, PaintSplashScreen);

        target.Controls.Add(_splashScreen);

        _splashScreen.Visible = EnableSplashScreen;

        ModifySystemMenu();

        ShowSplash();

        target.Activate();

        CreateBrowserCore();
    }

    private void ModifySystemMenu()
    {


        var hSysMenu = GetSystemMenu(WindowHandle, false);

        if (CurrentFormStyle.AllowFullScreen)
        {

            InsertMenu(hSysMenu, (uint)5, MenuFlags.MF_BYPOSITION, (nint)SYSMENU_FULL_SCREEN_ID, Messages.SystemMenu_FullScreen);
            //InsertMenu(hSysMenu, (uint)SysCommand.SC_CLOSE, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_SEPARATOR, IntPtr.Zero, string.Empty);
        }

        if (!DisableAboutMenu)
        {
            AppendMenu(hSysMenu, MenuFlags.MF_SEPARATOR, IntPtr.Zero, string.Empty);
            AppendMenu(hSysMenu, MenuFlags.MF_STRING, (IntPtr)SYSMENU_ABOUT_ID, Messages.SystemMenu_About);
        }
    }

    internal void ConfigureBrowserSettingsCore(CefBrowserSettings settings)
    {

        ChromiumEnviroment.ConfigureBrowserSettings?.Invoke(settings);

        CreateBrowser(settings);
    }

    internal void CreateBrowserCore()
    {
        var settings = ChromiumEnviroment.GetDefaultBrowserSettings();

        if (CurrentFormStyle.OffScreenRenderEnabled)
        {
            settings.BackgroundColor = new CefColor(0x00, 0x00, 0x00, 0x00);
        }
        else
        {
            settings.BackgroundColor = new CefColor(0xFF, 0xFF, 0xFF, 0xFF);
        }

        ConfigureBrowserSettingsCore(settings);

        WebView.Url = Url;

        if (CurrentFormStyle.OffScreenRenderEnabled)
        {
            WebView.Create(settings, WebViewHostMode.Windowless);
            ImeHandler = new OffscreenImeHandler(this);
            RegisterOffscreenModeEvents();
        }
        else
        {
            WebView.Create(settings, WebViewHostMode.HwndChild);
        }
    }

    internal void BrowserCreatedCore(CefBrowser browser)
    {
        ResizeWebView();

        OnEnabledChangedCore();

        var target = HostWindow!;


        target.Resize += (_, _) =>
        {
            ResizeWebView();
        };

        target.VisibleChanged += (_, _) =>
        {
            ResizeWebView();
        };

        target.ResizeBegin += (_, _) =>
        {
            WebView.NotifyMoveOrResizeStarted();
        };

        target.ResizeEnd += (_, _) =>
        {
            WebView.WasResized();
        };

        target.Move += (sender, _) =>
        {
            var target = (Form?)sender;
            if (target != null && target.WindowState == FormWindowState.Normal)
            {
                WebView.NotifyMoveOrResizeStarted();
            }
        };

        target.WindowDpiAdapter.WindowDpiChanged += (_, _) =>
        {
            WebView.NotifyScreenInfoChanged();
            WebView.NotifyMoveOrResizeStarted();
        };

        target.FormClosing += (_, args) =>
        {
            if (args.CloseReason == CloseReason.WindowsShutDown || WebView.CanClose)
            {
                return;
            }

            args.Cancel = true;

            BrowserHost?.CloseBrowser(false);
        };

        target.Activated += (_, _) =>
        {
            OnActivatedCore();
        };

        target.Deactivate += (_, _) =>
        {
            OnDeactivateCore();

        };

        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> BrowserCreated");

        OnBrowserCreated(new BrowserEventArgs(browser));
    }

    internal void ShowSplash()
    {
        if (EnableSplashScreen && _splashScreen != null)
        {
            InvokeOnUIThread(() => {
                _splashScreen.Visible = true;

                _splashScreen.BringToFront();
            });

        }
    }

    internal void HideSplash()
    {
        if (EnableSplashScreen && _splashScreen != null)
        {
            InvokeOnUIThread(() => {

                _splashScreen.SendToBack();
                _splashScreen.Visible = false;

                

                if (HostWindow != null && HostWindow.IsWindowActivated)
                {
                    BrowserHost?.SetFocus(true);

                    ResizeWebView();

                }
            });

        }
    }
    protected virtual void PaintSplashScreen(PaintEventArgs e)
    {

        const string Initializing_Text = "Powered by WinFormium";

        var bounds = e.ClipRectangle;

        var g = e.Graphics;

        g.Clear(ColorTranslator.FromHtml("#004F99"));

        var img = Resources.Chromium;

        var scale = bounds.Width / img.Width > 3 ? 1.0f : ((float)bounds.Width / 3) / (float)img.Width;

        if (scale > 1) scale = 1;

        var imgWidth = img.Width * scale;
        var imgHeight = img.Height * scale;

        g.DrawImage(img, new RectangleF((bounds.Width - imgWidth) / 2, (bounds.Height - imgHeight) / 2, imgWidth, imgHeight));



        var font = new Font("Segoue UI", 12 * (HostWindow?.WindowScaleFactor ?? 1.0f));

        var fontSize = g.MeasureString(Initializing_Text, font);

        g.DrawString(Initializing_Text, font, Brushes.White, new PointF((bounds.Width - fontSize.Width - 20), (bounds.Height - fontSize.Height - 20)));

    }

    internal void ContextCreatedCore(CefBrowser browser, CefFrame frame)
    {

        ContextCreated(browser, frame);

        if (ImeHandler != null)
        {
            CancelImeComposition(browser.GetHost());
        }
    }


    internal void OnActivatedCore()
    {
        SetBrowserFocus();


        OnActivated();

        WebView.InvokeOnActivated();


    }

    private void SetBrowserFocus()
    {
        if (_splashScreen == null)
        {
            BrowserHost?.SetFocus(true);
        }
        else
        {
            if (_splashScreen.Visible == false)
            {
                BrowserHost?.SetFocus(true);
            }
            else
            {
                InvokeOnUIThread(() => _splashScreen.BringToFront());
            }
        }
    }

    internal void OnWindowStateChangedCore()
    {
        OnWindowStateChanged(new WindowStateChangedEventArgs(WindowState));

        WebView.InvokeOnWindowStateChanged(WindowState.ToString());

    }

    internal void OnDeactivateCore()
    {
        OnDeactivated();
        BrowserHost?.SetFocus(false);

        WebView.InvokeOnDeactivate();

    }
    internal void OnEnabledChangedCore()
    {
        if (BrowserHandle != (nint)0 && WindowHandle != (nint)0)
        {
            EnableWindow(BrowserHandle, Enabled);
            EnableWindow(WindowHandle, Enabled);
        }
    }

    internal void OnClosingCore(ClosingEventArgs args)
    {
        OnClosing(args);
    }

    internal void OnClosedCore()
    {
        OnClosed();
    }

    private async void CreateBrowserMessageInterceptor()
    {
        var retval = await BrowserRenderWidgetHostMessageInterceptor.Setup(_browserRenderWidgetMessageInterceptor, this, BrowserWndProcCore);

        if (retval != null)
        {
            if (_browserRenderWidgetMessageInterceptor != null)
            {
                _browserRenderWidgetMessageInterceptor.ReleaseBrowserHandle();
            }

            _browserRenderWidgetMessageInterceptor = retval;
        }
    }

    private void SetFullscreenState(bool fullscreen, FormWindowState? state = null)
    {
        if (HostWindow == null || (!AllowFullScreen && fullscreen)) return;

        if (fullscreen)
        {
            _lastFormBorderStyle = HostWindow.FormBorderStyle;
            _lastFormWindowState = HostWindow.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : HostWindow.WindowState;

            HostWindow.WindowState = FormWindowState.Normal;

            HostWindow.FormBorderStyle = FormBorderStyle.None;

            HostWindow.WindowState = FormWindowState.Maximized;

            IsFullscreen = true;
        }
        else
        {
            HostWindow.FormBorderStyle = _lastFormBorderStyle == null ? HostWindow.FormBorderStyle : _lastFormBorderStyle.Value;

            if (state == null)
            {
                var formState = _lastFormWindowState == null ? FormWindowState.Normal : _lastFormWindowState.Value;

                if (formState != HostWindow.WindowState) HostWindow.WindowState = formState;
            }
            else
            {
                HostWindow.WindowState = state.Value;
            }

            _lastFormBorderStyle = null;
            _lastFormWindowState = null;

            IsFullscreen = false;
        }
    }

    private void RegisterHostWindowEvents()
    {
        var hostWindow = HostWindow!;


        hostWindow.ResizeBegin += (_, args) => OnResizeBegin(args);
        hostWindow.Resize += (_, args) =>
        {
            OnResize(args);

            var isMaximized = (HostWindow?.WindowState == FormWindowState.Maximized);

            RECT rect;

            if (isMaximized)
            {
                GetClientRect(WindowHandle, out rect);

            }
            else
            {
                GetWindowRect(WindowHandle, out rect);
            }

            WebView.InvokeOnWindowResized(rect);

        };
        hostWindow.ResizeEnd += (_, args) => OnResizeEnd(args);

        hostWindow.Move += (_, args) =>
        {
            OnMove(args);

            GetClientRect(WindowHandle, out var rect);

            WebView.InvokeOnWindowMoved(rect.Left, rect.Top);
        };

        hostWindow.VisibleChanged += (_, args) => OnVisibleChanged(args);

    }

    internal void HandleException(Exception exception)
    {
    }



    internal JavaScriptValue? OnBrowserRequest(string message, JavaScriptValue value)
    {
        if (JavaScriptBrowserRequestHandlers.TryGetValue(message, out var handler))
        {
            return handler.Invoke(value);
        }

        return null;
    }

    internal void OnBrowserRequestAsync(string message, JavaScriptValue value, JavaScriptPromise promise)
    {
        if (JavaScriptBrowserRequestAsyncHandlers.TryGetValue(message, out var handler))
        {
            handler.Invoke(value, promise);
        }
    }

    internal void OnBrowserMessage(string message, JavaScriptValue value)
    {
        if (JavaScriptBrowserMessageHandlers.TryGetValue(message, out var handler))
        {
            handler.Invoke(value);
        }
    }

    #region host window message handlers
    internal bool WndProcCore(ref Message m)
    {
        if (!WebView.IsBrowserInitialized) return false;

        var msg = (WindowMessage)m.Msg;

        HandleContextMenuMessages(msg);

        HandleSystemColorModeChange(m);

        var retval = HandleSystemMenuCommand(m);

        if (retval) return true;

        if (CurrentFormStyle.OffScreenRenderEnabled)
        {
            retval = BrowserMessageHandler(ref m);

            if (retval) return true;

            retval = BrowserImeMessageHandler(ref m);

            if (retval) return true;


        }

        //if (msg == WindowMessage.WM_WINDOWPOSCHANGED)
        //{
        //    var windowpos = m.LParam.ToStructure<WINDOWPOS>();

        //    if ((windowpos.flags & SetWindowPosFlags.SWP_NOSIZE) != SetWindowPosFlags.SWP_NOSIZE)
        //    {

        //        System.Diagnostics.Debug.WriteLine("[WIN32API] -> WM_WINDOWPOSCHANGED");
        //        ResizeWebView();
        //    }
        //}

        return WndProc(ref m);
    }

    private bool HandleSystemMenuCommand(Message m)
    {
        var msg = (WindowMessage)m.Msg;

        if (msg == WindowMessage.WM_SYSCOMMAND)
        {
            var cmd = (int)m.WParam;

            if (cmd == (int)SysCommand.SC_RESTORE && IsFullscreen)
            {
                SetFullscreenState(false);

                return true;
            }

            if (cmd == SYSMENU_FULL_SCREEN_ID)
            {
                SetFullscreenState(!IsFullscreen);
            }

            if (cmd == SYSMENU_ABOUT_ID)
            {
                WebView.ShowAboutDialog();
            }
        }

        if (msg == WindowMessage.WM_NCRBUTTONUP)
        {
            var point = new Point(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));
            ShowSystemMenu(ref point);
        }

        return false;
    }

    private void ShowSystemMenu(ref Point pt)
    {
        var hMenu = GetSystemMenu(WindowHandle, false);
        var hCmd = TrackPopupMenuEx(hMenu, TrackPopupMenuFlags.TPM_RETURNCMD | TrackPopupMenuFlags.TPM_TOPALIGN | TrackPopupMenuFlags.TPM_LEFTALIGN, pt.X, pt.Y, WindowHandle);

        PostMessage(WindowHandle, (uint)WindowMessage.WM_SYSCOMMAND, (IntPtr)hCmd, IntPtr.Zero);
    }

    internal bool DefWndProcCore(ref Message m)
    {
        var msg = (WindowMessage)m.Msg;

        return DefWndProc(ref m);
    }

    private void HandleSystemColorModeChange(Message m)
    {
        const string IMMERSIVE_COLOR_SET = "ImmersiveColorSet";

        var msg = (WindowMessage)m.Msg;

        if (msg == WindowMessage.WM_SETTINGCHANGE && m.LParam != IntPtr.Zero)
        {
            var buff = new byte[256];
            Marshal.Copy(m.LParam, buff, 0, 255);
            var settingName = Encoding.Unicode.GetString(buff);
            settingName = settingName.Substring(0, settingName.IndexOf('\0'));

            if (settingName == IMMERSIVE_COLOR_SET)
            {
                SystemColorModeChangedCore();
            }
        }
    }



    private void HandleContextMenuMessages(WindowMessage msg)
    {
        if (CurrentFormStyle.OffScreenRenderEnabled)
            return;

        if (msg == WindowMessage.WM_NCLBUTTONDOWN || msg == WindowMessage.WM_NCRBUTTONDOWN)
        {
            WebView.CloseContextMenu();
        }
    }
    #endregion

    #region browser window message handlers
    internal bool BrowserWndProcCore(ref Message m)
    {
        var retval = BrowserMessageHandler(ref m);

        if (retval) return true;

        return BrowserWndProc(ref m);
    }

    private const int WM_TOUCH = 0x0240;

    private bool BrowserMessageHandler(ref Message m)
    {
        var msg = (WindowMessage)m.Msg;

        switch (msg)
        {
            case WindowMessage.WM_MOUSEMOVE when CurrentFormStyle.UseBrowserHitTest:
                return BrowserWmMouseMove(ref m);
            case WindowMessage.WM_SETCURSOR when CurrentFormStyle.UseBrowserHitTest:
                return BrowserWmSetCursor(ref m);
            case WindowMessage.WM_LBUTTONDOWN:
                return BrowserLButtonDown(ref m);
            case WindowMessage.WM_RBUTTONDOWN:
                return BrowserRButtonHandler(true, ref m);
            case WindowMessage.WM_RBUTTONUP:
                return BrowserRButtonHandler(false, ref m);
            case WindowMessage.WM_LBUTTONDBLCLK:
                return BrowserLButtonDoubleClick(ref m);

        }


        //if(m.Msg == WM_TOUCH)
        //{
        //    return DecodeTouch(ref m);
        //}

        return false;
    }

    //private bool DecodeTouch(ref Message m)
    //{
    //    var inputCount = (uint)Macros.LOWORD(m.WParam);

    //    var inputs = new TOUCHINPUT[inputCount];

    //    var cbSize= Marshal.SizeOf<TOUCHINPUT>();

    //    if(!GetTouchInputInfo(m.LParam, inputCount, inputs, cbSize))
    //    {
    //        return false;
    //    }


    //    if(inputCount == 1)
    //    {
    //        var ti = inputs[inputCount];

    //        var isDown = ((ti.dwFlags & TOUCHEVENTF.TOUCHEVENTF_DOWN) == TOUCHEVENTF.TOUCHEVENTF_DOWN);

    //        if (isDown)
    //        {
    //            var point = new POINT(ti.x / 100, ti.y / 100);

    //            ScreenToClient(WindowHandle, ref point);

    //            var isInDraggableArea = WebViewHost.DraggableRegion?.IsVisible(point) ?? false;

    //            if (isInDraggableArea)
    //            {
    //                ReleaseCapture();

    //                PostMessage(WindowHandle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)HitTestValues.HTCAPTION, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

    //                return true;
    //            }

    //        }
    //    }


    //    CloseTouchInputHandle(m.LParam);



    //    return false;
    //}

    private bool BrowserLButtonDoubleClick(ref Message m)
    {
        var point = new Point(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = WebViewHost.DraggableRegion?.IsVisible(point) ?? false;

        if (isInDraggableArea && Maximizable && Sizable)
        {
            if (IsFullscreen)
            {
                return false;
            }

            PostMessage(WindowHandle, (uint)WindowMessage.WM_NCLBUTTONDBLCLK, (IntPtr)HitTestValues.HTCAPTION, IntPtr.Zero);

            return true;
        }

        return false;

    }

    private bool BrowserRButtonHandler(bool isDown, ref Message m)
    {
        if (!AllowSystemMenu)
        {
            return false;
        }



        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = WebViewHost.DraggableRegion?.IsVisible(point) ?? false;

        if (isInDraggableArea)
        {
            ClientToScreen(WindowHandle, ref point);

            if (isDown)
            {
                PostMessage(WindowHandle, (uint)WindowMessage.WM_NCRBUTTONDOWN, (IntPtr)HitTestValues.HTSYSMENU, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));
            }
            else
            {
                PostMessage(WindowHandle, (uint)WindowMessage.WM_NCRBUTTONUP, (IntPtr)HitTestValues.HTSYSMENU, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));
            }


            return true;
        }

        return false;
    }

    private bool BrowserLButtonDown(ref Message m)
    {
        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = WebViewHost.DraggableRegion?.IsVisible(point) ?? false;

        var mode = HostWindow!.HitTest(point);

        if (mode == HitTestValues.HTNOWHERE) return false;

        ClientToScreen(WindowHandle, ref point);

        if (CurrentFormStyle.Sizable && CurrentFormStyle.UseBrowserHitTest && mode != HitTestValues.HTCLIENT && HostWindow!.WindowState == FormWindowState.Normal)
        {
            ReleaseCapture();

            PostMessage(WindowHandle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)mode, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }
        else if (isInDraggableArea)
        {
            ReleaseCapture();

            PostMessage(WindowHandle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)HitTestValues.HTCAPTION, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }

        return false;
    }

    private bool BrowserWmSetCursor(ref Message m)
    {
        #region SETCURSOR
        void SetCursor(HitTestValues mode)
        {
            SafeHCURSOR? handle = null;

            switch (mode)
            {
                case HitTestValues.HTTOP:
                case HitTestValues.HTBOTTOM:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32645));
                    break;
                case HitTestValues.HTLEFT:
                case HitTestValues.HTRIGHT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32644));
                    break;
                case HitTestValues.HTTOPLEFT:
                case HitTestValues.HTBOTTOMRIGHT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32642));

                    break;
                case HitTestValues.HTTOPRIGHT:
                case HitTestValues.HTBOTTOMLEFT:
                    handle = LoadCursor(lpCursorName: Macros.MAKEINTRESOURCE(32643));
                    break;
            }


            if (handle != null)
            {
                var oldCursor = User32.SetCursor(handle);

                oldCursor?.Close();
            }
        }
        #endregion

        if (HostWindow?.WindowState != FormWindowState.Normal) return false;

        if (!CurrentFormStyle.Sizable) return false;


        var pos = GetMessagePos();
        var point = new POINT(Macros.LOWORD(pos), Macros.HIWORD(pos));
        ScreenToClient(WindowHandle, ref point);

        var retval = HostWindow!.HitTest(point);

        if (retval != HitTestValues.HTCLIENT)
        {
            SetCursor(retval);

            m.Result = (IntPtr)1;

            return true;
        }

        return false;
    }

    private bool BrowserWmMouseMove(ref Message m)
    {
        if (HostWindow?.WindowState != FormWindowState.Normal) return false;

        if (!CurrentFormStyle.Sizable) return false;

        if (!CurrentFormStyle.UseBrowserHitTest) return false;


        var lparam = m.LParam;

        var point = new Point(Macros.GET_X_LPARAM(lparam), Macros.GET_Y_LPARAM(lparam));

        var retval = HostWindow!.HitTest(point);

        return retval != HitTestValues.HTNOWHERE && retval != HitTestValues.HTCLIENT;
    }
    #endregion
}
