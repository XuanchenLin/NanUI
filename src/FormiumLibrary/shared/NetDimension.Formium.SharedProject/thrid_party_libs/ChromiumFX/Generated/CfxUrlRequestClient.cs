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
    /// Structure that should be implemented by the CfxUrlRequest client. The
    /// functions of this structure will be called on the same thread that created
    /// the request unless otherwise documented.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
    /// </remarks>
    public class CfxUrlRequestClient : CfxBaseClient {

        internal static CfxUrlRequestClient Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.UrlRequestClient.cfx_urlrequest_client_get_gc_handle(nativePtr);
            return (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_request_complete_native = on_request_complete;
            on_upload_progress_native = on_upload_progress;
            on_download_progress_native = on_download_progress;
            on_download_data_native = on_download_data;
            get_auth_credentials_native = get_auth_credentials;

            on_request_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_request_complete_native);
            on_upload_progress_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_upload_progress_native);
            on_download_progress_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_download_progress_native);
            on_download_data_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_download_data_native);
            get_auth_credentials_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_auth_credentials_native);
        }

        // on_request_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_request_complete_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release);
        private static on_request_complete_delegate on_request_complete_native;
        private static IntPtr on_request_complete_native_ptr;

        internal static void on_request_complete(IntPtr gcHandlePtr, IntPtr request, out int request_release) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                request_release = 1;
                return;
            }
            var e = new CfxOnRequestCompleteEventArgs();
            e.m_request = request;
            self.m_OnRequestComplete?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }

        // on_upload_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_upload_progress_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total);
        private static on_upload_progress_delegate on_upload_progress_native;
        private static IntPtr on_upload_progress_native_ptr;

        internal static void on_upload_progress(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                request_release = 1;
                return;
            }
            var e = new CfxOnUploadProgressEventArgs();
            e.m_request = request;
            e.m_current = current;
            e.m_total = total;
            self.m_OnUploadProgress?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }

        // on_download_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_progress_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total);
        private static on_download_progress_delegate on_download_progress_native;
        private static IntPtr on_download_progress_native_ptr;

        internal static void on_download_progress(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                request_release = 1;
                return;
            }
            var e = new CfxOnDownloadProgressEventArgs();
            e.m_request = request;
            e.m_current = current;
            e.m_total = total;
            self.m_OnDownloadProgress?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }

        // on_download_data
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_data_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, IntPtr data, UIntPtr data_length);
        private static on_download_data_delegate on_download_data_native;
        private static IntPtr on_download_data_native_ptr;

        internal static void on_download_data(IntPtr gcHandlePtr, IntPtr request, out int request_release, IntPtr data, UIntPtr data_length) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                request_release = 1;
                return;
            }
            var e = new CfxOnDownloadDataEventArgs();
            e.m_request = request;
            e.m_data = data;
            e.m_data_length = data_length;
            self.m_OnDownloadData?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }

        // get_auth_credentials
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_auth_credentials_delegate(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release);
        private static get_auth_credentials_delegate get_auth_credentials_native;
        private static IntPtr get_auth_credentials_native_ptr;

        internal static void get_auth_credentials(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                callback_release = 1;
                return;
            }
            var e = new CfxUrlRequestClientGetAuthCredentialsEventArgs();
            e.m_isProxy = isProxy;
            e.m_host_str = host_str;
            e.m_host_length = host_length;
            e.m_port = port;
            e.m_realm_str = realm_str;
            e.m_realm_length = realm_length;
            e.m_scheme_str = scheme_str;
            e.m_scheme_length = scheme_length;
            e.m_callback = callback;
            self.m_GetAuthCredentials?.Invoke(self, e);
            e.m_isInvalid = true;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxUrlRequestClient(IntPtr nativePtr) : base(nativePtr) {}
        public CfxUrlRequestClient() : base(CfxApi.UrlRequestClient.cfx_urlrequest_client_ctor) {}

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfxUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfxOnRequestCompleteEventHandler OnRequestComplete {
            add {
                lock(eventLock) {
                    if(m_OnRequestComplete == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 0, on_request_complete_native_ptr);
                    }
                    m_OnRequestComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRequestComplete -= value;
                    if(m_OnRequestComplete == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRequestCompleteEventHandler m_OnRequestComplete;

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
        public event CfxOnUploadProgressEventHandler OnUploadProgress {
            add {
                lock(eventLock) {
                    if(m_OnUploadProgress == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 1, on_upload_progress_native_ptr);
                    }
                    m_OnUploadProgress += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnUploadProgress -= value;
                    if(m_OnUploadProgress == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnUploadProgressEventHandler m_OnUploadProgress;

        /// <summary>
        /// Notifies the client of download progress. |Current| denotes the number of
        /// bytes received up to the call and |Total| is the expected total size of the
        /// response (or -1 if not determined).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfxOnDownloadProgressEventHandler OnDownloadProgress {
            add {
                lock(eventLock) {
                    if(m_OnDownloadProgress == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 2, on_download_progress_native_ptr);
                    }
                    m_OnDownloadProgress += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadProgress -= value;
                    if(m_OnDownloadProgress == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDownloadProgressEventHandler m_OnDownloadProgress;

        /// <summary>
        /// Called when some part of the response is read. |Data| contains the current
        /// bytes received since the last call. This function will not be called if the
        /// UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfxOnDownloadDataEventHandler OnDownloadData {
            add {
                lock(eventLock) {
                    if(m_OnDownloadData == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 3, on_download_data_native_ptr);
                    }
                    m_OnDownloadData += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadData -= value;
                    if(m_OnDownloadData == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDownloadDataEventHandler m_OnDownloadData;

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. Return true (1) to continue
        /// the request and call CfxAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfxRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfxUrlRequestClientGetAuthCredentialsEventHandler GetAuthCredentials {
            add {
                lock(eventLock) {
                    if(m_GetAuthCredentials == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 4, get_auth_credentials_native_ptr);
                    }
                    m_GetAuthCredentials += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetAuthCredentials -= value;
                    if(m_GetAuthCredentials == null) {
                        CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxUrlRequestClientGetAuthCredentialsEventHandler m_GetAuthCredentials;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRequestComplete != null) {
                m_OnRequestComplete = null;
                CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnUploadProgress != null) {
                m_OnUploadProgress = null;
                CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnDownloadProgress != null) {
                m_OnDownloadProgress = null;
                CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnDownloadData != null) {
                m_OnDownloadData = null;
                CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetAuthCredentials != null) {
                m_GetAuthCredentials = null;
                CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfxUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRequestCompleteEventHandler(object sender, CfxOnRequestCompleteEventArgs e);

        /// <summary>
        /// Notifies the client that the request has completed. Use the
        /// CfxUrlRequest.GetRequestStatus function to determine if the request was
        /// successful or not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfxOnRequestCompleteEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxUrlRequest m_request_wrapped;

            internal CfxOnRequestCompleteEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxUrlRequestClient.OnRequestComplete"/> callback.
            /// </summary>
            public CfxUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxUrlRequest.Wrap(m_request);
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
        public delegate void CfxOnUploadProgressEventHandler(object sender, CfxOnUploadProgressEventArgs e);

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
        public class CfxOnUploadProgressEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxUrlRequest m_request_wrapped;
            internal long m_current;
            internal long m_total;

            internal CfxOnUploadProgressEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxUrlRequestClient.OnUploadProgress"/> callback.
            /// </summary>
            public CfxUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxUrlRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Current parameter for the <see cref="CfxUrlRequestClient.OnUploadProgress"/> callback.
            /// </summary>
            public long Current {
                get {
                    CheckAccess();
                    return m_current;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxUrlRequestClient.OnUploadProgress"/> callback.
            /// </summary>
            public long Total {
                get {
                    CheckAccess();
                    return m_total;
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
        public delegate void CfxOnDownloadProgressEventHandler(object sender, CfxOnDownloadProgressEventArgs e);

        /// <summary>
        /// Notifies the client of download progress. |Current| denotes the number of
        /// bytes received up to the call and |Total| is the expected total size of the
        /// response (or -1 if not determined).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfxOnDownloadProgressEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxUrlRequest m_request_wrapped;
            internal long m_current;
            internal long m_total;

            internal CfxOnDownloadProgressEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxUrlRequestClient.OnDownloadProgress"/> callback.
            /// </summary>
            public CfxUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxUrlRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Current parameter for the <see cref="CfxUrlRequestClient.OnDownloadProgress"/> callback.
            /// </summary>
            public long Current {
                get {
                    CheckAccess();
                    return m_current;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxUrlRequestClient.OnDownloadProgress"/> callback.
            /// </summary>
            public long Total {
                get {
                    CheckAccess();
                    return m_total;
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
        public delegate void CfxOnDownloadDataEventHandler(object sender, CfxOnDownloadDataEventArgs e);

        /// <summary>
        /// Called when some part of the response is read. |Data| contains the current
        /// bytes received since the last call. This function will not be called if the
        /// UR_FLAG_NO_DOWNLOAD_DATA flag is set on the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfxOnDownloadDataEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxUrlRequest m_request_wrapped;
            internal IntPtr m_data;
            internal UIntPtr m_data_length;

            internal CfxOnDownloadDataEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxUrlRequestClient.OnDownloadData"/> callback.
            /// </summary>
            public CfxUrlRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxUrlRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Data parameter for the <see cref="CfxUrlRequestClient.OnDownloadData"/> callback.
            /// </summary>
            public IntPtr Data {
                get {
                    CheckAccess();
                    return m_data;
                }
            }
            /// <summary>
            /// Get the DataLength parameter for the <see cref="CfxUrlRequestClient.OnDownloadData"/> callback.
            /// </summary>
            public ulong DataLength {
                get {
                    CheckAccess();
                    return (ulong)m_data_length;
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
        /// the request and call CfxAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfxRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public delegate void CfxUrlRequestClientGetAuthCredentialsEventHandler(object sender, CfxUrlRequestClientGetAuthCredentialsEventArgs e);

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. Return true (1) to continue
        /// the request and call CfxAuthCallback.Continue() when the authentication
        /// information is available. If the request has an associated browser/frame
        /// then returning false (0) will result in a call to GetAuthCredentials on the
        /// CfxRequestHandler associated with that browser, if any. Otherwise,
        /// returning false (0) will cancel the request immediately. This function will
        /// only be called for requests initiated from the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public class CfxUrlRequestClientGetAuthCredentialsEventArgs : CfxEventArgs {

            internal int m_isProxy;
            internal IntPtr m_host_str;
            internal int m_host_length;
            internal string m_host;
            internal int m_port;
            internal IntPtr m_realm_str;
            internal int m_realm_length;
            internal string m_realm;
            internal IntPtr m_scheme_str;
            internal int m_scheme_length;
            internal string m_scheme;
            internal IntPtr m_callback;
            internal CfxAuthCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxUrlRequestClientGetAuthCredentialsEventArgs() {}

            /// <summary>
            /// Get the IsProxy parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public bool IsProxy {
                get {
                    CheckAccess();
                    return 0 != m_isProxy;
                }
            }
            /// <summary>
            /// Get the Host parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public string Host {
                get {
                    CheckAccess();
                    m_host = StringFunctions.PtrToStringUni(m_host_str, m_host_length);
                    return m_host;
                }
            }
            /// <summary>
            /// Get the Port parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public int Port {
                get {
                    CheckAccess();
                    return m_port;
                }
            }
            /// <summary>
            /// Get the Realm parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public string Realm {
                get {
                    CheckAccess();
                    m_realm = StringFunctions.PtrToStringUni(m_realm_str, m_realm_length);
                    return m_realm;
                }
            }
            /// <summary>
            /// Get the Scheme parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public string Scheme {
                get {
                    CheckAccess();
                    m_scheme = StringFunctions.PtrToStringUni(m_scheme_str, m_scheme_length);
                    return m_scheme;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
            /// </summary>
            public CfxAuthCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxAuthCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxUrlRequestClient.GetAuthCredentials"/> callback.
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
                return String.Format("IsProxy={{{0}}}, Host={{{1}}}, Port={{{2}}}, Realm={{{3}}}, Scheme={{{4}}}, Callback={{{5}}}", IsProxy, Host, Port, Realm, Scheme, Callback);
            }
        }

    }
}
