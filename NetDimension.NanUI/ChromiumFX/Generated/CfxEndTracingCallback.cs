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
	using Event;

	/// <summary>
	/// Implement this structure to receive notification when tracing has completed.
	/// The functions of this structure will be called on the browser process UI
	/// thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
	/// </remarks>
	public class CfxEndTracingCallback : CfxBase {

        static CfxEndTracingCallback () {
            CfxApiLoader.LoadCfxEndTracingCallbackApi();
        }

        internal static CfxEndTracingCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_end_tracing_callback_get_gc_handle(nativePtr);
            return (CfxEndTracingCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_end_tracing_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_end_tracing_callback_on_end_tracing_complete_delegate(IntPtr gcHandlePtr, IntPtr tracing_file_str, int tracing_file_length);
        private static cfx_end_tracing_callback_on_end_tracing_complete_delegate cfx_end_tracing_callback_on_end_tracing_complete;
        private static IntPtr cfx_end_tracing_callback_on_end_tracing_complete_ptr;

        internal static void on_end_tracing_complete(IntPtr gcHandlePtr, IntPtr tracing_file_str, int tracing_file_length) {
            var self = (CfxEndTracingCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxEndTracingCallbackOnEndTracingCompleteEventArgs(tracing_file_str, tracing_file_length);
            var eventHandler = self.m_OnEndTracingComplete;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxEndTracingCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxEndTracingCallback() : base(CfxApi.cfx_end_tracing_callback_ctor) {}

        /// <summary>
        /// Called after all processes have sent their trace data. |TracingFile| is
        /// the path at which tracing data was written. The client is responsible for
        /// deleting |TracingFile|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public event CfxEndTracingCallbackOnEndTracingCompleteEventHandler OnEndTracingComplete {
            add {
                lock(eventLock) {
                    if(m_OnEndTracingComplete == null) {
                        if(cfx_end_tracing_callback_on_end_tracing_complete == null) {
                            cfx_end_tracing_callback_on_end_tracing_complete = on_end_tracing_complete;
                            cfx_end_tracing_callback_on_end_tracing_complete_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_end_tracing_callback_on_end_tracing_complete);
                        }
                        CfxApi.cfx_end_tracing_callback_set_managed_callback(NativePtr, 0, cfx_end_tracing_callback_on_end_tracing_complete_ptr);
                    }
                    m_OnEndTracingComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnEndTracingComplete -= value;
                    if(m_OnEndTracingComplete == null) {
                        CfxApi.cfx_end_tracing_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEndTracingCallbackOnEndTracingCompleteEventHandler m_OnEndTracingComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnEndTracingComplete != null) {
                m_OnEndTracingComplete = null;
                CfxApi.cfx_end_tracing_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called after all processes have sent their trace data. |TracingFile| is
		/// the path at which tracing data was written. The client is responsible for
		/// deleting |TracingFile|.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
		/// </remarks>
		public delegate void CfxEndTracingCallbackOnEndTracingCompleteEventHandler(object sender, CfxEndTracingCallbackOnEndTracingCompleteEventArgs e);

        /// <summary>
        /// Called after all processes have sent their trace data. |TracingFile| is
        /// the path at which tracing data was written. The client is responsible for
        /// deleting |TracingFile|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public class CfxEndTracingCallbackOnEndTracingCompleteEventArgs : CfxEventArgs {

            internal IntPtr m_tracing_file_str;
            internal int m_tracing_file_length;
            internal string m_tracing_file;

            internal CfxEndTracingCallbackOnEndTracingCompleteEventArgs(IntPtr tracing_file_str, int tracing_file_length) {
                m_tracing_file_str = tracing_file_str;
                m_tracing_file_length = tracing_file_length;
            }

            /// <summary>
            /// Get the TracingFile parameter for the <see cref="CfxEndTracingCallback.OnEndTracingComplete"/> callback.
            /// </summary>
            public string TracingFile {
                get {
                    CheckAccess();
                    m_tracing_file = StringFunctions.PtrToStringUni(m_tracing_file_str, m_tracing_file_length);
                    return m_tracing_file;
                }
            }

            public override string ToString() {
                return String.Format("TracingFile={{{0}}}", TracingFile);
            }
        }

    }
}
