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
    /// Callback structure for CfxRequestContext.ResolveHost.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
    /// </remarks>
    public class CfxResolveCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_resolve_completed_native = on_resolve_completed;

            on_resolve_completed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resolve_completed_native);
        }

        // on_resolve_completed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_resolve_completed_delegate(IntPtr gcHandlePtr, int result, IntPtr resolved_ips);
        private static on_resolve_completed_delegate on_resolve_completed_native;
        private static IntPtr on_resolve_completed_native_ptr;

        internal static void on_resolve_completed(IntPtr gcHandlePtr, int result, IntPtr resolved_ips) {
            var self = (CfxResolveCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnResolveCompletedEventArgs();
            e.m_result = result;
            e.m_resolved_ips = resolved_ips;
            self.m_OnResolveCompleted?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxResolveCallback() : base(CfxApi.ResolveCallback.cfx_resolve_callback_ctor) {}

        /// <summary>
        /// Called on the UI thread after the ResolveHost request has completed.
        /// |Result| will be the result code. |ResolvedIps| will be the list of
        /// resolved IP addresses or NULL if the resolution failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public event CfxOnResolveCompletedEventHandler OnResolveCompleted {
            add {
                lock(eventLock) {
                    if(m_OnResolveCompleted == null) {
                        CfxApi.ResolveCallback.cfx_resolve_callback_set_callback(NativePtr, 0, on_resolve_completed_native_ptr);
                    }
                    m_OnResolveCompleted += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResolveCompleted -= value;
                    if(m_OnResolveCompleted == null) {
                        CfxApi.ResolveCallback.cfx_resolve_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResolveCompletedEventHandler m_OnResolveCompleted;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnResolveCompleted != null) {
                m_OnResolveCompleted = null;
                CfxApi.ResolveCallback.cfx_resolve_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the UI thread after the ResolveHost request has completed.
        /// |Result| will be the result code. |ResolvedIps| will be the list of
        /// resolved IP addresses or NULL if the resolution failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResolveCompletedEventHandler(object sender, CfxOnResolveCompletedEventArgs e);

        /// <summary>
        /// Called on the UI thread after the ResolveHost request has completed.
        /// |Result| will be the result code. |ResolvedIps| will be the list of
        /// resolved IP addresses or NULL if the resolution failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public class CfxOnResolveCompletedEventArgs : CfxEventArgs {

            internal int m_result;
            internal IntPtr m_resolved_ips;

            internal CfxOnResolveCompletedEventArgs() {}

            /// <summary>
            /// Get the Result parameter for the <see cref="CfxResolveCallback.OnResolveCompleted"/> callback.
            /// </summary>
            public CfxErrorCode Result {
                get {
                    CheckAccess();
                    return (CfxErrorCode)m_result;
                }
            }
            /// <summary>
            /// Get the ResolvedIps parameter for the <see cref="CfxResolveCallback.OnResolveCompleted"/> callback.
            /// </summary>
            public System.Collections.Generic.List<string> ResolvedIps {
                get {
                    CheckAccess();
                    return StringFunctions.WrapCfxStringList(m_resolved_ips);
                }
            }

            public override string ToString() {
                return String.Format("Result={{{0}}}, ResolvedIps={{{1}}}", Result, ResolvedIps);
            }
        }

    }
}
