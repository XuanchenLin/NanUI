// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.CefGlue.Interop;

namespace NetDimension.NanUI.CefGlue;
/// <summary>
/// Generic callback interface used for asynchronous continuation.
/// </summary>
public sealed unsafe partial class CefCallback
{
    /// <summary>
    /// Continue processing.
    /// </summary>
    public void Continue()
    {
        cef_callback_t.cont(_self);
    }

    /// <summary>
    /// Cancel processing.
    /// </summary>
    public void Cancel()
    {
        cef_callback_t.cancel(_self);
    }
}
