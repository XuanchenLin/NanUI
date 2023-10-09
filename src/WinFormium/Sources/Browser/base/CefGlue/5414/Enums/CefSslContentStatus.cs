// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.CefGlue;
/// <summary>
/// Supported SSL content status flags. See content/public/common/ssl_status.h
/// for more information.
/// </summary>
[Flags]
public enum CefSslContentStatus
{
    Normal = 0,
    DisplayedInsecure = 1 << 0,
    RanInsecure = 1 << 1,
}
