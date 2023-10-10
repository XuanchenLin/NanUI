// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Supported context menu edit state bit flags. These constants match their
/// equivalents in Chromium's ContextMenuDataEditFlags and should not be
/// renumbered.
/// </summary>
[Flags]
public enum CefContextMenuEditStateFlags
{
    None = 0,
    CanUndo = 1 << 0,
    CanRedo = 1 << 1,
    CanCut = 1 << 2,
    CanCopy = 1 << 3,
    CanPaste = 1 << 4,
    CanDelete = 1 << 5,
    CanSelectAll = 1 << 6,
    CanTranslate = 1 << 7,
    CanEditRichly = 1 << 8,
}
