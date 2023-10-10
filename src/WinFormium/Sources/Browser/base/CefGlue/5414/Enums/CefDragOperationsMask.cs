// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// "Verb" of a drag-and-drop operation as negotiated between the source and
/// destination. These constants match their equivalents in WebCore's
/// DragActions.h and should not be renumbered.
/// </summary>
public enum CefDragOperationsMask : uint
{
    None = 0,
    Copy = 1,
    Link = 2,
    Generic = 4,
    Private = 8,
    Move = 16,
    Delete = 32,
    Every = UInt32.MaxValue,
}
