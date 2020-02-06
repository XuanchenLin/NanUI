// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used to asynchronously continue a download.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
    /// </remarks>
    public class CfxBeforeDownloadCallback : CfxBaseLibrary {

        internal static CfxBeforeDownloadCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxBeforeDownloadCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxBeforeDownloadCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
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
            CfxApi.BeforeDownloadCallback.cfx_before_download_callback_cont(NativePtr, downloadPath_pinned.Obj.PinnedPtr, downloadPath_pinned.Length, showDialog ? 1 : 0);
            downloadPath_pinned.Obj.Free();
        }
    }
}
