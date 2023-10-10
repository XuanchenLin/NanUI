// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Focus sources.
/// </summary>
public enum CefFocusSource
{
    /// <summary>
    /// The source is explicit navigation via the API (LoadURL(), etc).
    /// </summary>
    Navigation = 0,

    /// <summary>
    /// The source is a system-generated focus event.
    /// </summary>
    System,
}
