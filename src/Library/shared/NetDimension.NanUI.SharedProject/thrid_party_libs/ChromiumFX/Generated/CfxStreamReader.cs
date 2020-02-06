// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to read data from a stream. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfxStreamReader : CfxBaseLibrary {

        internal static CfxStreamReader Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxStreamReader)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxStreamReader(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxStreamReader(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxStreamReader object from a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfxStreamReader CreateForFile(string fileName) {
            var fileName_pinned = new PinnedString(fileName);
            var __retval = CfxApi.StreamReader.cfx_stream_reader_create_for_file(fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length);
            fileName_pinned.Obj.Free();
            return CfxStreamReader.Wrap(__retval);
        }

        /// <summary>
        /// Create a new CfxStreamReader object from data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfxStreamReader CreateForData(IntPtr data, ulong size) {
            return CfxStreamReader.Wrap(CfxApi.StreamReader.cfx_stream_reader_create_for_data(data, (UIntPtr)size));
        }

        /// <summary>
        /// Create a new CfxStreamReader object from a custom handler.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public static CfxStreamReader CreateForHandler(CfxReadHandler handler) {
            return CfxStreamReader.Wrap(CfxApi.StreamReader.cfx_stream_reader_create_for_handler(CfxReadHandler.Unwrap(handler)));
        }

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public ulong Read(IntPtr ptr, ulong size, ulong n) {
            return (ulong)CfxApi.StreamReader.cfx_stream_reader_read(NativePtr, ptr, (UIntPtr)size, (UIntPtr)n);
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
            return CfxApi.StreamReader.cfx_stream_reader_seek(NativePtr, offset, whence);
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public long Tell() {
            return CfxApi.StreamReader.cfx_stream_reader_tell(NativePtr);
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public int Eof() {
            return CfxApi.StreamReader.cfx_stream_reader_eof(NativePtr);
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
            return 0 != CfxApi.StreamReader.cfx_stream_reader_may_block(NativePtr);
        }
    }
}
