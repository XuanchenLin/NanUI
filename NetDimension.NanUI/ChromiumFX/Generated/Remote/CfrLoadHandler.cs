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

namespace Chromium.Remote
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
	public class CfrLoadHandler : CfrBase {

        internal static CfrLoadHandler Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrLoadHandler)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrLoadHandler(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxLoadHandlerCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        internal void raise_OnLoadingStateChange(object sender, CfrOnLoadingStateChangeEventArgs e) {
            var handler = m_OnLoadingStateChange;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_OnLoadStart(object sender, CfrOnLoadStartEventArgs e) {
            var handler = m_OnLoadStart;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_OnLoadEnd(object sender, CfrOnLoadEndEventArgs e) {
            var handler = m_OnLoadEnd;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_OnLoadError(object sender, CfrOnLoadErrorEventArgs e) {
            var handler = m_OnLoadError;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }


        private CfrLoadHandler(IntPtr proxyId) : base(proxyId) {}
        public CfrLoadHandler() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
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
                    var call = new CfxOnLoadingStateChangeActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnLoadingStateChange += value;
            }
            remove {
                m_OnLoadingStateChange -= value;
                if(m_OnLoadingStateChange == null) {
                    var call = new CfxOnLoadingStateChangeDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnLoadingStateChangeEventHandler m_OnLoadingStateChange;


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
        public event CfrOnLoadStartEventHandler OnLoadStart {
            add {
                if(m_OnLoadStart == null) {
                    var call = new CfxOnLoadStartActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnLoadStart += value;
            }
            remove {
                m_OnLoadStart -= value;
                if(m_OnLoadStart == null) {
                    var call = new CfxOnLoadStartDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnLoadStartEventHandler m_OnLoadStart;


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
        public event CfrOnLoadEndEventHandler OnLoadEnd {
            add {
                if(m_OnLoadEnd == null) {
                    var call = new CfxOnLoadEndActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnLoadEnd += value;
            }
            remove {
                m_OnLoadEnd -= value;
                if(m_OnLoadEnd == null) {
                    var call = new CfxOnLoadEndDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnLoadEndEventHandler m_OnLoadEnd;


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
        public event CfrOnLoadErrorEventHandler OnLoadError {
            add {
                if(m_OnLoadError == null) {
                    var call = new CfxOnLoadErrorActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnLoadError += value;
            }
            remove {
                m_OnLoadError -= value;
                if(m_OnLoadError == null) {
                    var call = new CfxOnLoadErrorDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnLoadErrorEventHandler m_OnLoadError;


        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
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

            bool BrowserFetched;
            CfrBrowser m_Browser;
            bool IsLoadingFetched;
            bool m_IsLoading;
            bool CanGoBackFetched;
            bool m_CanGoBack;
            bool CanGoForwardFetched;
            bool m_CanGoForward;

            internal CfrOnLoadingStateChangeEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(!BrowserFetched) {
                        BrowserFetched = true;
                        var call = new CfxOnLoadingStateChangeGetBrowserRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Browser = CfrBrowser.Wrap(call.value);
                    }
                    return m_Browser;
                }
            }
            /// <summary>
            /// Get the IsLoading parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool IsLoading {
                get {
                    CheckAccess();
                    if(!IsLoadingFetched) {
                        IsLoadingFetched = true;
                        var call = new CfxOnLoadingStateChangeGetIsLoadingRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_IsLoading = call.value;
                    }
                    return m_IsLoading;
                }
            }
            /// <summary>
            /// Get the CanGoBack parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool CanGoBack {
                get {
                    CheckAccess();
                    if(!CanGoBackFetched) {
                        CanGoBackFetched = true;
                        var call = new CfxOnLoadingStateChangeGetCanGoBackRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_CanGoBack = call.value;
                    }
                    return m_CanGoBack;
                }
            }
            /// <summary>
            /// Get the CanGoForward parameter for the <see cref="CfrLoadHandler.OnLoadingStateChange"/> render process callback.
            /// </summary>
            public bool CanGoForward {
                get {
                    CheckAccess();
                    if(!CanGoForwardFetched) {
                        CanGoForwardFetched = true;
                        var call = new CfxOnLoadingStateChangeGetCanGoForwardRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_CanGoForward = call.value;
                    }
                    return m_CanGoForward;
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
        public delegate void CfrOnLoadStartEventHandler(object sender, CfrOnLoadStartEventArgs e);

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
        public class CfrOnLoadStartEventArgs : CfrEventArgs {

            bool BrowserFetched;
            CfrBrowser m_Browser;
            bool FrameFetched;
            CfrFrame m_Frame;

            internal CfrOnLoadStartEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadStart"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(!BrowserFetched) {
                        BrowserFetched = true;
                        var call = new CfxOnLoadStartGetBrowserRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Browser = CfrBrowser.Wrap(call.value);
                    }
                    return m_Browser;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadStart"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(!FrameFetched) {
                        FrameFetched = true;
                        var call = new CfxOnLoadStartGetFrameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Frame = CfrFrame.Wrap(call.value);
                    }
                    return m_Frame;
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
        public delegate void CfrOnLoadEndEventHandler(object sender, CfrOnLoadEndEventArgs e);

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
        public class CfrOnLoadEndEventArgs : CfrEventArgs {

            bool BrowserFetched;
            CfrBrowser m_Browser;
            bool FrameFetched;
            CfrFrame m_Frame;
            bool HttpStatusCodeFetched;
            int m_HttpStatusCode;

            internal CfrOnLoadEndEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(!BrowserFetched) {
                        BrowserFetched = true;
                        var call = new CfxOnLoadEndGetBrowserRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Browser = CfrBrowser.Wrap(call.value);
                    }
                    return m_Browser;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(!FrameFetched) {
                        FrameFetched = true;
                        var call = new CfxOnLoadEndGetFrameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Frame = CfrFrame.Wrap(call.value);
                    }
                    return m_Frame;
                }
            }
            /// <summary>
            /// Get the HttpStatusCode parameter for the <see cref="CfrLoadHandler.OnLoadEnd"/> render process callback.
            /// </summary>
            public int HttpStatusCode {
                get {
                    CheckAccess();
                    if(!HttpStatusCodeFetched) {
                        HttpStatusCodeFetched = true;
                        var call = new CfxOnLoadEndGetHttpStatusCodeRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_HttpStatusCode = call.value;
                    }
                    return m_HttpStatusCode;
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
        public delegate void CfrOnLoadErrorEventHandler(object sender, CfrOnLoadErrorEventArgs e);

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
        public class CfrOnLoadErrorEventArgs : CfrEventArgs {

            bool BrowserFetched;
            CfrBrowser m_Browser;
            bool FrameFetched;
            CfrFrame m_Frame;
            bool ErrorCodeFetched;
            CfxErrorCode m_ErrorCode;
            bool ErrorTextFetched;
            string m_ErrorText;
            bool FailedUrlFetched;
            string m_FailedUrl;

            internal CfrOnLoadErrorEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(!BrowserFetched) {
                        BrowserFetched = true;
                        var call = new CfxOnLoadErrorGetBrowserRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Browser = CfrBrowser.Wrap(call.value);
                    }
                    return m_Browser;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(!FrameFetched) {
                        FrameFetched = true;
                        var call = new CfxOnLoadErrorGetFrameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Frame = CfrFrame.Wrap(call.value);
                    }
                    return m_Frame;
                }
            }
            /// <summary>
            /// Get the ErrorCode parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public CfxErrorCode ErrorCode {
                get {
                    CheckAccess();
                    if(!ErrorCodeFetched) {
                        ErrorCodeFetched = true;
                        var call = new CfxOnLoadErrorGetErrorCodeRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_ErrorCode = (CfxErrorCode)call.value;
                    }
                    return m_ErrorCode;
                }
            }
            /// <summary>
            /// Get the ErrorText parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public string ErrorText {
                get {
                    CheckAccess();
                    if(!ErrorTextFetched) {
                        ErrorTextFetched = true;
                        var call = new CfxOnLoadErrorGetErrorTextRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_ErrorText = call.value;
                    }
                    return m_ErrorText;
                }
            }
            /// <summary>
            /// Get the FailedUrl parameter for the <see cref="CfrLoadHandler.OnLoadError"/> render process callback.
            /// </summary>
            public string FailedUrl {
                get {
                    CheckAccess();
                    if(!FailedUrlFetched) {
                        FailedUrlFetched = true;
                        var call = new CfxOnLoadErrorGetFailedUrlRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_FailedUrl = call.value;
                    }
                    return m_FailedUrl;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, ErrorCode={{{2}}}, ErrorText={{{3}}}, FailedUrl={{{4}}}", Browser, Frame, ErrorCode, ErrorText, FailedUrl);
            }
        }

    }
}
