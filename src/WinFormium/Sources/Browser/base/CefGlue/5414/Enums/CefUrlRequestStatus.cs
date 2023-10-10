// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
public enum CefUrlRequestStatus
{
    /// <summary>
    /// Unknown status.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Request succeeded.
    /// </summary>
    Success,

    /// <summary>
    /// An IO request is pending, and the caller will be informed when it is
    /// completed.
    /// </summary>
    IOPending,

    /// <summary>
    /// Request was canceled programatically.
    /// </summary>
    Canceled,

    /// <summary>
    /// Request failed for some reason.
    /// </summary>
    Failed,
}
