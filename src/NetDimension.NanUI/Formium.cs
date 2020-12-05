using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.Browser;
using Xilium.CefGlue;
using System.Threading.Tasks;
using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.Logging;
using System.Threading;

namespace NetDimension.NanUI
{
    public abstract partial class Formium : IDisposable
    {

        #region Private members
        private readonly ChromeWidgetMessageInterceptor chromeWidgetMessageInterceptor = null;

        private Dictionary<string, string> DelayedScripts { get; } = new Dictionary<string, string>();

        const string JS_EVENT_RAISER_NAME = "__formium_raiseHostWindowEvent";

        private string _title = Resources.Messages.HostWindow_DefaultTitle;

        private string _subtitle = string.Empty;

        private bool _resizable = true;

        private bool _isWindowLoaded;

        private bool _isBrowserCreated;

        private bool _isForceClosing = false;

        private const int SYSMENU_ABOUT_ID = 0x9001;

        private const int SYSMENU_FULL_SCREEN_ID = 0x9002;

        private bool _allowFullScreenMenu = false;

        private FormBorderStyle _lastFormBorderStyle;

        private FormWindowState _lastFormWindowState;

        private bool _isFirstTimeToRun = true;


        private readonly object _browserSyncRoot = new object();

        private string _loadUrlDeferred;
        private string _loadStringDeferred;

        private bool _isMinimized = false;

        #endregion

        internal FormiumWebView WebView { get; private set; }

        internal protected bool IsMainFrameLoaded { get; private set; } = false;


        internal Form HostWindowInternal { get; private set; }
        /// <summary>
        /// Gets the instance of the CefBrowser using in current window.
        /// </summary>
        internal protected CefBrowser Browser => WebView?.Browser;
        /// <summary>
        /// Invokes action in the UI thread of current window.
        /// </summary>
        /// <param name="a"></param>
        internal protected void InvokeIfRequired(Action a) => HostWindowInternal?.InvokeIfRequired(a);
        /// <summary>
        /// Posts action to the UI thread of current window.
        /// </summary>
        /// <param name="a"></param>
        /// 
        internal protected void PostUIThread(Action a) => GetIHostWindow()?.PostUIThread(a);
        /// <summary>
        /// Gets a value indicating whether the WebView is ready to use.
        /// </summary>
        protected bool IsWebViewReady => WebView?.WebViewIsReady ?? false;


        private IFormiumHostWindow GetIHostWindow()
        {
            return (IFormiumHostWindow)HostWindowInternal;
        }

        #region Events
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
                FullScreen(e.Fullscreen);
            }

            FullScreenModeChanged?.Invoke(this, e);

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
        #endregion

        #region Window public members
        /// <summary>
        /// 
        /// </summary>
        public IWin32Window HostWindow => HostWindowInternal;
        /// <summary>
        /// Gets a value indicating whether the Formium is in full screen mode.
        /// </summary>
        public bool IsFullScreen { get; private set; }
        /// <summary>
        /// Gets the handle of the host window.
        /// </summary>
        internal protected IntPtr HostWindowHandle { get; private set; }
        /// <summary>
        /// Gets the handle of the browser window.
        /// </summary>
        internal protected IntPtr BrowserWindowHandle => WebView?.BrowserHost?.GetWindowHandle() ?? IntPtr.Zero;
        /// <summary>
        /// Sets the window type of current window, this value can not changed when host window is created.
        /// </summary>
        public abstract HostWindowType WindowType { get; }
        /// <summary>
        /// Sets the startup url.
        /// </summary>
        public abstract string StartUrl { get; }
        /// <summary>
        /// Gets or sets the system menu will show when right clicking in dragable regions.
        /// </summary>
        public bool AllowSystemMenu { get; set; } = true;

        protected ILogger Logger => WinFormium.GetLogger();

        ///// <summary>
        ///// When the host window is loaded.
        ///// </summary>
        //protected virtual void OnWindowLoad()
        //{

        //}

        /// <summary>
        /// Gets or sets  a value indicating whether the formium allows to full screen mode.
        /// </summary>
        public bool AllowFullScreen
        {
            get => _allowFullScreenMenu;
            set
            {

                if (WindowType == HostWindowType.Layered || WindowType == HostWindowType.Kiosk)
                {
                    throw new InvalidOperationException($"{nameof(AllowFullScreen)} property cannot be set in {WindowType} style.");
                }

                if (value != _allowFullScreenMenu)
                {
                    _allowFullScreenMenu = value;
                }

                OnFullScreenMenuStateChanged();
            }
        }

        public void ShowAboutDialog()
        {
            var aboutDlg = new AboutDialog();

            aboutDlg.ShowDialog(HostWindow);
        }


        /// <summary>
        /// Gets or sets a value indicating whether the Mask Panel allows to show on startup.
        /// </summary>
        public bool AutoShowMask { get; set; } = true;

        /// <summary>
        /// Gets or sets the main title associated with this window.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnTitleChanged();
            }
        }
        /// <summary>
        /// Gets or sets the subtitle associated with this window.
        /// </summary>
        public string Subtitle
        {
            get => _subtitle;
            set
            {
                _subtitle = value;
                OnTitleChanged();
            }
        }
        /// <summary>
        /// Gets or sets the icon for the form.
        /// </summary>
        public Icon Icon
        {
            get => HostWindowInternal.Icon;
            set => HostWindowInternal.Icon = value;
        }
        /// <summary>
        /// Gets or sets the System.Drawing.Point that represents the upper-left corner of current window in screen coordinates.
        /// </summary>
        public Point Location
        {
            get => HostWindowInternal.Location;
            set => HostWindowInternal.Location = value;
        }
        /// <summary>
        /// Gets or sets the size of the window.
        /// </summary>
        public Size Size
        {
            get => HostWindowInternal.Size;
            set {
                HostWindowInternal.ClientSize = value;
                Mask.AdjustPanelSize();
            }
        }
        /// <summary>
        /// Gets or sets the size of the client area of the window.
        /// </summary>
        public Size ClientSize
        {
            get
            {
                return HostWindowInternal.ClientSize;
            }
        }
        /// <summary>
        /// Gets the maximum size the window can be resized to.
        /// </summary>
        public Size MaximumSize
        {
            get => HostWindowInternal.MaximumSize;
            set => HostWindowInternal.MaximumSize = value;
        }
        /// <summary>
        /// Gets or sets the minimum size the window can be resized to.
        /// </summary>
        public Size MinimumSize
        {
            get => HostWindowInternal.MinimumSize;
            set => HostWindowInternal.MinimumSize = value;
        }
        /// <summary>
        /// Gets or sets a value indicating whether the window is displayed in the Windows taskbar.
        /// </summary>
        public bool ShowInTaskbar
        {
            get => HostWindowInternal.ShowInTaskbar;
            set
            {
                if (WindowType == HostWindowType.Kiosk)
                {
                    throw new InvalidOperationException($"{nameof(ShowInTaskbar)} property cannot be set in Kiosk style.");
                }

                HostWindowInternal.ShowInTaskbar = value;
            }
        }
        /// <summary>
        /// Gets or sets the starting position of the window at run time.
        /// </summary>
        public FormStartPosition StartPosition
        {
            get => HostWindowInternal.StartPosition;
            set
            {
                if (WindowType == HostWindowType.Kiosk)
                {
                    throw new InvalidOperationException($"{nameof(StartPosition)} property cannot be set in Kiosk style.");
                }

                HostWindowInternal.StartPosition = value;
            }
        }

        FormWindowState? _deferredWindowState = null;
        /// <summary>
        /// Gets or sets a value that indicates whether window is minimized, maximized, or normal.
        /// </summary>
        public FormWindowState WindowState
        {
            get => HostWindowInternal.WindowState;
            set
            {
                if (WindowType == HostWindowType.Kiosk)
                {
                    throw new InvalidOperationException($"{nameof(WindowState)} property cannot be set in {WindowType} style.");
                }

                if (WindowType == HostWindowType.Layered && value == FormWindowState.Maximized)
                {
                    throw new InvalidOperationException($"{nameof(WindowState)} property cannot be set to {value} in {WindowType} style.");

                }

                if (_isWindowLoaded)
                {
                    HostWindowInternal.WindowState = value;

                }
                else
                {
                    _deferredWindowState = value;
                }



            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the window should be displayed as a topmost 
        /// </summary>
        public bool TopMost
        {
            get => HostWindowInternal.TopMost;
            set => HostWindowInternal.TopMost = value;
        }
        /// <summary>
        /// Gets or sets the width of the window.
        /// </summary>
        public int Width
        {
            get => HostWindowInternal.Width;
            set => HostWindowInternal.Width = value;
        }
        /// <summary>
        /// Gets or sets the height of the window.
        /// </summary>
        public int Height
        {
            get => HostWindowInternal.Height;
            set => HostWindowInternal.Height = value;
        }
        /// <summary>
        /// Gets or sets the distance, in pixels, between the left edge of the window and the left edge in current desktop area.
        /// </summary>
        public int Left
        {
            get => HostWindowInternal.Left;
            set => HostWindowInternal.Left = value;
        }
        /// <summary>
        /// Gets or sets the distance, in pixels, between the top edge of the window and the top edge in current desktop area.
        /// </summary>
        public int Top
        {
            get => HostWindowInternal.Top;
            set => HostWindowInternal.Top = value;
        }

        public bool Visible
        {
            get => HostWindowInternal?.Visible ?? false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window can be resize.
        /// </summary>
        public bool Resizable
        {
            get => _resizable;
            set
            {

                if (WindowType == HostWindowType.Kiosk || WindowType == HostWindowType.Layered)
                {
                    _resizable = false;
                    throw new InvalidOperationException($"{nameof(Resizable)} property cannot be set in {WindowType} style.");
                }
                else
                {
                    _resizable = value;

                    if (_resizable)
                    {
                        HostWindowInternal.FormBorderStyle = FormBorderStyle.Sizable;
                    }
                    else
                    {
                        HostWindowInternal.FormBorderStyle = FormBorderStyle.FixedSingle;
                    }
                }


            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the maximize behavior is allowed to perform.
        /// </summary>
        public bool CanMaximize
        {
            get => HostWindowInternal.MaximizeBox;
            set
            {
                if (WindowType == HostWindowType.Kiosk || WindowType == HostWindowType.Layered)
                {

                    HostWindowInternal.MaximizeBox = false;
                    throw new InvalidOperationException($"{nameof(CanMaximize)} property cannot be set in {WindowType} style.");
                }
                else
                {
                    HostWindowInternal.MaximizeBox = value;
                }

            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the minimize behavior is allowed to perform.
        /// </summary>
        public bool CanMinimize
        {
            get => HostWindowInternal.MinimizeBox;
            set
            {
                if (WindowType == HostWindowType.Kiosk)
                {
                    HostWindowInternal.MinimizeBox = false;
                    throw new InvalidOperationException($"{nameof(CanMinimize)} property cannot be set in Kiosk style.");
                }
                else
                {
                    HostWindowInternal.MinimizeBox = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        internal protected BorderlessWindowStyle BorderlessWindowProperties { get; private set; } = null;
        /// <summary>
        /// 
        /// </summary>
        internal protected KioskWindowStyle KioskWindowProperties { get; private set; } = null;
        /// <summary>
        /// 
        /// </summary>
        internal protected SystemWindowStyle SystemWindowProperties { get; private set; } = null;
        /// <summary>
        /// 
        /// </summary>
        internal protected AcrylicWindowStyle AcrylicWindowProperties { get; private set; } = null;
        /// <summary>
        /// Makes the window to full screen mode.
        /// </summary>
        /// <param name="toggle"></param>
        public void FullScreen(bool toggle)
        {
            if (toggle == IsFullScreen)
                return;

            HostWindowInternal.InvokeIfRequired(() =>
            {

                if (toggle)
                {
                    _lastFormBorderStyle = HostWindowInternal.FormBorderStyle;
                    _lastFormWindowState = HostWindowInternal.WindowState;


                    HostWindowInternal.FormBorderStyle = FormBorderStyle.None;
                    HostWindowInternal.WindowState = FormWindowState.Normal;
                    HostWindowInternal.WindowState = FormWindowState.Maximized;

                    IsFullScreen = true;
                }
                else
                {
                    HostWindowInternal.FormBorderStyle = _lastFormBorderStyle;
                    if (_lastFormWindowState == FormWindowState.Maximized)
                    {
                        HostWindowInternal.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        HostWindowInternal.WindowState = _lastFormWindowState;
                    }

                    IsFullScreen = false;
                }

                EnableFullScreenCommand(!toggle);
            });
        }

        public void Active()
        {
            HostWindowInternal?.Activate();
        }

        /// <summary>
        /// Displays the form to the users
        /// </summary>
        public void Show()
        {
            
            HostWindowInternal.Show();
        }

        /// <summary>
        /// Shows the form with the specified owner to the user.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements System.Windows.Forms.IWin32Window and represents the
        ///     top-level window that will own this form.
        /// </param>
        public void Show(IWin32Window owner)
        {
            HostWindowInternal.Show(owner);
        }
        /// <summary>
        /// Shows the form with the specified owner to the user.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements System.Windows.Forms.IWin32Window and represents the
        ///     top-level window that will own this form.
        /// </param>
        public void Show(Formium owner)
        {
            HostWindowInternal.Show(owner.HostWindowInternal);
        }

        /// <summary>
        /// Shows the form as a modal dialog box.
        /// </summary>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public DialogResult ShowDialog()
        {
            return HostWindowInternal.ShowDialog();
        }

        /// <summary>
        /// Shows the form as a modal dialog box with the specified owner.
        /// </summary>
        /// <param name="owner">Any object that implements System.Windows.Forms.IWin32Window that represents the top-level window that will own the modal dialog box.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public DialogResult ShowDialog(IWin32Window owner)
        {
            return HostWindowInternal.ShowDialog(owner);
        }

        /// <summary>
        /// Shows the form as a modal dialog box with the specified owner.
        /// </summary>
        /// <param name="owner">Any object that implements Formium that represents the top-level window that will own the modal dialog box.</param>
        /// <returns></returns>
        public DialogResult ShowDialog(Formium owner)
        {
            return HostWindowInternal.ShowDialog(owner.HostWindowInternal);
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        public void Close(bool force = false)
        {

            //((IFormiumHostWindow)HostWindowInternal).PostUIThread(() =>
            //{

            //});

            if (force)
            {

                WebView.BrowserHost.CloseBrowser(true);
                _isForceClosing = true;

                //HostWindowInternal?.Close();
            }
            else
            {
                var e = new FormiumCloseEventArgs();

                OnBeforeClose(e);

                if (!e.Canceled)
                {
                    WebView.BrowserHost.CloseBrowser(true);
                    _isForceClosing = true;
                }

            }
        }

        /// <summary>
        /// Hides the form.
        /// </summary>
        public void Hide()
        {
            ((IFormiumHostWindow)HostWindowInternal).PostUIThread(() => HostWindowInternal.Hide());
        }






        #endregion

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
        /// <summary>
        /// Execute a string of JavaScript code in main frame.
        /// </summary>
        /// <param name="code">The javascript code that will be executed.</param>
        public void ExecuteJavaScript(string code)
        {
            Browser?.GetMainFrame()?.ExecuteJavaScript(code, Browser.GetMainFrame().Url, 0);
        }
        /// <summary>
        /// Execute a string of JavaScript code in main frame and get result asynchronously.
        /// </summary>
        /// <param name="code">The javascript code that will be executed.</param>
        public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(string code)
        {
            var frame = Browser.GetMainFrame();
            return WebView.JSBridge.EvaluatorJavaScript(frame, code);
        }
        /// <summary>
        /// Register JavaScript object into Formium.external object.
        /// </summary>
        /// <param name="name">The name of the object will be registered.</param>
        /// <param name="value">The JavaScriptValue of object type.</param>
        public void RegisterExternalObjectValue(string name, JavaScriptValue value)
        {
            WebView.JSBridge.RegisterJavaScriptObjectValue(name, value);
        }

        /// <summary>
        /// Open developer tools (DevTools) in its own browser. The DevTools browser
        /// will remain associated with this browser. If the DevTools browser is
        /// already open then it will be focused.
        /// </summary>
        public void ShowDevTools()
        {

            if (WebView.BrowserHost == null)
            {
                return;
            }

            var windowInfo = CefWindowInfo.Create();
            windowInfo.SetAsPopup(IntPtr.Zero, Resources.Messages.HostWindow_DevToolsTitle);

            WebView.BrowserHost.ShowDevTools(windowInfo, new DevToolsBrowserClient(), new CefBrowserSettings(), new CefPoint(0, 0));
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the Formium class.
        /// </summary>
        public Formium()
        {
            switch (WindowType)
            {
                case HostWindowType.System:
                    _allowFullScreenMenu = true;

                    var systemWindow = new SystemStyleHostWindow(this);
                    SystemWindowProperties = new SystemWindowStyle(systemWindow);
                    OnCreateHostWindow(systemWindow);
                    HostWindowInternal = systemWindow;
                    break;
                case HostWindowType.Borderless:
                    _allowFullScreenMenu = true;

                    var borderlessWindow = new BorderlessStyleHostWindow(this);
                    BorderlessWindowProperties = new BorderlessWindowStyle(borderlessWindow);
                    OnCreateHostWindow(borderlessWindow);
                    HostWindowInternal = borderlessWindow;
                    break;
                case HostWindowType.Kiosk:
                    var kioskWindow = new SystemStyleHostWindow(this);
                    KioskWindowProperties = new KioskWindowStyle(kioskWindow);
                    OnCreateHostWindow(kioskWindow);
                    HostWindowInternal = kioskWindow;
                    HostWindowInternal.FormBorderStyle = FormBorderStyle.None;
                    HostWindowInternal.WindowState = FormWindowState.Maximized;
                    HostWindowInternal.ShowInTaskbar = false;
                    _resizable = false;
                    break;
                case HostWindowType.Acrylic:
                    _allowFullScreenMenu = true;

                    var acrylicWindow = new AcrylicStyleHostWindow(this);
                    AcrylicWindowProperties = new AcrylicWindowStyle(acrylicWindow);
                    OnCreateHostWindow(acrylicWindow);
                    HostWindowInternal = acrylicWindow;
                    break;
                case HostWindowType.Layered:
                    var layeredWindow = new LayeredStyleHostWindow(this);
                    OnCreateHostWindow(layeredWindow);
                    HostWindowInternal = layeredWindow;
                    HostWindowInternal.MaximizeBox = false;
                    _resizable = false;
                    _allowFullScreenMenu = false;
                    break;
                case HostWindowType.Custom:
                    var userCustomForm = CreateCustomHostWindow();

                    if (userCustomForm == null)
                    {
                        throw new ArgumentNullException(string.Format(Resources.Messages.Exception_HaveNoRetureValue, nameof(CreateCustomHostWindow)));
                    }

                    if (userCustomForm.GetType().GetInterface("IHostWindow") == null)
                    {
                        throw new NotImplementedException(string.Format(Resources.Messages.Exception_HaveNoRetureValue, nameof(HostWindowInternal)));
                    }

                    OnCreateHostWindow(userCustomForm);
                    HostWindowInternal = userCustomForm;
                    break;
            }





            HostWindowInternal.HandleCreated += OnHostWindowHandleCreated;

            HostWindowInternal.ResizeBegin += (s, e) =>
            {
                WebView?.BrowserHost?.NotifyMoveOrResizeStarted();
            };

            HostWindowInternal.ResizeEnd += (s, e) =>
            {
                WebView?.BrowserHost?.NotifyScreenInfoChanged();
                WebView?.BrowserHost?.WasResized();
            };

            HostWindowInternal.Resize += (s, e) =>
            {
                var isMinimized = User32.IsIconic(BrowserWindowHandle);
                if (isMinimized)
                {
                    if (_isMinimized)
                    {
                        WebView?.BrowserHost?.WasResized();

                        return;
                    }
                    else
                    {
                        _isMinimized = true;
                    }
                }
                else
                {
                    if (_isMinimized)
                    {
                        _isMinimized = false;
                    }

                    WebView?.BrowserHost?.WasResized();

                }



            };

            HostWindowInternal.Shown += (s, e) =>
            {
                HostWindowInternal.Text = GetWindowTitle();
            };

            HostWindowInternal.VisibleChanged += (s, e) =>
            {
                if (HostWindowInternal.Visible)
                {
                    WebView?.BrowserHost?.WasHidden(false);
                }
                else
                {
                    WebView?.BrowserHost?.WasHidden(true);
                }
            };




            HostWindowInternal.Move += (s, e) =>
            {
                WebView?.BrowserHost?.NotifyMoveOrResizeStarted();
            };


            HostWindowInternal.FormClosing += OnHostWindowClosing;

            var ihostWindow = GetIHostWindow();

            ihostWindow.OnWindowsMessage = OnHostWindowWndProc;

            ihostWindow.OnDefWindowsMessage = OnHostWindowDefWndProc;

            Mask = new ViewMask(this);


            HostWindowInternal.Load += OnHostWindowLoad;

            HostWindowInternal.Shown += OnHostWindowShown;
        }

        private void OnHostWindowShown(object sender, EventArgs e)
        {
            if (_deferredWindowState.HasValue && _deferredWindowState != FormWindowState.Normal)
            {
                HostWindowInternal.WindowState = _deferredWindowState.Value;
            }

            _deferredWindowState = null;
        }

        #region Overrides


        internal protected ViewMask Mask { get; private set; }

        //protected virtual void CustomizeMaskView(Control.ControlCollection view)
        //{
            

        //}

        protected void ShowMask()
        {
            Mask?.Show();
        }

        protected void CloseMask()
        {
            Mask?.Close();
        }



        /// <summary>
        /// If the browser context is ready to use.
        /// </summary>
        protected virtual void OnReady()
        {

        }
        /// <summary>
        /// Combine subtile and main title of the window.
        /// </summary>
        protected virtual string GetWindowTitle()
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


        /// <summary>
        /// Setup the default browser settings.
        /// </summary>
        /// <param name="defaultBrowserSettings"></param>
        /// <returns></returns>
        protected virtual CefBrowserSettings OnCreateBrowserSettings(CefBrowserSettings defaultBrowserSettings)
        {
            return defaultBrowserSettings;
        }
        /// <summary>
        /// If the WindowType is set to Custom, you should create your own window here to host the the browser.
        /// </summary>
        protected virtual Form CreateCustomHostWindow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Fires when the host window is creating.
        /// </summary>
        /// <param name="hostWindow"></param>
        protected virtual void OnCreateHostWindow(Form hostWindow)
        {

        }
        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected virtual bool HostWindowWndProc(ref Message m)
        {
            return false;
        }
        /// <summary>
        /// Processes Windows def messages.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected virtual bool HostWindowDefWndProc(ref Message m)
        {
            return false;
        }
        #endregion

        #region HostWindow staffs


        private void OnHostWindowLoad(object sender, EventArgs e)
        {
            CreateBrowser();


            RegisterHostWindowJavascriptEventHandler();

            Mask.AdjustPanelSize();


            if (AutoShowMask && WindowType != HostWindowType.Layered)
            {
                Mask.Show();
            }

            _isWindowLoaded = true;


        }

        FormWindowState _windowLastState;

        private void RegisterHostWindowJavascriptEventHandler()
        {
            _windowLastState = HostWindowInternal.WindowState;

            HostWindowInternal.Activated += (_, args) =>
            {
                var sb = new StringBuilder();

                sb.AppendLine($@"(function(){{

    const html =  document.querySelector('html');

    html && html.classList.remove('formium-blur');    
    html && html.classList.add('formium-focus');

    { JS_EVENT_RAISER_NAME}(""hostactivated"", {{}});
    {JS_EVENT_RAISER_NAME}(""hostactivatestatechange"", {{ activated: true }});

}})();");


                if (!IsWebViewReady)
                {
                    DelayedScripts["hostactivatestatechange"] = sb.ToString();
                }


                ExecuteJavaScript(sb.ToString());

            };

            HostWindowInternal.Deactivate += (_, args) =>
            {
                var sb = new StringBuilder();

                sb.AppendLine($@"(function(){{

    const html =  document.querySelector('html');
    
    html && html.classList.remove('formium-focus');
    html && html.classList.add('formium-blur');

    { JS_EVENT_RAISER_NAME}(""hostdeactivate"", {{}});
    {JS_EVENT_RAISER_NAME}(""hostactivatestatechange"", {{ activated: false }});

}})();");


                if (!IsWebViewReady)
                {
                    DelayedScripts["hostactivatestatechange"] = sb.ToString();
                }

                ExecuteJavaScript(sb.ToString());


            };

            HostWindowInternal.Resize += (_, args) =>
            {
                var state = HostWindowInternal.WindowState.ToString().ToLower();

                var rect = new RECT();

                var isMaximized = User32.IsZoomed(HostWindowHandle);

                if (isMaximized)
                {
                    User32.GetClientRect(HostWindowHandle, ref rect);
                }
                else
                {
                    User32.GetWindowRect(HostWindowHandle, ref rect);
                }

                var sb = new StringBuilder();

                sb.AppendLine("(function(){");

                sb.AppendLine("const html =  document.querySelector('html');");

                if (_windowLastState != HostWindowInternal.WindowState)
                {
                    sb.AppendLine($"html && html.classList.remove('formium-maximized','formium-minimized');");

                    sb.AppendLine($@"{JS_EVENT_RAISER_NAME}(""hoststatechanged"", {{ state: ""{state}""}});");


                    if (HostWindowInternal.WindowState != FormWindowState.Normal)
                    {
                        sb.AppendLine($"html && html.classList.add('formium-{state}');");
                    }


                    _windowLastState = HostWindowInternal.WindowState;
                }



                sb.AppendLine($@"{JS_EVENT_RAISER_NAME}(""hostsizechanged"", {{ width:{rect.Width}, height:{rect.Height} }});");



                sb.AppendLine("})();");

                if (IsWebViewReady)
                {
                    ExecuteJavaScript(sb.ToString());
                }
                else
                {
                    DelayedScripts["hostsizechanged"] = sb.ToString();
                }

            };


        }

        private void OnHostWindowClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isForceClosing && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                Close();
            }
        }

        private void OnFullScreenMenuStateChanged()
        {
            var hSysMenu = User32.GetSystemMenu(HostWindowHandle, false);

            if (_allowFullScreenMenu && !IsFullScreen)
            {
                User32.EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, User32.MF_BYCOMMAND | User32.MF_ENABLED);
            }
            else
            {
                User32.EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, User32.MF_BYCOMMAND | User32.MF_DISABLED);
            }
        }

        private void OnHostWindowHandleCreated(object sender, EventArgs e)
        {
            HostWindowHandle = HostWindowInternal.Handle;

            var hSysMenu = User32.GetSystemMenu(HostWindowHandle, false);

            User32.InsertMenu(hSysMenu, (int)SystemCommandFlags.SC_CLOSE, User32.MF_BYCOMMAND, SYSMENU_FULL_SCREEN_ID, Resources.Messages.SystemMenu_FullScreen);
            User32.InsertMenu(hSysMenu, (int)SystemCommandFlags.SC_CLOSE, User32.MF_BYCOMMAND | User32.MF_SEPARATOR, 0, string.Empty);

            if (!WinFormium.DisableAboutMenu)
            {
                User32.AppendMenu(hSysMenu, User32.MF_SEPARATOR, 0, string.Empty);
                User32.AppendMenu(hSysMenu, User32.MF_STRING, SYSMENU_ABOUT_ID, Resources.Messages.SystemMenu_About);
            }



            OnFullScreenMenuStateChanged();

        }

        private void CreateBrowser()
        {
            var settings = OnCreateBrowserSettings(new CefBrowserSettings());

            if (settings == null)
            {
                settings = WinFormium.DefaultBrowserSettings;
            }

            WebView = new FormiumWebView(this, settings, StartUrl);

            var windowInfo = CefWindowInfo.Create();

            //windowInfo.StyleEx |= Xilium.CefGlue.Platform.Windows.WindowStyleEx.WS_EX_NOACTIVATE;

            if (WindowType == HostWindowType.Acrylic || WindowType == HostWindowType.Layered)
            {
                windowInfo.SetAsWindowless(HostWindowHandle, true);
            }
            else
            {
                var rect = new RECT();
                User32.GetWindowRect(HostWindowHandle, ref rect);
                windowInfo.SetAsChild(HostWindowHandle, new CefRectangle(0, 0, rect.Width, rect.Height));
            }

            WebView.CreateBrowser(windowInfo);



        }

        private bool OnHostWindowDefWndProc(ref Message m)
        {
            var retval = HostWindowDefWndProc(ref m);
            return retval;
        }

        private bool OnHostWindowWndProc(ref Message m)
        {



            switch ((WindowsMessages)m.Msg)
            {
                case WindowsMessages.WM_SIZE:
                    {
                        OnWmSize(ref m);
                    }
                    break;
                case WindowsMessages.WM_MOVE:
                    {
                        OnWmMove(ref m);
                    }
                    break;
                case WindowsMessages.WM_NCRBUTTONUP:
                    {
                        OnWmNcRButtonUp(ref m);
                    }
                    break;
                case WindowsMessages.WM_SYSCOMMAND:
                    {
                        var nCmd = (int)m.WParam;


                        if (nCmd == SYSMENU_ABOUT_ID)
                        {
                            var aboutDlg = new AboutDialog();

                            aboutDlg.ShowDialog(HostWindow);
                        }

                        if (nCmd == SYSMENU_FULL_SCREEN_ID)
                        {
                            FullScreen(true);
                        }

                        if (nCmd == (int)SystemCommandFlags.SC_RESTORE)
                        {

                            if (HostWindowInternal.WindowState != FormWindowState.Minimized && IsFullScreen)
                            {
                                FullScreen(false);
                                return true;
                            }
                        }
                    }
                    break;
            }

            var retval = HostWindowWndProc(ref m);
            return retval;
        }

        private void OnWmNcRButtonUp(ref Message m)
        {
            var point = Win32.GetPostionFromPtr(m.LParam);

            ShowSystemMenu(ref point);
        }

        private void OnWmSize(ref Message m)
        {
            if (!_isBrowserCreated)
            {
                return;
            }

            ResizeBrowserWindow();




        }

        private void OnWmMove(ref Message m)
        {
            WebView?.BrowserHost?.NotifyMoveOrResizeStarted();
        }

        private void EnableFullScreenCommand(bool enabled)
        {
            var hSysMenu = User32.GetSystemMenu(HostWindowHandle, false);
            if (enabled && _allowFullScreenMenu)
            {
                User32.EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, User32.MF_BYCOMMAND | User32.MF_ENABLED);
            }
            else
            {
                User32.EnableMenuItem(hSysMenu, SYSMENU_FULL_SCREEN_ID, User32.MF_BYCOMMAND | User32.MF_DISABLED);
            }
        }

        private void ShowSystemMenu(ref POINT pt)
        {
            const int TPM_LEFTALIGN = 0x0000, TPM_TOPALIGN = 0x0000, TPM_RETURNCMD = 0x0100;

            if (!_isWindowLoaded)
            {
                return;
            }

            var hMenu = User32.GetSystemMenu(HostWindowHandle, false);
            var hCmd = User32.TrackPopupMenu(hMenu, TPM_RETURNCMD | TPM_TOPALIGN | TPM_LEFTALIGN,
                pt.x, pt.y, 0, HostWindowHandle, IntPtr.Zero);

            User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_SYSCOMMAND, hCmd, IntPtr.Zero);
        }

        private void OnTitleChanged()
        {
            if (!_isWindowLoaded)
            {
                return;
            }

            HostWindowInternal.InvokeIfRequired(() =>
            {
                if (HostWindowInternal != null && !HostWindowInternal.IsDisposed)
                {
                    HostWindowInternal.Text = GetWindowTitle();
                }
            });
        }

        private void ResizeBrowserWindow()
        {
            if (BrowserWindowHandle == IntPtr.Zero || BrowserWindowHandle == HostWindowHandle)
                return;

            var rect = new RECT();

            User32.GetClientRect(HostWindowHandle, ref rect);

            //User32.SetWindowPos(BrowserWindowHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);




            if (Visible)
            {
                User32.SetWindowPos(BrowserWindowHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_SHOWWINDOW | SetWindowPosFlags.SWP_NOCOPYBITS | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);

                User32.SetWindowLongPtr(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_VISIBLE));
            }
            else
            {

                User32.SetWindowPos(BrowserWindowHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);

                User32.SetWindowLongPtr(BrowserWindowHandle, WindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_DISABLED));
            }
        }
        #endregion

        #region Browser staffs
        internal bool WebViewEdgeHitTestAvailable
        {
            get
            {
                if (!(HostWindowInternal is BorderlessWindow))
                {
                    return false;
                }

                var borderlessWindow = (BorderlessWindow)HostWindowInternal;

                return borderlessWindow.ShadowEffect == ShadowEffect.None && Resizable;
            }
        }

        internal void AttachChromeWidgetMessageHandler()
        {
            ChromeWidgetMessageInterceptor.Setup(chromeWidgetMessageInterceptor, this, OnBrowserWindowMessage);

        }

        internal void OnBrowserCreated()
        {

            AttachChromeWidgetMessageHandler();


            InvokeIfRequired(() => BrowserCreated?.Invoke(this, EventArgs.Empty));

            InvokeIfRequired(() => OnReady());


            ResizeBrowserWindow();

            _isBrowserCreated = true;


            ThreadPool.QueueUserWorkItem(AfterSetBrowserTasks);

        }

        private void AfterSetBrowserTasks(object state)
        {

            IsMainFrameLoaded = true;

            lock (_browserSyncRoot)
            {
                if (_loadUrlDeferred != null)
                {
                    Browser.GetMainFrame().LoadUrl(_loadUrlDeferred);
                }
            }
        }

        private bool OnBrowserWindowMessage(Message m)
        {

            var msg = (WindowsMessages)m.Msg;

            var handled = false;

            if (_isWindowLoaded)
            {

                if (WindowType == HostWindowType.Kiosk)
                {
                    return false;
                }

                switch (msg)
                {
                    case WindowsMessages.WM_LBUTTONDOWN:
                        handled = OnBrowserWMLButtonDown(m);
                        break;
                    case WindowsMessages.WM_RBUTTONDOWN:
                        handled = OnBrowserWMRButtonDown(m);
                        break;
                    case WindowsMessages.WM_RBUTTONUP:
                        handled = OnBrowserWMRButtonUp(m);
                        break;
                    case WindowsMessages.WM_LBUTTONDBLCLK:
                        handled = OnBrowserWMLButtonDbClick(m);
                        break;
                    case WindowsMessages.WM_MOUSEMOVE:
                        if (Resizable)
                        {
                            handled = OnBrowserWMMouseMove(m);
                        }
                        break;
                }
            }



            return handled;
        }

        internal bool OnBrowserWMLButtonDown(Message m)
        {
            if (IsFullScreen)
            {
                return false;
            }


            var point = Win32.GetPostionFromPtr(m.LParam);

            var inDragableArea = (WebView.DraggableRegion != null && WebView.DraggableRegion.IsVisible(new Point(point.x, point.y)));

            var mode = Win32.GetSizeMode(point, HostWindowInternal.ClientSize.Width, HostWindowInternal.ClientSize.Height);

            if (WebViewEdgeHitTestAvailable && mode != HitTest.HTCLIENT && WindowState == FormWindowState.Normal)
            {
                SetCursor(mode);

                User32.ReleaseCapture();

                User32.ClientToScreen(BrowserWindowHandle, ref point);

                User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)mode, Win32.MakeParam(point.x, point.y));

                return true;
            }
            else if (inDragableArea)
            {
                User32.ReleaseCapture();

                User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)HitTest.HTCAPTION, IntPtr.Zero);
                return true;
            }

            return false;
        }

        internal bool OnBrowserWMLButtonDbClick(Message m)
        {
            var point = Win32.GetPostionFromPtr(m.LParam);

            var inDragableArea = (WebView.DraggableRegion != null && WebView.DraggableRegion.IsVisible(new Point(point.x, point.y)));

            if (inDragableArea && CanMaximize && Resizable)
            {

                if (IsFullScreen)
                {
                    FullScreen(false);
                    return true;
                }

                User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_NCLBUTTONDBLCLK, (IntPtr)HitTest.HTCAPTION, IntPtr.Zero);
                return true;
            }

            return false;
        }

        internal bool OnBrowserWMRButtonDown(Message m)
        {
            if (!AllowSystemMenu)
                return false;

            var point = Win32.GetPostionFromPtr(m.LParam);

            var inDragableArea = (WebView.DraggableRegion != null && WebView.DraggableRegion.IsVisible(new Point(point.x, point.y)));

            if (inDragableArea)
            {
                User32.ClientToScreen(HostWindowHandle, ref point);

                User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_NCRBUTTONDOWN, (IntPtr)HitTest.HTSYSMENU, Win32.MakeParam(point.x, point.y));


                return true;
            }



            return false;
        }

        internal bool OnBrowserWMRButtonUp(Message m)
        {
            if (!AllowSystemMenu)
                return false;

            var point = Win32.GetPostionFromPtr(m.LParam);

            var inDragableArea = (WebView.DraggableRegion != null && WebView.DraggableRegion.IsVisible(new Point(point.x, point.y)));

            if (inDragableArea)
            {

                User32.ClientToScreen(HostWindowHandle, ref point);

                User32.PostMessage(HostWindowHandle, (uint)WindowsMessages.WM_NCRBUTTONUP, (IntPtr)HitTest.HTSYSMENU, Win32.MakeParam(point.x, point.y));


                return true;
            }

            return false;


        }

        internal bool OnBrowserWMMouseMove(Message m)
        {
            if (IsFullScreen)
            {
                return false;
            }

            var point = Win32.GetPostionFromPtr(m.LParam);


            if (WebViewEdgeHitTestAvailable && WindowState == FormWindowState.Normal)
            {
                var mode = Win32.GetSizeMode(point, HostWindowInternal.ClientSize.Width, HostWindowInternal.ClientSize.Height);

                User32.ClientToScreen(BrowserWindowHandle, ref point);

                if (mode != HitTest.HTCLIENT)
                {
                    User32.SendMessage(BrowserWindowHandle, (uint)WindowsMessages.WM_NCHITTEST, (IntPtr)mode, Win32.MakeParam(point.x, point.y));
                    SetCursor(mode);
                    return true;

                }


                return false;

            }

            return false;
        }

        private void SetCursor(HitTest mode)
        {


            IntPtr handle = IntPtr.Zero;

            switch (mode)
            {
                case HitTest.HTTOP:
                case HitTest.HTBOTTOM:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENS);
                    break;
                case HitTest.HTLEFT:
                case HitTest.HTRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZEWE);
                    break;
                case HitTest.HTTOPLEFT:
                case HitTest.HTBOTTOMRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENWSE);
                    break;
                case HitTest.HTTOPRIGHT:
                case HitTest.HTBOTTOMLEFT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENESW);
                    break;
            }

            if (handle != IntPtr.Zero)
            {
                User32.SetCursor(handle);
            }
            else
            {
                User32.SetCursor(IntPtr.Zero);
            }
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Gets the Formium is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get => HostWindowInternal == null || HostWindowInternal.IsDisposed;
        }
        /// <summary>
        /// Release all resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);



        }
        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                WebView.Dispose();

                if (!HostWindowInternal.IsDisposed)
                {
                    HostWindowInternal.Dispose();
                }


            }

            WebView = null;

            HostWindowInternal = null;
        }


        #endregion

        #region HostWindow stylers
        public sealed class SystemWindowStyle
        {
            private SystemStyleHostWindow _hostWindow;

            private SystemWindowStyle() { }

            internal SystemWindowStyle(SystemStyleHostWindow hostWindow)
            {
                _hostWindow = hostWindow;
            }
        }

        public sealed class KioskWindowStyle
        {
            private SystemStyleHostWindow _hostWindow;

            private KioskWindowStyle() { }

            internal KioskWindowStyle(SystemStyleHostWindow hostWindow)
            {
                _hostWindow = hostWindow;
            }
        }

        public sealed class AcrylicWindowStyle
        {
            private AcrylicStyleHostWindow _hostWindow;


            public AcrylicWindowStyle(AcrylicStyleHostWindow hostWindow)
            {
                _hostWindow = hostWindow;
            }

            public ShadowEffect ShadowEffect
            {
                get => _hostWindow.ShadowEffect;
                set
                {
                    _hostWindow.ShadowEffect = value;
                }
            }

            public Color ShadowColor
            {
                get => _hostWindow.ShadowColor;
                set
                {
                    _hostWindow.ShadowColor = value;
                }
            }

            public Color? InactiveShadowColor
            {
                get => _hostWindow.InactiveShadowColor;
                set
                {
                    _hostWindow.InactiveShadowColor = value;
                }
            }
        }

        public sealed class BorderlessWindowStyle
        {
            private BorderlessStyleHostWindow _hostWindow;

            private BorderlessWindowStyle() { }
            internal BorderlessWindowStyle(BorderlessStyleHostWindow hostWindow)
            {
                _hostWindow = hostWindow;
            }

            public ShadowEffect ShadowEffect
            {
                get => _hostWindow.ShadowEffect;
                set
                {
                    _hostWindow.ShadowEffect = value;
                }
            }

            public BorderEffect BorderEffect
            {
                get => _hostWindow.BorderEffect;

                set
                {
                    _hostWindow.BorderEffect = value;
                }
            }

            public Color ShadowColor
            {
                get => _hostWindow.ShadowColor;
                set
                {
                    _hostWindow.ShadowColor = value;
                }
            }

            public Color? InactiveShadowColor
            {
                get => _hostWindow.InactiveShadowColor;
                set
                {
                    _hostWindow.InactiveShadowColor = value;
                }
            }

            public Color BorderColor
            {
                get => _hostWindow.BorderColor;
                set
                {
                    _hostWindow.BorderColor = value;
                }
            }

            public Color? InactiveBorderColor
            {
                get => _hostWindow.InactiveBorderColor;
                set
                {
                    _hostWindow.InactiveBorderColor = value;
                }
            }



        }



        #endregion

        #region Browser internal classes
        internal sealed class DevToolsBrowserClient : CefClient
        {

            class DevToolsBrowserLifeSpanHandler : CefLifeSpanHandler
            {

                const int ICO_BIG = 1;
                const int ICO_SAMLL = 0;

                protected override void OnAfterCreated(CefBrowser browser)
                {

                    var hostHandle = browser.GetHost().GetWindowHandle();

                    User32.SendMessage(hostHandle, (uint)WindowsMessages.WM_SETICON, (IntPtr)ICO_BIG, Properties.Resources.DevToolsIcon.Handle);

                    base.OnAfterCreated(browser);
                }
            }

            private readonly CefLifeSpanHandler _lifeSpanHandler;

            public DevToolsBrowserClient()
            {
                _lifeSpanHandler = new DevToolsBrowserLifeSpanHandler();
            }

            protected override CefLifeSpanHandler GetLifeSpanHandler()
            {
                return _lifeSpanHandler;
            }
        }

        #endregion
    }




}
