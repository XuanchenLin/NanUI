// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxEndTracingCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_end_tracing_complete_native = on_end_tracing_complete;

            on_end_tracing_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_end_tracing_complete_native);
        }

        // on_end_tracing_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_end_tracing_complete_delegate(IntPtr gcHandlePtr, IntPtr tracing_file_str, int tracing_file_length);
        private static on_end_tracing_complete_delegate on_end_tracing_complete_native;
        private static IntPtr on_end_tracing_complete_native_ptr;

        internal static void on_end_tracing_complete(IntPtr gcHandlePtr, IntPtr tracing_file_str, int tracing_file_length) {
            var self = (CfxEndTracingCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnEndTracingCompleteEventArgs();
            e.m_tracing_file_str = tracing_file_str;
            e.m_tracing_file_length = tracing_file_length;
            self.m_OnEndTracingComplete?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxEndTracingCallback() : base(CfxApi.EndTracingCallback.cfx_end_tracing_callback_ctor) {}

        /// <summary>
        /// Called after all processes have sent their trace data. |TracingFile| is
        /// the path at which tracing data was written. The client is responsible for
        /// deleting |TracingFile|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public event CfxOnEndTracingCompleteEventHandler OnEndTracingComplete {
            add {
                lock(eventLock) {
                    if(m_OnEndTracingComplete == null) {
                        CfxApi.EndTracingCallback.cfx_end_tracing_callback_set_callback(NativePtr, 0, on_end_tracing_complete_native_ptr);
                    }
                    m_OnEndTracingComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnEndTracingComplete -= value;
                    if(m_OnEndTracingComplete == null) {
                        CfxApi.EndTracingCallback.cfx_end_tracing_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnEndTracingCompleteEventHandler m_OnEndTracingComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnEndTracingComplete != null) {
                m_OnEndTracingComplete = null;
                CfxApi.EndTracingCallback.cfx_end_tracing_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called after all processes have sent their trace data. |TracingFile| is
        /// the path at which tracing data was written. The client is responsible for
        /// deleting |TracingFile|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnEndTracingCompleteEventHandler(object sender, CfxOnEndTracingCompleteEventArgs e);

        /// <summary>
        /// Called after all processes have sent their trace data. |TracingFile| is
        /// the path at which tracing data was written. The client is responsible for
        /// deleting |TracingFile|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_trace_capi.h">cef/include/capi/cef_trace_capi.h</see>.
        /// </remarks>
        public class CfxOnEndTracingCompleteEventArgs : CfxEventArgs {

            internal IntPtr m_tracing_file_str;
            internal int m_tracing_file_length;
            internal string m_tracing_file;

            internal CfxOnEndTracingCompleteEventArgs() {}

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
