// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure that supports the reading of zip archives via the zlib unzip API.
    /// The functions of this structure should only be called on the thread that
    /// creates the object.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
    /// </remarks>
    public partial class CfxZipReader : CfxBaseLibrary {

        internal static CfxZipReader Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxZipReader)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxZipReader(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxZipReader(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxZipReader object. The returned object's functions can
        /// only be called from the thread that created the object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public static CfxZipReader Create(CfxStreamReader stream) {
            return CfxZipReader.Wrap(CfxApi.ZipReader.cfx_zip_reader_create(CfxStreamReader.Unwrap(stream)));
        }

        /// <summary>
        /// Returns the name of the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public string FileName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.ZipReader.cfx_zip_reader_get_file_name(NativePtr));
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
                return CfxApi.ZipReader.cfx_zip_reader_get_file_size(NativePtr);
            }
        }

        /// <summary>
        /// Returns the last modified timestamp for the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public CfxTime FileLastModified {
            get {
                var __retval = CfxApi.ZipReader.cfx_zip_reader_get_file_last_modified(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxTime.WrapOwned(__retval);
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
            return 0 != CfxApi.ZipReader.cfx_zip_reader_move_to_first_file(NativePtr);
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
            return 0 != CfxApi.ZipReader.cfx_zip_reader_move_to_next_file(NativePtr);
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
            var fileName_pinned = new PinnedString(fileName);
            var __retval = CfxApi.ZipReader.cfx_zip_reader_move_to_file(NativePtr, fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length, caseSensitive ? 1 : 0);
            fileName_pinned.Obj.Free();
            return 0 != __retval;
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
            return 0 != CfxApi.ZipReader.cfx_zip_reader_close(NativePtr);
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
            var password_pinned = new PinnedString(password);
            var __retval = CfxApi.ZipReader.cfx_zip_reader_open_file(NativePtr, password_pinned.Obj.PinnedPtr, password_pinned.Length);
            password_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Closes the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool CloseFile() {
            return 0 != CfxApi.ZipReader.cfx_zip_reader_close_file(NativePtr);
        }

        /// <summary>
        /// Read uncompressed file contents into the specified buffer. Returns &lt; 0 if
        /// an error occurred, 0 if at the end of file, or the number of bytes read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public int ReadFile(IntPtr buffer, ulong bufferSize) {
            return CfxApi.ZipReader.cfx_zip_reader_read_file(NativePtr, buffer, (UIntPtr)bufferSize);
        }

        /// <summary>
        /// Returns the current offset in the uncompressed file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public long Tell() {
            return CfxApi.ZipReader.cfx_zip_reader_tell(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if at end of the file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool Eof() {
            return 0 != CfxApi.ZipReader.cfx_zip_reader_eof(NativePtr);
        }
    }
}
