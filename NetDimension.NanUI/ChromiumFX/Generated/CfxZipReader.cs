// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Structure that supports the reading of zip archives via the zlib unzip API.
	/// The functions of this structure should only be called on the thread that
	/// creates the object.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
	/// </remarks>
	public partial class CfxZipReader : CfxBase {

        static CfxZipReader () {
            CfxApiLoader.LoadCfxZipReaderApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxZipReader Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxZipReader)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxZipReader(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
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
            return CfxZipReader.Wrap(CfxApi.cfx_zip_reader_create(CfxStreamReader.Unwrap(stream)));
        }

        /// <summary>
        /// The below functions act on the file at the current cursor position.
        /// Returns the name of the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public string FileName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_zip_reader_get_file_name(NativePtr));
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
                return CfxApi.cfx_zip_reader_get_file_size(NativePtr);
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
                return CfxTime.WrapOwned(CfxApi.cfx_zip_reader_get_file_last_modified(NativePtr));
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
            return 0 != CfxApi.cfx_zip_reader_move_to_first_file(NativePtr);
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
            return 0 != CfxApi.cfx_zip_reader_move_to_next_file(NativePtr);
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
            var __retval = CfxApi.cfx_zip_reader_move_to_file(NativePtr, fileName_pinned.Obj.PinnedPtr, fileName_pinned.Length, caseSensitive ? 1 : 0);
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
            return 0 != CfxApi.cfx_zip_reader_close(NativePtr);
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
            var __retval = CfxApi.cfx_zip_reader_open_file(NativePtr, password_pinned.Obj.PinnedPtr, password_pinned.Length);
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
            return 0 != CfxApi.cfx_zip_reader_close_file(NativePtr);
        }

        /// <summary>
        /// Read uncompressed file contents into the specified buffer. Returns &lt; 0 if
        /// an error occurred, 0 if at the end of file, or the number of bytes read.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public int ReadFile(IntPtr buffer, int bufferSize) {
            return CfxApi.cfx_zip_reader_read_file(NativePtr, buffer, bufferSize);
        }

        /// <summary>
        /// Returns the current offset in the uncompressed file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public long Tell() {
            return CfxApi.cfx_zip_reader_tell(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if at end of the file contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_zip_reader_capi.h">cef/include/capi/cef_zip_reader_capi.h</see>.
        /// </remarks>
        public bool Eof() {
            return 0 != CfxApi.cfx_zip_reader_eof(NativePtr);
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
