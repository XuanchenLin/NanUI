// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure for asynchronous continuation of file dialog requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
    /// </remarks>
    public class CfxFileDialogCallback : CfxBaseLibrary {

        internal static CfxFileDialogCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxFileDialogCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxFileDialogCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxFileDialogCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue the file selection. |selectedAcceptFilter| should be the 0-based
        /// index of the value selected from the accept filters array passed to
        /// CfxDialogHandler.OnFileDialog. |filePaths| should be a single value
        /// or a list of values depending on the dialog mode. An NULL |filePaths|
        /// value is treated the same as calling cancel().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
        /// </remarks>
        public void Continue(int selectedAcceptFilter, System.Collections.Generic.List<string> filePaths) {
            PinnedString[] filePaths_handles;
            var filePaths_unwrapped = StringFunctions.UnwrapCfxStringList(filePaths, out filePaths_handles);
            CfxApi.FileDialogCallback.cfx_file_dialog_callback_cont(NativePtr, selectedAcceptFilter, filePaths_unwrapped);
            StringFunctions.FreePinnedStrings(filePaths_handles);
            StringFunctions.CfxStringListCopyToManaged(filePaths_unwrapped, filePaths);
            CfxApi.Runtime.cfx_string_list_free(filePaths_unwrapped);
        }

        /// <summary>
        /// Cancel the file selection.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.FileDialogCallback.cfx_file_dialog_callback_cancel(NativePtr);
        }
    }
}
