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
    /// functions of this structure will be called on the IO thread unless otherwise
    /// indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
    /// </remarks>
    public class CfxResourceRequestHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_cookie_access_filter_native = get_cookie_access_filter;
            on_before_resource_load_native = on_before_resource_load;
            get_resource_handler_native = get_resource_handler;
            on_resource_redirect_native = on_resource_redirect;
            on_resource_response_native = on_resource_response;
            get_resource_response_filter_native = get_resource_response_filter;
            on_resource_load_complete_native = on_resource_load_complete;
            on_protocol_execution_native = on_protocol_execution;

            get_cookie_access_filter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_cookie_access_filter_native);
            on_before_resource_load_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_resource_load_native);
            get_resource_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_handler_native);
            on_resource_redirect_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_redirect_native);
            on_resource_response_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_response_native);
            get_resource_response_filter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_response_filter_native);
            on_resource_load_complete_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_resource_load_complete_native);
            on_protocol_execution_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_protocol_execution_native);
        }

        // get_cookie_access_filter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_cookie_access_filter_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release);
        private static get_cookie_access_filter_delegate get_cookie_access_filter_native;
        private static IntPtr get_cookie_access_filter_native_ptr;

        internal static void get_cookie_access_filter(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release) {
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxGetCookieAccessFilterEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            self.m_GetCookieAccessFilter?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            __retval = CfxCookieAccessFilter.Unwrap(e.m_returnValue);
        }

        // on_before_resource_load
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_resource_load_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr callback, out int callback_release);
        private static on_before_resource_load_delegate on_before_resource_load_native;
        private static IntPtr on_before_resource_load_native_ptr;

        internal static void on_before_resource_load(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, IntPtr callback, out int callback_release) {
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnBeforeResourceLoadEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_callback = callback;
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
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxGetResourceHandlerEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
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
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceRedirectEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_response = response;
            e.m_new_url_str = new_url_str;
            e.m_new_url_length = new_url_length;
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
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceResponseEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_response = response;
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
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxGetResourceResponseFilterEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_response = response;
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
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                response_release = 1;
                return;
            }
            var e = new CfxOnResourceLoadCompleteEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_response = response;
            e.m_status = status;
            e.m_received_content_length = received_content_length;
            self.m_OnResourceLoadComplete?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            response_release = e.m_response_wrapped == null? 1 : 0;
        }

        // on_protocol_execution
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_protocol_execution_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, out int allow_os_execution);
        private static on_protocol_execution_delegate on_protocol_execution_native;
        private static IntPtr on_protocol_execution_native_ptr;

        internal static void on_protocol_execution(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, out int allow_os_execution) {
            var self = (CfxResourceRequestHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                allow_os_execution = default(int);
                return;
            }
            var e = new CfxOnProtocolExecutionEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            self.m_OnProtocolExecution?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            allow_os_execution = e.m_allow_os_execution;
        }

        public CfxResourceRequestHandler() : base(CfxApi.ResourceRequestHandler.cfx_resource_request_handler_ctor) {}

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To
        /// optionally filter cookies for the request return a
        /// CfxCookieAccessFilter object. The |Request| object cannot not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetCookieAccessFilterEventHandler GetCookieAccessFilter {
            add {
                lock(eventLock) {
                    if(m_GetCookieAccessFilter == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 0, get_cookie_access_filter_native_ptr);
                    }
                    m_GetCookieAccessFilter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetCookieAccessFilter -= value;
                    if(m_GetCookieAccessFilter == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetCookieAccessFilterEventHandler m_GetCookieAccessFilter;

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To redirect
        /// or change the resource load optionally modify |Request|. Modification of
        /// the request URL will be treated as a redirect. Return RV_CONTINUE to
        /// continue the request immediately. Return RV_CONTINUE_ASYNC and call
        /// CfxRequestCallback:: cont() at a later time to continue or cancel the
        /// request asynchronously. Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeResourceLoadEventHandler OnBeforeResourceLoad {
            add {
                lock(eventLock) {
                    if(m_OnBeforeResourceLoad == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 1, on_before_resource_load_native_ptr);
                    }
                    m_OnBeforeResourceLoad += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeResourceLoad -= value;
                    if(m_OnBeforeResourceLoad == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeResourceLoadEventHandler m_OnBeforeResourceLoad;

        /// <summary>
        /// Called on the IO thread before a resource is loaded. The |Browser| and
        /// |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource to load using the default network loader return NULL. To specify a
        /// handler for the resource return a CfxResourceHandler object. The
        /// |Request| object cannot not be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetResourceHandlerEventHandler GetResourceHandler {
            add {
                lock(eventLock) {
                    if(m_GetResourceHandler == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 2, get_resource_handler_native_ptr);
                    }
                    m_GetResourceHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceHandler -= value;
                    if(m_GetResourceHandler == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetResourceHandlerEventHandler m_GetResourceHandler;

        /// <summary>
        /// Called on the IO thread when a resource load is redirected. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. The
        /// |Request| parameter will contain the old URL and other request-related
        /// information. The |Response| parameter will contain the response that
        /// resulted in the redirect. The |NewUrl| parameter will contain the new URL
        /// and can be changed if desired. The |Request| and |Response| objects cannot
        /// be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceRedirectEventHandler OnResourceRedirect {
            add {
                lock(eventLock) {
                    if(m_OnResourceRedirect == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 3, on_resource_redirect_native_ptr);
                    }
                    m_OnResourceRedirect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceRedirect -= value;
                    if(m_OnResourceRedirect == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceRedirectEventHandler m_OnResourceRedirect;

        /// <summary>
        /// Called on the IO thread when a resource response is received. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource load to proceed without modification return false (0). To redirect
        /// or retry the resource load optionally modify |Request| and return true (1).
        /// Modification of the request URL will be treated as a redirect. Requests
        /// handled using the default network loader cannot be redirected in this
        /// callback. The |Response| object cannot be modified in this callback.
        /// 
        /// WARNING: Redirecting using this function is deprecated. Use
        /// OnBeforeResourceLoad or GetResourceHandler to perform redirects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceResponseEventHandler OnResourceResponse {
            add {
                lock(eventLock) {
                    if(m_OnResourceResponse == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 4, on_resource_response_native_ptr);
                    }
                    m_OnResourceResponse += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceResponse -= value;
                    if(m_OnResourceResponse == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceResponseEventHandler m_OnResourceResponse;

        /// <summary>
        /// Called on the IO thread to optionally filter resource response content. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetResourceResponseFilterEventHandler GetResourceResponseFilter {
            add {
                lock(eventLock) {
                    if(m_GetResourceResponseFilter == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 5, get_resource_response_filter_native_ptr);
                    }
                    m_GetResourceResponseFilter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceResponseFilter -= value;
                    if(m_GetResourceResponseFilter == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetResourceResponseFilterEventHandler m_GetResourceResponseFilter;

        /// <summary>
        /// Called on the IO thread when a resource load has completed. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// and |Response| represent the request and response respectively and cannot
        /// be modified in this callback. |Status| indicates the load completion
        /// status. |ReceivedContentLength| is the number of response bytes actually
        /// read. This function will be called for all requests, including requests
        /// that are aborted due to CEF shutdown or destruction of the associated
        /// browser. In cases where the associated browser is destroyed this callback
        /// may arrive after the CfxLifeSpanHandler.OnBeforeClose callback for
        /// that browser. The CfxFrame.IsValid function can be used to test for
        /// this situation, and care should be taken not to call |Browser| or |Frame|
        /// functions that modify state (like LoadURL, SendProcessMessage, etc.) if the
        /// frame is invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResourceLoadCompleteEventHandler OnResourceLoadComplete {
            add {
                lock(eventLock) {
                    if(m_OnResourceLoadComplete == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 6, on_resource_load_complete_native_ptr);
                    }
                    m_OnResourceLoadComplete += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResourceLoadComplete -= value;
                    if(m_OnResourceLoadComplete == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResourceLoadCompleteEventHandler m_OnResourceLoadComplete;

        /// <summary>
        /// Called on the IO thread to handle requests for URLs with an unknown
        /// protocol component. The |Browser| and |Frame| values represent the source
        /// of the request, and may be NULL for requests originating from service
        /// workers or CfxUrlRequest. |Request| cannot be modified in this callback.
        /// Set |AllowOsExecution| to true (1) to attempt execution via the
        /// registered OS protocol handler, if any. SECURITY WARNING: YOU SHOULD USE
        /// THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR OTHER URL
        /// ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnProtocolExecutionEventHandler OnProtocolExecution {
            add {
                lock(eventLock) {
                    if(m_OnProtocolExecution == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 7, on_protocol_execution_native_ptr);
                    }
                    m_OnProtocolExecution += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProtocolExecution -= value;
                    if(m_OnProtocolExecution == null) {
                        CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProtocolExecutionEventHandler m_OnProtocolExecution;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetCookieAccessFilter != null) {
                m_GetCookieAccessFilter = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforeResourceLoad != null) {
                m_OnBeforeResourceLoad = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetResourceHandler != null) {
                m_GetResourceHandler = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnResourceRedirect != null) {
                m_OnResourceRedirect = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnResourceResponse != null) {
                m_OnResourceResponse = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_GetResourceResponseFilter != null) {
                m_GetResourceResponseFilter = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnResourceLoadComplete != null) {
                m_OnResourceLoadComplete = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnProtocolExecution != null) {
                m_OnProtocolExecution = null;
                CfxApi.ResourceRequestHandler.cfx_resource_request_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To
        /// optionally filter cookies for the request return a
        /// CfxCookieAccessFilter object. The |Request| object cannot not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetCookieAccessFilterEventHandler(object sender, CfxGetCookieAccessFilterEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To
        /// optionally filter cookies for the request return a
        /// CfxCookieAccessFilter object. The |Request| object cannot not be
        /// modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetCookieAccessFilterEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;

            internal CfxCookieAccessFilter m_returnValue;
            private bool returnValueSet;

            internal CfxGetCookieAccessFilterEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.GetCookieAccessFilter"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.GetCookieAccessFilter"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.GetCookieAccessFilter"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceRequestHandler.GetCookieAccessFilter"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxCookieAccessFilter returnValue) {
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
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To redirect
        /// or change the resource load optionally modify |Request|. Modification of
        /// the request URL will be treated as a redirect. Return RV_CONTINUE to
        /// continue the request immediately. Return RV_CONTINUE_ASYNC and call
        /// CfxRequestCallback:: cont() at a later time to continue or cancel the
        /// request asynchronously. Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeResourceLoadEventHandler(object sender, CfxOnBeforeResourceLoadEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource request is loaded. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To redirect
        /// or change the resource load optionally modify |Request|. Modification of
        /// the request URL will be treated as a redirect. Return RV_CONTINUE to
        /// continue the request immediately. Return RV_CONTINUE_ASYNC and call
        /// CfxRequestCallback:: cont() at a later time to continue or cancel the
        /// request asynchronously. Return RV_CANCEL to cancel the request immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxOnBeforeResourceLoadEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceRequestHandler.OnBeforeResourceLoad"/> callback.
            /// </summary>
            public CfxRequestCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxRequestCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceRequestHandler.OnBeforeResourceLoad"/> callback.
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
        /// Called on the IO thread before a resource is loaded. The |Browser| and
        /// |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource to load using the default network loader return NULL. To specify a
        /// handler for the resource return a CfxResourceHandler object. The
        /// |Request| object cannot not be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetResourceHandlerEventHandler(object sender, CfxGetResourceHandlerEventArgs e);

        /// <summary>
        /// Called on the IO thread before a resource is loaded. The |Browser| and
        /// |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource to load using the default network loader return NULL. To specify a
        /// handler for the resource return a CfxResourceHandler object. The
        /// |Request| object cannot not be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxGetResourceHandlerEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.GetResourceHandler"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceRequestHandler.GetResourceHandler"/> callback.
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
        /// Called on the IO thread when a resource load is redirected. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. The
        /// |Request| parameter will contain the old URL and other request-related
        /// information. The |Response| parameter will contain the response that
        /// resulted in the redirect. The |NewUrl| parameter will contain the new URL
        /// and can be changed if desired. The |Request| and |Response| objects cannot
        /// be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceRedirectEventHandler(object sender, CfxOnResourceRedirectEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource load is redirected. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. The
        /// |Request| parameter will contain the old URL and other request-related
        /// information. The |Response| parameter will contain the response that
        /// resulted in the redirect. The |NewUrl| parameter will contain the new URL
        /// and can be changed if desired. The |Request| and |Response| objects cannot
        /// be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxOnResourceRedirectEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxResourceRequestHandler.OnResourceRedirect"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Get or set the NewUrl parameter for the <see cref="CfxResourceRequestHandler.OnResourceRedirect"/> callback.
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
        /// Called on the IO thread when a resource response is received. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource load to proceed without modification return false (0). To redirect
        /// or retry the resource load optionally modify |Request| and return true (1).
        /// Modification of the request URL will be treated as a redirect. Requests
        /// handled using the default network loader cannot be redirected in this
        /// callback. The |Response| object cannot be modified in this callback.
        /// 
        /// WARNING: Redirecting using this function is deprecated. Use
        /// OnBeforeResourceLoad or GetResourceHandler to perform redirects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceResponseEventHandler(object sender, CfxOnResourceResponseEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource response is received. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. To allow the
        /// resource load to proceed without modification return false (0). To redirect
        /// or retry the resource load optionally modify |Request| and return true (1).
        /// Modification of the request URL will be treated as a redirect. Requests
        /// handled using the default network loader cannot be redirected in this
        /// callback. The |Response| object cannot be modified in this callback.
        /// 
        /// WARNING: Redirecting using this function is deprecated. Use
        /// OnBeforeResourceLoad or GetResourceHandler to perform redirects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxOnResourceResponseEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxResourceRequestHandler.OnResourceResponse"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceRequestHandler.OnResourceResponse"/> callback.
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
        /// Called on the IO thread to optionally filter resource response content. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetResourceResponseFilterEventHandler(object sender, CfxGetResourceResponseFilterEventArgs e);

        /// <summary>
        /// Called on the IO thread to optionally filter resource response content. The
        /// |Browser| and |Frame| values represent the source of the request, and may
        /// be NULL for requests originating from service workers or CfxUrlRequest.
        /// |Request| and |Response| represent the request and response respectively
        /// and cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxGetResourceResponseFilterEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxResourceRequestHandler.GetResourceResponseFilter"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceRequestHandler.GetResourceResponseFilter"/> callback.
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
        /// Called on the IO thread when a resource load has completed. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// and |Response| represent the request and response respectively and cannot
        /// be modified in this callback. |Status| indicates the load completion
        /// status. |ReceivedContentLength| is the number of response bytes actually
        /// read. This function will be called for all requests, including requests
        /// that are aborted due to CEF shutdown or destruction of the associated
        /// browser. In cases where the associated browser is destroyed this callback
        /// may arrive after the CfxLifeSpanHandler.OnBeforeClose callback for
        /// that browser. The CfxFrame.IsValid function can be used to test for
        /// this situation, and care should be taken not to call |Browser| or |Frame|
        /// functions that modify state (like LoadURL, SendProcessMessage, etc.) if the
        /// frame is invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResourceLoadCompleteEventHandler(object sender, CfxOnResourceLoadCompleteEventArgs e);

        /// <summary>
        /// Called on the IO thread when a resource load has completed. The |Browser|
        /// and |Frame| values represent the source of the request, and may be NULL for
        /// requests originating from service workers or CfxUrlRequest. |Request|
        /// and |Response| represent the request and response respectively and cannot
        /// be modified in this callback. |Status| indicates the load completion
        /// status. |ReceivedContentLength| is the number of response bytes actually
        /// read. This function will be called for all requests, including requests
        /// that are aborted due to CEF shutdown or destruction of the associated
        /// browser. In cases where the associated browser is destroyed this callback
        /// may arrive after the CfxLifeSpanHandler.OnBeforeClose callback for
        /// that browser. The CfxFrame.IsValid function can be used to test for
        /// this situation, and care should be taken not to call |Browser| or |Frame|
        /// functions that modify state (like LoadURL, SendProcessMessage, etc.) if the
        /// frame is invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
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

            internal CfxOnResourceLoadCompleteEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Response parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Get the Status parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
            /// </summary>
            public CfxUrlRequestStatus Status {
                get {
                    CheckAccess();
                    return (CfxUrlRequestStatus)m_status;
                }
            }
            /// <summary>
            /// Get the ReceivedContentLength parameter for the <see cref="CfxResourceRequestHandler.OnResourceLoadComplete"/> callback.
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
        /// Called on the IO thread to handle requests for URLs with an unknown
        /// protocol component. The |Browser| and |Frame| values represent the source
        /// of the request, and may be NULL for requests originating from service
        /// workers or CfxUrlRequest. |Request| cannot be modified in this callback.
        /// Set |AllowOsExecution| to true (1) to attempt execution via the
        /// registered OS protocol handler, if any. SECURITY WARNING: YOU SHOULD USE
        /// THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR OTHER URL
        /// ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnProtocolExecutionEventHandler(object sender, CfxOnProtocolExecutionEventArgs e);

        /// <summary>
        /// Called on the IO thread to handle requests for URLs with an unknown
        /// protocol component. The |Browser| and |Frame| values represent the source
        /// of the request, and may be NULL for requests originating from service
        /// workers or CfxUrlRequest. |Request| cannot be modified in this callback.
        /// Set |AllowOsExecution| to true (1) to attempt execution via the
        /// registered OS protocol handler, if any. SECURITY WARNING: YOU SHOULD USE
        /// THIS METHOD TO ENFORCE RESTRICTIONS BASED ON SCHEME, HOST OR OTHER URL
        /// ANALYSIS BEFORE ALLOWING OS EXECUTION.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_request_handler_capi.h">cef/include/capi/cef_resource_request_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnProtocolExecutionEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_allow_os_execution;

            internal CfxOnProtocolExecutionEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxResourceRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxResourceRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the AllowOsExecution out parameter for the <see cref="CfxResourceRequestHandler.OnProtocolExecution"/> callback.
            /// </summary>
            public bool AllowOsExecution {
                set {
                    CheckAccess();
                    m_allow_os_execution = value ? 1 : 0;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}", Browser, Frame, Request);
            }
        }

    }
}
