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
    /// Callback structure for CfxBrowserHost.DownloadImage. The functions of
    /// this structure will be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxDownloadImageCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_download_image_finished_native = on_download_image_finished;

            on_download_image_finished_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_download_image_finished_native);
        }

        // on_download_image_finished
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_download_image_finished_delegate(IntPtr gcHandlePtr, IntPtr image_url_str, int image_url_length, int http_status_code, IntPtr image, out int image_release);
        private static on_download_image_finished_delegate on_download_image_finished_native;
        private static IntPtr on_download_image_finished_native_ptr;

        internal static void on_download_image_finished(IntPtr gcHandlePtr, IntPtr image_url_str, int image_url_length, int http_status_code, IntPtr image, out int image_release) {
            var self = (CfxDownloadImageCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                image_release = 1;
                return;
            }
            var e = new CfxOnDownloadImageFinishedEventArgs();
            e.m_image_url_str = image_url_str;
            e.m_image_url_length = image_url_length;
            e.m_http_status_code = http_status_code;
            e.m_image = image;
            self.m_OnDownloadImageFinished?.Invoke(self, e);
            e.m_isInvalid = true;
            image_release = e.m_image_wrapped == null? 1 : 0;
        }

        public CfxDownloadImageCallback() : base(CfxApi.DownloadImageCallback.cfx_download_image_callback_ctor) {}

        /// <summary>
        /// Method that will be executed when the image download has completed.
        /// |ImageUrl| is the URL that was downloaded and |HttpStatusCode| is the
        /// resulting HTTP status code. |Image| is the resulting image, possibly at
        /// multiple scale factors, or NULL if the download failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public event CfxOnDownloadImageFinishedEventHandler OnDownloadImageFinished {
            add {
                lock(eventLock) {
                    if(m_OnDownloadImageFinished == null) {
                        CfxApi.DownloadImageCallback.cfx_download_image_callback_set_callback(NativePtr, 0, on_download_image_finished_native_ptr);
                    }
                    m_OnDownloadImageFinished += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDownloadImageFinished -= value;
                    if(m_OnDownloadImageFinished == null) {
                        CfxApi.DownloadImageCallback.cfx_download_image_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDownloadImageFinishedEventHandler m_OnDownloadImageFinished;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnDownloadImageFinished != null) {
                m_OnDownloadImageFinished = null;
                CfxApi.DownloadImageCallback.cfx_download_image_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be executed when the image download has completed.
        /// |ImageUrl| is the URL that was downloaded and |HttpStatusCode| is the
        /// resulting HTTP status code. |Image| is the resulting image, possibly at
        /// multiple scale factors, or NULL if the download failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnDownloadImageFinishedEventHandler(object sender, CfxOnDownloadImageFinishedEventArgs e);

        /// <summary>
        /// Method that will be executed when the image download has completed.
        /// |ImageUrl| is the URL that was downloaded and |HttpStatusCode| is the
        /// resulting HTTP status code. |Image| is the resulting image, possibly at
        /// multiple scale factors, or NULL if the download failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public class CfxOnDownloadImageFinishedEventArgs : CfxEventArgs {

            internal IntPtr m_image_url_str;
            internal int m_image_url_length;
            internal string m_image_url;
            internal int m_http_status_code;
            internal IntPtr m_image;
            internal CfxImage m_image_wrapped;

            internal CfxOnDownloadImageFinishedEventArgs() {}

            /// <summary>
            /// Get the ImageUrl parameter for the <see cref="CfxDownloadImageCallback.OnDownloadImageFinished"/> callback.
            /// </summary>
            public string ImageUrl {
                get {
                    CheckAccess();
                    m_image_url = StringFunctions.PtrToStringUni(m_image_url_str, m_image_url_length);
                    return m_image_url;
                }
            }
            /// <summary>
            /// Get the HttpStatusCode parameter for the <see cref="CfxDownloadImageCallback.OnDownloadImageFinished"/> callback.
            /// </summary>
            public int HttpStatusCode {
                get {
                    CheckAccess();
                    return m_http_status_code;
                }
            }
            /// <summary>
            /// Get the Image parameter for the <see cref="CfxDownloadImageCallback.OnDownloadImageFinished"/> callback.
            /// </summary>
            public CfxImage Image {
                get {
                    CheckAccess();
                    if(m_image_wrapped == null) m_image_wrapped = CfxImage.Wrap(m_image);
                    return m_image_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("ImageUrl={{{0}}}, HttpStatusCode={{{1}}}, Image={{{2}}}", ImageUrl, HttpStatusCode, Image);
            }
        }

    }
}
