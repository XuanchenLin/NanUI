// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback for asynchronous continuation of CfxResourceHandler.Read().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
    /// </remarks>
    public class CfxResourceReadCallback : CfxBaseLibrary {

        internal static CfxResourceReadCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxResourceReadCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxResourceReadCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxResourceReadCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Callback for asynchronous continuation of read(). If |bytesRead| == 0 the
        /// response will be considered complete. If |bytesRead| > 0 then read() will
        /// be called again until the request is complete (based on either the result
        /// or the expected content length). If |bytesRead| &lt; 0 then the request will
        /// fail and the |bytesRead| value will be treated as the error code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_resource_handler_capi.h">cef/include/capi/cef_resource_handler_capi.h</see>.
        /// </remarks>
        public void Continue(int bytesRead) {
            CfxApi.ResourceReadCallback.cfx_resource_read_callback_cont(NativePtr, bytesRead);
        }
    }
}
