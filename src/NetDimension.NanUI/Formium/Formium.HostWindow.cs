namespace NetDimension.NanUI;

using NetDimension.NanUI.HostWindow;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

partial class Formium
{

    private const int SYSMENU_ABOUT_ID = 0x9001;

    private const int SYSMENU_FULL_SCREEN_ID = 0x9002;

    /// <summary>
    /// Sets the Window style of current window.
    /// </summary>
    public abstract HostWindowType WindowType { get; }

    #region HostWindow private members
    private bool _isHostWindowCreated = false;

    private string _title = Resources.Messages.HostWindow_DefaultTitle;
    private string _subtitle;

    private bool _sizable = true;
    private bool _maximizable = true;
    private bool _minimizable = true;
    private Icon _windowIcon = Properties.Resources.DefaultIcon;
    private Point? _location = null;
    private Size? _size = new Size(720, 480);
    private Size? _maximumSize;
    private Size? _minimumSize;
    private bool _showInTaskBar = true;
    private FormStartPosition? _startPosition;
    private FormWindowState _windowState = FormWindowState.Normal;
    private bool _topMost = false;
    private bool _isForceClosing = false;


    private DialogResult _dialogResult = DialogResult.None;

    private bool _allowFullScreen = true;

    private bool _fullScreen = false;

    /// <summary>
    /// Gets or sets a value that indicates HostWindow can be fullscreen.
    /// </summary>
    internal protected bool AllowFullScreen
    {
        get => _allowFullScreen && _sizable;
        set
        {
            if (value != _allowFullScreen)
            {
                _allowFullScreen = value;
                OnAllowFullScreenChanged();
            }
        }
    }


    #endregion

    #region HostWindow Properties
    /// <summary>
    /// Gets or sets the Title of the host window.
    /// </summary>
    public string Title
    {
        get => _title;
        set
        {
            if (value != _title)
            {
                _title = value;

                OnTitleChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Subtitle of the host window.
    /// </summary>
    public string Subtitle
    {
        get => _subtitle;
        set
        {
            if (value != _subtitle)
            {
                _subtitle = value;
                OnTitleChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Sizable of the host window.
    /// </summary>
    public bool Sizable
    {
        get => _sizable;
        set
        {
            if (value != _sizable)
            {
                _sizable = value;
                OnSizableChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Maximizable of the host window.
    /// </summary>
    public bool Maximizable
    {
        get => _maximizable;
        set
        {
            if (value != _maximizable)
            {
                _maximizable = value;

                OnMaximizableChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Minimizable of the host window.
    /// </summary>
    public bool Minimizable
    {
        get => _minimizable;
        set
        {
            if (value != _minimizable)
            {
                _minimizable = value;
                OnMinimizableChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Location of the host window.
    /// </summary>
    public Point Location
    {
        get => FormHostWindow?.Location ?? _location ?? Point.Empty;
        set
        {
            _location = value;
            OnLocationChanged();
        }
    }

    /// <summary>
    /// Gets or sets the Size of the host window.
    /// </summary>
    public Size Size
    {
        get => FormHostWindow?.Size ?? _size ?? Size.Empty;
        set
        {
            if (value != _size)
            {
                _size = value;
                OnSizeChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the MaximumSize of the host window.
    /// </summary>
    public Size MaximumSize
    {
        get => _maximumSize ?? Size.Empty;
        set
        {
            if (value != _maximumSize)
            {
                _maximumSize = value;
                OnMaximumSizeChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the MinimumSize of the host window.
    /// </summary>
    public Size MinimumSize
    {
        get => _minimumSize ?? Size.Empty;
        set
        {
            if (value != _minimumSize)
            {
                _minimumSize = value;
                OnMinimumSizeChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the ShowInTaskBar of the host window.
    /// </summary>
    public bool ShowInTaskBar
    {
        get => _showInTaskBar;
        set
        {
            if (value != _showInTaskBar)
            {
                _showInTaskBar = value;
                OnShowInTaskBarChanged();
            }
        }
    }

    /// <summary>
    /// Gets or sets the StartPosition of the host window.
    /// </summary>
    public FormStartPosition StartPosition
    {
        get => _startPosition ?? FormStartPosition.WindowsDefaultLocation;
        set
        {
            _startPosition = value;
            OnStartPostitionChanged();
        }
    }

    /// <summary>
    /// Gets or sets the WindowState of the host window.
    /// </summary>
    public FormWindowState WindowState
    {
        get => FormHostWindow?.WindowState ?? _windowState;
        set
        {
            _windowState = value;
            OnWindowStateChanged();
        }
    }

    /// <summary>
    /// Gets or sets the TopMost state of the host window.
    /// </summary>
    public bool TopMost
    {
        get => _topMost;
        set
        {
            _topMost = value;
            OnTopMostChanged();
        }
    }


    /// <summary>
    /// Gets or sets the fullscreen state of the host window.
    /// </summary>
    public bool FullScreen
    {
        get => _fullScreen;
        set
        {
            if (value != _fullScreen)
            {
                _fullScreen = value;
                OnFullScreenChanged();
            }
        }
    }


    /// <summary>
    /// Gets or sets the Icon of the host window.
    /// </summary>
    public Icon Icon
    {
        get => _windowIcon;
        set
        {
            _windowIcon = value;

            OnIconChanged();
        }
    }


    /// <summary>
    /// Gets or sets the DialogResult of the host window.
    /// </summary>
    public DialogResult DialogResult
    {
        get => _dialogResult;
        set
        {
            _dialogResult = value;
            OnDialogResultChanged();
        }
    }

    /// <summary>
    /// Gets or sets the Left of the host window.
    /// </summary>
    public int Left
    {
        get => FormHostWindow?.Left ?? 0;
        set
        {
            if (FormHostWindow != null)
                FormHostWindow.Left = value;
        }
    }

    /// <summary>
    /// Gets or sets the Top of the host window.
    /// </summary>
    public int Top
    {
        get => FormHostWindow?.Top ?? 0;
        set
        {
            if (FormHostWindow != null)
                FormHostWindow.Top = value;
        }
    }

    /// <summary>
    /// Gets or sets the Width of the host window.
    /// </summary>
    public int Width
    {
        get => FormHostWindow?.Width ?? 0;
        set
        {
            if (FormHostWindow != null)
                FormHostWindow.Width = value;
        }
    }

    /// <summary>
    /// Gets or sets the Height of the host window.
    /// </summary>
    public int Height
    {
        get => FormHostWindow?.Height ?? 0;
        set
        {
            if (FormHostWindow != null)
                FormHostWindow.Height = value;
        }
    }

    /// <summary>
    /// Gets the Win32 HWND handle of the host window.
    /// </summary>
    public IWin32Window WindowHandle => FormHostWindow;

    public bool IsDisposed => FormHostWindow?.IsDisposed ?? false;

    public bool Visible => FormHostWindow?.Visible ?? false;


    /// <summary>
    /// You can disalbe About Menu in System Command Menu here, but you 
    /// must follow the LICENCE of NanUI Project at https://github.com/NetDimension/NanUI/blob/master/LICENCE
    /// </summary>
    protected virtual bool DisableAboutMenu => false;

    public IWin32Window OwnerHandle => FormHostWindow.Owner;

    public Form Owner => FormHostWindow.Owner;


    #endregion

    /// <summary>
    /// SplashScreen
    /// </summary>
    internal protected Splash SplashScreen { get; private set; }

    #region HostWindow Methods
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Active()
    {
        FormHostWindow?.Activate();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the Mask Panel allows to show on startup.
    /// </summary>
    public bool EnableSplashScreen { get; set; } = true;

    public void ShowAboutDialog()
    {
        InvokeIfRequired(() =>
        {
            var aboutDlg = new AboutDialog();
            aboutDlg.ShowDialog(WindowHandle);
        });

    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Show()
    {
        FormHostWindow.Show();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Show(IWin32Window owner)
    {
        FormHostWindow.Show(owner);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Show(Formium owner)
    {
        FormHostWindow.Show(owner.FormHostWindow);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DialogResult ShowDialog()
    {
        return FormHostWindow.ShowDialog();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DialogResult ShowDialog(IWin32Window owner)
    {
        return FormHostWindow.ShowDialog(owner);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DialogResult ShowDialog(Formium owner)
    {
        return FormHostWindow.ShowDialog(owner.FormHostWindow);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Close(bool force = false)
    {
        if (force)
        {
            _isForceClosing = true;
        }
        else
        {
            _isForceClosing = false;
        }

        InvokeIfRequired(() => FormHostWindow?.Close());

    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Hide()
    {
        FormHostWindow.Hide();
    }
    #endregion

    #region Overrides
    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    protected virtual bool WindowWndProc(ref Message m)
    {
        return false;
    }

    /// <summary>
    /// Processes Windows def messages.
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    protected virtual bool WindowDefWndProc(ref Message m)
    {
        return false;
    }

    /// <summary>
    /// Combine subtile and main title of the window.
    /// </summary>
    internal protected virtual string GetWindowTitle()
    {
        if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Subtitle))
        {
            return $"{Subtitle} - {Title}";
        }
        else if (string.IsNullOrEmpty(Title))
        {
            return Subtitle;
        }

        return Title;
    }
    #endregion

    /// <summary>
    /// Invokes action in the UI thread of current window.
    /// </summary>
    /// <param name="a"></param>
    public void InvokeIfRequired(Action a)
    {
        if (FormHostWindow != null && !FormHostWindow.IsDisposed)
        {
            FormHostWindow.InvokeIfRequired(a);
        }
    }

    internal Form FormHostWindow { get; private set; }

    internal IFormiumHostWindow IFormHostWindow { get; private set; }

    internal void CreateHostWindow()
    {

        Form innerWindow = null;

        switch (WindowType)
        {
            case HostWindowType.System:
                innerWindow = new StandardHostWindow(this);
                _currentHostWindowStyle = new SystemWindowStyle(innerWindow);

                break;
            case HostWindowType.SystemBorderless:
                innerWindow = new DwmFramelessHostWindow(this);
                _currentHostWindowStyle = new SystemBorderlessWindowStyle(innerWindow);

                break;
            case HostWindowType.Borderless:
                innerWindow = new FramelessHostWindow(this);
                _currentHostWindowStyle = new BorderlessWindowStyle(innerWindow);

                break;
            case HostWindowType.Kiosk:
                Sizable = false;
                AllowFullScreen = false;
                innerWindow = new StandardHostWindow(this);
                _currentHostWindowStyle = new KioskWindowStyle(innerWindow);
                innerWindow.FormBorderStyle = FormBorderStyle.None;
                innerWindow.WindowState = FormWindowState.Maximized;

                break;
            case HostWindowType.Layered:
                _sizable = false;
                _fullScreen = false;
                AllowFullScreen = false;
                Maximizable = false;
                Sizable = false;
                innerWindow = new LayeredStyleHostWindow(this)
                {
                    ShadowEffect = ShadowEffect.None,
                    CornerStyle = CornerStyle.None,
                    FormBorderStyle = FormBorderStyle.FixedSingle
                };


                WinFormium.DefaultBrowserSettings.WindowlessFrameRate = 60;
                _currentHostWindowStyle = new LayeredWindowStyle(innerWindow);
                break;
            //case HostWindowType.Acrylic:
            //    _currentHostWindowStyle = new AcrylicWindowStyle(this);
            //    _fullScreen = false;
            //    FormHostWindow = new AcrylicStyleHostWindow(this);
            //    break;
            case HostWindowType.Custom:
                break;
        }



        FormHostWindow = innerWindow;


        if (FormHostWindow == null)
        {
            throw new InvalidOperationException();
        }

        if (WindowType != HostWindowType.Kiosk)
        {
            FormHostWindow.TopMost = _topMost;
            FormHostWindow.Location = _location ?? Location;
            FormHostWindow.Size = _size ?? Size;
            FormHostWindow.StartPosition = StartPosition;
            FormHostWindow.FormBorderStyle = Sizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
            FormHostWindow.MaximizeBox = Maximizable;
            FormHostWindow.MinimizeBox = Minimizable;
            FormHostWindow.WindowState = _windowState;
            FormHostWindow.ShowInTaskbar = ShowInTaskBar;
            FormHostWindow.MinimumSize = MinimumSize;
            FormHostWindow.MaximumSize = MaximumSize;
            FormHostWindow.DialogResult = DialogResult;
        }

        SplashScreen = new Splash(this);


        FormHostWindow.Icon = Icon;

        FormHostWindow.HandleCreated += FormHostWindowHandleCreated;
        FormHostWindow.Load += FormHostWindowLoad;
        FormHostWindow.Resize += FormHostWindowResize;
        FormHostWindow.ResizeBegin += FormHostWindowResizeBegin;
        FormHostWindow.ResizeEnd += FormHostWindowResizeEnd;
        FormHostWindow.Move += FormHostWindowMove;
        FormHostWindow.Shown += FormHostWindowShown;
        FormHostWindow.VisibleChanged += FormHostWindowVisibleChanged;
        FormHostWindow.FormClosing += FormHostWindowFormClosing;
        

        IFormHostWindow = (IFormiumHostWindow)FormHostWindow;

        IFormHostWindow.OnWindowsMessage = OnHostWindowWndProc;
        IFormHostWindow.OnDefWindowsMessage = OnHostWindowDefWndProc;



    }

    #region HostWindowEvents
    private void FormHostWindowMove(object sender, EventArgs e)
    {
    }

    private void FormHostWindowVisibleChanged(object sender, EventArgs e)
    {
    }

    private void FormHostWindowShown(object sender, EventArgs e)
    {
    }

    bool _isResizing = false;
    private void FormHostWindowResizeBegin(object sender, EventArgs e)
    {
        _isResizing = true;
        WebView?.BrowserHost?.NotifyMoveOrResizeStarted();
    }

    private void FormHostWindowResizeEnd(object sender, EventArgs e)
    {
        WebView?.BrowserHost?.WasResized();
        _isResizing = false;
    }

    private void FormHostWindowResize(object sender, EventArgs e)
    {
    }

    private void FormHostWindowHandleCreated(object sender, EventArgs e)
    {
        HostWindowHandle = FormHostWindow.Handle;


        var hSysMenu = GetSystemMenu(HostWindowHandle, false);

        InsertMenu(hSysMenu, (uint)SysCommand.SC_CLOSE, MenuFlags.MF_BYCOMMAND, (IntPtr)SYSMENU_FULL_SCREEN_ID, Resources.Messages.SystemMenu_FullScreen);

        InsertMenu(hSysMenu, (uint)SysCommand.SC_CLOSE, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_SEPARATOR, IntPtr.Zero, string.Empty);

        if (!DisableAboutMenu)
        {
            AppendMenu(hSysMenu, MenuFlags.MF_SEPARATOR, IntPtr.Zero, string.Empty);
            AppendMenu(hSysMenu, MenuFlags.MF_STRING, (IntPtr)SYSMENU_ABOUT_ID, Resources.Messages.SystemMenu_About);
        }

        OnAllowFullScreenChanged();

        CreateBrowser();

        RegisterHostWindowJavascriptEventHandler();

        FormHostWindow.Activate();
        _isHostWindowCreated = true;

    }

    private void FormHostWindowLoad(object sender, EventArgs e)
    {
        if (_isFullScreenRequired)
        {
            OnFullScreenChanged();
        }

        SplashScreen?.AdjustPanelSize();

        if (EnableSplashScreen && WindowType != HostWindowType.Layered)
        {
            SplashScreen?.ShowPanel();
        }
    }


    private void FormHostWindowFormClosing(object sender, FormClosingEventArgs e)
    {
        if(_isForceClosing || e.CloseReason!= CloseReason.UserClosing)
        {
            return;
        }

        var args = new Browser.FormiumCloseEventArgs();

        OnBeforeClose(args);

        e.Cancel = args.Canceled;

        if (!e.Cancel)
        {
            Browser.GetHost().CloseBrowser();
        }
    }
    #endregion

    private bool OnHostWindowWndProc(ref Message m)
    {
        const string FORMIUM_ACTIVATED = "formium-app-activated";
        const string FORMIUM_DEACTIVATE = "formium-app-deactivate";

        if (m.Msg == (int)WindowMessage.WM_SIZE)
        {
            ResizeWebView();
        }

        if(m.Msg == (int)WindowMessage.WM_ACTIVATEAPP)
        {
            var isAppActivate = false;

            if (m.WParam != IntPtr.Zero)
            {
                isAppActivate = true;
            }


            var sb = new StringBuilder();

            if (isAppActivate)
            {
                sb.AppendLine($@"(function(){{

    const html =  document.querySelector(`html`);

    html && html.classList.remove(`{FORMIUM_DEACTIVATE}`);    
    html && html.classList.add(`{FORMIUM_ACTIVATED}`);

if(typeof {JS_EVENT_RAISER_NAME} === 'undefined') return;

{JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""appactivated"", {{}});
{JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""appactivatestatechange"", {{ activated: true }});

}})();");

            }
            else
            {
                sb.AppendLine($@"(function(){{

    const html =  document.querySelector(`html`);

    html && html.classList.add(`{FORMIUM_DEACTIVATE}`);    
    html && html.classList.remove(`{FORMIUM_ACTIVATED}`);

if(typeof {JS_EVENT_RAISER_NAME} === 'undefined') return;

{JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""appdeactivate"", {{}});
{JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""appactivatestatechange"", {{ activated: false }});

}})();");
            }

            if (!IsWebViewReady)
            {
                DelayedScripts["appactivatestatechange"] = sb.ToString();
            }


            ExecuteJavaScript(sb.ToString());

        }

        if (m.Msg == (int)WindowMessage.WM_NCRBUTTONUP)
        {
            var point = new Point(Macros.GET_X_LPARAM(m.LParam), Macros.GET_Y_LPARAM(m.LParam));

            ShowSystemMenu(ref point);
        }

        if (m.Msg == (int)WindowMessage.WM_SYSCOMMAND)
        {
            var cmd = (int)m.WParam;

            if (cmd == SYSMENU_FULL_SCREEN_ID)
            {
                FullScreen = true;
            }

            if(cmd== SYSMENU_ABOUT_ID)
            {
                var aboutDlg = new AboutDialog();

                aboutDlg.ShowDialog(WindowHandle);
            }

            if (cmd == (int)SysCommand.SC_RESTORE)
            {

                if (FormHostWindow.WindowState != FormWindowState.Minimized && FullScreen)
                {
                    FullScreen = false;
                    return true;
                }
            }
        }

        var retval = WindowWndProc(ref m);

        return retval;
    }

    private bool OnHostWindowDefWndProc(ref Message m)
    {
        var retval = WindowWndProc(ref m);
        return retval;
    }

    #region Property Changed

    private FormBorderStyle _lastFormBorderStyle;

    private FormWindowState _lastFormWindowState;

    private bool _isFullScreenRequired = false;

    private void OnFullScreenChanged()
    {

        if (!AllowFullScreen)
        {
            return;
        }

        if (!_isHostWindowCreated)
        {
            _isFullScreenRequired = true;

            return;
        }

        var hSysMenu = GetSystemMenu(HostWindowHandle, false);

        if (FullScreen)
        {
            _lastFormBorderStyle = FormHostWindow.FormBorderStyle;
            _lastFormWindowState = FormHostWindow.WindowState;

            FormHostWindow.FormBorderStyle = FormBorderStyle.None;
            FormHostWindow.WindowState = FormWindowState.Normal;
            FormHostWindow.WindowState = FormWindowState.Maximized;
            EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_DISABLED);
        }
        else
        {
            FormHostWindow.FormBorderStyle = _lastFormBorderStyle;

            if (_lastFormWindowState == FormWindowState.Maximized)
            {
                FormHostWindow.WindowState = FormWindowState.Normal;
            }
            else
            {
                FormHostWindow.WindowState = _lastFormWindowState;
            }

            EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_ENABLED);
        }
    }

    private void OnAllowFullScreenChanged()
    {
        var hSysMenu = GetSystemMenu(HostWindowHandle, false);


        if (AllowFullScreen)
        {
            EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_ENABLED);
        }
        else
        {
            EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, MenuFlags.MF_BYCOMMAND | MenuFlags.MF_DISABLED);
        }
    }

    private void OnTitleChanged()
    {
        if (FormHostWindow != null)
        {
            InvokeIfRequired(() => FormHostWindow.Text = GetWindowTitle());
        }
    }

    private void OnSizableChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.FormBorderStyle = Sizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
    }

    private void OnMaximizableChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.MaximizeBox = Maximizable;
    }
    private void OnMinimizableChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.MinimizeBox = Minimizable;
    }
    private void OnLocationChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.Location = _location ?? Location;
    }
    private void OnSizeChanged()
    {
        if (FormHostWindow != null)
        {
            FormHostWindow.Size = _size ?? Size;

            SplashScreen?.AdjustPanelSize();
        }
    }

    private void OnMaximumSizeChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.MaximumSize = MaximumSize;
    }

    private void OnMinimumSizeChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.MinimumSize = MinimumSize;
    }
    private void OnShowInTaskBarChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.ShowInTaskbar = _showInTaskBar;
    }

    private void OnStartPostitionChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.StartPosition = _startPosition ?? StartPosition;
    }

    private void OnWindowStateChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.WindowState = _windowState;
    }

    private void OnTopMostChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.TopMost = TopMost;
    }



    private void OnIconChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.Icon = Icon;
    }

    private void OnDialogResultChanged()
    {
        if (FormHostWindow != null)
            FormHostWindow.DialogResult = DialogResult;
    }
    #endregion




}
