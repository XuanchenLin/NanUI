// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxReadHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxReadHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxReadHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.ReadHandler.cfx_read_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxReadHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxReadHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxReadHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxReadHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxReadHandlerReadRemoteEventCall : RemoteEventCall {

        internal CfxReadHandlerReadRemoteEventCall()
            : base(RemoteCallId.CfxReadHandlerReadRemoteEventCall) {}

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
            var self = (CfrReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrReadHandlerReadEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Read?.Invoke(self, e);
            e.connection = null;
            __retval = (UIntPtr)e.m_returnValue;
        }
    }

    internal class CfxReadHandlerSeekRemoteEventCall : RemoteEventCall {

        internal CfxReadHandlerSeekRemoteEventCall()
            : base(RemoteCallId.CfxReadHandlerSeekRemoteEventCall) {}

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
            var self = (CfrReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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

    internal class CfxReadHandlerTellRemoteEventCall : RemoteEventCall {

        internal CfxReadHandlerTellRemoteEventCall()
            : base(RemoteCallId.CfxReadHandlerTellRemoteEventCall) {}


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
            var self = (CfrReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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

    internal class CfxReadHandlerEofRemoteEventCall : RemoteEventCall {

        internal CfxReadHandlerEofRemoteEventCall()
            : base(RemoteCallId.CfxReadHandlerEofRemoteEventCall) {}


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
            var self = (CfrReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrReadHandlerEofEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Eof?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue;
        }
    }

    internal class CfxReadHandlerMayBlockRemoteEventCall : RemoteEventCall {

        internal CfxReadHandlerMayBlockRemoteEventCall()
            : base(RemoteCallId.CfxReadHandlerMayBlockRemoteEventCall) {}


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
            var self = (CfrReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
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
