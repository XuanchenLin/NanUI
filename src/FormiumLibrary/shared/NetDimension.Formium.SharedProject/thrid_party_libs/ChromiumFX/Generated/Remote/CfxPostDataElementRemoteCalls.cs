// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxPostDataElementCreateRemoteCall : RemoteCall {

        internal CfxPostDataElementCreateRemoteCall()
            : base(RemoteCallId.CfxPostDataElementCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.PostDataElement.cfx_post_data_element_create();
        }
    }

    internal class CfxPostDataElementIsReadOnlyRemoteCall : RemoteCall {

        internal CfxPostDataElementIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxPostDataElementIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.PostDataElement.cfx_post_data_element_is_read_only(@this);
        }
    }

    internal class CfxPostDataElementSetToEmptyRemoteCall : RemoteCall {

        internal CfxPostDataElementSetToEmptyRemoteCall()
            : base(RemoteCallId.CfxPostDataElementSetToEmptyRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.PostDataElement.cfx_post_data_element_set_to_empty(@this);
        }
    }

    internal class CfxPostDataElementSetToFileRemoteCall : RemoteCall {

        internal CfxPostDataElementSetToFileRemoteCall()
            : base(RemoteCallId.CfxPostDataElementSetToFileRemoteCall) {}

        internal IntPtr @this;
        internal string fileName;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(fileName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out fileName);
        }

        protected override void RemoteProcedure() {
            var fileName_pinned = new PinnedString(fileName);
            CfxApi.PostDataElement.cfx_post_data_element_set_to_file(@this, fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length);
            fileName_pinned.Obj.Free();
        }
    }

    internal class CfxPostDataElementSetToBytesRemoteCall : RemoteCall {

        internal CfxPostDataElementSetToBytesRemoteCall()
            : base(RemoteCallId.CfxPostDataElementSetToBytesRemoteCall) {}

        internal IntPtr @this;
        internal ulong size;
        internal IntPtr bytes;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(size);
            h.Write(bytes);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out size);
            h.Read(out bytes);
        }

        protected override void RemoteProcedure() {
            CfxApi.PostDataElement.cfx_post_data_element_set_to_bytes(@this, (UIntPtr)size, bytes);
        }
    }

    internal class CfxPostDataElementGetTypeRemoteCall : RemoteCall {

        internal CfxPostDataElementGetTypeRemoteCall()
            : base(RemoteCallId.CfxPostDataElementGetTypeRemoteCall) {}

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
            __retval = CfxApi.PostDataElement.cfx_post_data_element_get_type(@this);
        }
    }

    internal class CfxPostDataElementGetFileRemoteCall : RemoteCall {

        internal CfxPostDataElementGetFileRemoteCall()
            : base(RemoteCallId.CfxPostDataElementGetFileRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.PostDataElement.cfx_post_data_element_get_file(@this));
        }
    }

    internal class CfxPostDataElementGetBytesCountRemoteCall : RemoteCall {

        internal CfxPostDataElementGetBytesCountRemoteCall()
            : base(RemoteCallId.CfxPostDataElementGetBytesCountRemoteCall) {}

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
            __retval = (ulong)CfxApi.PostDataElement.cfx_post_data_element_get_bytes_count(@this);
        }
    }

    internal class CfxPostDataElementGetBytesRemoteCall : RemoteCall {

        internal CfxPostDataElementGetBytesRemoteCall()
            : base(RemoteCallId.CfxPostDataElementGetBytesRemoteCall) {}

        internal IntPtr @this;
        internal ulong size;
        internal IntPtr bytes;
        internal ulong __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(size);
            h.Write(bytes);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out size);
            h.Read(out bytes);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = (ulong)CfxApi.PostDataElement.cfx_post_data_element_get_bytes(@this, (UIntPtr)size, bytes);
        }
    }

}
