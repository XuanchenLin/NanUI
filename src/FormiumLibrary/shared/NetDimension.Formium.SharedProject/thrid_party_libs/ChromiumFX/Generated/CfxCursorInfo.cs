// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing cursor information. |buffer| will be
    /// |size.width|*|size.height|*4 bytes in size and represents a BGRA image with
    /// an upper-left origin.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxCursorInfo : CfxStructure {

        internal static CfxCursorInfo Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxCursorInfo(nativePtr);
        }

        internal static CfxCursorInfo WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxCursorInfo(nativePtr, CfxApi.CursorInfo.cfx_cursor_info_dtor);
        }

        public CfxCursorInfo() : base(CfxApi.CursorInfo.cfx_cursor_info_ctor, CfxApi.CursorInfo.cfx_cursor_info_dtor) {}
        internal CfxCursorInfo(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxCursorInfo(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public CfxPoint Hotspot {
            get {
                IntPtr value;
                CfxApi.CursorInfo.cfx_cursor_info_get_hotspot(nativePtrUnchecked, out value);
                return CfxPoint.Wrap(value);
            }
            set {
                CfxApi.CursorInfo.cfx_cursor_info_set_hotspot(nativePtrUnchecked, CfxPoint.Unwrap(value));
            }
        }

        public float ImageScaleFactor {
            get {
                float value;
                CfxApi.CursorInfo.cfx_cursor_info_get_image_scale_factor(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.CursorInfo.cfx_cursor_info_set_image_scale_factor(nativePtrUnchecked, value);
            }
        }

        public IntPtr Buffer {
            get {
                IntPtr value;
                CfxApi.CursorInfo.cfx_cursor_info_get_buffer(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.CursorInfo.cfx_cursor_info_set_buffer(nativePtrUnchecked, value);
            }
        }

        public CfxSize Size {
            get {
                IntPtr value;
                CfxApi.CursorInfo.cfx_cursor_info_get_size(nativePtrUnchecked, out value);
                return CfxSize.Wrap(value);
            }
            set {
                CfxApi.CursorInfo.cfx_cursor_info_set_size(nativePtrUnchecked, CfxSize.Unwrap(value));
            }
        }

    }
}
