// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent an entry in navigation history.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
    /// </remarks>
    public class CfxNavigationEntry : CfxBaseLibrary {

        internal static CfxNavigationEntry Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxNavigationEntry)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxNavigationEntry(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxNavigationEntry(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns true (1) if this object is valid. Do not call any other functions
        /// if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.NavigationEntry.cfx_navigation_entry_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns the actual URL of the page. For some pages this may be data: URL or
        /// similar. Use get_display_url() to return a display-friendly version.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.NavigationEntry.cfx_navigation_entry_get_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns a display-friendly version of the URL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public string DisplayUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.NavigationEntry.cfx_navigation_entry_get_display_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the original URL that was entered by the user before any redirects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public string OriginalUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.NavigationEntry.cfx_navigation_entry_get_original_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the title set by the page. This value may be NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public string Title {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.NavigationEntry.cfx_navigation_entry_get_title(NativePtr));
            }
        }

        /// <summary>
        /// Returns the transition type which indicates what the user did to move to
        /// this page from the previous page.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public CfxTransitionType TransitionType {
            get {
                return (CfxTransitionType)CfxApi.NavigationEntry.cfx_navigation_entry_get_transition_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this navigation includes post data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public bool HasPostData {
            get {
                return 0 != CfxApi.NavigationEntry.cfx_navigation_entry_has_post_data(NativePtr);
            }
        }

        /// <summary>
        /// Returns the time for the last known successful navigation completion. A
        /// navigation may be completed more than once if the page is reloaded. May be
        /// 0 if the navigation has not yet completed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public CfxTime CompletionTime {
            get {
                var __retval = CfxApi.NavigationEntry.cfx_navigation_entry_get_completion_time(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxTime.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Returns the HTTP status code for the last known successful navigation
        /// response. May be 0 if the response has not yet been received or if the
        /// navigation has not yet completed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public int HttpStatusCode {
            get {
                return CfxApi.NavigationEntry.cfx_navigation_entry_get_http_status_code(NativePtr);
            }
        }

        /// <summary>
        /// Returns the SSL information for this navigation entry.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_navigation_entry_capi.h">cef/include/capi/cef_navigation_entry_capi.h</see>.
        /// </remarks>
        public CfxSslStatus SslStatus {
            get {
                return CfxSslStatus.Wrap(CfxApi.NavigationEntry.cfx_navigation_entry_get_sslstatus(NativePtr));
            }
        }
    }
}
