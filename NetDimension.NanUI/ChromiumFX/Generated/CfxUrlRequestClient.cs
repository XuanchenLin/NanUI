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
	/// Structure that should be implemented by the CfxUrlRequest client. The
	/// functions of this structure will be called on the same thread that created
	/// the request unless otherwise documented.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
	/// </remarks>
	public class CfxUrlRequestClient : CfxBase {

        static CfxUrlRequestClient () {
            CfxApiLoader.LoadCfxUrlRequestClientApi();
        }

        internal static CfxUrlRequestClient Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_urlrequest_client_get_gc_handle(nativePtr);
            return (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_request_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_urlrequest_client_on_request_complete_delegate(IntPtr gcHandlePtr, IntPtr request);
        private static cfx_urlrequest_client_on_request_complete_delegate cfx_urlrequest_client_on_request_complete;
        private static IntPtr cfx_urlrequest_client_on_request_complete_ptr;

        internal static void on_request_complete(IntPtr gcHandlePtr, IntPtr request) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnRequestCompleteEventArgs(request);
            var eventHandler = self.m_OnRequestComplete;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
        }

        // on_upload_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_urlrequest_client_on_upload_progress_delegate(IntPtr gcHandlePtr, IntPtr request, long current, long total);
        private static cfx_urlrequest_client_on_upload_progress_delegate cfx_urlrequest_client_on_upload_progress;
        private static IntPtr cfx_urlrequest_client_on_upload_progress_ptr;

        internal static void on_upload_progress(IntPtr gcHandlePtr, IntPtr request, long current, long total) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnUploadProgressEventArgs(request, current, total);
            var eventHandler = self.m_OnUploadProgress;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
        }

        // on_download_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_urlrequest_client_on_download_progress_delegate(IntPtr gcHandlePtr, IntPtr request, long current, long total);
        private static cfx_urlrequest_client_on_download_progress_delegate cfx_urlrequest_client_on_download_progress;
        private static IntPtr cfx_urlrequest_client_on_download_progress_ptr;

        internal static void on_download_progress(IntPtr gcHandlePtr, IntPtr request, long current, long total) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnDownloadProgressEventArgs(request, current, total);
            var eventHandler = self.m_OnDownloadProgress;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
        }

        // on_download_data
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_urlrequest_client_on_download_data_delegate(IntPtr gcHandlePtr, IntPtr request, IntPtr data, int data_length);
        private static cfx_urlrequest_client_on_download_data_delegate cfx_urlrequest_client_on_download_data;
        private static IntPtr cfx_urlrequest_client_on_download_data_ptr;

        internal static void on_download_data(IntPtr gcHandlePtr, IntPtr request, IntPtr data, int data_length) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnDownloadDataEventArgs(request, data, data_length);
            var eventHandler = self.m_OnDownloadData;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
        }

        // get_auth_credentials
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_urlrequest_client_get_auth_credentials_delegate(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback);
        private static cfx_urlrequest_client_get_auth_credentials_delegate cfx_urlrequest_client_get_auth_credentials;
        private static IntPtr cfx_urlrequest_client_get_auth_credentials_ptr;

        internal static void get_auth_credentials(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback) {
            var self = (CfxUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxUrlRequestClientGetAuthCredentialsEventArgs(isProxy, host_str, host_length, port, realm_str, realm_length, scheme_str, scheme_length, callback);
            var eventHandler = self.m_GetAuthCredentials;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxUrlRequestClient(IntPtr nativePtr) : base(nativePtr) {}
        public CfxUrlRequestClient() : base(CfxApi.cfx_urlrequest_client_ctor) {}

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
                        if(cfx_urlrequest_client_on_request_complete == null) {
                            cfx_urlrequest_client_on_request_complete = on_request_complete;
                            cfx_urlrequest_client_on_request_complete_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_urlrequest_client_on_request_complete);
                        }
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 0, cfx_urlrequest_client_on_request_complete_ptr);
                    }
                    m_OnRequestComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRequestComplete -= value;
                    if(m_OnRequestComplete == null) {
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_urlrequest_client_on_upload_progress == null) {
                            cfx_urlrequest_client_on_upload_progress = on_upload_progress;
                            cfx_urlrequest_client_on_upload_progress_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_urlrequest_client_on_upload_progress);
                        }
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 1, cfx_urlrequest_client_on_upload_progress_ptr);
                    }
                    m_OnUploadProgress += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnUploadProgress -= value;
                    if(m_OnUploadProgress == null) {
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 1, IntPtr.Zero);
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
                        if(cfx_urlrequest_client_on_download_progress == null) {
                            cfx_urlrequest_client_on_download_progress = on_download_progress;
                            cfx_urlrequest_client_on_download_progress_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_urlrequest_client_on_download_progress);
                        }
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 2, cfx_urlrequest_client_on_download_progress_ptr);
                    }
                    m_OnDownloadProgress += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadProgress -= value;
                    if(m_OnDownloadProgress == null) {
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 2, IntPtr.Zero);
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
                        if(cfx_urlrequest_client_on_download_data == null) {
                            cfx_urlrequest_client_on_download_data = on_download_data;
                            cfx_urlrequest_client_on_download_data_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_urlrequest_client_on_download_data);
                        }
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 3, cfx_urlrequest_client_on_download_data_ptr);
                    }
                    m_OnDownloadData += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadData -= value;
                    if(m_OnDownloadData == null) {
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 3, IntPtr.Zero);
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
        /// information is available. Return false (0) to cancel the request. This
        /// function will only be called for requests initiated from the browser
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public event CfxUrlRequestClientGetAuthCredentialsEventHandler GetAuthCredentials {
            add {
                lock(eventLock) {
                    if(m_GetAuthCredentials == null) {
                        if(cfx_urlrequest_client_get_auth_credentials == null) {
                            cfx_urlrequest_client_get_auth_credentials = get_auth_credentials;
                            cfx_urlrequest_client_get_auth_credentials_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_urlrequest_client_get_auth_credentials);
                        }
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 4, cfx_urlrequest_client_get_auth_credentials_ptr);
                    }
                    m_GetAuthCredentials += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetAuthCredentials -= value;
                    if(m_GetAuthCredentials == null) {
                        CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxUrlRequestClientGetAuthCredentialsEventHandler m_GetAuthCredentials;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRequestComplete != null) {
                m_OnRequestComplete = null;
                CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnUploadProgress != null) {
                m_OnUploadProgress = null;
                CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnDownloadProgress != null) {
                m_OnDownloadProgress = null;
                CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnDownloadData != null) {
                m_OnDownloadData = null;
                CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetAuthCredentials != null) {
                m_GetAuthCredentials = null;
                CfxApi.cfx_urlrequest_client_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxOnRequestCompleteEventArgs(IntPtr request) {
                m_request = request;
            }

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

            internal CfxOnUploadProgressEventArgs(IntPtr request, long current, long total) {
                m_request = request;
                m_current = current;
                m_total = total;
            }

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

            internal CfxOnDownloadProgressEventArgs(IntPtr request, long current, long total) {
                m_request = request;
                m_current = current;
                m_total = total;
            }

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
            internal int m_data_length;

            internal CfxOnDownloadDataEventArgs(IntPtr request, IntPtr data, int data_length) {
                m_request = request;
                m_data = data;
                m_data_length = data_length;
            }

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
            public int DataLength {
                get {
                    CheckAccess();
                    return m_data_length;
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
        /// information is available. Return false (0) to cancel the request. This
        /// function will only be called for requests initiated from the browser
        /// process.
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
        /// information is available. Return false (0) to cancel the request. This
        /// function will only be called for requests initiated from the browser
        /// process.
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

            internal CfxUrlRequestClientGetAuthCredentialsEventArgs(int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback) {
                m_isProxy = isProxy;
                m_host_str = host_str;
                m_host_length = host_length;
                m_port = port;
                m_realm_str = realm_str;
                m_realm_length = realm_length;
                m_scheme_str = scheme_str;
                m_scheme_length = scheme_length;
                m_callback = callback;
            }

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
