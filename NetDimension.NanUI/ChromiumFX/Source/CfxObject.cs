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
	/// Base class for all wrapper classes for CEF structs.
	/// </summary>
	public abstract class CfxObject : IDisposable {

        private IntPtr m_nativePtr;
                
        internal CfxObject() {}

        internal CfxObject(IntPtr nativePtr) {
            this.m_nativePtr = nativePtr;
        }

        internal void CreateNative(CfxApi.cfx_ctor_delegate cfx_ctor) {
            m_nativePtr = cfx_ctor();
            if(m_nativePtr == IntPtr.Zero)
                throw new OutOfMemoryException();
        }

        internal void SetNative(IntPtr nativePtr) {
            this.m_nativePtr = nativePtr;
        }

        internal void CreateNative(CfxApi.cfx_ctor_with_gc_handle_delegate cfx_ctor) {
            // must be a weak handle
            // otherwise transient callback structs never go out of scope if
            // they are not explicitly disposed
            System.Runtime.InteropServices.GCHandle handle =
                System.Runtime.InteropServices.GCHandle.Alloc(this, System.Runtime.InteropServices.GCHandleType.Weak);
            m_nativePtr = cfx_ctor(System.Runtime.InteropServices.GCHandle.ToIntPtr(handle));
            if(m_nativePtr == IntPtr.Zero)
                throw new OutOfMemoryException();
        }

        internal IntPtr nativePtrUnchecked {
            get {
                return m_nativePtr;
            }
        }

        public abstract IntPtr NativePtr { get; }

        internal abstract void OnDispose(IntPtr nativePtr);

        public void Dispose() {
            if(m_nativePtr != IntPtr.Zero) {
                OnDispose(m_nativePtr);
                m_nativePtr = IntPtr.Zero;
                GC.SuppressFinalize(this);
            }
        }

        ~CfxObject() {
            if(m_nativePtr != IntPtr.Zero) {
                OnDispose(m_nativePtr);
                m_nativePtr = IntPtr.Zero;
            }
        }
    }
}
