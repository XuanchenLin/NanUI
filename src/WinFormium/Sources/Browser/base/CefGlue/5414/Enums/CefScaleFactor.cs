// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Supported UI scale factors for the platform. SCALE_FACTOR_NONE is used for
/// density independent resources such as string, html/js files or an image that
/// can be used for any scale factors (such as wallpapers).
/// </summary>
public enum CefScaleFactor : int
{
    None = 0,
    P100,
    P125,
    P133,
    P140,
    P150,
    P180,
    P200,
    P250,
    P300,
}
