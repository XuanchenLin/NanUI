// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Supported value types.
/// </summary>
public enum CefValueType
{
    Invalid = 0,
    Null,
    Bool,
    Int,
    Double,
    String,
    Binary,
    Dictionary,
    List,
}
