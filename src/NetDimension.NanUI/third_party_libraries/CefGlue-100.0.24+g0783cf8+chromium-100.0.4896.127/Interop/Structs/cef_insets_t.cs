//
// This file manually written from cef/include/internal/cef_types_geometry.h.
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe struct cef_insets_t
    {
        public int top;
        public int left;
        public int bottom;
        public int right;

        public cef_insets_t(int top, int left, int bottom, int right)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }
    }
}
