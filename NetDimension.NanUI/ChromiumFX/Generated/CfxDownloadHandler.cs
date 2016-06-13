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
	/// Structure used to handle file downloads. The functions of this structure will
	/// called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
	/// </remarks>
	public class CfxDownloadHandler : CfxBase {

        static CfxDownloadHandler () {
            CfxApiLoader.LoadCfxDownloadHandlerApi();
        }

        internal static CfxDownloadHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_download_handler_get_gc_handle(nativePtr);
            return (CfxDownloadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_before_download
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_download_handler_on_before_download_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr download_item, IntPtr suggested_name_str, int suggested_name_length, IntPtr callback);
        private static cfx_download_handler_on_before_download_delegate cfx_download_handler_on_before_download;
        private static IntPtr cfx_download_handler_on_before_download_ptr;

        internal static void on_before_download(IntPtr gcHandlePtr, IntPtr browser, IntPtr download_item, IntPtr suggested_name_str, int suggested_name_length, IntPtr callback) {
            var self = (CfxDownloadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnBeforeDownloadEventArgs(browser, download_item, suggested_name_str, suggested_name_length, callback);
            var eventHandler = self.m_OnBeforeDownload;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_download_item_wrapped == null) CfxApi.cfx_release(e.m_download_item);
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
        }

        // on_download_updated
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_download_handler_on_download_updated_delegate(IntPtr gcHandlePtr, IntPtr browser, IntPtr download_item, IntPtr callback);
        private static cfx_download_handler_on_download_updated_delegate cfx_download_handler_on_download_updated;
        private static IntPtr cfx_download_handler_on_download_updated_ptr;

        internal static void on_download_updated(IntPtr gcHandlePtr, IntPtr browser, IntPtr download_item, IntPtr callback) {
            var self = (CfxDownloadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnDownloadUpdatedEventArgs(browser, download_item, callback);
            var eventHandler = self.m_OnDownloadUpdated;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_download_item_wrapped == null) CfxApi.cfx_release(e.m_download_item);
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
        }

        internal CfxDownloadHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxDownloadHandler() : base(CfxApi.cfx_download_handler_ctor) {}

        /// <summary>
        /// Called before a download begins. |SuggestedName| is the suggested name for
        /// the download file. By default the download will be canceled. Execute
        /// |Callback| either asynchronously or in this function to continue the
        /// download if desired. Do not keep a reference to |DownloadItem| outside of
        /// this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeDownloadEventHandler OnBeforeDownload {
            add {
                lock(eventLock) {
                    if(m_OnBeforeDownload == null) {
                        if(cfx_download_handler_on_before_download == null) {
                            cfx_download_handler_on_before_download = on_before_download;
                            cfx_download_handler_on_before_download_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_download_handler_on_before_download);
                        }
                        CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 0, cfx_download_handler_on_before_download_ptr);
                    }
                    m_OnBeforeDownload += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeDownload -= value;
                    if(m_OnBeforeDownload == null) {
                        CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeDownloadEventHandler m_OnBeforeDownload;

        /// <summary>
        /// Called when a download's status or progress information has been updated.
        /// This may be called multiple times before and after on_before_download().
        /// Execute |Callback| either asynchronously or in this function to cancel the
        /// download if desired. Do not keep a reference to |DownloadItem| outside of
        /// this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnDownloadUpdatedEventHandler OnDownloadUpdated {
            add {
                lock(eventLock) {
                    if(m_OnDownloadUpdated == null) {
                        if(cfx_download_handler_on_download_updated == null) {
                            cfx_download_handler_on_download_updated = on_download_updated;
                            cfx_download_handler_on_download_updated_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_download_handler_on_download_updated);
                        }
                        CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 1, cfx_download_handler_on_download_updated_ptr);
                    }
                    m_OnDownloadUpdated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadUpdated -= value;
                    if(m_OnDownloadUpdated == null) {
                        CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDownloadUpdatedEventHandler m_OnDownloadUpdated;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnBeforeDownload != null) {
                m_OnBeforeDownload = null;
                CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnDownloadUpdated != null) {
                m_OnDownloadUpdated = null;
                CfxApi.cfx_download_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called before a download begins. |SuggestedName| is the suggested name for
		/// the download file. By default the download will be canceled. Execute
		/// |Callback| either asynchronously or in this function to continue the
		/// download if desired. Do not keep a reference to |DownloadItem| outside of
		/// this function.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxOnBeforeDownloadEventHandler(object sender, CfxOnBeforeDownloadEventArgs e);

        /// <summary>
        /// Called before a download begins. |SuggestedName| is the suggested name for
        /// the download file. By default the download will be canceled. Execute
        /// |Callback| either asynchronously or in this function to continue the
        /// download if desired. Do not keep a reference to |DownloadItem| outside of
        /// this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeDownloadEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_download_item;
            internal CfxDownloadItem m_download_item_wrapped;
            internal IntPtr m_suggested_name_str;
            internal int m_suggested_name_length;
            internal string m_suggested_name;
            internal IntPtr m_callback;
            internal CfxBeforeDownloadCallback m_callback_wrapped;

            internal CfxOnBeforeDownloadEventArgs(IntPtr browser, IntPtr download_item, IntPtr suggested_name_str, int suggested_name_length, IntPtr callback) {
                m_browser = browser;
                m_download_item = download_item;
                m_suggested_name_str = suggested_name_str;
                m_suggested_name_length = suggested_name_length;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDownloadHandler.OnBeforeDownload"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the DownloadItem parameter for the <see cref="CfxDownloadHandler.OnBeforeDownload"/> callback.
            /// </summary>
            public CfxDownloadItem DownloadItem {
                get {
                    CheckAccess();
                    if(m_download_item_wrapped == null) m_download_item_wrapped = CfxDownloadItem.Wrap(m_download_item);
                    return m_download_item_wrapped;
                }
            }
            /// <summary>
            /// Get the SuggestedName parameter for the <see cref="CfxDownloadHandler.OnBeforeDownload"/> callback.
            /// </summary>
            public string SuggestedName {
                get {
                    CheckAccess();
                    m_suggested_name = StringFunctions.PtrToStringUni(m_suggested_name_str, m_suggested_name_length);
                    return m_suggested_name;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxDownloadHandler.OnBeforeDownload"/> callback.
            /// </summary>
            public CfxBeforeDownloadCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxBeforeDownloadCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, DownloadItem={{{1}}}, SuggestedName={{{2}}}, Callback={{{3}}}", Browser, DownloadItem, SuggestedName, Callback);
            }
        }

        /// <summary>
        /// Called when a download's status or progress information has been updated.
        /// This may be called multiple times before and after on_before_download().
        /// Execute |Callback| either asynchronously or in this function to cancel the
        /// download if desired. Do not keep a reference to |DownloadItem| outside of
        /// this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnDownloadUpdatedEventHandler(object sender, CfxOnDownloadUpdatedEventArgs e);

        /// <summary>
        /// Called when a download's status or progress information has been updated.
        /// This may be called multiple times before and after on_before_download().
        /// Execute |Callback| either asynchronously or in this function to cancel the
        /// download if desired. Do not keep a reference to |DownloadItem| outside of
        /// this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnDownloadUpdatedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_download_item;
            internal CfxDownloadItem m_download_item_wrapped;
            internal IntPtr m_callback;
            internal CfxDownloadItemCallback m_callback_wrapped;

            internal CfxOnDownloadUpdatedEventArgs(IntPtr browser, IntPtr download_item, IntPtr callback) {
                m_browser = browser;
                m_download_item = download_item;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxDownloadHandler.OnDownloadUpdated"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the DownloadItem parameter for the <see cref="CfxDownloadHandler.OnDownloadUpdated"/> callback.
            /// </summary>
            public CfxDownloadItem DownloadItem {
                get {
                    CheckAccess();
                    if(m_download_item_wrapped == null) m_download_item_wrapped = CfxDownloadItem.Wrap(m_download_item);
                    return m_download_item_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxDownloadHandler.OnDownloadUpdated"/> callback.
            /// </summary>
            public CfxDownloadItemCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxDownloadItemCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, DownloadItem={{{1}}}, Callback={{{2}}}", Browser, DownloadItem, Callback);
            }
        }

    }
}
