// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Supported context menu media types. These constants match their equivalents
/// in Chromium's ContextMenuDataMediaType and should not be renumbered.
/// </summary>
public enum CefContextMenuMediaType
{
    /// <summary>
    /// No special node is in context.
    /// </summary>
    None,

    /// <summary>
    /// An image node is selected.
    /// </summary>
    Image,

    /// <summary>
    /// A video node is selected.
    /// </summary>
    Video,

    /// <summary>
    /// An audio node is selected.
    /// </summary>
    Audio,

    /// <summary>
    /// An canvas node is selected.
    /// </summary>
    Canvas,

    /// <summary>
    /// A file node is selected.
    /// </summary>
    File,

    /// <summary>
    /// A plugin node is selected.
    /// </summary>
    Plugin,
}
