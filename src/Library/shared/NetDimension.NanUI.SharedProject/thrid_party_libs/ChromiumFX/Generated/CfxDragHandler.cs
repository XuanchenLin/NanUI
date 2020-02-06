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
    /// Implement this structure to handle events related to dragging. The functions
    /// of this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
    /// </remarks>
    public class CfxDragHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_drag_enter_native = on_drag_enter;
            on_draggable_regions_changed_native = on_draggable_regions_changed;

            on_drag_enter_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_drag_enter_native);
            on_draggable_regions_changed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_draggable_regions_changed_native);
        }

        // on_drag_enter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_drag_enter_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr dragData, out int dragData_release, int mask);
        private static on_drag_enter_delegate on_drag_enter_native;
        private static IntPtr on_drag_enter_native_ptr;

        internal static void on_drag_enter(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr dragData, out int dragData_release, int mask) {
            var self = (CfxDragHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                dragData_release = 1;
                return;
            }
            var e = new CfxOnDragEnterEventArgs();
            e.m_browser = browser;
            e.m_dragData = dragData;
            e.m_mask = mask;
            self.m_OnDragEnter?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            dragData_release = e.m_dragData_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_draggable_regions_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_draggable_regions_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, UIntPtr regionsCount, IntPtr regions, int regions_structsize);
        private static on_draggable_regions_changed_delegate on_draggable_regions_changed_native;
        private static IntPtr on_draggable_regions_changed_native_ptr;

        internal static void on_draggable_regions_changed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, UIntPtr regionsCount, IntPtr regions, int regions_structsize) {
            var self = (CfxDragHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnDraggableRegionsChangedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_regions = regions;
            e.m_regions_structsize = regions_structsize;
            e.m_regionsCount = regionsCount;
            self.m_OnDraggableRegionsChanged?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            if(e.m_regions_managed != null) {
                for(int i = 0; i < e.m_regions_managed.Length; ++i) {
                    e.m_regions_managed[i].Dispose();
                }
            }
        }

        public CfxDragHandler() : base(CfxApi.DragHandler.cfx_drag_handler_ctor) {}

        /// <summary>
        /// Called when an external drag event enters the browser window. |DragData|
        /// contains the drag event data and |Mask| represents the type of drag
        /// operation. Return false (0) for default drag handling behavior or true (1)
        /// to cancel the drag event.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnDragEnterEventHandler OnDragEnter {
            add {
                lock(eventLock) {
                    if(m_OnDragEnter == null) {
                        CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 0, on_drag_enter_native_ptr);
                    }
                    m_OnDragEnter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDragEnter -= value;
                    if(m_OnDragEnter == null) {
                        CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDragEnterEventHandler m_OnDragEnter;

        /// <summary>
        /// Called whenever draggable regions for the browser window change. These can
        /// be specified using the '-webkit-app-region: drag/no-drag' CSS-property. If
        /// draggable regions are never defined in a document this function will also
        /// never be called. If the last draggable region is removed from a document
        /// this function will be called with an NULL vector.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnDraggableRegionsChangedEventHandler OnDraggableRegionsChanged {
            add {
                lock(eventLock) {
                    if(m_OnDraggableRegionsChanged == null) {
                        CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 1, on_draggable_regions_changed_native_ptr);
                    }
                    m_OnDraggableRegionsChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDraggableRegionsChanged -= value;
                    if(m_OnDraggableRegionsChanged == null) {
                        CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDraggableRegionsChangedEventHandler m_OnDraggableRegionsChanged;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnDragEnter != null) {
                m_OnDragEnter = null;
                CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnDraggableRegionsChanged != null) {
                m_OnDraggableRegionsChanged = null;
                CfxApi.DragHandler.cfx_drag_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called when an external drag event enters the browser window. |DragData|
        /// contains the drag event data and |Mask| represents the type of drag
        /// operation. Return false (0) for default drag handling behavior or true (1)
        /// to cancel the drag event.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnDragEnterEventHandler(object sender, CfxOnDragEnterEventArgs e);

        /// <summary>
        /// Called when an external drag event enters the browser window. |DragData|
        /// contains the drag event data and |Mask| represents the type of drag
        /// operation. Return false (0) for default drag handling behavior or true (1)
        /// to cancel the drag event.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnDragEnterEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_dragData;
            internal CfxDragData m_dragData_wrapped;
            internal int m_mask;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnDragEnterEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDragHandler.OnDragEnter"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the DragData parameter for the <see cref="CfxDragHandler.OnDragEnter"/> callback.
            /// </summary>
            public CfxDragData DragData {
                get {
                    CheckAccess();
                    if(m_dragData_wrapped == null) m_dragData_wrapped = CfxDragData.Wrap(m_dragData);
                    return m_dragData_wrapped;
                }
            }
            /// <summary>
            /// Get the Mask parameter for the <see cref="CfxDragHandler.OnDragEnter"/> callback.
            /// </summary>
            public CfxDragOperationsMask Mask {
                get {
                    CheckAccess();
                    return (CfxDragOperationsMask)m_mask;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxDragHandler.OnDragEnter"/> callback.
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
                return String.Format("Browser={{{0}}}, DragData={{{1}}}, Mask={{{2}}}", Browser, DragData, Mask);
            }
        }

        /// <summary>
        /// Called whenever draggable regions for the browser window change. These can
        /// be specified using the '-webkit-app-region: drag/no-drag' CSS-property. If
        /// draggable regions are never defined in a document this function will also
        /// never be called. If the last draggable region is removed from a document
        /// this function will be called with an NULL vector.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnDraggableRegionsChangedEventHandler(object sender, CfxOnDraggableRegionsChangedEventArgs e);

        /// <summary>
        /// Called whenever draggable regions for the browser window change. These can
        /// be specified using the '-webkit-app-region: drag/no-drag' CSS-property. If
        /// draggable regions are never defined in a document this function will also
        /// never be called. If the last draggable region is removed from a document
        /// this function will be called with an NULL vector.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnDraggableRegionsChangedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_regions;
            internal int m_regions_structsize;
            internal UIntPtr m_regionsCount;
            internal CfxDraggableRegion[] m_regions_managed;

            internal CfxOnDraggableRegionsChangedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDragHandler.OnDraggableRegionsChanged"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxDragHandler.OnDraggableRegionsChanged"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Regions parameter for the <see cref="CfxDragHandler.OnDraggableRegionsChanged"/> callback.
            /// Do not keep a reference to the elements of this array outside of this function.
            /// </summary>
            public CfxDraggableRegion[] Regions {
                get {
                    CheckAccess();
                    if(m_regions_managed == null) {
                        m_regions_managed = new CfxDraggableRegion[(ulong)m_regionsCount];
                        var currentPtr = m_regions;
                        for(ulong i = 0; i < (ulong)m_regionsCount; ++i) {
                            m_regions_managed[i] = CfxDraggableRegion.Wrap(currentPtr);
                            currentPtr += m_regions_structsize;
                        }
                    }
                    return m_regions_managed;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Regions={{{2}}}", Browser, Frame, Regions);
            }
        }

    }
}
