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
    /// Callback structure for CfxBrowserHost.PrintToPDF. The functions of this
    /// structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxPdfPrintCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_pdf_print_finished_native = on_pdf_print_finished;

            on_pdf_print_finished_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_pdf_print_finished_native);
        }

        // on_pdf_print_finished
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_pdf_print_finished_delegate(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int ok);
        private static on_pdf_print_finished_delegate on_pdf_print_finished_native;
        private static IntPtr on_pdf_print_finished_native_ptr;

        internal static void on_pdf_print_finished(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int ok) {
            var self = (CfxPdfPrintCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnPdfPrintFinishedEventArgs();
            e.m_path_str = path_str;
            e.m_path_length = path_length;
            e.m_ok = ok;
            self.m_OnPdfPrintFinished?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxPdfPrintCallback() : base(CfxApi.PdfPrintCallback.cfx_pdf_print_callback_ctor) {}

        /// <summary>
        /// Method that will be executed when the PDF printing has completed. |Path| is
        /// the output path. |Ok| will be true (1) if the printing completed
        /// successfully or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public event CfxOnPdfPrintFinishedEventHandler OnPdfPrintFinished {
            add {
                lock(eventLock) {
                    if(m_OnPdfPrintFinished == null) {
                        CfxApi.PdfPrintCallback.cfx_pdf_print_callback_set_callback(NativePtr, 0, on_pdf_print_finished_native_ptr);
                    }
                    m_OnPdfPrintFinished += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPdfPrintFinished -= value;
                    if(m_OnPdfPrintFinished == null) {
                        CfxApi.PdfPrintCallback.cfx_pdf_print_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnPdfPrintFinishedEventHandler m_OnPdfPrintFinished;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnPdfPrintFinished != null) {
                m_OnPdfPrintFinished = null;
                CfxApi.PdfPrintCallback.cfx_pdf_print_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be executed when the PDF printing has completed. |Path| is
        /// the output path. |Ok| will be true (1) if the printing completed
        /// successfully or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnPdfPrintFinishedEventHandler(object sender, CfxOnPdfPrintFinishedEventArgs e);

        /// <summary>
        /// Method that will be executed when the PDF printing has completed. |Path| is
        /// the output path. |Ok| will be true (1) if the printing completed
        /// successfully or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public class CfxOnPdfPrintFinishedEventArgs : CfxEventArgs {

            internal IntPtr m_path_str;
            internal int m_path_length;
            internal string m_path;
            internal int m_ok;

            internal CfxOnPdfPrintFinishedEventArgs() {}

            /// <summary>
            /// Get the Path parameter for the <see cref="CfxPdfPrintCallback.OnPdfPrintFinished"/> callback.
            /// </summary>
            public string Path {
                get {
                    CheckAccess();
                    m_path = StringFunctions.PtrToStringUni(m_path_str, m_path_length);
                    return m_path;
                }
            }
            /// <summary>
            /// Get the Ok parameter for the <see cref="CfxPdfPrintCallback.OnPdfPrintFinished"/> callback.
            /// </summary>
            public bool Ok {
                get {
                    CheckAccess();
                    return 0 != m_ok;
                }
            }

            public override string ToString() {
                return String.Format("Path={{{0}}}, Ok={{{1}}}", Path, Ok);
            }
        }

    }
}
