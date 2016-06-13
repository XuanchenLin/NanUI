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

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Generic callback structure used for asynchronous completion.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
	/// </remarks>
	public class CfxCompletionCallback : CfxBase {

        static CfxCompletionCallback () {
            CfxApiLoader.LoadCfxCompletionCallbackApi();
        }

        internal static CfxCompletionCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_completion_callback_get_gc_handle(nativePtr);
            return (CfxCompletionCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_completion_callback_on_complete_delegate(IntPtr gcHandlePtr);
        private static cfx_completion_callback_on_complete_delegate cfx_completion_callback_on_complete;
        private static IntPtr cfx_completion_callback_on_complete_ptr;

        internal static void on_complete(IntPtr gcHandlePtr) {
            var self = (CfxCompletionCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxEventArgs();
            var eventHandler = self.m_OnComplete;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxCompletionCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxCompletionCallback() : base(CfxApi.cfx_completion_callback_ctor) {}

        /// <summary>
        /// Method that will be called once the task is complete.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
        /// </remarks>
        public event CfxEventHandler OnComplete {
            add {
                lock(eventLock) {
                    if(m_OnComplete == null) {
                        if(cfx_completion_callback_on_complete == null) {
                            cfx_completion_callback_on_complete = on_complete;
                            cfx_completion_callback_on_complete_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_completion_callback_on_complete);
                        }
                        CfxApi.cfx_completion_callback_set_managed_callback(NativePtr, 0, cfx_completion_callback_on_complete_ptr);
                    }
                    m_OnComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnComplete -= value;
                    if(m_OnComplete == null) {
                        CfxApi.cfx_completion_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_OnComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnComplete != null) {
                m_OnComplete = null;
                CfxApi.cfx_completion_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{


	}
}
