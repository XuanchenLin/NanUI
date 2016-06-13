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
	/// Callback structure used to asynchronously continue a download.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
	/// </remarks>
	public class CfxBeforeDownloadCallback : CfxBase {

        static CfxBeforeDownloadCallback () {
            CfxApiLoader.LoadCfxBeforeDownloadCallbackApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxBeforeDownloadCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxBeforeDownloadCallback)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxBeforeDownloadCallback(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxBeforeDownloadCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Call to continue the download. Set |downloadPath| to the full file path
        /// for the download including the file name or leave blank to use the
        /// suggested name and the default temp directory. Set |showDialog| to true
        /// (1) if you do wish to show the default "Save As" dialog.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public void Continue(string downloadPath, bool showDialog) {
            var downloadPath_pinned = new PinnedString(downloadPath);
            CfxApi.cfx_before_download_callback_cont(NativePtr, downloadPath_pinned.Obj.PinnedPtr, downloadPath_pinned.Length, showDialog ? 1 : 0);
            downloadPath_pinned.Obj.Free();
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
