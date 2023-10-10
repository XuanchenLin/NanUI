// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewClient : CefClient
{
    public IWebViewClient FormiumBrowserClient { get; }

    public WebViewClient(IWebViewClient client)
    {
        FormiumBrowserClient = client;
    }

    protected override CefAudioHandler? GetAudioHandler()
    {
        return FormiumBrowserClient?.AudioHandler == null ? base.GetAudioHandler() : new WebViewAudioHandler(FormiumBrowserClient.AudioHandler);
    }

    protected override CefCommandHandler? GetCommandHandler()
    {
        return FormiumBrowserClient?.CommandHandler == null ? base.GetCommandHandler() : new WebViewCommandHandler(FormiumBrowserClient.CommandHandler);
    }

    protected override CefContextMenuHandler? GetContextMenuHandler()
    {
        return FormiumBrowserClient?.ContextMenuHandler == null ? base.GetContextMenuHandler() : new WebViewContextMenuHandler(FormiumBrowserClient.ContextMenuHandler);
    }

    protected override CefDialogHandler? GetDialogHandler()
    {
        return FormiumBrowserClient?.DialogHandler == null ? base.GetDialogHandler() : new WebViewDialogHandler(FormiumBrowserClient.DialogHandler);
    }

    protected override CefDisplayHandler? GetDisplayHandler()
    {
        return FormiumBrowserClient?.DisplayHandler == null ? base.GetDisplayHandler() : new WebViewDisplayHandler(FormiumBrowserClient.DisplayHandler);
    }

    protected override CefDownloadHandler? GetDownloadHandler()
    {
        return FormiumBrowserClient?.DownloadHandler == null ? base.GetDownloadHandler() : new WebViewDownloadHandler(FormiumBrowserClient.DownloadHandler);
    }

    protected override CefDragHandler? GetDragHandler()
    {
        return FormiumBrowserClient?.DragHandler == null ? base.GetDragHandler() : new WebViewDragHandler(FormiumBrowserClient.DragHandler);
    }

    protected override CefFindHandler? GetFindHandler()
    {
        return FormiumBrowserClient?.FindHandler == null ? base.GetFindHandler() : new WebViewFindHandler(FormiumBrowserClient.FindHandler);
    }

    protected override CefFocusHandler? GetFocusHandler()
    {
        return FormiumBrowserClient?.FocusHandler == null ? base.GetFocusHandler() : new WebViewFocusHandler(FormiumBrowserClient.FocusHandler);
    }

    protected override CefFrameHandler? GetFrameHandler()
    {
        return FormiumBrowserClient?.FrameHandler == null ? base.GetFrameHandler() : new WebViewFrameHandler(FormiumBrowserClient.FrameHandler);
    }

    protected override CefJSDialogHandler? GetJSDialogHandler()
    {
        return FormiumBrowserClient?.JSDialogHandler == null ? base.GetJSDialogHandler() : new WebViewJSDialogHandler(FormiumBrowserClient.JSDialogHandler);
    }

    protected override CefKeyboardHandler? GetKeyboardHandler()
    {
        return FormiumBrowserClient?.KeyboardHandler == null ? base.GetKeyboardHandler() : new WebViewKeyboardHandler(FormiumBrowserClient.KeyboardHandler);
    }

    protected override CefLifeSpanHandler? GetLifeSpanHandler()
    {
        return FormiumBrowserClient?.LifeSpanHandler == null ? base.GetLifeSpanHandler() : new WebViewLifeSpanHandler(FormiumBrowserClient.LifeSpanHandler);
    }

    protected override CefLoadHandler? GetLoadHandler()
    {
        return FormiumBrowserClient?.LoadHandler == null ? base.GetLoadHandler() : new WebViewLoadHandler(FormiumBrowserClient.LoadHandler);
    }

    protected override CefPermissionHandler? GetPermissionHandler()
    {
        return FormiumBrowserClient?.PermissionHandler == null ? base.GetPermissionHandler() : new WebViewPermissionHandler(FormiumBrowserClient.PermissionHandler);
    }

    // only for linux, so igrone it.

    protected override CefPrintHandler? GetPrintHandler()
    {
        return FormiumBrowserClient?.PrintHandler == null ? base.GetPrintHandler() : new WebViewPrintHandler(FormiumBrowserClient.PrintHandler);
    }

    protected override CefRenderHandler? GetRenderHandler()
    {
        return FormiumBrowserClient?.RenderHandler == null ? base.GetRenderHandler() : new WebViewRenderHandler(FormiumBrowserClient.RenderHandler);
    }

    protected override CefRequestHandler? GetRequestHandler()
    {
        return FormiumBrowserClient?.RequestHandler == null ? base.GetRequestHandler() : new WebViewRequestHandler(FormiumBrowserClient.RequestHandler);
    }

    protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        return FormiumBrowserClient.OnProcessMessageReceived(browser, frame, sourceProcess, message);
    }
}
