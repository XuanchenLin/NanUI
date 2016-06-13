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
	/// Base class for all wrapper classes for ref counted CEF structs.
	/// </summary>
	public abstract class CfxBase : CfxObject {

        static internal CfxBase Cast(IntPtr nativePtr) {
            throw new Exception("Implement this");
        }

        static internal IntPtr Unwrap(CfxBase cfxBase) {
            if (cfxBase == null) {
                return IntPtr.Zero;
            } else {
                return cfxBase.NativePtr;
            }
        }


        internal CfxBase(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxBase(CfxApi.cfx_ctor_with_gc_handle_delegate cfx_ctor) {
            CreateNative(cfx_ctor);
        }

        /// <summary>
        /// Provides access to the underlying native cef struct.
        /// This is a refcounted struct derived from cef_base_t.
        /// Add a ref before you let this managed object go out of scope.
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

        internal override void OnDispose(IntPtr nativePtr) {
            CfxApi.cfx_release(nativePtr);
        }
    }
}
