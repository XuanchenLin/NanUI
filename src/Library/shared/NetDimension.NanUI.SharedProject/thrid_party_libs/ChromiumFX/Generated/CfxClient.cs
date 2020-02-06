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
    /// Implement this structure to provide handler implementations.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
    /// </remarks>
    public class CfxClient : CfxBaseClient {

        internal static CfxClient Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.Client.cfx_client_get_gc_handle(nativePtr);
            return (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_context_menu_handler_native = get_context_menu_handler;
            get_dialog_handler_native = get_dialog_handler;
            get_display_handler_native = get_display_handler;
            get_download_handler_native = get_download_handler;
            get_drag_handler_native = get_drag_handler;
            get_find_handler_native = get_find_handler;
            get_focus_handler_native = get_focus_handler;
            get_jsdialog_handler_native = get_jsdialog_handler;
            get_keyboard_handler_native = get_keyboard_handler;
            get_life_span_handler_native = get_life_span_handler;
            get_load_handler_native = get_load_handler;
            get_render_handler_native = get_render_handler;
            get_request_handler_native = get_request_handler;
            on_process_message_received_native = on_process_message_received;

            get_context_menu_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_context_menu_handler_native);
            get_dialog_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_dialog_handler_native);
            get_display_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_display_handler_native);
            get_download_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_download_handler_native);
            get_drag_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_drag_handler_native);
            get_find_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_find_handler_native);
            get_focus_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_focus_handler_native);
            get_jsdialog_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_jsdialog_handler_native);
            get_keyboard_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_keyboard_handler_native);
            get_life_span_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_life_span_handler_native);
            get_load_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_load_handler_native);
            get_render_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_render_handler_native);
            get_request_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_request_handler_native);
            on_process_message_received_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_process_message_received_native);
        }

        // get_context_menu_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_context_menu_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_context_menu_handler_delegate get_context_menu_handler_native;
        private static IntPtr get_context_menu_handler_native_ptr;

        internal static void get_context_menu_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetContextMenuHandlerEventArgs();
            self.m_GetContextMenuHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxContextMenuHandler.Unwrap(e.m_returnValue);
        }

        // get_dialog_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_dialog_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_dialog_handler_delegate get_dialog_handler_native;
        private static IntPtr get_dialog_handler_native_ptr;

        internal static void get_dialog_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDialogHandlerEventArgs();
            self.m_GetDialogHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxDialogHandler.Unwrap(e.m_returnValue);
        }

        // get_display_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_display_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_display_handler_delegate get_display_handler_native;
        private static IntPtr get_display_handler_native_ptr;

        internal static void get_display_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDisplayHandlerEventArgs();
            self.m_GetDisplayHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxDisplayHandler.Unwrap(e.m_returnValue);
        }

        // get_download_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_download_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_download_handler_delegate get_download_handler_native;
        private static IntPtr get_download_handler_native_ptr;

        internal static void get_download_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDownloadHandlerEventArgs();
            self.m_GetDownloadHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxDownloadHandler.Unwrap(e.m_returnValue);
        }

        // get_drag_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_drag_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_drag_handler_delegate get_drag_handler_native;
        private static IntPtr get_drag_handler_native_ptr;

        internal static void get_drag_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDragHandlerEventArgs();
            self.m_GetDragHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxDragHandler.Unwrap(e.m_returnValue);
        }

        // get_find_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_find_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_find_handler_delegate get_find_handler_native;
        private static IntPtr get_find_handler_native_ptr;

        internal static void get_find_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetFindHandlerEventArgs();
            self.m_GetFindHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxFindHandler.Unwrap(e.m_returnValue);
        }

        // get_focus_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_focus_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_focus_handler_delegate get_focus_handler_native;
        private static IntPtr get_focus_handler_native_ptr;

        internal static void get_focus_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetFocusHandlerEventArgs();
            self.m_GetFocusHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxFocusHandler.Unwrap(e.m_returnValue);
        }

        // get_jsdialog_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_jsdialog_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_jsdialog_handler_delegate get_jsdialog_handler_native;
        private static IntPtr get_jsdialog_handler_native_ptr;

        internal static void get_jsdialog_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetJsDialogHandlerEventArgs();
            self.m_GetJsDialogHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxJsDialogHandler.Unwrap(e.m_returnValue);
        }

        // get_keyboard_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_keyboard_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_keyboard_handler_delegate get_keyboard_handler_native;
        private static IntPtr get_keyboard_handler_native_ptr;

        internal static void get_keyboard_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetKeyboardHandlerEventArgs();
            self.m_GetKeyboardHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxKeyboardHandler.Unwrap(e.m_returnValue);
        }

        // get_life_span_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_life_span_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_life_span_handler_delegate get_life_span_handler_native;
        private static IntPtr get_life_span_handler_native_ptr;

        internal static void get_life_span_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetLifeSpanHandlerEventArgs();
            self.m_GetLifeSpanHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxLifeSpanHandler.Unwrap(e.m_returnValue);
        }

        // get_load_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_load_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_load_handler_delegate get_load_handler_native;
        private static IntPtr get_load_handler_native_ptr;

        internal static void get_load_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetLoadHandlerEventArgs();
            self.m_GetLoadHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxLoadHandler.Unwrap(e.m_returnValue);
        }

        // get_render_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_render_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_render_handler_delegate get_render_handler_native;
        private static IntPtr get_render_handler_native_ptr;

        internal static void get_render_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetRenderHandlerEventArgs();
            self.m_GetRenderHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxRenderHandler.Unwrap(e.m_returnValue);
        }

        // get_request_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_request_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_request_handler_delegate get_request_handler_native;
        private static IntPtr get_request_handler_native_ptr;

        internal static void get_request_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetRequestHandlerEventArgs();
            self.m_GetRequestHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxRequestHandler.Unwrap(e.m_returnValue);
        }

        // on_process_message_received
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_process_message_received_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release);
        private static on_process_message_received_delegate on_process_message_received_native;
        private static IntPtr on_process_message_received_native_ptr;

        internal static void on_process_message_received(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                message_release = 1;
                return;
            }
            var e = new CfxOnProcessMessageReceivedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_source_process = source_process;
            e.m_message = message;
            self.m_OnProcessMessageReceived?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            message_release = e.m_message_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxClient(IntPtr nativePtr) : base(nativePtr) {}
        public CfxClient() : base(CfxApi.Client.cfx_client_ctor) {}

        /// <summary>
        /// Return the handler for context menus. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetContextMenuHandlerEventHandler GetContextMenuHandler {
            add {
                lock(eventLock) {
                    if(m_GetContextMenuHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 0, get_context_menu_handler_native_ptr);
                    m_GetContextMenuHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetContextMenuHandler -= value;
                    if(m_GetContextMenuHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxContextMenuHandler provided by the event handler attached to the GetContextMenuHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxContextMenuHandler RetrieveContextMenuHandler() {
            var h = m_GetContextMenuHandler;
            if(h != null) {
                var e = new CfxGetContextMenuHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetContextMenuHandlerEventHandler m_GetContextMenuHandler;

        /// <summary>
        /// Return the handler for dialogs. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetDialogHandlerEventHandler GetDialogHandler {
            add {
                lock(eventLock) {
                    if(m_GetDialogHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 1, get_dialog_handler_native_ptr);
                    m_GetDialogHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDialogHandler -= value;
                    if(m_GetDialogHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxDialogHandler provided by the event handler attached to the GetDialogHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxDialogHandler RetrieveDialogHandler() {
            var h = m_GetDialogHandler;
            if(h != null) {
                var e = new CfxGetDialogHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetDialogHandlerEventHandler m_GetDialogHandler;

        /// <summary>
        /// Return the handler for browser display state events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetDisplayHandlerEventHandler GetDisplayHandler {
            add {
                lock(eventLock) {
                    if(m_GetDisplayHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 2, get_display_handler_native_ptr);
                    m_GetDisplayHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDisplayHandler -= value;
                    if(m_GetDisplayHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxDisplayHandler provided by the event handler attached to the GetDisplayHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxDisplayHandler RetrieveDisplayHandler() {
            var h = m_GetDisplayHandler;
            if(h != null) {
                var e = new CfxGetDisplayHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetDisplayHandlerEventHandler m_GetDisplayHandler;

        /// <summary>
        /// Return the handler for download events. If no handler is returned downloads
        /// will not be allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetDownloadHandlerEventHandler GetDownloadHandler {
            add {
                lock(eventLock) {
                    if(m_GetDownloadHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 3, get_download_handler_native_ptr);
                    m_GetDownloadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDownloadHandler -= value;
                    if(m_GetDownloadHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxDownloadHandler provided by the event handler attached to the GetDownloadHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxDownloadHandler RetrieveDownloadHandler() {
            var h = m_GetDownloadHandler;
            if(h != null) {
                var e = new CfxGetDownloadHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetDownloadHandlerEventHandler m_GetDownloadHandler;

        /// <summary>
        /// Return the handler for drag events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetDragHandlerEventHandler GetDragHandler {
            add {
                lock(eventLock) {
                    if(m_GetDragHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 4, get_drag_handler_native_ptr);
                    m_GetDragHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDragHandler -= value;
                    if(m_GetDragHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxDragHandler provided by the event handler attached to the GetDragHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxDragHandler RetrieveDragHandler() {
            var h = m_GetDragHandler;
            if(h != null) {
                var e = new CfxGetDragHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetDragHandlerEventHandler m_GetDragHandler;

        /// <summary>
        /// Return the handler for find result events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetFindHandlerEventHandler GetFindHandler {
            add {
                lock(eventLock) {
                    if(m_GetFindHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 5, get_find_handler_native_ptr);
                    m_GetFindHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetFindHandler -= value;
                    if(m_GetFindHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxFindHandler provided by the event handler attached to the GetFindHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxFindHandler RetrieveFindHandler() {
            var h = m_GetFindHandler;
            if(h != null) {
                var e = new CfxGetFindHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetFindHandlerEventHandler m_GetFindHandler;

        /// <summary>
        /// Return the handler for focus events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetFocusHandlerEventHandler GetFocusHandler {
            add {
                lock(eventLock) {
                    if(m_GetFocusHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 6, get_focus_handler_native_ptr);
                    m_GetFocusHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetFocusHandler -= value;
                    if(m_GetFocusHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxFocusHandler provided by the event handler attached to the GetFocusHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxFocusHandler RetrieveFocusHandler() {
            var h = m_GetFocusHandler;
            if(h != null) {
                var e = new CfxGetFocusHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetFocusHandlerEventHandler m_GetFocusHandler;

        /// <summary>
        /// Return the handler for JavaScript dialogs. If no handler is provided the
        /// default implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetJsDialogHandlerEventHandler GetJsDialogHandler {
            add {
                lock(eventLock) {
                    if(m_GetJsDialogHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 7, get_jsdialog_handler_native_ptr);
                    m_GetJsDialogHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetJsDialogHandler -= value;
                    if(m_GetJsDialogHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxJsDialogHandler provided by the event handler attached to the GetJsDialogHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxJsDialogHandler RetrieveJsDialogHandler() {
            var h = m_GetJsDialogHandler;
            if(h != null) {
                var e = new CfxGetJsDialogHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetJsDialogHandlerEventHandler m_GetJsDialogHandler;

        /// <summary>
        /// Return the handler for keyboard events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetKeyboardHandlerEventHandler GetKeyboardHandler {
            add {
                lock(eventLock) {
                    if(m_GetKeyboardHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 8, get_keyboard_handler_native_ptr);
                    m_GetKeyboardHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetKeyboardHandler -= value;
                    if(m_GetKeyboardHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxKeyboardHandler provided by the event handler attached to the GetKeyboardHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxKeyboardHandler RetrieveKeyboardHandler() {
            var h = m_GetKeyboardHandler;
            if(h != null) {
                var e = new CfxGetKeyboardHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetKeyboardHandlerEventHandler m_GetKeyboardHandler;

        /// <summary>
        /// Return the handler for browser life span events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetLifeSpanHandlerEventHandler GetLifeSpanHandler {
            add {
                lock(eventLock) {
                    if(m_GetLifeSpanHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 9, get_life_span_handler_native_ptr);
                    m_GetLifeSpanHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLifeSpanHandler -= value;
                    if(m_GetLifeSpanHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 9, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxLifeSpanHandler provided by the event handler attached to the GetLifeSpanHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxLifeSpanHandler RetrieveLifeSpanHandler() {
            var h = m_GetLifeSpanHandler;
            if(h != null) {
                var e = new CfxGetLifeSpanHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetLifeSpanHandlerEventHandler m_GetLifeSpanHandler;

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetLoadHandlerEventHandler GetLoadHandler {
            add {
                lock(eventLock) {
                    if(m_GetLoadHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 10, get_load_handler_native_ptr);
                    m_GetLoadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLoadHandler -= value;
                    if(m_GetLoadHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxLoadHandler provided by the event handler attached to the GetLoadHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxLoadHandler RetrieveLoadHandler() {
            var h = m_GetLoadHandler;
            if(h != null) {
                var e = new CfxGetLoadHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetLoadHandlerEventHandler m_GetLoadHandler;

        /// <summary>
        /// Return the handler for off-screen rendering events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetRenderHandlerEventHandler GetRenderHandler {
            add {
                lock(eventLock) {
                    if(m_GetRenderHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 11, get_render_handler_native_ptr);
                    m_GetRenderHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRenderHandler -= value;
                    if(m_GetRenderHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 11, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxRenderHandler provided by the event handler attached to the GetRenderHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxRenderHandler RetrieveRenderHandler() {
            var h = m_GetRenderHandler;
            if(h != null) {
                var e = new CfxGetRenderHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetRenderHandlerEventHandler m_GetRenderHandler;

        /// <summary>
        /// Return the handler for browser request events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetRequestHandlerEventHandler GetRequestHandler {
            add {
                lock(eventLock) {
                    if(m_GetRequestHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.Client.cfx_client_set_callback(NativePtr, 12, get_request_handler_native_ptr);
                    m_GetRequestHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRequestHandler -= value;
                    if(m_GetRequestHandler == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 12, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxRequestHandler provided by the event handler attached to the GetRequestHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxRequestHandler RetrieveRequestHandler() {
            var h = m_GetRequestHandler;
            if(h != null) {
                var e = new CfxGetRequestHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetRequestHandlerEventHandler m_GetRequestHandler;

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxOnProcessMessageReceivedEventHandler OnProcessMessageReceived {
            add {
                lock(eventLock) {
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 13, on_process_message_received_native_ptr);
                    }
                    m_OnProcessMessageReceived += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProcessMessageReceived -= value;
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.Client.cfx_client_set_callback(NativePtr, 13, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProcessMessageReceivedEventHandler m_OnProcessMessageReceived;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetContextMenuHandler != null) {
                m_GetContextMenuHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetDialogHandler != null) {
                m_GetDialogHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetDisplayHandler != null) {
                m_GetDisplayHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetDownloadHandler != null) {
                m_GetDownloadHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetDragHandler != null) {
                m_GetDragHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_GetFindHandler != null) {
                m_GetFindHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_GetFocusHandler != null) {
                m_GetFocusHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_GetJsDialogHandler != null) {
                m_GetJsDialogHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_GetKeyboardHandler != null) {
                m_GetKeyboardHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_GetLifeSpanHandler != null) {
                m_GetLifeSpanHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_GetLoadHandler != null) {
                m_GetLoadHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 10, IntPtr.Zero);
            }
            if(m_GetRenderHandler != null) {
                m_GetRenderHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 11, IntPtr.Zero);
            }
            if(m_GetRequestHandler != null) {
                m_GetRequestHandler = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 12, IntPtr.Zero);
            }
            if(m_OnProcessMessageReceived != null) {
                m_OnProcessMessageReceived = null;
                CfxApi.Client.cfx_client_set_callback(NativePtr, 13, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Return the handler for context menus. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetContextMenuHandlerEventHandler(object sender, CfxGetContextMenuHandlerEventArgs e);

        /// <summary>
        /// Return the handler for context menus. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetContextMenuHandlerEventArgs : CfxEventArgs {


            internal CfxContextMenuHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetContextMenuHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetContextMenuHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxContextMenuHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for dialogs. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDialogHandlerEventHandler(object sender, CfxGetDialogHandlerEventArgs e);

        /// <summary>
        /// Return the handler for dialogs. If no handler is provided the default
        /// implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetDialogHandlerEventArgs : CfxEventArgs {


            internal CfxDialogHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetDialogHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetDialogHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxDialogHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for browser display state events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDisplayHandlerEventHandler(object sender, CfxGetDisplayHandlerEventArgs e);

        /// <summary>
        /// Return the handler for browser display state events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetDisplayHandlerEventArgs : CfxEventArgs {


            internal CfxDisplayHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetDisplayHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetDisplayHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxDisplayHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for download events. If no handler is returned downloads
        /// will not be allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDownloadHandlerEventHandler(object sender, CfxGetDownloadHandlerEventArgs e);

        /// <summary>
        /// Return the handler for download events. If no handler is returned downloads
        /// will not be allowed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetDownloadHandlerEventArgs : CfxEventArgs {


            internal CfxDownloadHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetDownloadHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetDownloadHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxDownloadHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for drag events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetDragHandlerEventHandler(object sender, CfxGetDragHandlerEventArgs e);

        /// <summary>
        /// Return the handler for drag events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetDragHandlerEventArgs : CfxEventArgs {


            internal CfxDragHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetDragHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetDragHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxDragHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for find result events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetFindHandlerEventHandler(object sender, CfxGetFindHandlerEventArgs e);

        /// <summary>
        /// Return the handler for find result events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetFindHandlerEventArgs : CfxEventArgs {


            internal CfxFindHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetFindHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetFindHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxFindHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for focus events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetFocusHandlerEventHandler(object sender, CfxGetFocusHandlerEventArgs e);

        /// <summary>
        /// Return the handler for focus events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetFocusHandlerEventArgs : CfxEventArgs {


            internal CfxFocusHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetFocusHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetFocusHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxFocusHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for JavaScript dialogs. If no handler is provided the
        /// default implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetJsDialogHandlerEventHandler(object sender, CfxGetJsDialogHandlerEventArgs e);

        /// <summary>
        /// Return the handler for JavaScript dialogs. If no handler is provided the
        /// default implementation will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetJsDialogHandlerEventArgs : CfxEventArgs {


            internal CfxJsDialogHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetJsDialogHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetJsDialogHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxJsDialogHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for keyboard events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetKeyboardHandlerEventHandler(object sender, CfxGetKeyboardHandlerEventArgs e);

        /// <summary>
        /// Return the handler for keyboard events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetKeyboardHandlerEventArgs : CfxEventArgs {


            internal CfxKeyboardHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetKeyboardHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetKeyboardHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxKeyboardHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for browser life span events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetLifeSpanHandlerEventHandler(object sender, CfxGetLifeSpanHandlerEventArgs e);

        /// <summary>
        /// Return the handler for browser life span events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetLifeSpanHandlerEventArgs : CfxEventArgs {


            internal CfxLifeSpanHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetLifeSpanHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetLifeSpanHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxLifeSpanHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetLoadHandlerEventHandler(object sender, CfxGetLoadHandlerEventArgs e);

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetLoadHandlerEventArgs : CfxEventArgs {


            internal CfxLoadHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetLoadHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetLoadHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxLoadHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for off-screen rendering events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetRenderHandlerEventHandler(object sender, CfxGetRenderHandlerEventArgs e);

        /// <summary>
        /// Return the handler for off-screen rendering events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetRenderHandlerEventArgs : CfxEventArgs {


            internal CfxRenderHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetRenderHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetRenderHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxRenderHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return the handler for browser request events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetRequestHandlerEventHandler(object sender, CfxGetRequestHandlerEventArgs e);

        /// <summary>
        /// Return the handler for browser request events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetRequestHandlerEventArgs : CfxEventArgs {


            internal CfxRequestHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetRequestHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetRequestHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxRequestHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnProcessMessageReceivedEventHandler(object sender, CfxOnProcessMessageReceivedEventArgs e);

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxOnProcessMessageReceivedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal int m_source_process;
            internal IntPtr m_message;
            internal CfxProcessMessage m_message_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnProcessMessageReceivedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxClient.OnProcessMessageReceived"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxClient.OnProcessMessageReceived"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the SourceProcess parameter for the <see cref="CfxClient.OnProcessMessageReceived"/> callback.
            /// </summary>
            public CfxProcessId SourceProcess {
                get {
                    CheckAccess();
                    return (CfxProcessId)m_source_process;
                }
            }
            /// <summary>
            /// Get the Message parameter for the <see cref="CfxClient.OnProcessMessageReceived"/> callback.
            /// </summary>
            public CfxProcessMessage Message {
                get {
                    CheckAccess();
                    if(m_message_wrapped == null) m_message_wrapped = CfxProcessMessage.Wrap(m_message);
                    return m_message_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxClient.OnProcessMessageReceived"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, SourceProcess={{{2}}}, Message={{{3}}}", Browser, Frame, SourceProcess, Message);
            }
        }

    }
}
