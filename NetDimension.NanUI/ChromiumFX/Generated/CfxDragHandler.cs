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
	/// Implement this structure to handle events related to dragging. The functions
	/// of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_handler_capi.h">cef/include/capi/cef_drag_handler_capi.h</see>.
	/// </remarks>
	public class CfxDragHandler : CfxBase {

        static CfxDragHandler () {
            CfxApiLoader.LoadCfxDragHandlerApi();
        }

        internal static CfxDragHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_drag_handler_get_gc_handle(nativePtr);
            return (CfxDragHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_drag_enter
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_drag_handler_on_drag_enter_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr dragData, int mask);
        private static cfx_drag_handler_on_drag_enter_delegate cfx_drag_handler_on_drag_enter;
        private static IntPtr cfx_drag_handler_on_drag_enter_ptr;

        internal static void on_drag_enter(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr dragData, int mask) {
            var self = (CfxDragHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnDragEnterEventArgs(browser, dragData, mask);
            var eventHandler = self.m_OnDragEnter;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_dragData_wrapped == null) CfxApi.cfx_release(e.m_dragData);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_draggable_regions_changed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_drag_handler_on_draggable_regions_changed_delegate(IntPtr gcHandlePtr, IntPtr browser, int regionsCount, IntPtr regions, int regions_structsize);
        private static cfx_drag_handler_on_draggable_regions_changed_delegate cfx_drag_handler_on_draggable_regions_changed;
        private static IntPtr cfx_drag_handler_on_draggable_regions_changed_ptr;

        internal static void on_draggable_regions_changed(IntPtr gcHandlePtr, IntPtr browser, int regionsCount, IntPtr regions, int regions_structsize) {
            var self = (CfxDragHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnDraggableRegionsChangedEventArgs(browser, regions, regionsCount, regions_structsize);
            var eventHandler = self.m_OnDraggableRegionsChanged;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_regions_managed != null) {
                for(int i = 0; i < e.m_regions_managed.Length; ++i) {
                    e.m_regions_managed[i].Dispose();
                }
            }
        }

        internal CfxDragHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxDragHandler() : base(CfxApi.cfx_drag_handler_ctor) {}

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
                        if(cfx_drag_handler_on_drag_enter == null) {
                            cfx_drag_handler_on_drag_enter = on_drag_enter;
                            cfx_drag_handler_on_drag_enter_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_drag_handler_on_drag_enter);
                        }
                        CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 0, cfx_drag_handler_on_drag_enter_ptr);
                    }
                    m_OnDragEnter += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDragEnter -= value;
                    if(m_OnDragEnter == null) {
                        CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
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
                        if(cfx_drag_handler_on_draggable_regions_changed == null) {
                            cfx_drag_handler_on_draggable_regions_changed = on_draggable_regions_changed;
                            cfx_drag_handler_on_draggable_regions_changed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_drag_handler_on_draggable_regions_changed);
                        }
                        CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 1, cfx_drag_handler_on_draggable_regions_changed_ptr);
                    }
                    m_OnDraggableRegionsChanged += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDraggableRegionsChanged -= value;
                    if(m_OnDraggableRegionsChanged == null) {
                        CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDraggableRegionsChangedEventHandler m_OnDraggableRegionsChanged;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnDragEnter != null) {
                m_OnDragEnter = null;
                CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnDraggableRegionsChanged != null) {
                m_OnDraggableRegionsChanged = null;
                CfxApi.cfx_drag_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxOnDragEnterEventArgs(IntPtr browser, IntPtr dragData, int mask) {
                m_browser = browser;
                m_dragData = dragData;
                m_mask = mask;
            }

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
            IntPtr m_regions;
            int m_regions_structsize;
            int m_regionsCount;
            internal CfxDraggableRegion[] m_regions_managed;

            internal CfxOnDraggableRegionsChangedEventArgs(IntPtr browser, IntPtr regions, int regionsCount, int regions_structsize) {
                m_browser = browser;
                m_regions = regions;
                m_regions_structsize = regions_structsize;
                m_regionsCount = regionsCount;
            }

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
            /// Get the Regions parameter for the <see cref="CfxDragHandler.OnDraggableRegionsChanged"/> callback.
            /// Do not keep a reference to the elements of this array outside of this function.
            /// </summary>
            public CfxDraggableRegion[] Regions {
                get {
                    CheckAccess();
                    if(m_regions_managed == null) {
                        m_regions_managed = new CfxDraggableRegion[m_regionsCount];
                        for(int i = 0; i < m_regionsCount; ++i) {
                            m_regions_managed[i] = CfxDraggableRegion.Wrap(m_regions + (i * m_regions_structsize));
                        }
                    }
                    return m_regions_managed;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Regions={{{1}}}", Browser, Regions);
            }
        }

    }
}
