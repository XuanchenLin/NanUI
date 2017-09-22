// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a point.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxPoint : CfxStructure {

        internal static CfxPoint Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPoint(nativePtr);
        }

        internal static CfxPoint WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPoint(nativePtr, CfxApi.Point.cfx_point_dtor);
        }

        public CfxPoint() : base(CfxApi.Point.cfx_point_ctor, CfxApi.Point.cfx_point_dtor) {}
        internal CfxPoint(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxPoint(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int X {
            get {
                int value;
                CfxApi.Point.cfx_point_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Point.cfx_point_set_x(nativePtrUnchecked, value);
            }
        }

        public int Y {
            get {
                int value;
                CfxApi.Point.cfx_point_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Point.cfx_point_set_y(nativePtrUnchecked, value);
            }
        }

    }
}
