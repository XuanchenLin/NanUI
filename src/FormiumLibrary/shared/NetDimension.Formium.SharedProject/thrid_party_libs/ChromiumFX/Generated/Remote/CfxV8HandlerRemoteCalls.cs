// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxV8HandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxV8HandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxV8HandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Handler.cfx_v8handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxV8HandlerGetGcHandleRemoteCall : GetGcHandleRemoteCall {

        internal CfxV8HandlerGetGcHandleRemoteCall()
            : base(RemoteCallId.CfxV8HandlerGetGcHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            gc_handle = CfxApi.V8Handler.cfx_v8handler_get_gc_handle(self);
        }
    }

    internal class CfxV8HandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxV8HandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxV8HandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxV8HandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxV8HandlerExecuteRemoteEventCall : RemoteEventCall {

        internal CfxV8HandlerExecuteRemoteEventCall()
            : base(RemoteCallId.CfxV8HandlerExecuteRemoteEventCall) {}

        internal IntPtr name_str;
        internal int name_length;
        internal IntPtr @object;
        internal int object_release;
        internal UIntPtr argumentsCount;
        internal IntPtr arguments;
        internal int arguments_release;
        internal IntPtr retval;
        internal string exception;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(name_str);
            h.Write(name_length);
            h.Write(@object);
            h.Write(argumentsCount);
            h.Write(arguments);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out name_str);
            h.Read(out name_length);
            h.Read(out @object);
            h.Read(out argumentsCount);
            h.Read(out arguments);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(object_release);
            h.Write(arguments_release);
            h.Write(retval);
            h.Write(exception);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out object_release);
            h.Read(out arguments_release);
            h.Read(out retval);
            h.Read(out exception);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrV8HandlerExecuteEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Execute?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            arguments_release = e.m_arguments_managed == null? 1 : 0;
            exception = e.m_exception_wrapped;
            retval = CfrV8Value.Unwrap(e.m_returnValue).ptr;
            __retval = e.m_returnValue != null || e.m_exception_wrapped != null ? 1 : 0;
        }
    }

}
