// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Supported context menu type flags.
/// </summary>
[Flags]
public enum CefContextMenuTypeFlags
{
    /// <summary>
    /// No node is selected.
    /// </summary>
    None = 0,

    /// <summary>
    /// The top page is selected.
    /// </summary>
    Page = 1 << 0,

    /// <summary>
    /// A subframe page is selected.
    /// </summary>
    Frame = 1 << 1,

    /// <summary>
    /// A link is selected.
    /// </summary>
    Link = 1 << 2,

    /// <summary>
    /// A media node is selected.
    /// </summary>
    Media = 1 << 3,

    /// <summary>
    /// There is a textual or mixed selection that is selected.
    /// </summary>
    Selection = 1 << 4,

    /// <summary>
    /// An editable element is selected.
    /// </summary>
    Editable = 1 << 5
}
