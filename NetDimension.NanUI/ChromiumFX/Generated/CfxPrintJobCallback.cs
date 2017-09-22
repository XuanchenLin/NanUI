// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure for asynchronous continuation of print job requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
    /// </remarks>
    public class CfxPrintJobCallback : CfxBaseLibrary {

        internal static CfxPrintJobCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxPrintJobCallback)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxPrintJobCallback(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxPrintJobCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Indicate completion of the print job.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public void Continue() {
            CfxApi.PrintJobCallback.cfx_print_job_callback_cont(NativePtr);
        }
    }
}
