// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
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
