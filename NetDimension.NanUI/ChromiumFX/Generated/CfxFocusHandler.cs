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
    /// Implement this structure to handle events related to focus. The functions of
    /// this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
    /// </remarks>
    public class CfxFocusHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_take_focus_native = on_take_focus;
            on_set_focus_native = on_set_focus;
            on_got_focus_native = on_got_focus;

            on_take_focus_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_take_focus_native);
            on_set_focus_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_set_focus_native);
            on_got_focus_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_got_focus_native);
        }

        // on_take_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_take_focus_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int next);
        private static on_take_focus_delegate on_take_focus_native;
        private static IntPtr on_take_focus_native_ptr;

        internal static void on_take_focus(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int next) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnTakeFocusEventArgs();
            e.m_browser = browser;
            e.m_next = next;
            self.m_OnTakeFocus?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_set_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_set_focus_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int source);
        private static on_set_focus_delegate on_set_focus_native;
        private static IntPtr on_set_focus_native_ptr;

        internal static void on_set_focus(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int source) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxOnSetFocusEventArgs();
            e.m_browser = browser;
            e.m_source = source;
            self.m_OnSetFocus?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_got_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_got_focus_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_got_focus_delegate on_got_focus_native;
        private static IntPtr on_got_focus_native_ptr;

        internal static void on_got_focus(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnGotFocusEventArgs();
            e.m_browser = browser;
            self.m_OnGotFocus?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        public CfxFocusHandler() : base(CfxApi.FocusHandler.cfx_focus_handler_ctor) {}

        /// <summary>
        /// Called when the browser component is about to loose focus. For instance, if
        /// focus was on the last HTML element and the user pressed the TAB key. |Next|
        /// will be true (1) if the browser is giving focus to the next component and
        /// false (0) if the browser is giving focus to the previous component.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnTakeFocusEventHandler OnTakeFocus {
            add {
                lock(eventLock) {
                    if(m_OnTakeFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 0, on_take_focus_native_ptr);
                    }
                    m_OnTakeFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTakeFocus -= value;
                    if(m_OnTakeFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnTakeFocusEventHandler m_OnTakeFocus;

        /// <summary>
        /// Called when the browser component is requesting focus. |Source| indicates
        /// where the focus request is originating from. Return false (0) to allow the
        /// focus to be set or true (1) to cancel setting the focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnSetFocusEventHandler OnSetFocus {
            add {
                lock(eventLock) {
                    if(m_OnSetFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 1, on_set_focus_native_ptr);
                    }
                    m_OnSetFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnSetFocus -= value;
                    if(m_OnSetFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnSetFocusEventHandler m_OnSetFocus;

        /// <summary>
        /// Called when the browser component has received focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnGotFocusEventHandler OnGotFocus {
            add {
                lock(eventLock) {
                    if(m_OnGotFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 2, on_got_focus_native_ptr);
                    }
                    m_OnGotFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnGotFocus -= value;
                    if(m_OnGotFocus == null) {
                        CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnGotFocusEventHandler m_OnGotFocus;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnTakeFocus != null) {
                m_OnTakeFocus = null;
                CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnSetFocus != null) {
                m_OnSetFocus = null;
                CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnGotFocus != null) {
                m_OnGotFocus = null;
                CfxApi.FocusHandler.cfx_focus_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called when the browser component is about to loose focus. For instance, if
        /// focus was on the last HTML element and the user pressed the TAB key. |Next|
        /// will be true (1) if the browser is giving focus to the next component and
        /// false (0) if the browser is giving focus to the previous component.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnTakeFocusEventHandler(object sender, CfxOnTakeFocusEventArgs e);

        /// <summary>
        /// Called when the browser component is about to loose focus. For instance, if
        /// focus was on the last HTML element and the user pressed the TAB key. |Next|
        /// will be true (1) if the browser is giving focus to the next component and
        /// false (0) if the browser is giving focus to the previous component.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnTakeFocusEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_next;

            internal CfxOnTakeFocusEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxFocusHandler.OnTakeFocus"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Next parameter for the <see cref="CfxFocusHandler.OnTakeFocus"/> callback.
            /// </summary>
            public bool Next {
                get {
                    CheckAccess();
                    return 0 != m_next;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Next={{{1}}}", Browser, Next);
            }
        }

        /// <summary>
        /// Called when the browser component is requesting focus. |Source| indicates
        /// where the focus request is originating from. Return false (0) to allow the
        /// focus to be set or true (1) to cancel setting the focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnSetFocusEventHandler(object sender, CfxOnSetFocusEventArgs e);

        /// <summary>
        /// Called when the browser component is requesting focus. |Source| indicates
        /// where the focus request is originating from. Return false (0) to allow the
        /// focus to be set or true (1) to cancel setting the focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnSetFocusEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_source;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnSetFocusEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxFocusHandler.OnSetFocus"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Source parameter for the <see cref="CfxFocusHandler.OnSetFocus"/> callback.
            /// </summary>
            public CfxFocusSource Source {
                get {
                    CheckAccess();
                    return (CfxFocusSource)m_source;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxFocusHandler.OnSetFocus"/> callback.
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
                return String.Format("Browser={{{0}}}, Source={{{1}}}", Browser, Source);
            }
        }

        /// <summary>
        /// Called when the browser component has received focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnGotFocusEventHandler(object sender, CfxOnGotFocusEventArgs e);

        /// <summary>
        /// Called when the browser component has received focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnGotFocusEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnGotFocusEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxFocusHandler.OnGotFocus"/> callback.
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

    }
}
