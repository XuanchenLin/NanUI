// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback for asynchronous continuation of CfxResourceHandler.Skip().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
    /// </remarks>
    public class CfxResourceSkipCallback : CfxBaseLibrary {

        internal static CfxResourceSkipCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxResourceSkipCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxResourceSkipCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxResourceSkipCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Callback for asynchronous continuation of skip(). If |bytesSkipped| > 0
        /// then either skip() will be called again until the requested number of bytes
        /// have been skipped or the request will proceed. If |bytesSkipped| &lt;= 0 the
        /// request will fail with ERR_REQUEST_RANGE_NOT_SATISFIABLE.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public void Continue(long bytesSkipped) {
            CfxApi.ResourceSkipCallback.cfx_resource_skip_callback_cont(NativePtr, bytesSkipped);
        }
    }
}
