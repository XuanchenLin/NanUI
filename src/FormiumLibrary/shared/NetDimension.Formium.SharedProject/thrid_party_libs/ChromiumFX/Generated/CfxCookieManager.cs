// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used for managing cookies. The functions of this structure may be
    /// called on any thread unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
    /// </remarks>
    public class CfxCookieManager : CfxBaseLibrary {

        internal static CfxCookieManager Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxCookieManager)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxCookieManager(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxCookieManager(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the global cookie manager. By default data will be stored at
        /// CfxSettings.CachePath if specified or in memory otherwise. If |callback| is
        /// non-NULL it will be executed asnychronously on the UI thread after the
        /// manager's storage has been initialized. Using this function is equivalent to
        /// calling CfxRequestContext.CfxRequestContextGetGlobalContext()->GetDe
        /// faultCookieManager().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public static CfxCookieManager GetGlobalManager(CfxCompletionCallback callback) {
            return CfxCookieManager.Wrap(CfxApi.CookieManager.cfx_cookie_manager_get_global_manager(CfxCompletionCallback.Unwrap(callback)));
        }

        /// <summary>
        /// Set the schemes supported by this manager. If |includeDefaults| is true
        /// (1) the default schemes ("http", "https", "ws" and "wss") will also be
        /// supported. Calling this function with an NULL |schemes| value and
        /// |includeDefaults| set to false (0) will disable all loading and saving of
        /// cookies for this manager. If |callback| is non-NULL it will be executed
        /// asnychronously on the UI thread after the change has been applied. Must be
        /// called before any cookies are accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public void SetSupportedSchemes(System.Collections.Generic.List<string> schemes, bool includeDefaults, CfxCompletionCallback callback) {
            PinnedString[] schemes_handles;
            var schemes_unwrapped = StringFunctions.UnwrapCfxStringList(schemes, out schemes_handles);
            CfxApi.CookieManager.cfx_cookie_manager_set_supported_schemes(NativePtr, schemes_unwrapped, includeDefaults ? 1 : 0, CfxCompletionCallback.Unwrap(callback));
            StringFunctions.FreePinnedStrings(schemes_handles);
            StringFunctions.CfxStringListCopyToManaged(schemes_unwrapped, schemes);
            CfxApi.Runtime.cfx_string_list_free(schemes_unwrapped);
        }

        /// <summary>
        /// Visit all cookies on the UI thread. The returned cookies are ordered by
        /// longest path, then by earliest creation date. Returns false (0) if cookies
        /// cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool VisitAllCookies(CfxCookieVisitor visitor) {
            return 0 != CfxApi.CookieManager.cfx_cookie_manager_visit_all_cookies(NativePtr, CfxCookieVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Visit a subset of cookies on the UI thread. The results are filtered by the
        /// given url scheme, host, domain and path. If |includeHttpOnly| is true (1)
        /// HTTP-only cookies will also be included in the results. The returned
        /// cookies are ordered by longest path, then by earliest creation date.
        /// Returns false (0) if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool VisitUrlCookies(string url, bool includeHttpOnly, CfxCookieVisitor visitor) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.CookieManager.cfx_cookie_manager_visit_url_cookies(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, includeHttpOnly ? 1 : 0, CfxCookieVisitor.Unwrap(visitor));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Sets a cookie given a valid URL and explicit user-provided cookie
        /// attributes. This function expects each attribute to be well-formed. It will
        /// check for disallowed characters (e.g. the ';' character is disallowed
        /// within the cookie value attribute) and fail without setting the cookie if
        /// such characters are found. If |callback| is non-NULL it will be executed
        /// asnychronously on the UI thread after the cookie has been set. Returns
        /// false (0) if an invalid URL is specified or if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool SetCookie(string url, CfxCookie cookie, CfxSetCookieCallback callback) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.CookieManager.cfx_cookie_manager_set_cookie(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxCookie.Unwrap(cookie), CfxSetCookieCallback.Unwrap(callback));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Delete all cookies that match the specified parameters. If both |url| and
        /// |cookieName| values are specified all host and domain cookies matching
        /// both will be deleted. If only |url| is specified all host cookies (but not
        /// domain cookies) irrespective of path will be deleted. If |url| is NULL all
        /// cookies for all hosts and domains will be deleted. If |callback| is non-
        /// NULL it will be executed asnychronously on the UI thread after the cookies
        /// have been deleted. Returns false (0) if a non-NULL invalid URL is specified
        /// or if cookies cannot be accessed. Cookies can alternately be deleted using
        /// the Visit*Cookies() functions.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool DeleteCookies(string url, string cookieName, CfxDeleteCookiesCallback callback) {
            var url_pinned = new PinnedString(url);
            var cookieName_pinned = new PinnedString(cookieName);
            var __retval = CfxApi.CookieManager.cfx_cookie_manager_delete_cookies(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, cookieName_pinned.Obj.PinnedPtr, cookieName_pinned.Length, CfxDeleteCookiesCallback.Unwrap(callback));
            url_pinned.Obj.Free();
            cookieName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Flush the backing store (if any) to disk. If |callback| is non-NULL it will
        /// be executed asnychronously on the UI thread after the flush is complete.
        /// Returns false (0) if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool FlushStore(CfxCompletionCallback callback) {
            return 0 != CfxApi.CookieManager.cfx_cookie_manager_flush_store(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }
    }
}
