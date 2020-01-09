// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxValueCreateRemoteCall : RemoteCall {

        internal CfxValueCreateRemoteCall()
            : base(RemoteCallId.CfxValueCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Value.cfx_value_create();
        }
    }

    internal class CfxValueIsValidRemoteCall : RemoteCall {

        internal CfxValueIsValidRemoteCall()
            : base(RemoteCallId.CfxValueIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_is_valid(@this);
        }
    }

    internal class CfxValueIsOwnedRemoteCall : RemoteCall {

        internal CfxValueIsOwnedRemoteCall()
            : base(RemoteCallId.CfxValueIsOwnedRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_is_owned(@this);
        }
    }

    internal class CfxValueIsReadOnlyRemoteCall : RemoteCall {

        internal CfxValueIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxValueIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_is_read_only(@this);
        }
    }

    internal class CfxValueIsSameRemoteCall : RemoteCall {

        internal CfxValueIsSameRemoteCall()
            : base(RemoteCallId.CfxValueIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_is_same(@this, that);
        }
    }

    internal class CfxValueIsEqualRemoteCall : RemoteCall {

        internal CfxValueIsEqualRemoteCall()
            : base(RemoteCallId.CfxValueIsEqualRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_is_equal(@this, that);
        }
    }

    internal class CfxValueCopyRemoteCall : RemoteCall {

        internal CfxValueCopyRemoteCall()
            : base(RemoteCallId.CfxValueCopyRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_copy(@this);
        }
    }

    internal class CfxValueGetTypeRemoteCall : RemoteCall {

        internal CfxValueGetTypeRemoteCall()
            : base(RemoteCallId.CfxValueGetTypeRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_type(@this);
        }
    }

    internal class CfxValueGetBoolRemoteCall : RemoteCall {

        internal CfxValueGetBoolRemoteCall()
            : base(RemoteCallId.CfxValueGetBoolRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_get_bool(@this);
        }
    }

    internal class CfxValueGetIntRemoteCall : RemoteCall {

        internal CfxValueGetIntRemoteCall()
            : base(RemoteCallId.CfxValueGetIntRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_int(@this);
        }
    }

    internal class CfxValueGetDoubleRemoteCall : RemoteCall {

        internal CfxValueGetDoubleRemoteCall()
            : base(RemoteCallId.CfxValueGetDoubleRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_double(@this);
        }
    }

    internal class CfxValueGetStringRemoteCall : RemoteCall {

        internal CfxValueGetStringRemoteCall()
            : base(RemoteCallId.CfxValueGetStringRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Value.cfx_value_get_string(@this));
        }
    }

    internal class CfxValueGetBinaryRemoteCall : RemoteCall {

        internal CfxValueGetBinaryRemoteCall()
            : base(RemoteCallId.CfxValueGetBinaryRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_binary(@this);
        }
    }

    internal class CfxValueGetDictionaryRemoteCall : RemoteCall {

        internal CfxValueGetDictionaryRemoteCall()
            : base(RemoteCallId.CfxValueGetDictionaryRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_dictionary(@this);
        }
    }

    internal class CfxValueGetListRemoteCall : RemoteCall {

        internal CfxValueGetListRemoteCall()
            : base(RemoteCallId.CfxValueGetListRemoteCall) {}

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
            __retval = CfxApi.Value.cfx_value_get_list(@this);
        }
    }

    internal class CfxValueSetNullRemoteCall : RemoteCall {

        internal CfxValueSetNullRemoteCall()
            : base(RemoteCallId.CfxValueSetNullRemoteCall) {}

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
            __retval = 0 != CfxApi.Value.cfx_value_set_null(@this);
        }
    }

    internal class CfxValueSetBoolRemoteCall : RemoteCall {

        internal CfxValueSetBoolRemoteCall()
            : base(RemoteCallId.CfxValueSetBoolRemoteCall) {}

        internal IntPtr @this;
        internal bool value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_bool(@this, value ? 1 : 0);
        }
    }

    internal class CfxValueSetIntRemoteCall : RemoteCall {

        internal CfxValueSetIntRemoteCall()
            : base(RemoteCallId.CfxValueSetIntRemoteCall) {}

        internal IntPtr @this;
        internal int value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_int(@this, value);
        }
    }

    internal class CfxValueSetDoubleRemoteCall : RemoteCall {

        internal CfxValueSetDoubleRemoteCall()
            : base(RemoteCallId.CfxValueSetDoubleRemoteCall) {}

        internal IntPtr @this;
        internal double value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_double(@this, value);
        }
    }

    internal class CfxValueSetStringRemoteCall : RemoteCall {

        internal CfxValueSetStringRemoteCall()
            : base(RemoteCallId.CfxValueSetStringRemoteCall) {}

        internal IntPtr @this;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
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
            __retval = 0 != CfxApi.Value.cfx_value_set_string(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxValueSetBinaryRemoteCall : RemoteCall {

        internal CfxValueSetBinaryRemoteCall()
            : base(RemoteCallId.CfxValueSetBinaryRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_binary(@this, value);
        }
    }

    internal class CfxValueSetDictionaryRemoteCall : RemoteCall {

        internal CfxValueSetDictionaryRemoteCall()
            : base(RemoteCallId.CfxValueSetDictionaryRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_dictionary(@this, value);
        }
    }

    internal class CfxValueSetListRemoteCall : RemoteCall {

        internal CfxValueSetListRemoteCall()
            : base(RemoteCallId.CfxValueSetListRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Value.cfx_value_set_list(@this, value);
        }
    }

}
