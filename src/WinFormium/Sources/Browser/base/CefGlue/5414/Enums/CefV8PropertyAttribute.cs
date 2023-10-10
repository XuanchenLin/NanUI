// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
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
