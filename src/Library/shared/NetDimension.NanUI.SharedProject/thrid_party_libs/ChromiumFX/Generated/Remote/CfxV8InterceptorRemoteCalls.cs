// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxV8InterceptorCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxV8InterceptorCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxV8InterceptorCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Interceptor.cfx_v8interceptor_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxV8InterceptorSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxV8InterceptorSetCallbackRemoteCall()
            : base(RemoteCallId.CfxV8InterceptorSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxV8InterceptorRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxV8InterceptorGetByNameRemoteEventCall : RemoteEventCall {

        internal CfxV8InterceptorGetByNameRemoteEventCall()
            : base(RemoteCallId.CfxV8InterceptorGetByNameRemoteEventCall) {}

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
            var self = (CfrV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetByNameEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetByName?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            retval = CfrObject.Unwrap(e.m_retval_wrapped).ptr;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxV8InterceptorGetByIndexRemoteEventCall : RemoteEventCall {

        internal CfxV8InterceptorGetByIndexRemoteEventCall()
            : base(RemoteCallId.CfxV8InterceptorGetByIndexRemoteEventCall) {}

        internal int index;
        internal IntPtr @object;
        internal int object_release;
        internal IntPtr retval;
        internal string exception;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(index);
            h.Write(@object);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out index);
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
            var self = (CfrV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetByIndexEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetByIndex?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            retval = CfrObject.Unwrap(e.m_retval_wrapped).ptr;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxV8InterceptorSetByNameRemoteEventCall : RemoteEventCall {

        internal CfxV8InterceptorSetByNameRemoteEventCall()
            : base(RemoteCallId.CfxV8InterceptorSetByNameRemoteEventCall) {}

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
            var self = (CfrV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrSetByNameEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_SetByName?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            value_release = e.m_value_wrapped == null? 1 : 0;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxV8InterceptorSetByIndexRemoteEventCall : RemoteEventCall {

        internal CfxV8InterceptorSetByIndexRemoteEventCall()
            : base(RemoteCallId.CfxV8InterceptorSetByIndexRemoteEventCall) {}

        internal int index;
        internal IntPtr @object;
        internal int object_release;
        internal IntPtr value;
        internal int value_release;
        internal string exception;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(index);
            h.Write(@object);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out index);
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
            var self = (CfrV8Interceptor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrSetByIndexEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_SetByIndex?.Invoke(self, e);
            e.connection = null;
            object_release = e.m_object_wrapped == null? 1 : 0;
            value_release = e.m_value_wrapped == null? 1 : 0;
            exception = e.m_exception_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
