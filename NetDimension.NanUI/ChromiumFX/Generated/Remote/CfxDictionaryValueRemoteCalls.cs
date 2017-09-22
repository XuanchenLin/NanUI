// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxDictionaryValueCreateRemoteCall : RemoteCall {

        internal CfxDictionaryValueCreateRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_create();
        }
    }

    internal class CfxDictionaryValueIsValidRemoteCall : RemoteCall {

        internal CfxDictionaryValueIsValidRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_is_valid(@this);
        }
    }

    internal class CfxDictionaryValueIsOwnedRemoteCall : RemoteCall {

        internal CfxDictionaryValueIsOwnedRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueIsOwnedRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_is_owned(@this);
        }
    }

    internal class CfxDictionaryValueIsReadOnlyRemoteCall : RemoteCall {

        internal CfxDictionaryValueIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_is_read_only(@this);
        }
    }

    internal class CfxDictionaryValueIsSameRemoteCall : RemoteCall {

        internal CfxDictionaryValueIsSameRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_is_same(@this, that);
        }
    }

    internal class CfxDictionaryValueIsEqualRemoteCall : RemoteCall {

        internal CfxDictionaryValueIsEqualRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueIsEqualRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_is_equal(@this, that);
        }
    }

    internal class CfxDictionaryValueCopyRemoteCall : RemoteCall {

        internal CfxDictionaryValueCopyRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueCopyRemoteCall) {}

        internal IntPtr @this;
        internal bool excludeEmptyChildren;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(excludeEmptyChildren);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out excludeEmptyChildren);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_copy(@this, excludeEmptyChildren ? 1 : 0);
        }
    }

    internal class CfxDictionaryValueGetSizeRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetSizeRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetSizeRemoteCall) {}

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
            __retval = (ulong)CfxApi.DictionaryValue.cfx_dictionary_value_get_size(@this);
        }
    }

    internal class CfxDictionaryValueClearRemoteCall : RemoteCall {

        internal CfxDictionaryValueClearRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueClearRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_clear(@this);
        }
    }

    internal class CfxDictionaryValueHasKeyRemoteCall : RemoteCall {

        internal CfxDictionaryValueHasKeyRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueHasKeyRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_has_key(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetKeysRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetKeysRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetKeysRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_get_keys(@this, keys_unwrapped);
            StringFunctions.FreePinnedStrings(keys_handles);
            StringFunctions.CfxStringListCopyToManaged(keys_unwrapped, keys);
            CfxApi.Runtime.cfx_string_list_free(keys_unwrapped);
        }
    }

    internal class CfxDictionaryValueRemoveRemoteCall : RemoteCall {

        internal CfxDictionaryValueRemoveRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueRemoveRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_remove(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetTypeRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetTypeRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetTypeRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal int __retval;

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_type(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetValueRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetValueRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetValueRemoteCall) {}

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_value(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetBoolRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetBoolRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetBoolRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_get_bool(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetIntRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetIntRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetIntRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal int __retval;

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_int(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetDoubleRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetDoubleRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetDoubleRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal double __retval;

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_double(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetStringRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetStringRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetStringRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DictionaryValue.cfx_dictionary_value_get_string(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length));
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetBinaryRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetBinaryRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetBinaryRemoteCall) {}

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_binary(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetDictionaryRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetDictionaryRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetDictionaryRemoteCall) {}

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_dictionary(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueGetListRemoteCall : RemoteCall {

        internal CfxDictionaryValueGetListRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueGetListRemoteCall) {}

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
            __retval = CfxApi.DictionaryValue.cfx_dictionary_value_get_list(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetValueRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetValueRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetValueRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_value(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetNullRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetNullRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetNullRemoteCall) {}

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
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_null(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetBoolRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetBoolRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetBoolRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal bool value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_bool(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value ? 1 : 0);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetIntRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetIntRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetIntRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal int value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_int(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetDoubleRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetDoubleRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetDoubleRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal double value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_double(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetStringRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetStringRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetStringRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            var value_pinned = new PinnedString(value);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_string(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            key_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetBinaryRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetBinaryRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetBinaryRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_binary(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetDictionaryRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetDictionaryRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetDictionaryRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_dictionary(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

    internal class CfxDictionaryValueSetListRemoteCall : RemoteCall {

        internal CfxDictionaryValueSetListRemoteCall()
            : base(RemoteCallId.CfxDictionaryValueSetListRemoteCall) {}

        internal IntPtr @this;
        internal string key;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(key);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out key);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var key_pinned = new PinnedString(key);
            __retval = 0 != CfxApi.DictionaryValue.cfx_dictionary_value_set_list(@this, key_pinned.Obj.PinnedPtr, key_pinned.Length, value);
            key_pinned.Obj.Free();
        }
    }

}
