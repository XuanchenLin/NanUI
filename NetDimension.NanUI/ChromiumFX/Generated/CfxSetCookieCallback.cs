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
    /// Structure to implement to be notified of asynchronous completion via
    /// CfxCookieManager.SetCookie().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
    /// </remarks>
    public class CfxSetCookieCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_complete_native = on_complete;

            on_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_complete_native);
        }

        // on_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_complete_delegate(IntPtr gcHandlePtr, int success);
        private static on_complete_delegate on_complete_native;
        private static IntPtr on_complete_native_ptr;

        internal static void on_complete(IntPtr gcHandlePtr, int success) {
            var self = (CfxSetCookieCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxSetCookieCallbackOnCompleteEventArgs();
            e.m_success = success;
            self.m_OnComplete?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxSetCookieCallback() : base(CfxApi.SetCookieCallback.cfx_set_cookie_callback_ctor) {}

        /// <summary>
        /// Method that will be called upon completion. |Success| will be true (1) if
        /// the cookie was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public event CfxSetCookieCallbackOnCompleteEventHandler OnComplete {
            add {
                lock(eventLock) {
                    if(m_OnComplete == null) {
                        CfxApi.SetCookieCallback.cfx_set_cookie_callback_set_callback(NativePtr, 0, on_complete_native_ptr);
                    }
                    m_OnComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnComplete -= value;
                    if(m_OnComplete == null) {
                        CfxApi.SetCookieCallback.cfx_set_cookie_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSetCookieCallbackOnCompleteEventHandler m_OnComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnComplete != null) {
                m_OnComplete = null;
                CfxApi.SetCookieCallback.cfx_set_cookie_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called upon completion. |Success| will be true (1) if
        /// the cookie was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public delegate void CfxSetCookieCallbackOnCompleteEventHandler(object sender, CfxSetCookieCallbackOnCompleteEventArgs e);

        /// <summary>
        /// Method that will be called upon completion. |Success| will be true (1) if
        /// the cookie was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public class CfxSetCookieCallbackOnCompleteEventArgs : CfxEventArgs {

            internal int m_success;

            internal CfxSetCookieCallbackOnCompleteEventArgs() {}

            /// <summary>
            /// Get the Success parameter for the <see cref="CfxSetCookieCallback.OnComplete"/> callback.
            /// </summary>
            public bool Success {
                get {
                    CheckAccess();
                    return 0 != m_success;
                }
            }

            public override string ToString() {
                return String.Format("Success={{{0}}}", Success);
            }
        }

    }
}
