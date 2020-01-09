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
    /// Structure that should be implemented by the CfrUrlRequest client. The
    /// functions of this structure will be called on the same thread that created
    /// the request unless otherwise documented.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
    /// </remarks>
    public class CfrUrlRequestClient : CfrBaseClient {

        internal static CfrUrlRequestClient Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var call = new CfxUrlRequestClientGetGcHandleRemoteCall();
            call.self = remotePtr.ptr;
            call.RequestExecution(remotePtr.connection);
            return (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(call.gc_handle).Target;
        }



        private CfrUrlRequestClient(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrUrlRequestClient() : base(new CfxUrlRequestClientCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfrUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfrOnRequestCompleteEventHandler OnRequestComplete {
            add {
                if(m_OnRequestComplete == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnRequestComplete += value;
            }
            remove {
                m_OnRequestComplete -= value;
                if(m_OnRequestComplete == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnRequestCompleteEventHandler m_OnRequestComplete;


        /// <summary>
        /// Notifies the client of upload progress. |Current| denotes the number of
        /// bytes sent so far and |Total| is the total size of uploading data (or -1 if
        /// chunked upload is enabled). This function will only be called if the
        /// UR_FLAG_REPORT_UPLOAD_PROGRESS flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfrOnUploadProgressEventHandler OnUploadProgress {
            add {
                if(m_OnUploadProgress == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnUploadProgress += value;
            }
            remove {
                m_OnUploadProgress -= value;
                if(m_OnUploadProgress == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnUploadProgressEventHandler m_OnUploadProgress;


        /// <summary>
        /// Notifies the client of download progress. |Current| denotes the number of
        /// bytes received up to the call and |Total| is the expected total size of the
        /// response (or -1 if not determined).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfrOnDownloadProgressEventHandler OnDownloadProgress {
            add {
                if(m_OnDownloadProgress == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnDownloadProgress += value;
            }
            remove {
                m_OnDownloadProgress -= value;
                if(m_OnDownloadProgress == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnDownloadProgressEventHandler m_OnDownloadProgress;


        /// <summary>
        /// Called when some part of the response is read. |Data| contains the current
        /// bytes received since the last call. This function will not be called if the
        /// UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfrOnDownloadDataEventHandler OnDownloadData {
            add {
                if(m_OnDownloadData == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnDownloadData += value;
            }
            remove {
                m_OnDownloadData -= value;
                if(m_OnDownloadData == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnDownloadDataEventHandler m_OnDownloadData;


        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. Return true (1) to continue
        /// the request and call CfrAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfrRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfrUrlRequestClientGetAuthCredentialsEventHandler GetAuthCredentials {
            add {
                if(m_GetAuthCredentials == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetAuthCredentials += value;
            }
            remove {
                m_GetAuthCredentials -= value;
                if(m_GetAuthCredentials == null) {
                    var call = new CfxUrlRequestClientSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrUrlRequestClientGetAuthCredentialsEventHandler m_GetAuthCredentials;


    }

    namespace Event {

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfrUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnRequestCompleteEventHandler(object sender, CfrOnRequestCompleteEventArgs e);

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfrUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfrOnRequestCompleteEventArgs : CfrEventArgs {

            private CfxUrlRequestClientOnRequestCompleteRemoteEventCall call;

            internal CfrUrlRequest m_request_wrapped;

            internal CfrOnRequestCompleteEventArgs(CfxUrlRequestClientOnRequestCompleteRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Request parameter for the <see cref="CfrUrlRequestClient.OnRequestComplete"/> render process callback.
            /// </summary>
            public CfrUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrUrlRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Request={{{0}}}", Request);
            }
        }

        /// <summary>
        /// Notifies the client of upload progress. |Current| denotes the number of
        /// bytes sent so far and |Total| is the total size of uploading data (or -1 if
        /// chunked upload is enabled). This function will only be called if the
        /// UR_FLAG_REPORT_UPLOAD_PROGRESS flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnUploadProgressEventHandler(object sender, CfrOnUploadProgressEventArgs e);

        /// <summary>
        /// Notifies the client of upload progress. |Current| denotes the number of
        /// bytes sent so far and |Total| is the total size of uploading data (or -1 if
        /// chunked upload is enabled). This function will only be called if the
        /// UR_FLAG_REPORT_UPLOAD_PROGRESS flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfrOnUploadProgressEventArgs : CfrEventArgs {

            private CfxUrlRequestClientOnUploadProgressRemoteEventCall call;

            internal CfrUrlRequest m_request_wrapped;

            internal CfrOnUploadProgressEventArgs(CfxUrlRequestClientOnUploadProgressRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Request parameter for the <see cref="CfrUrlRequestClient.OnUploadProgress"/> render process callback.
            /// </summary>
            public CfrUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrUrlRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Current parameter for the <see cref="CfrUrlRequestClient.OnUploadProgress"/> render process callback.
            /// </summary>
            public long Current {
                get {
                    CheckAccess();
                    return call.current;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfrUrlRequestClient.OnUploadProgress"/> render process callback.
            /// </summary>
            public long Total {
                get {
                    CheckAccess();
                    return call.total;
                }
            }

            public override string ToString() {
                return String.Format("Request={{{0}}}, Current={{{1}}}, Total={{{2}}}", Request, Current, Total);
            }
        }

        /// <summary>
        /// Notifies the client of download progress. |Current| denotes the number of
        /// bytes received up to the call and |Total| is the expected total size of the
        /// response (or -1 if not determined).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnDownloadProgressEventHandler(object sender, CfrOnDownloadProgressEventArgs e);

        /// <summary>
        /// Notifies the client of download progress. |Current| denotes the number of
        /// bytes received up to the call and |Total| is the expected total size of the
        /// response (or -1 if not determined).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfrOnDownloadProgressEventArgs : CfrEventArgs {

            private CfxUrlRequestClientOnDownloadProgressRemoteEventCall call;

            internal CfrUrlRequest m_request_wrapped;

            internal CfrOnDownloadProgressEventArgs(CfxUrlRequestClientOnDownloadProgressRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Request parameter for the <see cref="CfrUrlRequestClient.OnDownloadProgress"/> render process callback.
            /// </summary>
            public CfrUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrUrlRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Current parameter for the <see cref="CfrUrlRequestClient.OnDownloadProgress"/> render process callback.
            /// </summary>
            public long Current {
                get {
                    CheckAccess();
                    return call.current;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfrUrlRequestClient.OnDownloadProgress"/> render process callback.
            /// </summary>
            public long Total {
                get {
                    CheckAccess();
                    return call.total;
                }
            }

            public override string ToString() {
                return String.Format("Request={{{0}}}, Current={{{1}}}, Total={{{2}}}", Request, Current, Total);
            }
        }

        /// <summary>
        /// Called when some part of the response is read. |Data| contains the current
        /// bytes received since the last call. This function will not be called if the
        /// UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnDownloadDataEventHandler(object sender, CfrOnDownloadDataEventArgs e);

        /// <summary>
        /// Called when some part of the response is read. |Data| contains the current
        /// bytes received since the last call. This function will not be called if the
        /// UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfrOnDownloadDataEventArgs : CfrEventArgs {

            private CfxUrlRequestClientOnDownloadDataRemoteEventCall call;

            internal CfrUrlRequest m_request_wrapped;

            internal CfrOnDownloadDataEventArgs(CfxUrlRequestClientOnDownloadDataRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Request parameter for the <see cref="CfrUrlRequestClient.OnDownloadData"/> render process callback.
            /// </summary>
            public CfrUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrUrlRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Data parameter for the <see cref="CfrUrlRequestClient.OnDownloadData"/> render process callback.
            /// </summary>
            public RemotePtr Data {
                get {
                    CheckAccess();
                    return new RemotePtr(connection, call.data);
                }
            }
            /// <summary>
            /// Get the DataLength parameter for the <see cref="CfrUrlRequestClient.OnDownloadData"/> render process callback.
            /// </summary>
            public ulong DataLength {
                get {
                    CheckAccess();
                    return (ulong)call.data_length;
                }
            }

            public override string ToString() {
                return String.Format("Request={{{0}}}, Data={{{1}}}, DataLength={{{2}}}", Request, Data, DataLength);
            }
        }

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. Return true (1) to continue
        /// the request and call CfrAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfrRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfrUrlRequestClientGetAuthCredentialsEventHandler(object sender, CfrUrlRequestClientGetAuthCredentialsEventArgs e);

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. Return true (1) to continue
        /// the request and call CfrAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfrRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfrUrlRequestClientGetAuthCredentialsEventArgs : CfrEventArgs {

            private CfxUrlRequestClientGetAuthCredentialsRemoteEventCall call;

            internal string m_host;
            internal bool m_host_fetched;
            internal string m_realm;
            internal bool m_realm_fetched;
            internal string m_scheme;
            internal bool m_scheme_fetched;
            internal CfrAuthCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrUrlRequestClientGetAuthCredentialsEventArgs(CfxUrlRequestClientGetAuthCredentialsRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the IsProxy parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public bool IsProxy {
                get {
                    CheckAccess();
                    return 0 != call.isProxy;
                }
            }
            /// <summary>
            /// Get the Host parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public string Host {
                get {
                    CheckAccess();
                    if(!m_host_fetched) {
                        m_host = call.host_str == IntPtr.Zero ? null : (call.host_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.host_str), call.host_length));
                        m_host_fetched = true;
                    }
                    return m_host;
                }
            }
            /// <summary>
            /// Get the Port parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public int Port {
                get {
                    CheckAccess();
                    return call.port;
                }
            }
            /// <summary>
            /// Get the Realm parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public string Realm {
                get {
                    CheckAccess();
                    if(!m_realm_fetched) {
                        m_realm = call.realm_str == IntPtr.Zero ? null : (call.realm_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.realm_str), call.realm_length));
                        m_realm_fetched = true;
                    }
                    return m_realm;
                }
            }
            /// <summary>
            /// Get the Scheme parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public string Scheme {
                get {
                    CheckAccess();
                    if(!m_scheme_fetched) {
                        m_scheme = call.scheme_str == IntPtr.Zero ? null : (call.scheme_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.scheme_str), call.scheme_length));
                        m_scheme_fetched = true;
                    }
                    return m_scheme;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// </summary>
            public CfrAuthCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfrAuthCallback.Wrap(new RemotePtr(connection, call.callback));
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrUrlRequestClient.GetAuthCredentials"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("IsProxy={{{0}}}, Host={{{1}}}, Port={{{2}}}, Realm={{{3}}}, Scheme={{{4}}}, Callback={{{5}}}", IsProxy, Host, Port, Realm, Scheme, Callback);
            }
        }

    }
}
