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
    /// Structure to implement for visiting web plugin information. The functions of
    /// this structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
    /// </remarks>
    public class CfxWebPluginInfoVisitor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            visit_native = visit;

            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr info, out int info_release, int count, int total);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, out int __retval, IntPtr info, out int info_release, int count, int total) {
            var self = (CfxWebPluginInfoVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                info_release = 1;
                return;
            }
            var e = new CfxWebPluginInfoVisitorVisitEventArgs();
            e.m_info = info;
            e.m_count = count;
            e.m_total = total;
            self.m_Visit?.Invoke(self, e);
            e.m_isInvalid = true;
            info_release = e.m_info_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxWebPluginInfoVisitor() : base(CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_ctor) {}

        /// <summary>
        /// Method that will be called once for each plugin. |Count| is the 0-based
        /// index for the current plugin. |Total| is the total number of plugins.
        /// Return false (0) to stop visiting plugins. This function may never be
        /// called if no plugins are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public event CfxWebPluginInfoVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_set_callback(NativePtr, 0, visit_native_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxWebPluginInfoVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.WebPluginInfoVisitor.cfx_web_plugin_info_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called once for each plugin. |Count| is the 0-based
        /// index for the current plugin. |Total| is the total number of plugins.
        /// Return false (0) to stop visiting plugins. This function may never be
        /// called if no plugins are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public delegate void CfxWebPluginInfoVisitorVisitEventHandler(object sender, CfxWebPluginInfoVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be called once for each plugin. |Count| is the 0-based
        /// index for the current plugin. |Total| is the total number of plugins.
        /// Return false (0) to stop visiting plugins. This function may never be
        /// called if no plugins are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public class CfxWebPluginInfoVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_info;
            internal CfxWebPluginInfo m_info_wrapped;
            internal int m_count;
            internal int m_total;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxWebPluginInfoVisitorVisitEventArgs() {}

            /// <summary>
            /// Get the Info parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public CfxWebPluginInfo Info {
                get {
                    CheckAccess();
                    if(m_info_wrapped == null) m_info_wrapped = CfxWebPluginInfo.Wrap(m_info);
                    return m_info_wrapped;
                }
            }
            /// <summary>
            /// Get the Count parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public int Count {
                get {
                    CheckAccess();
                    return m_count;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public int Total {
                get {
                    CheckAccess();
                    return m_total;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
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
                return String.Format("Info={{{0}}}, Count={{{1}}}, Total={{{2}}}", Info, Count, Total);
            }
        }

    }
}
