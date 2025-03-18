// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.CefGlue.Interop;

namespace NetDimension.NanUI.CefGlue;
/// <summary>
/// Interface to implement to be notified of asynchronous completion via
/// CefCookieManager::DeleteCookies().
/// </summary>
public abstract unsafe partial class CefDeleteCookiesCallback
{
    private void on_complete(cef_delete_cookies_callback_t* self, int num_deleted)
    {
        CheckSelf(self);
        OnComplete(num_deleted);
    }

    /// <summary>
    /// Method that will be called upon completion. |num_deleted| will be the
    /// number of cookies that were deleted.
    /// </summary>
    protected abstract void OnComplete(int numDeleted);
}
