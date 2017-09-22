// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure that supports the reading of zip archives via the zlib unzip API.
    /// The functions of this structure should only be called on the thread that
    /// creates the object.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
    /// </remarks>
    public class CfrZipReader : CfrBaseLibrary {

        internal static CfrZipReader Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrZipReader)weakCache.Get(remotePtr.ptr);
                if(cfrObj == null) {
                    cfrObj = new CfrZipReader(remotePtr);
                    weakCache.Add(remotePtr.ptr, cfrObj);
                }
                return cfrObj;
            }
        }


        /// <summary>
        /// Create a new CfrZipReader object. The returned object's functions can
        /// only be called from the thread that created the object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public static CfrZipReader Create(CfrStreamReader stream) {
            var call = new CfxZipReaderCreateRemoteCall();
            call.stream = CfrObject.Unwrap(stream).ptr;
            call.RequestExecution();
            return CfrZipReader.Wrap(new RemotePtr(call.__retval));
        }


        private CfrZipReader(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the name of the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public string FileName {
            get {
                var call = new CfxZipReaderGetFileNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the uncompressed size of the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public long FileSize {
            get {
                var call = new CfxZipReaderGetFileSizeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the last modified timestamp for the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public CfrTime FileLastModified {
            get {
                var call = new CfxZipReaderGetFileLastModifiedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                if(call.__retval == IntPtr.Zero) throw new OutOfMemoryException("Render process out of memory.");
                return CfrTime.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Moves the cursor to the first file in the archive. Returns true (1) if the
        /// cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToFirstFile() {
            var call = new CfxZipReaderMoveToFirstFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Moves the cursor to the next file in the archive. Returns true (1) if the
        /// cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToNextFile() {
            var call = new CfxZipReaderMoveToNextFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Moves the cursor to the specified file in the archive. If |caseSensitive|
        /// is true (1) then the search will be case sensitive. Returns true (1) if the
        /// cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToFile(string fileName, bool caseSensitive) {
            var call = new CfxZipReaderMoveToFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.fileName = fileName;
            call.caseSensitive = caseSensitive;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Closes the archive. This should be called directly to ensure that cleanup
        /// occurs on the correct thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool Close() {
            var call = new CfxZipReaderCloseRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Opens the file for reading of uncompressed data. A read password may
        /// optionally be specified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool OpenFile(string password) {
            var call = new CfxZipReaderOpenFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.password = password;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Closes the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool CloseFile() {
            var call = new CfxZipReaderCloseFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Read uncompressed file contents into the specified buffer. Returns &lt; 0 if
        /// an error occurred, 0 if at the end of file, or the number of bytes read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public int ReadFile(RemotePtr buffer, ulong bufferSize) {
            var call = new CfxZipReaderReadFileRemoteCall();
            call.@this = RemotePtr.ptr;
            call.buffer = buffer.ptr;
            call.bufferSize = bufferSize;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the current offset in the uncompressed file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public long Tell() {
            var call = new CfxZipReaderTellRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if at end of the file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool Eof() {
            var call = new CfxZipReaderEofRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
            return call.__retval;
        }
    }
}
