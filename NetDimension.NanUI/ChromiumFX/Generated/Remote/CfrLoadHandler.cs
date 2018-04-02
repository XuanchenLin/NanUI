// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
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
    public class CfrLoadHandler : CfrBaseClient {


        private CfrLoadHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrLoadHandler() : base(new CfxLoadHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

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
        public event CfrOnLoadingStateChangeEventHandler OnLoadingStateChange {
            add {
                if(m_OnLoadingStateChange == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnLoadingStateChange += value;
            }
            remove {
                m_OnLoadingStateChange -= value;
                if(m_OnLoadingStateChange == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnLoadingStateChangeEventHandler m_OnLoadingStateChange;


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
        public event CfrOnLoadStartEventHandler OnLoadStart {
            add {
                if(m_OnLoadStart == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnLoadStart += value;
            }
            remove {
                m_OnLoadStart -= value;
                if(m_OnLoadStart == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnLoadStartEventHandler m_OnLoadStart;


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
        public event CfrOnLoadEndEventHandler OnLoadEnd {
            add {
                if(m_OnLoadEnd == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnLoadEnd += value;
            }
            remove {
                m_OnLoadEnd -= value;
                if(m_OnLoadEnd == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnLoadEndEventHandler m_OnLoadEnd;


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
        public event CfrOnLoadErrorEventHandler OnLoadError {
            add {
                if(m_OnLoadError == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnLoadError += value;
            }
            remove {
                m_OnLoadError -= value;
                if(m_OnLoadError == null) {
                    var call = new CfxLoadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnLoadErrorEventHandler m_OnLoadError;


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
        public delegate void CfrOnLoadingStateChangeEventHandler(object sender, CfrOnLoadingStateChangeEventArgs e);

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
        public class CfrOnLoadingStateChangeEventArgs : CfrEventArgs {

            private CfxLoadHandlerOnLoadingStateChangeRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;

            internal CfrOnLoadingStateChangeEventArgs(CfxLoadHandlerOnLoadingStateChangeRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IsLoading parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool IsLoading {
                get {
                    CheckAccess();
                    return 0 != call.isLoading;
                }
            }
            /// <summary>
            /// Get the CanGoBack parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool CanGoBack {
                get {
                    CheckAccess();
                    return 0 != call.canGoBack;
                }
            }
            /// <summary>
            /// Get the CanGoForward parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool CanGoForward {
                get {
                    CheckAccess();
                    return 0 != call.canGoForward;
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
        public delegate void CfrOnLoadStartEventHandler(object sender, CfrOnLoadStartEventArgs e);

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
        public class CfrOnLoadStartEventArgs : CfrEventArgs {

            private CfxLoadHandlerOnLoadStartRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;

            internal CfrOnLoadStartEventArgs(CfxLoadHandlerOnLoadStartRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadStart"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadStart"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the TransitionType parameter for the <see cref="CfrLoadHandler.OnLoadStart"/> render process callback.
            /// </summary>
            public CfxTransitionType TransitionType {
                get {
                    CheckAccess();
                    return (CfxTransitionType)call.transition_type;
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
        public delegate void CfrOnLoadEndEventHandler(object sender, CfrOnLoadEndEventArgs e);

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
        public class CfrOnLoadEndEventArgs : CfrEventArgs {

            private CfxLoadHandlerOnLoadEndRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;

            internal CfrOnLoadEndEventArgs(CfxLoadHandlerOnLoadEndRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the HttpStatusCode parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public int HttpStatusCode {
                get {
                    CheckAccess();
                    return call.httpStatusCode;
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
        public delegate void CfrOnLoadErrorEventHandler(object sender, CfrOnLoadErrorEventArgs e);

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
        public class CfrOnLoadErrorEventArgs : CfrEventArgs {

            private CfxLoadHandlerOnLoadErrorRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal string m_errorText;
            internal bool m_errorText_fetched;
            internal string m_failedUrl;
            internal bool m_failedUrl_fetched;

            internal CfrOnLoadErrorEventArgs(CfxLoadHandlerOnLoadErrorRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the ErrorCode parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfxErrorCode ErrorCode {
                get {
                    CheckAccess();
                    return (CfxErrorCode)call.errorCode;
                }
            }
            /// <summary>
            /// Get the ErrorText parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public string ErrorText {
                get {
                    CheckAccess();
                    if(!m_errorText_fetched) {
                        m_errorText = call.errorText_str == IntPtr.Zero ? null : (call.errorText_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.errorText_str), call.errorText_length));
                        m_errorText_fetched = true;
                    }
                    return m_errorText;
                }
            }
            /// <summary>
            /// Get the FailedUrl parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public string FailedUrl {
                get {
                    CheckAccess();
                    if(!m_failedUrl_fetched) {
                        m_failedUrl = call.failedUrl_str == IntPtr.Zero ? null : (call.failedUrl_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.failedUrl_str), call.failedUrl_length));
                        m_failedUrl_fetched = true;
                    }
                    return m_failedUrl;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, ErrorCode={{{2}}}, ErrorText={{{3}}}, FailedUrl={{{4}}}", Browser, Frame, ErrorCode, ErrorText, FailedUrl);
            }
        }

    }
}
