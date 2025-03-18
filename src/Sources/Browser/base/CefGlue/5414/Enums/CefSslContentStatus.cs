// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;
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
