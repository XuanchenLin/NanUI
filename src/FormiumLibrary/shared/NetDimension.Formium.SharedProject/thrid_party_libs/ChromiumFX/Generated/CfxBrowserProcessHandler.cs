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
    /// Structure used to implement browser process callbacks. The functions of this
    /// structure will be called on the browser process main thread unless otherwise
    /// indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
    /// </remarks>
    public class CfxBrowserProcessHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_context_initialized_native = on_context_initialized;
            on_before_child_process_launch_native = on_before_child_process_launch;
            on_render_process_thread_created_native = on_render_process_thread_created;
            get_print_handler_native = get_print_handler;
            on_schedule_message_pump_work_native = on_schedule_message_pump_work;

            on_context_initialized_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_context_initialized_native);
            on_before_child_process_launch_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_child_process_launch_native);
            on_render_process_thread_created_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_render_process_thread_created_native);
            get_print_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_print_handler_native);
            on_schedule_message_pump_work_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_schedule_message_pump_work_native);
        }

        // on_context_initialized
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_initialized_delegate(IntPtr gcHandlePtr);
        private static on_context_initialized_delegate on_context_initialized_native;
        private static IntPtr on_context_initialized_native_ptr;

        internal static void on_context_initialized(IntPtr gcHandlePtr) {
            var self = (CfxBrowserProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxEventArgs();
            self.m_OnContextInitialized?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        // on_before_child_process_launch
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_child_process_launch_delegate(IntPtr gcHandlePtr, IntPtr command_line, out int command_line_release);
        private static on_before_child_process_launch_delegate on_before_child_process_launch_native;
        private static IntPtr on_before_child_process_launch_native_ptr;

        internal static void on_before_child_process_launch(IntPtr gcHandlePtr, IntPtr command_line, out int command_line_release) {
            var self = (CfxBrowserProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                command_line_release = 1;
                return;
            }
            var e = new CfxOnBeforeChildProcessLaunchEventArgs();
            e.m_command_line = command_line;
            self.m_OnBeforeChildProcessLaunch?.Invoke(self, e);
            e.m_isInvalid = true;
            command_line_release = e.m_command_line_wrapped == null? 1 : 0;
        }

        // on_render_process_thread_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_render_process_thread_created_delegate(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release);
        private static on_render_process_thread_created_delegate on_render_process_thread_created_native;
        private static IntPtr on_render_process_thread_created_native_ptr;

        internal static void on_render_process_thread_created(IntPtr gcHandlePtr, IntPtr extra_info, out int extra_info_release) {
            var self = (CfxBrowserProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                extra_info_release = 1;
                return;
            }
            var e = new CfxOnRenderProcessThreadCreatedEventArgs();
            e.m_extra_info = extra_info;
            self.m_OnRenderProcessThreadCreated?.Invoke(self, e);
            e.m_isInvalid = true;
            extra_info_release = e.m_extra_info_wrapped == null? 1 : 0;
        }

        // get_print_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_print_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_print_handler_delegate get_print_handler_native;
        private static IntPtr get_print_handler_native_ptr;

        internal static void get_print_handler(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxBrowserProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetPrintHandlerEventArgs();
            self.m_GetPrintHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxPrintHandler.Unwrap(e.m_returnValue);
        }

        // on_schedule_message_pump_work
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_schedule_message_pump_work_delegate(IntPtr gcHandlePtr, long delay_ms);
        private static on_schedule_message_pump_work_delegate on_schedule_message_pump_work_native;
        private static IntPtr on_schedule_message_pump_work_native_ptr;

        internal static void on_schedule_message_pump_work(IntPtr gcHandlePtr, long delay_ms) {
            var self = (CfxBrowserProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnScheduleMessagePumpWorkEventArgs();
            e.m_delay_ms = delay_ms;
            self.m_OnScheduleMessagePumpWork?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxBrowserProcessHandler() : base(CfxApi.BrowserProcessHandler.cfx_browser_process_handler_ctor) {}

        /// <summary>
        /// Called on the browser process UI thread immediately after the CEF context
        /// has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxEventHandler OnContextInitialized {
            add {
                lock(eventLock) {
                    if(m_OnContextInitialized == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 0, on_context_initialized_native_ptr);
                    }
                    m_OnContextInitialized += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextInitialized -= value;
                    if(m_OnContextInitialized == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_OnContextInitialized;

        /// <summary>
        /// Called before a child process is launched. Will be called on the browser
        /// process UI thread when launching a render process and on the browser
        /// process IO thread when launching a GPU or plugin process. Provides an
        /// opportunity to modify the child process command line. Do not keep a
        /// reference to |CommandLine| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeChildProcessLaunchEventHandler OnBeforeChildProcessLaunch {
            add {
                lock(eventLock) {
                    if(m_OnBeforeChildProcessLaunch == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 1, on_before_child_process_launch_native_ptr);
                    }
                    m_OnBeforeChildProcessLaunch += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeChildProcessLaunch -= value;
                    if(m_OnBeforeChildProcessLaunch == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeChildProcessLaunchEventHandler m_OnBeforeChildProcessLaunch;

        /// <summary>
        /// Called on the browser process IO thread after the main thread has been
        /// created for a new render process. Provides an opportunity to specify extra
        /// information that will be passed to
        /// CfxRenderProcessHandler.OnRenderThreadCreated() in the render
        /// process. Do not keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRenderProcessThreadCreatedEventHandler OnRenderProcessThreadCreated {
            add {
                lock(eventLock) {
                    if(m_OnRenderProcessThreadCreated == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 2, on_render_process_thread_created_native_ptr);
                    }
                    m_OnRenderProcessThreadCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRenderProcessThreadCreated -= value;
                    if(m_OnRenderProcessThreadCreated == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRenderProcessThreadCreatedEventHandler m_OnRenderProcessThreadCreated;

        /// <summary>
        /// Return the handler for printing on Linux. If a print handler is not
        /// provided then printing will not be supported on the Linux platform.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetPrintHandlerEventHandler GetPrintHandler {
            add {
                lock(eventLock) {
                    if(m_GetPrintHandler != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 3, get_print_handler_native_ptr);
                    m_GetPrintHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetPrintHandler -= value;
                    if(m_GetPrintHandler == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxPrintHandler provided by the event handler attached to the GetPrintHandler event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxPrintHandler RetrievePrintHandler() {
            var h = m_GetPrintHandler;
            if(h != null) {
                var e = new CfxGetPrintHandlerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetPrintHandlerEventHandler m_GetPrintHandler;

        /// <summary>
        /// Called from any thread when work has been scheduled for the browser process
        /// main (UI) thread. This callback is used in combination with CfxSettings.
        /// external_message_pump and cef_do_message_loop_work() in cases where the CEF
        /// message loop must be integrated into an existing application message loop
        /// (see additional comments and warnings on CfxDoMessageLoopWork). This
        /// callback should schedule a cef_do_message_loop_work() call to happen on the
        /// main (UI) thread. |DelayMs| is the requested delay in milliseconds. If
        /// |DelayMs| is &lt;= 0 then the call should happen reasonably soon. If
        /// |DelayMs| is > 0 then the call should be scheduled to happen after the
        /// specified delay and any currently pending scheduled call should be
        /// cancelled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnScheduleMessagePumpWorkEventHandler OnScheduleMessagePumpWork {
            add {
                lock(eventLock) {
                    if(m_OnScheduleMessagePumpWork == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 4, on_schedule_message_pump_work_native_ptr);
                    }
                    m_OnScheduleMessagePumpWork += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnScheduleMessagePumpWork -= value;
                    if(m_OnScheduleMessagePumpWork == null) {
                        CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnScheduleMessagePumpWorkEventHandler m_OnScheduleMessagePumpWork;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnContextInitialized != null) {
                m_OnContextInitialized = null;
                CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforeChildProcessLaunch != null) {
                m_OnBeforeChildProcessLaunch = null;
                CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnRenderProcessThreadCreated != null) {
                m_OnRenderProcessThreadCreated = null;
                CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetPrintHandler != null) {
                m_GetPrintHandler = null;
                CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnScheduleMessagePumpWork != null) {
                m_OnScheduleMessagePumpWork = null;
                CfxApi.BrowserProcessHandler.cfx_browser_process_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {


        /// <summary>
        /// Called before a child process is launched. Will be called on the browser
        /// process UI thread when launching a render process and on the browser
        /// process IO thread when launching a GPU or plugin process. Provides an
        /// opportunity to modify the child process command line. Do not keep a
        /// reference to |CommandLine| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeChildProcessLaunchEventHandler(object sender, CfxOnBeforeChildProcessLaunchEventArgs e);

        /// <summary>
        /// Called before a child process is launched. Will be called on the browser
        /// process UI thread when launching a render process and on the browser
        /// process IO thread when launching a GPU or plugin process. Provides an
        /// opportunity to modify the child process command line. Do not keep a
        /// reference to |CommandLine| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeChildProcessLaunchEventArgs : CfxEventArgs {

            internal IntPtr m_command_line;
            internal CfxCommandLine m_command_line_wrapped;

            internal CfxOnBeforeChildProcessLaunchEventArgs() {}

            /// <summary>
            /// Get the CommandLine parameter for the <see cref="CfxBrowserProcessHandler.OnBeforeChildProcessLaunch"/> callback.
            /// </summary>
            public CfxCommandLine CommandLine {
                get {
                    CheckAccess();
                    if(m_command_line_wrapped == null) m_command_line_wrapped = CfxCommandLine.Wrap(m_command_line);
                    return m_command_line_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("CommandLine={{{0}}}", CommandLine);
            }
        }

        /// <summary>
        /// Called on the browser process IO thread after the main thread has been
        /// created for a new render process. Provides an opportunity to specify extra
        /// information that will be passed to
        /// CfxRenderProcessHandler.OnRenderThreadCreated() in the render
        /// process. Do not keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRenderProcessThreadCreatedEventHandler(object sender, CfxOnRenderProcessThreadCreatedEventArgs e);

        /// <summary>
        /// Called on the browser process IO thread after the main thread has been
        /// created for a new render process. Provides an opportunity to specify extra
        /// information that will be passed to
        /// CfxRenderProcessHandler.OnRenderThreadCreated() in the render
        /// process. Do not keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRenderProcessThreadCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_extra_info;
            internal CfxListValue m_extra_info_wrapped;

            internal CfxOnRenderProcessThreadCreatedEventArgs() {}

            /// <summary>
            /// Get the ExtraInfo parameter for the <see cref="CfxBrowserProcessHandler.OnRenderProcessThreadCreated"/> callback.
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
        /// Return the handler for printing on Linux. If a print handler is not
        /// provided then printing will not be supported on the Linux platform.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetPrintHandlerEventHandler(object sender, CfxGetPrintHandlerEventArgs e);

        /// <summary>
        /// Return the handler for printing on Linux. If a print handler is not
        /// provided then printing will not be supported on the Linux platform.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetPrintHandlerEventArgs : CfxEventArgs {


            internal CfxPrintHandler m_returnValue;
            private bool returnValueSet;

            internal CfxGetPrintHandlerEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxBrowserProcessHandler.GetPrintHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxPrintHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Called from any thread when work has been scheduled for the browser process
        /// main (UI) thread. This callback is used in combination with CfxSettings.
        /// external_message_pump and cef_do_message_loop_work() in cases where the CEF
        /// message loop must be integrated into an existing application message loop
        /// (see additional comments and warnings on CfxDoMessageLoopWork). This
        /// callback should schedule a cef_do_message_loop_work() call to happen on the
        /// main (UI) thread. |DelayMs| is the requested delay in milliseconds. If
        /// |DelayMs| is &lt;= 0 then the call should happen reasonably soon. If
        /// |DelayMs| is > 0 then the call should be scheduled to happen after the
        /// specified delay and any currently pending scheduled call should be
        /// cancelled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnScheduleMessagePumpWorkEventHandler(object sender, CfxOnScheduleMessagePumpWorkEventArgs e);

        /// <summary>
        /// Called from any thread when work has been scheduled for the browser process
        /// main (UI) thread. This callback is used in combination with CfxSettings.
        /// external_message_pump and cef_do_message_loop_work() in cases where the CEF
        /// message loop must be integrated into an existing application message loop
        /// (see additional comments and warnings on CfxDoMessageLoopWork). This
        /// callback should schedule a cef_do_message_loop_work() call to happen on the
        /// main (UI) thread. |DelayMs| is the requested delay in milliseconds. If
        /// |DelayMs| is &lt;= 0 then the call should happen reasonably soon. If
        /// |DelayMs| is > 0 then the call should be scheduled to happen after the
        /// specified delay and any currently pending scheduled call should be
        /// cancelled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_process_handler_capi.h">cef/include/capi/cef_browser_process_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnScheduleMessagePumpWorkEventArgs : CfxEventArgs {

            internal long m_delay_ms;

            internal CfxOnScheduleMessagePumpWorkEventArgs() {}

            /// <summary>
            /// Get the DelayMs parameter for the <see cref="CfxBrowserProcessHandler.OnScheduleMessagePumpWork"/> callback.
            /// </summary>
            public long DelayMs {
                get {
                    CheckAccess();
                    return m_delay_ms;
                }
            }

            public override string ToString() {
                return String.Format("DelayMs={{{0}}}", DelayMs);
            }
        }

    }
}
