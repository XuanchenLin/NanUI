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
    /// Implement this structure to handle dialog events. The functions of this
    /// structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
    /// </remarks>
    public class CfxDialogHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_file_dialog_native = on_file_dialog;

            on_file_dialog_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_file_dialog_native);
        }

        // on_file_dialog
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_file_dialog_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int mode, IntPtr title_str, int title_length, IntPtr default_file_path_str, int default_file_path_length, IntPtr accept_filters, int selected_accept_filter, IntPtr callback, out int callback_release);
        private static on_file_dialog_delegate on_file_dialog_native;
        private static IntPtr on_file_dialog_native_ptr;

        internal static void on_file_dialog(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int mode, IntPtr title_str, int title_length, IntPtr default_file_path_str, int default_file_path_length, IntPtr accept_filters, int selected_accept_filter, IntPtr callback, out int callback_release) {
            var self = (CfxDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnFileDialogEventArgs();
            e.m_browser = browser;
            e.m_mode = mode;
            e.m_title_str = title_str;
            e.m_title_length = title_length;
            e.m_default_file_path_str = default_file_path_str;
            e.m_default_file_path_length = default_file_path_length;
            e.m_accept_filters = accept_filters;
            e.m_selected_accept_filter = selected_accept_filter;
            e.m_callback = callback;
            self.m_OnFileDialog?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxDialogHandler() : base(CfxApi.DialogHandler.cfx_dialog_handler_ctor) {}

        /// <summary>
        /// Called to run a file chooser dialog. |Mode| represents the type of dialog
        /// to display. |Title| to the title to be used for the dialog and may be NULL
        /// to show the default title ("Open" or "Save" depending on the mode).
        /// |DefaultFilePath| is the path with optional directory and/or file name
        /// component that should be initially selected in the dialog. |AcceptFilters|
        /// are used to restrict the selectable file types and may any combination of
        /// (a) valid lower-cased MIME types (e.g. "text/*" or "image/*"), (b)
        /// individual file extensions (e.g. ".txt" or ".png"), or (c) combined
        /// description and file extension delimited using "|" and ";" (e.g. "Image
        /// Types|.png;.gif;.jpg"). |SelectedAcceptFilter| is the 0-based index of
        /// the filter that should be selected by default. To display a custom dialog
        /// return true (1) and execute |Callback| either inline or at a later time. To
        /// display the default dialog return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnFileDialogEventHandler OnFileDialog {
            add {
                lock(eventLock) {
                    if(m_OnFileDialog == null) {
                        CfxApi.DialogHandler.cfx_dialog_handler_set_callback(NativePtr, 0, on_file_dialog_native_ptr);
                    }
                    m_OnFileDialog += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFileDialog -= value;
                    if(m_OnFileDialog == null) {
                        CfxApi.DialogHandler.cfx_dialog_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFileDialogEventHandler m_OnFileDialog;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnFileDialog != null) {
                m_OnFileDialog = null;
                CfxApi.DialogHandler.cfx_dialog_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called to run a file chooser dialog. |Mode| represents the type of dialog
        /// to display. |Title| to the title to be used for the dialog and may be NULL
        /// to show the default title ("Open" or "Save" depending on the mode).
        /// |DefaultFilePath| is the path with optional directory and/or file name
        /// component that should be initially selected in the dialog. |AcceptFilters|
        /// are used to restrict the selectable file types and may any combination of
        /// (a) valid lower-cased MIME types (e.g. "text/*" or "image/*"), (b)
        /// individual file extensions (e.g. ".txt" or ".png"), or (c) combined
        /// description and file extension delimited using "|" and ";" (e.g. "Image
        /// Types|.png;.gif;.jpg"). |SelectedAcceptFilter| is the 0-based index of
        /// the filter that should be selected by default. To display a custom dialog
        /// return true (1) and execute |Callback| either inline or at a later time. To
        /// display the default dialog return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnFileDialogEventHandler(object sender, CfxOnFileDialogEventArgs e);

        /// <summary>
        /// Called to run a file chooser dialog. |Mode| represents the type of dialog
        /// to display. |Title| to the title to be used for the dialog and may be NULL
        /// to show the default title ("Open" or "Save" depending on the mode).
        /// |DefaultFilePath| is the path with optional directory and/or file name
        /// component that should be initially selected in the dialog. |AcceptFilters|
        /// are used to restrict the selectable file types and may any combination of
        /// (a) valid lower-cased MIME types (e.g. "text/*" or "image/*"), (b)
        /// individual file extensions (e.g. ".txt" or ".png"), or (c) combined
        /// description and file extension delimited using "|" and ";" (e.g. "Image
        /// Types|.png;.gif;.jpg"). |SelectedAcceptFilter| is the 0-based index of
        /// the filter that should be selected by default. To display a custom dialog
        /// return true (1) and execute |Callback| either inline or at a later time. To
        /// display the default dialog return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dialog_handler_capi.h">cef/include/capi/cef_dialog_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnFileDialogEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_mode;
            internal IntPtr m_title_str;
            internal int m_title_length;
            internal string m_title;
            internal IntPtr m_default_file_path_str;
            internal int m_default_file_path_length;
            internal string m_default_file_path;
            internal IntPtr m_accept_filters;
            internal int m_selected_accept_filter;
            internal IntPtr m_callback;
            internal CfxFileDialogCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnFileDialogEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Mode parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public CfxFileDialogMode Mode {
                get {
                    CheckAccess();
                    return (CfxFileDialogMode)m_mode;
                }
            }
            /// <summary>
            /// Get the Title parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public string Title {
                get {
                    CheckAccess();
                    m_title = StringFunctions.PtrToStringUni(m_title_str, m_title_length);
                    return m_title;
                }
            }
            /// <summary>
            /// Get the DefaultFilePath parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public string DefaultFilePath {
                get {
                    CheckAccess();
                    m_default_file_path = StringFunctions.PtrToStringUni(m_default_file_path_str, m_default_file_path_length);
                    return m_default_file_path;
                }
            }
            /// <summary>
            /// Get the AcceptFilters parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public System.Collections.Generic.List<string> AcceptFilters {
                get {
                    CheckAccess();
                    return StringFunctions.WrapCfxStringList(m_accept_filters);
                }
            }
            /// <summary>
            /// Get the SelectedAcceptFilter parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public int SelectedAcceptFilter {
                get {
                    CheckAccess();
                    return m_selected_accept_filter;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// </summary>
            public CfxFileDialogCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxFileDialogCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxDialogHandler.OnFileDialog"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Mode={{{1}}}, Title={{{2}}}, DefaultFilePath={{{3}}}, AcceptFilters={{{4}}}, SelectedAcceptFilter={{{5}}}, Callback={{{6}}}", Browser, Mode, Title, DefaultFilePath, AcceptFilters, SelectedAcceptFilter, Callback);
            }
        }

    }
}
