// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used to asynchronously cancel a download.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
    /// </remarks>
    public class CfxDownloadItemCallback : CfxBaseLibrary {

        internal static CfxDownloadItemCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxDownloadItemCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxDownloadItemCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxDownloadItemCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Call to cancel the download.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.DownloadItemCallback.cfx_download_item_callback_cancel(NativePtr);
        }

        /// <summary>
        /// Call to pause the download.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public void Pause() {
            CfxApi.DownloadItemCallback.cfx_download_item_callback_pause(NativePtr);
        }

        /// <summary>
        /// Call to resume the download.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public void Resume() {
            CfxApi.DownloadItemCallback.cfx_download_item_callback_resume(NativePtr);
        }
    }
}
