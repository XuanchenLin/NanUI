// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Callback structure for CfxBrowserHost.RunFileDialog. The functions of
    /// this structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxRunFileDialogCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_file_dialog_dismissed_native = on_file_dialog_dismissed;

            on_file_dialog_dismissed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_file_dialog_dismissed_native);
        }

        // on_file_dialog_dismissed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_file_dialog_dismissed_delegate(IntPtr gcHandlePtr, int selected_accept_filter, IntPtr file_paths);
        private static on_file_dialog_dismissed_delegate on_file_dialog_dismissed_native;
        private static IntPtr on_file_dialog_dismissed_native_ptr;

        internal static void on_file_dialog_dismissed(IntPtr gcHandlePtr, int selected_accept_filter, IntPtr file_paths) {
            var self = (CfxRunFileDialogCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnFileDialogDismissedEventArgs();
            e.m_selected_accept_filter = selected_accept_filter;
            e.m_file_paths = file_paths;
            self.m_OnFileDialogDismissed?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxRunFileDialogCallback() : base(CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_ctor) {}

        /// <summary>
        /// Called asynchronously after the file dialog is dismissed.
        /// |SelectedAcceptFilter| is the 0-based index of the value selected from
        /// the accept filters array passed to CfxBrowserHost.RunFileDialog.
        /// |FilePaths| will be a single value or a list of values depending on the
        /// dialog mode. If the selection was cancelled |FilePaths| will be NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public event CfxOnFileDialogDismissedEventHandler OnFileDialogDismissed {
            add {
                lock(eventLock) {
                    if(m_OnFileDialogDismissed == null) {
                        CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_set_callback(NativePtr, 0, on_file_dialog_dismissed_native_ptr);
                    }
                    m_OnFileDialogDismissed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFileDialogDismissed -= value;
                    if(m_OnFileDialogDismissed == null) {
                        CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFileDialogDismissedEventHandler m_OnFileDialogDismissed;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnFileDialogDismissed != null) {
                m_OnFileDialogDismissed = null;
                CfxApi.RunFileDialogCallback.cfx_run_file_dialog_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called asynchronously after the file dialog is dismissed.
        /// |SelectedAcceptFilter| is the 0-based index of the value selected from
        /// the accept filters array passed to CfxBrowserHost.RunFileDialog.
        /// |FilePaths| will be a single value or a list of values depending on the
        /// dialog mode. If the selection was cancelled |FilePaths| will be NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnFileDialogDismissedEventHandler(object sender, CfxOnFileDialogDismissedEventArgs e);

        /// <summary>
        /// Called asynchronously after the file dialog is dismissed.
        /// |SelectedAcceptFilter| is the 0-based index of the value selected from
        /// the accept filters array passed to CfxBrowserHost.RunFileDialog.
        /// |FilePaths| will be a single value or a list of values depending on the
        /// dialog mode. If the selection was cancelled |FilePaths| will be NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public class CfxOnFileDialogDismissedEventArgs : CfxEventArgs {

            internal int m_selected_accept_filter;
            internal IntPtr m_file_paths;

            internal CfxOnFileDialogDismissedEventArgs() {}

            /// <summary>
            /// Get the SelectedAcceptFilter parameter for the <see cref="CfxRunFileDialogCallback.OnFileDialogDismissed"/> callback.
            /// </summary>
            public int SelectedAcceptFilter {
                get {
                    CheckAccess();
                    return m_selected_accept_filter;
                }
            }
            /// <summary>
            /// Get the FilePaths parameter for the <see cref="CfxRunFileDialogCallback.OnFileDialogDismissed"/> callback.
            /// </summary>
            public System.Collections.Generic.List<string> FilePaths {
                get {
                    CheckAccess();
                    return StringFunctions.WrapCfxStringList(m_file_paths);
                }
            }

            public override string ToString() {
                return String.Format("SelectedAcceptFilter={{{0}}}, FilePaths={{{1}}}", SelectedAcceptFilter, FilePaths);
            }
        }

    }
}
