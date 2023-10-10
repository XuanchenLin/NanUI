// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Specifies where along the cross axis the CefBoxLayout child views should be
/// laid out.
/// </summary>
public enum CefCrossAxisAlignment
{
    /// <summary>
    /// Child views will be stretched to fit.
    /// </summary>
    Stretch,

    /// <summary>
    /// Child views will be left-aligned.
    /// </summary>
    Start,

    /// <summary>
    /// Child views will be center-aligned.
    /// </summary>
    Center,

    /// <summary>
    /// Child views will be right-aligned.
    /// </summary>
    End,
}
