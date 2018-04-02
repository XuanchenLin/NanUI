// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to write data to a stream. The functions of this structure may
    /// be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfxStreamWriter : CfxBaseLibrary {

        internal static CfxStreamWriter Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxStreamWriter)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxStreamWriter(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxStreamWriter(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxStreamWriter object for a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfxStreamWriter CreateForFile(string fileName) {
            var fileName_pinned = new PinnedString(fileName);
            var __retval = CfxApi.StreamWriter.cfx_stream_writer_create_for_file(fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length);
            fileName_pinned.Obj.Free();
            return CfxStreamWriter.Wrap(__retval);
        }

        /// <summary>
        /// Create a new CfxStreamWriter object for a custom handler.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfxStreamWriter CreateForHandler(CfxWriteHandler handler) {
            return CfxStreamWriter.Wrap(CfxApi.StreamWriter.cfx_stream_writer_create_for_handler(CfxWriteHandler.Unwrap(handler)));
        }

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public ulong Write(IntPtr ptr, ulong size, ulong n) {
            return (ulong)CfxApi.StreamWriter.cfx_stream_writer_write(NativePtr, ptr, (UIntPtr)size, (UIntPtr)n);
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
            return CfxApi.StreamWriter.cfx_stream_writer_seek(NativePtr, offset, whence);
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public long Tell() {
            return CfxApi.StreamWriter.cfx_stream_writer_tell(NativePtr);
        }

        /// <summary>
        /// Flush the stream.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public int Flush() {
            return CfxApi.StreamWriter.cfx_stream_writer_flush(NativePtr);
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
            return 0 != CfxApi.StreamWriter.cfx_stream_writer_may_block(NativePtr);
        }
    }
}
