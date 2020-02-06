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
    /// Implement this structure to handle printing on Linux. Each browser will have
    /// only one print job in progress at a time. The functions of this structure
    /// will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
    /// </remarks>
    public class CfxPrintHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_print_start_native = on_print_start;
            on_print_settings_native = on_print_settings;
            on_print_dialog_native = on_print_dialog;
            on_print_job_native = on_print_job;
            on_print_reset_native = on_print_reset;
            get_pdf_paper_size_native = get_pdf_paper_size;

            on_print_start_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_print_start_native);
            on_print_settings_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_print_settings_native);
            on_print_dialog_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_print_dialog_native);
            on_print_job_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_print_job_native);
            on_print_reset_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_print_reset_native);
            get_pdf_paper_size_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_pdf_paper_size_native);
        }

        // on_print_start
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_print_start_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_print_start_delegate on_print_start_native;
        private static IntPtr on_print_start_native_ptr;

        internal static void on_print_start(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPrintStartEventArgs();
            e.m_browser = browser;
            self.m_OnPrintStart?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // on_print_settings
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_print_settings_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr settings, out int settings_release, int get_defaults);
        private static on_print_settings_delegate on_print_settings_native;
        private static IntPtr on_print_settings_native_ptr;

        internal static void on_print_settings(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr settings, out int settings_release, int get_defaults) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                settings_release = 1;
                return;
            }
            var e = new CfxOnPrintSettingsEventArgs();
            e.m_browser = browser;
            e.m_settings = settings;
            e.m_get_defaults = get_defaults;
            self.m_OnPrintSettings?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            settings_release = e.m_settings_wrapped == null? 1 : 0;
        }

        // on_print_dialog
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_print_dialog_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int has_selection, IntPtr callback, out int callback_release);
        private static on_print_dialog_delegate on_print_dialog_native;
        private static IntPtr on_print_dialog_native_ptr;

        internal static void on_print_dialog(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, int has_selection, IntPtr callback, out int callback_release) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnPrintDialogEventArgs();
            e.m_browser = browser;
            e.m_has_selection = has_selection;
            e.m_callback = callback;
            self.m_OnPrintDialog?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_print_job
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_print_job_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr document_name_str, int document_name_length, IntPtr pdf_file_path_str, int pdf_file_path_length, IntPtr callback, out int callback_release);
        private static on_print_job_delegate on_print_job_native;
        private static IntPtr on_print_job_native_ptr;

        internal static void on_print_job(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr document_name_str, int document_name_length, IntPtr pdf_file_path_str, int pdf_file_path_length, IntPtr callback, out int callback_release) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnPrintJobEventArgs();
            e.m_browser = browser;
            e.m_document_name_str = document_name_str;
            e.m_document_name_length = document_name_length;
            e.m_pdf_file_path_str = pdf_file_path_str;
            e.m_pdf_file_path_length = pdf_file_path_length;
            e.m_callback = callback;
            self.m_OnPrintJob?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_print_reset
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_print_reset_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release);
        private static on_print_reset_delegate on_print_reset_native;
        private static IntPtr on_print_reset_native_ptr;

        internal static void on_print_reset(IntPtr gcHandlePtr, IntPtr browser, out int browser_release) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnPrintResetEventArgs();
            e.m_browser = browser;
            self.m_OnPrintReset?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        // get_pdf_paper_size
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_pdf_paper_size_delegate(IntPtr gcHandlePtr, out IntPtr __retval, out IntPtr __retval_handle, int device_units_per_inch);
        private static get_pdf_paper_size_delegate get_pdf_paper_size_native;
        private static IntPtr get_pdf_paper_size_native_ptr;

        internal static void get_pdf_paper_size(IntPtr gcHandlePtr, out IntPtr __retval, out IntPtr __retval_handle, int device_units_per_inch) {
            var self = (CfxPrintHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                __retval_handle = default(IntPtr);
                return;
            }
            var e = new CfxGetPdfPaperSizeEventArgs();
            e.m_device_units_per_inch = device_units_per_inch;
            self.m_GetPdfPaperSize?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxSize.Unwrap(e.m_returnValue);
            __retval_handle = e.m_returnValue == null ? IntPtr.Zero : System.Runtime.InteropServices.GCHandle.ToIntPtr(System.Runtime.InteropServices.GCHandle.Alloc(e.m_returnValue));
        }

        public CfxPrintHandler() : base(CfxApi.PrintHandler.cfx_print_handler_ctor) {}

        /// <summary>
        /// Called when printing has started for the specified |Browser|. This function
        /// will be called before the other OnPrint*() functions and irrespective of
        /// how printing was initiated (e.g. CfxBrowserHost.Print(), JavaScript
        /// window.print() or PDF extension print button).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPrintStartEventHandler OnPrintStart {
            add {
                lock(eventLock) {
                    if(m_OnPrintStart == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 0, on_print_start_native_ptr);
                    }
                    m_OnPrintStart += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPrintStart -= value;
                    if(m_OnPrintStart == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPrintStartEventHandler m_OnPrintStart;

        /// <summary>
        /// Synchronize |Settings| with client state. If |GetDefaults| is true (1)
        /// then populate |Settings| with the default print settings. Do not keep a
        /// reference to |Settings| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPrintSettingsEventHandler OnPrintSettings {
            add {
                lock(eventLock) {
                    if(m_OnPrintSettings == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 1, on_print_settings_native_ptr);
                    }
                    m_OnPrintSettings += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPrintSettings -= value;
                    if(m_OnPrintSettings == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPrintSettingsEventHandler m_OnPrintSettings;

        /// <summary>
        /// Show the print dialog. Execute |Callback| once the dialog is dismissed.
        /// Return true (1) if the dialog will be displayed or false (0) to cancel the
        /// printing immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPrintDialogEventHandler OnPrintDialog {
            add {
                lock(eventLock) {
                    if(m_OnPrintDialog == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 2, on_print_dialog_native_ptr);
                    }
                    m_OnPrintDialog += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPrintDialog -= value;
                    if(m_OnPrintDialog == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPrintDialogEventHandler m_OnPrintDialog;

        /// <summary>
        /// Send the print job to the printer. Execute |Callback| once the job is
        /// completed. Return true (1) if the job will proceed or false (0) to cancel
        /// the job immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPrintJobEventHandler OnPrintJob {
            add {
                lock(eventLock) {
                    if(m_OnPrintJob == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 3, on_print_job_native_ptr);
                    }
                    m_OnPrintJob += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPrintJob -= value;
                    if(m_OnPrintJob == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPrintJobEventHandler m_OnPrintJob;

        /// <summary>
        /// Reset client state related to printing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnPrintResetEventHandler OnPrintReset {
            add {
                lock(eventLock) {
                    if(m_OnPrintReset == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 4, on_print_reset_native_ptr);
                    }
                    m_OnPrintReset += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPrintReset -= value;
                    if(m_OnPrintReset == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPrintResetEventHandler m_OnPrintReset;

        /// <summary>
        /// Return the PDF paper size in device units. Used in combination with
        /// CfxBrowserHost.PrintToPdf().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetPdfPaperSizeEventHandler GetPdfPaperSize {
            add {
                lock(eventLock) {
                    if(m_GetPdfPaperSize == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 5, get_pdf_paper_size_native_ptr);
                    }
                    m_GetPdfPaperSize += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetPdfPaperSize -= value;
                    if(m_GetPdfPaperSize == null) {
                        CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetPdfPaperSizeEventHandler m_GetPdfPaperSize;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnPrintStart != null) {
                m_OnPrintStart = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnPrintSettings != null) {
                m_OnPrintSettings = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnPrintDialog != null) {
                m_OnPrintDialog = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnPrintJob != null) {
                m_OnPrintJob = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnPrintReset != null) {
                m_OnPrintReset = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_GetPdfPaperSize != null) {
                m_GetPdfPaperSize = null;
                CfxApi.PrintHandler.cfx_print_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called when printing has started for the specified |Browser|. This function
        /// will be called before the other OnPrint*() functions and irrespective of
        /// how printing was initiated (e.g. CfxBrowserHost.Print(), JavaScript
        /// window.print() or PDF extension print button).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPrintStartEventHandler(object sender, CfxOnPrintStartEventArgs e);

        /// <summary>
        /// Called when printing has started for the specified |Browser|. This function
        /// will be called before the other OnPrint*() functions and irrespective of
        /// how printing was initiated (e.g. CfxBrowserHost.Print(), JavaScript
        /// window.print() or PDF extension print button).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPrintStartEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnPrintStartEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxPrintHandler.OnPrintStart"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

        /// <summary>
        /// Synchronize |Settings| with client state. If |GetDefaults| is true (1)
        /// then populate |Settings| with the default print settings. Do not keep a
        /// reference to |Settings| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPrintSettingsEventHandler(object sender, CfxOnPrintSettingsEventArgs e);

        /// <summary>
        /// Synchronize |Settings| with client state. If |GetDefaults| is true (1)
        /// then populate |Settings| with the default print settings. Do not keep a
        /// reference to |Settings| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPrintSettingsEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_settings;
            internal CfxPrintSettings m_settings_wrapped;
            internal int m_get_defaults;

            internal CfxOnPrintSettingsEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxPrintHandler.OnPrintSettings"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Settings parameter for the <see cref="CfxPrintHandler.OnPrintSettings"/> callback.
            /// </summary>
            public CfxPrintSettings Settings {
                get {
                    CheckAccess();
                    if(m_settings_wrapped == null) m_settings_wrapped = CfxPrintSettings.Wrap(m_settings);
                    return m_settings_wrapped;
                }
            }
            /// <summary>
            /// Get the GetDefaults parameter for the <see cref="CfxPrintHandler.OnPrintSettings"/> callback.
            /// </summary>
            public bool GetDefaults {
                get {
                    CheckAccess();
                    return 0 != m_get_defaults;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Settings={{{1}}}, GetDefaults={{{2}}}", Browser, Settings, GetDefaults);
            }
        }

        /// <summary>
        /// Show the print dialog. Execute |Callback| once the dialog is dismissed.
        /// Return true (1) if the dialog will be displayed or false (0) to cancel the
        /// printing immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPrintDialogEventHandler(object sender, CfxOnPrintDialogEventArgs e);

        /// <summary>
        /// Show the print dialog. Execute |Callback| once the dialog is dismissed.
        /// Return true (1) if the dialog will be displayed or false (0) to cancel the
        /// printing immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPrintDialogEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_has_selection;
            internal IntPtr m_callback;
            internal CfxPrintDialogCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnPrintDialogEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxPrintHandler.OnPrintDialog"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the HasSelection parameter for the <see cref="CfxPrintHandler.OnPrintDialog"/> callback.
            /// </summary>
            public bool HasSelection {
                get {
                    CheckAccess();
                    return 0 != m_has_selection;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxPrintHandler.OnPrintDialog"/> callback.
            /// </summary>
            public CfxPrintDialogCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxPrintDialogCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxPrintHandler.OnPrintDialog"/> callback.
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
                return String.Format("Browser={{{0}}}, HasSelection={{{1}}}, Callback={{{2}}}", Browser, HasSelection, Callback);
            }
        }

        /// <summary>
        /// Send the print job to the printer. Execute |Callback| once the job is
        /// completed. Return true (1) if the job will proceed or false (0) to cancel
        /// the job immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPrintJobEventHandler(object sender, CfxOnPrintJobEventArgs e);

        /// <summary>
        /// Send the print job to the printer. Execute |Callback| once the job is
        /// completed. Return true (1) if the job will proceed or false (0) to cancel
        /// the job immediately.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPrintJobEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_document_name_str;
            internal int m_document_name_length;
            internal string m_document_name;
            internal IntPtr m_pdf_file_path_str;
            internal int m_pdf_file_path_length;
            internal string m_pdf_file_path;
            internal IntPtr m_callback;
            internal CfxPrintJobCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnPrintJobEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxPrintHandler.OnPrintJob"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the DocumentName parameter for the <see cref="CfxPrintHandler.OnPrintJob"/> callback.
            /// </summary>
            public string DocumentName {
                get {
                    CheckAccess();
                    m_document_name = StringFunctions.PtrToStringUni(m_document_name_str, m_document_name_length);
                    return m_document_name;
                }
            }
            /// <summary>
            /// Get the PdfFilePath parameter for the <see cref="CfxPrintHandler.OnPrintJob"/> callback.
            /// </summary>
            public string PdfFilePath {
                get {
                    CheckAccess();
                    m_pdf_file_path = StringFunctions.PtrToStringUni(m_pdf_file_path_str, m_pdf_file_path_length);
                    return m_pdf_file_path;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxPrintHandler.OnPrintJob"/> callback.
            /// </summary>
            public CfxPrintJobCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxPrintJobCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxPrintHandler.OnPrintJob"/> callback.
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
                return String.Format("Browser={{{0}}}, DocumentName={{{1}}}, PdfFilePath={{{2}}}, Callback={{{3}}}", Browser, DocumentName, PdfFilePath, Callback);
            }
        }

        /// <summary>
        /// Reset client state related to printing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPrintResetEventHandler(object sender, CfxOnPrintResetEventArgs e);

        /// <summary>
        /// Reset client state related to printing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnPrintResetEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnPrintResetEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxPrintHandler.OnPrintReset"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

        /// <summary>
        /// Return the PDF paper size in device units. Used in combination with
        /// CfxBrowserHost.PrintToPdf().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetPdfPaperSizeEventHandler(object sender, CfxGetPdfPaperSizeEventArgs e);

        /// <summary>
        /// Return the PDF paper size in device units. Used in combination with
        /// CfxBrowserHost.PrintToPdf().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_handler_capi.h">cef/include/capi/cef_print_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetPdfPaperSizeEventArgs : CfxEventArgs {

            internal int m_device_units_per_inch;

            internal CfxSize m_returnValue;
            private bool returnValueSet;

            internal CfxGetPdfPaperSizeEventArgs() {}

            /// <summary>
            /// Get the DeviceUnitsPerInch parameter for the <see cref="CfxPrintHandler.GetPdfPaperSize"/> callback.
            /// </summary>
            public int DeviceUnitsPerInch {
                get {
                    CheckAccess();
                    return m_device_units_per_inch;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxPrintHandler.GetPdfPaperSize"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxSize returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("DeviceUnitsPerInch={{{0}}}", DeviceUnitsPerInch);
            }
        }

    }
}
