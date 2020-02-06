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
    /// Implement this structure to handle events related to browser display state.
    /// The functions of this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
    /// </remarks>
    public class CfxDisplayHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_address_change_native = on_address_change;
            on_title_change_native = on_title_change;
            on_favicon_urlchange_native = on_favicon_urlchange;
            on_fullscreen_mode_change_native = on_fullscreen_mode_change;
            on_tooltip_native = on_tooltip;
            on_status_message_native = on_status_message;
            on_console_message_native = on_console_message;
            on_auto_resize_native = on_auto_resize;
            on_loading_progress_change_native = on_loading_progress_change;

            on_address_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_address_change_native);
            on_title_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_title_change_native);
            on_favicon_urlchange_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_favicon_urlchange_native);
            on_fullscreen_mode_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_fullscreen_mode_change_native);
            on_tooltip_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_tooltip_native);
            on_status_message_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_status_message_native);
            on_console_message_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_console_message_native);
            on_auto_resize_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_auto_resize_native);
            on_loading_progress_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_loading_progress_change_native);
        }

        // on_address_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_address_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr url_str, int url_length);
        private static on_address_change_delegate on_address_change_native;
        private static IntPtr on_address_change_native_ptr;

        internal static void on_address_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr url_str, int url_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnAddressChangeEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_url_str = url_str;
            e.m_url_length = url_length;
            self.m_OnAddressChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }

        // on_title_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_title_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr title_str, int title_length);
        private static on_title_change_delegate on_title_change_native;
        private static IntPtr on_title_change_native_ptr;

        internal static void on_title_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr title_str, int title_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnTitleChangeEventArgs();
            e.m_browser = browser;
            e.m_title_str = title_str;
            e.m_title_length = title_length;
            self.m_OnTitleChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_favicon_urlchange
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_favicon_urlchange_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr icon_urls);
        private static on_favicon_urlchange_delegate on_favicon_urlchange_native;
        private static IntPtr on_favicon_urlchange_native_ptr;

        internal static void on_favicon_urlchange(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr icon_urls) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnFaviconUrlchangeEventArgs();
            e.m_browser = browser;
            e.m_icon_urls = icon_urls;
            self.m_OnFaviconUrlchange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_fullscreen_mode_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_fullscreen_mode_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int fullscreen);
        private static on_fullscreen_mode_change_delegate on_fullscreen_mode_change_native;
        private static IntPtr on_fullscreen_mode_change_native_ptr;

        internal static void on_fullscreen_mode_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int fullscreen) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnFullscreenModeChangeEventArgs();
            e.m_browser = browser;
            e.m_fullscreen = fullscreen;
            self.m_OnFullscreenModeChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_tooltip
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_tooltip_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, ref IntPtr text_str, ref int text_length);
        private static on_tooltip_delegate on_tooltip_native;
        private static IntPtr on_tooltip_native_ptr;

        internal static void on_tooltip(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, ref IntPtr text_str, ref int text_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxOnTooltipEventArgs();
            e.m_browser = browser;
            e.m_text_str = text_str;
            e.m_text_length = text_length;
            self.m_OnTooltip?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            if(e.m_text_changed) {
                var text_pinned = new PinnedString(e.m_text_wrapped);
                text_str = text_pinned.Obj.PinnedPtr;
                text_length = text_pinned.Length;
            }
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_status_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_status_message_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr value_str, int value_length);
        private static on_status_message_delegate on_status_message_native;
        private static IntPtr on_status_message_native_ptr;

        internal static void on_status_message(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr value_str, int value_length) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnStatusMessageEventArgs();
            e.m_browser = browser;
            e.m_value_str = value_str;
            e.m_value_length = value_length;
            self.m_OnStatusMessage?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_console_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_console_message_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int level, IntPtr message_str, int message_length, IntPtr source_str, int source_length, int line);
        private static on_console_message_delegate on_console_message_native;
        private static IntPtr on_console_message_native_ptr;

        internal static void on_console_message(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int level, IntPtr message_str, int message_length, IntPtr source_str, int source_length, int line) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxOnConsoleMessageEventArgs();
            e.m_browser = browser;
            e.m_level = level;
            e.m_message_str = message_str;
            e.m_message_length = message_length;
            e.m_source_str = source_str;
            e.m_source_length = source_length;
            e.m_line = line;
            self.m_OnConsoleMessage?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_auto_resize
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_auto_resize_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr new_size);
        private static on_auto_resize_delegate on_auto_resize_native;
        private static IntPtr on_auto_resize_native_ptr;

        internal static void on_auto_resize(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr new_size) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxOnAutoResizeEventArgs();
            e.m_browser = browser;
            e.m_new_size = new_size;
            self.m_OnAutoResize?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_loading_progress_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_loading_progress_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, double progress);
        private static on_loading_progress_change_delegate on_loading_progress_change_native;
        private static IntPtr on_loading_progress_change_native_ptr;

        internal static void on_loading_progress_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, double progress) {
            var self = (CfxDisplayHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnLoadingProgressChangeEventArgs();
            e.m_browser = browser;
            e.m_progress = progress;
            self.m_OnLoadingProgressChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        public CfxDisplayHandler() : base(CfxApi.DisplayHandler.cfx_display_handler_ctor) {}

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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 0, on_address_change_native_ptr);
                    }
                    m_OnAddressChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnAddressChange -= value;
                    if(m_OnAddressChange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 0, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 1, on_title_change_native_ptr);
                    }
                    m_OnTitleChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTitleChange -= value;
                    if(m_OnTitleChange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 1, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 2, on_favicon_urlchange_native_ptr);
                    }
                    m_OnFaviconUrlchange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFaviconUrlchange -= value;
                    if(m_OnFaviconUrlchange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 2, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 3, on_fullscreen_mode_change_native_ptr);
                    }
                    m_OnFullscreenModeChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFullscreenModeChange -= value;
                    if(m_OnFullscreenModeChange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 3, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 4, on_tooltip_native_ptr);
                    }
                    m_OnTooltip += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnTooltip -= value;
                    if(m_OnTooltip == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 4, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 5, on_status_message_native_ptr);
                    }
                    m_OnStatusMessage += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnStatusMessage -= value;
                    if(m_OnStatusMessage == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 5, IntPtr.Zero);
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
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 6, on_console_message_native_ptr);
                    }
                    m_OnConsoleMessage += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnConsoleMessage -= value;
                    if(m_OnConsoleMessage == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnConsoleMessageEventHandler m_OnConsoleMessage;

        /// <summary>
        /// Called when auto-resize is enabled via
        /// CfxBrowserHost.SetAutoResizeEnabled and the contents have auto-
        /// resized. |NewSize| will be the desired size in view coordinates. Return
        /// true (1) if the resize was handled or false (0) for default handling.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnAutoResizeEventHandler OnAutoResize {
            add {
                lock(eventLock) {
                    if(m_OnAutoResize == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 7, on_auto_resize_native_ptr);
                    }
                    m_OnAutoResize += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnAutoResize -= value;
                    if(m_OnAutoResize == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnAutoResizeEventHandler m_OnAutoResize;

        /// <summary>
        /// Called when the overall page loading progress has changed. |Progress|
        /// ranges from 0.0 to 1.0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnLoadingProgressChangeEventHandler OnLoadingProgressChange {
            add {
                lock(eventLock) {
                    if(m_OnLoadingProgressChange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 8, on_loading_progress_change_native_ptr);
                    }
                    m_OnLoadingProgressChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnLoadingProgressChange -= value;
                    if(m_OnLoadingProgressChange == null) {
                        CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnLoadingProgressChangeEventHandler m_OnLoadingProgressChange;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnAddressChange != null) {
                m_OnAddressChange = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnTitleChange != null) {
                m_OnTitleChange = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnFaviconUrlchange != null) {
                m_OnFaviconUrlchange = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnFullscreenModeChange != null) {
                m_OnFullscreenModeChange = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnTooltip != null) {
                m_OnTooltip = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnStatusMessage != null) {
                m_OnStatusMessage = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnConsoleMessage != null) {
                m_OnConsoleMessage = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnAutoResize != null) {
                m_OnAutoResize = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_OnLoadingProgressChange != null) {
                m_OnLoadingProgressChange = null;
                CfxApi.DisplayHandler.cfx_display_handler_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

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

            internal CfxOnAddressChangeEventArgs() {}

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

            internal CfxOnTitleChangeEventArgs() {}

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

            internal CfxOnFaviconUrlchangeEventArgs() {}

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

            internal CfxOnFullscreenModeChangeEventArgs() {}

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

            internal CfxOnTooltipEventArgs() {}

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

            internal CfxOnStatusMessageEventArgs() {}

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
            internal int m_level;
            internal IntPtr m_message_str;
            internal int m_message_length;
            internal string m_message;
            internal IntPtr m_source_str;
            internal int m_source_length;
            internal string m_source;
            internal int m_line;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnConsoleMessageEventArgs() {}

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
            /// Get the Level parameter for the <see cref="CfxDisplayHandler.OnConsoleMessage"/> callback.
            /// </summary>
            public CfxLogSeverity Level {
                get {
                    CheckAccess();
                    return (CfxLogSeverity)m_level;
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
                return String.Format("Browser={{{0}}}, Level={{{1}}}, Message={{{2}}}, Source={{{3}}}, Line={{{4}}}", Browser, Level, Message, Source, Line);
            }
        }

        /// <summary>
        /// Called when auto-resize is enabled via
        /// CfxBrowserHost.SetAutoResizeEnabled and the contents have auto-
        /// resized. |NewSize| will be the desired size in view coordinates. Return
        /// true (1) if the resize was handled or false (0) for default handling.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnAutoResizeEventHandler(object sender, CfxOnAutoResizeEventArgs e);

        /// <summary>
        /// Called when auto-resize is enabled via
        /// CfxBrowserHost.SetAutoResizeEnabled and the contents have auto-
        /// resized. |NewSize| will be the desired size in view coordinates. Return
        /// true (1) if the resize was handled or false (0) for default handling.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnAutoResizeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_new_size;
            internal CfxSize m_new_size_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnAutoResizeEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnAutoResize"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the NewSize parameter for the <see cref="CfxDisplayHandler.OnAutoResize"/> callback.
            /// </summary>
            public CfxSize NewSize {
                get {
                    CheckAccess();
                    if(m_new_size_wrapped == null) m_new_size_wrapped = CfxSize.Wrap(m_new_size);
                    return m_new_size_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxDisplayHandler.OnAutoResize"/> callback.
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
                return String.Format("Browser={{{0}}}, NewSize={{{1}}}", Browser, NewSize);
            }
        }

        /// <summary>
        /// Called when the overall page loading progress has changed. |Progress|
        /// ranges from 0.0 to 1.0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnLoadingProgressChangeEventHandler(object sender, CfxOnLoadingProgressChangeEventArgs e);

        /// <summary>
        /// Called when the overall page loading progress has changed. |Progress|
        /// ranges from 0.0 to 1.0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_display_handler_capi.h">cef/include/capi/cef_display_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnLoadingProgressChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal double m_progress;

            internal CfxOnLoadingProgressChangeEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDisplayHandler.OnLoadingProgressChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Progress parameter for the <see cref="CfxDisplayHandler.OnLoadingProgressChange"/> callback.
            /// </summary>
            public double Progress {
                get {
                    CheckAccess();
                    return m_progress;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Progress={{{1}}}", Browser, Progress);
            }
        }

    }
}
