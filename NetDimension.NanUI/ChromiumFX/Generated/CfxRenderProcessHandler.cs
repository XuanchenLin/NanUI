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
	/// Structure used to implement render process callbacks. The functions of this
	/// structure will be called on the render process main thread (TID_RENDERER)
	/// unless otherwise indicated.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
	/// </remarks>
	public class CfxRenderProcessHandler : CfxBase {

        static CfxRenderProcessHandler () {
            CfxApiLoader.LoadCfxRenderProcessHandlerApi();
        }

        internal static CfxRenderProcessHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_render_process_handler_get_gc_handle(nativePtr);
            return (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_render_thread_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_render_thread_created_delegate(IntPtr gcHandlePtr, IntPtr extra_info);
        private static cfx_render_process_handler_on_render_thread_created_delegate cfx_render_process_handler_on_render_thread_created;
        private static IntPtr cfx_render_process_handler_on_render_thread_created_ptr;

        internal static void on_render_thread_created(IntPtr gcHandlePtr, IntPtr extra_info) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnRenderThreadCreatedEventArgs(extra_info);
            var eventHandler = self.m_OnRenderThreadCreated;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_extra_info_wrapped == null) CfxApi.cfx_release(e.m_extra_info);
        }

        // on_web_kit_initialized
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_web_kit_initialized_delegate(IntPtr gcHandlePtr);
        private static cfx_render_process_handler_on_web_kit_initialized_delegate cfx_render_process_handler_on_web_kit_initialized;
        private static IntPtr cfx_render_process_handler_on_web_kit_initialized_ptr;

        internal static void on_web_kit_initialized(IntPtr gcHandlePtr) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxEventArgs();
            var eventHandler = self.m_OnWebKitInitialized;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        // on_browser_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_browser_created_delegate(IntPtr gcHandlePtr, IntPtr browser);
        private static cfx_render_process_handler_on_browser_created_delegate cfx_render_process_handler_on_browser_created;
        private static IntPtr cfx_render_process_handler_on_browser_created_ptr;

        internal static void on_browser_created(IntPtr gcHandlePtr, IntPtr browser) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnBrowserCreatedEventArgs(browser);
            var eventHandler = self.m_OnBrowserCreated;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_browser_destroyed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_browser_destroyed_delegate(IntPtr gcHandlePtr, IntPtr browser);
        private static cfx_render_process_handler_on_browser_destroyed_delegate cfx_render_process_handler_on_browser_destroyed;
        private static IntPtr cfx_render_process_handler_on_browser_destroyed_ptr;

        internal static void on_browser_destroyed(IntPtr gcHandlePtr, IntPtr browser) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnBrowserDestroyedEventArgs(browser);
            var eventHandler = self.m_OnBrowserDestroyed;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // get_load_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_get_load_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_render_process_handler_get_load_handler_delegate cfx_render_process_handler_get_load_handler;
        private static IntPtr cfx_render_process_handler_get_load_handler_ptr;

        internal static void get_load_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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

        // on_before_navigation
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_before_navigation_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr frame, IntPtr request, int navigation_type, int is_redirect);
        private static cfx_render_process_handler_on_before_navigation_delegate cfx_render_process_handler_on_before_navigation;
        private static IntPtr cfx_render_process_handler_on_before_navigation_ptr;

        internal static void on_before_navigation(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr frame, IntPtr request, int navigation_type, int is_redirect) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnBeforeNavigationEventArgs(browser, frame, request, navigation_type, is_redirect);
            var eventHandler = self.m_OnBeforeNavigation;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_request_wrapped == null) CfxApi.cfx_release(e.m_request);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_context_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_context_created_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context);
        private static cfx_render_process_handler_on_context_created_delegate cfx_render_process_handler_on_context_created;
        private static IntPtr cfx_render_process_handler_on_context_created_ptr;

        internal static void on_context_created(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnContextCreatedEventArgs(browser, frame, context);
            var eventHandler = self.m_OnContextCreated;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_context_wrapped == null) CfxApi.cfx_release(e.m_context);
        }

        // on_context_released
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_context_released_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context);
        private static cfx_render_process_handler_on_context_released_delegate cfx_render_process_handler_on_context_released;
        private static IntPtr cfx_render_process_handler_on_context_released_ptr;

        internal static void on_context_released(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnContextReleasedEventArgs(browser, frame, context);
            var eventHandler = self.m_OnContextReleased;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_context_wrapped == null) CfxApi.cfx_release(e.m_context);
        }

        // on_uncaught_exception
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_uncaught_exception_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context, IntPtr exception, IntPtr stackTrace);
        private static cfx_render_process_handler_on_uncaught_exception_delegate cfx_render_process_handler_on_uncaught_exception;
        private static IntPtr cfx_render_process_handler_on_uncaught_exception_ptr;

        internal static void on_uncaught_exception(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr context, IntPtr exception, IntPtr stackTrace) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnUncaughtExceptionEventArgs(browser, frame, context, exception, stackTrace);
            var eventHandler = self.m_OnUncaughtException;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_context_wrapped == null) CfxApi.cfx_release(e.m_context);
            if(e.m_exception_wrapped == null) CfxApi.cfx_release(e.m_exception);
            if(e.m_stackTrace_wrapped == null) CfxApi.cfx_release(e.m_stackTrace);
        }

        // on_focused_node_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_focused_node_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr node);
        private static cfx_render_process_handler_on_focused_node_changed_delegate cfx_render_process_handler_on_focused_node_changed;
        private static IntPtr cfx_render_process_handler_on_focused_node_changed_ptr;

        internal static void on_focused_node_changed(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr node) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnFocusedNodeChangedEventArgs(browser, frame, node);
            var eventHandler = self.m_OnFocusedNodeChanged;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
            if(e.m_node_wrapped == null) CfxApi.cfx_release(e.m_node);
        }

        // on_process_message_received
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_process_handler_on_process_message_received_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source_process, IntPtr message);
        private static cfx_render_process_handler_on_process_message_received_delegate cfx_render_process_handler_on_process_message_received;
        private static IntPtr cfx_render_process_handler_on_process_message_received_ptr;

        internal static void on_process_message_received(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source_process, IntPtr message) {
            var self = (CfxRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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

        internal CfxRenderProcessHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRenderProcessHandler() : base(CfxApi.cfx_render_process_handler_ctor) {}

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
                        if(cfx_render_process_handler_on_render_thread_created == null) {
                            cfx_render_process_handler_on_render_thread_created = on_render_thread_created;
                            cfx_render_process_handler_on_render_thread_created_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_render_thread_created);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 0, cfx_render_process_handler_on_render_thread_created_ptr);
                    }
                    m_OnRenderThreadCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderThreadCreated -= value;
                    if(m_OnRenderThreadCreated == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_web_kit_initialized == null) {
                            cfx_render_process_handler_on_web_kit_initialized = on_web_kit_initialized;
                            cfx_render_process_handler_on_web_kit_initialized_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_web_kit_initialized);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 1, cfx_render_process_handler_on_web_kit_initialized_ptr);
                    }
                    m_OnWebKitInitialized += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnWebKitInitialized -= value;
                    if(m_OnWebKitInitialized == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_OnWebKitInitialized;

        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBrowserCreatedEventHandler OnBrowserCreated {
            add {
                lock(eventLock) {
                    if(m_OnBrowserCreated == null) {
                        if(cfx_render_process_handler_on_browser_created == null) {
                            cfx_render_process_handler_on_browser_created = on_browser_created;
                            cfx_render_process_handler_on_browser_created_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_browser_created);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 2, cfx_render_process_handler_on_browser_created_ptr);
                    }
                    m_OnBrowserCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBrowserCreated -= value;
                    if(m_OnBrowserCreated == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_browser_destroyed == null) {
                            cfx_render_process_handler_on_browser_destroyed = on_browser_destroyed;
                            cfx_render_process_handler_on_browser_destroyed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_browser_destroyed);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 3, cfx_render_process_handler_on_browser_destroyed_ptr);
                    }
                    m_OnBrowserDestroyed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBrowserDestroyed -= value;
                    if(m_OnBrowserDestroyed == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
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
                    if(m_GetLoadHandler == null) {
                        if(cfx_render_process_handler_get_load_handler == null) {
                            cfx_render_process_handler_get_load_handler = get_load_handler;
                            cfx_render_process_handler_get_load_handler_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_get_load_handler);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 4, cfx_render_process_handler_get_load_handler_ptr);
                    }
                    m_GetLoadHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetLoadHandler -= value;
                    if(m_GetLoadHandler == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetLoadHandlerEventHandler m_GetLoadHandler;

        /// <summary>
        /// Called before browser navigation. Return true (1) to cancel the navigation
        /// or false (0) to allow the navigation to proceed. The |Request| object
        /// cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeNavigationEventHandler OnBeforeNavigation {
            add {
                lock(eventLock) {
                    if(m_OnBeforeNavigation == null) {
                        if(cfx_render_process_handler_on_before_navigation == null) {
                            cfx_render_process_handler_on_before_navigation = on_before_navigation;
                            cfx_render_process_handler_on_before_navigation_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_before_navigation);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 5, cfx_render_process_handler_on_before_navigation_ptr);
                    }
                    m_OnBeforeNavigation += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeNavigation -= value;
                    if(m_OnBeforeNavigation == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeNavigationEventHandler m_OnBeforeNavigation;

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
                        if(cfx_render_process_handler_on_context_created == null) {
                            cfx_render_process_handler_on_context_created = on_context_created;
                            cfx_render_process_handler_on_context_created_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_context_created);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 6, cfx_render_process_handler_on_context_created_ptr);
                    }
                    m_OnContextCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextCreated -= value;
                    if(m_OnContextCreated == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_context_released == null) {
                            cfx_render_process_handler_on_context_released = on_context_released;
                            cfx_render_process_handler_on_context_released_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_context_released);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 7, cfx_render_process_handler_on_context_released_ptr);
                    }
                    m_OnContextReleased += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextReleased -= value;
                    if(m_OnContextReleased == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 7, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_uncaught_exception == null) {
                            cfx_render_process_handler_on_uncaught_exception = on_uncaught_exception;
                            cfx_render_process_handler_on_uncaught_exception_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_uncaught_exception);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 8, cfx_render_process_handler_on_uncaught_exception_ptr);
                    }
                    m_OnUncaughtException += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnUncaughtException -= value;
                    if(m_OnUncaughtException == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 8, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_focused_node_changed == null) {
                            cfx_render_process_handler_on_focused_node_changed = on_focused_node_changed;
                            cfx_render_process_handler_on_focused_node_changed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_focused_node_changed);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 9, cfx_render_process_handler_on_focused_node_changed_ptr);
                    }
                    m_OnFocusedNodeChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFocusedNodeChanged -= value;
                    if(m_OnFocusedNodeChanged == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 9, IntPtr.Zero);
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
                        if(cfx_render_process_handler_on_process_message_received == null) {
                            cfx_render_process_handler_on_process_message_received = on_process_message_received;
                            cfx_render_process_handler_on_process_message_received_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_process_handler_on_process_message_received);
                        }
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 10, cfx_render_process_handler_on_process_message_received_ptr);
                    }
                    m_OnProcessMessageReceived += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnProcessMessageReceived -= value;
                    if(m_OnProcessMessageReceived == null) {
                        CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnProcessMessageReceivedEventHandler m_OnProcessMessageReceived;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRenderThreadCreated != null) {
                m_OnRenderThreadCreated = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnWebKitInitialized != null) {
                m_OnWebKitInitialized = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnBrowserCreated != null) {
                m_OnBrowserCreated = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnBrowserDestroyed != null) {
                m_OnBrowserDestroyed = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_GetLoadHandler != null) {
                m_GetLoadHandler = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnBeforeNavigation != null) {
                m_OnBeforeNavigation = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnContextCreated != null) {
                m_OnContextCreated = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnContextReleased != null) {
                m_OnContextReleased = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_OnUncaughtException != null) {
                m_OnUncaughtException = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_OnFocusedNodeChanged != null) {
                m_OnFocusedNodeChanged = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_OnProcessMessageReceived != null) {
                m_OnProcessMessageReceived = null;
                CfxApi.cfx_render_process_handler_set_managed_callback(NativePtr, 10, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxOnRenderThreadCreatedEventArgs(IntPtr extra_info) {
                m_extra_info = extra_info;
            }

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
        /// destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBrowserCreatedEventHandler(object sender, CfxOnBrowserCreatedEventArgs e);

        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBrowserCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnBrowserCreatedEventArgs(IntPtr browser) {
                m_browser = browser;
            }

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

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
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

            internal CfxOnBrowserDestroyedEventArgs(IntPtr browser) {
                m_browser = browser;
            }

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
        /// Called before browser navigation. Return true (1) to cancel the navigation
        /// or false (0) to allow the navigation to proceed. The |Request| object
        /// cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeNavigationEventHandler(object sender, CfxOnBeforeNavigationEventArgs e);

        /// <summary>
        /// Called before browser navigation. Return true (1) to cancel the navigation
        /// or false (0) to allow the navigation to proceed. The |Request| object
        /// cannot be modified in this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeNavigationEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_navigation_type;
            internal int m_is_redirect;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeNavigationEventArgs(IntPtr browser, IntPtr frame, IntPtr request, int navigation_type, int is_redirect) {
                m_browser = browser;
                m_frame = frame;
                m_request = request;
                m_navigation_type = navigation_type;
                m_is_redirect = is_redirect;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the NavigationType parameter for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
            /// </summary>
            public CfxNavigationType NavigationType {
                get {
                    CheckAccess();
                    return (CfxNavigationType)m_navigation_type;
                }
            }
            /// <summary>
            /// Get the IsRedirect parameter for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
            /// </summary>
            public bool IsRedirect {
                get {
                    CheckAccess();
                    return 0 != m_is_redirect;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderProcessHandler.OnBeforeNavigation"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, NavigationType={{{3}}}, IsRedirect={{{4}}}", Browser, Frame, Request, NavigationType, IsRedirect);
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

            internal CfxOnContextCreatedEventArgs(IntPtr browser, IntPtr frame, IntPtr context) {
                m_browser = browser;
                m_frame = frame;
                m_context = context;
            }

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

            internal CfxOnContextReleasedEventArgs(IntPtr browser, IntPtr frame, IntPtr context) {
                m_browser = browser;
                m_frame = frame;
                m_context = context;
            }

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

            internal CfxOnUncaughtExceptionEventArgs(IntPtr browser, IntPtr frame, IntPtr context, IntPtr exception, IntPtr stackTrace) {
                m_browser = browser;
                m_frame = frame;
                m_context = context;
                m_exception = exception;
                m_stackTrace = stackTrace;
            }

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

            internal CfxOnFocusedNodeChangedEventArgs(IntPtr browser, IntPtr frame, IntPtr node) {
                m_browser = browser;
                m_frame = frame;
                m_node = node;
            }

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
