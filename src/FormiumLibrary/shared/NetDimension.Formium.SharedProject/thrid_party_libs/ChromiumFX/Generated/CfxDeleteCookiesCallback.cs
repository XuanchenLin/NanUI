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
    /// CfxCookieManager.DeleteCookies().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
    /// </remarks>
    public class CfxDeleteCookiesCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_complete_native = on_complete;

            on_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_complete_native);
        }

        // on_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_complete_delegate(IntPtr gcHandlePtr, int num_deleted);
        private static on_complete_delegate on_complete_native;
        private static IntPtr on_complete_native_ptr;

        internal static void on_complete(IntPtr gcHandlePtr, int num_deleted) {
            var self = (CfxDeleteCookiesCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxDeleteCookiesCallbackOnCompleteEventArgs();
            e.m_num_deleted = num_deleted;
            self.m_OnComplete?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxDeleteCookiesCallback() : base(CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_ctor) {}

        /// <summary>
        /// Method that will be called upon completion. |NumDeleted| will be the
        /// number of cookies that were deleted.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public event CfxDeleteCookiesCallbackOnCompleteEventHandler OnComplete {
            add {
                lock(eventLock) {
                    if(m_OnComplete == null) {
                        CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_set_callback(NativePtr, 0, on_complete_native_ptr);
                    }
                    m_OnComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnComplete -= value;
                    if(m_OnComplete == null) {
                        CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxDeleteCookiesCallbackOnCompleteEventHandler m_OnComplete;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnComplete != null) {
                m_OnComplete = null;
                CfxApi.DeleteCookiesCallback.cfx_delete_cookies_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called upon completion. |NumDeleted| will be the
        /// number of cookies that were deleted.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public delegate void CfxDeleteCookiesCallbackOnCompleteEventHandler(object sender, CfxDeleteCookiesCallbackOnCompleteEventArgs e);

        /// <summary>
        /// Method that will be called upon completion. |NumDeleted| will be the
        /// number of cookies that were deleted.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public class CfxDeleteCookiesCallbackOnCompleteEventArgs : CfxEventArgs {

            internal int m_num_deleted;

            internal CfxDeleteCookiesCallbackOnCompleteEventArgs() {}

            /// <summary>
            /// Get the NumDeleted parameter for the <see cref="CfxDeleteCookiesCallback.OnComplete"/> callback.
            /// </summary>
            public int NumDeleted {
                get {
                    CheckAccess();
                    return m_num_deleted;
                }
            }

            public override string ToString() {
                return String.Format("NumDeleted={{{0}}}", NumDeleted);
            }
        }

    }
}
