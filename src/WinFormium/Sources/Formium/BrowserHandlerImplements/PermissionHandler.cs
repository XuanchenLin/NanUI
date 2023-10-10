// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class PermissionHandler : IPermissionHandler
{
    void IPermissionHandler.OnDismissPermissionPrompt(CefBrowser browser, ulong promptId, CefPermissionRequestResult result)
    {
        OnDismissPermissionPrompt(browser, promptId, result);
    }

    bool IPermissionHandler.OnRequestMediaAccessPermission(CefBrowser browser, CefFrame frame, string requestingOrigin, CefMediaAccessPermissionTypes requestedPermissions, CefMediaAccessCallback callback)
    {
        return OnRequestMediaAccessPermission(browser, frame, requestingOrigin, requestedPermissions, callback);
    }

    bool IPermissionHandler.OnShowPermissionPrompt(CefBrowser browser, ulong promptId, string requestingOrigin, CefPermissionRequestTypes requestedPermissions, CefPermissionPromptCallback callback)
    {
        return OnShowPermissionPrompt(browser, promptId, requestingOrigin, requestedPermissions, callback);
    }

    protected virtual void OnDismissPermissionPrompt(CefBrowser browser, ulong promptId, CefPermissionRequestResult result)
    {
    }

    protected virtual bool OnRequestMediaAccessPermission(CefBrowser browser, CefFrame frame, string requestingOrigin, CefMediaAccessPermissionTypes requestedPermissions, CefMediaAccessCallback callback)
    {
        return false;
    }

    protected virtual bool OnShowPermissionPrompt(CefBrowser browser, ulong promptId, string requestingOrigin, CefPermissionRequestTypes requestedPermissions, CefPermissionPromptCallback callback)
    {
        return false;
    }


}
