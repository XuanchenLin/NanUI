// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Generic callback interface used for asynchronous completion.
/// </summary>
public abstract unsafe partial class CefCompletionCallback
{
    private void on_complete(cef_completion_callback_t* self)
    {
        CheckSelf(self);

        OnComplete();
    }
    
    /// <summary>
    /// Method that will be called once the task is complete.
    /// </summary>
    protected abstract void OnComplete();
}
