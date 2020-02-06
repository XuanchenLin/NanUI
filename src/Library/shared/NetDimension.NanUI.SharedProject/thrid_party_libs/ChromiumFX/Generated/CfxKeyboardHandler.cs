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
    /// Implement this structure to handle events related to keyboard input. The
    /// functions of this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
    /// </remarks>
    public class CfxKeyboardHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_pre_key_event_native = on_pre_key_event;
            on_key_event_native = on_key_event;

            on_pre_key_event_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_pre_key_event_native);
            on_key_event_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_key_event_native);
        }

        // on_pre_key_event
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_pre_key_event_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr @event, IntPtr os_event, out int is_keyboard_shortcut);
        private static on_pre_key_event_delegate on_pre_key_event_native;
        private static IntPtr on_pre_key_event_native_ptr;

        internal static void on_pre_key_event(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr @event, IntPtr os_event, out int is_keyboard_shortcut) {
            var self = (CfxKeyboardHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                is_keyboard_shortcut = default(int);
                return;
            }
            var e = new CfxOnPreKeyEventEventArgs();
            e.m_browser = browser;
            e.m_event = @event;
            e.m_os_event = os_event;
            self.m_OnPreKeyEvent?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            is_keyboard_shortcut = e.m_is_keyboard_shortcut;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_key_event
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_key_event_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr @event, IntPtr os_event);
        private static on_key_event_delegate on_key_event_native;
        private static IntPtr on_key_event_native_ptr;

        internal static void on_key_event(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr @event, IntPtr os_event) {
            var self = (CfxKeyboardHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxOnKeyEventEventArgs();
            e.m_browser = browser;
            e.m_event = @event;
            e.m_os_event = os_event;
            self.m_OnKeyEvent?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxKeyboardHandler() : base(CfxApi.KeyboardHandler.cfx_keyboard_handler_ctor) {}

        /// <summary>
        /// Called before a keyboard event is sent to the renderer. |Event| contains
        /// information about the keyboard event. |OsEvent| is the operating system
        /// event message, if any. Return true (1) if the event was handled or false
        /// (0) otherwise. If the event will be handled in on_key_event() as a keyboard
        /// shortcut set |IsKeyboardShortcut| to true (1) and return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPreKeyEventEventHandler OnPreKeyEvent {
            add {
                lock(eventLock) {
                    if(m_OnPreKeyEvent == null) {
                        CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 0, on_pre_key_event_native_ptr);
                    }
                    m_OnPreKeyEvent += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPreKeyEvent -= value;
                    if(m_OnPreKeyEvent == null) {
                        CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPreKeyEventEventHandler m_OnPreKeyEvent;

        /// <summary>
        /// Called after the renderer and JavaScript in the page has had a chance to
        /// handle the event. |Event| contains information about the keyboard event.
        /// |OsEvent| is the operating system event message, if any. Return true (1)
        /// if the keyboard event was handled or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnKeyEventEventHandler OnKeyEvent {
            add {
                lock(eventLock) {
                    if(m_OnKeyEvent == null) {
                        CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 1, on_key_event_native_ptr);
                    }
                    m_OnKeyEvent += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnKeyEvent -= value;
                    if(m_OnKeyEvent == null) {
                        CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnKeyEventEventHandler m_OnKeyEvent;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnPreKeyEvent != null) {
                m_OnPreKeyEvent = null;
                CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnKeyEvent != null) {
                m_OnKeyEvent = null;
                CfxApi.KeyboardHandler.cfx_keyboard_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called before a keyboard event is sent to the renderer. |Event| contains
        /// information about the keyboard event. |OsEvent| is the operating system
        /// event message, if any. Return true (1) if the event was handled or false
        /// (0) otherwise. If the event will be handled in on_key_event() as a keyboard
        /// shortcut set |IsKeyboardShortcut| to true (1) and return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPreKeyEventEventHandler(object sender, CfxOnPreKeyEventEventArgs e);

        /// <summary>
        /// Called before a keyboard event is sent to the renderer. |Event| contains
        /// information about the keyboard event. |OsEvent| is the operating system
        /// event message, if any. Return true (1) if the event was handled or false
        /// (0) otherwise. If the event will be handled in on_key_event() as a keyboard
        /// shortcut set |IsKeyboardShortcut| to true (1) and return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPreKeyEventEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_event;
            internal CfxKeyEvent m_event_wrapped;
            internal IntPtr m_os_event;
            internal int m_is_keyboard_shortcut;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnPreKeyEventEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxKeyboardHandler.OnPreKeyEvent"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Event parameter for the <see cref="CfxKeyboardHandler.OnPreKeyEvent"/> callback.
            /// </summary>
            public CfxKeyEvent Event {
                get {
                    CheckAccess();
                    if(m_event_wrapped == null) m_event_wrapped = CfxKeyEvent.Wrap(m_event);
                    return m_event_wrapped;
                }
            }
            /// <summary>
            /// Get the OsEvent parameter for the <see cref="CfxKeyboardHandler.OnPreKeyEvent"/> callback.
            /// </summary>
            public IntPtr OsEvent {
                get {
                    CheckAccess();
                    return m_os_event;
                }
            }
            /// <summary>
            /// Set the IsKeyboardShortcut out parameter for the <see cref="CfxKeyboardHandler.OnPreKeyEvent"/> callback.
            /// </summary>
            public bool IsKeyboardShortcut {
                set {
                    CheckAccess();
                    m_is_keyboard_shortcut = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxKeyboardHandler.OnPreKeyEvent"/> callback.
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
                return String.Format("Browser={{{0}}}, Event={{{1}}}, OsEvent={{{2}}}", Browser, Event, OsEvent);
            }
        }

        /// <summary>
        /// Called after the renderer and JavaScript in the page has had a chance to
        /// handle the event. |Event| contains information about the keyboard event.
        /// |OsEvent| is the operating system event message, if any. Return true (1)
        /// if the keyboard event was handled or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnKeyEventEventHandler(object sender, CfxOnKeyEventEventArgs e);

        /// <summary>
        /// Called after the renderer and JavaScript in the page has had a chance to
        /// handle the event. |Event| contains information about the keyboard event.
        /// |OsEvent| is the operating system event message, if any. Return true (1)
        /// if the keyboard event was handled or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnKeyEventEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_event;
            internal CfxKeyEvent m_event_wrapped;
            internal IntPtr m_os_event;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnKeyEventEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxKeyboardHandler.OnKeyEvent"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Event parameter for the <see cref="CfxKeyboardHandler.OnKeyEvent"/> callback.
            /// </summary>
            public CfxKeyEvent Event {
                get {
                    CheckAccess();
                    if(m_event_wrapped == null) m_event_wrapped = CfxKeyEvent.Wrap(m_event);
                    return m_event_wrapped;
                }
            }
            /// <summary>
            /// Get the OsEvent parameter for the <see cref="CfxKeyboardHandler.OnKeyEvent"/> callback.
            /// </summary>
            public IntPtr OsEvent {
                get {
                    CheckAccess();
                    return m_os_event;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxKeyboardHandler.OnKeyEvent"/> callback.
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
                return String.Format("Browser={{{0}}}, Event={{{1}}}, OsEvent={{{2}}}", Browser, Event, OsEvent);
            }
        }

    }
}
