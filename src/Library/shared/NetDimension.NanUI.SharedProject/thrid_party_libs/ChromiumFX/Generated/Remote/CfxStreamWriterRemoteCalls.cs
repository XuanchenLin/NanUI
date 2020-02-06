// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxStreamWriterCreateForFileRemoteCall : RemoteCall {

        internal CfxStreamWriterCreateForFileRemoteCall()
            : base(RemoteCallId.CfxStreamWriterCreateForFileRemoteCall) {}

        internal string fileName;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(fileName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out fileName);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var fileName_pinned = new PinnedString(fileName);
            __retval = CfxApi.StreamWriter.cfx_stream_writer_create_for_file(fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length);
            fileName_pinned.Obj.Free();
        }
    }

    internal class CfxStreamWriterCreateForHandlerRemoteCall : RemoteCall {

        internal CfxStreamWriterCreateForHandlerRemoteCall()
            : base(RemoteCallId.CfxStreamWriterCreateForHandlerRemoteCall) {}

        internal IntPtr handler;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(handler);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out handler);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.StreamWriter.cfx_stream_writer_create_for_handler(handler);
        }
    }

    internal class CfxStreamWriterWriteRemoteCall : RemoteCall {

        internal CfxStreamWriterWriteRemoteCall()
            : base(RemoteCallId.CfxStreamWriterWriteRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr ptr;
        internal ulong size;
        internal ulong n;
        internal ulong __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(ptr);
            h.Write(size);
            h.Write(n);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out ptr);
            h.Read(out size);
            h.Read(out n);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = (ulong)CfxApi.StreamWriter.cfx_stream_writer_write(@this, ptr, (UIntPtr)size, (UIntPtr)n);
        }
    }

    internal class CfxStreamWriterSeekRemoteCall : RemoteCall {

        internal CfxStreamWriterSeekRemoteCall()
            : base(RemoteCallId.CfxStreamWriterSeekRemoteCall) {}

        internal IntPtr @this;
        internal long offset;
        internal int whence;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(offset);
            h.Write(whence);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out offset);
            h.Read(out whence);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.StreamWriter.cfx_stream_writer_seek(@this, offset, whence);
        }
    }

    internal class CfxStreamWriterTellRemoteCall : RemoteCall {

        internal CfxStreamWriterTellRemoteCall()
            : base(RemoteCallId.CfxStreamWriterTellRemoteCall) {}

        internal IntPtr @this;
        internal long __retval;

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
            __retval = CfxApi.StreamWriter.cfx_stream_writer_tell(@this);
        }
    }

    internal class CfxStreamWriterFlushRemoteCall : RemoteCall {

        internal CfxStreamWriterFlushRemoteCall()
            : base(RemoteCallId.CfxStreamWriterFlushRemoteCall) {}

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
            __retval = CfxApi.StreamWriter.cfx_stream_writer_flush(@this);
        }
    }

    internal class CfxStreamWriterMayBlockRemoteCall : RemoteCall {

        internal CfxStreamWriterMayBlockRemoteCall()
            : base(RemoteCallId.CfxStreamWriterMayBlockRemoteCall) {}

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
            __retval = 0 != CfxApi.StreamWriter.cfx_stream_writer_may_block(@this);
        }
    }

}
