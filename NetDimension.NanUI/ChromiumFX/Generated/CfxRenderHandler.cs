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
	/// Implement this structure to handle events when window rendering is disabled.
	/// The functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_handler_capi.h">cef/include/capi/cef_render_handler_capi.h</see>.
	/// </remarks>
	public class CfxRenderHandler : CfxBase {

        static CfxRenderHandler () {
            CfxApiLoader.LoadCfxRenderHandlerApi();
        }

        internal static CfxRenderHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_render_handler_get_gc_handle(nativePtr);
            return (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // get_root_screen_rect
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_get_root_screen_rect_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr rect);
        private static cfx_render_handler_get_root_screen_rect_delegate cfx_render_handler_get_root_screen_rect;
        private static IntPtr cfx_render_handler_get_root_screen_rect_ptr;

        internal static void get_root_screen_rect(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxGetRootScreenRectEventArgs(browser, rect);
            var eventHandler = self.m_GetRootScreenRect;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_view_rect
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_get_view_rect_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr rect);
        private static cfx_render_handler_get_view_rect_delegate cfx_render_handler_get_view_rect;
        private static IntPtr cfx_render_handler_get_view_rect_ptr;

        internal static void get_view_rect(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxGetViewRectEventArgs(browser, rect);
            var eventHandler = self.m_GetViewRect;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_screen_point
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_get_screen_point_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int viewX, int viewY, out int screenX, out int screenY);
        private static cfx_render_handler_get_screen_point_delegate cfx_render_handler_get_screen_point;
        private static IntPtr cfx_render_handler_get_screen_point_ptr;

        internal static void get_screen_point(IntPtr gcHandlePtr, out int __retval, IntPtr browser, int viewX, int viewY, out int screenX, out int screenY) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                screenX = default(int);
                screenY = default(int);
                return;
            }
            var e = new CfxGetScreenPointEventArgs(browser, viewX, viewY);
            var eventHandler = self.m_GetScreenPoint;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            screenX = e.m_screenX;
            screenY = e.m_screenY;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_screen_info
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_get_screen_info_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr screen_info);
        private static cfx_render_handler_get_screen_info_delegate cfx_render_handler_get_screen_info;
        private static IntPtr cfx_render_handler_get_screen_info_ptr;

        internal static void get_screen_info(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr screen_info) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxGetScreenInfoEventArgs(browser, screen_info);
            var eventHandler = self.m_GetScreenInfo;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_popup_show
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_on_popup_show_delegate(IntPtr gcHandlePtr, IntPtr browser, int show);
        private static cfx_render_handler_on_popup_show_delegate cfx_render_handler_on_popup_show;
        private static IntPtr cfx_render_handler_on_popup_show_ptr;

        internal static void on_popup_show(IntPtr gcHandlePtr, IntPtr browser, int show) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnPopupShowEventArgs(browser, show);
            var eventHandler = self.m_OnPopupShow;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_popup_size
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_on_popup_size_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr rect);
        private static cfx_render_handler_on_popup_size_delegate cfx_render_handler_on_popup_size;
        private static IntPtr cfx_render_handler_on_popup_size_ptr;

        internal static void on_popup_size(IntPtr gcHandlePtr, IntPtr browser, IntPtr rect) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnPopupSizeEventArgs(browser, rect);
            var eventHandler = self.m_OnPopupSize;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_paint
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_on_paint_delegate(IntPtr gcHandlePtr, IntPtr browser, int type, int dirtyRectsCount, IntPtr dirtyRects, int dirtyRects_structsize, IntPtr buffer, int width, int height);
        private static cfx_render_handler_on_paint_delegate cfx_render_handler_on_paint;
        private static IntPtr cfx_render_handler_on_paint_ptr;

        internal static void on_paint(IntPtr gcHandlePtr, IntPtr browser, int type, int dirtyRectsCount, IntPtr dirtyRects, int dirtyRects_structsize, IntPtr buffer, int width, int height) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnPaintEventArgs(browser, type, dirtyRects, dirtyRectsCount, dirtyRects_structsize, buffer, width, height);
            var eventHandler = self.m_OnPaint;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_dirtyRects_managed != null) {
                for(int i = 0; i < e.m_dirtyRects_managed.Length; ++i) {
                    e.m_dirtyRects_managed[i].Dispose();
                }
            }
        }

        // on_cursor_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_on_cursor_change_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr cursor, int type, IntPtr custom_cursor_info);
        private static cfx_render_handler_on_cursor_change_delegate cfx_render_handler_on_cursor_change;
        private static IntPtr cfx_render_handler_on_cursor_change_ptr;

        internal static void on_cursor_change(IntPtr gcHandlePtr, IntPtr browser, IntPtr cursor, int type, IntPtr custom_cursor_info) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnCursorChangeEventArgs(browser, cursor, type, custom_cursor_info);
            var eventHandler = self.m_OnCursorChange;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // start_dragging
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_start_dragging_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr drag_data, int allowed_ops, int x, int y);
        private static cfx_render_handler_start_dragging_delegate cfx_render_handler_start_dragging;
        private static IntPtr cfx_render_handler_start_dragging_ptr;

        internal static void start_dragging(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr drag_data, int allowed_ops, int x, int y) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxStartDraggingEventArgs(browser, drag_data, allowed_ops, x, y);
            var eventHandler = self.m_StartDragging;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_drag_data_wrapped == null) CfxApi.cfx_release(e.m_drag_data);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // update_drag_cursor
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_update_drag_cursor_delegate(IntPtr gcHandlePtr, IntPtr browser, int operation);
        private static cfx_render_handler_update_drag_cursor_delegate cfx_render_handler_update_drag_cursor;
        private static IntPtr cfx_render_handler_update_drag_cursor_ptr;

        internal static void update_drag_cursor(IntPtr gcHandlePtr, IntPtr browser, int operation) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxUpdateDragCursorEventArgs(browser, operation);
            var eventHandler = self.m_UpdateDragCursor;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_scroll_offset_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_render_handler_on_scroll_offset_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, double x, double y);
        private static cfx_render_handler_on_scroll_offset_changed_delegate cfx_render_handler_on_scroll_offset_changed;
        private static IntPtr cfx_render_handler_on_scroll_offset_changed_ptr;

        internal static void on_scroll_offset_changed(IntPtr gcHandlePtr, IntPtr browser, double x, double y) {
            var self = (CfxRenderHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnScrollOffsetChangedEventArgs(browser, x, y);
            var eventHandler = self.m_OnScrollOffsetChanged;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        internal CfxRenderHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRenderHandler() : base(CfxApi.cfx_render_handler_ctor) {}

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
                        if(cfx_render_handler_get_root_screen_rect == null) {
                            cfx_render_handler_get_root_screen_rect = get_root_screen_rect;
                            cfx_render_handler_get_root_screen_rect_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_get_root_screen_rect);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 0, cfx_render_handler_get_root_screen_rect_ptr);
                    }
                    m_GetRootScreenRect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetRootScreenRect -= value;
                    if(m_GetRootScreenRect == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_render_handler_get_view_rect == null) {
                            cfx_render_handler_get_view_rect = get_view_rect;
                            cfx_render_handler_get_view_rect_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_get_view_rect);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 1, cfx_render_handler_get_view_rect_ptr);
                    }
                    m_GetViewRect += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetViewRect -= value;
                    if(m_GetViewRect == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
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
                        if(cfx_render_handler_get_screen_point == null) {
                            cfx_render_handler_get_screen_point = get_screen_point;
                            cfx_render_handler_get_screen_point_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_get_screen_point);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 2, cfx_render_handler_get_screen_point_ptr);
                    }
                    m_GetScreenPoint += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetScreenPoint -= value;
                    if(m_GetScreenPoint == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetScreenPointEventHandler m_GetScreenPoint;

        /// <summary>
        /// Called to allow the client to fill in the CfxScreenInfo object with
        /// appropriate values. Return true (1) if the |ScreenInfo| structure has been
        /// modified.
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
                        if(cfx_render_handler_get_screen_info == null) {
                            cfx_render_handler_get_screen_info = get_screen_info;
                            cfx_render_handler_get_screen_info_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_get_screen_info);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 3, cfx_render_handler_get_screen_info_ptr);
                    }
                    m_GetScreenInfo += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetScreenInfo -= value;
                    if(m_GetScreenInfo == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
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
                        if(cfx_render_handler_on_popup_show == null) {
                            cfx_render_handler_on_popup_show = on_popup_show;
                            cfx_render_handler_on_popup_show_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_on_popup_show);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 4, cfx_render_handler_on_popup_show_ptr);
                    }
                    m_OnPopupShow += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPopupShow -= value;
                    if(m_OnPopupShow == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
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
                        if(cfx_render_handler_on_popup_size == null) {
                            cfx_render_handler_on_popup_size = on_popup_size;
                            cfx_render_handler_on_popup_size_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_on_popup_size);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 5, cfx_render_handler_on_popup_size_ptr);
                    }
                    m_OnPopupSize += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPopupSize -= value;
                    if(m_OnPopupSize == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
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
                        if(cfx_render_handler_on_paint == null) {
                            cfx_render_handler_on_paint = on_paint;
                            cfx_render_handler_on_paint_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_on_paint);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 6, cfx_render_handler_on_paint_ptr);
                    }
                    m_OnPaint += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPaint -= value;
                    if(m_OnPaint == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
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
                        if(cfx_render_handler_on_cursor_change == null) {
                            cfx_render_handler_on_cursor_change = on_cursor_change;
                            cfx_render_handler_on_cursor_change_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_on_cursor_change);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 7, cfx_render_handler_on_cursor_change_ptr);
                    }
                    m_OnCursorChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnCursorChange -= value;
                    if(m_OnCursorChange == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 7, IntPtr.Zero);
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
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
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
                        if(cfx_render_handler_start_dragging == null) {
                            cfx_render_handler_start_dragging = start_dragging;
                            cfx_render_handler_start_dragging_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_start_dragging);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 8, cfx_render_handler_start_dragging_ptr);
                    }
                    m_StartDragging += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_StartDragging -= value;
                    if(m_StartDragging == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 8, IntPtr.Zero);
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
                        if(cfx_render_handler_update_drag_cursor == null) {
                            cfx_render_handler_update_drag_cursor = update_drag_cursor;
                            cfx_render_handler_update_drag_cursor_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_update_drag_cursor);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 9, cfx_render_handler_update_drag_cursor_ptr);
                    }
                    m_UpdateDragCursor += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_UpdateDragCursor -= value;
                    if(m_UpdateDragCursor == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 9, IntPtr.Zero);
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
                        if(cfx_render_handler_on_scroll_offset_changed == null) {
                            cfx_render_handler_on_scroll_offset_changed = on_scroll_offset_changed;
                            cfx_render_handler_on_scroll_offset_changed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_render_handler_on_scroll_offset_changed);
                        }
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 10, cfx_render_handler_on_scroll_offset_changed_ptr);
                    }
                    m_OnScrollOffsetChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnScrollOffsetChanged -= value;
                    if(m_OnScrollOffsetChanged == null) {
                        CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 10, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnScrollOffsetChangedEventHandler m_OnScrollOffsetChanged;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetRootScreenRect != null) {
                m_GetRootScreenRect = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_GetViewRect != null) {
                m_GetViewRect = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetScreenPoint != null) {
                m_GetScreenPoint = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_GetScreenInfo != null) {
                m_GetScreenInfo = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnPopupShow != null) {
                m_OnPopupShow = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnPopupSize != null) {
                m_OnPopupSize = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnPaint != null) {
                m_OnPaint = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnCursorChange != null) {
                m_OnCursorChange = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 7, IntPtr.Zero);
            }
            if(m_StartDragging != null) {
                m_StartDragging = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 8, IntPtr.Zero);
            }
            if(m_UpdateDragCursor != null) {
                m_UpdateDragCursor = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 9, IntPtr.Zero);
            }
            if(m_OnScrollOffsetChanged != null) {
                m_OnScrollOffsetChanged = null;
                CfxApi.cfx_render_handler_set_managed_callback(NativePtr, 10, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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
            int m_dirtyRectsCount;
            internal CfxRect[] m_dirtyRects_managed;
            internal IntPtr m_buffer;
            internal int m_width;
            internal int m_height;

            internal CfxOnPaintEventArgs(IntPtr browser, int type, IntPtr dirtyRects, int dirtyRectsCount, int dirtyRects_structsize, IntPtr buffer, int width, int height) {
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
                        m_dirtyRects_managed = new CfxRect[m_dirtyRectsCount];
                        for(int i = 0; i < m_dirtyRectsCount; ++i) {
                            m_dirtyRects_managed[i] = CfxRect.Wrap(m_dirtyRects + (i * m_dirtyRects_structsize));
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
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
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
        /// Return false (0) to abort the drag operation. Don't call any of
        /// CfxBrowserHost.DragSource*Ended* functions after returning false (0).
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

    }
}
