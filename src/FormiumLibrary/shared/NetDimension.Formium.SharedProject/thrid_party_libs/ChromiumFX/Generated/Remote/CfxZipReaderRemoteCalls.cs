// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxZipReaderCreateRemoteCall : RemoteCall {

        internal CfxZipReaderCreateRemoteCall()
            : base(RemoteCallId.CfxZipReaderCreateRemoteCall) {}

        internal IntPtr stream;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(stream);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out stream);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.ZipReader.cfx_zip_reader_create(stream);
        }
    }

    internal class CfxZipReaderMoveToFirstFileRemoteCall : RemoteCall {

        internal CfxZipReaderMoveToFirstFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderMoveToFirstFileRemoteCall) {}

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
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_move_to_first_file(@this);
        }
    }

    internal class CfxZipReaderMoveToNextFileRemoteCall : RemoteCall {

        internal CfxZipReaderMoveToNextFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderMoveToNextFileRemoteCall) {}

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
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_move_to_next_file(@this);
        }
    }

    internal class CfxZipReaderMoveToFileRemoteCall : RemoteCall {

        internal CfxZipReaderMoveToFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderMoveToFileRemoteCall) {}

        internal IntPtr @this;
        internal string fileName;
        internal bool caseSensitive;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(fileName);
            h.Write(caseSensitive);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out fileName);
            h.Read(out caseSensitive);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var fileName_pinned = new PinnedString(fileName);
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_move_to_file(@this, fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length, caseSensitive ? 1 : 0);
            fileName_pinned.Obj.Free();
        }
    }

    internal class CfxZipReaderCloseRemoteCall : RemoteCall {

        internal CfxZipReaderCloseRemoteCall()
            : base(RemoteCallId.CfxZipReaderCloseRemoteCall) {}

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
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_close(@this);
        }
    }

    internal class CfxZipReaderGetFileNameRemoteCall : RemoteCall {

        internal CfxZipReaderGetFileNameRemoteCall()
            : base(RemoteCallId.CfxZipReaderGetFileNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.ZipReader.cfx_zip_reader_get_file_name(@this));
        }
    }

    internal class CfxZipReaderGetFileSizeRemoteCall : RemoteCall {

        internal CfxZipReaderGetFileSizeRemoteCall()
            : base(RemoteCallId.CfxZipReaderGetFileSizeRemoteCall) {}

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
            __retval = CfxApi.ZipReader.cfx_zip_reader_get_file_size(@this);
        }
    }

    internal class CfxZipReaderGetFileLastModifiedRemoteCall : RemoteCall {

        internal CfxZipReaderGetFileLastModifiedRemoteCall()
            : base(RemoteCallId.CfxZipReaderGetFileLastModifiedRemoteCall) {}

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
            __retval = CfxApi.ZipReader.cfx_zip_reader_get_file_last_modified(@this);
        }
    }

    internal class CfxZipReaderOpenFileRemoteCall : RemoteCall {

        internal CfxZipReaderOpenFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderOpenFileRemoteCall) {}

        internal IntPtr @this;
        internal string password;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(password);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out password);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var password_pinned = new PinnedString(password);
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_open_file(@this, password_pinned.Obj.PinnedPtr, password_pinned.Length);
            password_pinned.Obj.Free();
        }
    }

    internal class CfxZipReaderCloseFileRemoteCall : RemoteCall {

        internal CfxZipReaderCloseFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderCloseFileRemoteCall) {}

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
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_close_file(@this);
        }
    }

    internal class CfxZipReaderReadFileRemoteCall : RemoteCall {

        internal CfxZipReaderReadFileRemoteCall()
            : base(RemoteCallId.CfxZipReaderReadFileRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr buffer;
        internal ulong bufferSize;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(buffer);
            h.Write(bufferSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out buffer);
            h.Read(out bufferSize);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.ZipReader.cfx_zip_reader_read_file(@this, buffer, (UIntPtr)bufferSize);
        }
    }

    internal class CfxZipReaderTellRemoteCall : RemoteCall {

        internal CfxZipReaderTellRemoteCall()
            : base(RemoteCallId.CfxZipReaderTellRemoteCall) {}

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
            __retval = CfxApi.ZipReader.cfx_zip_reader_tell(@this);
        }
    }

    internal class CfxZipReaderEofRemoteCall : RemoteCall {

        internal CfxZipReaderEofRemoteCall()
            : base(RemoteCallId.CfxZipReaderEofRemoteCall) {}

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
            __retval = 0 != CfxApi.ZipReader.cfx_zip_reader_eof(@this);
        }
    }

}
