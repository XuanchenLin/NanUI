// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IContextMenuHandler
{
    void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model);
    bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback);
    bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags);
    void OnContextMenuDismissed(CefBrowser browser, CefFrame frame);
    bool RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback);
    bool OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags);
    void OnQuickMenuDismissed(CefBrowser browser, CefFrame frame);
}
