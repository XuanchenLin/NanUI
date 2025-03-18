// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;
/// <summary>
/// V8 property attribute values.
/// </summary>
[Flags]
public enum CefV8PropertyAttribute
{
    /// <summary>
    /// Writeable, Enumerable, Configurable
    /// </summary>
    None = 0,

    /// <summary>
    /// Not writeable
    /// </summary>
    ReadOnly = 1 << 0,

    /// <summary>
    /// Not enumerable
    /// </summary>
    DontEnum = 1 << 1,

    /// <summary>
    /// Not configurable
    /// </summary>
    DontDelete = 1 << 2,
}
