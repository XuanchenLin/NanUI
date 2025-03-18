// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;
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
