//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_quick_menu_edit_state_flags_t.
//
using System;

namespace Xilium.CefGlue
{
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
}
