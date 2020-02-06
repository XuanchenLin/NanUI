// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxTaskCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxTaskCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxTaskCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.Task.cfx_task_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxTaskSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxTaskSetCallbackRemoteCall()
            : base(RemoteCallId.CfxTaskSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxTaskRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxTaskExecuteRemoteEventCall : RemoteEventCall {

        internal CfxTaskExecuteRemoteEventCall()
            : base(RemoteCallId.CfxTaskExecuteRemoteEventCall) {}


        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
        }

        protected override void ReadReturn(StreamHandler h) {
        }

        protected override void RemoteProcedure() {
            var self = (CfrTask)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrEventArgs();
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Execute?.Invoke(self, e);
            e.connection = null;
        }
    }

}
