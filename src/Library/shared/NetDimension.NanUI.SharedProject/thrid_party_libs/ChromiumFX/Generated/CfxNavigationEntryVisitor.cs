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
    /// Callback structure for CfxBrowserHost.GetNavigationEntries. The
    /// functions of this structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxNavigationEntryVisitor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            visit_native = visit;

            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr entry, out int entry_release, int current, int index, int total);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, out int __retval, IntPtr entry, out int entry_release, int current, int index, int total) {
            var self = (CfxNavigationEntryVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                entry_release = 1;
                return;
            }
            var e = new CfxNavigationEntryVisitorVisitEventArgs();
            e.m_entry = entry;
            e.m_current = current;
            e.m_index = index;
            e.m_total = total;
            self.m_Visit?.Invoke(self, e);
            e.m_isInvalid = true;
            entry_release = e.m_entry_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxNavigationEntryVisitor() : base(CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_ctor) {}

        /// <summary>
        /// Method that will be executed. Do not keep a reference to |Entry| outside of
        /// this callback. Return true (1) to continue visiting entries or false (0) to
        /// stop. |Current| is true (1) if this entry is the currently loaded
        /// navigation entry. |Index| is the 0-based index of this entry and |Total| is
        /// the total number of entries.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public event CfxNavigationEntryVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_set_callback(NativePtr, 0, visit_native_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxNavigationEntryVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.NavigationEntryVisitor.cfx_navigation_entry_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be executed. Do not keep a reference to |Entry| outside of
        /// this callback. Return true (1) to continue visiting entries or false (0) to
        /// stop. |Current| is true (1) if this entry is the currently loaded
        /// navigation entry. |Index| is the 0-based index of this entry and |Total| is
        /// the total number of entries.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public delegate void CfxNavigationEntryVisitorVisitEventHandler(object sender, CfxNavigationEntryVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be executed. Do not keep a reference to |Entry| outside of
        /// this callback. Return true (1) to continue visiting entries or false (0) to
        /// stop. |Current| is true (1) if this entry is the currently loaded
        /// navigation entry. |Index| is the 0-based index of this entry and |Total| is
        /// the total number of entries.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public class CfxNavigationEntryVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_entry;
            internal CfxNavigationEntry m_entry_wrapped;
            internal int m_current;
            internal int m_index;
            internal int m_total;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxNavigationEntryVisitorVisitEventArgs() {}

            /// <summary>
            /// Get the Entry parameter for the <see cref="CfxNavigationEntryVisitor.Visit"/> callback.
            /// </summary>
            public CfxNavigationEntry Entry {
                get {
                    CheckAccess();
                    if(m_entry_wrapped == null) m_entry_wrapped = CfxNavigationEntry.Wrap(m_entry);
                    return m_entry_wrapped;
                }
            }
            /// <summary>
            /// Get the Current parameter for the <see cref="CfxNavigationEntryVisitor.Visit"/> callback.
            /// </summary>
            public bool Current {
                get {
                    CheckAccess();
                    return 0 != m_current;
                }
            }
            /// <summary>
            /// Get the Index parameter for the <see cref="CfxNavigationEntryVisitor.Visit"/> callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return m_index;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxNavigationEntryVisitor.Visit"/> callback.
            /// </summary>
            public int Total {
                get {
                    CheckAccess();
                    return m_total;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxNavigationEntryVisitor.Visit"/> callback.
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
                return String.Format("Entry={{{0}}}, Current={{{1}}}, Index={{{2}}}, Total={{{3}}}", Entry, Current, Index, Total);
            }
        }

    }
}
