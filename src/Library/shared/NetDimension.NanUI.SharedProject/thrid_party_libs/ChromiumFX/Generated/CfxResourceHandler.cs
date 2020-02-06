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
    /// Structure used to implement a custom request handler structure. The functions
    /// of this structure will be called on the IO thread unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
    /// </remarks>
    public class CfxResourceHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            open_native = open;
            process_request_native = process_request;
            get_response_headers_native = get_response_headers;
            skip_native = skip;
            read_native = read;
            read_response_native = read_response;
            cancel_native = cancel;

            open_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(open_native);
            process_request_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(process_request_native);
            get_response_headers_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_response_headers_native);
            skip_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(skip_native);
            read_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(read_native);
            read_response_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(read_response_native);
            cancel_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cancel_native);
        }

        // open
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void open_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr request, out int request_release, out int handle_request, IntPtr callback, out int callback_release);
        private static open_delegate open_native;
        private static IntPtr open_native_ptr;

        internal static void open(IntPtr gcHandlePtr, out int __retval, IntPtr request, out int request_release, out int handle_request, IntPtr callback, out int callback_release) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                request_release = 1;
                handle_request = default(int);
                callback_release = 1;
                return;
            }
            var e = new CfxOpenEventArgs();
            e.m_request = request;
            e.m_callback = callback;
            self.m_Open?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
            handle_request = e.m_handle_request;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // process_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void process_request_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr request, out int request_release, IntPtr callback, out int callback_release);
        private static process_request_delegate process_request_native;
        private static IntPtr process_request_native_ptr;

        internal static void process_request(IntPtr gcHandlePtr, out int __retval, IntPtr request, out int request_release, IntPtr callback, out int callback_release) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                request_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxProcessRequestEventArgs();
            e.m_request = request;
            e.m_callback = callback;
            self.m_ProcessRequest?.Invoke(self, e);
            e.m_isInvalid = true;
            request_release = e.m_request_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_response_headers
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_response_headers_delegate(IntPtr gcHandlePtr, IntPtr response, out int response_release, out long response_length, out IntPtr redirectUrl_str, out int redirectUrl_length, out IntPtr redirectUrl_gc_handle);
        private static get_response_headers_delegate get_response_headers_native;
        private static IntPtr get_response_headers_native_ptr;

        internal static void get_response_headers(IntPtr gcHandlePtr, IntPtr response, out int response_release, out long response_length, out IntPtr redirectUrl_str, out int redirectUrl_length, out IntPtr redirectUrl_gc_handle) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                response_release = 1;
                response_length = default(long);
                redirectUrl_str = IntPtr.Zero;
                redirectUrl_length = 0;
                redirectUrl_gc_handle = IntPtr.Zero;
                return;
            }
            var e = new CfxGetResponseHeadersEventArgs();
            e.m_response = response;
            self.m_GetResponseHeaders?.Invoke(self, e);
            e.m_isInvalid = true;
            response_release = e.m_response_wrapped == null? 1 : 0;
            response_length = e.m_response_length;
            if(e.m_redirectUrl_wrapped != null && e.m_redirectUrl_wrapped.Length > 0) {
                var redirectUrl_pinned = new PinnedString(e.m_redirectUrl_wrapped);
                redirectUrl_str = redirectUrl_pinned.Obj.PinnedPtr;
                redirectUrl_length = redirectUrl_pinned.Length;
                redirectUrl_gc_handle = redirectUrl_pinned.Obj.GCHandlePtr();
            } else {
                redirectUrl_str = IntPtr.Zero;
                redirectUrl_length = 0;
                redirectUrl_gc_handle = IntPtr.Zero;
            }
        }

        // skip
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void skip_delegate(IntPtr gcHandlePtr, out int __retval, long bytes_to_skip, out long bytes_skipped, IntPtr callback, out int callback_release);
        private static skip_delegate skip_native;
        private static IntPtr skip_native_ptr;

        internal static void skip(IntPtr gcHandlePtr, out int __retval, long bytes_to_skip, out long bytes_skipped, IntPtr callback, out int callback_release) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                bytes_skipped = default(long);
                callback_release = 1;
                return;
            }
            var e = new CfxSkipEventArgs();
            e.m_bytes_to_skip = bytes_to_skip;
            e.m_callback = callback;
            self.m_Skip?.Invoke(self, e);
            e.m_isInvalid = true;
            bytes_skipped = e.m_bytes_skipped;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // read
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void read_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr data_out, int bytes_to_read, out int bytes_read, IntPtr callback, out int callback_release);
        private static read_delegate read_native;
        private static IntPtr read_native_ptr;

        internal static void read(IntPtr gcHandlePtr, out int __retval, IntPtr data_out, int bytes_to_read, out int bytes_read, IntPtr callback, out int callback_release) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                bytes_read = default(int);
                callback_release = 1;
                return;
            }
            var e = new CfxResourceHandlerReadEventArgs();
            e.m_data_out = data_out;
            e.m_bytes_to_read = bytes_to_read;
            e.m_callback = callback;
            self.m_Read?.Invoke(self, e);
            e.m_isInvalid = true;
            bytes_read = e.m_bytes_read;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // read_response
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void read_response_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr data_out, int bytes_to_read, out int bytes_read, IntPtr callback, out int callback_release);
        private static read_response_delegate read_response_native;
        private static IntPtr read_response_native_ptr;

        internal static void read_response(IntPtr gcHandlePtr, out int __retval, IntPtr data_out, int bytes_to_read, out int bytes_read, IntPtr callback, out int callback_release) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                bytes_read = default(int);
                callback_release = 1;
                return;
            }
            var e = new CfxReadResponseEventArgs();
            e.m_data_out = data_out;
            e.m_bytes_to_read = bytes_to_read;
            e.m_callback = callback;
            self.m_ReadResponse?.Invoke(self, e);
            e.m_isInvalid = true;
            bytes_read = e.m_bytes_read;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // cancel
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cancel_delegate(IntPtr gcHandlePtr);
        private static cancel_delegate cancel_native;
        private static IntPtr cancel_native_ptr;

        internal static void cancel(IntPtr gcHandlePtr) {
            var self = (CfxResourceHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxEventArgs();
            self.m_Cancel?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxResourceHandler() : base(CfxApi.ResourceHandler.cfx_resource_handler_ctor) {}

        /// <summary>
        /// Open the response stream. To handle the request immediately set
        /// |HandleRequest| to true (1) and return true (1). To decide at a later time
        /// set |HandleRequest| to false (0), return true (1), and execute |Callback|
        /// to continue or cancel the request. To cancel the request immediately set
        /// |HandleRequest| to true (1) and return false (0). This function will be
        /// called in sequence but not from a dedicated thread. For backwards
        /// compatibility set |HandleRequest| to false (0) and return false (0) and
        /// the ProcessRequest function will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxOpenEventHandler Open {
            add {
                lock(eventLock) {
                    if(m_Open == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 0, open_native_ptr);
                    }
                    m_Open += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Open -= value;
                    if(m_Open == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOpenEventHandler m_Open;

        /// <summary>
        /// Begin processing the request. To handle the request return true (1) and
        /// call CfxCallback.Continue() once the response header information is
        /// available (CfxCallback.Continue() can also be called from inside this
        /// function if header information is available immediately). To cancel the
        /// request return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Open instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxProcessRequestEventHandler ProcessRequest {
            add {
                lock(eventLock) {
                    if(m_ProcessRequest == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 1, process_request_native_ptr);
                    }
                    m_ProcessRequest += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_ProcessRequest -= value;
                    if(m_ProcessRequest == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxProcessRequestEventHandler m_ProcessRequest;

        /// <summary>
        /// Retrieve response header information. If the response length is not known
        /// set |ResponseLength| to -1 and read_response() will be called until it
        /// returns false (0). If the response length is known set |ResponseLength| to
        /// a positive value and read_response() will be called until it returns false
        /// (0) or the specified number of bytes have been read. Use the |Response|
        /// object to set the mime type, http status code and other optional header
        /// values. To redirect the request to a new URL set |RedirectUrl| to the new
        /// URL. |RedirectUrl| can be either a relative or fully qualified URL. It is
        /// also possible to set |Response| to a redirect http status code and pass the
        /// new URL via a Location header. Likewise with |RedirectUrl| it is valid to
        /// set a relative or fully qualified URL as the Location header value. If an
        /// error occured while setting up the request you can call set_error() on
        /// |Response| to indicate the error condition.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetResponseHeadersEventHandler GetResponseHeaders {
            add {
                lock(eventLock) {
                    if(m_GetResponseHeaders == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 2, get_response_headers_native_ptr);
                    }
                    m_GetResponseHeaders += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResponseHeaders -= value;
                    if(m_GetResponseHeaders == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetResponseHeadersEventHandler m_GetResponseHeaders;

        /// <summary>
        /// Skip response data when requested by a Range header. Skip over and discard
        /// |BytesToSkip| bytes of response data. If data is available immediately
        /// set |BytesSkipped| to the number of bytes skipped and return true (1). To
        /// read the data at a later time set |BytesSkipped| to 0, return true (1) and
        /// execute |Callback| when the data is available. To indicate failure set
        /// |BytesSkipped| to &lt; 0 (e.g. -2 for ERR_FAILED) and return false (0). This
        /// function will be called in sequence but not from a dedicated thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxSkipEventHandler Skip {
            add {
                lock(eventLock) {
                    if(m_Skip == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 3, skip_native_ptr);
                    }
                    m_Skip += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Skip -= value;
                    if(m_Skip == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSkipEventHandler m_Skip;

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time keep a
        /// pointer to |DataOut|, set |BytesRead| to 0, return true (1) and execute
        /// |Callback| when the data is available (|DataOut| will remain valid until
        /// the callback is executed). To indicate response completion set |BytesRead|
        /// to 0 and return false (0). To indicate failure set |BytesRead| to &lt; 0
        /// (e.g. -2 for ERR_FAILED) and return false (0). This function will be called
        /// in sequence but not from a dedicated thread. For backwards compatibility
        /// set |BytesRead| to -1 and return false (0) and the ReadResponse function
        /// will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxResourceHandlerReadEventHandler Read {
            add {
                lock(eventLock) {
                    if(m_Read == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 4, read_native_ptr);
                    }
                    m_Read += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Read -= value;
                    if(m_Read == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxResourceHandlerReadEventHandler m_Read;

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time set
        /// |BytesRead| to 0, return true (1) and call CfxCallback.Continue() when the
        /// data is available. To indicate response completion return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Skip and Read instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxReadResponseEventHandler ReadResponse {
            add {
                lock(eventLock) {
                    if(m_ReadResponse == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 5, read_response_native_ptr);
                    }
                    m_ReadResponse += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_ReadResponse -= value;
                    if(m_ReadResponse == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxReadResponseEventHandler m_ReadResponse;

        /// <summary>
        /// Request processing has been canceled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public event CfxEventHandler Cancel {
            add {
                lock(eventLock) {
                    if(m_Cancel == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 6, cancel_native_ptr);
                    }
                    m_Cancel += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Cancel -= value;
                    if(m_Cancel == null) {
                        CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_Cancel;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Open != null) {
                m_Open = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_ProcessRequest != null) {
                m_ProcessRequest = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetResponseHeaders != null) {
                m_GetResponseHeaders = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_Skip != null) {
                m_Skip = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_Read != null) {
                m_Read = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_ReadResponse != null) {
                m_ReadResponse = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_Cancel != null) {
                m_Cancel = null;
                CfxApi.ResourceHandler.cfx_resource_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Open the response stream. To handle the request immediately set
        /// |HandleRequest| to true (1) and return true (1). To decide at a later time
        /// set |HandleRequest| to false (0), return true (1), and execute |Callback|
        /// to continue or cancel the request. To cancel the request immediately set
        /// |HandleRequest| to true (1) and return false (0). This function will be
        /// called in sequence but not from a dedicated thread. For backwards
        /// compatibility set |HandleRequest| to false (0) and return false (0) and
        /// the ProcessRequest function will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOpenEventHandler(object sender, CfxOpenEventArgs e);

        /// <summary>
        /// Open the response stream. To handle the request immediately set
        /// |HandleRequest| to true (1) and return true (1). To decide at a later time
        /// set |HandleRequest| to false (0), return true (1), and execute |Callback|
        /// to continue or cancel the request. To cancel the request immediately set
        /// |HandleRequest| to true (1) and return false (0). This function will be
        /// called in sequence but not from a dedicated thread. For backwards
        /// compatibility set |HandleRequest| to false (0) and return false (0) and
        /// the ProcessRequest function will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxOpenEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_handle_request;
            internal IntPtr m_callback;
            internal CfxCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOpenEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceHandler.Open"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Set the HandleRequest out parameter for the <see cref="CfxResourceHandler.Open"/> callback.
            /// </summary>
            public bool HandleRequest {
                set {
                    CheckAccess();
                    m_handle_request = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceHandler.Open"/> callback.
            /// </summary>
            public CfxCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceHandler.Open"/> callback.
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
                return String.Format("Request={{{0}}}, Callback={{{1}}}", Request, Callback);
            }
        }

        /// <summary>
        /// Begin processing the request. To handle the request return true (1) and
        /// call CfxCallback.Continue() once the response header information is
        /// available (CfxCallback.Continue() can also be called from inside this
        /// function if header information is available immediately). To cancel the
        /// request return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Open instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxProcessRequestEventHandler(object sender, CfxProcessRequestEventArgs e);

        /// <summary>
        /// Begin processing the request. To handle the request return true (1) and
        /// call CfxCallback.Continue() once the response header information is
        /// available (CfxCallback.Continue() can also be called from inside this
        /// function if header information is available immediately). To cancel the
        /// request return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Open instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxProcessRequestEventArgs : CfxEventArgs {

            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_callback;
            internal CfxCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxProcessRequestEventArgs() {}

            /// <summary>
            /// Get the Request parameter for the <see cref="CfxResourceHandler.ProcessRequest"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceHandler.ProcessRequest"/> callback.
            /// </summary>
            public CfxCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceHandler.ProcessRequest"/> callback.
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
                return String.Format("Request={{{0}}}, Callback={{{1}}}", Request, Callback);
            }
        }

        /// <summary>
        /// Retrieve response header information. If the response length is not known
        /// set |ResponseLength| to -1 and read_response() will be called until it
        /// returns false (0). If the response length is known set |ResponseLength| to
        /// a positive value and read_response() will be called until it returns false
        /// (0) or the specified number of bytes have been read. Use the |Response|
        /// object to set the mime type, http status code and other optional header
        /// values. To redirect the request to a new URL set |RedirectUrl| to the new
        /// URL. |RedirectUrl| can be either a relative or fully qualified URL. It is
        /// also possible to set |Response| to a redirect http status code and pass the
        /// new URL via a Location header. Likewise with |RedirectUrl| it is valid to
        /// set a relative or fully qualified URL as the Location header value. If an
        /// error occured while setting up the request you can call set_error() on
        /// |Response| to indicate the error condition.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetResponseHeadersEventHandler(object sender, CfxGetResponseHeadersEventArgs e);

        /// <summary>
        /// Retrieve response header information. If the response length is not known
        /// set |ResponseLength| to -1 and read_response() will be called until it
        /// returns false (0). If the response length is known set |ResponseLength| to
        /// a positive value and read_response() will be called until it returns false
        /// (0) or the specified number of bytes have been read. Use the |Response|
        /// object to set the mime type, http status code and other optional header
        /// values. To redirect the request to a new URL set |RedirectUrl| to the new
        /// URL. |RedirectUrl| can be either a relative or fully qualified URL. It is
        /// also possible to set |Response| to a redirect http status code and pass the
        /// new URL via a Location header. Likewise with |RedirectUrl| it is valid to
        /// set a relative or fully qualified URL as the Location header value. If an
        /// error occured while setting up the request you can call set_error() on
        /// |Response| to indicate the error condition.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetResponseHeadersEventArgs : CfxEventArgs {

            internal IntPtr m_response;
            internal CfxResponse m_response_wrapped;
            internal long m_response_length;
            internal string m_redirectUrl_wrapped;

            internal CfxGetResponseHeadersEventArgs() {}

            /// <summary>
            /// Get the Response parameter for the <see cref="CfxResourceHandler.GetResponseHeaders"/> callback.
            /// </summary>
            public CfxResponse Response {
                get {
                    CheckAccess();
                    if(m_response_wrapped == null) m_response_wrapped = CfxResponse.Wrap(m_response);
                    return m_response_wrapped;
                }
            }
            /// <summary>
            /// Set the ResponseLength out parameter for the <see cref="CfxResourceHandler.GetResponseHeaders"/> callback.
            /// </summary>
            public long ResponseLength {
                set {
                    CheckAccess();
                    m_response_length = value;
                }
            }
            /// <summary>
            /// Set the RedirectUrl out parameter for the <see cref="CfxResourceHandler.GetResponseHeaders"/> callback.
            /// </summary>
            public string RedirectUrl {
                set {
                    CheckAccess();
                    m_redirectUrl_wrapped = value;
                }
            }

            public override string ToString() {
                return String.Format("Response={{{0}}}", Response);
            }
        }

        /// <summary>
        /// Skip response data when requested by a Range header. Skip over and discard
        /// |BytesToSkip| bytes of response data. If data is available immediately
        /// set |BytesSkipped| to the number of bytes skipped and return true (1). To
        /// read the data at a later time set |BytesSkipped| to 0, return true (1) and
        /// execute |Callback| when the data is available. To indicate failure set
        /// |BytesSkipped| to &lt; 0 (e.g. -2 for ERR_FAILED) and return false (0). This
        /// function will be called in sequence but not from a dedicated thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxSkipEventHandler(object sender, CfxSkipEventArgs e);

        /// <summary>
        /// Skip response data when requested by a Range header. Skip over and discard
        /// |BytesToSkip| bytes of response data. If data is available immediately
        /// set |BytesSkipped| to the number of bytes skipped and return true (1). To
        /// read the data at a later time set |BytesSkipped| to 0, return true (1) and
        /// execute |Callback| when the data is available. To indicate failure set
        /// |BytesSkipped| to &lt; 0 (e.g. -2 for ERR_FAILED) and return false (0). This
        /// function will be called in sequence but not from a dedicated thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxSkipEventArgs : CfxEventArgs {

            internal long m_bytes_to_skip;
            internal long m_bytes_skipped;
            internal IntPtr m_callback;
            internal CfxResourceSkipCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxSkipEventArgs() {}

            /// <summary>
            /// Get the BytesToSkip parameter for the <see cref="CfxResourceHandler.Skip"/> callback.
            /// </summary>
            public long BytesToSkip {
                get {
                    CheckAccess();
                    return m_bytes_to_skip;
                }
            }
            /// <summary>
            /// Set the BytesSkipped out parameter for the <see cref="CfxResourceHandler.Skip"/> callback.
            /// </summary>
            public long BytesSkipped {
                set {
                    CheckAccess();
                    m_bytes_skipped = value;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceHandler.Skip"/> callback.
            /// </summary>
            public CfxResourceSkipCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxResourceSkipCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceHandler.Skip"/> callback.
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
                return String.Format("BytesToSkip={{{0}}}, Callback={{{1}}}", BytesToSkip, Callback);
            }
        }

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time keep a
        /// pointer to |DataOut|, set |BytesRead| to 0, return true (1) and execute
        /// |Callback| when the data is available (|DataOut| will remain valid until
        /// the callback is executed). To indicate response completion set |BytesRead|
        /// to 0 and return false (0). To indicate failure set |BytesRead| to &lt; 0
        /// (e.g. -2 for ERR_FAILED) and return false (0). This function will be called
        /// in sequence but not from a dedicated thread. For backwards compatibility
        /// set |BytesRead| to -1 and return false (0) and the ReadResponse function
        /// will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxResourceHandlerReadEventHandler(object sender, CfxResourceHandlerReadEventArgs e);

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time keep a
        /// pointer to |DataOut|, set |BytesRead| to 0, return true (1) and execute
        /// |Callback| when the data is available (|DataOut| will remain valid until
        /// the callback is executed). To indicate response completion set |BytesRead|
        /// to 0 and return false (0). To indicate failure set |BytesRead| to &lt; 0
        /// (e.g. -2 for ERR_FAILED) and return false (0). This function will be called
        /// in sequence but not from a dedicated thread. For backwards compatibility
        /// set |BytesRead| to -1 and return false (0) and the ReadResponse function
        /// will be called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxResourceHandlerReadEventArgs : CfxEventArgs {

            internal IntPtr m_data_out;
            internal int m_bytes_to_read;
            internal int m_bytes_read;
            internal IntPtr m_callback;
            internal CfxResourceReadCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxResourceHandlerReadEventArgs() {}

            /// <summary>
            /// Get the DataOut parameter for the <see cref="CfxResourceHandler.Read"/> callback.
            /// </summary>
            public IntPtr DataOut {
                get {
                    CheckAccess();
                    return m_data_out;
                }
            }
            /// <summary>
            /// Get the BytesToRead parameter for the <see cref="CfxResourceHandler.Read"/> callback.
            /// </summary>
            public int BytesToRead {
                get {
                    CheckAccess();
                    return m_bytes_to_read;
                }
            }
            /// <summary>
            /// Set the BytesRead out parameter for the <see cref="CfxResourceHandler.Read"/> callback.
            /// </summary>
            public int BytesRead {
                set {
                    CheckAccess();
                    m_bytes_read = value;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceHandler.Read"/> callback.
            /// </summary>
            public CfxResourceReadCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxResourceReadCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceHandler.Read"/> callback.
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
                return String.Format("DataOut={{{0}}}, BytesToRead={{{1}}}, Callback={{{2}}}", DataOut, BytesToRead, Callback);
            }
        }

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time set
        /// |BytesRead| to 0, return true (1) and call CfxCallback.Continue() when the
        /// data is available. To indicate response completion return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Skip and Read instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxReadResponseEventHandler(object sender, CfxReadResponseEventArgs e);

        /// <summary>
        /// Read response data. If data is available immediately copy up to
        /// |BytesToRead| bytes into |DataOut|, set |BytesRead| to the number of
        /// bytes copied, and return true (1). To read the data at a later time set
        /// |BytesRead| to 0, return true (1) and call CfxCallback.Continue() when the
        /// data is available. To indicate response completion return false (0).
        /// 
        /// WARNING: This function is deprecated. Use Skip and Read instead.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public class CfxReadResponseEventArgs : CfxEventArgs {

            internal IntPtr m_data_out;
            internal int m_bytes_to_read;
            internal int m_bytes_read;
            internal IntPtr m_callback;
            internal CfxCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxReadResponseEventArgs() {}

            /// <summary>
            /// Get the DataOut parameter for the <see cref="CfxResourceHandler.ReadResponse"/> callback.
            /// </summary>
            public IntPtr DataOut {
                get {
                    CheckAccess();
                    return m_data_out;
                }
            }
            /// <summary>
            /// Get the BytesToRead parameter for the <see cref="CfxResourceHandler.ReadResponse"/> callback.
            /// </summary>
            public int BytesToRead {
                get {
                    CheckAccess();
                    return m_bytes_to_read;
                }
            }
            /// <summary>
            /// Set the BytesRead out parameter for the <see cref="CfxResourceHandler.ReadResponse"/> callback.
            /// </summary>
            public int BytesRead {
                set {
                    CheckAccess();
                    m_bytes_read = value;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxResourceHandler.ReadResponse"/> callback.
            /// </summary>
            public CfxCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxResourceHandler.ReadResponse"/> callback.
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
                return String.Format("DataOut={{{0}}}, BytesToRead={{{1}}}, Callback={{{2}}}", DataOut, BytesToRead, Callback);
            }
        }


    }
}
