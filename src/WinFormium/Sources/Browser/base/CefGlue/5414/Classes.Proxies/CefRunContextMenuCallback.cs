// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface used for continuation of custom context menu display.
/// </summary>
public sealed unsafe partial class CefRunContextMenuCallback
{
    /// <summary>
    /// Complete context menu display by selecting the specified |command_id| and
    /// |event_flags|.
    /// </summary>
    public void Continue(int commandId, CefEventFlags eventFlags)
    {
        cef_run_context_menu_callback_t.cont(_self, commandId, eventFlags);
    }

    /// <summary>
    /// Cancel context menu display.
    /// </summary>
    public void Cancel()
    {
        cef_run_context_menu_callback_t.cancel(_self);
    }
}
