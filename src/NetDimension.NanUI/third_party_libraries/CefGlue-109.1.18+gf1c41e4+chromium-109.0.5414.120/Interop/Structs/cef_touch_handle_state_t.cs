//
// This file manually written from cef/include/internal/cef_types.h.
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_touch_handle_state_t
    {
        public int touch_handle_id;
        public CefTouchHandleStateFlags flags;
        public int enabled;
        public CefHorizontalAlignment orientation;
        public int mirror_vertical;
        public int mirror_horizontal;
        public cef_point_t origin;
        public float alpha;
    }
}
