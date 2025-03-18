// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;

/// <summary>
/// Process termination status values.
/// </summary>
public enum CefTerminationStatus
{
    /// <summary>
    /// Non-zero exit status.
    /// </summary>
    Termination,

    /// <summary>
    /// SIGKILL or task manager kill.
    /// </summary>
    WasKilled,

    /// <summary>
    /// Segmentation fault.
    /// </summary>
    ProcessCrashed,

    /// <summary>
    /// Out of memory. Some platforms may use TS_PROCESS_CRASHED instead.
    /// </summary>
    OutOfMemory,
}
