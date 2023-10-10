// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to handle context menu events. The methods of this
/// class will be called on the UI thread.
/// </summary>
public abstract unsafe partial class CefContextMenuHandler
{
    private void on_before_context_menu(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_context_menu_params_t* @params, cef_menu_model_t* model)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        var mState = CefContextMenuParams.FromNative(@params);
        var mModel = CefMenuModel.FromNative(model);

        OnBeforeContextMenu(mBrowser, mFrame, mState, mModel);

        mState.Dispose();
        mModel.Dispose();
    }

    /// <summary>
    /// Called before a context menu is displayed. |params| provides information
    /// about the context menu state. |model| initially contains the default
    /// context menu. The |model| can be cleared to show no context menu or
    /// modified to show a custom menu. Do not keep references to |params| or
    /// |model| outside of this callback.
    /// </summary>
    protected virtual void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
    }


    private int run_context_menu(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_context_menu_params_t* @params, cef_menu_model_t* model, cef_run_context_menu_callback_t* callback)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        var mParameters = CefContextMenuParams.FromNative(@params);
        var mModel = CefMenuModel.FromNative(model);
        var mCallback = CefRunContextMenuCallback.FromNative(callback);
        var result = RunContextMenu(mBrowser, mFrame, mParameters, mModel, mCallback);
        mParameters.Dispose();
        mModel.Dispose();

        return result ? 1 : 0;
    }

    /// <summary>
    /// Called to allow custom display of the context menu. |params| provides
    /// information about the context menu state. |model| contains the context
    /// menu model resulting from OnBeforeContextMenu. For custom display return
    /// true and execute |callback| either synchronously or asynchronously with
    /// the selected command ID. For default display return false. Do not keep
    /// references to |params| or |model| outside of this callback.
    /// </summary>
    protected virtual bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {
        return false;
    }


    private int on_context_menu_command(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_context_menu_params_t* @params, int command_id, CefEventFlags event_flags)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        var mState = CefContextMenuParams.FromNative(@params);

        var result = OnContextMenuCommand(mBrowser, mFrame, mState, command_id, event_flags);

        mState.Dispose();

        return result ? 1 : 0;
    }

    /// <summary>
    /// Called to execute a command selected from the context menu. Return true if
    /// the command was handled or false for the default implementation. See
    /// cef_menu_id_t for the command ids that have default implementations. All
    /// user-defined command ids should be between MENU_ID_USER_FIRST and
    /// MENU_ID_USER_LAST. |params| will have the same values as what was passed
    /// to OnBeforeContextMenu(). Do not keep a reference to |params| outside of
    /// this callback.
    /// </summary>
    protected virtual bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        return false;
    }


    private void on_context_menu_dismissed(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);

        OnContextMenuDismissed(mBrowser, mFrame);
    }

    /// <summary>
    /// Called when the context menu is dismissed irregardless of whether the menu
    /// was canceled or a command was selected.
    /// </summary>
    protected virtual void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
    }


    private int run_quick_menu(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_point_t* location, cef_size_t* size, CefQuickMenuEditStateFlags edit_state_flags, cef_run_quick_menu_callback_t* callback)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        var mLocation = new CefPoint(location->x, location->y);
        var mSize = new CefSize(size->width, size->height);
        var mCallback = CefRunQuickMenuCallback.FromNative(callback);

        var result = RunQuickMenu(mBrowser, mFrame, mLocation, mSize, edit_state_flags, mCallback);
        if (!result)
        {
            mCallback.Dispose();
        }
        return result ? 1 : 0;
    }

    /// <summary>
    /// Called to allow custom display of the quick menu for a windowless browser.
    /// |location| is the top left corner of the selected region. |size| is the
    /// size of the selected region. |edit_state_flags| is a combination of flags
    /// that represent the state of the quick menu. Return true if the menu will
    /// be handled and execute |callback| either synchronously or asynchronously
    /// with the selected command ID. Return false to cancel the menu.
    /// </summary>
    protected virtual bool RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback)
        => false;


    private int on_quick_menu_command(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, int command_id, CefEventFlags event_flags)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);

        var result = OnQuickMenuCommand(mBrowser, mFrame, command_id, event_flags);
        return result ? 1 : 0;
    }

    /// <summary>
    /// Called to execute a command selected from the quick menu for a windowless
    /// browser. Return true if the command was handled or false for the default
    /// implementation. See cef_menu_id_t for command IDs that have default
    /// implementations.
    /// </summary>
    protected virtual bool OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags)
        => false;


    private void on_quick_menu_dismissed(cef_context_menu_handler_t* self, cef_browser_t* browser, cef_frame_t* frame)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);

        OnQuickMenuDismissed(mBrowser, mFrame);
    }

    /// <summary>
    /// Called when the quick menu for a windowless browser is dismissed
    /// irregardless of whether the menu was canceled or a command was selected.
    /// </summary>
    protected virtual void OnQuickMenuDismissed(CefBrowser browser, CefFrame frame)
    { }
}
