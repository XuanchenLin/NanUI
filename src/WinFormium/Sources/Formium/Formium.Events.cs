// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium
{
    #region Lifecycle Events
    /// <summary>
    /// Occurs when the form is activated in code or by the user.
    /// </summary>
    public event EventHandler<EventArgs>? Activated;
    /// <summary>
    /// Occurs when the browser is created.
    /// </summary>
    public event EventHandler<BrowserEventArgs>? BrowserCreated; //<-- OnRenderViewReady
    /// <summary>
    /// Occurs when the form and broswser is loaded and ready for interaction.
    /// </summary>
    public event EventHandler<BrowserEventArgs>? Loaded; //<-- OnRenderViewReady
    /// <summary>
    /// Occurs when the window.document is available.
    /// </summary>
    public event EventHandler<BrowserEventArgs>? DocumentAvailable; //<-- OnDocumentAvailableInMainFrame
    /// <summary>
    /// Occurs when the form is deactivated in code or by the user.
    /// </summary>
    public event EventHandler<EventArgs>? Deactivate;
    /// <summary>
    /// Occurs before the form is closed.
    /// </summary>
    public event EventHandler<ClosingEventArgs>? Closing;
    /// <summary>
    /// Occurs when the form is closed.
    /// </summary>
    public event EventHandler<EventArgs>? Closed;
    #endregion

    #region Window Events
    /// <summary>
    /// Occurs when a form enters resizing mode.
    /// </summary>
    public event EventHandler<EventArgs>? ResizeBegin;

    /// <summary>
    /// Occurs when the form is resized.
    /// </summary>
    public event EventHandler<EventArgs>? Resize;

    /// <summary>
    /// Occurs when a form exits resizing mode.
    /// </summary>
    public event EventHandler<EventArgs>? ResizeEnd;

    /// <summary>
    /// Occurs when the form is moved.
    /// </summary>
    public event EventHandler<EventArgs>? Move;



    /// <summary>
    /// Occurs whenever the form is first displayed.
    /// </summary>
    public event EventHandler<EventArgs>? Shown;

    /// <summary>
    /// Occurs when the <see cref="Visible"/> property value changes.
    /// </summary>
    public event EventHandler<EventArgs>? VisibleChanged;

    public event EventHandler<WindowStateChangedEventArgs>? WindowStateChanged;

    #endregion

    #region Browser Events

    // page load events


    /// <summary>
    /// Occurs when the page loading state has changed.
    /// </summary>
    public event EventHandler<PageLoadingStateChangeEventArgs>? PageLoadingStateChange;
    /// <summary>
    /// Occurs when the page load has started.
    /// </summary>
    public event EventHandler<PageLoadStartEventArgs>? PageLoadStart;
    /// <summary>
    /// Occurs when the page load has ended with one or more errors.
    /// </summary>
    public event EventHandler<PageLoadErrorEventArgs>? PageLoadError;
    /// <summary>
    /// Occurs when the page load has ended..
    /// </summary>
    public event EventHandler<PageLoadEndEventArgs>? PageLoadEnd;
    /// <summary>
    /// Occurs when the frame page load has started.
    /// </summary>
    public event EventHandler<FramePageLoadStartEventArgs>? FramePageLoadStart;
    /// <summary>
    /// Occurs when the frame page load has ended with one or more errors.
    /// </summary>
    public event EventHandler<FramePageLoadErrorEventArgs>? FramePageLoadError;
    /// <summary>
    /// Occurs when the frame page load has ended.
    /// </summary>
    public event EventHandler<FramePageLoadEndEventArgs>? FramePageLoadEnd;

    // focus events

    /// <summary>
    /// Occurs when the browser has received focus.
    /// </summary>
    public event EventHandler<EventArgs>? GotFocus;
    /// <summary>
    /// Occurs when the form loses focus.
    /// </summary>
    public event EventHandler<EventArgs>? TakeFocus;
    /// <summary>
    /// Occurs when the browser component is requesting focus.
    /// </summary>
    public event EventHandler<SetFocusEventArgs>? SetFocus;

    // drag events

    /// <summary>
    /// Occurs when an object is dragged into the form's bounds.
    /// </summary>
    public event EventHandler<DragEnterEventArgs>? DragEnter;

    // display events

    /// <summary>
    /// Occurs when the browser's title has changed.
    /// </summary>
    public event EventHandler<PageTitleChangeEventArgs>? PageTitleChange;
    /// <summary>
    /// Occurs when the browser's address has changed.
    /// </summary>
    public event EventHandler<PageAddressChangeEventArgs>? PageAddressChange;
    /// <summary>
    /// Occurs when one frame of the browser's address has changed.
    /// </summary>
    public event EventHandler<FramePageAddressChangeEventArgs>? FramePageAddressChange;
    /// <summary>
    /// Occurs when the browser's cursor has changed.
    /// </summary>
    public event EventHandler<CursorChangeEventArgs>? CursorChange;
    /// <summary>
    /// Occurs when the browser's loading progress has changed.
    /// </summary>
    public event EventHandler<PageLoadingProgressChangeEventArgs>? PageLoadingProgressChange;
    /// <summary>
    /// Occurs when the browser's favicon has changed.
    /// </summary>
    public event EventHandler<FaviconUrlChangeEventArgs>? FaviconUrlChange;
    /// <summary>
    /// Occurs when the browser's status message has changed.
    /// </summary>
    public event EventHandler<StatusMessageChangeEventArgs>? StatusMessageChange;
    /// <summary>
    /// Occurs when the console message has changed.
    /// </summary>
    public event EventHandler<ConsoleMessageEventArgs>? ConsoleMessage;
    /// <summary>
    /// Occurs when the browser's fullscreen mode has changed.
    /// </summary>
    public event EventHandler<FullscreenModeChangeEventArgs>? FullscreenModeChange;
    /// <summary>
    /// Occurs when the browser's access to an audio and/or video source has changed.
    /// </summary>
    public event EventHandler<MediaAccessChangeEventArgs>? MediaAccessChange;
    /// <summary>
    /// Occurs when the browser is about to display a tooltip.
    /// </summary>
    public event EventHandler<TooltipEventArgs>? Tooltip;

    //request events

    /// <summary>
    /// Occurs before <see cref="BeforeBrowse"/> in certain limited cases where navigating a new or different browser might be desirable.
    /// </summary>
    public event EventHandler<OpenUrlFromTabEventArgs>? OpenUrlFromTab;

    /// <summary>
    /// Occurs when the render process terminates unexpectedly.
    /// </summary>
    public event EventHandler<RenderProcessCrashedEventArgs>? RenderProcessCrashed;

    /// <summary>
    /// Occurs before browser navigation.
    /// </summary>
    public event EventHandler<BeforeBrowseEventArgs>? BeforeBrowse;

    /// <summary>
    /// Occurs when the browser needs credentials from the user.
    /// </summary>
    public event EventHandler<GetAuthCredentialsEventArgs>? GetAuthCredentials;

    // keyboard events

    /// <summary>
    /// Occurs before a keyboard event is sent to the browser.
    /// </summary>
    public event EventHandler<BeforeKeyEventEventArgs>? BeforeKeyEvent;

    /// <summary>
    /// Occurs when a keyboard event is sent to the browser.
    /// </summary>
    public event EventHandler<KeyEventEventArgs>? KeyEvent;

    // download events

    /// <summary>
    /// Occurs before a download begins in response to a user-initiated action such as alt + link clicking or link clicking.
    /// </summary>
    public event EventHandler<CanDownloadEventArgs>? CanDownload;

    /// <summary>
    /// Occurs before a download begins.
    /// </summary>
    public event EventHandler<BeforeDownloadEventArgs>? BeforeDownload;

    /// <summary>
    /// Occurs when a download's status or progress information has been updated.
    /// </summary>
    public event EventHandler<DownloadUpdatedEventArgs>? DownloadUpdated;

    #endregion

    #region Browser




    /// <summary>
    /// Raises the <see cref="DragEnter"/> event.
    /// </summary>
    /// <param name="args">The <see cref="DragEnterEventArgs"/> that contains the event data.</param>
    protected virtual void OnDragEnter(DragEnterEventArgs args)
    {
        DragEnter?.Invoke(this, args);
    }

    #region IDisplayHandler
    /// <summary>
    /// Raises the <see cref="Tooltip"/> event.
    /// </summary>
    /// <param name="args">The <see cref="TooltipEventArgs"/> that contains the event data.</param>
    protected virtual void OnToolTip(TooltipEventArgs args)
    {
        Tooltip?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="MediaAccessChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="MediaAccessChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnMediaAccessChange(MediaAccessChangeEventArgs args)
    {
        MediaAccessChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageLoadingProgressChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageLoadingProgressChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageLoadingProgressChange(PageLoadingProgressChangeEventArgs args)
    {
        PageLoadingProgressChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="OnFullscreenModeChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FullscreenModeChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFullscreenModeChange(FullscreenModeChangeEventArgs args)
    {

        FullscreenModeChange?.Invoke(this, args);

        if (HostWindow == null || args.Cancel) return;

        SetFullscreenState(args.Fullscreen);

    }

    /// <summary>
    /// Raises the <see cref="FaviconUrlChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FaviconUrlChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFaviconUrlChange(FaviconUrlChangeEventArgs args)
    {
        FaviconUrlChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="ConsoleMessage"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="ConsoleMessageEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnConsoleMessage(ConsoleMessageEventArgs args)
    {
        ConsoleMessage?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="StatusMessageChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="StatusMessageChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnStatusMessageChange(StatusMessageChangeEventArgs args)
    {
        StatusMessageChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageTitleChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageTitleChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageTitleChange(PageTitleChangeEventArgs args)
    {
        if (PageTitleChange == null)
        {
            PageTitle = args.Title;
            HostWindow!.Text = BuildTitleString();
            return;
        }
        PageTitleChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageAddressChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageAddressChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageAddressChange(PageAddressChangeEventArgs args)
    {
        PageAddressChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="FramePageAddressChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FramePageAddressChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFramePageAddressChange(FramePageAddressChangeEventArgs args)
    {
        FramePageAddressChange?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="CursorChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="CursorChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnCursorChange(CursorChangeEventArgs args)
    {
        CursorChange?.Invoke(this, args);
    }
    #endregion

    #region IDownloadHandler
    /// <summary>
    /// Raises the <see cref="CanDownload"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="CanDownloadEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnCanDownload(CanDownloadEventArgs args)
    {
        CanDownload?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="BeforeDownload"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BeforeDownloadEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnBeforeDownload(BeforeDownloadEventArgs args)
    {

        if (BeforeDownload != null)
            BeforeDownload.Invoke(this, args);
        else
        {
            args.Callback.Continue(string.Empty, true);
        }
    }

    /// <summary>
    /// Raises the <see cref="DownloadUpdated"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="DownloadUpdatedEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnDownloadUpdated(DownloadUpdatedEventArgs args)
    {
        DownloadUpdated?.Invoke(this, args);
    }
    #endregion

    #region IFocusHandler
    /// <summary>
    /// Raises the <see cref="TakeFocus"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BrowserEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnTakeFocus(BrowserEventArgs args)
    {
        TakeFocus?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="GotFocus"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BrowserEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnGotFocus(BrowserEventArgs args)
    {
        GotFocus?.Invoke(this, args);
    }


    /// <summary>
    /// Raises the <see cref="SetFocus"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="SetFocusEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnSetFocus(SetFocusEventArgs args)
    {
        SetFocus?.Invoke(this, args);
    }


    #endregion

    #region IKeyboardHandler
    /// <summary>
    /// Raises the <see cref="KeyEvent"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="KeyEventEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnKeyEvent(KeyEventEventArgs args)
    {
        KeyEvent?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="BeforeKeyEvent"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BeforeKeyEventEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPreKeyEvent(BeforeKeyEventEventArgs args)
    {
        BeforeKeyEvent?.Invoke(this, args);
    }
    #endregion

    #region ILoadHandler
    /// <summary>
    /// Raises the <see cref="PageLoadStart"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageLoadStartEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageLoadStart(PageLoadStartEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnPageLoadStart");

        PageLoadStart?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageLoadError"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageLoadErrorEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageLoadError(PageLoadErrorEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnPageLoadError");

        PageLoadError?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageLoadEnd"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageLoadEndEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageLoadEnd(PageLoadEndEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnPageLoadEnd");

        PageLoadEnd?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="FramePageLoadStart"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FramePageLoadStartEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFramePageLoadStart(FramePageLoadStartEventArgs args)
    {
        FramePageLoadStart?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="FramePageLoadError"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FramePageLoadErrorEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFramePageLoadError(FramePageLoadErrorEventArgs args)
    {

        FramePageLoadError?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="FramePageLoadEnd"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="FramePageLoadEndEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnFramePageLoadEnd(FramePageLoadEndEventArgs args)
    {

        FramePageLoadEnd?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="PageLoadingStateChange"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="PageLoadingStateChangeEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnPageLoadingStateChange(PageLoadingStateChangeEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine($"[BROWSER] -> OnPageLoadingStateChange");

        PageLoadingStateChange?.Invoke(this, args);
    }



    #endregion

    #region IRequestHandler

    /// <summary>
    /// Raises the <see cref="RenderProcessCrashed"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="RenderProcessCrashedEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnRenderProcessCrashed(RenderProcessCrashedEventArgs args)
    {
        RenderProcessCrashed?.Invoke(this, args);

    }

    /// <summary>
    /// Raises the <see cref="OpenUrlFromTab"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="OpenUrlFromTabEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnOpenUrlFromTab(OpenUrlFromTabEventArgs args)
    {
        OpenUrlFromTab?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="BeforeBrowse"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BeforeBrowseEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnBeforeBrowse(BeforeBrowseEventArgs args)
    {
        BeforeBrowse?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="GetAuthCredentials"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="GetAuthCredentialsEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnGetAuthCredentials(GetAuthCredentialsEventArgs args)
    {
        GetAuthCredentials?.Invoke(this, args);
    }
    #endregion

    #endregion

    #region Window

    protected virtual void OnBrowserCreated(BrowserEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnBrowserCreated");

        BrowserCreated?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="Loaded"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BrowserEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnLoaded(BrowserEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnLoaded");

        Loaded?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="DocumentAvailable"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="BrowserEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnDocumentAvailable(BrowserEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnDocumentAvailable");

        DocumentAvailable?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="Activated"/> event.
    /// </summary>
    protected virtual void OnActivated()
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnActivated");

        Activated?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="Deactivate"/> event.
    /// </summary>
    protected virtual void OnDeactivated()
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnDeactivated");

        Deactivate?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnWindowStateChanged(WindowStateChangedEventArgs args)
    {
        WindowStateChanged?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="Closing"/> event.
    /// </summary>
    /// <param name="args">
    /// The <see cref="ClosingEventArgs"/> that contains the event data.
    /// </param>
    protected virtual void OnClosing(ClosingEventArgs args)
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnClosing");


        Closing?.Invoke(this, args);
    }

    /// <summary>
    /// Raises the <see cref="Closed"/> event.
    /// </summary>
    protected virtual void OnClosed()
    {
        System.Diagnostics.Debug.WriteLine("[LIFECYCLE] -> OnClosed");

        Closed?.Invoke(this, EventArgs.Empty);
    }






    /// <summary>
    /// Raises the <see cref="ResizeBegin"/> event.
    /// </summary>
    /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnResizeBegin(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnResizeBegin");

        ResizeBegin?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="ResizeEnd"/> event.
    /// </summary>
    /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnResizeEnd(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnResizeEnd");

        ResizeEnd?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="Resize"/> event.
    /// </summary>
    /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnResize(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnResize");

        Resize?.Invoke(this, args);

        OnWindowStateChangedCore();

    }

    /// <summary>
    /// Raises the <see cref="Move"/> event.
    /// </summary>
    /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnMove(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnMove");

        Move?.Invoke(this, args);
    }


    /// <summary>
    /// Raises the <see cref="Shown"/> event.
    /// </summary>
    /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnShown(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnShown");

        Shown?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnVisibleChanged(EventArgs args)
    {
        //System.Diagnostics.Debug.WriteLine("[WINDOW] -> OnVisibleChanged");

        VisibleChanged?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
