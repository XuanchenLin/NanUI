// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a draggable region.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxDraggableRegion : CfxStructure {

        internal static CfxDraggableRegion Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxDraggableRegion(nativePtr);
        }

        internal static CfxDraggableRegion WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxDraggableRegion(nativePtr, CfxApi.DraggableRegion.cfx_draggable_region_dtor);
        }

        public CfxDraggableRegion() : base(CfxApi.DraggableRegion.cfx_draggable_region_ctor, CfxApi.DraggableRegion.cfx_draggable_region_dtor) {}
        internal CfxDraggableRegion(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxDraggableRegion(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        /// <summary>
        /// Bounds of the region.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxRect Bounds {
            get {
                IntPtr value;
                CfxApi.DraggableRegion.cfx_draggable_region_get_bounds(nativePtrUnchecked, out value);
                return CfxRect.Wrap(value);
            }
            set {
                CfxApi.DraggableRegion.cfx_draggable_region_set_bounds(nativePtrUnchecked, CfxRect.Unwrap(value));
            }
        }

        /// <summary>
        /// True (1) this this region is draggable and false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool Draggable {
            get {
                int value;
                CfxApi.DraggableRegion.cfx_draggable_region_get_draggable(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.DraggableRegion.cfx_draggable_region_set_draggable(nativePtrUnchecked, value ? 1 : 0);
            }
        }

    }
}
