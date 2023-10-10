// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class ContextMenuHandler : IContextMenuHandler
{
    void IContextMenuHandler.OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
        OnBeforeContextMenu(browser, frame, state, model);
    }

    bool IContextMenuHandler.OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        return OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
    }

    void IContextMenuHandler.OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        OnContextMenuDismissed(browser, frame);
    }

    bool IContextMenuHandler.OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags)
    {
        return OnQuickMenuCommand(browser, frame, commandId, eventFlags);
    }

    void IContextMenuHandler.OnQuickMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        OnQuickMenuDismissed(browser, frame);
    }

    bool IContextMenuHandler.RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {
        return RunContextMenu(browser, frame, parameters, model, callback);
    }

    bool IContextMenuHandler.RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback)
    {
        return RunQuickMenu(browser, frame, location, size, editStateFlags, callback);
    }


    protected virtual void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
    }

    protected virtual bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        return false;
    }

    protected virtual void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
    }

    protected virtual bool OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags)
    {
        return false;
    }

    protected virtual void OnQuickMenuDismissed(CefBrowser browser, CefFrame frame)
    {
    }


    protected virtual bool RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback)
    {
        return false;
    }

    protected virtual bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {
        return false;
    }
}
