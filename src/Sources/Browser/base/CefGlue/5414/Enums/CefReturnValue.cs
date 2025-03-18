// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;

/// <summary>
/// Return value types.
/// </summary>
public enum CefReturnValue
{
    /// <summary>
    /// Cancel immediately.
    /// </summary>
    Cancel = 0,

    /// <summary>
    /// Continue immediately.
    /// </summary>
    Continue,

    /// <summary>
    /// Continue asynchronously (usually via a callback).
    /// </summary>
    ContinueAsync,
}
