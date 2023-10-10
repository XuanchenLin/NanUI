// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Return values for CefResponseFilter::Filter().
/// </summary>
public enum CefResponseFilterStatus
{
    /// <summary>
    /// Some or all of the pre-filter data was read successfully but more data is
    /// needed in order to continue filtering (filtered output is pending).
    /// </summary>
    NeedMoreData,

    /// <summary>
    /// Some or all of the pre-filter data was read successfully and all available
    /// filtered output has been written.
    /// </summary>
    Done,

    /// <summary>
    /// An error occurred during filtering.
    /// </summary>
    Error,
}
