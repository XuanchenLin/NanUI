// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to handle events related to commands. The methods
/// of this class will be called on the UI thread.
/// </summary>
public abstract unsafe partial class CefCommandHandler
{
    private int on_chrome_command(cef_command_handler_t* self, cef_browser_t* browser, int command_id, CefWindowOpenDisposition disposition)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNative(browser);
        return OnChromeCommand(m_browser, command_id, disposition) ? 1 : 0;
    }

    /// <summary>
    /// Called to execute a Chrome command triggered via menu selection or
    /// keyboard shortcut. Values for |command_id| can be found in the
    /// cef_command_ids.h file. |disposition| provides information about the
    /// intended command target. Return true if the command was handled or false
    /// for the default implementation. For context menu commands this will be
    /// called after CefContextMenuHandler::OnContextMenuCommand. Only used with
    /// the Chrome runtime.
    /// </summary>
    protected abstract bool OnChromeCommand(CefBrowser browser, int commandId, CefWindowOpenDisposition disposition);
}
