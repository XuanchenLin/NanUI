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
	/// Implement this structure to provide handler implementations.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
	/// </remarks>
	public class CfxClient : CfxBase {

        static CfxClient () {
            CfxApiLoader.LoadCfxClientApi();
        }

        internal static CfxClient Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_client_get_gc_handle(nativePtr);
            return (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // get_context_menu_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_context_menu_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_context_menu_handler_delegate cfx_client_get_context_menu_handler;
        private static IntPtr cfx_client_get_context_menu_handler_ptr;

        internal static void get_context_menu_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetContextMenuHandlerEventArgs();
            var eventHandler = self.m_GetContextMenuHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxContextMenuHandler.Unwrap(e.m_returnValue);
        }

        // get_dialog_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_dialog_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_dialog_handler_delegate cfx_client_get_dialog_handler;
        private static IntPtr cfx_client_get_dialog_handler_ptr;

        internal static void get_dialog_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDialogHandlerEventArgs();
            var eventHandler = self.m_GetDialogHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxDialogHandler.Unwrap(e.m_returnValue);
        }

        // get_display_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_display_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_display_handler_delegate cfx_client_get_display_handler;
        private static IntPtr cfx_client_get_display_handler_ptr;

        internal static void get_display_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDisplayHandlerEventArgs();
            var eventHandler = self.m_GetDisplayHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxDisplayHandler.Unwrap(e.m_returnValue);
        }

        // get_download_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_download_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_download_handler_delegate cfx_client_get_download_handler;
        private static IntPtr cfx_client_get_download_handler_ptr;

        internal static void get_download_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDownloadHandlerEventArgs();
            var eventHandler = self.m_GetDownloadHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxDownloadHandler.Unwrap(e.m_returnValue);
        }

        // get_drag_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_drag_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_drag_handler_delegate cfx_client_get_drag_handler;
        private static IntPtr cfx_client_get_drag_handler_ptr;

        internal static void get_drag_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetDragHandlerEventArgs();
            var eventHandler = self.m_GetDragHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxDragHandler.Unwrap(e.m_returnValue);
        }

        // get_find_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_find_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_find_handler_delegate cfx_client_get_find_handler;
        private static IntPtr cfx_client_get_find_handler_ptr;

        internal static void get_find_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetFindHandlerEventArgs();
            var eventHandler = self.m_GetFindHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxFindHandler.Unwrap(e.m_returnValue);
        }

        // get_focus_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_focus_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_focus_handler_delegate cfx_client_get_focus_handler;
        private static IntPtr cfx_client_get_focus_handler_ptr;

        internal static void get_focus_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetFocusHandlerEventArgs();
            var eventHandler = self.m_GetFocusHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxFocusHandler.Unwrap(e.m_returnValue);
        }

        // get_geolocation_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_geolocation_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_geolocation_handler_delegate cfx_client_get_geolocation_handler;
        private static IntPtr cfx_client_get_geolocation_handler_ptr;

        internal static void get_geolocation_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetGeolocationHandlerEventArgs();
            var eventHandler = self.m_GetGeolocationHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxGeolocationHandler.Unwrap(e.m_returnValue);
        }

        // get_jsdialog_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_jsdialog_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_jsdialog_handler_delegate cfx_client_get_jsdialog_handler;
        private static IntPtr cfx_client_get_jsdialog_handler_ptr;

        internal static void get_jsdialog_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetJsDialogHandlerEventArgs();
            var eventHandler = self.m_GetJsDialogHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxJsDialogHandler.Unwrap(e.m_returnValue);
        }

        // get_keyboard_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_keyboard_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_keyboard_handler_delegate cfx_client_get_keyboard_handler;
        private static IntPtr cfx_client_get_keyboard_handler_ptr;

        internal static void get_keyboard_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetKeyboardHandlerEventArgs();
            var eventHandler = self.m_GetKeyboardHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxKeyboardHandler.Unwrap(e.m_returnValue);
        }

        // get_life_span_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_life_span_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_life_span_handler_delegate cfx_client_get_life_span_handler;
        private static IntPtr cfx_client_get_life_span_handler_ptr;

        internal static void get_life_span_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetLifeSpanHandlerEventArgs();
            var eventHandler = self.m_GetLifeSpanHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxLifeSpanHandler.Unwrap(e.m_returnValue);
        }

        // get_load_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_load_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_load_handler_delegate cfx_client_get_load_handler;
        private static IntPtr cfx_client_get_load_handler_ptr;

        internal static void get_load_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetLoadHandlerEventArgs();
            var eventHandler = self.m_GetLoadHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxLoadHandler.Unwrap(e.m_returnValue);
        }

        // get_render_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_render_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_render_handler_delegate cfx_client_get_render_handler;
        private static IntPtr cfx_client_get_render_handler_ptr;

        internal static void get_render_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetRenderHandlerEventArgs();
            var eventHandler = self.m_GetRenderHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxRenderHandler.Unwrap(e.m_returnValue);
        }

        // get_request_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_get_request_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_client_get_request_handler_delegate cfx_client_get_request_handler;
        private static IntPtr cfx_client_get_request_handler_ptr;

        internal static void get_request_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetRequestHandlerEventArgs();
            var eventHandler = self.m_GetRequestHandler;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxRequestHandler.Unwrap(e.m_returnValue);
        }

        // on_process_message_received
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_client_on_process_message_received_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source_process, IntPtr message);
        private static cfx_client_on_process_message_received_delegate cfx_client_on_process_message_received;
        private static IntPtr cfx_client_on_process_message_received_ptr;

        internal static void on_process_message_received(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source_process, IntPtr message) {
            var self = (CfxClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnProcessMessageReceivedEventArgs(browser, source_process, message);
            var eventHandler = self.m_OnProcessMessageReceived;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_message_wrapped == null) CfxApi.cfx_release(e.m_message);
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxClient(IntPtr nativePtr) : base(nativePtr) {}
        public CfxClient() : base(CfxApi.cfx_client_ctor) {}

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
                    if(m_GetContextMenuHandler == null) {
                        if(cfx_client_get_context_menu_handler == null) {
                            cfx_client_get_context_menu_handler = get_context_menu_handler;
                            cfx_client_get_context_menu_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_context_menu_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 0, cfx_client_get_context_menu_handler_ptr);
                    }
                    m_GetContextMenuHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetContextMenuHandler -= value;
                    if(m_GetContextMenuHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
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
                    if(m_GetDialogHandler == null) {
                        if(cfx_client_get_dialog_handler == null) {
                            cfx_client_get_dialog_handler = get_dialog_handler;
                            cfx_client_get_dialog_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_dialog_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 1, cfx_client_get_dialog_handler_ptr);
                    }
                    m_GetDialogHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDialogHandler -= value;
                    if(m_GetDialogHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
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
                    if(m_GetDisplayHandler == null) {
                        if(cfx_client_get_display_handler == null) {
                            cfx_client_get_display_handler = get_display_handler;
                            cfx_client_get_display_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_display_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 2, cfx_client_get_display_handler_ptr);
                    }
                    m_GetDisplayHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDisplayHandler -= value;
                    if(m_GetDisplayHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
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
                    if(m_GetDownloadHandler == null) {
                        if(cfx_client_get_download_handler == null) {
                            cfx_client_get_download_handler = get_download_handler;
                            cfx_client_get_download_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_download_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 3, cfx_client_get_download_handler_ptr);
                    }
                    m_GetDownloadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDownloadHandler -= value;
                    if(m_GetDownloadHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
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
                    if(m_GetDragHandler == null) {
                        if(cfx_client_get_drag_handler == null) {
                            cfx_client_get_drag_handler = get_drag_handler;
                            cfx_client_get_drag_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_drag_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 4, cfx_client_get_drag_handler_ptr);
                    }
                    m_GetDragHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetDragHandler -= value;
                    if(m_GetDragHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
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
                    if(m_GetFindHandler == null) {
                        if(cfx_client_get_find_handler == null) {
                            cfx_client_get_find_handler = get_find_handler;
                            cfx_client_get_find_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_find_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 5, cfx_client_get_find_handler_ptr);
                    }
                    m_GetFindHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetFindHandler -= value;
                    if(m_GetFindHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
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
                    if(m_GetFocusHandler == null) {
                        if(cfx_client_get_focus_handler == null) {
                            cfx_client_get_focus_handler = get_focus_handler;
                            cfx_client_get_focus_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_focus_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 6, cfx_client_get_focus_handler_ptr);
                    }
                    m_GetFocusHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetFocusHandler -= value;
                    if(m_GetFocusHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetFocusHandlerEventHandler m_GetFocusHandler;

        /// <summary>
        /// Return the handler for geolocation permissions requests. If no handler is
        /// provided geolocation access will be denied by default.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public event CfxGetGeolocationHandlerEventHandler GetGeolocationHandler {
            add {
                lock(eventLock) {
                    if(m_GetGeolocationHandler == null) {
                        if(cfx_client_get_geolocation_handler == null) {
                            cfx_client_get_geolocation_handler = get_geolocation_handler;
                            cfx_client_get_geolocation_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_geolocation_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 7, cfx_client_get_geolocation_handler_ptr);
                    }
                    m_GetGeolocationHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetGeolocationHandler -= value;
                    if(m_GetGeolocationHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetGeolocationHandlerEventHandler m_GetGeolocationHandler;

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
                    if(m_GetJsDialogHandler == null) {
                        if(cfx_client_get_jsdialog_handler == null) {
                            cfx_client_get_jsdialog_handler = get_jsdialog_handler;
                            cfx_client_get_jsdialog_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_jsdialog_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 8, cfx_client_get_jsdialog_handler_ptr);
                    }
                    m_GetJsDialogHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetJsDialogHandler -= value;
                    if(m_GetJsDialogHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
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
                    if(m_GetKeyboardHandler == null) {
                        if(cfx_client_get_keyboard_handler == null) {
                            cfx_client_get_keyboard_handler = get_keyboard_handler;
                            cfx_client_get_keyboard_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_keyboard_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 9, cfx_client_get_keyboard_handler_ptr);
                    }
                    m_GetKeyboardHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetKeyboardHandler -= value;
                    if(m_GetKeyboardHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 9, IntPtr.Zero);
                    }
                }
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
                    if(m_GetLifeSpanHandler == null) {
                        if(cfx_client_get_life_span_handler == null) {
                            cfx_client_get_life_span_handler = get_life_span_handler;
                            cfx_client_get_life_span_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_life_span_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 10, cfx_client_get_life_span_handler_ptr);
                    }
                    m_GetLifeSpanHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLifeSpanHandler -= value;
                    if(m_GetLifeSpanHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
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
                    if(m_GetLoadHandler == null) {
                        if(cfx_client_get_load_handler == null) {
                            cfx_client_get_load_handler = get_load_handler;
                            cfx_client_get_load_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_load_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 11, cfx_client_get_load_handler_ptr);
                    }
                    m_GetLoadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLoadHandler -= value;
                    if(m_GetLoadHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 11, IntPtr.Zero);
                    }
                }
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
                    if(m_GetRenderHandler == null) {
                        if(cfx_client_get_render_handler == null) {
                            cfx_client_get_render_handler = get_render_handler;
                            cfx_client_get_render_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_render_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 12, cfx_client_get_render_handler_ptr);
                    }
                    m_GetRenderHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRenderHandler -= value;
                    if(m_GetRenderHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 12, IntPtr.Zero);
                    }
                }
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
                    if(m_GetRequestHandler == null) {
                        if(cfx_client_get_request_handler == null) {
                            cfx_client_get_request_handler = get_request_handler;
                            cfx_client_get_request_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_get_request_handler);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 13, cfx_client_get_request_handler_ptr);
                    }
                    m_GetRequestHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRequestHandler -= value;
                    if(m_GetRequestHandler == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 13, IntPtr.Zero);
                    }
                }
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
                        if(cfx_client_on_process_message_received == null) {
                            cfx_client_on_process_message_received = on_process_message_received;
                            cfx_client_on_process_message_received_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_client_on_process_message_received);
                        }
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 14, cfx_client_on_process_message_received_ptr);
                    }
                    m_OnProcessMessageReceived += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProcessMessageReceived -= value;
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.cfx_client_set_managed_callback(NativePtr, 14, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProcessMessageReceivedEventHandler m_OnProcessMessageReceived;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetContextMenuHandler != null) {
                m_GetContextMenuHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetDialogHandler != null) {
                m_GetDialogHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetDisplayHandler != null) {
                m_GetDisplayHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetDownloadHandler != null) {
                m_GetDownloadHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetDragHandler != null) {
                m_GetDragHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_GetFindHandler != null) {
                m_GetFindHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_GetFocusHandler != null) {
                m_GetFocusHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_GetGeolocationHandler != null) {
                m_GetGeolocationHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_GetJsDialogHandler != null) {
                m_GetJsDialogHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_GetKeyboardHandler != null) {
                m_GetKeyboardHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_GetLifeSpanHandler != null) {
                m_GetLifeSpanHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 10, IntPtr.Zero);
            }
            if(m_GetLoadHandler != null) {
                m_GetLoadHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 11, IntPtr.Zero);
            }
            if(m_GetRenderHandler != null) {
                m_GetRenderHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 12, IntPtr.Zero);
            }
            if(m_GetRequestHandler != null) {
                m_GetRequestHandler = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 13, IntPtr.Zero);
            }
            if(m_OnProcessMessageReceived != null) {
                m_OnProcessMessageReceived = null;
                CfxApi.cfx_client_set_managed_callback(NativePtr, 14, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxGetContextMenuHandlerEventArgs() {
            }

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

            internal CfxGetDialogHandlerEventArgs() {
            }

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

            internal CfxGetDisplayHandlerEventArgs() {
            }

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

            internal CfxGetDownloadHandlerEventArgs() {
            }

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

            internal CfxGetDragHandlerEventArgs() {
            }

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

            internal CfxGetFindHandlerEventArgs() {
            }

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

            internal CfxGetFocusHandlerEventArgs() {
            }

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
        /// Return the handler for geolocation permissions requests. If no handler is
        /// provided geolocation access will be denied by default.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetGeolocationHandlerEventHandler(object sender, CfxGetGeolocationHandlerEventArgs e);

        /// <summary>
        /// Return the handler for geolocation permissions requests. If no handler is
        /// provided geolocation access will be denied by default.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_client_capi.h">cef/include/capi/cef_client_capi.h</see>.
        /// </remarks>
        public class CfxGetGeolocationHandlerEventArgs : CfxEventArgs {


            internal CfxGeolocationHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetGeolocationHandlerEventArgs() {
            }

            /// <summary>
            /// Set the return value for the <see cref="CfxClient.GetGeolocationHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxGeolocationHandler returnValue) {
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

            internal CfxGetJsDialogHandlerEventArgs() {
            }

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

            internal CfxGetKeyboardHandlerEventArgs() {
            }

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

            internal CfxGetLifeSpanHandlerEventArgs() {
            }

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

            internal CfxGetLoadHandlerEventArgs() {
            }

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

            internal CfxGetRenderHandlerEventArgs() {
            }

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

            internal CfxGetRequestHandlerEventArgs() {
            }

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
            internal int m_source_process;
            internal IntPtr m_message;
            internal CfxProcessMessage m_message_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnProcessMessageReceivedEventArgs(IntPtr browser, int source_process, IntPtr message) {
                m_browser = browser;
                m_source_process = source_process;
                m_message = message;
            }

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
                return String.Format("Browser={{{0}}}, SourceProcess={{{1}}}, Message={{{2}}}", Browser, SourceProcess, Message);
            }
        }

    }
}
