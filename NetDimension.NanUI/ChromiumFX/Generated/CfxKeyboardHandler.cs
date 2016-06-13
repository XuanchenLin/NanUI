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
	/// Implement this structure to handle events related to keyboard input. The
	/// functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_keyboard_handler_capi.h">cef/include/capi/cef_keyboard_handler_capi.h</see>.
	/// </remarks>
	public class CfxKeyboardHandler : CfxBase {

        static CfxKeyboardHandler () {
            CfxApiLoader.LoadCfxKeyboardHandlerApi();
        }

        internal static CfxKeyboardHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_keyboard_handler_get_gc_handle(nativePtr);
            return (CfxKeyboardHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_pre_key_event
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_keyboard_handler_on_pre_key_event_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr @event, IntPtr os_event, out int is_keyboard_shortcut);
        private static cfx_keyboard_handler_on_pre_key_event_delegate cfx_keyboard_handler_on_pre_key_event;
        private static IntPtr cfx_keyboard_handler_on_pre_key_event_ptr;

        internal static void on_pre_key_event(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr @event, IntPtr os_event, out int is_keyboard_shortcut) {
            var self = (CfxKeyboardHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                is_keyboard_shortcut = default(int);
                return;
            }
            var e = new CfxOnPreKeyEventEventArgs(browser, @event, os_event);
            var eventHandler = self.m_OnPreKeyEvent;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            is_keyboard_shortcut = e.m_is_keyboard_shortcut;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_key_event
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_keyboard_handler_on_key_event_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr @event, IntPtr os_event);
        private static cfx_keyboard_handler_on_key_event_delegate cfx_keyboard_handler_on_key_event;
        private static IntPtr cfx_keyboard_handler_on_key_event_ptr;

        internal static void on_key_event(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr @event, IntPtr os_event) {
            var self = (CfxKeyboardHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnKeyEventEventArgs(browser, @event, os_event);
            var eventHandler = self.m_OnKeyEvent;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxKeyboardHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxKeyboardHandler() : base(CfxApi.cfx_keyboard_handler_ctor) {}

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
                        if(cfx_keyboard_handler_on_pre_key_event == null) {
                            cfx_keyboard_handler_on_pre_key_event = on_pre_key_event;
                            cfx_keyboard_handler_on_pre_key_event_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_keyboard_handler_on_pre_key_event);
                        }
                        CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 0, cfx_keyboard_handler_on_pre_key_event_ptr);
                    }
                    m_OnPreKeyEvent += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPreKeyEvent -= value;
                    if(m_OnPreKeyEvent == null) {
                        CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_keyboard_handler_on_key_event == null) {
                            cfx_keyboard_handler_on_key_event = on_key_event;
                            cfx_keyboard_handler_on_key_event_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_keyboard_handler_on_key_event);
                        }
                        CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 1, cfx_keyboard_handler_on_key_event_ptr);
                    }
                    m_OnKeyEvent += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnKeyEvent -= value;
                    if(m_OnKeyEvent == null) {
                        CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnKeyEventEventHandler m_OnKeyEvent;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnPreKeyEvent != null) {
                m_OnPreKeyEvent = null;
                CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnKeyEvent != null) {
                m_OnKeyEvent = null;
                CfxApi.cfx_keyboard_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxOnPreKeyEventEventArgs(IntPtr browser, IntPtr @event, IntPtr os_event) {
                m_browser = browser;
                m_event = @event;
                m_os_event = os_event;
            }

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

            internal CfxOnKeyEventEventArgs(IntPtr browser, IntPtr @event, IntPtr os_event) {
                m_browser = browser;
                m_event = @event;
                m_os_event = os_event;
            }

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
