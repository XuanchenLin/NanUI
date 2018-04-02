// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxDomVisitorCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxDomVisitorCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxDomVisitorCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.DomVisitor.cfx_domvisitor_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxDomVisitorSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxDomVisitorSetCallbackRemoteCall()
            : base(RemoteCallId.CfxDomVisitorSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxDomVisitorRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxDomVisitorVisitRemoteEventCall : RemoteEventCall {

        internal CfxDomVisitorVisitRemoteEventCall()
            : base(RemoteCallId.CfxDomVisitorVisitRemoteEventCall) {}

        internal IntPtr document;
        internal int document_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(document);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out document);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(document_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out document_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrDomVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrDomVisitorVisitEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Visit?.Invoke(self, e);
            e.connection = null;
            document_release = e.m_document_wrapped == null? 1 : 0;
        }
    }

}
