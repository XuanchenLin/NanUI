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
    /// Implement this structure to filter cookies that may be sent or received from
    /// resource requests. The functions of this structure will be called on the IO
    /// thread unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
    /// </remarks>
    public class CfxCookieAccessFilter : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            can_send_cookie_native = can_send_cookie;
            can_save_cookie_native = can_save_cookie;

            can_send_cookie_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(can_send_cookie_native);
            can_save_cookie_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(can_save_cookie_native);
        }

        // can_send_cookie
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void can_send_cookie_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr cookie);
        private static can_send_cookie_delegate can_send_cookie_native;
        private static IntPtr can_send_cookie_native_ptr;

        internal static void can_send_cookie(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr cookie) {
            var self = (CfxCookieAccessFilter)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxCanSendCookieEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_cookie = cookie;
            self.m_CanSendCookie?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // can_save_cookie
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void can_save_cookie_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, IntPtr cookie);
        private static can_save_cookie_delegate can_save_cookie_native;
        private static IntPtr can_save_cookie_native_ptr;

        internal static void can_save_cookie(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, IntPtr cookie) {
            var self = (CfxCookieAccessFilter)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxCanSaveCookieEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_response = response;
            e.m_cookie = cookie;
            self.m_CanSaveCookie?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxCookieAccessFilter() : base(CfxApi.CookieAccessFilter.cfx_cookie_access_filter_ctor) {}

        /// <summary>
        /// Called on the IO thread before a resource request is sent. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// cannot be modified in this callback. Return true (1) if the specified
        /// cookie can be sent with the request or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxCanSendCookieEventHandler CanSendCookie {
            add {
                lock(eventLock) {
                    if(m_CanSendCookie == null) {
                        CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 0, can_send_cookie_native_ptr);
                    }
                    m_CanSendCookie += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_CanSendCookie -= value;
                    if(m_CanSendCookie == null) {
                        CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxCanSendCookieEventHandler m_CanSendCookie;

        /// <summary>
        /// Called on the IO thread after a resource response is received. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| cannot be modified in this callback. Return true (1) if the
        /// specified cookie returned with the response can be saved or false (0)
        /// otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxCanSaveCookieEventHandler CanSaveCookie {
            add {
                lock(eventLock) {
                    if(m_CanSaveCookie == null) {
                        CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 1, can_save_cookie_native_ptr);
                    }
                    m_CanSaveCookie += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_CanSaveCookie -= value;
                    if(m_CanSaveCookie == null) {
                        CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxCanSaveCookieEventHandler m_CanSaveCookie;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_CanSendCookie != null) {
                m_CanSendCookie = null;
                CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_CanSaveCookie != null) {
                m_CanSaveCookie = null;
                CfxApi.CookieAccessFilter.cfx_cookie_access_filter_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the IO thread before a resource request is sent. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// cannot be modified in this callback. Return true (1) if the specified
        /// cookie can be sent with the request or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxCanSendCookieEventHandler(object sender, CfxCanSendCookieEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource request is sent. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// cannot be modified in this callback. Return true (1) if the specified
        /// cookie can be sent with the request or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxCanSendCookieEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_cookie;
            internal CfxCookie m_cookie_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxCanSendCookieEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxCookieAccessFilter.CanSendCookie"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxCookieAccessFilter.CanSendCookie"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxCookieAccessFilter.CanSendCookie"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Cookie parameter for the <see cref="CfxCookieAccessFilter.CanSendCookie"/> callback.
            /// </summary>
            public CfxCookie Cookie {
                get {
                    CheckAccess();
                    if(m_cookie_wrapped == null) m_cookie_wrapped = CfxCookie.Wrap(m_cookie);
                    return m_cookie_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxCookieAccessFilter.CanSendCookie"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Cookie={{{3}}}", Browser, Frame, Request, Cookie);
            }
        }

        /// <summary>
        /// Called on the IO thread after a resource response is received. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| cannot be modified in this callback. Return true (1) if the
        /// specified cookie returned with the response can be saved or false (0)
        /// otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxCanSaveCookieEventHandler(object sender, CfxCanSaveCookieEventArgs e);

        /// <summary>
        /// Called on the IO thread after a resource response is received. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| cannot be modified in this callback. Return true (1) if the
        /// specified cookie returned with the response can be saved or false (0)
        /// otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxCanSaveCookieEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;
            internal IntPtr m_cookie;
            internal CfxCookie m_cookie_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxCanSaveCookieEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Get the Cookie parameter for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// </summary>
            public CfxCookie Cookie {
                get {
                    CheckAccess();
                    if(m_cookie_wrapped == null) m_cookie_wrapped = CfxCookie.Wrap(m_cookie);
                    return m_cookie_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxCookieAccessFilter.CanSaveCookie"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Response={{{3}}}, Cookie={{{4}}}", Browser, Frame, Request, Response, Cookie);
            }
        }

    }
}
