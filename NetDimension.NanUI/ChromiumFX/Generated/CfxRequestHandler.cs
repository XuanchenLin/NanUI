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
    /// Implement this structure to handle events related to browser requests. The
    /// functions of this structure will be called on the thread indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
    /// </remarks>
    public class CfxRequestHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_before_browse_native = on_before_browse;
            on_open_urlfrom_tab_native = on_open_urlfrom_tab;
            on_before_resource_load_native = on_before_resource_load;
            get_resource_handler_native = get_resource_handler;
            on_resource_redirect_native = on_resource_redirect;
            on_resource_response_native = on_resource_response;
            get_resource_response_filter_native = get_resource_response_filter;
            on_resource_load_complete_native = on_resource_load_complete;
            get_auth_credentials_native = get_auth_credentials;
            on_quota_request_native = on_quota_request;
            on_protocol_execution_native = on_protocol_execution;
            on_certificate_error_native = on_certificate_error;
            on_select_client_certificate_native = on_select_client_certificate;
            on_plugin_crashed_native = on_plugin_crashed;
            on_render_view_ready_native = on_render_view_ready;
            on_render_process_terminated_native = on_render_process_terminated;

            on_before_browse_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_browse_native);
            on_open_urlfrom_tab_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_open_urlfrom_tab_native);
            on_before_resource_load_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_resource_load_native);
            get_resource_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_handler_native);
            on_resource_redirect_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_redirect_native);
            on_resource_response_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_response_native);
            get_resource_response_filter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_response_filter_native);
            on_resource_load_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_load_complete_native);
            get_auth_credentials_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_auth_credentials_native);
            on_quota_request_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_quota_request_native);
            on_protocol_execution_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_protocol_execution_native);
            on_certificate_error_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_certificate_error_native);
            on_select_client_certificate_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_select_client_certificate_native);
            on_plugin_crashed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_plugin_crashed_native);
            on_render_view_ready_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_view_ready_native);
            on_render_process_terminated_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_process_terminated_native);
        }

        // on_before_browse
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_browse_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_redirect);
        private static on_before_browse_delegate on_before_browse_native;
        private static IntPtr on_before_browse_native_ptr;

        internal static void on_before_browse(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_redirect) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxOnBeforeBrowseEventArgs(browser, frame, request, is_redirect);
            self.m_OnBeforeBrowse?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_open_urlfrom_tab
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_open_urlfrom_tab_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr target_url_str, int target_url_length, int target_disposition, int user_gesture);
        private static on_open_urlfrom_tab_delegate on_open_urlfrom_tab_native;
        private static IntPtr on_open_urlfrom_tab_native_ptr;

        internal static void on_open_urlfrom_tab(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr target_url_str, int target_url_length, int target_disposition, int user_gesture) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnOpenUrlfromTabEventArgs(browser, frame, target_url_str, target_url_length, target_disposition, user_gesture);
            self.m_OnOpenUrlfromTab?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_before_resource_load
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_resource_load_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr callback, out int callback_release);
        private static on_before_resource_load_delegate on_before_resource_load_native;
        private static IntPtr on_before_resource_load_native_ptr;

        internal static void on_before_resource_load(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnBeforeResourceLoadEventArgs(browser, frame, request, callback);
            self.m_OnBeforeResourceLoad?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = (int)e.m_returnValue;
        }

        // get_resource_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_resource_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release);
        private static get_resource_handler_delegate get_resource_handler_native;
        private static IntPtr get_resource_handler_native_ptr;

        internal static void get_resource_handler(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxGetResourceHandlerEventArgs(browser, frame, request);
            self.m_GetResourceHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            __retval = CfxResourceHandler.Unwrap(e.m_returnValue);
        }

        // on_resource_redirect
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_resource_redirect_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, ref IntPtr new_url_str, ref int new_url_length);
        private static on_resource_redirect_delegate on_resource_redirect_native;
        private static IntPtr on_resource_redirect_native_ptr;

        internal static void on_resource_redirect(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, ref IntPtr new_url_str, ref int new_url_length) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceRedirectEventArgs(browser, frame, request, response, new_url_str, new_url_length);
            self.m_OnResourceRedirect?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
            if(e.m_new_url_changed) {
                var new_url_pinned = new PinnedString(e.m_new_url_wrapped);
                new_url_str = new_url_pinned.Obj.PinnedPtr;
                new_url_length = new_url_pinned.Length;
            }
        }

        // on_resource_response
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_resource_response_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release);
        private static on_resource_response_delegate on_resource_response_native;
        private static IntPtr on_resource_response_native_ptr;

        internal static void on_resource_response(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceResponseEventArgs(browser, frame, request, response);
            self.m_OnResourceResponse?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_resource_response_filter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_resource_response_filter_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release);
        private static get_resource_response_filter_delegate get_resource_response_filter_native;
        private static IntPtr get_resource_response_filter_native_ptr;

        internal static void get_resource_response_filter(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxGetResourceResponseFilterEventArgs(browser, frame, request, response);
            self.m_GetResourceResponseFilter?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
            __retval = CfxResponseFilter.Unwrap(e.m_returnValue);
        }

        // on_resource_load_complete
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_resource_load_complete_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, int status, long received_content_length);
        private static on_resource_load_complete_delegate on_resource_load_complete_native;
        private static IntPtr on_resource_load_complete_native_ptr;

        internal static void on_resource_load_complete(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr response, out int response_release, int status, long received_content_length) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceLoadCompleteEventArgs(browser, frame, request, response, status, received_content_length);
            self.m_OnResourceLoadComplete?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
        }

        // get_auth_credentials
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_auth_credentials_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release);
        private static get_auth_credentials_delegate get_auth_credentials_native;
        private static IntPtr get_auth_credentials_native_ptr;

        internal static void get_auth_credentials(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxRequestHandlerGetAuthCredentialsEventArgs(browser, frame, isProxy, host_str, host_length, port, realm_str, realm_length, scheme_str, scheme_length, callback);
            self.m_GetAuthCredentials?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_quota_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_quota_request_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr origin_url_str, int origin_url_length, long new_size, IntPtr callback, out int callback_release);
        private static on_quota_request_delegate on_quota_request_native;
        private static IntPtr on_quota_request_native_ptr;

        internal static void on_quota_request(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr origin_url_str, int origin_url_length, long new_size, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnQuotaRequestEventArgs(browser, origin_url_str, origin_url_length, new_size, callback);
            self.m_OnQuotaRequest?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_protocol_execution
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_protocol_execution_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr url_str, int url_length, out int allow_os_execution);
        private static on_protocol_execution_delegate on_protocol_execution_native;
        private static IntPtr on_protocol_execution_native_ptr;

        internal static void on_protocol_execution(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr url_str, int url_length, out int allow_os_execution) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                allow_os_execution = default(int);
                return;
            }
            var e = new CfxOnProtocolExecutionEventArgs(browser, url_str, url_length);
            self.m_OnProtocolExecution?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            allow_os_execution = e.m_allow_os_execution;
        }

        // on_certificate_error
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_certificate_error_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int cert_error, IntPtr request_url_str, int request_url_length, IntPtr ssl_info, out int ssl_info_release, IntPtr callback, out int callback_release);
        private static on_certificate_error_delegate on_certificate_error_native;
        private static IntPtr on_certificate_error_native_ptr;

        internal static void on_certificate_error(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int cert_error, IntPtr request_url_str, int request_url_length, IntPtr ssl_info, out int ssl_info_release, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                ssl_info_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnCertificateErrorEventArgs(browser, cert_error, request_url_str, request_url_length, ssl_info, callback);
            self.m_OnCertificateError?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            ssl_info_release = e.m_ssl_info_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_select_client_certificate
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_select_client_certificate_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int isProxy, IntPtr host_str, int host_length, int port, UIntPtr certificatesCount, IntPtr certificates, out int certificates_release, IntPtr callback, out int callback_release);
        private static on_select_client_certificate_delegate on_select_client_certificate_native;
        private static IntPtr on_select_client_certificate_native_ptr;

        internal static void on_select_client_certificate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int isProxy, IntPtr host_str, int host_length, int port, UIntPtr certificatesCount, IntPtr certificates, out int certificates_release, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                certificates_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnSelectClientCertificateEventArgs(browser, isProxy, host_str, host_length, port, certificates, certificatesCount, callback);
            self.m_OnSelectClientCertificate?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            certificates_release = e.m_certificates_managed == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_plugin_crashed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_plugin_crashed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr plugin_path_str, int plugin_path_length);
        private static on_plugin_crashed_delegate on_plugin_crashed_native;
        private static IntPtr on_plugin_crashed_native_ptr;

        internal static void on_plugin_crashed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr plugin_path_str, int plugin_path_length) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPluginCrashedEventArgs(browser, plugin_path_str, plugin_path_length);
            self.m_OnPluginCrashed?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_render_view_ready
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_render_view_ready_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_render_view_ready_delegate on_render_view_ready_native;
        private static IntPtr on_render_view_ready_native_ptr;

        internal static void on_render_view_ready(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnRenderViewReadyEventArgs(browser);
            self.m_OnRenderViewReady?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_render_process_terminated
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_render_process_terminated_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int status);
        private static on_render_process_terminated_delegate on_render_process_terminated_native;
        private static IntPtr on_render_process_terminated_native_ptr;

        internal static void on_render_process_terminated(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int status) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnRenderProcessTerminatedEventArgs(browser, status);
            self.m_OnRenderProcessTerminated?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        public CfxRequestHandler() : base(CfxApi.RequestHandler.cfx_request_handler_ctor) {}

        /// <summary>
        /// Called on the UI thread before browser navigation. Return true (1) to
        /// cancel the navigation or false (0) to allow the navigation to proceed. The
        /// |Request| object cannot be modified in this callback.
        /// CfxLoadHandler.OnLoadingStateChange will be called twice in all cases.
        /// If the navigation is allowed CfxLoadHandler.OnLoadStart and
        /// CfxLoadHandler.OnLoadEnd will be called. If the navigation is canceled
        /// CfxLoadHandler.OnLoadError will be called with an |ErrorCode| value of
        /// ERR_ABORTED.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeBrowseEventHandler OnBeforeBrowse {
            add {
                lock(eventLock) {
                    if(m_OnBeforeBrowse == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 0, on_before_browse_native_ptr);
                    }
                    m_OnBeforeBrowse += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeBrowse -= value;
                    if(m_OnBeforeBrowse == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeBrowseEventHandler m_OnBeforeBrowse;

        /// <summary>
        /// Called on the UI thread before OnBeforeBrowse in certain limited cases
        /// where navigating a new or different browser might be desirable. This
        /// includes user-initiated navigation that might open in a special way (e.g.
        /// links clicked via middle-click or ctrl + left-click) and certain types of
        /// cross-origin navigation initiated from the renderer process (e.g.
        /// navigating the top-level frame to/from a file URL). The |Browser| and
        /// |Frame| values represent the source of the navigation. The
        /// |TargetDisposition| value indicates where the user intended to navigate
        /// the browser based on standard Chromium behaviors (e.g. current tab, new
        /// tab, etc). The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event). Return
        /// true (1) to cancel the navigation or false (0) to allow the navigation to
        /// proceed in the source browser's top-level frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnOpenUrlfromTabEventHandler OnOpenUrlfromTab {
            add {
                lock(eventLock) {
                    if(m_OnOpenUrlfromTab == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 1, on_open_urlfrom_tab_native_ptr);
                    }
                    m_OnOpenUrlfromTab += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnOpenUrlfromTab -= value;
                    if(m_OnOpenUrlfromTab == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnOpenUrlfromTabEventHandler m_OnOpenUrlfromTab;

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Request|
        /// object may be modified. Return RV_CONTINUE to continue the request
        /// immediately. Return RV_CONTINUE_ASYNC and call CfxRequestCallback::
        /// cont() at a later time to continue or cancel the request asynchronously.
        /// Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeResourceLoadEventHandler OnBeforeResourceLoad {
            add {
                lock(eventLock) {
                    if(m_OnBeforeResourceLoad == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, on_before_resource_load_native_ptr);
                    }
                    m_OnBeforeResourceLoad += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeResourceLoad -= value;
                    if(m_OnBeforeResourceLoad == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeResourceLoadEventHandler m_OnBeforeResourceLoad;

        /// <summary>
        /// Called on the IO thread before a resource is loaded. To allow the resource
        /// to load normally return NULL. To specify a handler for the resource return
        /// a CfxResourceHandler object. The |Request| object should not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetResourceHandlerEventHandler GetResourceHandler {
            add {
                lock(eventLock) {
                    if(m_GetResourceHandler == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, get_resource_handler_native_ptr);
                    }
                    m_GetResourceHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceHandler -= value;
                    if(m_GetResourceHandler == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetResourceHandlerEventHandler m_GetResourceHandler;

        /// <summary>
        /// Called on the IO thread when a resource load is redirected. The |Request|
        /// parameter will contain the old URL and other request-related information.
        /// The |Response| parameter will contain the response that resulted in the
        /// redirect. The |NewUrl| parameter will contain the new URL and can be
        /// changed if desired. The |Request| object cannot be modified in this
        /// callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceRedirectEventHandler OnResourceRedirect {
            add {
                lock(eventLock) {
                    if(m_OnResourceRedirect == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, on_resource_redirect_native_ptr);
                    }
                    m_OnResourceRedirect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceRedirect -= value;
                    if(m_OnResourceRedirect == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceRedirectEventHandler m_OnResourceRedirect;

        /// <summary>
        /// Called on the IO thread when a resource response is received. To allow the
        /// resource to load normally return false (0). To redirect or retry the
        /// resource modify |Request| (url, headers or post body) and return true (1).
        /// The |Response| object cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceResponseEventHandler OnResourceResponse {
            add {
                lock(eventLock) {
                    if(m_OnResourceResponse == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, on_resource_response_native_ptr);
                    }
                    m_OnResourceResponse += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceResponse -= value;
                    if(m_OnResourceResponse == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceResponseEventHandler m_OnResourceResponse;

        /// <summary>
        /// Called on the IO thread to optionally filter resource response content.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetResourceResponseFilterEventHandler GetResourceResponseFilter {
            add {
                lock(eventLock) {
                    if(m_GetResourceResponseFilter == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, get_resource_response_filter_native_ptr);
                    }
                    m_GetResourceResponseFilter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceResponseFilter -= value;
                    if(m_GetResourceResponseFilter == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetResourceResponseFilterEventHandler m_GetResourceResponseFilter;

        /// <summary>
        /// Called on the IO thread when a resource load has completed. |Request| and
        /// |Response| represent the request and response respectively and cannot be
        /// modified in this callback. |Status| indicates the load completion status.
        /// |ReceivedContentLength| is the number of response bytes actually read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceLoadCompleteEventHandler OnResourceLoadComplete {
            add {
                lock(eventLock) {
                    if(m_OnResourceLoadComplete == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, on_resource_load_complete_native_ptr);
                    }
                    m_OnResourceLoadComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceLoadComplete -= value;
                    if(m_OnResourceLoadComplete == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceLoadCompleteEventHandler m_OnResourceLoadComplete;

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. |Realm| is the realm of the
        /// challenge and may be NULL. |Scheme| is the authentication scheme used, such
        /// as "basic" or "digest", and will be NULL if the source of the request is an
        /// FTP server. Return true (1) to continue the request and call
        /// CfxAuthCallback.Continue() either in this function or at a later time when
        /// the authentication information is available. Return false (0) to cancel the
        /// request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxRequestHandlerGetAuthCredentialsEventHandler GetAuthCredentials {
            add {
                lock(eventLock) {
                    if(m_GetAuthCredentials == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, get_auth_credentials_native_ptr);
                    }
                    m_GetAuthCredentials += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetAuthCredentials -= value;
                    if(m_GetAuthCredentials == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxRequestHandlerGetAuthCredentialsEventHandler m_GetAuthCredentials;

        /// <summary>
        /// Called on the IO thread when JavaScript requests a specific storage quota
        /// size via the webkitStorageInfo.requestQuota function. |OriginUrl| is the
        /// origin of the page making the request. |NewSize| is the requested quota
        /// size in bytes. Return true (1) to continue the request and call
        /// CfxRequestCallback.Continue() either in this function or at a later time to
        /// grant or deny the request. Return false (0) to cancel the request
        /// immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnQuotaRequestEventHandler OnQuotaRequest {
            add {
                lock(eventLock) {
                    if(m_OnQuotaRequest == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, on_quota_request_native_ptr);
                    }
                    m_OnQuotaRequest += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnQuotaRequest -= value;
                    if(m_OnQuotaRequest == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnQuotaRequestEventHandler m_OnQuotaRequest;

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an unknown
        /// protocol component. Set |AllowOsExecution| to true (1) to attempt
        /// execution via the registered OS protocol handler, if any. SECURITY WARNING:
        /// YOU SHOULD USE THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR
        /// OTHER URL ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnProtocolExecutionEventHandler OnProtocolExecution {
            add {
                lock(eventLock) {
                    if(m_OnProtocolExecution == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 10, on_protocol_execution_native_ptr);
                    }
                    m_OnProtocolExecution += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProtocolExecution -= value;
                    if(m_OnProtocolExecution == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProtocolExecutionEventHandler m_OnProtocolExecution;

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an invalid SSL
        /// certificate. Return true (1) and call CfxRequestCallback.Continue() either
        /// in this function or at a later time to continue or cancel the request.
        /// Return false (0) to cancel the request immediately. If
        /// CfxSettings.IgnoreCertificateErrors is set all invalid certificates will
        /// be accepted without calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnCertificateErrorEventHandler OnCertificateError {
            add {
                lock(eventLock) {
                    if(m_OnCertificateError == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 11, on_certificate_error_native_ptr);
                    }
                    m_OnCertificateError += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCertificateError -= value;
                    if(m_OnCertificateError == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 11, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnCertificateErrorEventHandler m_OnCertificateError;

        /// <summary>
        /// Called on the UI thread when a client certificate is being requested for
        /// authentication. Return false (0) to use the default behavior and
        /// automatically select the first certificate available. Return true (1) and
        /// call CfxSelectClientCertificateCallback.Select either in this
        /// function or at a later time to select a certificate. Do not call Select or
        /// call it with NULL to continue without using any certificate. |IsProxy|
        /// indicates whether the host is an HTTPS proxy or the origin server. |Host|
        /// and |Port| contains the hostname and port of the SSL server. |Certificates|
        /// is the list of certificates to choose from; this list has already been
        /// pruned by Chromium so that it only contains certificates from issuers that
        /// the server trusts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnSelectClientCertificateEventHandler OnSelectClientCertificate {
            add {
                lock(eventLock) {
                    if(m_OnSelectClientCertificate == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 12, on_select_client_certificate_native_ptr);
                    }
                    m_OnSelectClientCertificate += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnSelectClientCertificate -= value;
                    if(m_OnSelectClientCertificate == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 12, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnSelectClientCertificateEventHandler m_OnSelectClientCertificate;

        /// <summary>
        /// Called on the browser process UI thread when a plugin has crashed.
        /// |PluginPath| is the path of the plugin that crashed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPluginCrashedEventHandler OnPluginCrashed {
            add {
                lock(eventLock) {
                    if(m_OnPluginCrashed == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 13, on_plugin_crashed_native_ptr);
                    }
                    m_OnPluginCrashed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPluginCrashed -= value;
                    if(m_OnPluginCrashed == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 13, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPluginCrashedEventHandler m_OnPluginCrashed;

        /// <summary>
        /// Called on the browser process UI thread when the render view associated
        /// with |Browser| is ready to receive/handle IPC messages in the render
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRenderViewReadyEventHandler OnRenderViewReady {
            add {
                lock(eventLock) {
                    if(m_OnRenderViewReady == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 14, on_render_view_ready_native_ptr);
                    }
                    m_OnRenderViewReady += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderViewReady -= value;
                    if(m_OnRenderViewReady == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 14, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRenderViewReadyEventHandler m_OnRenderViewReady;

        /// <summary>
        /// Called on the browser process UI thread when the render process terminates
        /// unexpectedly. |Status| indicates how the process terminated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRenderProcessTerminatedEventHandler OnRenderProcessTerminated {
            add {
                lock(eventLock) {
                    if(m_OnRenderProcessTerminated == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 15, on_render_process_terminated_native_ptr);
                    }
                    m_OnRenderProcessTerminated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderProcessTerminated -= value;
                    if(m_OnRenderProcessTerminated == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 15, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRenderProcessTerminatedEventHandler m_OnRenderProcessTerminated;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnBeforeBrowse != null) {
                m_OnBeforeBrowse = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnOpenUrlfromTab != null) {
                m_OnOpenUrlfromTab = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnBeforeResourceLoad != null) {
                m_OnBeforeResourceLoad = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetResourceHandler != null) {
                m_GetResourceHandler = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnResourceRedirect != null) {
                m_OnResourceRedirect = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnResourceResponse != null) {
                m_OnResourceResponse = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_GetResourceResponseFilter != null) {
                m_GetResourceResponseFilter = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnResourceLoadComplete != null) {
                m_OnResourceLoadComplete = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_GetAuthCredentials != null) {
                m_GetAuthCredentials = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_OnQuotaRequest != null) {
                m_OnQuotaRequest = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_OnProtocolExecution != null) {
                m_OnProtocolExecution = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 10, IntPtr.Zero);
            }
            if(m_OnCertificateError != null) {
                m_OnCertificateError = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 11, IntPtr.Zero);
            }
            if(m_OnSelectClientCertificate != null) {
                m_OnSelectClientCertificate = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 12, IntPtr.Zero);
            }
            if(m_OnPluginCrashed != null) {
                m_OnPluginCrashed = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 13, IntPtr.Zero);
            }
            if(m_OnRenderViewReady != null) {
                m_OnRenderViewReady = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 14, IntPtr.Zero);
            }
            if(m_OnRenderProcessTerminated != null) {
                m_OnRenderProcessTerminated = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 15, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the UI thread before browser navigation. Return true (1) to
        /// cancel the navigation or false (0) to allow the navigation to proceed. The
        /// |Request| object cannot be modified in this callback.
        /// CfxLoadHandler.OnLoadingStateChange will be called twice in all cases.
        /// If the navigation is allowed CfxLoadHandler.OnLoadStart and
        /// CfxLoadHandler.OnLoadEnd will be called. If the navigation is canceled
        /// CfxLoadHandler.OnLoadError will be called with an |ErrorCode| value of
        /// ERR_ABORTED.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeBrowseEventHandler(object sender, CfxOnBeforeBrowseEventArgs e);

        /// <summary>
        /// Called on the UI thread before browser navigation. Return true (1) to
        /// cancel the navigation or false (0) to allow the navigation to proceed. The
        /// |Request| object cannot be modified in this callback.
        /// CfxLoadHandler.OnLoadingStateChange will be called twice in all cases.
        /// If the navigation is allowed CfxLoadHandler.OnLoadStart and
        /// CfxLoadHandler.OnLoadEnd will be called. If the navigation is canceled
        /// CfxLoadHandler.OnLoadError will be called with an |ErrorCode| value of
        /// ERR_ABORTED.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeBrowseEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_is_redirect;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeBrowseEventArgs(IntPtr browser, IntPtr frame, IntPtr request, int is_redirect) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_is_redirect = is_redirect;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the IsRedirect parameter for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
            /// </summary>
            public bool IsRedirect {
                get {
                    CheckAccess();
                    return 0 != m_is_redirect;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, IsRedirect={{{3}}}", Browser, Frame, Request, IsRedirect);
            }
        }

        /// <summary>
        /// Called on the UI thread before OnBeforeBrowse in certain limited cases
        /// where navigating a new or different browser might be desirable. This
        /// includes user-initiated navigation that might open in a special way (e.g.
        /// links clicked via middle-click or ctrl + left-click) and certain types of
        /// cross-origin navigation initiated from the renderer process (e.g.
        /// navigating the top-level frame to/from a file URL). The |Browser| and
        /// |Frame| values represent the source of the navigation. The
        /// |TargetDisposition| value indicates where the user intended to navigate
        /// the browser based on standard Chromium behaviors (e.g. current tab, new
        /// tab, etc). The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event). Return
        /// true (1) to cancel the navigation or false (0) to allow the navigation to
        /// proceed in the source browser's top-level frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnOpenUrlfromTabEventHandler(object sender, CfxOnOpenUrlfromTabEventArgs e);

        /// <summary>
        /// Called on the UI thread before OnBeforeBrowse in certain limited cases
        /// where navigating a new or different browser might be desirable. This
        /// includes user-initiated navigation that might open in a special way (e.g.
        /// links clicked via middle-click or ctrl + left-click) and certain types of
        /// cross-origin navigation initiated from the renderer process (e.g.
        /// navigating the top-level frame to/from a file URL). The |Browser| and
        /// |Frame| values represent the source of the navigation. The
        /// |TargetDisposition| value indicates where the user intended to navigate
        /// the browser based on standard Chromium behaviors (e.g. current tab, new
        /// tab, etc). The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event). Return
        /// true (1) to cancel the navigation or false (0) to allow the navigation to
        /// proceed in the source browser's top-level frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnOpenUrlfromTabEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_target_url_str;
            internal int m_target_url_length;
            internal string m_target_url;
            internal int m_target_disposition;
            internal int m_user_gesture;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnOpenUrlfromTabEventArgs(IntPtr browser, IntPtr frame, IntPtr target_url_str, int target_url_length, int target_disposition, int user_gesture) {
                m_browser = browser;
                m_frame = frame;
                m_target_url_str = target_url_str;
                m_target_url_length = target_url_length;
                m_target_disposition = target_disposition;
                m_user_gesture = user_gesture;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the TargetUrl parameter for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
            /// </summary>
            public string TargetUrl {
                get {
                    CheckAccess();
                    m_target_url = StringFunctions.PtrToStringUni(m_target_url_str, m_target_url_length);
                    return m_target_url;
                }
            }
            /// <summary>
            /// Get the TargetDisposition parameter for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
            /// </summary>
            public CfxWindowOpenDisposition TargetDisposition {
                get {
                    CheckAccess();
                    return (CfxWindowOpenDisposition)m_target_disposition;
                }
            }
            /// <summary>
            /// Get the UserGesture parameter for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
            /// </summary>
            public bool UserGesture {
                get {
                    CheckAccess();
                    return 0 != m_user_gesture;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnOpenUrlfromTab"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, TargetUrl={{{2}}}, TargetDisposition={{{3}}}, UserGesture={{{4}}}", Browser, Frame, TargetUrl, TargetDisposition, UserGesture);
            }
        }

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Request|
        /// object may be modified. Return RV_CONTINUE to continue the request
        /// immediately. Return RV_CONTINUE_ASYNC and call CfxRequestCallback::
        /// cont() at a later time to continue or cancel the request asynchronously.
        /// Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeResourceLoadEventHandler(object sender, CfxOnBeforeResourceLoadEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Request|
        /// object may be modified. Return RV_CONTINUE to continue the request
        /// immediately. Return RV_CONTINUE_ASYNC and call CfxRequestCallback::
        /// cont() at a later time to continue or cancel the request asynchronously.
        /// Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeResourceLoadEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_callback;
            internal CfxRequestCallback m_callback_wrapped;

            internal CfxReturnValue m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeResourceLoadEventArgs(IntPtr browser, IntPtr frame, IntPtr request, IntPtr callback) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxRequestCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxRequestCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnBeforeResourceLoad"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxReturnValue returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Callback={{{3}}}", Browser, Frame, Request, Callback);
            }
        }

        /// <summary>
        /// Called on the IO thread before a resource is loaded. To allow the resource
        /// to load normally return NULL. To specify a handler for the resource return
        /// a CfxResourceHandler object. The |Request| object should not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetResourceHandlerEventHandler(object sender, CfxGetResourceHandlerEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource is loaded. To allow the resource
        /// to load normally return NULL. To specify a handler for the resource return
        /// a CfxResourceHandler object. The |Request| object should not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetResourceHandlerEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;

            internal CfxResourceHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetResourceHandlerEventArgs(IntPtr browser, IntPtr frame, IntPtr request) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.GetResourceHandler"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}", Browser, Frame, Request);
            }
        }

        /// <summary>
        /// Called on the IO thread when a resource load is redirected. The |Request|
        /// parameter will contain the old URL and other request-related information.
        /// The |Response| parameter will contain the response that resulted in the
        /// redirect. The |NewUrl| parameter will contain the new URL and can be
        /// changed if desired. The |Request| object cannot be modified in this
        /// callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceRedirectEventHandler(object sender, CfxOnResourceRedirectEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource load is redirected. The |Request|
        /// parameter will contain the old URL and other request-related information.
        /// The |Response| parameter will contain the response that resulted in the
        /// redirect. The |NewUrl| parameter will contain the new URL and can be
        /// changed if desired. The |Request| object cannot be modified in this
        /// callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnResourceRedirectEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;
            internal IntPtr m_new_url_str;
            internal int m_new_url_length;
            internal string m_new_url_wrapped;
            internal bool m_new_url_changed;

            internal CfxOnResourceRedirectEventArgs(IntPtr browser, IntPtr frame, IntPtr request, IntPtr response, IntPtr new_url_str, int new_url_length) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_response = response;
                m_new_url_str = new_url_str;
                m_new_url_length = new_url_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Get or set the NewUrl parameter for the <see cref="CfxRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public string NewUrl {
                get {
                    CheckAccess();
                    if(!m_new_url_changed && m_new_url_wrapped == null) {
                        m_new_url_wrapped = StringFunctions.PtrToStringUni(m_new_url_str, m_new_url_length);
                    }
                    return m_new_url_wrapped;
                }
                set {
                    CheckAccess();
                    m_new_url_wrapped = value;
                    m_new_url_changed = true;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Response={{{3}}}, NewUrl={{{4}}}", Browser, Frame, Request, Response, NewUrl);
            }
        }

        /// <summary>
        /// Called on the IO thread when a resource response is received. To allow the
        /// resource to load normally return false (0). To redirect or retry the
        /// resource modify |Request| (url, headers or post body) and return true (1).
        /// The |Response| object cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceResponseEventHandler(object sender, CfxOnResourceResponseEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource response is received. To allow the
        /// resource to load normally return false (0). To redirect or retry the
        /// resource modify |Request| (url, headers or post body) and return true (1).
        /// The |Response| object cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnResourceResponseEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnResourceResponseEventArgs(IntPtr browser, IntPtr frame, IntPtr request, IntPtr response) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_response = response;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnResourceResponse"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Response={{{3}}}", Browser, Frame, Request, Response);
            }
        }

        /// <summary>
        /// Called on the IO thread to optionally filter resource response content.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetResourceResponseFilterEventHandler(object sender, CfxGetResourceResponseFilterEventArgs e);

        /// <summary>
        /// Called on the IO thread to optionally filter resource response content.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetResourceResponseFilterEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;

            internal CfxResponseFilter m_returnValue;
            private bool returnValueSet;

            internal CfxGetResourceResponseFilterEventArgs(IntPtr browser, IntPtr frame, IntPtr request, IntPtr response) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_response = response;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.GetResourceResponseFilter"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxResponseFilter returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Response={{{3}}}", Browser, Frame, Request, Response);
            }
        }

        /// <summary>
        /// Called on the IO thread when a resource load has completed. |Request| and
        /// |Response| represent the request and response respectively and cannot be
        /// modified in this callback. |Status| indicates the load completion status.
        /// |ReceivedContentLength| is the number of response bytes actually read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceLoadCompleteEventHandler(object sender, CfxOnResourceLoadCompleteEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource load has completed. |Request| and
        /// |Response| represent the request and response respectively and cannot be
        /// modified in this callback. |Status| indicates the load completion status.
        /// |ReceivedContentLength| is the number of response bytes actually read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnResourceLoadCompleteEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;
            internal int m_status;
            internal long m_received_content_length;

            internal CfxOnResourceLoadCompleteEventArgs(IntPtr browser, IntPtr frame, IntPtr request, IntPtr response, int status, long received_content_length) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_response = response;
                m_status = status;
                m_received_content_length = received_content_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Get the Status parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxUrlRequestStatus Status {
                get {
                    CheckAccess();
                    return (CfxUrlRequestStatus)m_status;
                }
            }
            /// <summary>
            /// Get the ReceivedContentLength parameter for the <see cref="CfxRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public long ReceivedContentLength {
                get {
                    CheckAccess();
                    return m_received_content_length;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, Response={{{3}}}, Status={{{4}}}, ReceivedContentLength={{{5}}}", Browser, Frame, Request, Response, Status, ReceivedContentLength);
            }
        }

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. |Realm| is the realm of the
        /// challenge and may be NULL. |Scheme| is the authentication scheme used, such
        /// as "basic" or "digest", and will be NULL if the source of the request is an
        /// FTP server. Return true (1) to continue the request and call
        /// CfxAuthCallback.Continue() either in this function or at a later time when
        /// the authentication information is available. Return false (0) to cancel the
        /// request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxRequestHandlerGetAuthCredentialsEventHandler(object sender, CfxRequestHandlerGetAuthCredentialsEventArgs e);

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |IsProxy| indicates whether the host is a proxy server. |Host| contains the
        /// hostname and |Port| contains the port number. |Realm| is the realm of the
        /// challenge and may be NULL. |Scheme| is the authentication scheme used, such
        /// as "basic" or "digest", and will be NULL if the source of the request is an
        /// FTP server. Return true (1) to continue the request and call
        /// CfxAuthCallback.Continue() either in this function or at a later time when
        /// the authentication information is available. Return false (0) to cancel the
        /// request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxRequestHandlerGetAuthCredentialsEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
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

            internal CfxRequestHandlerGetAuthCredentialsEventArgs(IntPtr browser, IntPtr frame, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback) {
                m_browser = browser;
                m_frame = frame;
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
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the IsProxy parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public bool IsProxy {
                get {
                    CheckAccess();
                    return 0 != m_isProxy;
                }
            }
            /// <summary>
            /// Get the Host parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public string Host {
                get {
                    CheckAccess();
                    m_host = StringFunctions.PtrToStringUni(m_host_str, m_host_length);
                    return m_host;
                }
            }
            /// <summary>
            /// Get the Port parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public int Port {
                get {
                    CheckAccess();
                    return m_port;
                }
            }
            /// <summary>
            /// Get the Realm parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public string Realm {
                get {
                    CheckAccess();
                    m_realm = StringFunctions.PtrToStringUni(m_realm_str, m_realm_length);
                    return m_realm;
                }
            }
            /// <summary>
            /// Get the Scheme parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public string Scheme {
                get {
                    CheckAccess();
                    m_scheme = StringFunctions.PtrToStringUni(m_scheme_str, m_scheme_length);
                    return m_scheme;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public CfxAuthCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxAuthCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, IsProxy={{{2}}}, Host={{{3}}}, Port={{{4}}}, Realm={{{5}}}, Scheme={{{6}}}, Callback={{{7}}}", Browser, Frame, IsProxy, Host, Port, Realm, Scheme, Callback);
            }
        }

        /// <summary>
        /// Called on the IO thread when JavaScript requests a specific storage quota
        /// size via the webkitStorageInfo.requestQuota function. |OriginUrl| is the
        /// origin of the page making the request. |NewSize| is the requested quota
        /// size in bytes. Return true (1) to continue the request and call
        /// CfxRequestCallback.Continue() either in this function or at a later time to
        /// grant or deny the request. Return false (0) to cancel the request
        /// immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnQuotaRequestEventHandler(object sender, CfxOnQuotaRequestEventArgs e);

        /// <summary>
        /// Called on the IO thread when JavaScript requests a specific storage quota
        /// size via the webkitStorageInfo.requestQuota function. |OriginUrl| is the
        /// origin of the page making the request. |NewSize| is the requested quota
        /// size in bytes. Return true (1) to continue the request and call
        /// CfxRequestCallback.Continue() either in this function or at a later time to
        /// grant or deny the request. Return false (0) to cancel the request
        /// immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnQuotaRequestEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_origin_url_str;
            internal int m_origin_url_length;
            internal string m_origin_url;
            internal long m_new_size;
            internal IntPtr m_callback;
            internal CfxRequestCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnQuotaRequestEventArgs(IntPtr browser, IntPtr origin_url_str, int origin_url_length, long new_size, IntPtr callback) {
                m_browser = browser;
                m_origin_url_str = origin_url_str;
                m_origin_url_length = origin_url_length;
                m_new_size = new_size;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnQuotaRequest"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the OriginUrl parameter for the <see cref="CfxRequestHandler.OnQuotaRequest"/> callback.
            /// </summary>
            public string OriginUrl {
                get {
                    CheckAccess();
                    m_origin_url = StringFunctions.PtrToStringUni(m_origin_url_str, m_origin_url_length);
                    return m_origin_url;
                }
            }
            /// <summary>
            /// Get the NewSize parameter for the <see cref="CfxRequestHandler.OnQuotaRequest"/> callback.
            /// </summary>
            public long NewSize {
                get {
                    CheckAccess();
                    return m_new_size;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxRequestHandler.OnQuotaRequest"/> callback.
            /// </summary>
            public CfxRequestCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxRequestCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnQuotaRequest"/> callback.
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
                return String.Format("Browser={{{0}}}, OriginUrl={{{1}}}, NewSize={{{2}}}, Callback={{{3}}}", Browser, OriginUrl, NewSize, Callback);
            }
        }

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an unknown
        /// protocol component. Set |AllowOsExecution| to true (1) to attempt
        /// execution via the registered OS protocol handler, if any. SECURITY WARNING:
        /// YOU SHOULD USE THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR
        /// OTHER URL ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnProtocolExecutionEventHandler(object sender, CfxOnProtocolExecutionEventArgs e);

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an unknown
        /// protocol component. Set |AllowOsExecution| to true (1) to attempt
        /// execution via the registered OS protocol handler, if any. SECURITY WARNING:
        /// YOU SHOULD USE THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR
        /// OTHER URL ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnProtocolExecutionEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_url_str;
            internal int m_url_length;
            internal string m_url;
            internal int m_allow_os_execution;

            internal CfxOnProtocolExecutionEventArgs(IntPtr browser, IntPtr url_str, int url_length) {
                m_browser = browser;
                m_url_str = url_str;
                m_url_length = url_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Url parameter for the <see cref="CfxRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public string Url {
                get {
                    CheckAccess();
                    m_url = StringFunctions.PtrToStringUni(m_url_str, m_url_length);
                    return m_url;
                }
            }
            /// <summary>
            /// Set the AllowOsExecution out parameter for the <see cref="CfxRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public bool AllowOsExecution {
                set {
                    CheckAccess();
                    m_allow_os_execution = value ? 1 : 0;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Url={{{1}}}", Browser, Url);
            }
        }

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an invalid SSL
        /// certificate. Return true (1) and call CfxRequestCallback.Continue() either
        /// in this function or at a later time to continue or cancel the request.
        /// Return false (0) to cancel the request immediately. If
        /// CfxSettings.IgnoreCertificateErrors is set all invalid certificates will
        /// be accepted without calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnCertificateErrorEventHandler(object sender, CfxOnCertificateErrorEventArgs e);

        /// <summary>
        /// Called on the UI thread to handle requests for URLs with an invalid SSL
        /// certificate. Return true (1) and call CfxRequestCallback.Continue() either
        /// in this function or at a later time to continue or cancel the request.
        /// Return false (0) to cancel the request immediately. If
        /// CfxSettings.IgnoreCertificateErrors is set all invalid certificates will
        /// be accepted without calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnCertificateErrorEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_cert_error;
            internal IntPtr m_request_url_str;
            internal int m_request_url_length;
            internal string m_request_url;
            internal IntPtr m_ssl_info;
            internal CfxSslInfo m_ssl_info_wrapped;
            internal IntPtr m_callback;
            internal CfxRequestCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnCertificateErrorEventArgs(IntPtr browser, int cert_error, IntPtr request_url_str, int request_url_length, IntPtr ssl_info, IntPtr callback) {
                m_browser = browser;
                m_cert_error = cert_error;
                m_request_url_str = request_url_str;
                m_request_url_length = request_url_length;
                m_ssl_info = ssl_info;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the CertError parameter for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
            /// </summary>
            public CfxErrorCode CertError {
                get {
                    CheckAccess();
                    return (CfxErrorCode)m_cert_error;
                }
            }
            /// <summary>
            /// Get the RequestUrl parameter for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
            /// </summary>
            public string RequestUrl {
                get {
                    CheckAccess();
                    m_request_url = StringFunctions.PtrToStringUni(m_request_url_str, m_request_url_length);
                    return m_request_url;
                }
            }
            /// <summary>
            /// Get the SslInfo parameter for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
            /// </summary>
            public CfxSslInfo SslInfo {
                get {
                    CheckAccess();
                    if(m_ssl_info_wrapped == null) m_ssl_info_wrapped = CfxSslInfo.Wrap(m_ssl_info);
                    return m_ssl_info_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
            /// </summary>
            public CfxRequestCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxRequestCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnCertificateError"/> callback.
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
                return String.Format("Browser={{{0}}}, CertError={{{1}}}, RequestUrl={{{2}}}, SslInfo={{{3}}}, Callback={{{4}}}", Browser, CertError, RequestUrl, SslInfo, Callback);
            }
        }

        /// <summary>
        /// Called on the UI thread when a client certificate is being requested for
        /// authentication. Return false (0) to use the default behavior and
        /// automatically select the first certificate available. Return true (1) and
        /// call CfxSelectClientCertificateCallback.Select either in this
        /// function or at a later time to select a certificate. Do not call Select or
        /// call it with NULL to continue without using any certificate. |IsProxy|
        /// indicates whether the host is an HTTPS proxy or the origin server. |Host|
        /// and |Port| contains the hostname and port of the SSL server. |Certificates|
        /// is the list of certificates to choose from; this list has already been
        /// pruned by Chromium so that it only contains certificates from issuers that
        /// the server trusts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnSelectClientCertificateEventHandler(object sender, CfxOnSelectClientCertificateEventArgs e);

        /// <summary>
        /// Called on the UI thread when a client certificate is being requested for
        /// authentication. Return false (0) to use the default behavior and
        /// automatically select the first certificate available. Return true (1) and
        /// call CfxSelectClientCertificateCallback.Select either in this
        /// function or at a later time to select a certificate. Do not call Select or
        /// call it with NULL to continue without using any certificate. |IsProxy|
        /// indicates whether the host is an HTTPS proxy or the origin server. |Host|
        /// and |Port| contains the hostname and port of the SSL server. |Certificates|
        /// is the list of certificates to choose from; this list has already been
        /// pruned by Chromium so that it only contains certificates from issuers that
        /// the server trusts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnSelectClientCertificateEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_isProxy;
            internal IntPtr m_host_str;
            internal int m_host_length;
            internal string m_host;
            internal int m_port;
            internal IntPtr[] m_certificates;
            internal CfxX509Certificate[] m_certificates_managed;
            internal IntPtr m_callback;
            internal CfxSelectClientCertificateCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnSelectClientCertificateEventArgs(IntPtr browser, int isProxy, IntPtr host_str, int host_length, int port, IntPtr certificates, UIntPtr certificatesCount, IntPtr callback) {
                m_browser = browser;
                m_isProxy = isProxy;
                m_host_str = host_str;
                m_host_length = host_length;
                m_port = port;
                m_certificates = new IntPtr[(ulong)certificatesCount];
                if(m_certificates.Length > 0) {
                    System.Runtime.InteropServices.Marshal.Copy(certificates, m_certificates, 0, (int)certificatesCount);
                }
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IsProxy parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public bool IsProxy {
                get {
                    CheckAccess();
                    return 0 != m_isProxy;
                }
            }
            /// <summary>
            /// Get the Host parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public string Host {
                get {
                    CheckAccess();
                    m_host = StringFunctions.PtrToStringUni(m_host_str, m_host_length);
                    return m_host;
                }
            }
            /// <summary>
            /// Get the Port parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public int Port {
                get {
                    CheckAccess();
                    return m_port;
                }
            }
            /// <summary>
            /// Get the Certificates parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public CfxX509Certificate[] Certificates {
                get {
                    CheckAccess();
                    if(m_certificates_managed == null) {
                        m_certificates_managed = new CfxX509Certificate[m_certificates.Length];
                        for(int i = 0; i < m_certificates.Length; ++i) {
                            m_certificates_managed[i] = CfxX509Certificate.Wrap(m_certificates[i]);
                        }
                    }
                    return m_certificates_managed;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
            /// </summary>
            public CfxSelectClientCertificateCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxSelectClientCertificateCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.OnSelectClientCertificate"/> callback.
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
                return String.Format("Browser={{{0}}}, IsProxy={{{1}}}, Host={{{2}}}, Port={{{3}}}, Certificates={{{4}}}, Callback={{{5}}}", Browser, IsProxy, Host, Port, Certificates, Callback);
            }
        }

        /// <summary>
        /// Called on the browser process UI thread when a plugin has crashed.
        /// |PluginPath| is the path of the plugin that crashed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPluginCrashedEventHandler(object sender, CfxOnPluginCrashedEventArgs e);

        /// <summary>
        /// Called on the browser process UI thread when a plugin has crashed.
        /// |PluginPath| is the path of the plugin that crashed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPluginCrashedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_plugin_path_str;
            internal int m_plugin_path_length;
            internal string m_plugin_path;

            internal CfxOnPluginCrashedEventArgs(IntPtr browser, IntPtr plugin_path_str, int plugin_path_length) {
                m_browser = browser;
                m_plugin_path_str = plugin_path_str;
                m_plugin_path_length = plugin_path_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnPluginCrashed"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the PluginPath parameter for the <see cref="CfxRequestHandler.OnPluginCrashed"/> callback.
            /// </summary>
            public string PluginPath {
                get {
                    CheckAccess();
                    m_plugin_path = StringFunctions.PtrToStringUni(m_plugin_path_str, m_plugin_path_length);
                    return m_plugin_path;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, PluginPath={{{1}}}", Browser, PluginPath);
            }
        }

        /// <summary>
        /// Called on the browser process UI thread when the render view associated
        /// with |Browser| is ready to receive/handle IPC messages in the render
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRenderViewReadyEventHandler(object sender, CfxOnRenderViewReadyEventArgs e);

        /// <summary>
        /// Called on the browser process UI thread when the render view associated
        /// with |Browser| is ready to receive/handle IPC messages in the render
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRenderViewReadyEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnRenderViewReadyEventArgs(IntPtr browser) {
                m_browser = browser;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnRenderViewReady"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

        /// <summary>
        /// Called on the browser process UI thread when the render process terminates
        /// unexpectedly. |Status| indicates how the process terminated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRenderProcessTerminatedEventHandler(object sender, CfxOnRenderProcessTerminatedEventArgs e);

        /// <summary>
        /// Called on the browser process UI thread when the render process terminates
        /// unexpectedly. |Status| indicates how the process terminated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRenderProcessTerminatedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_status;

            internal CfxOnRenderProcessTerminatedEventArgs(IntPtr browser, int status) {
                m_browser = browser;
                m_status = status;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.OnRenderProcessTerminated"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Status parameter for the <see cref="CfxRequestHandler.OnRenderProcessTerminated"/> callback.
            /// </summary>
            public CfxTerminationStatus Status {
                get {
                    CheckAccess();
                    return (CfxTerminationStatus)m_status;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Status={{{1}}}", Browser, Status);
            }
        }

    }
}
