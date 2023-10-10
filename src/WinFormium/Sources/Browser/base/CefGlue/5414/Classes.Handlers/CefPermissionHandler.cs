// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to handle events related to permission requests.
/// The methods of this class will be called on the browser process UI thread.
/// </summary>
public abstract unsafe partial class CefPermissionHandler
{
    private int on_request_media_access_permission(cef_permission_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_string_t* requesting_origin, uint requested_permissions, cef_media_access_callback_t* callback)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        var mRequestingOrigin = cef_string_t.ToString(requesting_origin);
        var mRequestedPermissions = (CefMediaAccessPermissionTypes)requested_permissions;
        var mCallback = CefMediaAccessCallback.FromNative(callback);

        var result = OnRequestMediaAccessPermission(mBrowser, mFrame, mRequestingOrigin, mRequestedPermissions, mCallback);
        if (!result)
        {
            mCallback.Dispose();
        }
        return result ? 1 : 0;
    }

    /// <summary>
    /// Called when a page requests permission to access media.
    /// |requesting_origin| is the URL origin requesting permission.
    /// |requested_permissions| is a combination of values from
    /// cef_media_access_permission_types_t that represent the requested
    /// permissions. Return true and call CefMediaAccessCallback methods either in
    /// this method or at a later time to continue or cancel the request. Return
    /// false to proceed with default handling. With the Chrome runtime, default
    /// handling will display the permission request UI. With the Alloy runtime,
    /// default handling will deny the request. This method will not be called if
    /// the "--enable-media-stream" command-line switch is used to grant all
    /// permissions.
    /// </summary>
    protected virtual bool OnRequestMediaAccessPermission(CefBrowser browser, CefFrame frame,
        string requestingOrigin,
        CefMediaAccessPermissionTypes requestedPermissions,
        CefMediaAccessCallback callback)
        => false;


    private int on_show_permission_prompt(cef_permission_handler_t* self, cef_browser_t* browser, ulong prompt_id, cef_string_t* requesting_origin, uint requested_permissions, cef_permission_prompt_callback_t* callback)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mRequestingOrigin = cef_string_t.ToString(requesting_origin);
        var mRequestedPermissions = (CefPermissionRequestTypes)requested_permissions;
        var mCallback = CefPermissionPromptCallback.FromNative(callback);

        var result = OnShowPermissionPrompt(mBrowser, prompt_id, mRequestingOrigin,
            mRequestedPermissions, mCallback);
        if (!result)
        {
            mCallback.Dispose();
        }
        return result ? 1 : 0;
    }

    /// <summary>
    /// Called when a page should show a permission prompt. |prompt_id| uniquely
    /// identifies the prompt. |requesting_origin| is the URL origin requesting
    /// permission. |requested_permissions| is a combination of values from
    /// cef_permission_request_types_t that represent the requested permissions.
    /// Return true and call CefPermissionPromptCallback::Continue either in this
    /// method or at a later time to continue or cancel the request. Return false
    /// to proceed with default handling. With the Chrome runtime, default
    /// handling will display the permission prompt UI. With the Alloy runtime,
    /// default handling is CEF_PERMISSION_RESULT_IGNORE.
    /// </summary>
    protected virtual bool OnShowPermissionPrompt(CefBrowser browser, ulong promptId, string requestingOrigin,
        CefPermissionRequestTypes requestedPermissions,
        CefPermissionPromptCallback callback)
        => false;


    private void on_dismiss_permission_prompt(cef_permission_handler_t* self, cef_browser_t* browser, ulong prompt_id, CefPermissionRequestResult result)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        OnDismissPermissionPrompt(mBrowser, prompt_id, result);
    }

    /// <summary>
    /// Called when a permission prompt handled via OnShowPermissionPrompt is
    /// dismissed. |prompt_id| will match the value that was passed to
    /// OnShowPermissionPrompt. |result| will be the value passed to
    /// CefPermissionPromptCallback::Continue or CEF_PERMISSION_RESULT_IGNORE if
    /// the dialog was dismissed for other reasons such as navigation, browser
    /// closure, etc. This method will not be called if OnShowPermissionPrompt
    /// returned false for |prompt_id|.
    /// </summary>
    protected virtual void OnDismissPermissionPrompt(CefBrowser browser, ulong promptId, CefPermissionRequestResult result)
    { }
}
