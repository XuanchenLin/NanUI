// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Structure to implement for visiting the DOM. The functions of this structure
    /// will be called on the render process main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
    /// </remarks>
    public class CfrDomVisitor : CfrBaseClient {


        private CfrDomVisitor(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrDomVisitor() : base(new CfxDomVisitorCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

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
        public event CfrDomVisitorVisitEventHandler Visit {
            add {
                if(m_Visit == null) {
                    var call = new CfxDomVisitorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Visit += value;
            }
            remove {
                m_Visit -= value;
                if(m_Visit == null) {
                    var call = new CfxDomVisitorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrDomVisitorVisitEventHandler m_Visit;


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
        public delegate void CfrDomVisitorVisitEventHandler(object sender, CfrDomVisitorVisitEventArgs e);

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
        public class CfrDomVisitorVisitEventArgs : CfrEventArgs {

            private CfxDomVisitorVisitRemoteEventCall call;

            internal CfrDomDocument m_document_wrapped;

            internal CfrDomVisitorVisitEventArgs(CfxDomVisitorVisitRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Document parameter for the <see cref="CfrDomVisitor.Visit"/> render process callback.
            /// </summary>
            public CfrDomDocument Document {
                get {
                    CheckAccess();
                    if(m_document_wrapped == null) m_document_wrapped = CfrDomDocument.Wrap(new RemotePtr(connection, call.document));
                    return m_document_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Document={{{0}}}", Document);
            }
        }

    }
}
