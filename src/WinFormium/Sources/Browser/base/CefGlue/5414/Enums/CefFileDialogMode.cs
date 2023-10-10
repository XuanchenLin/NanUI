// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Supported file dialog modes.
/// </summary>
[Flags]
public enum CefFileDialogMode
{
    /// <summary>
    /// Requires that the file exists before allowing the user to pick it.
    /// </summary>
    Open = 0,

    /// <summary>
    /// Like Open, but allows picking multiple files to open.
    /// </summary>
    OpenMultiple,

    /// <summary>
    /// Like Open, but selects a folder to open.
    /// </summary>
    OpenFolder,

    /// <summary>
    /// Allows picking a nonexistent file, and prompts to overwrite if the file
    /// already exists.
    /// </summary>
    Save,
}
