// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxListValueCreateRemoteCall : RemoteCall {

        internal CfxListValueCreateRemoteCall()
            : base(RemoteCallId.CfxListValueCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.ListValue.cfx_list_value_create();
        }
    }

    internal class CfxListValueIsValidRemoteCall : RemoteCall {

        internal CfxListValueIsValidRemoteCall()
            : base(RemoteCallId.CfxListValueIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_is_valid(@this);
        }
    }

    internal class CfxListValueIsOwnedRemoteCall : RemoteCall {

        internal CfxListValueIsOwnedRemoteCall()
            : base(RemoteCallId.CfxListValueIsOwnedRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_is_owned(@this);
        }
    }

    internal class CfxListValueIsReadOnlyRemoteCall : RemoteCall {

        internal CfxListValueIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxListValueIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_is_read_only(@this);
        }
    }

    internal class CfxListValueIsSameRemoteCall : RemoteCall {

        internal CfxListValueIsSameRemoteCall()
            : base(RemoteCallId.CfxListValueIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_is_same(@this, that);
        }
    }

    internal class CfxListValueIsEqualRemoteCall : RemoteCall {

        internal CfxListValueIsEqualRemoteCall()
            : base(RemoteCallId.CfxListValueIsEqualRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_is_equal(@this, that);
        }
    }

    internal class CfxListValueCopyRemoteCall : RemoteCall {

        internal CfxListValueCopyRemoteCall()
            : base(RemoteCallId.CfxListValueCopyRemoteCall) {}

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
            __retval = CfxApi.ListValue.cfx_list_value_copy(@this);
        }
    }

    internal class CfxListValueSetSizeRemoteCall : RemoteCall {

        internal CfxListValueSetSizeRemoteCall()
            : base(RemoteCallId.CfxListValueSetSizeRemoteCall) {}

        internal IntPtr @this;
        internal ulong size;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(size);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out size);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_size(@this, (UIntPtr)size);
        }
    }

    internal class CfxListValueGetSizeRemoteCall : RemoteCall {

        internal CfxListValueGetSizeRemoteCall()
            : base(RemoteCallId.CfxListValueGetSizeRemoteCall) {}

        internal IntPtr @this;
        internal ulong __retval;

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
            __retval = (ulong)CfxApi.ListValue.cfx_list_value_get_size(@this);
        }
    }

    internal class CfxListValueClearRemoteCall : RemoteCall {

        internal CfxListValueClearRemoteCall()
            : base(RemoteCallId.CfxListValueClearRemoteCall) {}

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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_clear(@this);
        }
    }

    internal class CfxListValueRemoveRemoteCall : RemoteCall {

        internal CfxListValueRemoveRemoteCall()
            : base(RemoteCallId.CfxListValueRemoveRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_remove(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetTypeRemoteCall : RemoteCall {

        internal CfxListValueGetTypeRemoteCall()
            : base(RemoteCallId.CfxListValueGetTypeRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal int __retval;

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
            __retval = CfxApi.ListValue.cfx_list_value_get_type(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetValueRemoteCall : RemoteCall {

        internal CfxListValueGetValueRemoteCall()
            : base(RemoteCallId.CfxListValueGetValueRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = CfxApi.ListValue.cfx_list_value_get_value(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetBoolRemoteCall : RemoteCall {

        internal CfxListValueGetBoolRemoteCall()
            : base(RemoteCallId.CfxListValueGetBoolRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_get_bool(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetIntRemoteCall : RemoteCall {

        internal CfxListValueGetIntRemoteCall()
            : base(RemoteCallId.CfxListValueGetIntRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal int __retval;

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
            __retval = CfxApi.ListValue.cfx_list_value_get_int(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetDoubleRemoteCall : RemoteCall {

        internal CfxListValueGetDoubleRemoteCall()
            : base(RemoteCallId.CfxListValueGetDoubleRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal double __retval;

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
            __retval = CfxApi.ListValue.cfx_list_value_get_double(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetStringRemoteCall : RemoteCall {

        internal CfxListValueGetStringRemoteCall()
            : base(RemoteCallId.CfxListValueGetStringRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.ListValue.cfx_list_value_get_string(@this, (UIntPtr)index));
        }
    }

    internal class CfxListValueGetBinaryRemoteCall : RemoteCall {

        internal CfxListValueGetBinaryRemoteCall()
            : base(RemoteCallId.CfxListValueGetBinaryRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = CfxApi.ListValue.cfx_list_value_get_binary(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetDictionaryRemoteCall : RemoteCall {

        internal CfxListValueGetDictionaryRemoteCall()
            : base(RemoteCallId.CfxListValueGetDictionaryRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = CfxApi.ListValue.cfx_list_value_get_dictionary(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueGetListRemoteCall : RemoteCall {

        internal CfxListValueGetListRemoteCall()
            : base(RemoteCallId.CfxListValueGetListRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = CfxApi.ListValue.cfx_list_value_get_list(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueSetValueRemoteCall : RemoteCall {

        internal CfxListValueSetValueRemoteCall()
            : base(RemoteCallId.CfxListValueSetValueRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_value(@this, (UIntPtr)index, value);
        }
    }

    internal class CfxListValueSetNullRemoteCall : RemoteCall {

        internal CfxListValueSetNullRemoteCall()
            : base(RemoteCallId.CfxListValueSetNullRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_null(@this, (UIntPtr)index);
        }
    }

    internal class CfxListValueSetBoolRemoteCall : RemoteCall {

        internal CfxListValueSetBoolRemoteCall()
            : base(RemoteCallId.CfxListValueSetBoolRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal bool value;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_bool(@this, (UIntPtr)index, value ? 1 : 0);
        }
    }

    internal class CfxListValueSetIntRemoteCall : RemoteCall {

        internal CfxListValueSetIntRemoteCall()
            : base(RemoteCallId.CfxListValueSetIntRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal int value;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_int(@this, (UIntPtr)index, value);
        }
    }

    internal class CfxListValueSetDoubleRemoteCall : RemoteCall {

        internal CfxListValueSetDoubleRemoteCall()
            : base(RemoteCallId.CfxListValueSetDoubleRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal double value;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_double(@this, (UIntPtr)index, value);
        }
    }

    internal class CfxListValueSetStringRemoteCall : RemoteCall {

        internal CfxListValueSetStringRemoteCall()
            : base(RemoteCallId.CfxListValueSetStringRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
        internal string value;
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
            var value_pinned = new PinnedString(value);
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_string(@this, (UIntPtr)index, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxListValueSetBinaryRemoteCall : RemoteCall {

        internal CfxListValueSetBinaryRemoteCall()
            : base(RemoteCallId.CfxListValueSetBinaryRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_binary(@this, (UIntPtr)index, value);
        }
    }

    internal class CfxListValueSetDictionaryRemoteCall : RemoteCall {

        internal CfxListValueSetDictionaryRemoteCall()
            : base(RemoteCallId.CfxListValueSetDictionaryRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_dictionary(@this, (UIntPtr)index, value);
        }
    }

    internal class CfxListValueSetListRemoteCall : RemoteCall {

        internal CfxListValueSetListRemoteCall()
            : base(RemoteCallId.CfxListValueSetListRemoteCall) {}

        internal IntPtr @this;
        internal ulong index;
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
            __retval = 0 != CfxApi.ListValue.cfx_list_value_set_list(@this, (UIntPtr)index, value);
        }
    }

}
