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
    /// Implement this structure to handle events when window rendering is disabled.
    /// The functions of this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
    /// </remarks>
    public class CfxRenderHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_root_screen_rect_native = get_root_screen_rect;
            get_view_rect_native = get_view_rect;
            get_screen_point_native = get_screen_point;
            get_screen_info_native = get_screen_info;
            on_popup_show_native = on_popup_show;
            on_popup_size_native = on_popup_size;
            on_paint_native = on_paint;
            on_cursor_change_native = on_cursor_change;
            start_dragging_native = start_dragging;
            update_drag_cursor_native = update_drag_cursor;
            on_scroll_offset_changed_native = on_scroll_offset_changed;
            on_ime_composition_range_changed_native = on_ime_composition_range_changed;

            get_root_screen_rect_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_root_screen_rect_native);
            get_view_rect_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_view_rect_native);
            get_screen_point_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_screen_point_native);
            get_screen_info_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_screen_info_native);
            on_popup_show_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_popup_show_native);
            on_popup_size_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_popup_size_native);
            on_paint_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_paint_native);
            on_cursor_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_cursor_change_native);
            start_dragging_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(start_dragging_native);
            update_drag_cursor_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(update_drag_cursor_native);
            on_scroll_offset_changed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_scroll_offset_changed_native);
            on_ime_composition_range_changed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_ime_composition_range_changed_native);
        }

        // get_root_screen_rect
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_root_screen_rect_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr rect);
        private static get_root_screen_rect_delegate get_root_screen_rect_native;
        private static IntPtr get_root_screen_rect_native_ptr;

        internal static void get_root_screen_rect(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxGetRootScreenRectEventArgs(browser, rect);
            self.m_GetRootScreenRect?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_view_rect
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_view_rect_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr rect);
        private static get_view_rect_delegate get_view_rect_native;
        private static IntPtr get_view_rect_native_ptr;

        internal static void get_view_rect(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxGetViewRectEventArgs(browser, rect);
            self.m_GetViewRect?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_screen_point
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_screen_point_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int viewX, int viewY, out int screenX, out int screenY);
        private static get_screen_point_delegate get_screen_point_native;
        private static IntPtr get_screen_point_native_ptr;

        internal static void get_screen_point(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int viewX, int viewY, out int screenX, out int screenY) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                screenX = default(int);
                screenY = default(int);
                return;
            }
            var e = new CfxGetScreenPointEventArgs(browser, viewX, viewY);
            self.m_GetScreenPoint?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            screenX = e.m_screenX;
            screenY = e.m_screenY;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_screen_info
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_screen_info_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr screen_info);
        private static get_screen_info_delegate get_screen_info_native;
        private static IntPtr get_screen_info_native_ptr;

        internal static void get_screen_info(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr screen_info) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                return;
            }
            var e = new CfxGetScreenInfoEventArgs(browser, screen_info);
            self.m_GetScreenInfo?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_popup_show
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_popup_show_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int show);
        private static on_popup_show_delegate on_popup_show_native;
        private static IntPtr on_popup_show_native_ptr;

        internal static void on_popup_show(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int show) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPopupShowEventArgs(browser, show);
            self.m_OnPopupShow?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_popup_size
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_popup_size_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr rect);
        private static on_popup_size_delegate on_popup_size_native;
        private static IntPtr on_popup_size_native_ptr;

        internal static void on_popup_size(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPopupSizeEventArgs(browser, rect);
            self.m_OnPopupSize?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_paint
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_paint_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int type, UIntPtr dirtyRectsCount, IntPtr dirtyRects, int dirtyRects_structsize, IntPtr buffer, int width, int height);
        private static on_paint_delegate on_paint_native;
        private static IntPtr on_paint_native_ptr;

        internal static void on_paint(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int type, UIntPtr dirtyRectsCount, IntPtr dirtyRects, int dirtyRects_structsize, IntPtr buffer, int width, int height) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPaintEventArgs(browser, type, dirtyRects, dirtyRectsCount, dirtyRects_structsize, buffer, width, height);
            self.m_OnPaint?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            if(e.m_dirtyRects_managed != null) {
                for(int i = 0; i < e.m_dirtyRects_managed.Length; ++i) {
                    e.m_dirtyRects_managed[i].Dispose();
                }
            }
        }

        // on_cursor_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_cursor_change_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr cursor, int type, IntPtr custom_cursor_info);
        private static on_cursor_change_delegate on_cursor_change_native;
        private static IntPtr on_cursor_change_native_ptr;

        internal static void on_cursor_change(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr cursor, int type, IntPtr custom_cursor_info) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnCursorChangeEventArgs(browser, cursor, type, custom_cursor_info);
            self.m_OnCursorChange?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // start_dragging
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void start_dragging_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr drag_data, out int drag_data_release, int allowed_ops, int x, int y);
        private static start_dragging_delegate start_dragging_native;
        private static IntPtr start_dragging_native_ptr;

        internal static void start_dragging(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr drag_data, out int drag_data_release, int allowed_ops, int x, int y) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                drag_data_release = 1;
                return;
            }
            var e = new CfxStartDraggingEventArgs(browser, drag_data, allowed_ops, x, y);
            self.m_StartDragging?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            drag_data_release = e.m_drag_data_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // update_drag_cursor
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void update_drag_cursor_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int operation);
        private static update_drag_cursor_delegate update_drag_cursor_native;
        private static IntPtr update_drag_cursor_native_ptr;

        internal static void update_drag_cursor(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int operation) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxUpdateDragCursorEventArgs(browser, operation);
            self.m_UpdateDragCursor?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_scroll_offset_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_scroll_offset_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, double x, double y);
        private static on_scroll_offset_changed_delegate on_scroll_offset_changed_native;
        private static IntPtr on_scroll_offset_changed_native_ptr;

        internal static void on_scroll_offset_changed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, double x, double y) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnScrollOffsetChangedEventArgs(browser, x, y);
            self.m_OnScrollOffsetChanged?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_ime_composition_range_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_ime_composition_range_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr selected_range, UIntPtr character_boundsCount, IntPtr character_bounds, int character_bounds_structsize);
        private static on_ime_composition_range_changed_delegate on_ime_composition_range_changed_native;
        private static IntPtr on_ime_composition_range_changed_native_ptr;

        internal static void on_ime_composition_range_changed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr selected_range, UIntPtr character_boundsCount, IntPtr character_bounds, int character_bounds_structsize) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnImeCompositionRangeChangedEventArgs(browser, selected_range, character_bounds, character_boundsCount, character_bounds_structsize);
            self.m_OnImeCompositionRangeChanged?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            if(e.m_character_bounds_managed != null) {
                for(int i = 0; i < e.m_character_bounds_managed.Length; ++i) {
                    e.m_character_bounds_managed[i].Dispose();
                }
            }
        }

        public CfxRenderHandler() : base(CfxApi.RenderHandler.cfx_render_handler_ctor) {}

        /// <summary>
        /// Called to retrieve the root window rectangle in screen coordinates. Return
        /// true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetRootScreenRectEventHandler GetRootScreenRect {
            add {
                lock(eventLock) {
                    if(m_GetRootScreenRect == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 0, get_root_screen_rect_native_ptr);
                    }
                    m_GetRootScreenRect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRootScreenRect -= value;
                    if(m_GetRootScreenRect == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetRootScreenRectEventHandler m_GetRootScreenRect;

        /// <summary>
        /// Called to retrieve the view rectangle which is relative to screen
        /// coordinates. Return true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetViewRectEventHandler GetViewRect {
            add {
                lock(eventLock) {
                    if(m_GetViewRect == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 1, get_view_rect_native_ptr);
                    }
                    m_GetViewRect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetViewRect -= value;
                    if(m_GetViewRect == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetViewRectEventHandler m_GetViewRect;

        /// <summary>
        /// Called to retrieve the translation from view coordinates to actual screen
        /// coordinates. Return true (1) if the screen coordinates were provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetScreenPointEventHandler GetScreenPoint {
            add {
                lock(eventLock) {
                    if(m_GetScreenPoint == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 2, get_screen_point_native_ptr);
                    }
                    m_GetScreenPoint += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetScreenPoint -= value;
                    if(m_GetScreenPoint == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetScreenPointEventHandler m_GetScreenPoint;

        /// <summary>
        /// Called to allow the client to fill in the CfxScreenInfo object with
        /// appropriate values. Return true (1) if the |ScreenInfo| structure has been
        /// modified.
        /// 
        /// If the screen info rectangle is left NULL the rectangle from GetViewRect
        /// will be used. If the rectangle is still NULL or invalid popups may not be
        /// drawn correctly.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetScreenInfoEventHandler GetScreenInfo {
            add {
                lock(eventLock) {
                    if(m_GetScreenInfo == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 3, get_screen_info_native_ptr);
                    }
                    m_GetScreenInfo += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetScreenInfo -= value;
                    if(m_GetScreenInfo == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetScreenInfoEventHandler m_GetScreenInfo;

        /// <summary>
        /// Called when the browser wants to show or hide the popup widget. The popup
        /// should be shown if |Show| is true (1) and hidden if |Show| is false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPopupShowEventHandler OnPopupShow {
            add {
                lock(eventLock) {
                    if(m_OnPopupShow == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 4, on_popup_show_native_ptr);
                    }
                    m_OnPopupShow += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPopupShow -= value;
                    if(m_OnPopupShow == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPopupShowEventHandler m_OnPopupShow;

        /// <summary>
        /// Called when the browser wants to move or resize the popup widget. |Rect|
        /// contains the new location and size in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPopupSizeEventHandler OnPopupSize {
            add {
                lock(eventLock) {
                    if(m_OnPopupSize == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 5, on_popup_size_native_ptr);
                    }
                    m_OnPopupSize += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPopupSize -= value;
                    if(m_OnPopupSize == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPopupSizeEventHandler m_OnPopupSize;

        /// <summary>
        /// Called when an element should be painted. Pixel values passed to this
        /// function are scaled relative to view coordinates based on the value of
        /// CfxScreenInfo.DeviceScaleFactor returned from GetScreenInfo. |Type|
        /// indicates whether the element is the view or the popup widget. |Buffer|
        /// contains the pixel data for the whole image. |DirtyRects| contains the set
        /// of rectangles in pixel coordinates that need to be repainted. |Buffer| will
        /// be |Width|*|Height|*4 bytes in size and represents a BGRA image with an
        /// upper-left origin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPaintEventHandler OnPaint {
            add {
                lock(eventLock) {
                    if(m_OnPaint == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 6, on_paint_native_ptr);
                    }
                    m_OnPaint += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPaint -= value;
                    if(m_OnPaint == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPaintEventHandler m_OnPaint;

        /// <summary>
        /// Called when the browser's cursor has changed. If |Type| is CT_CUSTOM then
        /// |CustomCursorInfo| will be populated with the custom cursor information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnCursorChangeEventHandler OnCursorChange {
            add {
                lock(eventLock) {
                    if(m_OnCursorChange == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 7, on_cursor_change_native_ptr);
                    }
                    m_OnCursorChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCursorChange -= value;
                    if(m_OnCursorChange == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnCursorChangeEventHandler m_OnCursorChange;

        /// <summary>
        /// Called when the user starts dragging content in the web view. Contextual
        /// information about the dragged content is supplied by |DragData|. (|X|,
        /// |Y|) is the drag start location in screen coordinates. OS APIs that run a
        /// system message loop may be used within the StartDragging call.
        /// 
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
        /// 
        /// Return true (1) to handle the drag operation. Call
        /// CfxBrowserHost.DragSourceEndedAt and DragSourceSystemDragEnded either
        /// synchronously or asynchronously to inform the web view that the drag
        /// operation has ended.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxStartDraggingEventHandler StartDragging {
            add {
                lock(eventLock) {
                    if(m_StartDragging == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 8, start_dragging_native_ptr);
                    }
                    m_StartDragging += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_StartDragging -= value;
                    if(m_StartDragging == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 8, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxStartDraggingEventHandler m_StartDragging;

        /// <summary>
        /// Called when the web view wants to update the mouse cursor during a drag &amp;
        /// drop operation. |Operation| describes the allowed operation (none, move,
        /// copy, link).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxUpdateDragCursorEventHandler UpdateDragCursor {
            add {
                lock(eventLock) {
                    if(m_UpdateDragCursor == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 9, update_drag_cursor_native_ptr);
                    }
                    m_UpdateDragCursor += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_UpdateDragCursor -= value;
                    if(m_UpdateDragCursor == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 9, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxUpdateDragCursorEventHandler m_UpdateDragCursor;

        /// <summary>
        /// Called when the scroll offset has changed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnScrollOffsetChangedEventHandler OnScrollOffsetChanged {
            add {
                lock(eventLock) {
                    if(m_OnScrollOffsetChanged == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 10, on_scroll_offset_changed_native_ptr);
                    }
                    m_OnScrollOffsetChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnScrollOffsetChanged -= value;
                    if(m_OnScrollOffsetChanged == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnScrollOffsetChangedEventHandler m_OnScrollOffsetChanged;

        /// <summary>
        /// Called when the IME composition range has changed. |SelectedRange| is the
        /// range of characters that have been selected. |CharacterBounds| is the
        /// bounds of each character in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnImeCompositionRangeChangedEventHandler OnImeCompositionRangeChanged {
            add {
                lock(eventLock) {
                    if(m_OnImeCompositionRangeChanged == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 11, on_ime_composition_range_changed_native_ptr);
                    }
                    m_OnImeCompositionRangeChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnImeCompositionRangeChanged -= value;
                    if(m_OnImeCompositionRangeChanged == null) {
                        CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 11, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnImeCompositionRangeChangedEventHandler m_OnImeCompositionRangeChanged;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetRootScreenRect != null) {
                m_GetRootScreenRect = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetViewRect != null) {
                m_GetViewRect = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetScreenPoint != null) {
                m_GetScreenPoint = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetScreenInfo != null) {
                m_GetScreenInfo = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnPopupShow != null) {
                m_OnPopupShow = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnPopupSize != null) {
                m_OnPopupSize = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnPaint != null) {
                m_OnPaint = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnCursorChange != null) {
                m_OnCursorChange = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_StartDragging != null) {
                m_StartDragging = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_UpdateDragCursor != null) {
                m_UpdateDragCursor = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_OnScrollOffsetChanged != null) {
                m_OnScrollOffsetChanged = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 10, IntPtr.Zero);
            }
            if(m_OnImeCompositionRangeChanged != null) {
                m_OnImeCompositionRangeChanged = null;
                CfxApi.RenderHandler.cfx_render_handler_set_callback(NativePtr, 11, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called to retrieve the root window rectangle in screen coordinates. Return
        /// true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetRootScreenRectEventHandler(object sender, CfxGetRootScreenRectEventArgs e);

        /// <summary>
        /// Called to retrieve the root window rectangle in screen coordinates. Return
        /// true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetRootScreenRectEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_rect;
            internal CfxRect m_rect_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetRootScreenRectEventArgs(IntPtr browser, IntPtr rect) {
                m_browser = browser;
                m_rect = rect;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.GetRootScreenRect"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Rect parameter for the <see cref="CfxRenderHandler.GetRootScreenRect"/> callback.
            /// </summary>
            public CfxRect Rect {
                get {
                    CheckAccess();
                    if(m_rect_wrapped == null) m_rect_wrapped = CfxRect.Wrap(m_rect);
                    return m_rect_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderHandler.GetRootScreenRect"/> callback.
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
                return String.Format("Browser={{{0}}}, Rect={{{1}}}", Browser, Rect);
            }
        }

        /// <summary>
        /// Called to retrieve the view rectangle which is relative to screen
        /// coordinates. Return true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetViewRectEventHandler(object sender, CfxGetViewRectEventArgs e);

        /// <summary>
        /// Called to retrieve the view rectangle which is relative to screen
        /// coordinates. Return true (1) if the rectangle was provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetViewRectEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_rect;
            internal CfxRect m_rect_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetViewRectEventArgs(IntPtr browser, IntPtr rect) {
                m_browser = browser;
                m_rect = rect;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.GetViewRect"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Rect parameter for the <see cref="CfxRenderHandler.GetViewRect"/> callback.
            /// </summary>
            public CfxRect Rect {
                get {
                    CheckAccess();
                    if(m_rect_wrapped == null) m_rect_wrapped = CfxRect.Wrap(m_rect);
                    return m_rect_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderHandler.GetViewRect"/> callback.
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
                return String.Format("Browser={{{0}}}, Rect={{{1}}}", Browser, Rect);
            }
        }

        /// <summary>
        /// Called to retrieve the translation from view coordinates to actual screen
        /// coordinates. Return true (1) if the screen coordinates were provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetScreenPointEventHandler(object sender, CfxGetScreenPointEventArgs e);

        /// <summary>
        /// Called to retrieve the translation from view coordinates to actual screen
        /// coordinates. Return true (1) if the screen coordinates were provided.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetScreenPointEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_viewX;
            internal int m_viewY;
            internal int m_screenX;
            internal int m_screenY;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetScreenPointEventArgs(IntPtr browser, int viewX, int viewY) {
                m_browser = browser;
                m_viewX = viewX;
                m_viewY = viewY;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the ViewX parameter for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
            /// </summary>
            public int ViewX {
                get {
                    CheckAccess();
                    return m_viewX;
                }
            }
            /// <summary>
            /// Get the ViewY parameter for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
            /// </summary>
            public int ViewY {
                get {
                    CheckAccess();
                    return m_viewY;
                }
            }
            /// <summary>
            /// Set the ScreenX out parameter for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
            /// </summary>
            public int ScreenX {
                set {
                    CheckAccess();
                    m_screenX = value;
                }
            }
            /// <summary>
            /// Set the ScreenY out parameter for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
            /// </summary>
            public int ScreenY {
                set {
                    CheckAccess();
                    m_screenY = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderHandler.GetScreenPoint"/> callback.
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
                return String.Format("Browser={{{0}}}, ViewX={{{1}}}, ViewY={{{2}}}", Browser, ViewX, ViewY);
            }
        }

        /// <summary>
        /// Called to allow the client to fill in the CfxScreenInfo object with
        /// appropriate values. Return true (1) if the |ScreenInfo| structure has been
        /// modified.
        /// 
        /// If the screen info rectangle is left NULL the rectangle from GetViewRect
        /// will be used. If the rectangle is still NULL or invalid popups may not be
        /// drawn correctly.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetScreenInfoEventHandler(object sender, CfxGetScreenInfoEventArgs e);

        /// <summary>
        /// Called to allow the client to fill in the CfxScreenInfo object with
        /// appropriate values. Return true (1) if the |ScreenInfo| structure has been
        /// modified.
        /// 
        /// If the screen info rectangle is left NULL the rectangle from GetViewRect
        /// will be used. If the rectangle is still NULL or invalid popups may not be
        /// drawn correctly.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetScreenInfoEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_screen_info;
            internal CfxScreenInfo m_screen_info_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetScreenInfoEventArgs(IntPtr browser, IntPtr screen_info) {
                m_browser = browser;
                m_screen_info = screen_info;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.GetScreenInfo"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the ScreenInfo parameter for the <see cref="CfxRenderHandler.GetScreenInfo"/> callback.
            /// </summary>
            public CfxScreenInfo ScreenInfo {
                get {
                    CheckAccess();
                    if(m_screen_info_wrapped == null) m_screen_info_wrapped = CfxScreenInfo.Wrap(m_screen_info);
                    return m_screen_info_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderHandler.GetScreenInfo"/> callback.
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
                return String.Format("Browser={{{0}}}, ScreenInfo={{{1}}}", Browser, ScreenInfo);
            }
        }

        /// <summary>
        /// Called when the browser wants to show or hide the popup widget. The popup
        /// should be shown if |Show| is true (1) and hidden if |Show| is false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPopupShowEventHandler(object sender, CfxOnPopupShowEventArgs e);

        /// <summary>
        /// Called when the browser wants to show or hide the popup widget. The popup
        /// should be shown if |Show| is true (1) and hidden if |Show| is false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPopupShowEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_show;

            internal CfxOnPopupShowEventArgs(IntPtr browser, int show) {
                m_browser = browser;
                m_show = show;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnPopupShow"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Show parameter for the <see cref="CfxRenderHandler.OnPopupShow"/> callback.
            /// </summary>
            public bool Show {
                get {
                    CheckAccess();
                    return 0 != m_show;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Show={{{1}}}", Browser, Show);
            }
        }

        /// <summary>
        /// Called when the browser wants to move or resize the popup widget. |Rect|
        /// contains the new location and size in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPopupSizeEventHandler(object sender, CfxOnPopupSizeEventArgs e);

        /// <summary>
        /// Called when the browser wants to move or resize the popup widget. |Rect|
        /// contains the new location and size in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPopupSizeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_rect;
            internal CfxRect m_rect_wrapped;

            internal CfxOnPopupSizeEventArgs(IntPtr browser, IntPtr rect) {
                m_browser = browser;
                m_rect = rect;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnPopupSize"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Rect parameter for the <see cref="CfxRenderHandler.OnPopupSize"/> callback.
            /// </summary>
            public CfxRect Rect {
                get {
                    CheckAccess();
                    if(m_rect_wrapped == null) m_rect_wrapped = CfxRect.Wrap(m_rect);
                    return m_rect_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Rect={{{1}}}", Browser, Rect);
            }
        }

        /// <summary>
        /// Called when an element should be painted. Pixel values passed to this
        /// function are scaled relative to view coordinates based on the value of
        /// CfxScreenInfo.DeviceScaleFactor returned from GetScreenInfo. |Type|
        /// indicates whether the element is the view or the popup widget. |Buffer|
        /// contains the pixel data for the whole image. |DirtyRects| contains the set
        /// of rectangles in pixel coordinates that need to be repainted. |Buffer| will
        /// be |Width|*|Height|*4 bytes in size and represents a BGRA image with an
        /// upper-left origin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPaintEventHandler(object sender, CfxOnPaintEventArgs e);

        /// <summary>
        /// Called when an element should be painted. Pixel values passed to this
        /// function are scaled relative to view coordinates based on the value of
        /// CfxScreenInfo.DeviceScaleFactor returned from GetScreenInfo. |Type|
        /// indicates whether the element is the view or the popup widget. |Buffer|
        /// contains the pixel data for the whole image. |DirtyRects| contains the set
        /// of rectangles in pixel coordinates that need to be repainted. |Buffer| will
        /// be |Width|*|Height|*4 bytes in size and represents a BGRA image with an
        /// upper-left origin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPaintEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_type;
            IntPtr m_dirtyRects;
            int m_dirtyRects_structsize;
            UIntPtr m_dirtyRectsCount;
            internal CfxRect[] m_dirtyRects_managed;
            internal IntPtr m_buffer;
            internal int m_width;
            internal int m_height;

            internal CfxOnPaintEventArgs(IntPtr browser, int type, IntPtr dirtyRects, UIntPtr dirtyRectsCount, int dirtyRects_structsize, IntPtr buffer, int width, int height) {
                m_browser = browser;
                m_type = type;
                m_dirtyRects = dirtyRects;
                m_dirtyRects_structsize = dirtyRects_structsize;
                m_dirtyRectsCount = dirtyRectsCount;
                m_buffer = buffer;
                m_width = width;
                m_height = height;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Type parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// </summary>
            public CfxPaintElementType Type {
                get {
                    CheckAccess();
                    return (CfxPaintElementType)m_type;
                }
            }
            /// <summary>
            /// Get the DirtyRects parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// Do not keep a reference to the elements of this array outside of this function.
            /// </summary>
            public CfxRect[] DirtyRects {
                get {
                    CheckAccess();
                    if(m_dirtyRects_managed == null) {
                        m_dirtyRects_managed = new CfxRect[(ulong)m_dirtyRectsCount];
                        var currentPtr = m_dirtyRects;
                        for(ulong i = 0; i < (ulong)m_dirtyRectsCount; ++i) {
                            m_dirtyRects_managed[i] = CfxRect.Wrap(currentPtr);
                            currentPtr += m_dirtyRects_structsize;
                        }
                    }
                    return m_dirtyRects_managed;
                }
            }
            /// <summary>
            /// Get the Buffer parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// </summary>
            public IntPtr Buffer {
                get {
                    CheckAccess();
                    return m_buffer;
                }
            }
            /// <summary>
            /// Get the Width parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// </summary>
            public int Width {
                get {
                    CheckAccess();
                    return m_width;
                }
            }
            /// <summary>
            /// Get the Height parameter for the <see cref="CfxRenderHandler.OnPaint"/> callback.
            /// </summary>
            public int Height {
                get {
                    CheckAccess();
                    return m_height;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Type={{{1}}}, DirtyRects={{{2}}}, Buffer={{{3}}}, Width={{{4}}}, Height={{{5}}}", Browser, Type, DirtyRects, Buffer, Width, Height);
            }
        }

        /// <summary>
        /// Called when the browser's cursor has changed. If |Type| is CT_CUSTOM then
        /// |CustomCursorInfo| will be populated with the custom cursor information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnCursorChangeEventHandler(object sender, CfxOnCursorChangeEventArgs e);

        /// <summary>
        /// Called when the browser's cursor has changed. If |Type| is CT_CUSTOM then
        /// |CustomCursorInfo| will be populated with the custom cursor information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnCursorChangeEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_cursor;
            internal int m_type;
            internal IntPtr m_custom_cursor_info;
            internal CfxCursorInfo m_custom_cursor_info_wrapped;

            internal CfxOnCursorChangeEventArgs(IntPtr browser, IntPtr cursor, int type, IntPtr custom_cursor_info) {
                m_browser = browser;
                m_cursor = cursor;
                m_type = type;
                m_custom_cursor_info = custom_cursor_info;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnCursorChange"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Cursor parameter for the <see cref="CfxRenderHandler.OnCursorChange"/> callback.
            /// </summary>
            public IntPtr Cursor {
                get {
                    CheckAccess();
                    return m_cursor;
                }
            }
            /// <summary>
            /// Get the Type parameter for the <see cref="CfxRenderHandler.OnCursorChange"/> callback.
            /// </summary>
            public CfxCursorType Type {
                get {
                    CheckAccess();
                    return (CfxCursorType)m_type;
                }
            }
            /// <summary>
            /// Get the CustomCursorInfo parameter for the <see cref="CfxRenderHandler.OnCursorChange"/> callback.
            /// </summary>
            public CfxCursorInfo CustomCursorInfo {
                get {
                    CheckAccess();
                    if(m_custom_cursor_info_wrapped == null) m_custom_cursor_info_wrapped = CfxCursorInfo.Wrap(m_custom_cursor_info);
                    return m_custom_cursor_info_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Cursor={{{1}}}, Type={{{2}}}, CustomCursorInfo={{{3}}}", Browser, Cursor, Type, CustomCursorInfo);
            }
        }

        /// <summary>
        /// Called when the user starts dragging content in the web view. Contextual
        /// information about the dragged content is supplied by |DragData|. (|X|,
        /// |Y|) is the drag start location in screen coordinates. OS APIs that run a
        /// system message loop may be used within the StartDragging call.
        /// 
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
        /// 
        /// Return true (1) to handle the drag operation. Call
        /// CfxBrowserHost.DragSourceEndedAt and DragSourceSystemDragEnded either
        /// synchronously or asynchronously to inform the web view that the drag
        /// operation has ended.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxStartDraggingEventHandler(object sender, CfxStartDraggingEventArgs e);

        /// <summary>
        /// Called when the user starts dragging content in the web view. Contextual
        /// information about the dragged content is supplied by |DragData|. (|X|,
        /// |Y|) is the drag start location in screen coordinates. OS APIs that run a
        /// system message loop may be used within the StartDragging call.
        /// 
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
        /// 
        /// Return true (1) to handle the drag operation. Call
        /// CfxBrowserHost.DragSourceEndedAt and DragSourceSystemDragEnded either
        /// synchronously or asynchronously to inform the web view that the drag
        /// operation has ended.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxStartDraggingEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_drag_data;
            internal CfxDragData m_drag_data_wrapped;
            internal int m_allowed_ops;
            internal int m_x;
            internal int m_y;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxStartDraggingEventArgs(IntPtr browser, IntPtr drag_data, int allowed_ops, int x, int y) {
                m_browser = browser;
                m_drag_data = drag_data;
                m_allowed_ops = allowed_ops;
                m_x = x;
                m_y = y;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.StartDragging"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the DragData parameter for the <see cref="CfxRenderHandler.StartDragging"/> callback.
            /// </summary>
            public CfxDragData DragData {
                get {
                    CheckAccess();
                    if(m_drag_data_wrapped == null) m_drag_data_wrapped = CfxDragData.Wrap(m_drag_data);
                    return m_drag_data_wrapped;
                }
            }
            /// <summary>
            /// Get the AllowedOps parameter for the <see cref="CfxRenderHandler.StartDragging"/> callback.
            /// </summary>
            public CfxDragOperationsMask AllowedOps {
                get {
                    CheckAccess();
                    return (CfxDragOperationsMask)m_allowed_ops;
                }
            }
            /// <summary>
            /// Get the X parameter for the <see cref="CfxRenderHandler.StartDragging"/> callback.
            /// </summary>
            public int X {
                get {
                    CheckAccess();
                    return m_x;
                }
            }
            /// <summary>
            /// Get the Y parameter for the <see cref="CfxRenderHandler.StartDragging"/> callback.
            /// </summary>
            public int Y {
                get {
                    CheckAccess();
                    return m_y;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRenderHandler.StartDragging"/> callback.
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
                return String.Format("Browser={{{0}}}, DragData={{{1}}}, AllowedOps={{{2}}}, X={{{3}}}, Y={{{4}}}", Browser, DragData, AllowedOps, X, Y);
            }
        }

        /// <summary>
        /// Called when the web view wants to update the mouse cursor during a drag &amp;
        /// drop operation. |Operation| describes the allowed operation (none, move,
        /// copy, link).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxUpdateDragCursorEventHandler(object sender, CfxUpdateDragCursorEventArgs e);

        /// <summary>
        /// Called when the web view wants to update the mouse cursor during a drag &amp;
        /// drop operation. |Operation| describes the allowed operation (none, move,
        /// copy, link).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxUpdateDragCursorEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_operation;

            internal CfxUpdateDragCursorEventArgs(IntPtr browser, int operation) {
                m_browser = browser;
                m_operation = operation;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.UpdateDragCursor"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Operation parameter for the <see cref="CfxRenderHandler.UpdateDragCursor"/> callback.
            /// </summary>
            public CfxDragOperationsMask Operation {
                get {
                    CheckAccess();
                    return (CfxDragOperationsMask)m_operation;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Operation={{{1}}}", Browser, Operation);
            }
        }

        /// <summary>
        /// Called when the scroll offset has changed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnScrollOffsetChangedEventHandler(object sender, CfxOnScrollOffsetChangedEventArgs e);

        /// <summary>
        /// Called when the scroll offset has changed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnScrollOffsetChangedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal double m_x;
            internal double m_y;

            internal CfxOnScrollOffsetChangedEventArgs(IntPtr browser, double x, double y) {
                m_browser = browser;
                m_x = x;
                m_y = y;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnScrollOffsetChanged"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the X parameter for the <see cref="CfxRenderHandler.OnScrollOffsetChanged"/> callback.
            /// </summary>
            public double X {
                get {
                    CheckAccess();
                    return m_x;
                }
            }
            /// <summary>
            /// Get the Y parameter for the <see cref="CfxRenderHandler.OnScrollOffsetChanged"/> callback.
            /// </summary>
            public double Y {
                get {
                    CheckAccess();
                    return m_y;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, X={{{1}}}, Y={{{2}}}", Browser, X, Y);
            }
        }

        /// <summary>
        /// Called when the IME composition range has changed. |SelectedRange| is the
        /// range of characters that have been selected. |CharacterBounds| is the
        /// bounds of each character in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnImeCompositionRangeChangedEventHandler(object sender, CfxOnImeCompositionRangeChangedEventArgs e);

        /// <summary>
        /// Called when the IME composition range has changed. |SelectedRange| is the
        /// range of characters that have been selected. |CharacterBounds| is the
        /// bounds of each character in view coordinates.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnImeCompositionRangeChangedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_selected_range;
            internal CfxRange m_selected_range_wrapped;
            IntPtr m_character_bounds;
            int m_character_bounds_structsize;
            UIntPtr m_character_boundsCount;
            internal CfxRect[] m_character_bounds_managed;

            internal CfxOnImeCompositionRangeChangedEventArgs(IntPtr browser, IntPtr selected_range, IntPtr character_bounds, UIntPtr character_boundsCount, int character_bounds_structsize) {
                m_browser = browser;
                m_selected_range = selected_range;
                m_character_bounds = character_bounds;
                m_character_bounds_structsize = character_bounds_structsize;
                m_character_boundsCount = character_boundsCount;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRenderHandler.OnImeCompositionRangeChanged"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the SelectedRange parameter for the <see cref="CfxRenderHandler.OnImeCompositionRangeChanged"/> callback.
            /// </summary>
            public CfxRange SelectedRange {
                get {
                    CheckAccess();
                    if(m_selected_range_wrapped == null) m_selected_range_wrapped = CfxRange.Wrap(m_selected_range);
                    return m_selected_range_wrapped;
                }
            }
            /// <summary>
            /// Get the CharacterBounds parameter for the <see cref="CfxRenderHandler.OnImeCompositionRangeChanged"/> callback.
            /// Do not keep a reference to the elements of this array outside of this function.
            /// </summary>
            public CfxRect[] CharacterBounds {
                get {
                    CheckAccess();
                    if(m_character_bounds_managed == null) {
                        m_character_bounds_managed = new CfxRect[(ulong)m_character_boundsCount];
                        var currentPtr = m_character_bounds;
                        for(ulong i = 0; i < (ulong)m_character_boundsCount; ++i) {
                            m_character_bounds_managed[i] = CfxRect.Wrap(currentPtr);
                            currentPtr += m_character_bounds_structsize;
                        }
                    }
                    return m_character_bounds_managed;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, SelectedRange={{{1}}}, CharacterBounds={{{2}}}", Browser, SelectedRange, CharacterBounds);
            }
        }

    }
}
