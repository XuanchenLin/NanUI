// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Permission request results.
/// </summary>
public enum CefPermissionRequestResult
{
    /// <summary>
    /// Accept the permission request as an explicit user action.
    /// </summary>
    Accept,

    /// <summary>
    /// Deny the permission request as an explicit user action.
    /// </summary>
    Deny,

    /// <summary>
    /// Dismiss the permission request as an explicit user action.
    /// </summary>
    Dismiss,

    /// <summary>
    /// Ignore the permission request. If the prompt remains unhandled (e.g.
    /// OnShowPermissionPrompt returns false and there is no default permissions
    /// UI) then any related promises may remain unresolved.
    /// </summary>
    Ignore,
}
