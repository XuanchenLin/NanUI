// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxUrlRequestClientRemoteClient {

        static CfxUrlRequestClientRemoteClient() {
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

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(self, index, active ? on_request_complete_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(self, index, active ? on_upload_progress_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(self, index, active ? on_download_progress_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(self, index, active ? on_download_data_native_ptr : IntPtr.Zero);
                    break;
                case 4:
                    CfxApi.UrlRequestClient.cfx_urlrequest_client_set_callback(self, index, active ? get_auth_credentials_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // on_request_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_request_complete_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release);
        private static on_request_complete_delegate on_request_complete_native;
        private static IntPtr on_request_complete_native_ptr;

        internal static void on_request_complete(IntPtr gcHandlePtr, IntPtr request, out int request_release) {
            var call = new CfxUrlRequestClientOnRequestCompleteRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.request = request;
            call.RequestExecution();
            request_release = call.request_release;
        }

        // on_upload_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_upload_progress_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total);
        private static on_upload_progress_delegate on_upload_progress_native;
        private static IntPtr on_upload_progress_native_ptr;

        internal static void on_upload_progress(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total) {
            var call = new CfxUrlRequestClientOnUploadProgressRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.request = request;
            call.current = current;
            call.total = total;
            call.RequestExecution();
            request_release = call.request_release;
        }

        // on_download_progress
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_progress_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total);
        private static on_download_progress_delegate on_download_progress_native;
        private static IntPtr on_download_progress_native_ptr;

        internal static void on_download_progress(IntPtr gcHandlePtr, IntPtr request, out int request_release, long current, long total) {
            var call = new CfxUrlRequestClientOnDownloadProgressRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.request = request;
            call.current = current;
            call.total = total;
            call.RequestExecution();
            request_release = call.request_release;
        }

        // on_download_data
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_data_delegate(IntPtr gcHandlePtr, IntPtr request, out int request_release, IntPtr data, UIntPtr data_length);
        private static on_download_data_delegate on_download_data_native;
        private static IntPtr on_download_data_native_ptr;

        internal static void on_download_data(IntPtr gcHandlePtr, IntPtr request, out int request_release, IntPtr data, UIntPtr data_length) {
            var call = new CfxUrlRequestClientOnDownloadDataRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.request = request;
            call.data = data;
            call.data_length = data_length;
            call.RequestExecution();
            request_release = call.request_release;
        }

        // get_auth_credentials
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_auth_credentials_delegate(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release);
        private static get_auth_credentials_delegate get_auth_credentials_native;
        private static IntPtr get_auth_credentials_native_ptr;

        internal static void get_auth_credentials(IntPtr gcHandlePtr, out int __retval, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release) {
            var call = new CfxUrlRequestClientGetAuthCredentialsRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.isProxy = isProxy;
            call.host_str = host_str;
            call.host_length = host_length;
            call.port = port;
            call.realm_str = realm_str;
            call.realm_length = realm_length;
            call.scheme_str = scheme_str;
            call.scheme_length = scheme_length;
            call.callback = callback;
            call.RequestExecution();
            callback_release = call.callback_release;
            __retval = call.__retval;
        }

    }
}
