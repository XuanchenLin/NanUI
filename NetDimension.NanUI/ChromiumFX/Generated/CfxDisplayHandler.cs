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
	/// Implement this structure to handle events related to browser display state.
	/// The functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
	/// </remarks>
	public class CfxDisplayHandler : CfxBase {

        static CfxDisplayHandler () {
            CfxApiLoader.LoadCfxDisplayHandlerApi();
        }

        internal static CfxDisplayHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_display_handler_get_gc_handle(nativePtr);
            return (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_address_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_address_change_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr url_str, int url_length);
        private static cfx_display_handler_on_address_change_delegate cfx_display_handler_on_address_change;
        private static IntPtr cfx_display_handler_on_address_change_ptr;

        internal static void on_address_change(IntPtr gcHandlePtr, IntPtr browser, IntPtr frame, IntPtr url_str, int url_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnAddressChangeEventArgs(browser, frame, url_str, url_length);
            var eventHandler = self.m_OnAddressChange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_frame_wrapped == null) CfxApi.cfx_release(e.m_frame);
        }

        // on_title_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_title_change_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr title_str, int title_length);
        private static cfx_display_handler_on_title_change_delegate cfx_display_handler_on_title_change;
        private static IntPtr cfx_display_handler_on_title_change_ptr;

        internal static void on_title_change(IntPtr gcHandlePtr, IntPtr browser, IntPtr title_str, int title_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnTitleChangeEventArgs(browser, title_str, title_length);
            var eventHandler = self.m_OnTitleChange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_favicon_urlchange
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_favicon_urlchange_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr icon_urls);
        private static cfx_display_handler_on_favicon_urlchange_delegate cfx_display_handler_on_favicon_urlchange;
        private static IntPtr cfx_display_handler_on_favicon_urlchange_ptr;

        internal static void on_favicon_urlchange(IntPtr gcHandlePtr, IntPtr browser, IntPtr icon_urls) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnFaviconUrlchangeEventArgs(browser, icon_urls);
            var eventHandler = self.m_OnFaviconUrlchange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_fullscreen_mode_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_fullscreen_mode_change_delegate(IntPtr gcHandlePtr, IntPtr browser, int fullscreen);
        private static cfx_display_handler_on_fullscreen_mode_change_delegate cfx_display_handler_on_fullscreen_mode_change;
        private static IntPtr cfx_display_handler_on_fullscreen_mode_change_ptr;

        internal static void on_fullscreen_mode_change(IntPtr gcHandlePtr, IntPtr browser, int fullscreen) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnFullscreenModeChangeEventArgs(browser, fullscreen);
            var eventHandler = self.m_OnFullscreenModeChange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_tooltip
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_tooltip_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, ref IntPtr text_str, ref int text_length);
        private static cfx_display_handler_on_tooltip_delegate cfx_display_handler_on_tooltip;
        private static IntPtr cfx_display_handler_on_tooltip_ptr;

        internal static void on_tooltip(IntPtr gcHandlePtr, out int __retval, IntPtr browser, ref IntPtr text_str, ref int text_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnTooltipEventArgs(browser, text_str, text_length);
            var eventHandler = self.m_OnTooltip;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_text_changed) {
                var text_pinned = new PinnedString(e.m_text_wrapped);
                text_str = text_pinned.Obj.PinnedPtr;
                text_length = text_pinned.Length;
            }
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_status_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_status_message_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr value_str, int value_length);
        private static cfx_display_handler_on_status_message_delegate cfx_display_handler_on_status_message;
        private static IntPtr cfx_display_handler_on_status_message_ptr;

        internal static void on_status_message(IntPtr gcHandlePtr, IntPtr browser, IntPtr value_str, int value_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnStatusMessageEventArgs(browser, value_str, value_length);
            var eventHandler = self.m_OnStatusMessage;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_console_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_display_handler_on_console_message_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr message_str, int message_length, IntPtr source_str, int source_length, int line);
        private static cfx_display_handler_on_console_message_delegate cfx_display_handler_on_console_message;
        private static IntPtr cfx_display_handler_on_console_message_ptr;

        internal static void on_console_message(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr message_str, int message_length, IntPtr source_str, int source_length, int line) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnConsoleMessageEventArgs(browser, message_str, message_length, source_str, source_length, line);
            var eventHandler = self.m_OnConsoleMessage;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxDisplayHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxDisplayHandler() : base(CfxApi.cfx_display_handler_ctor) {}

        /// <summary>
        /// Called when a frame's address has changed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnAddressChangeEventHandler OnAddressChange {
            add {
                lock(eventLock) {
                    if(m_OnAddressChange == null) {
                        if(cfx_display_handler_on_address_change == null) {
                            cfx_display_handler_on_address_change = on_address_change;
                            cfx_display_handler_on_address_change_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_address_change);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 0, cfx_display_handler_on_address_change_ptr);
                    }
                    m_OnAddressChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnAddressChange -= value;
                    if(m_OnAddressChange == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnAddressChangeEventHandler m_OnAddressChange;

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnTitleChangeEventHandler OnTitleChange {
            add {
                lock(eventLock) {
                    if(m_OnTitleChange == null) {
                        if(cfx_display_handler_on_title_change == null) {
                            cfx_display_handler_on_title_change = on_title_change;
                            cfx_display_handler_on_title_change_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_title_change);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 1, cfx_display_handler_on_title_change_ptr);
                    }
                    m_OnTitleChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTitleChange -= value;
                    if(m_OnTitleChange == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnTitleChangeEventHandler m_OnTitleChange;

        /// <summary>
        /// Called when the page icon changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnFaviconUrlchangeEventHandler OnFaviconUrlchange {
            add {
                lock(eventLock) {
                    if(m_OnFaviconUrlchange == null) {
                        if(cfx_display_handler_on_favicon_urlchange == null) {
                            cfx_display_handler_on_favicon_urlchange = on_favicon_urlchange;
                            cfx_display_handler_on_favicon_urlchange_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_favicon_urlchange);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 2, cfx_display_handler_on_favicon_urlchange_ptr);
                    }
                    m_OnFaviconUrlchange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFaviconUrlchange -= value;
                    if(m_OnFaviconUrlchange == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFaviconUrlchangeEventHandler m_OnFaviconUrlchange;

        /// <summary>
        /// Called when web content in the page has toggled fullscreen mode. If
        /// |Fullscreen| is true (1) the content will automatically be sized to fill
        /// the browser content area. If |Fullscreen| is false (0) the content will
        /// automatically return to its original size and position. The client is
        /// responsible for resizing the browser if desired.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnFullscreenModeChangeEventHandler OnFullscreenModeChange {
            add {
                lock(eventLock) {
                    if(m_OnFullscreenModeChange == null) {
                        if(cfx_display_handler_on_fullscreen_mode_change == null) {
                            cfx_display_handler_on_fullscreen_mode_change = on_fullscreen_mode_change;
                            cfx_display_handler_on_fullscreen_mode_change_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_fullscreen_mode_change);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 3, cfx_display_handler_on_fullscreen_mode_change_ptr);
                    }
                    m_OnFullscreenModeChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFullscreenModeChange -= value;
                    if(m_OnFullscreenModeChange == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFullscreenModeChangeEventHandler m_OnFullscreenModeChange;

        /// <summary>
        /// Called when the browser is about to display a tooltip. |Text| contains the
        /// text that will be displayed in the tooltip. To handle the display of the
        /// tooltip yourself return true (1). Otherwise, you can optionally modify
        /// |Text| and then return false (0) to allow the browser to display the
        /// tooltip. When window rendering is disabled the application is responsible
        /// for drawing tooltips and the return value is ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnTooltipEventHandler OnTooltip {
            add {
                lock(eventLock) {
                    if(m_OnTooltip == null) {
                        if(cfx_display_handler_on_tooltip == null) {
                            cfx_display_handler_on_tooltip = on_tooltip;
                            cfx_display_handler_on_tooltip_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_tooltip);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 4, cfx_display_handler_on_tooltip_ptr);
                    }
                    m_OnTooltip += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTooltip -= value;
                    if(m_OnTooltip == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnTooltipEventHandler m_OnTooltip;

        /// <summary>
        /// Called when the browser receives a status message. |Value| contains the
        /// text that will be displayed in the status message.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnStatusMessageEventHandler OnStatusMessage {
            add {
                lock(eventLock) {
                    if(m_OnStatusMessage == null) {
                        if(cfx_display_handler_on_status_message == null) {
                            cfx_display_handler_on_status_message = on_status_message;
                            cfx_display_handler_on_status_message_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_status_message);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 5, cfx_display_handler_on_status_message_ptr);
                    }
                    m_OnStatusMessage += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnStatusMessage -= value;
                    if(m_OnStatusMessage == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnStatusMessageEventHandler m_OnStatusMessage;

        /// <summary>
        /// Called to display a console message. Return true (1) to stop the message
        /// from being output to the console.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnConsoleMessageEventHandler OnConsoleMessage {
            add {
                lock(eventLock) {
                    if(m_OnConsoleMessage == null) {
                        if(cfx_display_handler_on_console_message == null) {
                            cfx_display_handler_on_console_message = on_console_message;
                            cfx_display_handler_on_console_message_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_display_handler_on_console_message);
                        }
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 6, cfx_display_handler_on_console_message_ptr);
                    }
                    m_OnConsoleMessage += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnConsoleMessage -= value;
                    if(m_OnConsoleMessage == null) {
                        CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnConsoleMessageEventHandler m_OnConsoleMessage;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnAddressChange != null) {
                m_OnAddressChange = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnTitleChange != null) {
                m_OnTitleChange = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnFaviconUrlchange != null) {
                m_OnFaviconUrlchange = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnFullscreenModeChange != null) {
                m_OnFullscreenModeChange = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnTooltip != null) {
                m_OnTooltip = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnStatusMessage != null) {
                m_OnStatusMessage = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnConsoleMessage != null) {
                m_OnConsoleMessage = null;
                CfxApi.cfx_display_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called when a frame's address has changed.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxOnAddressChangeEventHandler(object sender, CfxOnAddressChangeEventArgs e);

        /// <summary>
        /// Called when a frame's address has changed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnAddressChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_url_str;
            internal int m_url_length;
            internal string m_url;

            internal CfxOnAddressChangeEventArgs(IntPtr browser, IntPtr frame, IntPtr url_str, int url_length) {
                m_browser = browser;
                m_frame = frame;
                m_url_str = url_str;
                m_url_length = url_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnAddressChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxDisplayHandler.OnAddressChange"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Url parameter for the <see cref="CfxDisplayHandler.OnAddressChange"/> callback.
            /// </summary>
            public string Url {
                get {
                    CheckAccess();
                    m_url = StringFunctions.PtrToStringUni(m_url_str, m_url_length);
                    return m_url;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Url={{{2}}}", Browser, Frame, Url);
            }
        }

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnTitleChangeEventHandler(object sender, CfxOnTitleChangeEventArgs e);

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnTitleChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_title_str;
            internal int m_title_length;
            internal string m_title;

            internal CfxOnTitleChangeEventArgs(IntPtr browser, IntPtr title_str, int title_length) {
                m_browser = browser;
                m_title_str = title_str;
                m_title_length = title_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnTitleChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Title parameter for the <see cref="CfxDisplayHandler.OnTitleChange"/> callback.
            /// </summary>
            public string Title {
                get {
                    CheckAccess();
                    m_title = StringFunctions.PtrToStringUni(m_title_str, m_title_length);
                    return m_title;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Title={{{1}}}", Browser, Title);
            }
        }

        /// <summary>
        /// Called when the page icon changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnFaviconUrlchangeEventHandler(object sender, CfxOnFaviconUrlchangeEventArgs e);

        /// <summary>
        /// Called when the page icon changes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnFaviconUrlchangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_icon_urls;

            internal CfxOnFaviconUrlchangeEventArgs(IntPtr browser, IntPtr icon_urls) {
                m_browser = browser;
                m_icon_urls = icon_urls;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnFaviconUrlchange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IconUrls parameter for the <see cref="CfxDisplayHandler.OnFaviconUrlchange"/> callback.
            /// </summary>
            public System.Collections.Generic.List<string> IconUrls {
                get {
                    CheckAccess();
                    return StringFunctions.WrapCfxStringList(m_icon_urls);
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, IconUrls={{{1}}}", Browser, IconUrls);
            }
        }

        /// <summary>
        /// Called when web content in the page has toggled fullscreen mode. If
        /// |Fullscreen| is true (1) the content will automatically be sized to fill
        /// the browser content area. If |Fullscreen| is false (0) the content will
        /// automatically return to its original size and position. The client is
        /// responsible for resizing the browser if desired.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnFullscreenModeChangeEventHandler(object sender, CfxOnFullscreenModeChangeEventArgs e);

        /// <summary>
        /// Called when web content in the page has toggled fullscreen mode. If
        /// |Fullscreen| is true (1) the content will automatically be sized to fill
        /// the browser content area. If |Fullscreen| is false (0) the content will
        /// automatically return to its original size and position. The client is
        /// responsible for resizing the browser if desired.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnFullscreenModeChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_fullscreen;

            internal CfxOnFullscreenModeChangeEventArgs(IntPtr browser, int fullscreen) {
                m_browser = browser;
                m_fullscreen = fullscreen;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnFullscreenModeChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Fullscreen parameter for the <see cref="CfxDisplayHandler.OnFullscreenModeChange"/> callback.
            /// </summary>
            public bool Fullscreen {
                get {
                    CheckAccess();
                    return 0 != m_fullscreen;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Fullscreen={{{1}}}", Browser, Fullscreen);
            }
        }

        /// <summary>
        /// Called when the browser is about to display a tooltip. |Text| contains the
        /// text that will be displayed in the tooltip. To handle the display of the
        /// tooltip yourself return true (1). Otherwise, you can optionally modify
        /// |Text| and then return false (0) to allow the browser to display the
        /// tooltip. When window rendering is disabled the application is responsible
        /// for drawing tooltips and the return value is ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnTooltipEventHandler(object sender, CfxOnTooltipEventArgs e);

        /// <summary>
        /// Called when the browser is about to display a tooltip. |Text| contains the
        /// text that will be displayed in the tooltip. To handle the display of the
        /// tooltip yourself return true (1). Otherwise, you can optionally modify
        /// |Text| and then return false (0) to allow the browser to display the
        /// tooltip. When window rendering is disabled the application is responsible
        /// for drawing tooltips and the return value is ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnTooltipEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_text_str;
            internal int m_text_length;
            internal string m_text_wrapped;
            internal bool m_text_changed;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnTooltipEventArgs(IntPtr browser, IntPtr text_str, int text_length) {
                m_browser = browser;
                m_text_str = text_str;
                m_text_length = text_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnTooltip"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get or set the Text parameter for the <see cref="CfxDisplayHandler.OnTooltip"/> callback.
            /// </summary>
            public string Text {
                get {
                    CheckAccess();
                    if(!m_text_changed && m_text_wrapped == null) {
                        m_text_wrapped = StringFunctions.PtrToStringUni(m_text_str, m_text_length);
                    }
                    return m_text_wrapped;
                }
                set {
                    CheckAccess();
                    m_text_wrapped = value;
                    m_text_changed = true;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxDisplayHandler.OnTooltip"/> callback.
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
                return String.Format("Browser={{{0}}}, Text={{{1}}}", Browser, Text);
            }
        }

        /// <summary>
        /// Called when the browser receives a status message. |Value| contains the
        /// text that will be displayed in the status message.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnStatusMessageEventHandler(object sender, CfxOnStatusMessageEventArgs e);

        /// <summary>
        /// Called when the browser receives a status message. |Value| contains the
        /// text that will be displayed in the status message.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnStatusMessageEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_value_str;
            internal int m_value_length;
            internal string m_value;

            internal CfxOnStatusMessageEventArgs(IntPtr browser, IntPtr value_str, int value_length) {
                m_browser = browser;
                m_value_str = value_str;
                m_value_length = value_length;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnStatusMessage"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfxDisplayHandler.OnStatusMessage"/> callback.
            /// </summary>
            public string Value {
                get {
                    CheckAccess();
                    m_value = StringFunctions.PtrToStringUni(m_value_str, m_value_length);
                    return m_value;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Value={{{1}}}", Browser, Value);
            }
        }

        /// <summary>
        /// Called to display a console message. Return true (1) to stop the message
        /// from being output to the console.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnConsoleMessageEventHandler(object sender, CfxOnConsoleMessageEventArgs e);

        /// <summary>
        /// Called to display a console message. Return true (1) to stop the message
        /// from being output to the console.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnConsoleMessageEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_message_str;
            internal int m_message_length;
            internal string m_message;
            internal IntPtr m_source_str;
            internal int m_source_length;
            internal string m_source;
            internal int m_line;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnConsoleMessageEventArgs(IntPtr browser, IntPtr message_str, int message_length, IntPtr source_str, int source_length, int line) {
                m_browser = browser;
                m_message_str = message_str;
                m_message_length = message_length;
                m_source_str = source_str;
                m_source_length = source_length;
                m_line = line;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Message parameter for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
            /// </summary>
            public string Message {
                get {
                    CheckAccess();
                    m_message = StringFunctions.PtrToStringUni(m_message_str, m_message_length);
                    return m_message;
                }
            }
            /// <summary>
            /// Get the Source parameter for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
            /// </summary>
            public string Source {
                get {
                    CheckAccess();
                    m_source = StringFunctions.PtrToStringUni(m_source_str, m_source_length);
                    return m_source;
                }
            }
            /// <summary>
            /// Get the Line parameter for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
            /// </summary>
            public int Line {
                get {
                    CheckAccess();
                    return m_line;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
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
                return String.Format("Browser={{{0}}}, Message={{{1}}}, Source={{{2}}}, Line={{{3}}}", Browser, Message, Source, Line);
            }
        }

    }
}
