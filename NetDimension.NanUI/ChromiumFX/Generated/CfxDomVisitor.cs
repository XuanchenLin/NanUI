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
	/// Structure to implement for visiting the DOM. The functions of this structure
	/// will be called on the render process main thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
	/// </remarks>
	public class CfxDomVisitor : CfxBase {

        static CfxDomVisitor () {
            CfxApiLoader.LoadCfxDomVisitorApi();
        }

        internal static CfxDomVisitor Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_domvisitor_get_gc_handle(nativePtr);
            return (CfxDomVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_domvisitor_visit_delegate(IntPtr gcHandlePtr, IntPtr document);
        private static cfx_domvisitor_visit_delegate cfx_domvisitor_visit;
        private static IntPtr cfx_domvisitor_visit_ptr;

        internal static void visit(IntPtr gcHandlePtr, IntPtr document) {
            var self = (CfxDomVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxDomVisitorVisitEventArgs(document);
            var eventHandler = self.m_Visit;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_document_wrapped == null) CfxApi.cfx_release(e.m_document);
        }

        internal CfxDomVisitor(IntPtr nativePtr) : base(nativePtr) {}
        public CfxDomVisitor() : base(CfxApi.cfx_domvisitor_ctor) {}

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
                        if(cfx_domvisitor_visit == null) {
                            cfx_domvisitor_visit = visit;
                            cfx_domvisitor_visit_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_domvisitor_visit);
                        }
                        CfxApi.cfx_domvisitor_set_managed_callback(NativePtr, 0, cfx_domvisitor_visit_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.cfx_domvisitor_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxDomVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.cfx_domvisitor_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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

            internal CfxDomVisitorVisitEventArgs(IntPtr document) {
                m_document = document;
            }

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
