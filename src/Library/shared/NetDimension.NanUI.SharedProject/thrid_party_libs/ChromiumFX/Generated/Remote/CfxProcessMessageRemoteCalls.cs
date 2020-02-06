// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxProcessMessageCreateRemoteCall : RemoteCall {

        internal CfxProcessMessageCreateRemoteCall()
            : base(RemoteCallId.CfxProcessMessageCreateRemoteCall) {}

        internal string name;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = CfxApi.ProcessMessage.cfx_process_message_create(name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
        }
    }

    internal class CfxProcessMessageIsValidRemoteCall : RemoteCall {

        internal CfxProcessMessageIsValidRemoteCall()
            : base(RemoteCallId.CfxProcessMessageIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.ProcessMessage.cfx_process_message_is_valid(@this);
        }
    }

    internal class CfxProcessMessageIsReadOnlyRemoteCall : RemoteCall {

        internal CfxProcessMessageIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxProcessMessageIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.ProcessMessage.cfx_process_message_is_read_only(@this);
        }
    }

    internal class CfxProcessMessageCopyRemoteCall : RemoteCall {

        internal CfxProcessMessageCopyRemoteCall()
            : base(RemoteCallId.CfxProcessMessageCopyRemoteCall) {}

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
            __retval = CfxApi.ProcessMessage.cfx_process_message_copy(@this);
        }
    }

    internal class CfxProcessMessageGetNameRemoteCall : RemoteCall {

        internal CfxProcessMessageGetNameRemoteCall()
            : base(RemoteCallId.CfxProcessMessageGetNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.ProcessMessage.cfx_process_message_get_name(@this));
        }
    }

    internal class CfxProcessMessageGetArgumentListRemoteCall : RemoteCall {

        internal CfxProcessMessageGetArgumentListRemoteCall()
            : base(RemoteCallId.CfxProcessMessageGetArgumentListRemoteCall) {}

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
            __retval = CfxApi.ProcessMessage.cfx_process_message_get_argument_list(@this);
        }
    }

}
