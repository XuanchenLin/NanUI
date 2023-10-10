// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Describes how to interpret the alpha component of a pixel.
/// </summary>
public enum CefAlphaType
{
    /// <summary>
    /// No transparency. The alpha component is ignored.
    /// </summary>
    Opaque,

    /// <summary>
    /// Transparency with pre-multiplied alpha component.
    /// </summary>
    Premultiplied,

    /// <summary>
    /// Transparency with post-multiplied alpha component.
    /// </summary>
    Postmultiplied,
}
