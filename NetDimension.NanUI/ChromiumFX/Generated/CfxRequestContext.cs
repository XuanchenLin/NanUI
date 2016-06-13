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
	/// A request context provides request handling for a set of related browser or
	/// URL request objects. A request context can be specified when creating a new
	/// browser via the CfxBrowserHost static factory functions or when creating
	/// a new URL request via the CfxUrlRequest static factory functions. Browser
	/// objects with different request contexts will never be hosted in the same
	/// render process. Browser objects with the same request context may or may not
	/// be hosted in the same render process depending on the process model. Browser
	/// objects created indirectly via the JavaScript window.open function or
	/// targeted links will share the same render process and the same request
	/// context as the source browser. When running in single-process mode there is
	/// only a single render process (the main process) and so all browsers created
	/// in single-process mode will share the same request context. This will be the
	/// first request context passed into a CfxBrowserHost static factory
	/// function and all other request context objects will be ignored.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
	/// </remarks>
	public class CfxRequestContext : CfxBase {

        static CfxRequestContext () {
            CfxApiLoader.LoadCfxRequestContextApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxRequestContext Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxRequestContext)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxRequestContext(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxRequestContext(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the global context object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public static CfxRequestContext GetGlobalContext() {
            return CfxRequestContext.Wrap(CfxApi.cfx_request_context_get_global_context());
        }

        /// <summary>
        /// Creates a new context object with the specified |settings| and optional
        /// |handler|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public static CfxRequestContext CreateContext(CfxRequestContextSettings settings, CfxRequestContextHandler handler) {
            return CfxRequestContext.Wrap(CfxApi.cfx_request_context_create_context(CfxRequestContextSettings.Unwrap(settings), CfxRequestContextHandler.Unwrap(handler)));
        }

        /// <summary>
        /// Returns true (1) if this object is the global context. The global context
        /// is used by default when creating a browser or URL request with a NULL
        /// context argument.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool IsGlobal {
            get {
                return 0 != CfxApi.cfx_request_context_is_global(NativePtr);
            }
        }

        /// <summary>
        /// Returns the handler for this context if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxRequestContextHandler Handler {
            get {
                return CfxRequestContextHandler.Wrap(CfxApi.cfx_request_context_get_handler(NativePtr));
            }
        }

        /// <summary>
        /// Returns the cache path for this object. If NULL an "incognito mode" in-
        /// memory cache is being used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public string CachePath {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_request_context_get_cache_path(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same context as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxRequestContext other) {
            return 0 != CfxApi.cfx_request_context_is_same(NativePtr, CfxRequestContext.Unwrap(other));
        }

        /// <summary>
        /// Returns true (1) if this object is sharing the same storage as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool IsSharingWith(CfxRequestContext other) {
            return 0 != CfxApi.cfx_request_context_is_sharing_with(NativePtr, CfxRequestContext.Unwrap(other));
        }

        /// <summary>
        /// Returns the default cookie manager for this object. This will be the global
        /// cookie manager if this object is the global request context. Otherwise,
        /// this will be the default cookie manager used when this request context does
        /// not receive a value via CfxRequestContextHandler.GetCookieManager().
        /// If |callback| is non-NULL it will be executed asnychronously on the IO
        /// thread after the manager's storage has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxCookieManager GetDefaultCookieManager(CfxCompletionCallback callback) {
            return CfxCookieManager.Wrap(CfxApi.cfx_request_context_get_default_cookie_manager(NativePtr, CfxCompletionCallback.Unwrap(callback)));
        }

        /// <summary>
        /// Register a scheme handler factory for the specified |schemeName| and
        /// optional |domainName|. An NULL |domainName| value for a standard scheme
        /// will cause the factory to match all domain names. The |domainName| value
        /// will be ignored for non-standard schemes. If |schemeName| is a built-in
        /// scheme and no handler is returned by |factory| then the built-in scheme
        /// handler factory will be called. If |schemeName| is a custom scheme then
        /// you must also implement the CfxApp.OnRegisterCustomSchemes()
        /// function in all processes. This function may be called multiple times to
        /// change or remove the factory that matches the specified |schemeName| and
        /// optional |domainName|. Returns false (0) if an error occurs. This function
        /// may be called on any thread in the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool RegisterSchemeHandlerFactory(string schemeName, string domainName, CfxSchemeHandlerFactory factory) {
            var schemeName_pinned = new PinnedString(schemeName);
            var domainName_pinned = new PinnedString(domainName);
            var __retval = CfxApi.cfx_request_context_register_scheme_handler_factory(NativePtr, schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, domainName_pinned.Obj.PinnedPtr, domainName_pinned.Length, CfxSchemeHandlerFactory.Unwrap(factory));
            schemeName_pinned.Obj.Free();
            domainName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Clear all registered scheme handler factories. Returns false (0) on error.
        /// This function may be called on any thread in the browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool ClearSchemeHandlerFactories() {
            return 0 != CfxApi.cfx_request_context_clear_scheme_handler_factories(NativePtr);
        }

        /// <summary>
        /// Tells all renderer processes associated with this context to throw away
        /// their plugin list cache. If |reloadPages| is true (1) they will also
        /// reload all pages with plugins.
        /// CfxRequestContextHandler.OnBeforePluginLoad may be called to rebuild
        /// the plugin list cache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void PurgePluginListCache(bool reloadPages) {
            CfxApi.cfx_request_context_purge_plugin_list_cache(NativePtr, reloadPages ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if a preference with the specified |name| exists. This
        /// function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool HasPreference(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.cfx_request_context_has_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the value for the preference with the specified |name|. Returns
        /// NULL if the preference does not exist. The returned object contains a copy
        /// of the underlying preference value and modifications to the returned object
        /// will not modify the underlying preference value. This function must be
        /// called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxValue GetPreference(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.cfx_request_context_get_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return CfxValue.Wrap(__retval);
        }

        /// <summary>
        /// Returns all preferences as a dictionary. If |includeDefaults| is true (1)
        /// then preferences currently at their default value will be included. The
        /// returned object contains a copy of the underlying preference values and
        /// modifications to the returned object will not modify the underlying
        /// preference values. This function must be called on the browser process UI
        /// thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxDictionaryValue GetAllPreferences(bool includeDefaults) {
            return CfxDictionaryValue.Wrap(CfxApi.cfx_request_context_get_all_preferences(NativePtr, includeDefaults ? 1 : 0));
        }

        /// <summary>
        /// Returns true (1) if the preference with the specified |name| can be
        /// modified using SetPreference. As one example preferences set via the
        /// command-line usually cannot be modified. This function must be called on
        /// the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool CanSetPreference(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.cfx_request_context_can_set_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Set the |value| associated with preference |name|. Returns true (1) if the
        /// value is set successfully and false (0) otherwise. If |value| is NULL the
        /// preference will be restored to its default value. If setting the preference
        /// fails then |error| will be populated with a detailed description of the
        /// problem. This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool SetPreference(string name, CfxValue value, ref string error) {
            var name_pinned = new PinnedString(name);
            var error_pinned = new PinnedString(error);
            IntPtr error_str = error_pinned.Obj.PinnedPtr;
            int error_length = error_pinned.Length;
            var __retval = CfxApi.cfx_request_context_set_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length, CfxValue.Unwrap(value), ref error_str, ref error_length);
            name_pinned.Obj.Free();
            if(error_str != error_pinned.Obj.PinnedPtr) {
                if(error_length > 0) {
                    error = System.Runtime.InteropServices.Marshal.PtrToStringUni(error_str, error_length);
                    // free the native string?
                } else {
                    error = null;
                }
            }
            error_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Clears all certificate exceptions that were added as part of handling
        /// CfxRequestHandler.OnCertificateError(). If you call this it is
        /// recommended that you also call close_all_connections() or you risk not
        /// being prompted again for server certificates if you reconnect quickly. If
        /// |callback| is non-NULL it will be executed on the UI thread after
        /// completion.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void ClearCertificateExceptions(CfxCompletionCallback callback) {
            CfxApi.cfx_request_context_clear_certificate_exceptions(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }

        /// <summary>
        /// Clears all active and idle connections that Chromium currently has. This is
        /// only recommended if you have released all other CEF objects but don't yet
        /// want to call cef_shutdown(). If |callback| is non-NULL it will be executed
        /// on the UI thread after completion.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void CloseAllConnections(CfxCompletionCallback callback) {
            CfxApi.cfx_request_context_close_all_connections(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }

        /// <summary>
        /// Attempts to resolve |origin| to a list of associated IP addresses.
        /// |callback| will be executed on the UI thread after completion.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void ResolveHost(string origin, CfxResolveCallback callback) {
            var origin_pinned = new PinnedString(origin);
            CfxApi.cfx_request_context_resolve_host(NativePtr, origin_pinned.Obj.PinnedPtr, origin_pinned.Length, CfxResolveCallback.Unwrap(callback));
            origin_pinned.Obj.Free();
        }

        /// <summary>
        /// Attempts to resolve |origin| to a list of associated IP addresses using
        /// cached data. |resolvedIps| will be populated with the list of resolved IP
        /// addresses or NULL if no cached data is available. Returns ERR_NONE on
        /// success. This function must be called on the browser process IO thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxErrorCode ResolveHostCached(string origin, System.Collections.Generic.List<string> resolvedIps) {
            var origin_pinned = new PinnedString(origin);
            PinnedString[] resolvedIps_handles;
            var resolvedIps_unwrapped = StringFunctions.UnwrapCfxStringList(resolvedIps, out resolvedIps_handles);
            var __retval = CfxApi.cfx_request_context_resolve_host_cached(NativePtr, origin_pinned.Obj.PinnedPtr, origin_pinned.Length, resolvedIps_unwrapped);
            origin_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(resolvedIps_handles);
            StringFunctions.CfxStringListCopyToManaged(resolvedIps_unwrapped, resolvedIps);
            CfxApi.cfx_string_list_free(resolvedIps_unwrapped);
            return (CfxErrorCode)__retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
