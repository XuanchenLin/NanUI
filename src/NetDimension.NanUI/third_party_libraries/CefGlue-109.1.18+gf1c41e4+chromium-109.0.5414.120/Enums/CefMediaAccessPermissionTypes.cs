//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_media_access_permission_types_t.
//
namespace Xilium.CefGlue
{
    using System;

    /// <summary>
    /// Media access permissions used by OnRequestMediaAccessPermission.
    /// </summary>
    [Flags]
    public enum CefMediaAccessPermissionTypes
    {
        /// <summary>
        /// No permission.
        /// </summary>
        None = 0,

        /// <summary>
        /// Device audio capture permission.
        /// </summary>
        DeviceAudioCapture = 1 << 0,

        /// <summary>
        /// Device video capture permission.
        /// </summary>
        DeviceVideoCapture = 1 << 1,

        /// <summary>
        /// Desktop audio capture permission.
        /// </summary>
        DesktopAudioCapture = 1 << 2,

        /// <summary>
        /// Desktop video capture permission.
        /// </summary>
        DesktopVideoCapture = 1 << 3,
    }
}
