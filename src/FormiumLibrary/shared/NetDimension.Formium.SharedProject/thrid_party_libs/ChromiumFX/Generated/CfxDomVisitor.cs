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
    /// Structure to implement for visiting the DOM. The functions of this structure
    /// will be called on the render process main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
    /// </remarks>
    public class CfxDomVisitor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            visit_native = visit;

            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, IntPtr document, out int document_release);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, IntPtr document, out int document_release) {
            var self = (CfxDomVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                document_release = 1;
                return;
            }
            var e = new CfxDomVisitorVisitEventArgs();
            e.m_document = document;
            self.m_Visit?.Invoke(self, e);
            e.m_isInvalid = true;
            document_release = e.m_document_wrapped == null? 1 : 0;
        }

        public CfxDomVisitor() : base(CfxApi.DomVisitor.cfx_domvisitor_ctor) {}

        /// <summary>
        /// Method executed for visiting the DOM. The document object passed to this
        /// function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public event CfxDomVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        CfxApi.DomVisitor.cfx_domvisitor_set_callback(NativePtr, 0, visit_native_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.DomVisitor.cfx_domvisitor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxDomVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.DomVisitor.cfx_domvisitor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method executed for visiting the DOM. The document object passed to this
        /// function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public delegate void CfxDomVisitorVisitEventHandler(object sender, CfxDomVisitorVisitEventArgs e);

        /// <summary>
        /// Method executed for visiting the DOM. The document object passed to this
        /// function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public class CfxDomVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_document;
            internal CfxDomDocument m_document_wrapped;

            internal CfxDomVisitorVisitEventArgs() {}

            /// <summary>
            /// Get the Document parameter for the <see cref="CfxDomVisitor.Visit"/> callback.
            /// </summary>
            public CfxDomDocument Document {
                get {
                    CheckAccess();
                    if(m_document_wrapped == null) m_document_wrapped = CfxDomDocument.Wrap(m_document);
                    return m_document_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Document={{{0}}}", Document);
            }
        }

    }
}
