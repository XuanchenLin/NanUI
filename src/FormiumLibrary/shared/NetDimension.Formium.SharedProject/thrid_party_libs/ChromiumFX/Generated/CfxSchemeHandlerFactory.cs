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
    /// Structure that creates CfxResourceHandler instances for handling scheme
    /// requests. The functions of this structure will always be called on the IO
    /// thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
    /// </remarks>
    public class CfxSchemeHandlerFactory : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            create_native = create;

            create_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(create_native);
        }

        // create
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void create_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr scheme_name_str, int scheme_name_length, IntPtr request, out int request_release);
        private static create_delegate create_native;
        private static IntPtr create_native_ptr;

        internal static void create(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr scheme_name_str, int scheme_name_length, IntPtr request, out int request_release) {
            var self = (CfxSchemeHandlerFactory)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxCreateEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_scheme_name_str = scheme_name_str;
            e.m_scheme_name_length = scheme_name_length;
            e.m_request = request;
            self.m_Create?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            __retval = CfxResourceHandler.Unwrap(e.m_returnValue);
        }

        public CfxSchemeHandlerFactory() : base(CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_ctor) {}

        /// <summary>
        /// Return a new resource handler instance to handle the request or an NULL
        /// reference to allow default handling of the request. |Browser| and |Frame|
        /// will be the browser window and frame respectively that originated the
        /// request or NULL if the request did not originate from a browser window (for
        /// example, if the request came from CfxUrlRequest). The |Request| object
        /// passed to this function cannot be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public event CfxCreateEventHandler Create {
            add {
                lock(eventLock) {
                    if(m_Create == null) {
                        CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_set_callback(NativePtr, 0, create_native_ptr);
                    }
                    m_Create += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Create -= value;
                    if(m_Create == null) {
                        CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxCreateEventHandler m_Create;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Create != null) {
                m_Create = null;
                CfxApi.SchemeHandlerFactory.cfx_scheme_handler_factory_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Return a new resource handler instance to handle the request or an NULL
        /// reference to allow default handling of the request. |Browser| and |Frame|
        /// will be the browser window and frame respectively that originated the
        /// request or NULL if the request did not originate from a browser window (for
        /// example, if the request came from CfxUrlRequest). The |Request| object
        /// passed to this function cannot be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public delegate void CfxCreateEventHandler(object sender, CfxCreateEventArgs e);

        /// <summary>
        /// Return a new resource handler instance to handle the request or an NULL
        /// reference to allow default handling of the request. |Browser| and |Frame|
        /// will be the browser window and frame respectively that originated the
        /// request or NULL if the request did not originate from a browser window (for
        /// example, if the request came from CfxUrlRequest). The |Request| object
        /// passed to this function cannot be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public class CfxCreateEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_scheme_name_str;
            internal int m_scheme_name_length;
            internal string m_scheme_name;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;

            internal CfxResourceHandler m_returnValue;
            private bool returnValueSet;

            internal CfxCreateEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxSchemeHandlerFactory.Create"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxSchemeHandlerFactory.Create"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the SchemeName parameter for the <see cref="CfxSchemeHandlerFactory.Create"/> callback.
            /// </summary>
            public string SchemeName {
                get {
                    CheckAccess();
                    m_scheme_name = StringFunctions.PtrToStringUni(m_scheme_name_str, m_scheme_name_length);
                    return m_scheme_name;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxSchemeHandlerFactory.Create"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxSchemeHandlerFactory.Create"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxResourceHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, SchemeName={{{2}}}, Request={{{3}}}", Browser, Frame, SchemeName, Request);
            }
        }

    }
}
