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
	/// Structure that creates CfxResourceHandler instances for handling scheme
	/// requests. The functions of this structure will always be called on the IO
	/// thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
	/// </remarks>
	public class CfxSchemeHandlerFactory : CfxBase {

        static CfxSchemeHandlerFactory () {
            CfxApiLoader.LoadCfxSchemeHandlerFactoryApi();
        }

        internal static CfxSchemeHandlerFactory Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_scheme_handler_factory_get_gc_handle(nativePtr);
            return (CfxSchemeHandlerFactory)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // create
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_scheme_handler_factory_create_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, IntPtr frame, IntPtr scheme_name_str, int scheme_name_length, IntPtr request);
        private static cfx_scheme_handler_factory_create_delegate cfx_scheme_handler_factory_create;
        private static IntPtr cfx_scheme_handler_factory_create_ptr;

        internal static void create(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, IntPtr frame, IntPtr scheme_name_str, int scheme_name_length, IntPtr request) {
            var self = (CfxSchemeHandlerFactory)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || browser == IntPtr.Zero) {
				//TOD:这里为什么会为空？
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxSchemeHandlerFactoryCreateEventArgs(browser, frame, scheme_name_str, scheme_name_length, request);
            var eventHandler = self.m_Create;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
            __retval = CfxResourceHandler.Unwrap(e.m_returnValue);
        }

        internal CfxSchemeHandlerFactory(IntPtr nativePtr) : base(nativePtr) {}
        public CfxSchemeHandlerFactory() : base(CfxApi.cfx_scheme_handler_factory_ctor) {}

        /// <summary>
        /// Return a new resource handler instance to handle the request or an NULL
        /// reference to allow default handling of the request. |Browser| and |Frame|
        /// will be the browser window and frame respectively that originated the
        /// request or NULL if the request did not originate from a browser window (for
        /// example, if the request came from CfxUrlRequest). The |Request| object
        /// passed to this function will not contain cookie data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public event CfxSchemeHandlerFactoryCreateEventHandler Create {
            add {
                lock(eventLock) {
                    if(m_Create == null) {
                        if(cfx_scheme_handler_factory_create == null) {
                            cfx_scheme_handler_factory_create = create;
                            cfx_scheme_handler_factory_create_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_scheme_handler_factory_create);
                        }
                        CfxApi.cfx_scheme_handler_factory_set_managed_callback(NativePtr, 0, cfx_scheme_handler_factory_create_ptr);
                    }
                    m_Create += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Create -= value;
                    if(m_Create == null) {
                        CfxApi.cfx_scheme_handler_factory_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSchemeHandlerFactoryCreateEventHandler m_Create;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Create != null) {
                m_Create = null;
                CfxApi.cfx_scheme_handler_factory_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Return a new resource handler instance to handle the request or an NULL
		/// reference to allow default handling of the request. |Browser| and |Frame|
		/// will be the browser window and frame respectively that originated the
		/// request or NULL if the request did not originate from a browser window (for
		/// example, if the request came from CfxUrlRequest). The |Request| object
		/// passed to this function will not contain cookie data.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
		/// </remarks>
		public delegate void CfxSchemeHandlerFactoryCreateEventHandler(object sender, CfxSchemeHandlerFactoryCreateEventArgs e);

        /// <summary>
        /// Return a new resource handler instance to handle the request or an NULL
        /// reference to allow default handling of the request. |Browser| and |Frame|
        /// will be the browser window and frame respectively that originated the
        /// request or NULL if the request did not originate from a browser window (for
        /// example, if the request came from CfxUrlRequest). The |Request| object
        /// passed to this function will not contain cookie data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public class CfxSchemeHandlerFactoryCreateEventArgs : CfxEventArgs {

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

            internal CfxSchemeHandlerFactoryCreateEventArgs(IntPtr browser, IntPtr frame, IntPtr scheme_name_str, int scheme_name_length, IntPtr request) {
                m_browser = browser;
                m_frame = frame;
                m_scheme_name_str = scheme_name_str;
                m_scheme_name_length = scheme_name_length;
                m_request = request;
            }

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
