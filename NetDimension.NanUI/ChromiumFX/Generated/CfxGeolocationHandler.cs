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
	/// Implement this structure to handle events related to geolocation permission
	/// requests. The functions of this structure will be called on the browser
	/// process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
	/// </remarks>
	public class CfxGeolocationHandler : CfxBase {

        static CfxGeolocationHandler () {
            CfxApiLoader.LoadCfxGeolocationHandlerApi();
        }

        internal static CfxGeolocationHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_geolocation_handler_get_gc_handle(nativePtr);
            return (CfxGeolocationHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_request_geolocation_permission
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_geolocation_handler_on_request_geolocation_permission_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr requesting_url_str, int requesting_url_length, int request_id, IntPtr callback);
        private static cfx_geolocation_handler_on_request_geolocation_permission_delegate cfx_geolocation_handler_on_request_geolocation_permission;
        private static IntPtr cfx_geolocation_handler_on_request_geolocation_permission_ptr;

        internal static void on_request_geolocation_permission(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr requesting_url_str, int requesting_url_length, int request_id, IntPtr callback) {
            var self = (CfxGeolocationHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnRequestGeolocationPermissionEventArgs(browser, requesting_url_str, requesting_url_length, request_id, callback);
            var eventHandler = self.m_OnRequestGeolocationPermission;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_cancel_geolocation_permission
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_geolocation_handler_on_cancel_geolocation_permission_delegate(IntPtr gcHandlePtr, IntPtr browser, int request_id);
        private static cfx_geolocation_handler_on_cancel_geolocation_permission_delegate cfx_geolocation_handler_on_cancel_geolocation_permission;
        private static IntPtr cfx_geolocation_handler_on_cancel_geolocation_permission_ptr;

        internal static void on_cancel_geolocation_permission(IntPtr gcHandlePtr, IntPtr browser, int request_id) {
            var self = (CfxGeolocationHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnCancelGeolocationPermissionEventArgs(browser, request_id);
            var eventHandler = self.m_OnCancelGeolocationPermission;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        internal CfxGeolocationHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxGeolocationHandler() : base(CfxApi.cfx_geolocation_handler_ctor) {}

        /// <summary>
        /// Called when a page requests permission to access geolocation information.
        /// |RequestingUrl| is the URL requesting permission and |RequestId| is the
        /// unique ID for the permission request. Return true (1) and call
        /// CfxGeolocationCallback.Continue() either in this function or at a later
        /// time to continue or cancel the request. Return false (0) to cancel the
        /// request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRequestGeolocationPermissionEventHandler OnRequestGeolocationPermission {
            add {
                lock(eventLock) {
                    if(m_OnRequestGeolocationPermission == null) {
                        if(cfx_geolocation_handler_on_request_geolocation_permission == null) {
                            cfx_geolocation_handler_on_request_geolocation_permission = on_request_geolocation_permission;
                            cfx_geolocation_handler_on_request_geolocation_permission_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_geolocation_handler_on_request_geolocation_permission);
                        }
                        CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 0, cfx_geolocation_handler_on_request_geolocation_permission_ptr);
                    }
                    m_OnRequestGeolocationPermission += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRequestGeolocationPermission -= value;
                    if(m_OnRequestGeolocationPermission == null) {
                        CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRequestGeolocationPermissionEventHandler m_OnRequestGeolocationPermission;

        /// <summary>
        /// Called when a geolocation access request is canceled. |RequestId| is the
        /// unique ID for the permission request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnCancelGeolocationPermissionEventHandler OnCancelGeolocationPermission {
            add {
                lock(eventLock) {
                    if(m_OnCancelGeolocationPermission == null) {
                        if(cfx_geolocation_handler_on_cancel_geolocation_permission == null) {
                            cfx_geolocation_handler_on_cancel_geolocation_permission = on_cancel_geolocation_permission;
                            cfx_geolocation_handler_on_cancel_geolocation_permission_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_geolocation_handler_on_cancel_geolocation_permission);
                        }
                        CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 1, cfx_geolocation_handler_on_cancel_geolocation_permission_ptr);
                    }
                    m_OnCancelGeolocationPermission += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCancelGeolocationPermission -= value;
                    if(m_OnCancelGeolocationPermission == null) {
                        CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnCancelGeolocationPermissionEventHandler m_OnCancelGeolocationPermission;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRequestGeolocationPermission != null) {
                m_OnRequestGeolocationPermission = null;
                CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnCancelGeolocationPermission != null) {
                m_OnCancelGeolocationPermission = null;
                CfxApi.cfx_geolocation_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called when a page requests permission to access geolocation information.
		/// |RequestingUrl| is the URL requesting permission and |RequestId| is the
		/// unique ID for the permission request. Return true (1) and call
		/// CfxGeolocationCallback.Continue() either in this function or at a later
		/// time to continue or cancel the request. Return false (0) to cancel the
		/// request immediately.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxOnRequestGeolocationPermissionEventHandler(object sender, CfxOnRequestGeolocationPermissionEventArgs e);

        /// <summary>
        /// Called when a page requests permission to access geolocation information.
        /// |RequestingUrl| is the URL requesting permission and |RequestId| is the
        /// unique ID for the permission request. Return true (1) and call
        /// CfxGeolocationCallback.Continue() either in this function or at a later
        /// time to continue or cancel the request. Return false (0) to cancel the
        /// request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRequestGeolocationPermissionEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_requesting_url_str;
            internal int m_requesting_url_length;
            internal string m_requesting_url;
            internal int m_request_id;
            internal IntPtr m_callback;
            internal CfxGeolocationCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnRequestGeolocationPermissionEventArgs(IntPtr browser, IntPtr requesting_url_str, int requesting_url_length, int request_id, IntPtr callback) {
                m_browser = browser;
                m_requesting_url_str = requesting_url_str;
                m_requesting_url_length = requesting_url_length;
                m_request_id = request_id;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxGeolocationHandler.OnRequestGeolocationPermission"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the RequestingUrl parameter for the <see cref="CfxGeolocationHandler.OnRequestGeolocationPermission"/> callback.
            /// </summary>
            public string RequestingUrl {
                get {
                    CheckAccess();
                    m_requesting_url = StringFunctions.PtrToStringUni(m_requesting_url_str, m_requesting_url_length);
                    return m_requesting_url;
                }
            }
            /// <summary>
            /// Get the RequestId parameter for the <see cref="CfxGeolocationHandler.OnRequestGeolocationPermission"/> callback.
            /// </summary>
            public int RequestId {
                get {
                    CheckAccess();
                    return m_request_id;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxGeolocationHandler.OnRequestGeolocationPermission"/> callback.
            /// </summary>
            public CfxGeolocationCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxGeolocationCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxGeolocationHandler.OnRequestGeolocationPermission"/> callback.
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
                return String.Format("Browser={{{0}}}, RequestingUrl={{{1}}}, RequestId={{{2}}}, Callback={{{3}}}", Browser, RequestingUrl, RequestId, Callback);
            }
        }

        /// <summary>
        /// Called when a geolocation access request is canceled. |RequestId| is the
        /// unique ID for the permission request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnCancelGeolocationPermissionEventHandler(object sender, CfxOnCancelGeolocationPermissionEventArgs e);

        /// <summary>
        /// Called when a geolocation access request is canceled. |RequestId| is the
        /// unique ID for the permission request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_geolocation_handler_capi.h">cef/include/capi/cef_geolocation_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnCancelGeolocationPermissionEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_request_id;

            internal CfxOnCancelGeolocationPermissionEventArgs(IntPtr browser, int request_id) {
                m_browser = browser;
                m_request_id = request_id;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxGeolocationHandler.OnCancelGeolocationPermission"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the RequestId parameter for the <see cref="CfxGeolocationHandler.OnCancelGeolocationPermission"/> callback.
            /// </summary>
            public int RequestId {
                get {
                    CheckAccess();
                    return m_request_id;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, RequestId={{{1}}}", Browser, RequestId);
            }
        }

    }
}
