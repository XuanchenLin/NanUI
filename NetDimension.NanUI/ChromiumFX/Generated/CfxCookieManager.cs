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
	/// <summary>
	/// Structure used for managing cookies. The functions of this structure may be
	/// called on any thread unless otherwise indicated.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
	/// </remarks>
	public class CfxCookieManager : CfxBase {

        static CfxCookieManager () {
            CfxApiLoader.LoadCfxCookieManagerApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxCookieManager Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxCookieManager)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxCookieManager(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxCookieManager(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the global cookie manager. By default data will be stored at
        /// CfxSettings.CachePath if specified or in memory otherwise. If |callback| is
        /// non-NULL it will be executed asnychronously on the IO thread after the
        /// manager's storage has been initialized. Using this function is equivalent to
        /// calling CfxRequestContext.CfxRequestContextGetGlobalContext()->get_d
        /// efault_cookie_manager().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public static CfxCookieManager GetGlobalManager(CfxCompletionCallback callback) {
            return CfxCookieManager.Wrap(CfxApi.cfx_cookie_manager_get_global_manager(CfxCompletionCallback.Unwrap(callback)));
        }

        /// <summary>
        /// Creates a new cookie manager. If |path| is NULL data will be stored in memory
        /// only. Otherwise, data will be stored at the specified |path|. To persist
        /// session cookies (cookies without an expiry date or validity interval) set
        /// |persistSessionCookies| to true (1). Session cookies are generally intended
        /// to be transient and most Web browsers do not persist them. If |callback| is
        /// non-NULL it will be executed asnychronously on the IO thread after the
        /// manager's storage has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public static CfxCookieManager CreateManager(string path, bool persistSessionCookies, CfxCompletionCallback callback) {
            var path_pinned = new PinnedString(path);
            var __retval = CfxApi.cfx_cookie_manager_create_manager(path_pinned.Obj.PinnedPtr, path_pinned.Length, persistSessionCookies ? 1 : 0, CfxCompletionCallback.Unwrap(callback));
            path_pinned.Obj.Free();
            return CfxCookieManager.Wrap(__retval);
        }

        /// <summary>
        /// Set the schemes supported by this manager. The default schemes ("http",
        /// "https", "ws" and "wss") will always be supported. If |callback| is non-
        /// NULL it will be executed asnychronously on the IO thread after the change
        /// has been applied. Must be called before any cookies are accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public void SetSupportedSchemes(System.Collections.Generic.List<string> schemes, CfxCompletionCallback callback) {
            PinnedString[] schemes_handles;
            var schemes_unwrapped = StringFunctions.UnwrapCfxStringList(schemes, out schemes_handles);
            CfxApi.cfx_cookie_manager_set_supported_schemes(NativePtr, schemes_unwrapped, CfxCompletionCallback.Unwrap(callback));
            StringFunctions.FreePinnedStrings(schemes_handles);
            StringFunctions.CfxStringListCopyToManaged(schemes_unwrapped, schemes);
            CfxApi.cfx_string_list_free(schemes_unwrapped);
        }

        /// <summary>
        /// Visit all cookies on the IO thread. The returned cookies are ordered by
        /// longest path, then by earliest creation date. Returns false (0) if cookies
        /// cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool VisitAllCookies(CfxCookieVisitor visitor) {
            return 0 != CfxApi.cfx_cookie_manager_visit_all_cookies(NativePtr, CfxCookieVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Visit a subset of cookies on the IO thread. The results are filtered by the
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
            var __retval = CfxApi.cfx_cookie_manager_visit_url_cookies(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, includeHttpOnly ? 1 : 0, CfxCookieVisitor.Unwrap(visitor));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Sets a cookie given a valid URL and explicit user-provided cookie
        /// attributes. This function expects each attribute to be well-formed. It will
        /// check for disallowed characters (e.g. the ';' character is disallowed
        /// within the cookie value attribute) and fail without setting the cookie if
        /// such characters are found. If |callback| is non-NULL it will be executed
        /// asnychronously on the IO thread after the cookie has been set. Returns
        /// false (0) if an invalid URL is specified or if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool SetCookie(string url, CfxCookie cookie, CfxSetCookieCallback callback) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.cfx_cookie_manager_set_cookie(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxCookie.Unwrap(cookie), CfxSetCookieCallback.Unwrap(callback));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Delete all cookies that match the specified parameters. If both |url| and
        /// |cookieName| values are specified all host and domain cookies matching
        /// both will be deleted. If only |url| is specified all host cookies (but not
        /// domain cookies) irrespective of path will be deleted. If |url| is NULL all
        /// cookies for all hosts and domains will be deleted. If |callback| is non-
        /// NULL it will be executed asnychronously on the IO thread after the cookies
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
            var __retval = CfxApi.cfx_cookie_manager_delete_cookies(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, cookieName_pinned.Obj.PinnedPtr, cookieName_pinned.Length, CfxDeleteCookiesCallback.Unwrap(callback));
            url_pinned.Obj.Free();
            cookieName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Sets the directory path that will be used for storing cookie data. If
        /// |path| is NULL data will be stored in memory only. Otherwise, data will be
        /// stored at the specified |path|. To persist session cookies (cookies without
        /// an expiry date or validity interval) set |persistSessionCookies| to true
        /// (1). Session cookies are generally intended to be transient and most Web
        /// browsers do not persist them. If |callback| is non-NULL it will be executed
        /// asnychronously on the IO thread after the manager's storage has been
        /// initialized. Returns false (0) if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool SetStoragePath(string path, bool persistSessionCookies, CfxCompletionCallback callback) {
            var path_pinned = new PinnedString(path);
            var __retval = CfxApi.cfx_cookie_manager_set_storage_path(NativePtr, path_pinned.Obj.PinnedPtr, path_pinned.Length, persistSessionCookies ? 1 : 0, CfxCompletionCallback.Unwrap(callback));
            path_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Flush the backing store (if any) to disk. If |callback| is non-NULL it will
        /// be executed asnychronously on the IO thread after the flush is complete.
        /// Returns false (0) if cookies cannot be accessed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public bool FlushStore(CfxCompletionCallback callback) {
            return 0 != CfxApi.cfx_cookie_manager_flush_store(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
