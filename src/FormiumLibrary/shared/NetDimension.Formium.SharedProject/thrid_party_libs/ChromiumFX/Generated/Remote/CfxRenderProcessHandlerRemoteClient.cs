// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxRenderProcessHandlerRemoteClient {

        static CfxRenderProcessHandlerRemoteClient() {
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

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_render_thread_created_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_web_kit_initialized_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_browser_created_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_browser_destroyed_native_ptr : IntPtr.Zero);
                    break;
                case 4:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? get_load_handler_native_ptr : IntPtr.Zero);
                    break;
                case 5:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_context_created_native_ptr : IntPtr.Zero);
                    break;
                case 6:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_context_released_native_ptr : IntPtr.Zero);
                    break;
                case 7:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_uncaught_exception_native_ptr : IntPtr.Zero);
                    break;
                case 8:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_focused_node_changed_native_ptr : IntPtr.Zero);
                    break;
                case 9:
                    CfxApi.RenderProcessHandler.cfx_render_process_handler_set_callback(self, index, active ? on_process_message_received_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // on_render_thread_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_render_thread_created_delegate(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release);
        private static on_render_thread_created_delegate on_render_thread_created_native;
        private static IntPtr on_render_thread_created_native_ptr;

        internal static void on_render_thread_created(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release) {
            var call = new CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.extra_info = extra_info;
            call.RequestExecution();
            extra_info_release = call.extra_info_release;
        }

        // on_web_kit_initialized
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_kit_initialized_delegate(IntPtr gcHandlePtr);
        private static on_web_kit_initialized_delegate on_web_kit_initialized_native;
        private static IntPtr on_web_kit_initialized_native_ptr;

        internal static void on_web_kit_initialized(IntPtr gcHandlePtr) {
            var call = new CfxRenderProcessHandlerOnWebKitInitializedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
        }

        // on_browser_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_browser_created_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr extra_info, out int extra_info_release);
        private static on_browser_created_delegate on_browser_created_native;
        private static IntPtr on_browser_created_native_ptr;

        internal static void on_browser_created(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr extra_info, out int extra_info_release) {
            var call = new CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.extra_info = extra_info;
            call.RequestExecution();
            browser_release = call.browser_release;
            extra_info_release = call.extra_info_release;
        }

        // on_browser_destroyed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_browser_destroyed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_browser_destroyed_delegate on_browser_destroyed_native;
        private static IntPtr on_browser_destroyed_native_ptr;

        internal static void on_browser_destroyed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var call = new CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.RequestExecution();
            browser_release = call.browser_release;
        }

        // get_load_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_load_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_load_handler_delegate get_load_handler_native;
        private static IntPtr get_load_handler_native_ptr;

        internal static void get_load_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var call = new CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // on_context_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_created_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release);
        private static on_context_created_delegate on_context_created_native;
        private static IntPtr on_context_created_native_ptr;

        internal static void on_context_created(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release) {
            var call = new CfxRenderProcessHandlerOnContextCreatedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.frame = frame;
            call.context = context;
            call.RequestExecution();
            browser_release = call.browser_release;
            frame_release = call.frame_release;
            context_release = call.context_release;
        }

        // on_context_released
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_released_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release);
        private static on_context_released_delegate on_context_released_native;
        private static IntPtr on_context_released_native_ptr;

        internal static void on_context_released(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release) {
            var call = new CfxRenderProcessHandlerOnContextReleasedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.frame = frame;
            call.context = context;
            call.RequestExecution();
            browser_release = call.browser_release;
            frame_release = call.frame_release;
            context_release = call.context_release;
        }

        // on_uncaught_exception
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_uncaught_exception_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release, IntPtr exception, out int exception_release, IntPtr stackTrace, out int stackTrace_release);
        private static on_uncaught_exception_delegate on_uncaught_exception_native;
        private static IntPtr on_uncaught_exception_native_ptr;

        internal static void on_uncaught_exception(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr context, out int context_release, IntPtr exception, out int exception_release, IntPtr stackTrace, out int stackTrace_release) {
            var call = new CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.frame = frame;
            call.context = context;
            call.exception = exception;
            call.stackTrace = stackTrace;
            call.RequestExecution();
            browser_release = call.browser_release;
            frame_release = call.frame_release;
            context_release = call.context_release;
            exception_release = call.exception_release;
            stackTrace_release = call.stackTrace_release;
        }

        // on_focused_node_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_focused_node_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr node, out int node_release);
        private static on_focused_node_changed_delegate on_focused_node_changed_native;
        private static IntPtr on_focused_node_changed_native_ptr;

        internal static void on_focused_node_changed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr node, out int node_release) {
            var call = new CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.frame = frame;
            call.node = node;
            call.RequestExecution();
            browser_release = call.browser_release;
            frame_release = call.frame_release;
            node_release = call.node_release;
        }

        // on_process_message_received
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_process_message_received_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release);
        private static on_process_message_received_delegate on_process_message_received_native;
        private static IntPtr on_process_message_received_native_ptr;

        internal static void on_process_message_received(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, int source_process, IntPtr message, out int message_release) {
            var call = new CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.browser = browser;
            call.frame = frame;
            call.source_process = source_process;
            call.message = message;
            call.RequestExecution();
            browser_release = call.browser_release;
            frame_release = call.frame_release;
            message_release = call.message_release;
            __retval = call.__retval;
        }

    }
}
