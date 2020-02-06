// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxBinaryValueCreateRemoteCall : RemoteCall {

        internal CfxBinaryValueCreateRemoteCall()
            : base(RemoteCallId.CfxBinaryValueCreateRemoteCall) {}

        internal IntPtr data;
        internal ulong dataSize;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(data);
            h.Write(dataSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out data);
            h.Read(out dataSize);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.BinaryValue.cfx_binary_value_create(data, (UIntPtr)dataSize);
        }
    }

    internal class CfxBinaryValueIsValidRemoteCall : RemoteCall {

        internal CfxBinaryValueIsValidRemoteCall()
            : base(RemoteCallId.CfxBinaryValueIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.BinaryValue.cfx_binary_value_is_valid(@this);
        }
    }

    internal class CfxBinaryValueIsOwnedRemoteCall : RemoteCall {

        internal CfxBinaryValueIsOwnedRemoteCall()
            : base(RemoteCallId.CfxBinaryValueIsOwnedRemoteCall) {}

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
            __retval = 0 != CfxApi.BinaryValue.cfx_binary_value_is_owned(@this);
        }
    }

    internal class CfxBinaryValueIsSameRemoteCall : RemoteCall {

        internal CfxBinaryValueIsSameRemoteCall()
            : base(RemoteCallId.CfxBinaryValueIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.BinaryValue.cfx_binary_value_is_same(@this, that);
        }
    }

    internal class CfxBinaryValueIsEqualRemoteCall : RemoteCall {

        internal CfxBinaryValueIsEqualRemoteCall()
            : base(RemoteCallId.CfxBinaryValueIsEqualRemoteCall) {}

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
            __retval = 0 != CfxApi.BinaryValue.cfx_binary_value_is_equal(@this, that);
        }
    }

    internal class CfxBinaryValueCopyRemoteCall : RemoteCall {

        internal CfxBinaryValueCopyRemoteCall()
            : base(RemoteCallId.CfxBinaryValueCopyRemoteCall) {}

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
            __retval = CfxApi.BinaryValue.cfx_binary_value_copy(@this);
        }
    }

    internal class CfxBinaryValueGetSizeRemoteCall : RemoteCall {

        internal CfxBinaryValueGetSizeRemoteCall()
            : base(RemoteCallId.CfxBinaryValueGetSizeRemoteCall) {}

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
            __retval = (ulong)CfxApi.BinaryValue.cfx_binary_value_get_size(@this);
        }
    }

    internal class CfxBinaryValueGetDataRemoteCall : RemoteCall {

        internal CfxBinaryValueGetDataRemoteCall()
            : base(RemoteCallId.CfxBinaryValueGetDataRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr buffer;
        internal ulong bufferSize;
        internal ulong dataOffset;
        internal ulong __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(buffer);
            h.Write(bufferSize);
            h.Write(dataOffset);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out buffer);
            h.Read(out bufferSize);
            h.Read(out dataOffset);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = (ulong)CfxApi.BinaryValue.cfx_binary_value_get_data(@this, buffer, (UIntPtr)bufferSize, (UIntPtr)dataOffset);
        }
    }

}
