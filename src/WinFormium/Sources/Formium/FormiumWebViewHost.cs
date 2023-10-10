// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
internal class FormiumWebViewHost : IWebViewHost
{
    public Formium Formium { get; }

    public FormiumWebViewHost(Formium formium)
    {
        Formium = formium;
    }

    public string Url { get=> throw new NotSupportedException() ; set => throw new NotSupportedException(); }
    public IntPtr WindowHandle { get => Formium.WindowHandle!; }
    public Region? DraggableRegion { get; set; }
    public IAudioHandler? AudioHandler { get; set; }
    public ICommandHandler? CommandHandler { get; set; }
    public IContextMenuHandler? ContextMenuHandler { get; set; }
    public IDialogHandler? DialogHandler { get; set; }
    public IDisplayHandler? DisplayHandler { get; set; }
    public IDownloadHandler? DownloadHandler { get; set; }
    public IDragHandler? DragHandler { get; set; }
    public IFindHandler? FindHandler { get; set; }
    public IFocusHandler? FocusHandler { get; set; }
    public IFrameHandler? FrameHandler { get; set; }
    public IPermissionHandler? PermissionHandler { get; set; }
    public IJSDialogHandler? JSDialogHandler { get; set; }
    public IKeyboardHandler? KeyboardHandler { get; set; }
    public ILifeSpanHandler? LifeSpanHandler { get; set; }
    public ILoadHandler? LoadHandler { get; set; }
    public IPrintHandler? PrintHandler { get; set; }
    public IRenderHandler? RenderHandler { get; set; }
    public IRequestHandler? RequestHandler { get; set; }

    public CefBrowser? Browser  => Formium.Browser;
    public CefBrowserHost? BrowserHost => Formium.BrowserHost;

    public WinFormiumApp ApplicationContext  => Formium.ApplicationContext;

    bool IWebViewHost.IsOffscreenEnabled => Formium.CurrentFormStyle.OffScreenRenderEnabled;

    public void Close()
    {
        Formium.InvokeOnUIThread(() => Formium.HostWindow?.Close());
    }

    public void ContextCreated(CefBrowser browser, CefFrame frame)
    {
        Formium.ContextCreatedCore(browser, frame);
    }

    public float GetScaleFactor()
    {
        return Formium.HostWindow?.WindowScaleFactor ?? 1.0f;
    }


    public void InvokeOnUIThread(Action action)
    {
        Formium.InvokeOnUIThread(action);
    }

    public bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        return false;
    }

    void IWebViewHost.HandleException(Exception exception)
    {
        Formium.HandleException(exception);
    }
}
