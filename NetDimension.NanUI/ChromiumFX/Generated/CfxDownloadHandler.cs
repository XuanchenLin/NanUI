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
    /// Structure used to handle file downloads. The functions of this structure will
    /// called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_download_handler_capi.h">cef/include/capi/cef_download_handler_capi.h</see>.
    /// </remarks>
    public class CfxDownloadHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_before_download_native = on_before_download;
            on_download_updated_native = on_download_updated;

            on_before_download_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_download_native);
            on_download_updated_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_download_updated_native);
        }

        // on_before_download
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_download_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr download_item, out int download_item_release, IntPtr suggested_name_str, int suggested_name_length, IntPtr callback, out int callback_release);
        private static on_before_download_delegate on_before_download_native;
        private static IntPtr on_before_download_native_ptr;

        internal static void on_before_download(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr download_item, out int download_item_release, IntPtr suggested_name_str, int suggested_name_length, IntPtr callback, out int callback_release) {
            var self = (CfxDownloadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                download_item_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnBeforeDownloadEventArgs();
            e.m_browser = browser;
            e.m_download_item = download_item;
            e.m_suggested_name_str = suggested_name_str;
            e.m_suggested_name_length = suggested_name_length;
            e.m_callback = callback;
            self.m_OnBeforeDownload?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            download_item_release = e.m_download_item_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
        }

        // on_download_updated
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_updated_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr download_item, out int download_item_release, IntPtr callback, out int callback_release);
        private static on_download_updated_delegate on_download_updated_native;
        private static IntPtr on_download_updated_native_ptr;

        internal static void on_download_updated(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr download_item, out int download_item_release, IntPtr callback, out int callback_release) {
            var self = (CfxDownloadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                download_item_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnDownloadUpdatedEventArgs();
            e.m_browser = browser;
            e.m_download_item = download_item;
            e.m_callback = callback;
            self.m_OnDownloadUpdated?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            download_item_release = e.m_download_item_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
        }

        public CfxDownloadHandler() : base(CfxApi.DownloadHandler.cfx_download_handler_ctor) {}

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
                        CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 0, on_before_download_native_ptr);
                    }
                    m_OnBeforeDownload += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeDownload -= value;
                    if(m_OnBeforeDownload == null) {
                        CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 0, IntPtr.Zero);
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
                        CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 1, on_download_updated_native_ptr);
                    }
                    m_OnDownloadUpdated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadUpdated -= value;
                    if(m_OnDownloadUpdated == null) {
                        CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDownloadUpdatedEventHandler m_OnDownloadUpdated;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnBeforeDownload != null) {
                m_OnBeforeDownload = null;
                CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnDownloadUpdated != null) {
                m_OnDownloadUpdated = null;
                CfxApi.DownloadHandler.cfx_download_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

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

            internal CfxOnBeforeDownloadEventArgs() {}

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

            internal CfxOnDownloadUpdatedEventArgs() {}

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
