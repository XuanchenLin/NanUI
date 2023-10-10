// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Interface to implement to be notified of asynchronous completion via
/// CefCookieManager::SetCookie().
/// </summary>
public abstract unsafe partial class CefSetCookieCallback
{
    private void on_complete(cef_set_cookie_callback_t* self, int success)
    {
        CheckSelf(self);
        OnComplete(success != 0);
    }

    /// <summary>
    /// Method that will be called upon completion. |success| will be true if the
    /// cookie was set successfully.
    /// </summary>
    protected abstract void OnComplete(bool success);
}
