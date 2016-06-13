// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



using System;
namespace Chromium
{
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
            CreateNative(cfx_ctor);
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
