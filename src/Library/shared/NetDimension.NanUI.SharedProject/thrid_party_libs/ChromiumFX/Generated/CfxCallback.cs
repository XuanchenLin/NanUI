// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Generic callback structure used for asynchronous continuation.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
    /// </remarks>
    public class CfxCallback : CfxBaseLibrary {

        internal static CfxCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue processing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
        /// </remarks>
        public void Continue() {
            CfxApi.Callback.cfx_callback_cont(NativePtr);
        }

        /// <summary>
        /// Cancel processing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.Callback.cfx_callback_cancel(NativePtr);
        }
    }
}
