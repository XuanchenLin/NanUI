// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxV8ValueCreateUndefinedRemoteCall : RemoteCall {

        internal CfxV8ValueCreateUndefinedRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateUndefinedRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_undefined();
        }
    }

    internal class CfxV8ValueCreateNullRemoteCall : RemoteCall {

        internal CfxV8ValueCreateNullRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateNullRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_null();
        }
    }

    internal class CfxV8ValueCreateBoolRemoteCall : RemoteCall {

        internal CfxV8ValueCreateBoolRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateBoolRemoteCall) {}

        internal bool value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_bool(value ? 1 : 0);
        }
    }

    internal class CfxV8ValueCreateIntRemoteCall : RemoteCall {

        internal CfxV8ValueCreateIntRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateIntRemoteCall) {}

        internal int value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_int(value);
        }
    }

    internal class CfxV8ValueCreateUintRemoteCall : RemoteCall {

        internal CfxV8ValueCreateUintRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateUintRemoteCall) {}

        internal uint value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_uint(value);
        }
    }

    internal class CfxV8ValueCreateDoubleRemoteCall : RemoteCall {

        internal CfxV8ValueCreateDoubleRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateDoubleRemoteCall) {}

        internal double value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_double(value);
        }
    }

    internal class CfxV8ValueCreateDateRemoteCall : RemoteCall {

        internal CfxV8ValueCreateDateRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateDateRemoteCall) {}

        internal IntPtr date;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(date);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out date);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_date(date);
        }
    }

    internal class CfxV8ValueCreateStringRemoteCall : RemoteCall {

        internal CfxV8ValueCreateStringRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateStringRemoteCall) {}

        internal string value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            __retval = CfxApi.V8Value.cfx_v8value_create_string(value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueCreateObjectRemoteCall : RemoteCall {

        internal CfxV8ValueCreateObjectRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateObjectRemoteCall) {}

        internal IntPtr accessor;
        internal IntPtr interceptor;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(accessor);
            h.Write(interceptor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out accessor);
            h.Read(out interceptor);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_object(accessor, interceptor);
        }
    }

    internal class CfxV8ValueCreateArrayRemoteCall : RemoteCall {

        internal CfxV8ValueCreateArrayRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateArrayRemoteCall) {}

        internal int length;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_array(length);
        }
    }

    internal class CfxV8ValueCreateArrayBufferRemoteCall : RemoteCall {

        internal CfxV8ValueCreateArrayBufferRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateArrayBufferRemoteCall) {}

        internal IntPtr buffer;
        internal ulong length;
        internal IntPtr releaseCallback;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(buffer);
            h.Write(length);
            h.Write(releaseCallback);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out buffer);
            h.Read(out length);
            h.Read(out releaseCallback);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_create_array_buffer(buffer, (UIntPtr)length, releaseCallback);
        }
    }

    internal class CfxV8ValueCreateFunctionRemoteCall : RemoteCall {

        internal CfxV8ValueCreateFunctionRemoteCall()
            : base(RemoteCallId.CfxV8ValueCreateFunctionRemoteCall) {}

        internal string name;
        internal IntPtr handler;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(name);
            h.Write(handler);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out name);
            h.Read(out handler);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = CfxApi.V8Value.cfx_v8value_create_function(name_pinned.Obj.PinnedPtr, name_pinned.Length, handler);
            name_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueIsValidRemoteCall : RemoteCall {

        internal CfxV8ValueIsValidRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsValidRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_valid(@this);
        }
    }

    internal class CfxV8ValueIsUndefinedRemoteCall : RemoteCall {

        internal CfxV8ValueIsUndefinedRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsUndefinedRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_undefined(@this);
        }
    }

    internal class CfxV8ValueIsNullRemoteCall : RemoteCall {

        internal CfxV8ValueIsNullRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsNullRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_null(@this);
        }
    }

    internal class CfxV8ValueIsBoolRemoteCall : RemoteCall {

        internal CfxV8ValueIsBoolRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsBoolRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_bool(@this);
        }
    }

    internal class CfxV8ValueIsIntRemoteCall : RemoteCall {

        internal CfxV8ValueIsIntRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsIntRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_int(@this);
        }
    }

    internal class CfxV8ValueIsUintRemoteCall : RemoteCall {

        internal CfxV8ValueIsUintRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsUintRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_uint(@this);
        }
    }

    internal class CfxV8ValueIsDoubleRemoteCall : RemoteCall {

        internal CfxV8ValueIsDoubleRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsDoubleRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_double(@this);
        }
    }

    internal class CfxV8ValueIsDateRemoteCall : RemoteCall {

        internal CfxV8ValueIsDateRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsDateRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_date(@this);
        }
    }

    internal class CfxV8ValueIsStringRemoteCall : RemoteCall {

        internal CfxV8ValueIsStringRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsStringRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_string(@this);
        }
    }

    internal class CfxV8ValueIsObjectRemoteCall : RemoteCall {

        internal CfxV8ValueIsObjectRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsObjectRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_object(@this);
        }
    }

    internal class CfxV8ValueIsArrayRemoteCall : RemoteCall {

        internal CfxV8ValueIsArrayRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsArrayRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_array(@this);
        }
    }

    internal class CfxV8ValueIsArrayBufferRemoteCall : RemoteCall {

        internal CfxV8ValueIsArrayBufferRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsArrayBufferRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_array_buffer(@this);
        }
    }

    internal class CfxV8ValueIsFunctionRemoteCall : RemoteCall {

        internal CfxV8ValueIsFunctionRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsFunctionRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_function(@this);
        }
    }

    internal class CfxV8ValueIsSameRemoteCall : RemoteCall {

        internal CfxV8ValueIsSameRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsSameRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr that;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(that);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out that);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_same(@this, that);
        }
    }

    internal class CfxV8ValueGetBoolValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetBoolValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetBoolValueRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_get_bool_value(@this);
        }
    }

    internal class CfxV8ValueGetIntValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetIntValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetIntValueRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_int_value(@this);
        }
    }

    internal class CfxV8ValueGetUintValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetUintValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetUintValueRemoteCall) {}

        internal IntPtr @this;
        internal uint __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_uint_value(@this);
        }
    }

    internal class CfxV8ValueGetDoubleValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetDoubleValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetDoubleValueRemoteCall) {}

        internal IntPtr @this;
        internal double __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_double_value(@this);
        }
    }

    internal class CfxV8ValueGetDateValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetDateValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetDateValueRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_date_value(@this);
        }
    }

    internal class CfxV8ValueGetStringValueRemoteCall : RemoteCall {

        internal CfxV8ValueGetStringValueRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetStringValueRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8Value.cfx_v8value_get_string_value(@this));
        }
    }

    internal class CfxV8ValueIsUserCreatedRemoteCall : RemoteCall {

        internal CfxV8ValueIsUserCreatedRemoteCall()
            : base(RemoteCallId.CfxV8ValueIsUserCreatedRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_is_user_created(@this);
        }
    }

    internal class CfxV8ValueHasExceptionRemoteCall : RemoteCall {

        internal CfxV8ValueHasExceptionRemoteCall()
            : base(RemoteCallId.CfxV8ValueHasExceptionRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_has_exception(@this);
        }
    }

    internal class CfxV8ValueGetExceptionRemoteCall : RemoteCall {

        internal CfxV8ValueGetExceptionRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetExceptionRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_exception(@this);
        }
    }

    internal class CfxV8ValueClearExceptionRemoteCall : RemoteCall {

        internal CfxV8ValueClearExceptionRemoteCall()
            : base(RemoteCallId.CfxV8ValueClearExceptionRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_clear_exception(@this);
        }
    }

    internal class CfxV8ValueWillRethrowExceptionsRemoteCall : RemoteCall {

        internal CfxV8ValueWillRethrowExceptionsRemoteCall()
            : base(RemoteCallId.CfxV8ValueWillRethrowExceptionsRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_will_rethrow_exceptions(@this);
        }
    }

    internal class CfxV8ValueSetRethrowExceptionsRemoteCall : RemoteCall {

        internal CfxV8ValueSetRethrowExceptionsRemoteCall()
            : base(RemoteCallId.CfxV8ValueSetRethrowExceptionsRemoteCall) {}

        internal IntPtr @this;
        internal bool rethrow;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(rethrow);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out rethrow);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_set_rethrow_exceptions(@this, rethrow ? 1 : 0);
        }
    }

    internal class CfxV8ValueHasValueByKeyRemoteCall : RemoteCall {

        internal CfxV8ValueHasValueByKeyRemoteCall()
            : base(RemoteCallId.CfxV8ValueHasValueByKeyRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.V8Value.cfx_v8value_has_value_bykey(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueHasValueByIndexRemoteCall : RemoteCall {

        internal CfxV8ValueHasValueByIndexRemoteCall()
            : base(RemoteCallId.CfxV8ValueHasValueByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_has_value_byindex(@this, index);
        }
    }

    internal class CfxV8ValueDeleteValueByKeyRemoteCall : RemoteCall {

        internal CfxV8ValueDeleteValueByKeyRemoteCall()
            : base(RemoteCallId.CfxV8ValueDeleteValueByKeyRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.V8Value.cfx_v8value_delete_value_bykey(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueDeleteValueByIndexRemoteCall : RemoteCall {

        internal CfxV8ValueDeleteValueByIndexRemoteCall()
            : base(RemoteCallId.CfxV8ValueDeleteValueByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_delete_value_byindex(@this, index);
        }
    }

    internal class CfxV8ValueGetValueByKeyRemoteCall : RemoteCall {

        internal CfxV8ValueGetValueByKeyRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetValueByKeyRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = CfxApi.V8Value.cfx_v8value_get_value_bykey(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueGetValueByIndexRemoteCall : RemoteCall {

        internal CfxV8ValueGetValueByIndexRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetValueByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_value_byindex(@this, index);
        }
    }

    internal class CfxV8ValueSetValueByKeyRemoteCall : RemoteCall {

        internal CfxV8ValueSetValueByKeyRemoteCall()
            : base(RemoteCallId.CfxV8ValueSetValueByKeyRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr value;
        internal int attribute;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
            h.Write(attribute);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
            h.Read(out attribute);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.V8Value.cfx_v8value_set_value_bykey(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value, (int)attribute);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueSetValueByIndexRemoteCall : RemoteCall {

        internal CfxV8ValueSetValueByIndexRemoteCall()
            : base(RemoteCallId.CfxV8ValueSetValueByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_set_value_byindex(@this, index, value);
        }
    }

    internal class CfxV8ValueSetValueByAccessorRemoteCall : RemoteCall {

        internal CfxV8ValueSetValueByAccessorRemoteCall()
            : base(RemoteCallId.CfxV8ValueSetValueByAccessorRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal int settings;
        internal int attribute;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(settings);
            h.Write(attribute);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out settings);
            h.Read(out attribute);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.V8Value.cfx_v8value_set_value_byaccessor(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, (int)settings, (int)attribute);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxV8ValueGetKeysRemoteCall : RemoteCall {

        internal CfxV8ValueGetKeysRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetKeysRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string> keys;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(keys);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out keys);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(keys);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out keys);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            PinnedString[] keys_handles;
            var keys_unwrapped = StringFunctions.UnwrapCfxStringList(keys, out keys_handles);
            __retval = 0 != CfxApi.V8Value.cfx_v8value_get_keys(@this, keys_unwrapped);
            StringFunctions.FreePinnedStrings(keys_handles);
            StringFunctions.CfxStringListCopyToManaged(keys_unwrapped, keys);
            CfxApi.Runtime.cfx_string_list_free(keys_unwrapped);
        }
    }

    internal class CfxV8ValueSetUserDataRemoteCall : RemoteCall {

        internal CfxV8ValueSetUserDataRemoteCall()
            : base(RemoteCallId.CfxV8ValueSetUserDataRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr userData;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(userData);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out userData);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_set_user_data(@this, userData);
        }
    }

    internal class CfxV8ValueGetUserDataRemoteCall : RemoteCall {

        internal CfxV8ValueGetUserDataRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetUserDataRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_user_data(@this);
        }
    }

    internal class CfxV8ValueGetExternallyAllocatedMemoryRemoteCall : RemoteCall {

        internal CfxV8ValueGetExternallyAllocatedMemoryRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetExternallyAllocatedMemoryRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_externally_allocated_memory(@this);
        }
    }

    internal class CfxV8ValueAdjustExternallyAllocatedMemoryRemoteCall : RemoteCall {

        internal CfxV8ValueAdjustExternallyAllocatedMemoryRemoteCall()
            : base(RemoteCallId.CfxV8ValueAdjustExternallyAllocatedMemoryRemoteCall) {}

        internal IntPtr @this;
        internal int changeInBytes;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(changeInBytes);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out changeInBytes);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_adjust_externally_allocated_memory(@this, changeInBytes);
        }
    }

    internal class CfxV8ValueGetArrayLengthRemoteCall : RemoteCall {

        internal CfxV8ValueGetArrayLengthRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetArrayLengthRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_array_length(@this);
        }
    }

    internal class CfxV8ValueGetArrayBufferReleaseCallbackRemoteCall : RemoteCall {

        internal CfxV8ValueGetArrayBufferReleaseCallbackRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetArrayBufferReleaseCallbackRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_array_buffer_release_callback(@this);
        }
    }

    internal class CfxV8ValueNeuterArrayBufferRemoteCall : RemoteCall {

        internal CfxV8ValueNeuterArrayBufferRemoteCall()
            : base(RemoteCallId.CfxV8ValueNeuterArrayBufferRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Value.cfx_v8value_neuter_array_buffer(@this);
        }
    }

    internal class CfxV8ValueGetFunctionNameRemoteCall : RemoteCall {

        internal CfxV8ValueGetFunctionNameRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetFunctionNameRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8Value.cfx_v8value_get_function_name(@this));
        }
    }

    internal class CfxV8ValueGetFunctionHandlerRemoteCall : RemoteCall {

        internal CfxV8ValueGetFunctionHandlerRemoteCall()
            : base(RemoteCallId.CfxV8ValueGetFunctionHandlerRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Value.cfx_v8value_get_function_handler(@this);
        }
    }

    internal class CfxV8ValueExecuteFunctionRemoteCall : RemoteCall {

        internal CfxV8ValueExecuteFunctionRemoteCall()
            : base(RemoteCallId.CfxV8ValueExecuteFunctionRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr @object;
        internal IntPtr[] arguments;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(@object);
            h.Write(arguments);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out @object);
            h.Read(out arguments);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            PinnedObject arguments_pinned = new PinnedObject(arguments);
            var arguments_length = arguments == null ? UIntPtr.Zero : (UIntPtr)arguments.LongLength;
            __retval = CfxApi.V8Value.cfx_v8value_execute_function(@this, @object, arguments_length, arguments_pinned.PinnedPtr);
            arguments_pinned.Free();
        }
    }

    internal class CfxV8ValueExecuteFunctionWithContextRemoteCall : RemoteCall {

        internal CfxV8ValueExecuteFunctionWithContextRemoteCall()
            : base(RemoteCallId.CfxV8ValueExecuteFunctionWithContextRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr context;
        internal IntPtr @object;
        internal IntPtr[] arguments;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(context);
            h.Write(@object);
            h.Write(arguments);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out context);
            h.Read(out @object);
            h.Read(out arguments);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            PinnedObject arguments_pinned = new PinnedObject(arguments);
            var arguments_length = arguments == null ? UIntPtr.Zero : (UIntPtr)arguments.LongLength;
            __retval = CfxApi.V8Value.cfx_v8value_execute_function_with_context(@this, context, @object, arguments_length, arguments_pinned.PinnedPtr);
            arguments_pinned.Free();
        }
    }

}
