// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface for asynchronous continuation of print job requests.
/// </summary>
public sealed unsafe partial class CefPrintJobCallback
{
    /// <summary>
    /// Indicate completion of the print job.
    /// </summary>
    public void Continue()
    {
        cef_print_job_callback_t.cont(_self);
    }
}
