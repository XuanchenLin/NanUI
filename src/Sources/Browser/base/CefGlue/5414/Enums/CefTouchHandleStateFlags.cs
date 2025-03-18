// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;

/// <summary>
/// Values indicating what state of the touch handle is set.
/// </summary>
[Flags]
public enum CefTouchHandleStateFlags : uint
{
    None = 0,
    Enabled = 1 << 0,
    Orientation = 1 << 1,
    Origin = 1 << 2,
    Alpha = 1 << 3,
}
