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
            get_resource_request_handler_native = get_resource_request_handler;
            get_auth_credentials_native = get_auth_credentials;
            on_quota_request_native = on_quota_request;
            on_certificate_error_native = on_certificate_error;
            on_select_client_certificate_native = on_select_client_certificate;
            on_plugin_crashed_native = on_plugin_crashed;
            on_render_view_ready_native = on_render_view_ready;
            on_render_process_terminated_native = on_render_process_terminated;

            on_before_browse_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_browse_native);
            on_open_urlfrom_tab_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_open_urlfrom_tab_native);
            get_resource_request_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_request_handler_native);
            get_auth_credentials_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_auth_credentials_native);
            on_quota_request_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_quota_request_native);
            on_certificate_error_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_certificate_error_native);
            on_select_client_certificate_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_select_client_certificate_native);
            on_plugin_crashed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_plugin_crashed_native);
            on_render_view_ready_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_view_ready_native);
            on_render_process_terminated_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_process_terminated_native);
        }

        // on_before_browse
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_browse_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int user_gesture, int is_redirect);
        private static on_before_browse_delegate on_before_browse_native;
        private static IntPtr on_before_browse_native_ptr;

        internal static void on_before_browse(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int user_gesture, int is_redirect) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxOnBeforeBrowseEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_user_gesture = user_gesture;
            e.m_is_redirect = is_redirect;
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
            var e = new CfxOnOpenUrlfromTabEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_target_url_str = target_url_str;
            e.m_target_url_length = target_url_length;
            e.m_target_disposition = target_disposition;
            e.m_user_gesture = user_gesture;
            self.m_OnOpenUrlfromTab?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_resource_request_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_resource_request_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_navigation, int is_download, IntPtr request_initiator_str, int request_initiator_length, out int disable_default_handling);
        private static get_resource_request_handler_delegate get_resource_request_handler_native;
        private static IntPtr get_resource_request_handler_native_ptr;

        internal static void get_resource_request_handler(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_navigation, int is_download, IntPtr request_initiator_str, int request_initiator_length, out int disable_default_handling) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                disable_default_handling = default(int);
                return;
            }
            var e = new CfxRequestHandlerGetResourceRequestHandlerEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_is_navigation = is_navigation;
            e.m_is_download = is_download;
            e.m_request_initiator_str = request_initiator_str;
            e.m_request_initiator_length = request_initiator_length;
            self.m_GetResourceRequestHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            disable_default_handling = e.m_disable_default_handling;
            __retval = CfxResourceRequestHandler.Unwrap(e.m_returnValue);
        }

        // get_auth_credentials
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_auth_credentials_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr origin_url_str, int origin_url_length, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release);
        private static get_auth_credentials_delegate get_auth_credentials_native;
        private static IntPtr get_auth_credentials_native_ptr;

        internal static void get_auth_credentials(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr origin_url_str, int origin_url_length, int isProxy, IntPtr host_str, int host_length, int port, IntPtr realm_str, int realm_length, IntPtr scheme_str, int scheme_length, IntPtr callback, out int callback_release) {
            var self = (CfxRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxRequestHandlerGetAuthCredentialsEventArgs();
            e.m_browser = browser;
            e.m_origin_url_str = origin_url_str;
            e.m_origin_url_length = origin_url_length;
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
            browser_release = e.m_browser_wrapped == null? 1 : 0;
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
            var e = new CfxOnQuotaRequestEventArgs();
            e.m_browser = browser;
            e.m_origin_url_str = origin_url_str;
            e.m_origin_url_length = origin_url_length;
            e.m_new_size = new_size;
            e.m_callback = callback;
            self.m_OnQuotaRequest?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
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
            var e = new CfxOnCertificateErrorEventArgs();
            e.m_browser = browser;
            e.m_cert_error = cert_error;
            e.m_request_url_str = request_url_str;
            e.m_request_url_length = request_url_length;
            e.m_ssl_info = ssl_info;
            e.m_callback = callback;
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
            var e = new CfxOnSelectClientCertificateEventArgs();
            e.m_browser = browser;
            e.m_isProxy = isProxy;
            e.m_host_str = host_str;
            e.m_host_length = host_length;
            e.m_port = port;
            e.m_certificates = new IntPtr[(ulong)certificatesCount];
            if(e.m_certificates.Length > 0) {
                System.Runtime.InteropServices.Marshal.Copy(certificates, e.m_certificates, 0, (int)certificatesCount);
            }
            e.m_callback = callback;
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
            var e = new CfxOnPluginCrashedEventArgs();
            e.m_browser = browser;
            e.m_plugin_path_str = plugin_path_str;
            e.m_plugin_path_length = plugin_path_length;
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
            var e = new CfxOnRenderViewReadyEventArgs();
            e.m_browser = browser;
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
            var e = new CfxOnRenderProcessTerminatedEventArgs();
            e.m_browser = browser;
            e.m_status = status;
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
        /// ERR_ABORTED. The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event).
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
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request. |Request| represents the request contents and cannot be modified
        /// in this callback. |IsNavigation| will be true (1) if the resource request
        /// is a navigation. |IsDownload| will be true (1) if the resource request is
        /// a download. |RequestInitiator| is the origin (scheme + domain) of the page
        /// that initiated the request. Set |DisableDefaultHandling| to true (1) to
        /// disable default handling of the request, in which case it will need to be
        /// handled via CfxResourceRequestHandler.GetResourceHandler or it will
        /// be canceled. To allow the resource load to proceed with default handling
        /// return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. If this callback returns NULL the
        /// same function will be called on the associated CfxRequestContextHandler,
        /// if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxRequestHandlerGetResourceRequestHandlerEventHandler GetResourceRequestHandler {
            add {
                lock(eventLock) {
                    if(m_GetResourceRequestHandler == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, get_resource_request_handler_native_ptr);
                    }
                    m_GetResourceRequestHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceRequestHandler -= value;
                    if(m_GetResourceRequestHandler == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxRequestHandlerGetResourceRequestHandlerEventHandler m_GetResourceRequestHandler;

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |OriginUrl| is the origin making this authentication request. |IsProxy|
        /// indicates whether the host is a proxy server. |Host| contains the hostname
        /// and |Port| contains the port number. |Realm| is the realm of the challenge
        /// and may be NULL. |Scheme| is the authentication scheme used, such as
        /// "basic" or "digest", and will be NULL if the source of the request is an
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, get_auth_credentials_native_ptr);
                    }
                    m_GetAuthCredentials += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetAuthCredentials -= value;
                    if(m_GetAuthCredentials == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, on_quota_request_native_ptr);
                    }
                    m_OnQuotaRequest += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnQuotaRequest -= value;
                    if(m_OnQuotaRequest == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnQuotaRequestEventHandler m_OnQuotaRequest;

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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, on_certificate_error_native_ptr);
                    }
                    m_OnCertificateError += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCertificateError -= value;
                    if(m_OnCertificateError == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, on_select_client_certificate_native_ptr);
                    }
                    m_OnSelectClientCertificate += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnSelectClientCertificate -= value;
                    if(m_OnSelectClientCertificate == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, on_plugin_crashed_native_ptr);
                    }
                    m_OnPluginCrashed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPluginCrashed -= value;
                    if(m_OnPluginCrashed == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, on_render_view_ready_native_ptr);
                    }
                    m_OnRenderViewReady += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderViewReady -= value;
                    if(m_OnRenderViewReady == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, IntPtr.Zero);
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
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, on_render_process_terminated_native_ptr);
                    }
                    m_OnRenderProcessTerminated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderProcessTerminated -= value;
                    if(m_OnRenderProcessTerminated == null) {
                        CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, IntPtr.Zero);
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
            if(m_GetResourceRequestHandler != null) {
                m_GetResourceRequestHandler = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetAuthCredentials != null) {
                m_GetAuthCredentials = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnQuotaRequest != null) {
                m_OnQuotaRequest = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnCertificateError != null) {
                m_OnCertificateError = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnSelectClientCertificate != null) {
                m_OnSelectClientCertificate = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnPluginCrashed != null) {
                m_OnPluginCrashed = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_OnRenderViewReady != null) {
                m_OnRenderViewReady = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_OnRenderProcessTerminated != null) {
                m_OnRenderProcessTerminated = null;
                CfxApi.RequestHandler.cfx_request_handler_set_callback(NativePtr, 9, IntPtr.Zero);
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
        /// ERR_ABORTED. The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event).
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
        /// ERR_ABORTED. The |UserGesture| value will be true (1) if the browser
        /// navigated via explicit user gesture (e.g. clicking a link) or false (0) if
        /// it navigated automatically (e.g. via the DomContentLoaded event).
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
            internal int m_user_gesture;
            internal int m_is_redirect;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeBrowseEventArgs() {}

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
            /// Get the UserGesture parameter for the <see cref="CfxRequestHandler.OnBeforeBrowse"/> callback.
            /// </summary>
            public bool UserGesture {
                get {
                    CheckAccess();
                    return 0 != m_user_gesture;
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, UserGesture={{{3}}}, IsRedirect={{{4}}}", Browser, Frame, Request, UserGesture, IsRedirect);
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

            internal CfxOnOpenUrlfromTabEventArgs() {}

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
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request. |Request| represents the request contents and cannot be modified
        /// in this callback. |IsNavigation| will be true (1) if the resource request
        /// is a navigation. |IsDownload| will be true (1) if the resource request is
        /// a download. |RequestInitiator| is the origin (scheme + domain) of the page
        /// that initiated the request. Set |DisableDefaultHandling| to true (1) to
        /// disable default handling of the request, in which case it will need to be
        /// handled via CfxResourceRequestHandler.GetResourceHandler or it will
        /// be canceled. To allow the resource load to proceed with default handling
        /// return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. If this callback returns NULL the
        /// same function will be called on the associated CfxRequestContextHandler,
        /// if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxRequestHandlerGetResourceRequestHandlerEventHandler(object sender, CfxRequestHandlerGetResourceRequestHandlerEventArgs e);

        /// <summary>
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request. |Request| represents the request contents and cannot be modified
        /// in this callback. |IsNavigation| will be true (1) if the resource request
        /// is a navigation. |IsDownload| will be true (1) if the resource request is
        /// a download. |RequestInitiator| is the origin (scheme + domain) of the page
        /// that initiated the request. Set |DisableDefaultHandling| to true (1) to
        /// disable default handling of the request, in which case it will need to be
        /// handled via CfxResourceRequestHandler.GetResourceHandler or it will
        /// be canceled. To allow the resource load to proceed with default handling
        /// return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. If this callback returns NULL the
        /// same function will be called on the associated CfxRequestContextHandler,
        /// if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxRequestHandlerGetResourceRequestHandlerEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_is_navigation;
            internal int m_is_download;
            internal IntPtr m_request_initiator_str;
            internal int m_request_initiator_length;
            internal string m_request_initiator;
            internal int m_disable_default_handling;

            internal CfxResourceRequestHandler m_returnValue;
            private bool returnValueSet;

            internal CfxRequestHandlerGetResourceRequestHandlerEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the IsNavigation parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool IsNavigation {
                get {
                    CheckAccess();
                    return 0 != m_is_navigation;
                }
            }
            /// <summary>
            /// Get the IsDownload parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool IsDownload {
                get {
                    CheckAccess();
                    return 0 != m_is_download;
                }
            }
            /// <summary>
            /// Get the RequestInitiator parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public string RequestInitiator {
                get {
                    CheckAccess();
                    m_request_initiator = StringFunctions.PtrToStringUni(m_request_initiator_str, m_request_initiator_length);
                    return m_request_initiator;
                }
            }
            /// <summary>
            /// Set the DisableDefaultHandling out parameter for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool DisableDefaultHandling {
                set {
                    CheckAccess();
                    m_disable_default_handling = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestHandler.GetResourceRequestHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxResourceRequestHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, IsNavigation={{{3}}}, IsDownload={{{4}}}, RequestInitiator={{{5}}}", Browser, Frame, Request, IsNavigation, IsDownload, RequestInitiator);
            }
        }

        /// <summary>
        /// Called on the IO thread when the browser needs credentials from the user.
        /// |OriginUrl| is the origin making this authentication request. |IsProxy|
        /// indicates whether the host is a proxy server. |Host| contains the hostname
        /// and |Port| contains the port number. |Realm| is the realm of the challenge
        /// and may be NULL. |Scheme| is the authentication scheme used, such as
        /// "basic" or "digest", and will be NULL if the source of the request is an
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
        /// |OriginUrl| is the origin making this authentication request. |IsProxy|
        /// indicates whether the host is a proxy server. |Host| contains the hostname
        /// and |Port| contains the port number. |Realm| is the realm of the challenge
        /// and may be NULL. |Scheme| is the authentication scheme used, such as
        /// "basic" or "digest", and will be NULL if the source of the request is an
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
            internal IntPtr m_origin_url_str;
            internal int m_origin_url_length;
            internal string m_origin_url;
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

            internal CfxRequestHandlerGetAuthCredentialsEventArgs() {}

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
            /// Get the OriginUrl parameter for the <see cref="CfxRequestHandler.GetAuthCredentials"/> callback.
            /// </summary>
            public string OriginUrl {
                get {
                    CheckAccess();
                    m_origin_url = StringFunctions.PtrToStringUni(m_origin_url_str, m_origin_url_length);
                    return m_origin_url;
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
                return String.Format("Browser={{{0}}}, OriginUrl={{{1}}}, IsProxy={{{2}}}, Host={{{3}}}, Port={{{4}}}, Realm={{{5}}}, Scheme={{{6}}}, Callback={{{7}}}", Browser, OriginUrl, IsProxy, Host, Port, Realm, Scheme, Callback);
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

            internal CfxOnQuotaRequestEventArgs() {}

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

            internal CfxOnCertificateErrorEventArgs() {}

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

            internal CfxOnSelectClientCertificateEventArgs() {}

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

            internal CfxOnPluginCrashedEventArgs() {}

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

            internal CfxOnRenderViewReadyEventArgs() {}

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

            internal CfxOnRenderProcessTerminatedEventArgs() {}

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
