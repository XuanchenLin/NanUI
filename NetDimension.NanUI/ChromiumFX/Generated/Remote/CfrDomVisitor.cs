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

namespace Chromium.Remote
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
	public class CfrDomVisitor : CfrBase {

        internal static CfrDomVisitor Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrDomVisitor)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrDomVisitor(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxDomVisitorCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        internal void raise_Visit(object sender, CfrDomVisitorVisitEventArgs e) {
            var handler = m_Visit;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }


        private CfrDomVisitor(IntPtr proxyId) : base(proxyId) {}
        public CfrDomVisitor() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
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
                    var call = new CfxDomVisitorVisitActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_Visit += value;
            }
            remove {
                m_Visit -= value;
                if(m_Visit == null) {
                    var call = new CfxDomVisitorVisitDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrDomVisitorVisitEventHandler m_Visit;


        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
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

            bool DocumentFetched;
            CfrDomDocument m_Document;

            internal CfrDomVisitorVisitEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Document parameter for the <see cref="CfrDomVisitor.Visit"/> render process callback.
            /// </summary>
            public CfrDomDocument Document {
                get {
                    CheckAccess();
                    if(!DocumentFetched) {
                        DocumentFetched = true;
                        var call = new CfxDomVisitorVisitGetDocumentRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Document = CfrDomDocument.Wrap(call.value);
                    }
                    return m_Document;
                }
            }

            public override string ToString() {
                return String.Format("Document={{{0}}}", Document);
            }
        }

    }
}
