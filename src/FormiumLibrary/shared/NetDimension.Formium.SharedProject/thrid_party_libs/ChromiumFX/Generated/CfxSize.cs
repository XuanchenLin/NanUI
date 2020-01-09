// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a size.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxSize : CfxStructure {

        internal static CfxSize Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxSize(nativePtr);
        }

        internal static CfxSize WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxSize(nativePtr, CfxApi.Size.cfx_size_dtor);
        }

        public CfxSize() : base(CfxApi.Size.cfx_size_ctor, CfxApi.Size.cfx_size_dtor) {}
        internal CfxSize(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxSize(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int Width {
            get {
                int value;
                CfxApi.Size.cfx_size_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Size.cfx_size_set_width(nativePtrUnchecked, value);
            }
        }

        public int Height {
            get {
                int value;
                CfxApi.Size.cfx_size_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Size.cfx_size_set_height(nativePtrUnchecked, value);
            }
        }

    }
}
