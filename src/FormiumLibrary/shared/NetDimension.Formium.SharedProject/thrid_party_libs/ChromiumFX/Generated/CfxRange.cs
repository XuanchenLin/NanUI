// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a range.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxRange : CfxStructure {

        internal static CfxRange Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxRange(nativePtr);
        }

        internal static CfxRange WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxRange(nativePtr, CfxApi.Range.cfx_range_dtor);
        }

        public CfxRange() : base(CfxApi.Range.cfx_range_ctor, CfxApi.Range.cfx_range_dtor) {}
        internal CfxRange(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxRange(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int From {
            get {
                int value;
                CfxApi.Range.cfx_range_get_from(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Range.cfx_range_set_from(nativePtrUnchecked, value);
            }
        }

        public int To {
            get {
                int value;
                CfxApi.Range.cfx_range_get_to(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Range.cfx_range_set_to(nativePtrUnchecked, value);
            }
        }

    }
}
