// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing insets.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxInsets : CfxStructure {

        internal static CfxInsets Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxInsets(nativePtr);
        }

        internal static CfxInsets WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxInsets(nativePtr, CfxApi.Insets.cfx_insets_dtor);
        }

        public CfxInsets() : base(CfxApi.Insets.cfx_insets_ctor, CfxApi.Insets.cfx_insets_dtor) {}
        internal CfxInsets(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxInsets(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int Top {
            get {
                int value;
                CfxApi.Insets.cfx_insets_get_top(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Insets.cfx_insets_set_top(nativePtrUnchecked, value);
            }
        }

        public int Left {
            get {
                int value;
                CfxApi.Insets.cfx_insets_get_left(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Insets.cfx_insets_set_left(nativePtrUnchecked, value);
            }
        }

        public int Bottom {
            get {
                int value;
                CfxApi.Insets.cfx_insets_get_bottom(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Insets.cfx_insets_set_bottom(nativePtrUnchecked, value);
            }
        }

        public int Right {
            get {
                int value;
                CfxApi.Insets.cfx_insets_get_right(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Insets.cfx_insets_set_right(nativePtrUnchecked, value);
            }
        }

    }
}
