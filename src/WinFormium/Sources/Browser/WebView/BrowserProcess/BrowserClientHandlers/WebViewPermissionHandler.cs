// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewPermissionHandler : CefPermissionHandler
{
    public IPermissionHandler Handler { get; }

    public WebViewPermissionHandler(IPermissionHandler handler)
    {
        Handler = handler;
    }

    protected override void OnDismissPermissionPrompt(CefBrowser browser, ulong promptId, CefPermissionRequestResult result)
    {
        Handler.OnDismissPermissionPrompt(browser, promptId, result);
    }

    protected override bool OnRequestMediaAccessPermission(CefBrowser browser, CefFrame frame, string requestingOrigin, CefMediaAccessPermissionTypes requestedPermissions, CefMediaAccessCallback callback)
    {
        return Handler.OnRequestMediaAccessPermission(browser, frame, requestingOrigin, requestedPermissions, callback);
    }

    protected override bool OnShowPermissionPrompt(CefBrowser browser, ulong promptId, string requestingOrigin, CefPermissionRequestTypes requestedPermissions, CefPermissionPromptCallback callback)
    {
        return Handler.OnShowPermissionPrompt(browser, promptId, requestingOrigin, requestedPermissions, callback);
    }
}
