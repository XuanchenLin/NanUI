// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxV8ArrayBufferReleaseCallbackCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxV8ArrayBufferReleaseCallbackCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxV8ArrayBufferReleaseCallbackCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxV8ArrayBufferReleaseCallbackGetGcHandleRemoteCall : GetGcHandleRemoteCall {

        internal CfxV8ArrayBufferReleaseCallbackGetGcHandleRemoteCall()
            : base(RemoteCallId.CfxV8ArrayBufferReleaseCallbackGetGcHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            gc_handle = CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_get_gc_handle(self);
        }
    }

    internal class CfxV8ArrayBufferReleaseCallbackSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxV8ArrayBufferReleaseCallbackSetCallbackRemoteCall()
            : base(RemoteCallId.CfxV8ArrayBufferReleaseCallbackSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxV8ArrayBufferReleaseCallbackRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall : RemoteEventCall {

        internal CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall()
            : base(RemoteCallId.CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall) {}

        internal IntPtr buffer;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(buffer);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out buffer);
        }

        protected override void WriteReturn(StreamHandler h) {
        }

        protected override void ReadReturn(StreamHandler h) {
        }

        protected override void RemoteProcedure() {
            var self = (CfrV8ArrayBufferReleaseCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrReleaseBufferEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_ReleaseBuffer?.Invoke(self, e);
            e.connection = null;
        }
    }

}
