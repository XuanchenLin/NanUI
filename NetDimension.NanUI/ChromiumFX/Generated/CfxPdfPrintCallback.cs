// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	using Event;

	/// <summary>
	/// Callback structure for CfxBrowserHost.PrintToPDF. The functions of this
	/// structure will be called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
	/// </remarks>
	public class CfxPdfPrintCallback : CfxBase {

        static CfxPdfPrintCallback () {
            CfxApiLoader.LoadCfxPdfPrintCallbackApi();
        }

        internal static CfxPdfPrintCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_pdf_print_callback_get_gc_handle(nativePtr);
            return (CfxPdfPrintCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_pdf_print_finished
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_pdf_print_callback_on_pdf_print_finished_delegate(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int ok);
        private static cfx_pdf_print_callback_on_pdf_print_finished_delegate cfx_pdf_print_callback_on_pdf_print_finished;
        private static IntPtr cfx_pdf_print_callback_on_pdf_print_finished_ptr;

        internal static void on_pdf_print_finished(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int ok) {
            var self = (CfxPdfPrintCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxPdfPrintCallbackOnPdfPrintFinishedEventArgs(path_str, path_length, ok);
            var eventHandler = self.m_OnPdfPrintFinished;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxPdfPrintCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxPdfPrintCallback() : base(CfxApi.cfx_pdf_print_callback_ctor) {}

        /// <summary>
        /// Method that will be executed when the PDF printing has completed. |Path| is
        /// the output path. |Ok| will be true (1) if the printing completed
        /// successfully or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public event CfxPdfPrintCallbackOnPdfPrintFinishedEventHandler OnPdfPrintFinished {
            add {
                lock(eventLock) {
                    if(m_OnPdfPrintFinished == null) {
                        if(cfx_pdf_print_callback_on_pdf_print_finished == null) {
                            cfx_pdf_print_callback_on_pdf_print_finished = on_pdf_print_finished;
                            cfx_pdf_print_callback_on_pdf_print_finished_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_pdf_print_callback_on_pdf_print_finished);
                        }
                        CfxApi.cfx_pdf_print_callback_set_managed_callback(NativePtr, 0, cfx_pdf_print_callback_on_pdf_print_finished_ptr);
                    }
                    m_OnPdfPrintFinished += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnPdfPrintFinished -= value;
                    if(m_OnPdfPrintFinished == null) {
                        CfxApi.cfx_pdf_print_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxPdfPrintCallbackOnPdfPrintFinishedEventHandler m_OnPdfPrintFinished;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnPdfPrintFinished != null) {
                m_OnPdfPrintFinished = null;
                CfxApi.cfx_pdf_print_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Method that will be executed when the PDF printing has completed. |Path| is
		/// the output path. |Ok| will be true (1) if the printing completed
		/// successfully or false (0) otherwise.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
		/// </remarks>
		public delegate void CfxPdfPrintCallbackOnPdfPrintFinishedEventHandler(object sender, CfxPdfPrintCallbackOnPdfPrintFinishedEventArgs e);

        /// <summary>
        /// Method that will be executed when the PDF printing has completed. |Path| is
        /// the output path. |Ok| will be true (1) if the printing completed
        /// successfully or false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public class CfxPdfPrintCallbackOnPdfPrintFinishedEventArgs : CfxEventArgs {

            internal IntPtr m_path_str;
            internal int m_path_length;
            internal string m_path;
            internal int m_ok;

            internal CfxPdfPrintCallbackOnPdfPrintFinishedEventArgs(IntPtr path_str, int path_length, int ok) {
                m_path_str = path_str;
                m_path_length = path_length;
                m_ok = ok;
            }

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
