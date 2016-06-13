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
	/// Callback structure for CfxBrowserHost.RunFileDialog. The functions of
	/// this structure will be called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
	/// </remarks>
	public class CfxRunFileDialogCallback : CfxBase {

        static CfxRunFileDialogCallback () {
            CfxApiLoader.LoadCfxRunFileDialogCallbackApi();
        }

        internal static CfxRunFileDialogCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_run_file_dialog_callback_get_gc_handle(nativePtr);
            return (CfxRunFileDialogCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_file_dialog_dismissed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_run_file_dialog_callback_on_file_dialog_dismissed_delegate(IntPtr gcHandlePtr, int selected_accept_filter, IntPtr file_paths);
        private static cfx_run_file_dialog_callback_on_file_dialog_dismissed_delegate cfx_run_file_dialog_callback_on_file_dialog_dismissed;
        private static IntPtr cfx_run_file_dialog_callback_on_file_dialog_dismissed_ptr;

        internal static void on_file_dialog_dismissed(IntPtr gcHandlePtr, int selected_accept_filter, IntPtr file_paths) {
            var self = (CfxRunFileDialogCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxRunFileDialogCallbackOnFileDialogDismissedEventArgs(selected_accept_filter, file_paths);
            var eventHandler = self.m_OnFileDialogDismissed;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxRunFileDialogCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRunFileDialogCallback() : base(CfxApi.cfx_run_file_dialog_callback_ctor) {}

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
        public event CfxRunFileDialogCallbackOnFileDialogDismissedEventHandler OnFileDialogDismissed {
            add {
                lock(eventLock) {
                    if(m_OnFileDialogDismissed == null) {
                        if(cfx_run_file_dialog_callback_on_file_dialog_dismissed == null) {
                            cfx_run_file_dialog_callback_on_file_dialog_dismissed = on_file_dialog_dismissed;
                            cfx_run_file_dialog_callback_on_file_dialog_dismissed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_run_file_dialog_callback_on_file_dialog_dismissed);
                        }
                        CfxApi.cfx_run_file_dialog_callback_set_managed_callback(NativePtr, 0, cfx_run_file_dialog_callback_on_file_dialog_dismissed_ptr);
                    }
                    m_OnFileDialogDismissed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFileDialogDismissed -= value;
                    if(m_OnFileDialogDismissed == null) {
                        CfxApi.cfx_run_file_dialog_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxRunFileDialogCallbackOnFileDialogDismissedEventHandler m_OnFileDialogDismissed;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnFileDialogDismissed != null) {
                m_OnFileDialogDismissed = null;
                CfxApi.cfx_run_file_dialog_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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
		public delegate void CfxRunFileDialogCallbackOnFileDialogDismissedEventHandler(object sender, CfxRunFileDialogCallbackOnFileDialogDismissedEventArgs e);

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
        public class CfxRunFileDialogCallbackOnFileDialogDismissedEventArgs : CfxEventArgs {

            internal int m_selected_accept_filter;
            internal IntPtr m_file_paths;

            internal CfxRunFileDialogCallbackOnFileDialogDismissedEventArgs(int selected_accept_filter, IntPtr file_paths) {
                m_selected_accept_filter = selected_accept_filter;
                m_file_paths = file_paths;
            }

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
