//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_permission_request_result_t.
//
namespace Xilium.CefGlue
{
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
}
