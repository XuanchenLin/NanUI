// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewContextMenuHandler : CefContextMenuHandler
{
    public IContextMenuHandler Handler { get; }

    public WebViewContextMenuHandler(IContextMenuHandler handler)
    {
        Handler = handler;
    }


    protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
        Handler.OnBeforeContextMenu(browser, frame, state, model);
    }

    protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        return Handler.OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
    }

    protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        Handler.OnContextMenuDismissed(browser, frame);
    }

    protected override bool OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags)
    {
        return Handler.OnQuickMenuCommand(browser, frame, commandId, eventFlags);
    }

    protected override void OnQuickMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        Handler.OnQuickMenuDismissed(browser, frame);
    }

    protected override bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {
        return Handler.RunContextMenu(browser, frame, parameters, model, callback);
    }

    protected override bool RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback)
    {
        return Handler.RunQuickMenu(browser, frame, location, size, editStateFlags, callback);
    }
}
