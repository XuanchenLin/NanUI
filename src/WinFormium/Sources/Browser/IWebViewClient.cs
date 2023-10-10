// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IWebViewClient
{
    IAudioHandler? AudioHandler { get; set; }
    ICommandHandler? CommandHandler { get; set; }
    IContextMenuHandler? ContextMenuHandler { get; set; }
    IDialogHandler? DialogHandler { get; set; }
    IDisplayHandler? DisplayHandler { get; set; }
    IDownloadHandler? DownloadHandler { get; set; }
    IDragHandler? DragHandler { get; set; }
    IFindHandler? FindHandler { get; set; }
    IFocusHandler? FocusHandler { get; set; }
    IFrameHandler? FrameHandler { get; set; }
    IPermissionHandler? PermissionHandler { get; set; }
    IJSDialogHandler? JSDialogHandler { get; set; }
    IKeyboardHandler? KeyboardHandler { get; set; }
    ILifeSpanHandler? LifeSpanHandler { get; set; }
    ILoadHandler? LoadHandler { get; set; }
    IPrintHandler? PrintHandler { get; set; }
    IRenderHandler? RenderHandler { get; set; }
    IRequestHandler? RequestHandler { get; set; }

    bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message);
}
