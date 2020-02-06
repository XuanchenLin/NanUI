// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure for asynchronous continuation of print dialog requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
    /// </remarks>
    public class CfxPrintDialogCallback : CfxBaseLibrary {

        internal static CfxPrintDialogCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxPrintDialogCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxPrintDialogCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxPrintDialogCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue printing with the specified |settings|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public void Continue(CfxPrintSettings settings) {
            CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cont(NativePtr, CfxPrintSettings.Unwrap(settings));
        }

        /// <summary>
        /// Cancel the printing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.PrintDialogCallback.cfx_print_dialog_callback_cancel(NativePtr);
        }
    }
}
