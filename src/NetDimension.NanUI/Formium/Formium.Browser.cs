using System;

using NetDimension.NanUI.Browser;
using NetDimension.NanUI.HostWindow;

using Vanara.PInvoke;

using Xilium.CefGlue;

using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI;




partial class Formium
{
    private ChromeWidgetMessageInterceptor chromeWidgetMessageInterceptor = null;

    private readonly object _browserSyncRoot = new object();

    private string _loadUrlDeferred;

    private bool _isBrowserCreated = false;

    private bool _isFirstTimeToRun = true;


    internal CefWindowInfo WindowInfo { get; private set; }

    internal protected CefBrowser Browser => WebView?.Browser;

    internal void CreateBrowser()
    {


        WebView = new FormiumWebView(this, _browserSettings, StartUrl);

        WindowInfo = CefWindowInfo.Create();

        WindowInfo.StyleEx |= Xilium.CefGlue.Platform.Windows.WindowStyleEx.WS_EX_NOACTIVATE;

        GetClientRect(HostWindowHandle, out var rect);


        if (WindowType == HostWindow.HostWindowType.Layered)
        {
            WindowInfo.WindowlessRenderingEnabled = true;

            WindowInfo.SetAsWindowless(IntPtr.Zero,true);
        }
        else
        {
            WindowInfo.SetAsChild(HostWindowHandle, new CefRectangle(0, 0, rect.Width, rect.Height));
        }


        WebView.CreateBrowser(WindowInfo);
    }


    internal async void AttachToChromeWidgetMessageHandler()
    {
        var retval = await ChromeWidgetMessageInterceptor.Setup(chromeWidgetMessageInterceptor, this, OnBrowserMessage);

        if (retval != null)
        {
            if (chromeWidgetMessageInterceptor != null)
            {
                chromeWidgetMessageInterceptor.ReleaseBrowserHandle();
            }

            chromeWidgetMessageInterceptor = retval;
        }
    }

    internal void OnBrowserCreated()
    {
        BrowserWindowHandle = WebView.BrowserWindowHandle;

        InvokeIfRequired(() => BrowserCreated?.Invoke(this, EventArgs.Empty));

        //InvokeIfRequired(() => OnWindowAndBrowserReady());

        _isBrowserCreated = true;


        ThreadPool.QueueUserWorkItem(AfterSetBrowserTasks);

        InvokeIfRequired(() => ResizeWebView());




    }

    private void AfterSetBrowserTasks(object state)
    {
        lock (_browserSyncRoot)
        {
            if (_loadUrlDeferred != null)
            {
                Browser.GetMainFrame().LoadUrl(_loadUrlDeferred);
            }
        }
    }

    private bool OnBrowserMessage(ref Message m)
    {
        if (!_isHostWindowCreated)
            return false;

        var retval = false;

        switch (m.Msg)
        {
            case (int)WindowMessage.WM_LBUTTONDOWN:
                retval = BrowserWmLButtonDown(ref m);
                break;
            case (int)WindowMessage.WM_RBUTTONDOWN:
                retval = BrowserWmRButtonDown(ref m);
                break;
            case (int)WindowMessage.WM_RBUTTONUP:
                retval = BrowserWmRButtonUp(ref m);
                break;
            case (int)WindowMessage.WM_LBUTTONUP:
                retval = BrowserWmLButtonUp(ref m);
                break;
            case (int)WindowMessage.WM_LBUTTONDBLCLK:
                retval = BrowserWmLButtonDbClick(ref m);
                break;
            case (int)WindowMessage.WM_MOUSEMOVE:
                retval = BrowserWmMouseMove(ref m);
                break;
            case (int)WindowMessage.WM_SETCURSOR:
                retval = BrowserWmSetCursor(ref m);
                break;
            case (int)WindowMessage.WM_NCHITTEST:
                retval = BrowserWmNCHitTest(ref m);
                break;
        }

        return retval;
    }



    private bool BrowserWmNCHitTest(ref Message m)
    {
        if (_isResizing)
        {
            return true;
        }

        return false;
    }



    internal void OnContextCreated(CefBrowser browser, CefFrame frame)
    {
        if (frame.IsMain)
        {
            AttachToChromeWidgetMessageHandler();
        }


        ContextCreated?.Invoke(this, new ContextCreatedEventArgs(browser, frame));


        if (WindowType == HostWindowType.Layered)
        {
            //var host = browser.GetHost();

            //host.ImeCommitText(string.Empty, new CefRange(int.MaxValue, int.MaxValue), 0);
            //host.ImeSetComposition(string.Empty, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));
            //host.ImeFinishComposingText(false);
            //SendMessage(HostWindowHandle, WindowMessage.WM_IME_KEYDOWN, 0);
        }



    }

    internal bool BrowserWmMouseMove(ref Message m)
    {
        if (FullScreen)
            return false;

        if (WindowState != FormWindowState.Normal)
            return false;

        var point = new Point(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var retval = IFormHostWindow.HitTest(point);

        if (retval != HitTestValues.HTNOWHERE)
        {
            var mode = retval;

            if (mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
            {
                return true;
            }
        }

        return false;
    }

    internal bool BrowserWmSetCursor(ref Message m)
    {
        if (FullScreen)
            return false;

        if (WindowState != FormWindowState.Normal)
            return false;

        if (!Sizable)
            return false;

        var pos = GetMessagePos();
        var point = new POINT(Macros.LOWORD(pos), Macros.HIWORD(pos));
        ScreenToClient(HostWindowHandle, ref point);

        var mode = IFormHostWindow.HitTest(point);

        if (mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
        {
            SetCursor(mode);

            m.Result = (IntPtr)1;

            return true;
        }

        return false;
    }


    internal bool BrowserWmLButtonDown(ref Message m)
    {
        if (FullScreen || WindowType == HostWindow.HostWindowType.Kiosk)
            return false;

        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = (WebView?.DraggableRegion?.IsVisible(point) ?? false);

        var mode = IFormHostWindow.HitTest(point);

        ClientToScreen(HostWindowHandle, ref point);

        if (Sizable && mode != HitTestValues.HTCLIENT && WindowState == FormWindowState.Normal)
        {
            ReleaseCapture();

            PostMessage(HostWindowHandle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)mode, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }
        else if (isInDraggableArea)
        {
            ReleaseCapture();

            PostMessage(HostWindowHandle, (uint)WindowMessage.WM_NCLBUTTONDOWN, (IntPtr)HitTestValues.HTCAPTION, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }
        //else
        //{
        //    PostMessage(HostWindowHandle, (uint)WindowMessage.WM_LBUTTONDOWN, m.WParam, m.LParam);
        //}



        return false;
    }

    internal bool BrowserWmRButtonDown(ref Message m)
    {
        if (!AllowSystemMenu)
        {
            return false;
        }

        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = (WebView?.DraggableRegion != null && WebView.DraggableRegion.IsVisible(point));

        if (isInDraggableArea)
        {
            ClientToScreen(HostWindowHandle, ref point);

            PostMessage(HostWindowHandle, (uint)WindowMessage.WM_NCRBUTTONDOWN, (IntPtr)HitTestValues.HTSYSMENU, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }

        return false;
    }

    internal bool BrowserWmRButtonUp(ref Message m)
    {
        if (!AllowSystemMenu)
        {
            return false;
        }

        var point = new POINT(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = (WebView?.DraggableRegion != null && WebView.DraggableRegion.IsVisible(point));

        if (isInDraggableArea)
        {
            ClientToScreen(HostWindowHandle, ref point);

            PostMessage(HostWindowHandle, (uint)WindowMessage.WM_NCRBUTTONUP, (IntPtr)HitTestValues.HTSYSMENU, Macros.MAKELPARAM((ushort)point.X, (ushort)point.Y));

            return true;
        }

        return false;
    }

    private bool BrowserWmLButtonUp(ref Message m)
    {
        return false;
    }

    internal bool BrowserWmLButtonDbClick(ref Message m)
    {
        var point = new Point(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

        var isInDraggableArea = (WebView?.DraggableRegion != null && WebView.DraggableRegion.IsVisible(point));

        if (isInDraggableArea && Maximizable && Sizable)
        {
            if (FullScreen)
            {
                return false;
            }

            PostMessage(HostWindowHandle, (uint)WindowMessage.WM_NCLBUTTONDBLCLK, (IntPtr)HitTestValues.HTCAPTION, IntPtr.Zero);

            return true;
        }

        return false;
    }

    internal void ResizeWebView()
    {
        if (!_isHostWindowCreated || !_isBrowserCreated || BrowserWindowHandle == IntPtr.Zero)
            return;

        GetClientRect(HostWindowHandle, out var rect);

        if (IsIconic(this.HostWindowHandle))
        {
            SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
        }
        else
        {

            if (IsWindowVisible(HostWindowHandle))
            {
                SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_SHOWWINDOW/* | SetWindowPosFlags.SWP_NOACTIVATE*/);

                SetWindowLong(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_VISIBLE));
            }
            else
            {
                SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_HIDEWINDOW);

                SetWindowLong(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_DISABLED));
            }
        }

    }


    internal void ResizeWebView(int width,int height)
    {
        if (!_isHostWindowCreated || !_isBrowserCreated || BrowserWindowHandle == IntPtr.Zero)
            return;

        //GetClientRect(HostWindowHandle, out var rect);

        if (IsIconic(this.HostWindowHandle))
        {
            SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
        }
        else
        {

            if (IsWindowVisible(HostWindowHandle))
            {
                SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, width, height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_SHOWWINDOW | SetWindowPosFlags.SWP_NOACTIVATE);

                SetWindowLong(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_VISIBLE));
            }
            else
            {
                SetWindowPos(BrowserWindowHandle, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_HIDEWINDOW);

                SetWindowLong(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_DISABLED));
            }
        }

    }


    internal void OnDataMessageReceived(string message, string json)
    {
        var args = new DataMessageReceivedArgs(message, json);
        DataMessageReceived?.Invoke(this, args);
    }

    /// <summary>
    /// Send empty message to client.
    /// </summary>
    /// <param name="message">Message name</param>
    public void SendDataMessage(string message)
    {
        ExecuteJavaScript($"Formium.__onDataMessageReceived__(`{message}`)");
    }

    /// <summary>
    /// Send messege to client.
    /// </summary>
    /// <typeparam name="T">Data type of message</typeparam>
    /// <param name="message">Message name</param>
    /// <param name="data">Data structure. The data will be serialize to JSON text when sending to client.</param>
    public void SendDataMessage<T>(string message, T data)
    {
        if (data == null)
        {
            ExecuteJavaScript($"Formium.__onDataMessageReceived__(`{message}`,``)");
        }
        else
        {
            var json = JsonSerializer.Serialize(data);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            ExecuteJavaScript($"Formium.__onDataMessageReceived__(`{message}`,`{base64}`)");

        }
    }


    #region Browser public members
    /// <summary>
    /// Returns true if current browser can navigate backwards.
    /// </summary>
    public bool CanGoBack => Browser?.CanGoBack ?? false;
    /// <summary>
    /// Returns true if current browser can navigate forwards.
    /// </summary>
    public bool CanGoForward => Browser?.CanGoForward ?? false;
    /// <summary>
    /// Returns the number of frames that currently exist.
    /// </summary>
    public int FrameCount => Browser?.FrameCount ?? 0;
    /// <summary>
    /// Returns true if a document has been loaded in the browser.
    /// </summary>
    public bool HasDocument => Browser?.HasDocument ?? false;
    /// <summary>
    /// Returns the globally unique identifier for this browser. This value is also
    /// used as the tabId for extension APIs.
    /// </summary>
    public int Identifier => Browser?.Identifier ?? 0;
    /// <summary>
    /// Returns true if the browser is currently loading.
    /// </summary>
    public bool IsLoading => Browser?.IsLoading ?? false;
    /// <summary>
    /// Returns true if the window is a popup window.
    /// </summary>
    public bool IsPopup => Browser?.IsPopup ?? false;
    /// <summary>
    /// Returns the focused frame for the browser window.
    /// </summary>
    public CefFrame GetFocusedFrame()
    {
        return Browser?.GetFocusedFrame();
    }
    /// <summary>
    /// Returns the frame with the specified identifier, or NULL if not found.
    /// </summary>
    /// <param name="identifier">The identifier of the frame to be get.</param>
    public CefFrame GetFrame(long identifier)
    {
        return Browser?.GetFrame(identifier);
    }
    /// <summary>
    /// Returns the frame with the specified name, or NULL if not found.
    /// </summary>
    /// <param name="name">The name of the frame to be get.</param>
    public CefFrame GetFrame(string name)
    {
        return Browser?.GetFrame(name);

    }
    /// <summary>
    /// Returns the identifiers of all existing frames.
    /// </summary>
    public long[] GetFrameIdentifiers()
    {
        return Browser?.GetFrameIdentifiers();

    }
    /// <summary>
    /// Returns the names of all existing frames.
    /// </summary>
    public string[] GetFrameNames()
    {
        return Browser?.GetFrameNames();

    }
    /// <summary>
    /// Returns the browser host object. This method can only be called in the
    /// browser process.
    /// </summary>
    public CefBrowserHost GetHost()
    {
        return Browser?.GetHost();
    }
    /// <summary>
    /// Returns the main (top-level) frame for the browser window.
    /// </summary>
    public CefFrame GetMainFrame()
    {
        return Browser?.GetMainFrame();

    }
    /// <summary>
    /// Navigate backwards.
    /// </summary>
    public void GoBack()
    {
        Browser?.GoBack();

    }
    /// <summary>
    /// Navigate forwards.
    /// </summary>
    public void GoForward()
    {
        Browser?.GoForward();
    }
    /// <summary>
    /// Returns true if this object is pointing to the same handle as |that|
    /// object.
    /// </summary>
    public bool IsSame(CefBrowser that)
    {
        return Browser?.IsSame(that) ?? false;
    }
    /// <summary>
    /// Reload the current page.
    /// </summary>
    public void Reload(bool forceReload = false)
    {
        if (forceReload)
        {
            Browser?.ReloadIgnoreCache();
        }
        else
        {
            Browser?.Reload();
        }
    }

    /// <summary>
    /// Load page from the
    /// </summary>
    /// <param name="url"></param>
    public void LoadUrl(string url)
    {

        if (Browser != null && Browser?.GetMainFrame() != null)
        {
            Browser.GetMainFrame().LoadUrl(url);

        }
        else
        {
            lock (_browserSyncRoot)
            {
                if (Browser != null && Browser?.GetMainFrame() != null)
                {
                    Browser.GetMainFrame().LoadUrl(url);
                }
                else
                {
                    _loadUrlDeferred = url;
                }
            }
        }


    }

    /// <summary>
    /// Stop loading the page.
    /// </summary>
    public void StopLoad()
    {
        Browser?.StopLoad();
    }


    DevToolsHostWindow devToolsWindow;


    /// <summary>
    /// Open developer tools (DevTools) in its own browser. The DevTools browser
    /// will remain associated with this browser. If the DevTools browser is
    /// already open then it will be focused.
    /// </summary>
    public void ShowDevTools()
    {
        InvokeIfRequired(() =>
        {

            if (WebView.BrowserHost == null)
            {
                return;
            }

            var windowInfo = CefWindowInfo.Create();


            if (devToolsWindow == null || devToolsWindow.IsDisposed)
            {
                devToolsWindow = new DevToolsHostWindow(this);
            }



            GetClientRect(devToolsWindow.Handle, out var rect);

            windowInfo.SetAsChild(devToolsWindow.Handle, new CefRectangle(0, 0, rect.Width, rect.Height));

            WebView.BrowserHost.ShowDevTools(windowInfo, new DevToolsBrowserClient(devToolsWindow), new CefBrowserSettings(), new CefPoint(0, 0));

            if (!devToolsWindow.Visible)
            {
                devToolsWindow.Show();

            }
        });
    }

    public void CloseDevTools()
    {
        WebView.BrowserHost.CloseDevTools();
    }



    #endregion

    #region Events
    /// <summary>
    /// Occurs when Formium is ready to use.
    /// </summary>
    //public event EventHandler Ready;

    internal protected event EventHandler<ContextCreatedEventArgs> ContextCreated;

    /// <summary>
    /// Occurs when DataMessage from Browser has arrived.
    /// </summary>
    public event EventHandler<DataMessageReceivedArgs> DataMessageReceived;

    /// <summary>
    /// Occurs before the browser is Created.
    /// </summary>
    public event EventHandler BrowserCreated;

    #region LifeSpanHandler
    /// <summary>
    /// Called on the UI thread before a new popup browser is created. The
    /// |browser| and |frame| values represent the source of the popup request. The
    /// |target_url| and |target_frame_name| values indicate where the popup
    /// browser should navigate and may be empty if not specified with the request.
    /// The |target_disposition| value indicates where the user intended to open
    /// the popup (e.g. current tab, new tab, etc). The |user_gesture| value will
    /// be true if the popup was opened via explicit user gesture (e.g. clicking a
    /// link) or false if the popup opened automatically (e.g. via the
    /// DomContentLoaded event). The |popupFeatures| structure contains additional
    /// information about the requested popup window. To allow creation of the
    /// popup browser optionally modify |windowInfo|, |client|, |settings| and
    /// |no_javascript_access| and return false. To cancel creation of the popup
    /// browser return true. The |client| and |settings| values will default to the
    /// source browser's values. If the |no_javascript_access| value is set to
    /// false the new browser will not be scriptable and may not be hosted in the
    /// same renderer process as the source browser. Any modifications to
    /// |windowInfo| will be ignored if the parent browser is wrapped in a
    /// CefBrowserView. Popup browser creation will be canceled if the parent
    /// browser is destroyed before the popup browser creation completes (indicated
    /// by a call to OnAfterCreated for the popup browser). The |extra_info|
    /// parameter provides an opportunity to specify extra information specific
    /// to the created popup browser that will be passed to
    /// CefRenderProcessHandler::OnBrowserCreated() in the render process.
    /// </summary>
    public event EventHandler<BeforePopupEventArgs> BeforePopup;
    /// <summary>
    /// Called just before a browser is destroyed. Release all references to the
    /// browser object and do not attempt to execute any methods on the browser
    /// object (other than GetIdentifier or IsSame) after this callback returns.
    /// This callback will be the last notification that references |browser| on
    /// the UI thread. Any in-progress network requests associated with |browser|
    /// will be aborted when the browser is destroyed, and
    /// CefResourceRequestHandler callbacks related to those requests may still
    /// arrive on the IO thread after this method is called. See DoClose()
    /// documentation for additional usage information.
    /// </summary>
    public event EventHandler<FormiumCloseEventArgs> BeforeClose;
    /// <summary>
    /// Raises the BeforePopup event.
    /// </summary>
    internal protected void OnBeforePopup(BeforePopupEventArgs e)
    {
        BeforePopup?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the BeforeClose event.
    /// </summary>
    internal protected void OnBeforeClose(FormiumCloseEventArgs e)
    {
        BeforeClose?.Invoke(this, e);
    }


    #endregion

    #region LoadHandler
    /// <summary>
    /// Called after a navigation has been committed and before the browser begins
    /// loading contents in the frame. The |frame| value will never be empty --
    /// call the IsMain() method to check if this frame is the main frame.
    /// |transition_type| provides information about the source of the navigation
    /// and an accurate value is only available in the browser process. Multiple
    /// frames may be loading at the same time. Sub-frames may start or continue
    /// loading after the main frame load has ended. This method will not be called
    /// for same page navigations (fragments, history state, etc.) or for
    /// navigations that fail or are canceled before commit. For notification of
    /// overall browser load status use OnLoadingStateChange instead.
    /// </summary>
    public event EventHandler<LoadStartEventArgs> LoadStart;
    /// <summary>
    /// Called when the browser is done loading a frame. The |frame| value will
    /// never be empty -- call the IsMain() method to check if this frame is the
    /// main frame. Multiple frames may be loading at the same time. Sub-frames may
    /// start or continue loading after the main frame load has ended. This method
    /// will not be called for same page navigations (fragments, history state,
    /// etc.) or for navigations that fail or are canceled before commit. For
    /// notification of overall browser load status use OnLoadingStateChange
    /// instead.
    /// </summary>
    public event EventHandler<LoadEndEventArgs> LoadEnd;
    /// <summary>
    /// Called when a navigation fails or is canceled. This method may be called
    /// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
    /// after commit. |errorCode| is the error code number, |errorText| is the
    /// error text and |failedUrl| is the URL that failed to load.
    /// See net\base\net_error_list.h for complete descriptions of the error codes.
    /// </summary>
    public event EventHandler<LoadErrorEventArgs> LoadError;
    /// <summary>
    /// Called when the loading state has changed. This callback will be executed
    /// twice -- once when loading is initiated either programmatically or by user
    /// action, and once when loading is terminated due to completion, cancellation
    /// of failure. It will be called before any calls to OnLoadStart and after all
    /// calls to OnLoadError and/or OnLoadEnd.
    /// </summary>
    public event EventHandler<LoadingStateChangeEventArgs> LoadingStateChanged;


    /// <summary>
    /// Raises the LoadStart event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnLoadStart(LoadStartEventArgs e)
    {
        LoadStart?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the LoadEnd event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnLoadEnd(LoadEndEventArgs e)
    {
        if (_isFirstTimeToRun && e.Frame.IsMain)
        {
            foreach (var script in DelayedScripts)
            {
                ExecuteJavaScript(script.Value);
            }

            DelayedScripts.Clear();

            _isFirstTimeToRun = false;
        }

        LoadEnd?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the LoadError event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnLoadError(LoadErrorEventArgs e)
    {
        LoadError?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the LoadingStateChanged event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnLoadingStateChanged(LoadingStateChangeEventArgs e)
    {
        LoadingStateChanged?.Invoke(this, e);
    }
    #endregion

    #region DisplayHandler
    /// <summary>
    /// Called when a frame's address has changed.
    /// </summary>
    public event EventHandler<AddressChangedEventArgs> AddressChanged;
    /// <summary>
    /// Called to display a console message. Return true to stop the message from
    /// being output to the console.
    /// </summary>
    public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
    /// <summary>
    /// Called when web content in the page has toggled fullscreen mode. If
    /// |fullscreen| is true the content will automatically be sized to fill the
    /// browser content area. If |fullscreen| is false the content will
    /// automatically return to its original size and position. The client is
    /// responsible for resizing the browser if desired.
    /// </summary>
    public event EventHandler<FullScreenModeChangedEventArgs> FullScreenModeChanged;
    /// <summary>
    /// Called when the overall page loading progress has changed. |progress|
    /// ranges from 0.0 to 1.0.
    /// </summary>
    public event EventHandler<LoadingProgressChangedEventArgs> LoadingProgressChanged;
    /// <summary>
    /// Called when the browser receives a status message. |value| contains the
    /// text that will be displayed in the status message.
    /// </summary>
    public event EventHandler<StatusMessageEventArgs> StatusMessage;
    /// <summary>
    /// Called when the page title changes.
    /// </summary>
    public event EventHandler<DocumentTitleChangedEventArgs> DocumentTitleChanged;
    /// <summary>
    /// Raises the AddressChanged event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnAddressChanged(AddressChangedEventArgs e)
    {
        AddressChanged?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the ConsoleMessage event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnConsoleMessage(ConsoleMessageEventArgs e)
    {
        ConsoleMessage?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the FullScreenModeChanged event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnFullscreenModeChanged(FullScreenModeChangedEventArgs e)
    {
        if (AllowFullScreen)
        {
            //TODO:FullScreen
            //FullScreen(e.Fullscreen);
            FullScreenModeChanged?.Invoke(this, e);
        }
        else
        {
            FullScreenModeChanged?.Invoke(this, new FullScreenModeChangedEventArgs(false));
        }

    }

    /// <summary>
    /// Raises the LoadingProgressChanged event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnLoadingProgressChanged(LoadingProgressChangedEventArgs e)
    {
        LoadingProgressChanged?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the StatusMessage event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnStatusMessage(StatusMessageEventArgs e)
    {
        StatusMessage?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the DocumentTitleChanged event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnDocumentTitleChanged(DocumentTitleChangedEventArgs e)
    {
        DocumentTitleChanged?.Invoke(this, e);
    }
    #endregion

    #region ContextMenuHandler
    /// <summary>
    /// Called before a context menu is displayed. |params| provides information
    /// about the context menu state. |model| initially contains the default
    /// context menu. The |model| can be cleared to show no context menu or
    /// modified to show a custom menu. Do not keep references to |params| or
    /// |model| outside of this callback.
    /// </summary>
    public event EventHandler<BeforeContextMenuEventArgs> BeforeContextMenu;

    /// <summary>
    /// Called to execute a command selected from the context menu. Return true if
    /// the command was handled or false for the default implementation. See
    /// cef_menu_id_t for the command ids that have default implementations. All
    /// user-defined command ids should be between MENU_ID_USER_FIRST and
    /// MENU_ID_USER_LAST. |params| will have the same values as what was passed to
    /// OnBeforeContextMenu(). Do not keep a reference to |params| outside of this
    /// callback.
    /// </summary>
    public event EventHandler<ContextMenuCommandEventArgs> ContextMenuCommand;
    /// <summary>
    /// Called when an external drag event enters the browser window. |dragData|
    /// contains the drag event data and |mask| represents the type of drag
    /// operation. Return false for default drag handling behavior or true to
    /// cancel the drag event.
    /// </summary>
    public event EventHandler<DragEnterEventArgs> DragEnter;
    /// <summary>
    /// Raises the BeforeContextMenu event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnBeforeContextMenu(BeforeContextMenuEventArgs e)
    {
        BeforeContextMenu?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the ContextMenuCommand event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnContextMenuCommand(ContextMenuCommandEventArgs e)
    {
        ContextMenuCommand?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the DragEnter event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnDragEnter(DragEnterEventArgs e)
    {
        DragEnter?.Invoke(this, e);
    }
    #endregion

    #region RequestHandler
    /// <summary>
    /// Called on the IO thread when the browser needs credentials from the user.
    /// |origin_url| is the origin making this authentication request. |isProxy|
    /// indicates whether the host is a proxy server. |host| contains the hostname
    /// and |port| contains the port number. |realm| is the realm of the challenge
    /// and may be empty. |scheme| is the authentication scheme used, such as
    /// "basic" or "digest", and will be empty if the source of the request is an
    /// FTP server. Return true to continue the request and call
    /// CefAuthCallback::Continue() either in this method or at a later time when
    /// the authentication information is available. Return false to cancel the
    /// request immediately.
    /// </summary>
    public event EventHandler<AuthCredentialsEventArgs> GetAuthCredentials;
    /// <summary>
    /// Called on the UI thread to handle requests for URLs with an invalid
    /// SSL certificate. Return true and call CefRequestCallback::Continue() either
    /// in this method or at a later time to continue or cancel the request. Return
    /// false to cancel the request immediately. If
    /// CefSettings.ignore_certificate_errors is set all invalid certificates will
    /// be accepted without calling this method.
    /// </summary>
    public event EventHandler<CertificateErrorEventArgs> CertificateError;

    /// <summary>
    /// Called on the UI thread before browser navigation. Return true to cancel
    /// the navigation or false to allow the navigation to proceed. The |request|
    /// object cannot be modified in this callback.
    /// CefLoadHandler::OnLoadingStateChange will be called twice in all cases.
    /// If the navigation is allowed CefLoadHandler::OnLoadStart and
    /// CefLoadHandler::OnLoadEnd will be called. If the navigation is canceled
    /// CefLoadHandler::OnLoadError will be called with an |errorCode| value of
    /// ERR_ABORTED. The |user_gesture| value will be true if the browser
    /// navigated via explicit user gesture (e.g. clicking a link) or false if it
    /// navigated automatically (e.g. via the DomContentLoaded event).
    /// </summary>
    public event EventHandler<BeforeBrowseEventArgs> BeforeBrowse;

    /// <summary>
    /// Called on the browser process UI thread when the render process
    /// terminates unexpectedly. |status| indicates how the process
    /// terminated.
    /// </summary>
    public event EventHandler<RenderProcessTerminatedEventArgs> RenderProcessTerminated;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public event EventHandler<GetResourceRequestHandlerEventArgs> GetResourceRequestHandler;


    internal protected virtual void OnGetResourceRequestHandler(GetResourceRequestHandlerEventArgs e)
    {
        GetResourceRequestHandler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the OnBeforeBrowse event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnBeforeBrowse(BeforeBrowseEventArgs e)
    {
        BeforeBrowse?.Invoke(this, e);
    }


    /// <summary>
    /// Raises the GetAuthCredentials event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnGetAuthCredentials(AuthCredentialsEventArgs e)
    {
        GetAuthCredentials?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the CertificateError event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnCertificateError(CertificateErrorEventArgs e)
    {
        CertificateError?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the RenderProcessTerminated event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnRenderProcessTerminated(RenderProcessTerminatedEventArgs e)
    {
        RenderProcessTerminated?.Invoke(this, e);
    }

    #endregion

    #region DownloadHandler
    /// <summary>
    /// Called before a download begins. |suggested_name| is the suggested name for
    /// the download file. By default the download will be canceled. Execute
    /// |callback| either asynchronously or in this method to continue the download
    /// if desired. Do not keep a reference to |download_item| outside of this
    /// method.
    /// </summary>
    public event EventHandler<BeforeDownloadEventArgs> BeforeDownload;
    /// <summary>
    /// Called when a download's status or progress information has been updated.
    /// This may be called multiple times before and after OnBeforeDownload().
    /// Execute |callback| either asynchronously or in this method to cancel the
    /// download if desired. Do not keep a reference to |download_item| outside of
    /// this method.
    /// </summary>
    public event EventHandler<DownloadUpdatedEventArgs> DownloadUpdated;

    /// <summary>
    /// Raises the BeforeDownload event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnBeforeDownload(BeforeDownloadEventArgs e)
    {
        if (BeforeDownload != null)
        {
            BeforeDownload.Invoke(this, e);
        }
        else
        {
            e.Continue(e.SuggestedName);
        }
    }
    /// <summary>
    /// Raises the DownloadUpdated event.
    /// </summary>
    /// <param name="e"></param>
    internal protected void OnDownloadUpdated(DownloadUpdatedEventArgs e)
    {
        DownloadUpdated?.Invoke(this, e);
    }
    #endregion

    #region KeyboardHandler
    /// <summary>
    /// Called after the renderer and JavaScript in the page has had a chance to
    /// handle the event. |event| contains information about the keyboard event.
    /// |os_event| is the operating system event message, if any. Return true if
    /// the keyboard event was handled or false otherwise.
    /// </summary>
    public event EventHandler<Browser.KeyEventArgs> KeyEvent;
    /// <summary>
    /// Called before a keyboard event is sent to the renderer. |event| contains
    /// information about the keyboard event. |os_event| is the operating system
    /// event message, if any. Return true if the event was handled or false
    /// otherwise. If the event will be handled in OnKeyEvent() as a keyboard
    /// shortcut set |is_keyboard_shortcut| to true and return false.
    /// </summary>
    public event EventHandler<PreKeyEventArgs> PreKeyEvent;
    /// <summary>
    /// Raises the PreKeyEvent event.
    /// </summary>
    internal protected void OnKeyEvent(Browser.KeyEventArgs e)
    {
        KeyEvent?.Invoke(this, e);
    }
    /// <summary>
    /// Raises the OnKeyEvent event.
    /// </summary>
    internal protected void OnPreKeyEvent(PreKeyEventArgs e)
    {
        PreKeyEvent?.Invoke(this, e);
    }

    #endregion

    #region FindHandler
    /// <summary>
    /// Called to report find results returned by CefBrowserHost::Find().
    /// |identifer| is the identifier passed to Find(), |count| is the number of
    /// matches currently identified, |selectionRect| is the location of where the
    /// match was found (in window coordinates), |activeMatchOrdinal| is the
    /// current position in the search results, and |finalUpdate| is true if this
    /// is the last find notification.
    /// </summary>
    public event EventHandler<FindResultEventArgs> FindResult;
    /// <summary>
    /// Raises the FindResult event.
    /// </summary>
    internal protected void OnFindResult(FindResultEventArgs e)
    {
        FindResult?.Invoke(this, e);
    }
    #endregion

    #region FocusHandler
    public event EventHandler<EventArgs> GotFocus;
    public event EventHandler<SetFocusEventArgs> SetFocus;
    public event EventHandler<TakeFocusEventArgs> TakeFocus;


    internal protected void OnGotFocus(EventArgs e)
    {
        GotFocus?.Invoke(this, e);
    }

    internal protected void OnSetFocus(SetFocusEventArgs e)
    {
        SetFocus?.Invoke(this, e);
    }

    internal protected void OnTakeFocus(TakeFocusEventArgs e)
    {
        TakeFocus?.Invoke(this, e);
    }
    #endregion

    #endregion
}

public class ContextCreatedEventArgs : EventArgs
{
    internal ContextCreatedEventArgs(CefBrowser browser, CefFrame frame)
    {
        this.Browser = browser;
        this.Frame = frame;
    }
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
}
