// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
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
