// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.CefGlue;
/// <summary>
/// Represents the state of a setting.
/// </summary>
public enum CefState : int
{
    /// <summary>
    /// Use the default state for the setting.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Enable or allow the setting.
    /// </summary>
    Enabled,

    /// <summary>
    /// Disable or disallow the setting.
    /// </summary>
    Disabled,
}
