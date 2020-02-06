// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxWriteHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxWriteHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxWriteHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.WriteHandler.cfx_write_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxWriteHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxWriteHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxWriteHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxWriteHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxWriteHandlerWriteRemoteEventCall : RemoteEventCall {

        internal CfxWriteHandlerWriteRemoteEventCall()
            : base(RemoteCallId.CfxWriteHandlerWriteRemoteEventCall) {}

        internal IntPtr ptr;
        internal UIntPtr size;
        internal UIntPtr n;

        internal UIntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(ptr);
            h.Write(size);
            h.Write(n);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out ptr);
            h.Read(out size);
            h.Read(out n);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrWriteHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrWriteEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Write?.Invoke(self, e);
            e.connection = null;
            __retval = (UIntPtr)e.m_returnValue;
        }
    }

    internal class CfxWriteHandlerSeekRemoteEventCall : RemoteEventCall {

        internal CfxWriteHandlerSeekRemoteEventCall()
            : base(RemoteCallId.CfxWriteHandlerSeekRemoteEventCall) {}

        internal long offset;
        internal int whence;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(offset);
            h.Write(whence);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out offset);
            h.Read(out whence);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrWriteHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrSeekEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Seek?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue;
        }
    }

    internal class CfxWriteHandlerTellRemoteEventCall : RemoteEventCall {

        internal CfxWriteHandlerTellRemoteEventCall()
            : base(RemoteCallId.CfxWriteHandlerTellRemoteEventCall) {}


        internal long __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrWriteHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrTellEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Tell?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue;
        }
    }

    internal class CfxWriteHandlerFlushRemoteEventCall : RemoteEventCall {

        internal CfxWriteHandlerFlushRemoteEventCall()
            : base(RemoteCallId.CfxWriteHandlerFlushRemoteEventCall) {}


        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrWriteHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrFlushEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Flush?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue;
        }
    }

    internal class CfxWriteHandlerMayBlockRemoteEventCall : RemoteEventCall {

        internal CfxWriteHandlerMayBlockRemoteEventCall()
            : base(RemoteCallId.CfxWriteHandlerMayBlockRemoteEventCall) {}


        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrWriteHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrMayBlockEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_MayBlock?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
