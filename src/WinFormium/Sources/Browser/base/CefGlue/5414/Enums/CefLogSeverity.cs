// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Log severity levels.
/// </summary>
public enum CefLogSeverity
{
    /// <summary>
    /// Default logging (currently INFO logging).
    /// </summary>
    Default,

    /// <summary>
    /// Verbose logging.
    /// </summary>
    Verbose,

    /// <summary>
    /// DEBUG logging.
    /// </summary>
    Debug = Verbose,

    /// <summary>
    /// INFO logging.
    /// </summary>
    Info,

    /// <summary>
    /// WARNING logging.
    /// </summary>
    Warning,

    /// <summary>
    /// ERROR logging.
    /// </summary>
    Error,

    /// <summary>
    /// FATAL logging.
    /// </summary>
    Fatal,

    /// <summary>
    /// Disable logging to file for all messages, and to stderr for messages with
    /// severity less than FATAL.
    /// </summary>
    Disable = 99,
}
