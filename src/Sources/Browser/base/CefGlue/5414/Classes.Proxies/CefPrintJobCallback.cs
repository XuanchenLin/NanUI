// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.CefGlue.Interop;

namespace NetDimension.NanUI.CefGlue;
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
