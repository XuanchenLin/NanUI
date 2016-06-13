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
	/// Implement this structure to handle events related to browser load status. The
	/// functions of this structure will be called on the browser process UI thread
	/// or render process main thread (TID_RENDERER).
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
	/// </remarks>
	public class CfxLoadHandler : CfxBase {

        static CfxLoadHandler () {
            CfxApiLoader.LoadCfxLoadHandlerApi();
        }

        internal static CfxLoadHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_load_handler_get_gc_handle(nativePtr);
            return (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_loading_state_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_load_handler_on_loading_state_change_delegate(IntPtr gcHandlePtr, IntPtr browser, int isLoading, int canGoBack, int canGoForward);
        private static cfx_load_handler_on_loading_state_change_delegate cfx_load_handler_on_loading_state_change;
        private static IntPtr cfx_load_handler_on_loading_state_change_ptr;

        internal static void on_loading_state_change(IntPtr gcHandlePtr, IntPtr browser, int isLoading, int canGoBack, int canGoForward) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnLoadingStateChangeEventArgs(browser, isLoading, canGoBack, canGoForward);
            var eventHandler = self.m_OnLoadingStateChange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_load_start
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_load_handler_on_load_start_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame);
        private static cfx_load_handler_on_load_start_delegate cfx_load_handler_on_load_start;
        private static IntPtr cfx_load_handler_on_load_start_ptr;

        internal static void on_load_start(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnLoadStartEventArgs(browser, frame);
            var eventHandler = self.m_OnLoadStart;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
        }

        // on_load_end
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_load_handler_on_load_end_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, int httpStatusCode);
        private static cfx_load_handler_on_load_end_delegate cfx_load_handler_on_load_end;
        private static IntPtr cfx_load_handler_on_load_end_ptr;

        internal static void on_load_end(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, int httpStatusCode) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnLoadEndEventArgs(browser, frame, httpStatusCode);
            var eventHandler = self.m_OnLoadEnd;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
        }

        // on_load_error
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_load_handler_on_load_error_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, int errorCode, IntPtr errorText_str, int errorText_length, IntPtr failedUrl_str, int failedUrl_length);
        private static cfx_load_handler_on_load_error_delegate cfx_load_handler_on_load_error;
        private static IntPtr cfx_load_handler_on_load_error_ptr;

        internal static void on_load_error(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, int errorCode, IntPtr errorText_str, int errorText_length, IntPtr failedUrl_str, int failedUrl_length) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnLoadErrorEventArgs(browser, frame, errorCode, errorText_str, errorText_length, failedUrl_str, failedUrl_length);
            var eventHandler = self.m_OnLoadError;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
        }

        internal CfxLoadHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxLoadHandler() : base(CfxApi.cfx_load_handler_ctor) {}

        /// <summary>
        /// Called when the loading state has changed. This callback will be executed
        /// twice -- once when loading is initiated either programmatically or by user
        /// action, and once when loading is terminated due to completion, cancellation
        /// of failure. It will be called before any calls to OnLoadStart and after all
        /// calls to OnLoadError and/or OnLoadEnd.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadingStateChangeEventHandler OnLoadingStateChange {
            add {
                lock(eventLock) {
                    if(m_OnLoadingStateChange == null) {
                        if(cfx_load_handler_on_loading_state_change == null) {
                            cfx_load_handler_on_loading_state_change = on_loading_state_change;
                            cfx_load_handler_on_loading_state_change_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_load_handler_on_loading_state_change);
                        }
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 0, cfx_load_handler_on_loading_state_change_ptr);
                    }
                    m_OnLoadingStateChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadingStateChange -= value;
                    if(m_OnLoadingStateChange == null) {
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadingStateChangeEventHandler m_OnLoadingStateChange;

        /// <summary>
        /// Called when the browser begins loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadStartEventHandler OnLoadStart {
            add {
                lock(eventLock) {
                    if(m_OnLoadStart == null) {
                        if(cfx_load_handler_on_load_start == null) {
                            cfx_load_handler_on_load_start = on_load_start;
                            cfx_load_handler_on_load_start_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_load_handler_on_load_start);
                        }
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 1, cfx_load_handler_on_load_start_ptr);
                    }
                    m_OnLoadStart += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadStart -= value;
                    if(m_OnLoadStart == null) {
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadStartEventHandler m_OnLoadStart;

        /// <summary>
        /// Called when the browser is done loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadEndEventHandler OnLoadEnd {
            add {
                lock(eventLock) {
                    if(m_OnLoadEnd == null) {
                        if(cfx_load_handler_on_load_end == null) {
                            cfx_load_handler_on_load_end = on_load_end;
                            cfx_load_handler_on_load_end_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_load_handler_on_load_end);
                        }
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 2, cfx_load_handler_on_load_end_ptr);
                    }
                    m_OnLoadEnd += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadEnd -= value;
                    if(m_OnLoadEnd == null) {
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadEndEventHandler m_OnLoadEnd;

        /// <summary>
        /// Called when the resource load for a navigation fails or is canceled.
        /// |ErrorCode| is the error code number, |ErrorText| is the error text and
        /// |FailedUrl| is the URL that failed to load. See net\base\net_error_list.h
        /// for complete descriptions of the error codes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadErrorEventHandler OnLoadError {
            add {
                lock(eventLock) {
                    if(m_OnLoadError == null) {
                        if(cfx_load_handler_on_load_error == null) {
                            cfx_load_handler_on_load_error = on_load_error;
                            cfx_load_handler_on_load_error_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_load_handler_on_load_error);
                        }
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 3, cfx_load_handler_on_load_error_ptr);
                    }
                    m_OnLoadError += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadError -= value;
                    if(m_OnLoadError == null) {
                        CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadErrorEventHandler m_OnLoadError;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnLoadingStateChange != null) {
                m_OnLoadingStateChange = null;
                CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnLoadStart != null) {
                m_OnLoadStart = null;
                CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnLoadEnd != null) {
                m_OnLoadEnd = null;
                CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnLoadError != null) {
                m_OnLoadError = null;
                CfxApi.cfx_load_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called when the loading state has changed. This callback will be executed
		/// twice -- once when loading is initiated either programmatically or by user
		/// action, and once when loading is terminated due to completion, cancellation
		/// of failure. It will be called before any calls to OnLoadStart and after all
		/// calls to OnLoadError and/or OnLoadEnd.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxOnLoadingStateChangeEventHandler(object sender, CfxOnLoadingStateChangeEventArgs e);

        /// <summary>
        /// Called when the loading state has changed. This callback will be executed
        /// twice -- once when loading is initiated either programmatically or by user
        /// action, and once when loading is terminated due to completion, cancellation
        /// of failure. It will be called before any calls to OnLoadStart and after all
        /// calls to OnLoadError and/or OnLoadEnd.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnLoadingStateChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_isLoading;
            internal int m_canGoBack;
            internal int m_canGoForward;

            internal CfxOnLoadingStateChangeEventArgs(IntPtr browser, int isLoading, int canGoBack, int canGoForward) {
                m_browser = browser;
                m_isLoading = isLoading;
                m_canGoBack = canGoBack;
                m_canGoForward = canGoForward;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxLoadHandler.OnLoadingStateChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IsLoading parameter for the <see cref="CfxLoadHandler.OnLoadingStateChange"/> callback.
            /// </summary>
            public bool IsLoading {
                get {
                    CheckAccess();
                    return 0 != m_isLoading;
                }
            }
            /// <summary>
            /// Get the CanGoBack parameter for the <see cref="CfxLoadHandler.OnLoadingStateChange"/> callback.
            /// </summary>
            public bool CanGoBack {
                get {
                    CheckAccess();
                    return 0 != m_canGoBack;
                }
            }
            /// <summary>
            /// Get the CanGoForward parameter for the <see cref="CfxLoadHandler.OnLoadingStateChange"/> callback.
            /// </summary>
            public bool CanGoForward {
                get {
                    CheckAccess();
                    return 0 != m_canGoForward;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, IsLoading={{{1}}}, CanGoBack={{{2}}}, CanGoForward={{{3}}}", Browser, IsLoading, CanGoBack, CanGoForward);
            }
        }

        /// <summary>
        /// Called when the browser begins loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadStartEventHandler(object sender, CfxOnLoadStartEventArgs e);

        /// <summary>
        /// Called when the browser begins loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnLoadStartEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;

            internal CfxOnLoadStartEventArgs(IntPtr browser, IntPtr frame) {
                m_browser = browser;
                m_frame = frame;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxLoadHandler.OnLoadStart"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxLoadHandler.OnLoadStart"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}", Browser, Frame);
            }
        }

        /// <summary>
        /// Called when the browser is done loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadEndEventHandler(object sender, CfxOnLoadEndEventArgs e);

        /// <summary>
        /// Called when the browser is done loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will always be called for all frames irrespective of whether the
        /// request completes successfully. For notification of overall browser load
        /// status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnLoadEndEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal int m_httpStatusCode;

            internal CfxOnLoadEndEventArgs(IntPtr browser, IntPtr frame, int httpStatusCode) {
                m_browser = browser;
                m_frame = frame;
                m_httpStatusCode = httpStatusCode;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxLoadHandler.OnLoadEnd"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxLoadHandler.OnLoadEnd"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the HttpStatusCode parameter for the <see cref="CfxLoadHandler.OnLoadEnd"/> callback.
            /// </summary>
            public int HttpStatusCode {
                get {
                    CheckAccess();
                    return m_httpStatusCode;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, HttpStatusCode={{{2}}}", Browser, Frame, HttpStatusCode);
            }
        }

        /// <summary>
        /// Called when the resource load for a navigation fails or is canceled.
        /// |ErrorCode| is the error code number, |ErrorText| is the error text and
        /// |FailedUrl| is the URL that failed to load. See net\base\net_error_list.h
        /// for complete descriptions of the error codes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadErrorEventHandler(object sender, CfxOnLoadErrorEventArgs e);

        /// <summary>
        /// Called when the resource load for a navigation fails or is canceled.
        /// |ErrorCode| is the error code number, |ErrorText| is the error text and
        /// |FailedUrl| is the URL that failed to load. See net\base\net_error_list.h
        /// for complete descriptions of the error codes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnLoadErrorEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal int m_errorCode;
            internal IntPtr m_errorText_str;
            internal int m_errorText_length;
            internal string m_errorText;
            internal IntPtr m_failedUrl_str;
            internal int m_failedUrl_length;
            internal string m_failedUrl;

            internal CfxOnLoadErrorEventArgs(IntPtr browser, IntPtr frame, int errorCode, IntPtr errorText_str, int errorText_length, IntPtr failedUrl_str, int failedUrl_length) {
                m_browser = browser;
                m_frame = frame;
                m_errorCode = errorCode;
                m_errorText_str = errorText_str;
                m_errorText_length = errorText_length;
                m_failedUrl_str = failedUrl_str;
                m_failedUrl_length = failedUrl_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxLoadHandler.OnLoadError"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxLoadHandler.OnLoadError"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the ErrorCode parameter for the <see cref="CfxLoadHandler.OnLoadError"/> callback.
            /// </summary>
            public CfxErrorCode ErrorCode {
                get {
                    CheckAccess();
                    return (CfxErrorCode)m_errorCode;
                }
            }
            /// <summary>
            /// Get the ErrorText parameter for the <see cref="CfxLoadHandler.OnLoadError"/> callback.
            /// </summary>
            public string ErrorText {
                get {
                    CheckAccess();
                    m_errorText = StringFunctions.PtrToStringUni(m_errorText_str, m_errorText_length);
                    return m_errorText;
                }
            }
            /// <summary>
            /// Get the FailedUrl parameter for the <see cref="CfxLoadHandler.OnLoadError"/> callback.
            /// </summary>
            public string FailedUrl {
                get {
                    CheckAccess();
                    m_failedUrl = StringFunctions.PtrToStringUni(m_failedUrl_str, m_failedUrl_length);
                    return m_failedUrl;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, ErrorCode={{{2}}}, ErrorText={{{3}}}, FailedUrl={{{4}}}", Browser, Frame, ErrorCode, ErrorText, FailedUrl);
            }
        }

    }
}
