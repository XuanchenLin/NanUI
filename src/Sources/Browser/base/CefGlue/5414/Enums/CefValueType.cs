// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;

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
