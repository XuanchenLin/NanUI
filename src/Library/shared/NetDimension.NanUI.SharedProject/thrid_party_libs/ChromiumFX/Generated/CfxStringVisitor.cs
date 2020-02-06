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
    /// Implement this structure to receive string values asynchronously.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
    /// </remarks>
    public class CfxStringVisitor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            visit_native = visit;

            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, IntPtr string_str, int string_length);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, IntPtr string_str, int string_length) {
            var self = (CfxStringVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxStringVisitorVisitEventArgs();
            e.m_string_str = string_str;
            e.m_string_length = string_length;
            self.m_Visit?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxStringVisitor() : base(CfxApi.StringVisitor.cfx_string_visitor_ctor) {}

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public event CfxStringVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        CfxApi.StringVisitor.cfx_string_visitor_set_callback(NativePtr, 0, visit_native_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.StringVisitor.cfx_string_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxStringVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.StringVisitor.cfx_string_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public delegate void CfxStringVisitorVisitEventHandler(object sender, CfxStringVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public class CfxStringVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_string_str;
            internal int m_string_length;
            internal string m_string;

            internal CfxStringVisitorVisitEventArgs() {}

            /// <summary>
            /// Get the String parameter for the <see cref="CfxStringVisitor.Visit"/> callback.
            /// </summary>
            public string String {
                get {
                    CheckAccess();
                    m_string = StringFunctions.PtrToStringUni(m_string_str, m_string_length);
                    return m_string;
                }
            }

            public override string ToString() {
                return String.Format("String={{{0}}}", String);
            }
        }

    }
}
