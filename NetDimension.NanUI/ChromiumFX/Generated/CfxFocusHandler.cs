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
	/// Implement this structure to handle events related to focus. The functions of
	/// this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_focus_handler_capi.h">cef/include/capi/cef_focus_handler_capi.h</see>.
	/// </remarks>
	public class CfxFocusHandler : CfxBase {

        static CfxFocusHandler () {
            CfxApiLoader.LoadCfxFocusHandlerApi();
        }

        internal static CfxFocusHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_focus_handler_get_gc_handle(nativePtr);
            return (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_take_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_focus_handler_on_take_focus_delegate(IntPtr gcHandlePtr, IntPtr browser, int next);
        private static cfx_focus_handler_on_take_focus_delegate cfx_focus_handler_on_take_focus;
        private static IntPtr cfx_focus_handler_on_take_focus_ptr;

        internal static void on_take_focus(IntPtr gcHandlePtr, IntPtr browser, int next) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnTakeFocusEventArgs(browser, next);
            var eventHandler = self.m_OnTakeFocus;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_set_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_focus_handler_on_set_focus_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source);
        private static cfx_focus_handler_on_set_focus_delegate cfx_focus_handler_on_set_focus;
        private static IntPtr cfx_focus_handler_on_set_focus_ptr;

        internal static void on_set_focus(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int source) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnSetFocusEventArgs(browser, source);
            var eventHandler = self.m_OnSetFocus;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_got_focus
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_focus_handler_on_got_focus_delegate(IntPtr gcHandlePtr, IntPtr browser);
        private static cfx_focus_handler_on_got_focus_delegate cfx_focus_handler_on_got_focus;
        private static IntPtr cfx_focus_handler_on_got_focus_ptr;

        internal static void on_got_focus(IntPtr gcHandlePtr, IntPtr browser) {
            var self = (CfxFocusHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnGotFocusEventArgs(browser);
            var eventHandler = self.m_OnGotFocus;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        internal CfxFocusHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxFocusHandler() : base(CfxApi.cfx_focus_handler_ctor) {}

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
                        if(cfx_focus_handler_on_take_focus == null) {
                            cfx_focus_handler_on_take_focus = on_take_focus;
                            cfx_focus_handler_on_take_focus_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_focus_handler_on_take_focus);
                        }
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 0, cfx_focus_handler_on_take_focus_ptr);
                    }
                    m_OnTakeFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTakeFocus -= value;
                    if(m_OnTakeFocus == null) {
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_focus_handler_on_set_focus == null) {
                            cfx_focus_handler_on_set_focus = on_set_focus;
                            cfx_focus_handler_on_set_focus_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_focus_handler_on_set_focus);
                        }
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 1, cfx_focus_handler_on_set_focus_ptr);
                    }
                    m_OnSetFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnSetFocus -= value;
                    if(m_OnSetFocus == null) {
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
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
                        if(cfx_focus_handler_on_got_focus == null) {
                            cfx_focus_handler_on_got_focus = on_got_focus;
                            cfx_focus_handler_on_got_focus_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_focus_handler_on_got_focus);
                        }
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 2, cfx_focus_handler_on_got_focus_ptr);
                    }
                    m_OnGotFocus += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnGotFocus -= value;
                    if(m_OnGotFocus == null) {
                        CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnGotFocusEventHandler m_OnGotFocus;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnTakeFocus != null) {
                m_OnTakeFocus = null;
                CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnSetFocus != null) {
                m_OnSetFocus = null;
                CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnGotFocus != null) {
                m_OnGotFocus = null;
                CfxApi.cfx_focus_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxOnTakeFocusEventArgs(IntPtr browser, int next) {
                m_browser = browser;
                m_next = next;
            }

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

            internal CfxOnSetFocusEventArgs(IntPtr browser, int source) {
                m_browser = browser;
                m_source = source;
            }

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

            internal CfxOnGotFocusEventArgs(IntPtr browser) {
                m_browser = browser;
            }

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
