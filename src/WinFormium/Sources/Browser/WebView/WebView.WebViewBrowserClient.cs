// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal partial class WebView : IWebViewClient
{
    public IAudioHandler? AudioHandler { get => WebViewHost.AudioHandler; set => WebViewHost.AudioHandler = value; }

    public ICommandHandler? CommandHandler { get => WebViewHost.CommandHandler; set => WebViewHost.CommandHandler = value; }

    public IDialogHandler? DialogHandler { get => WebViewHost.DialogHandler; set => WebViewHost.DialogHandler = value; }

    public IDisplayHandler? DisplayHandler { get => WebViewHost.DisplayHandler; set => WebViewHost.DisplayHandler = value; }

    public IDownloadHandler? DownloadHandler { get => WebViewHost.DownloadHandler; set => WebViewHost.DownloadHandler = value; }

    public IFindHandler? FindHandler { get => WebViewHost.FindHandler; set => WebViewHost.FindHandler = value; }

    public IFocusHandler? FocusHandler { get => WebViewHost.FocusHandler; set => WebViewHost.FocusHandler = value; }

    public IFrameHandler? FrameHandler { get => WebViewHost.FrameHandler; set => WebViewHost.FrameHandler = value; }

    public IPermissionHandler? PermissionHandler { get => WebViewHost.PermissionHandler; set => WebViewHost.PermissionHandler = value; }

    public IJSDialogHandler? JSDialogHandler { get => WebViewHost.JSDialogHandler; set => WebViewHost.JSDialogHandler = value; }

    public IKeyboardHandler? KeyboardHandler { get => WebViewHost.KeyboardHandler; set => WebViewHost.KeyboardHandler = value; }

    public ILoadHandler? LoadHandler { get => WebViewHost.LoadHandler; set => WebViewHost.LoadHandler = value; }

    public IRenderHandler? RenderHandler { get => WebViewHost.RenderHandler; set => WebViewHost.RenderHandler = value; }

    public IRequestHandler? RequestHandler { get => this; set => throw new NotSupportedException(); }

    public ILifeSpanHandler? LifeSpanHandler { get => this; set => throw new NotSupportedException(); }

    public IContextMenuHandler? ContextMenuHandler { get => this; set => throw new NotSupportedException(); }

    public IDragHandler? DragHandler { get => this; set => throw new NotSupportedException(); }
    public IPrintHandler? PrintHandler { get => WebViewHost.PrintHandler; set => WebViewHost.PrintHandler = value; }

    bool IWebViewClient.OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        MessageDispatcher.DispatchMessage(browser, frame, sourceProcess, message);

        return WebViewHost.OnProcessMessageReceived(browser, frame, sourceProcess, message);

        //try
        //{
        //    MessageDispatcher.DispatchMessage(browser, frame, sourceProcess, message);

        //    return WebViewHost.OnProcessMessageReceived(browser, frame, sourceProcess, message);

        //}
        //catch (Exception e)
        //{
        //    WebViewHost.HandleException(e);
        //    return false;
        //}
    }

}
