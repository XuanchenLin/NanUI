// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used for asynchronous continuation of JavaScript dialog
    /// requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
    /// </remarks>
    public class CfxJsDialogCallback : CfxBaseLibrary {

        internal static CfxJsDialogCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxJsDialogCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxJsDialogCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxJsDialogCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue the JS dialog request. Set |success| to true (1) if the OK button
        /// was pressed. The |userInput| value should be specified for prompt dialogs.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public void Continue(bool success, string userInput) {
            var userInput_pinned = new PinnedString(userInput);
            CfxApi.JsDialogCallback.cfx_jsdialog_callback_cont(NativePtr, success ? 1 : 0, userInput_pinned.Obj.PinnedPtr, userInput_pinned.Length);
            userInput_pinned.Obj.Free();
        }
    }
}
