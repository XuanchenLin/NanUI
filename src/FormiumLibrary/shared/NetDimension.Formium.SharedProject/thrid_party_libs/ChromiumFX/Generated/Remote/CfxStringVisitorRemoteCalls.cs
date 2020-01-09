// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxStringVisitorCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxStringVisitorCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxStringVisitorCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.StringVisitor.cfx_string_visitor_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxStringVisitorSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxStringVisitorSetCallbackRemoteCall()
            : base(RemoteCallId.CfxStringVisitorSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxStringVisitorRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxStringVisitorVisitRemoteEventCall : RemoteEventCall {

        internal CfxStringVisitorVisitRemoteEventCall()
            : base(RemoteCallId.CfxStringVisitorVisitRemoteEventCall) {}

        internal IntPtr string_str;
        internal int string_length;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(string_str);
            h.Write(string_length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out string_str);
            h.Read(out string_length);
        }

        protected override void WriteReturn(StreamHandler h) {
        }

        protected override void ReadReturn(StreamHandler h) {
        }

        protected override void RemoteProcedure() {
            var self = (CfrStringVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrStringVisitorVisitEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Visit?.Invoke(self, e);
            e.connection = null;
        }
    }

}
