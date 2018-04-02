// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxV8AccessorCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxV8AccessorCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxV8AccessorCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Accessor.cfx_v8accessor_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxV8AccessorSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxV8AccessorSetCallbackRemoteCall()
            : base(RemoteCallId.CfxV8AccessorSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxV8AccessorRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxV8AccessorGetRemoteEventCall : RemoteEventCall {

        internal CfxV8AccessorGetRemoteEventCall()
            : base(RemoteCallId.CfxV8AccessorGetRemoteEventCall) {}

        internal IntPtr name_str;
        internal int name_length;
        internal IntPtr @object;
        internal int object_release;
        internal IntPtr retval;
        internal string exception;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(name_str);
            h.Write(name_length);
            h.Write(@object);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out name_str);
            h.Read(out name_length);
            h.Read(out @object);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(object_release);
            h.Write(retval);
            h.Write(exception);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out object_release);
            h.Read(out retval);
            h.Read(out exception);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrV8Accessor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrV8AccessorGetEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Get?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            retval = CfrObject.Unwrap(e.m_retval_wrapped).ptr;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxV8AccessorSetRemoteEventCall : RemoteEventCall {

        internal CfxV8AccessorSetRemoteEventCall()
            : base(RemoteCallId.CfxV8AccessorSetRemoteEventCall) {}

        internal IntPtr name_str;
        internal int name_length;
        internal IntPtr @object;
        internal int object_release;
        internal IntPtr value;
        internal int value_release;
        internal string exception;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(name_str);
            h.Write(name_length);
            h.Write(@object);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out name_str);
            h.Read(out name_length);
            h.Read(out @object);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(object_release);
            h.Write(value_release);
            h.Write(exception);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out object_release);
            h.Read(out value_release);
            h.Read(out exception);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrV8Accessor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrV8AccessorSetEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_Set?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            value_release = e.m_value_wrapped == null? 1 : 0;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
