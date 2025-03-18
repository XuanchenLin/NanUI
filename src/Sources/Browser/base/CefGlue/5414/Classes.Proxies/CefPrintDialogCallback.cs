// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.CefGlue.Interop;

namespace NetDimension.NanUI.CefGlue;
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
