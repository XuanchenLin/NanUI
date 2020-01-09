// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Chromium {

    /// <summary>
    /// Base class for all wrapper classes for CEF client callback or handler structs.
    /// </summary>
    public class CfxBaseClient : CfxBaseRefCounted {

        internal CfxBaseClient(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxBaseClient(CfxApi.cfx_ctor_with_gc_handle_delegate cfx_ctor) {
            // must be a weak handle
            // otherwise transient callback structs never go out of scope if
            // they are not explicitly disposed
            GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
            var nativePtr = cfx_ctor(GCHandle.ToIntPtr(handle), 0);
            if(nativePtr == IntPtr.Zero)
                throw new OutOfMemoryException();
            SetNative(nativePtr);
        }

        /// <summary>
        /// Provides access to the underlying native cef struct.
        /// This is a refcounted client struct derived from cef_base_ref_counted_t.
        /// Add a ref in order to keep it alive when this managed object go out of scope.
        /// </summary>
        public sealed override IntPtr NativePtr {
            get {
                if(nativePtrUnchecked == IntPtr.Zero) {
                    throw new ObjectDisposedException(this.GetType().Name);
                } else {
                    return nativePtrUnchecked;
                }
            }
        }

        /// <summary>
        /// When true, all CEF callback events are disabled for this handler. Incoming callbacks will return default values to CEF.
        /// </summary>
        public bool CallbacksDisabled { get; set; }

        internal override void OnDispose(IntPtr nativePtr) {
            CallbacksDisabled = true;
            CfxApi.cfx_release(nativePtr);
        }
    }
}
