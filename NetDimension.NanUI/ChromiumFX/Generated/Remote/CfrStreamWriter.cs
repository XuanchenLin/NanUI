// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to write data to a stream. The functions of this structure may
    /// be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfrStreamWriter : CfrBaseLibrary {

        internal static CfrStreamWriter Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrStreamWriter)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrStreamWriter(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrStreamWriter object for a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfrStreamWriter CreateForFile(string fileName) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxStreamWriterCreateForFileRemoteCall();
            call.fileName = fileName;
            call.RequestExecution(connection);
            return CfrStreamWriter.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Create a new CfrStreamWriter object for a custom handler.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfrStreamWriter CreateForHandler(CfrWriteHandler handler) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxStreamWriterCreateForHandlerRemoteCall();
            if(!CfrObject.CheckConnection(handler, connection)) throw new ArgumentException("Render process connection mismatch.", "handler");
            call.handler = CfrObject.Unwrap(handler).ptr;
            call.RequestExecution(connection);
            return CfrStreamWriter.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrStreamWriter(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public ulong Write(RemotePtr ptr, ulong size, ulong n) {
            var connection = RemotePtr.connection;
            var call = new CfxStreamWriterWriteRemoteCall();
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
            var call = new CfxStreamWriterSeekRemoteCall();
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
            var call = new CfxStreamWriterTellRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Flush the stream.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public int Flush() {
            var connection = RemotePtr.connection;
            var call = new CfxStreamWriterFlushRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this writer performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the writer from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public bool MayBlock() {
            var connection = RemotePtr.connection;
            var call = new CfxStreamWriterMayBlockRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
