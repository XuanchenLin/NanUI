// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface for asynchronous continuation of file dialog requests.
/// </summary>
public sealed unsafe partial class CefFileDialogCallback
{
    /// <summary>
    /// Continue the file selection. |file_paths| should be a single value or a
    /// list of values depending on the dialog mode. An empty |file_paths| value
    /// is treated the same as calling Cancel().
    /// </summary>
    public void Continue(string[] filePaths)
    {
        var n_filePaths = cef_string_list.From(filePaths);

        cef_file_dialog_callback_t.cont(_self, n_filePaths);

        libcef.string_list_free(n_filePaths);
    }

    /// <summary>
    /// Cancel the file selection.
    /// </summary>
    public void Cancel()
    {
        cef_file_dialog_callback_t.cancel(_self);
    }
}
