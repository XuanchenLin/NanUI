// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to read data from a stream. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfrStreamReader : CfrBaseLibrary {

        internal static CfrStreamReader Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrStreamReader)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrStreamReader(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrStreamReader object from a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfrStreamReader CreateForFile(string fileName) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxStreamReaderCreateForFileRemoteCall();
            call.fileName = fileName;
            call.RequestExecution(connection);
            return CfrStreamReader.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrStreamReader object from data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfrStreamReader CreateForData(RemotePtr data, ulong size) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxStreamReaderCreateForDataRemoteCall();
            if(data.connection != connection) throw new ArgumentException("Render process connection mismatch.", "data");
            call.data = data.ptr;
            call.size = size;
            call.RequestExecution(connection);
            return CfrStreamReader.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrStreamReader object from a custom handler.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfrStreamReader CreateForHandler(CfrReadHandler handler) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxStreamReaderCreateForHandlerRemoteCall();
            if(!CfrObject.CheckConnection(handler, connection)) throw new ArgumentException("Render process connection mismatch.", "handler");
            call.handler = CfrObject.Unwrap(handler).ptr;
            call.RequestExecution(connection);
            return CfrStreamReader.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrStreamReader(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public ulong Read(RemotePtr ptr, ulong size, ulong n) {
            var connection = RemotePtr.connection;
            var call = new CfxStreamReaderReadRemoteCall();
            call.@this = RemotePtr.ptr;
            if(ptr.connection != connection) throw new ArgumentException("Render process connection mismatch.", "ptr");
            call.ptr = ptr.ptr;
            call.size = size;
            call.n = n;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Seek to the specified offset position. |whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Returns zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public int Seek(long offset, int whence) {
            var connection = RemotePtr.connection;
            var call = new CfxStreamReaderSeekRemoteCall();
            call.@this = RemotePtr.ptr;
            call.offset = offset;
            call.whence = whence;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public long Tell() {
            var connection = RemotePtr.connection;
            var call = new CfxStreamReaderTellRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public int Eof() {
            var connection = RemotePtr.connection;
            var call = new CfxStreamReaderEofRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this reader performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the reader from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public bool MayBlock() {
            var connection = RemotePtr.connection;
            var call = new CfxStreamReaderMayBlockRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
