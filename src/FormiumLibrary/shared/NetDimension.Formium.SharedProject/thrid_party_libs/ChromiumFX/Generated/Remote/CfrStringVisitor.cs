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
    /// Implement this structure to receive string values asynchronously.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
    /// </remarks>
    public class CfrStringVisitor : CfrBaseClient {


        private CfrStringVisitor(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrStringVisitor() : base(new CfxStringVisitorCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public event CfrStringVisitorVisitEventHandler Visit {
            add {
                if(m_Visit == null) {
                    var call = new CfxStringVisitorSetCallbackRemoteCall();
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
                    var call = new CfxStringVisitorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrStringVisitorVisitEventHandler m_Visit;


    }

    namespace Event {

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public delegate void CfrStringVisitorVisitEventHandler(object sender, CfrStringVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be executed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_string_visitor_capi.h">cef/include/capi/cef_string_visitor_capi.h</see>.
        /// </remarks>
        public class CfrStringVisitorVisitEventArgs : CfrEventArgs {

            private CfxStringVisitorVisitRemoteEventCall call;

            internal string m_string;
            internal bool m_string_fetched;

            internal CfrStringVisitorVisitEventArgs(CfxStringVisitorVisitRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the String parameter for the <see cref="CfrStringVisitor.Visit"/> render process callback.
            /// </summary>
            public string String {
                get {
                    CheckAccess();
                    if(!m_string_fetched) {
                        m_string = call.string_str == IntPtr.Zero ? null : (call.string_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.string_str), call.string_length));
                        m_string_fetched = true;
                    }
                    return m_string;
                }
            }

            public override string ToString() {
                return String.Format("String={{{0}}}", String);
            }
        }

    }
}
