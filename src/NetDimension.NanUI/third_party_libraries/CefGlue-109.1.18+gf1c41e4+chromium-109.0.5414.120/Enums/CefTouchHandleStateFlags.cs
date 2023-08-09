//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_touch_handle_state_flags_t.
//
using System;

namespace Xilium.CefGlue
{
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
}
