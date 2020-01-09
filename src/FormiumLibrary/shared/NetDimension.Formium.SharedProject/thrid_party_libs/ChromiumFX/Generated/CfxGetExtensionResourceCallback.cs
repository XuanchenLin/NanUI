// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used for asynchronous continuation of
    /// CfxExtensionHandler.GetExtensionResource.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
    /// </remarks>
    public class CfxGetExtensionResourceCallback : CfxBaseLibrary {

        internal static CfxGetExtensionResourceCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxGetExtensionResourceCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxGetExtensionResourceCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxGetExtensionResourceCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue the request. Read the resource contents from |stream|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public void Continue(CfxStreamReader stream) {
            CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cont(NativePtr, CfxStreamReader.Unwrap(stream));
        }

        /// <summary>
        /// Cancel the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.GetExtensionResourceCallback.cfx_get_extension_resource_callback_cancel(NativePtr);
        }
    }
}
