// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
namespace Chromium {
    /// <summary>
    /// Base class for all wrapper classes for CEF structs without refcount.
    /// </summary>
    public abstract class CfxStructure : CfxObject {

        static internal IntPtr Unwrap(CfxStructure structure) {
            if(structure == null)
                return IntPtr.Zero;
            return structure.NativePtr;
        }

        private readonly CfxApi.cfx_dtor_delegate m_cfx_dtor;

        // Case 1) User created structure: 
        // allocate native on creation, free native on dispose.
        internal CfxStructure(CfxApi.cfx_ctor_delegate cfx_ctor, CfxApi.cfx_dtor_delegate cfx_dtor) {
            this.m_cfx_dtor = cfx_dtor;
            //this might happen if the application tries to instanciate a platform specific struct
            //on the wrong platform.
            if(cfx_ctor == null)
                return;
            var nativePtr = cfx_ctor();
            if(nativePtr == IntPtr.Zero)
                throw new OutOfMemoryException();
            SetNative(nativePtr);
        }

        // Case 2) struct pointer passed in from framework in callback function
        // wrap native pointer on creation, do not free native pointer
        internal CfxStructure(IntPtr nativePtr) {
            SetNative(nativePtr);
        }

        // Case 3) struct passed in from framework as a return value
        // native layer makes a copy -> free native pointer on dispose
        internal CfxStructure(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) {
            this.m_cfx_dtor = cfx_dtor;
            SetNative(nativePtr);
        }

        /// <summary>
        /// Provides access to the underlying native cef struct.
        /// This object is not refcounted. The native cef struct
        /// will be destroyed when this object is disposed or finalized.
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

        internal override sealed void OnDispose(IntPtr nativePtr) {
            if(m_cfx_dtor != null)
                m_cfx_dtor(nativePtr);
        }
    }
}
