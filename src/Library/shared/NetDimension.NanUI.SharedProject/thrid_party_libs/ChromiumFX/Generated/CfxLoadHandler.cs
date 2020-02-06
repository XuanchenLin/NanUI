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
    /// Implement this structure to handle events related to browser load status. The
    /// functions of this structure will be called on the browser process UI thread
    /// or render process main thread (TID_RENDERER).
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
    /// </remarks>
    public class CfxLoadHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_loading_state_change_native = on_loading_state_change;
            on_load_start_native = on_load_start;
            on_load_end_native = on_load_end;
            on_load_error_native = on_load_error;

            on_loading_state_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_loading_state_change_native);
            on_load_start_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_load_start_native);
            on_load_end_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_load_end_native);
            on_load_error_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_load_error_native);
        }

        // on_loading_state_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_loading_state_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int isLoading, int canGoBack, int canGoForward);
        private static on_loading_state_change_delegate on_loading_state_change_native;
        private static IntPtr on_loading_state_change_native_ptr;

        internal static void on_loading_state_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int isLoading, int canGoBack, int canGoForward) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnLoadingStateChangeEventArgs();
            e.m_browser = browser;
            e.m_isLoading = isLoading;
            e.m_canGoBack = canGoBack;
            e.m_canGoForward = canGoForward;
            self.m_OnLoadingStateChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_load_start
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_load_start_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int transition_type);
        private static on_load_start_delegate on_load_start_native;
        private static IntPtr on_load_start_native_ptr;

        internal static void on_load_start(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int transition_type) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnLoadStartEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_transition_type = transition_type;
            self.m_OnLoadStart?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }

        // on_load_end
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_load_end_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int httpStatusCode);
        private static on_load_end_delegate on_load_end_native;
        private static IntPtr on_load_end_native_ptr;

        internal static void on_load_end(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int httpStatusCode) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnLoadEndEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_httpStatusCode = httpStatusCode;
            self.m_OnLoadEnd?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }

        // on_load_error
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_load_error_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int errorCode, IntPtr errorText_str, int errorText_length, IntPtr failedUrl_str, int failedUrl_length);
        private static on_load_error_delegate on_load_error_native;
        private static IntPtr on_load_error_native_ptr;

        internal static void on_load_error(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int errorCode, IntPtr errorText_str, int errorText_length, IntPtr failedUrl_str, int failedUrl_length) {
            var self = (CfxLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnLoadErrorEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_errorCode = errorCode;
            e.m_errorText_str = errorText_str;
            e.m_errorText_length = errorText_length;
            e.m_failedUrl_str = failedUrl_str;
            e.m_failedUrl_length = failedUrl_length;
            self.m_OnLoadError?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }

        public CfxLoadHandler() : base(CfxApi.LoadHandler.cfx_load_handler_ctor) {}

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
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 0, on_loading_state_change_native_ptr);
                    }
                    m_OnLoadingStateChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadingStateChange -= value;
                    if(m_OnLoadingStateChange == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadingStateChangeEventHandler m_OnLoadingStateChange;

        /// <summary>
        /// Called after a navigation has been committed and before the browser begins
        /// loading contents in the frame. The |Frame| value will never be NULL -- call
        /// the is_main() function to check if this frame is the main frame.
        /// |TransitionType| provides information about the source of the navigation
        /// and an accurate value is only available in the browser process. Multiple
        /// frames may be loading at the same time. Sub-frames may start or continue
        /// loading after the main frame load has ended. This function will not be
        /// called for same page navigations (fragments, history state, etc.) or for
        /// navigations that fail or are canceled before commit. For notification of
        /// overall browser load status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadStartEventHandler OnLoadStart {
            add {
                lock(eventLock) {
                    if(m_OnLoadStart == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 1, on_load_start_native_ptr);
                    }
                    m_OnLoadStart += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadStart -= value;
                    if(m_OnLoadStart == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 1, IntPtr.Zero);
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
        /// function will not be called for same page navigations (fragments, history
        /// state, etc.) or for navigations that fail or are canceled before commit.
        /// For notification of overall browser load status use OnLoadingStateChange
        /// instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadEndEventHandler OnLoadEnd {
            add {
                lock(eventLock) {
                    if(m_OnLoadEnd == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 2, on_load_end_native_ptr);
                    }
                    m_OnLoadEnd += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadEnd -= value;
                    if(m_OnLoadEnd == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadEndEventHandler m_OnLoadEnd;

        /// <summary>
        /// Called when a navigation fails or is canceled. This function may be called
        /// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
        /// after commit. |ErrorCode| is the error code number, |ErrorText| is the
        /// error text and |FailedUrl| is the URL that failed to load. See
        /// net\base\net_error_list.h for complete descriptions of the error codes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadErrorEventHandler OnLoadError {
            add {
                lock(eventLock) {
                    if(m_OnLoadError == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 3, on_load_error_native_ptr);
                    }
                    m_OnLoadError += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadError -= value;
                    if(m_OnLoadError == null) {
                        CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadErrorEventHandler m_OnLoadError;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnLoadingStateChange != null) {
                m_OnLoadingStateChange = null;
                CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnLoadStart != null) {
                m_OnLoadStart = null;
                CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnLoadEnd != null) {
                m_OnLoadEnd = null;
                CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnLoadError != null) {
                m_OnLoadError = null;
                CfxApi.LoadHandler.cfx_load_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

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

            internal CfxOnLoadingStateChangeEventArgs() {}

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
        /// Called after a navigation has been committed and before the browser begins
        /// loading contents in the frame. The |Frame| value will never be NULL -- call
        /// the is_main() function to check if this frame is the main frame.
        /// |TransitionType| provides information about the source of the navigation
        /// and an accurate value is only available in the browser process. Multiple
        /// frames may be loading at the same time. Sub-frames may start or continue
        /// loading after the main frame load has ended. This function will not be
        /// called for same page navigations (fragments, history state, etc.) or for
        /// navigations that fail or are canceled before commit. For notification of
        /// overall browser load status use OnLoadingStateChange instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadStartEventHandler(object sender, CfxOnLoadStartEventArgs e);

        /// <summary>
        /// Called after a navigation has been committed and before the browser begins
        /// loading contents in the frame. The |Frame| value will never be NULL -- call
        /// the is_main() function to check if this frame is the main frame.
        /// |TransitionType| provides information about the source of the navigation
        /// and an accurate value is only available in the browser process. Multiple
        /// frames may be loading at the same time. Sub-frames may start or continue
        /// loading after the main frame load has ended. This function will not be
        /// called for same page navigations (fragments, history state, etc.) or for
        /// navigations that fail or are canceled before commit. For notification of
        /// overall browser load status use OnLoadingStateChange instead.
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
            internal int m_transition_type;

            internal CfxOnLoadStartEventArgs() {}

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
            /// <summary>
            /// Get the TransitionType parameter for the <see cref="CfxLoadHandler.OnLoadStart"/> callback.
            /// </summary>
            public CfxTransitionType TransitionType {
                get {
                    CheckAccess();
                    return (CfxTransitionType)m_transition_type;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, TransitionType={{{2}}}", Browser, Frame, TransitionType);
            }
        }

        /// <summary>
        /// Called when the browser is done loading a frame. The |Frame| value will
        /// never be NULL -- call the is_main() function to check if this frame is the
        /// main frame. Multiple frames may be loading at the same time. Sub-frames may
        /// start or continue loading after the main frame load has ended. This
        /// function will not be called for same page navigations (fragments, history
        /// state, etc.) or for navigations that fail or are canceled before commit.
        /// For notification of overall browser load status use OnLoadingStateChange
        /// instead.
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
        /// function will not be called for same page navigations (fragments, history
        /// state, etc.) or for navigations that fail or are canceled before commit.
        /// For notification of overall browser load status use OnLoadingStateChange
        /// instead.
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

            internal CfxOnLoadEndEventArgs() {}

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
        /// Called when a navigation fails or is canceled. This function may be called
        /// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
        /// after commit. |ErrorCode| is the error code number, |ErrorText| is the
        /// error text and |FailedUrl| is the URL that failed to load. See
        /// net\base\net_error_list.h for complete descriptions of the error codes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_load_handler_capi.h">cef/include/capi/cef_load_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadErrorEventHandler(object sender, CfxOnLoadErrorEventArgs e);

        /// <summary>
        /// Called when a navigation fails or is canceled. This function may be called
        /// by itself if before commit or in combination with OnLoadStart/OnLoadEnd if
        /// after commit. |ErrorCode| is the error code number, |ErrorText| is the
        /// error text and |FailedUrl| is the URL that failed to load. See
        /// net\base\net_error_list.h for complete descriptions of the error codes.
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

            internal CfxOnLoadErrorEventArgs() {}

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
