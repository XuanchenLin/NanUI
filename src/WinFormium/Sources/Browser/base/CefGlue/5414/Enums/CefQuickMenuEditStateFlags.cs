// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.CefGlue;

/// <summary>
/// Supported quick menu state bit flags.
/// </summary>
[Flags]
public enum CefQuickMenuEditStateFlags
{
    None = 0,
    CanEllipsis = 1 << 0,
    CanCut = 1 << 1,
    CanCopy = 1 << 2,
    CanPaste = 1 << 3,
}
