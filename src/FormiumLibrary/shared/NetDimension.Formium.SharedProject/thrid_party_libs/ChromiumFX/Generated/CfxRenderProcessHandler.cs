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
    /// Structure used to implement render process callbacks. The functions of this
    /// structure will be called on the render process main thread (TID_RENDERER)
    /// unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
    /// </remarks>
    public class CfxRenderProcessHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_render_thread_created_native = on_render_thread_created;
            on_web_kit_initialized_native = on_web_kit_initialized;
            on_browser_created_native = on_browser_created;
            on_browser_destroyed_native = on_browser_destroyed;
            get_load_handler_native = get_load_handler;
            on_context_created_native = on_context_created;
            on_context_released_native = on_context_released;
            on_uncaught_exception_native = on_uncaught_exception;
            on_focused_node_changed_native = on_focused_node_changed;
            on_process_message_received_native = on_process_message_received;

            on_render_thread_created_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_thread_created_native);
            on_web_kit_initialized_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_web_kit_initialized_native);
            on_browser_created_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_browser_created_native);
            on_browser_destroyed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_browser_destroyed_native);
            get_load_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_load_handler_native);
            on_context_created_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_context_created_native);
            on_context_released_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_context_released_native);
            on_uncaught_exception_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_uncaught_exception_native);
            on_focused_node_changed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_focused_node_changed_native);
            on_process_message_received_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_process_message_received_native);
        }

        // on_render_thread_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_render_thread_created_delegate(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release);
        private static on_render_thread_created_delegate on_render_thread_created_native;
        private static IntPtr on_render_thread_created_native_ptr;

        internal static void on_render_thread_created(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                extra_info_release = 1;
                return;
            }
            var e = new CfxOnRenderThreadCreatedEventArgs();
            e.m_extra_info = extra_info;
            self.m_OnRenderThreadCreated?.Invoke(self, e);
            e.m_isInvalid = true;
            extra_info_release = e.m_extra_info_wrapped == null? 1 : 0;
        }

        // on_web_kit_initialized
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_kit_initialized_delegate(IntPtr gcHandlePtr);
        private static on_web_kit_initialized_delegate on_web_kit_initialized_native;
        private static IntPtr on_web_kit_initialized_native_ptr;

        internal static void on_web_kit_initialized(IntPtr gcHandlePtr) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxEventArgs();
            self.m_OnWebKitInitialized?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        // on_browser_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_browser_created_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr extra_info, out int extra_info_release);
        private static on_browser_created_delegate on_browser_created_native;
        private static IntPtr on_browser_created_native_ptr;

        internal static void on_browser_created(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr extra_info, out int extra_info_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                extra_info_release = 1;
                return;
            }
            var e = new CfxOnBrowserCreatedEventArgs();
            e.m_browser = browser;
            e.m_extra_info = extra_info;
            self.m_OnBrowserCreated?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            extra_info_release = e.m_extra_info_wrapped == null? 1 : 0;
        }

        // on_browser_destroyed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_browser_destroyed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_browser_destroyed_delegate on_browser_destroyed_native;
        private static IntPtr on_browser_destroyed_native_ptr;

        internal static void on_browser_destroyed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnBrowserDestroyedEventArgs();
            e.m_browser = browser;
            self.m_OnBrowserDestroyed?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // get_load_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_load_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_load_handler_delegate get_load_handler_native;
        private static IntPtr get_load_handler_native_ptr;

        internal static void get_load_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetLoadHandlerEventArgs();
            self.m_GetLoadHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxLoadHandler.Unwrap(e.m_returnValue);
        }

        // on_context_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_created_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release);
        private static on_context_created_delegate on_context_created_native;
        private static IntPtr on_context_created_native_ptr;

        internal static void on_context_created(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                context_release = 1;
                return;
            }
            var e = new CfxOnContextCreatedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_context = context;
            self.m_OnContextCreated?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
        }

        // on_context_released
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_released_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release);
        private static on_context_released_delegate on_context_released_native;
        private static IntPtr on_context_released_native_ptr;

        internal static void on_context_released(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                context_release = 1;
                return;
            }
            var e = new CfxOnContextReleasedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_context = context;
            self.m_OnContextReleased?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
        }

        // on_uncaught_exception
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_uncaught_exception_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release, IntPtr exception, out int exception_release, IntPtr stackTrace, out int stackTrace_release);
        private static on_uncaught_exception_delegate on_uncaught_exception_native;
        private static IntPtr on_uncaught_exception_native_ptr;

        internal static void on_uncaught_exception(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release, IntPtr exception, out int exception_release, IntPtr stackTrace, out int stackTrace_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                context_release = 1;
                exception_release = 1;
                stackTrace_release = 1;
                return;
            }
            var e = new CfxOnUncaughtExceptionEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_context = context;
            e.m_exception = exception;
            e.m_stackTrace = stackTrace;
            self.m_OnUncaughtException?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
            exception_release = e.m_exception_wrapped == null? 1 : 0;
            stackTrace_release = e.m_stackTrace_wrapped == null? 1 : 0;
        }

        // on_focused_node_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_focused_node_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr node, out int node_release);
        private static on_focused_node_changed_delegate on_focused_node_changed_native;
        private static IntPtr on_focused_node_changed_native_ptr;

        internal static void on_focused_node_changed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr node, out int node_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                node_release = 1;
                return;
            }
            var e = new CfxOnFocusedNodeChangedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_node = node;
            self.m_OnFocusedNodeChanged?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            node_release = e.m_node_wrapped == null? 1 : 0;
        }

        // on_process_message_received
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_process_message_received_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release);
        private static on_process_message_received_delegate on_process_message_received_native;
        private static IntPtr on_process_message_received_native_ptr;

        internal static void on_process_message_received(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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

        public CfxRenderProcessHandler() : base(CfxApi.RenderProcessHandler.cfx_render_process_handler_ctor) {}

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfxBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRenderThreadCreatedEventHandler OnRenderThreadCreated {
            add {
                lock(eventLock) {
                    if(m_OnRenderThreadCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 0, on_render_thread_created_native_ptr);
                    }
                    m_OnRenderThreadCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderThreadCreated -= value;
                    if(m_OnRenderThreadCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRenderThreadCreatedEventHandler m_OnRenderThreadCreated;

        /// <summary>
        /// Called after WebKit has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxEventHandler OnWebKitInitialized {
            add {
                lock(eventLock) {
                    if(m_OnWebKitInitialized == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 1, on_web_kit_initialized_native_ptr);
                    }
                    m_OnWebKitInitialized += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnWebKitInitialized -= value;
                    if(m_OnWebKitInitialized == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_OnWebKitInitialized;

        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfxBrowserHost.CfxBrowserHostCreateBrowser(),
        /// CfxBrowserHost.CfxBrowserHostCreateBrowserSync(),
        /// CfxLifeSpanHandler.OnBeforePopup() or
        /// CfxBrowserView.CfxBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBrowserCreatedEventHandler OnBrowserCreated {
            add {
                lock(eventLock) {
                    if(m_OnBrowserCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 2, on_browser_created_native_ptr);
                    }
                    m_OnBrowserCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBrowserCreated -= value;
                    if(m_OnBrowserCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBrowserCreatedEventHandler m_OnBrowserCreated;

        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBrowserDestroyedEventHandler OnBrowserDestroyed {
            add {
                lock(eventLock) {
                    if(m_OnBrowserDestroyed == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 3, on_browser_destroyed_native_ptr);
                    }
                    m_OnBrowserDestroyed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBrowserDestroyed -= value;
                    if(m_OnBrowserDestroyed == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBrowserDestroyedEventHandler m_OnBrowserDestroyed;

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetLoadHandlerEventHandler GetLoadHandler {
            add {
                lock(eventLock) {
                    if(m_GetLoadHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 4, get_load_handler_native_ptr);
                    m_GetLoadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLoadHandler -= value;
                    if(m_GetLoadHandler == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 4, IntPtr.Zero);
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
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfxV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfxV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnContextCreatedEventHandler OnContextCreated {
            add {
                lock(eventLock) {
                    if(m_OnContextCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 5, on_context_created_native_ptr);
                    }
                    m_OnContextCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextCreated -= value;
                    if(m_OnContextCreated == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnContextCreatedEventHandler m_OnContextCreated;

        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnContextReleasedEventHandler OnContextReleased {
            add {
                lock(eventLock) {
                    if(m_OnContextReleased == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 6, on_context_released_native_ptr);
                    }
                    m_OnContextReleased += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextReleased -= value;
                    if(m_OnContextReleased == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnContextReleasedEventHandler m_OnContextReleased;

        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfxSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnUncaughtExceptionEventHandler OnUncaughtException {
            add {
                lock(eventLock) {
                    if(m_OnUncaughtException == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 7, on_uncaught_exception_native_ptr);
                    }
                    m_OnUncaughtException += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnUncaughtException -= value;
                    if(m_OnUncaughtException == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnUncaughtExceptionEventHandler m_OnUncaughtException;

        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnFocusedNodeChangedEventHandler OnFocusedNodeChanged {
            add {
                lock(eventLock) {
                    if(m_OnFocusedNodeChanged == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 8, on_focused_node_changed_native_ptr);
                    }
                    m_OnFocusedNodeChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFocusedNodeChanged -= value;
                    if(m_OnFocusedNodeChanged == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFocusedNodeChangedEventHandler m_OnFocusedNodeChanged;

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnProcessMessageReceivedEventHandler OnProcessMessageReceived {
            add {
                lock(eventLock) {
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 9, on_process_message_received_native_ptr);
                    }
                    m_OnProcessMessageReceived += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProcessMessageReceived -= value;
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 9, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProcessMessageReceivedEventHandler m_OnProcessMessageReceived;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRenderThreadCreated != null) {
                m_OnRenderThreadCreated = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnWebKitInitialized != null) {
                m_OnWebKitInitialized = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnBrowserCreated != null) {
                m_OnBrowserCreated = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnBrowserDestroyed != null) {
                m_OnBrowserDestroyed = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetLoadHandler != null) {
                m_GetLoadHandler = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnContextCreated != null) {
                m_OnContextCreated = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnContextReleased != null) {
                m_OnContextReleased = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnUncaughtException != null) {
                m_OnUncaughtException = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_OnFocusedNodeChanged != null) {
                m_OnFocusedNodeChanged = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_OnProcessMessageReceived != null) {
                m_OnProcessMessageReceived = null;
                CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(NativePtr, 9, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfxBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRenderThreadCreatedEventHandler(object sender, CfxOnRenderThreadCreatedEventArgs e);

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfxBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRenderThreadCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_extra_info;
            internal CfxListValue m_extra_info_wrapped;

            internal CfxOnRenderThreadCreatedEventArgs() {}

            /// <summary>
            /// Get the ExtraInfo parameter for the <see cref="CfxRenderProcessHandler.OnRenderThreadCreated"/> callback.
            /// </summary>
            public CfxListValue ExtraInfo {
                get {
                    CheckAccess();
                    if(m_extra_info_wrapped == null) m_extra_info_wrapped = CfxListValue.Wrap(m_extra_info);
                    return m_extra_info_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("ExtraInfo={{{0}}}", ExtraInfo);
            }
        }


        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfxBrowserHost.CfxBrowserHostCreateBrowser(),
        /// CfxBrowserHost.CfxBrowserHostCreateBrowserSync(),
        /// CfxLifeSpanHandler.OnBeforePopup() or
        /// CfxBrowserView.CfxBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBrowserCreatedEventHandler(object sender, CfxOnBrowserCreatedEventArgs e);

        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfxBrowserHost.CfxBrowserHostCreateBrowser(),
        /// CfxBrowserHost.CfxBrowserHostCreateBrowserSync(),
        /// CfxLifeSpanHandler.OnBeforePopup() or
        /// CfxBrowserView.CfxBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBrowserCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_extra_info;
            internal CfxDictionaryValue m_extra_info_wrapped;

            internal CfxOnBrowserCreatedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnBrowserCreated"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the ExtraInfo parameter for the <see cref="CfxRenderProcessHandler.OnBrowserCreated"/> callback.
            /// </summary>
            public CfxDictionaryValue ExtraInfo {
                get {
                    CheckAccess();
                    if(m_extra_info_wrapped == null) m_extra_info_wrapped = CfxDictionaryValue.Wrap(m_extra_info);
                    return m_extra_info_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, ExtraInfo={{{1}}}", Browser, ExtraInfo);
            }
        }

        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBrowserDestroyedEventHandler(object sender, CfxOnBrowserDestroyedEventArgs e);

        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBrowserDestroyedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnBrowserDestroyedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnBrowserDestroyed"/> callback.
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
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfxV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfxV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnContextCreatedEventHandler(object sender, CfxOnContextCreatedEventArgs e);

        /// <summary>
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfxV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfxV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnContextCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_context;
            internal CfxV8Context m_context_wrapped;

            internal CfxOnContextCreatedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnContextCreated"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRenderProcessHandler.OnContextCreated"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfxRenderProcessHandler.OnContextCreated"/> callback.
            /// </summary>
            public CfxV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfxV8Context.Wrap(m_context);
                    return m_context_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}", Browser, Frame, Context);
            }
        }

        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnContextReleasedEventHandler(object sender, CfxOnContextReleasedEventArgs e);

        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnContextReleasedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_context;
            internal CfxV8Context m_context_wrapped;

            internal CfxOnContextReleasedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnContextReleased"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRenderProcessHandler.OnContextReleased"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfxRenderProcessHandler.OnContextReleased"/> callback.
            /// </summary>
            public CfxV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfxV8Context.Wrap(m_context);
                    return m_context_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}", Browser, Frame, Context);
            }
        }

        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfxSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnUncaughtExceptionEventHandler(object sender, CfxOnUncaughtExceptionEventArgs e);

        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfxSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnUncaughtExceptionEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_context;
            internal CfxV8Context m_context_wrapped;
            internal IntPtr m_exception;
            internal CfxV8Exception m_exception_wrapped;
            internal IntPtr m_stackTrace;
            internal CfxV8StackTrace m_stackTrace_wrapped;

            internal CfxOnUncaughtExceptionEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnUncaughtException"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRenderProcessHandler.OnUncaughtException"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfxRenderProcessHandler.OnUncaughtException"/> callback.
            /// </summary>
            public CfxV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfxV8Context.Wrap(m_context);
                    return m_context_wrapped;
                }
            }
            /// <summary>
            /// Get the Exception parameter for the <see cref="CfxRenderProcessHandler.OnUncaughtException"/> callback.
            /// </summary>
            public CfxV8Exception Exception {
                get {
                    CheckAccess();
                    if(m_exception_wrapped == null) m_exception_wrapped = CfxV8Exception.Wrap(m_exception);
                    return m_exception_wrapped;
                }
            }
            /// <summary>
            /// Get the StackTrace parameter for the <see cref="CfxRenderProcessHandler.OnUncaughtException"/> callback.
            /// </summary>
            public CfxV8StackTrace StackTrace {
                get {
                    CheckAccess();
                    if(m_stackTrace_wrapped == null) m_stackTrace_wrapped = CfxV8StackTrace.Wrap(m_stackTrace);
                    return m_stackTrace_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}, Exception={{{3}}}, StackTrace={{{4}}}", Browser, Frame, Context, Exception, StackTrace);
            }
        }

        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnFocusedNodeChangedEventHandler(object sender, CfxOnFocusedNodeChangedEventArgs e);

        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnFocusedNodeChangedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_node;
            internal CfxDomNode m_node_wrapped;

            internal CfxOnFocusedNodeChangedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnFocusedNodeChanged"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRenderProcessHandler.OnFocusedNodeChanged"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Node parameter for the <see cref="CfxRenderProcessHandler.OnFocusedNodeChanged"/> callback.
            /// </summary>
            public CfxDomNode Node {
                get {
                    CheckAccess();
                    if(m_node_wrapped == null) m_node_wrapped = CfxDomNode.Wrap(m_node);
                    return m_node_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Node={{{2}}}", Browser, Frame, Node);
            }
        }


    }
}
