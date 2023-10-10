// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface for asynchronous continuation of print dialog requests.
/// </summary>
public sealed unsafe partial class CefPrintDialogCallback
{
    /// <summary>
    /// Continue printing with the specified |settings|.
    /// </summary>
    public void Continue(CefPrintSettings settings)
    {
        cef_print_dialog_callback_t.cont(_self, settings.ToNative());
    }

    /// <summary>
    /// Cancel the printing.
    /// </summary>
    public void Cancel()
    {
        cef_print_dialog_callback_t.cancel(_self);
    }
}
