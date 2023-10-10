// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Path key values.
/// </summary>
public enum CefPathKey
{
    /// <summary>
    /// Current directory.
    /// </summary>
    Current,

    /// <summary>
    /// Directory containing PK_FILE_EXE.
    /// </summary>
    DirExe,

    /// <summary>
    /// Directory containing PK_FILE_MODULE.
    /// </summary>
    DirModule,

    /// <summary>
    /// Temporary directory.
    /// </summary>
    DirTemp,

    /// <summary>
    /// Path and filename of the current executable.
    /// </summary>
    FileExe,

    /// <summary>
    /// Path and filename of the module containing the CEF code (usually the
    /// libcef module).
    /// </summary>
    FileModule,

    /// <summary>
    /// "Local Settings\Application Data" directory under the user profile
    /// directory on Windows.
    /// </summary>
    LocalAppData,

    /// <summary>
    /// "Application Data" directory under the user profile directory on Windows
    /// and "~/Library/Application Support" directory on MacOS.
    /// </summary>
    UserData,

    /// <summary>
    /// Directory containing application resources. Can be configured via
    /// CefSettings.resources_dir_path.
    /// </summary>
    Resources,
}
