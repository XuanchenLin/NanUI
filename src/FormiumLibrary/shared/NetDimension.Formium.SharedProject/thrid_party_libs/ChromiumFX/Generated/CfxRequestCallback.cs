// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used for asynchronous continuation of url requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_callback_capi.h">cef/include/capi/cef_request_callback_capi.h</see>.
    /// </remarks>
    public class CfxRequestCallback : CfxBaseLibrary {

        internal static CfxRequestCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxRequestCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxRequestCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxRequestCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue the url request. If |allow| is true (1) the request will be
        /// continued. Otherwise, the request will be canceled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_callback_capi.h">cef/include/capi/cef_request_callback_capi.h</see>.
        /// </remarks>
        public void Continue(bool allow) {
            CfxApi.RequestCallback.cfx_request_callback_cont(NativePtr, allow ? 1 : 0);
        }

        /// <summary>
        /// Cancel the url request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_callback_capi.h">cef/include/capi/cef_request_callback_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.RequestCallback.cfx_request_callback_cancel(NativePtr);
        }
    }
}
