// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a rectangle.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxRect : CfxStructure {

        internal static CfxRect Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxRect(nativePtr);
        }

        internal static CfxRect WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxRect(nativePtr, CfxApi.Rect.cfx_rect_dtor);
        }

        public CfxRect() : base(CfxApi.Rect.cfx_rect_ctor, CfxApi.Rect.cfx_rect_dtor) {}
        internal CfxRect(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxRect(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int X {
            get {
                int value;
                CfxApi.Rect.cfx_rect_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Rect.cfx_rect_set_x(nativePtrUnchecked, value);
            }
        }

        public int Y {
            get {
                int value;
                CfxApi.Rect.cfx_rect_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Rect.cfx_rect_set_y(nativePtrUnchecked, value);
            }
        }

        public int Width {
            get {
                int value;
                CfxApi.Rect.cfx_rect_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Rect.cfx_rect_set_width(nativePtrUnchecked, value);
            }
        }

        public int Height {
            get {
                int value;
                CfxApi.Rect.cfx_rect_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Rect.cfx_rect_set_height(nativePtrUnchecked, value);
            }
        }

    }
}
