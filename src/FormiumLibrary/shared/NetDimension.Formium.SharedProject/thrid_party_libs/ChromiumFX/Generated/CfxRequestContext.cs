// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxRequestContext : CfxBaseLibrary {

        internal static CfxRequestContext Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxRequestContext)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxRequestContext(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
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
            return CfxRequestContext.Wrap(CfxApi.RequestContext.cfx_request_context_get_global_context());
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
            return CfxRequestContext.Wrap(CfxApi.RequestContext.cfx_request_context_create_context(CfxRequestContextSettings.Unwrap(settings), CfxRequestContextHandler.Unwrap(handler)));
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
                return 0 != CfxApi.RequestContext.cfx_request_context_is_global(NativePtr);
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
                return CfxRequestContextHandler.Wrap(CfxApi.RequestContext.cfx_request_context_get_handler(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.RequestContext.cfx_request_context_get_cache_path(NativePtr));
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
            return 0 != CfxApi.RequestContext.cfx_request_context_is_same(NativePtr, CfxRequestContext.Unwrap(other));
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
            return 0 != CfxApi.RequestContext.cfx_request_context_is_sharing_with(NativePtr, CfxRequestContext.Unwrap(other));
        }

        /// <summary>
        /// Returns the cookie manager for this object. If |callback| is non-NULL it
        /// will be executed asnychronously on the IO thread after the manager's
        /// storage has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxCookieManager GetCookieManager(CfxCompletionCallback callback) {
            return CfxCookieManager.Wrap(CfxApi.RequestContext.cfx_request_context_get_cookie_manager(NativePtr, CfxCompletionCallback.Unwrap(callback)));
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
            var __retval = CfxApi.RequestContext.cfx_request_context_register_scheme_handler_factory(NativePtr, schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, domainName_pinned.Obj.PinnedPtr, domainName_pinned.Length, CfxSchemeHandlerFactory.Unwrap(factory));
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
            return 0 != CfxApi.RequestContext.cfx_request_context_clear_scheme_handler_factories(NativePtr);
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
            CfxApi.RequestContext.cfx_request_context_purge_plugin_list_cache(NativePtr, reloadPages ? 1 : 0);
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
            var __retval = CfxApi.RequestContext.cfx_request_context_has_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
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
            var __retval = CfxApi.RequestContext.cfx_request_context_get_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
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
            return CfxDictionaryValue.Wrap(CfxApi.RequestContext.cfx_request_context_get_all_preferences(NativePtr, includeDefaults ? 1 : 0));
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
            var __retval = CfxApi.RequestContext.cfx_request_context_can_set_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
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
        public bool SetPreference(string name, CfxValue value, out string error) {
            var name_pinned = new PinnedString(name);
            IntPtr error_str;
            int error_length;
            var __retval = CfxApi.RequestContext.cfx_request_context_set_preference(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length, CfxValue.Unwrap(value), out error_str, out error_length);
            name_pinned.Obj.Free();
            if(error_length > 0) {
                error = System.Runtime.InteropServices.Marshal.PtrToStringUni(error_str, error_length);
                // free the native string?
            } else {
                error = null;
            }
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
            CfxApi.RequestContext.cfx_request_context_clear_certificate_exceptions(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }

        /// <summary>
        /// Clears all HTTP authentication credentials that were added as part of
        /// handling GetAuthCredentials. If |callback| is non-NULL it will be executed
        /// on the UI thread after completion.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void ClearHttpAuthCredentials(CfxCompletionCallback callback) {
            CfxApi.RequestContext.cfx_request_context_clear_http_auth_credentials(NativePtr, CfxCompletionCallback.Unwrap(callback));
        }

        /// <summary>
        /// Clears all active and idle connections that Chromium currently has. This is
        /// only recommended if you have released all other CEF objects but don't yet
        /// want to call Cfxshutdown(). If |callback| is non-NULL it will be executed
        /// on the UI thread after completion.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void CloseAllConnections(CfxCompletionCallback callback) {
            CfxApi.RequestContext.cfx_request_context_close_all_connections(NativePtr, CfxCompletionCallback.Unwrap(callback));
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
            CfxApi.RequestContext.cfx_request_context_resolve_host(NativePtr, origin_pinned.Obj.PinnedPtr, origin_pinned.Length, CfxResolveCallback.Unwrap(callback));
            origin_pinned.Obj.Free();
        }

        /// <summary>
        /// Load an extension.
        /// 
        /// If extension resources will be read from disk using the default load
        /// implementation then |rootDirectory| should be the absolute path to the
        /// extension resources directory and |manifest| should be NULL. If extension
        /// resources will be provided by the client (e.g. via CfxRequestHandler
        /// and/or CfxExtensionHandler) then |rootDirectory| should be a path
        /// component unique to the extension (if not absolute this will be internally
        /// prefixed with the PK_DIR_RESOURCES path) and |manifest| should contain the
        /// contents that would otherwise be read from the "manifest.json" file on
        /// disk.
        /// 
        /// The loaded extension will be accessible in all contexts sharing the same
        /// storage (HasExtension returns true (1)). However, only the context on which
        /// this function was called is considered the loader (DidLoadExtension returns
        /// true (1)) and only the loader will receive CfxRequestContextHandler
        /// callbacks for the extension.
        /// 
        /// CfxExtensionHandler.OnExtensionLoaded will be called on load success or
        /// CfxExtensionHandler.OnExtensionLoadFailed will be called on load
        /// failure.
        /// 
        /// If the extension specifies a background script via the "background"
        /// manifest key then CfxExtensionHandler.OnBeforeBackgroundBrowser will be
        /// called to create the background browser. See that function for additional
        /// information about background scripts.
        /// 
        /// For visible extension views the client application should evaluate the
        /// manifest to determine the correct extension URL to load and then pass that
        /// URL to the CfxBrowserHost.CreateBrowser* function after the extension
        /// has loaded. For example, the client can look for the "browser_action"
        /// manifest key as documented at
        /// https://developer.chrome.com/extensions/browserAction. Extension URLs take
        /// the form "chrome-extension://&lt;extension_id>/&lt;path>".
        /// 
        /// Browsers that host extensions differ from normal browsers as follows:
        ///  - Can access chrome.* JavaScript APIs if allowed by the manifest. Visit
        ///    chrome://extensions-support for the list of extension APIs currently
        ///    supported by CEF.
        ///  - Main frame navigation to non-extension content is blocked.
        ///  - Pinch-zooming is disabled.
        ///  - CfxBrowserHost.GetExtension returns the hosted extension.
        ///  - CfxBrowserHost.IsBackgroundHost returns true for background hosts.
        /// 
        /// See https://developer.chrome.com/extensions for extension implementation
        /// and usage documentation.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public void LoadExtension(string rootDirectory, CfxDictionaryValue manifest, CfxExtensionHandler handler) {
            var rootDirectory_pinned = new PinnedString(rootDirectory);
            CfxApi.RequestContext.cfx_request_context_load_extension(NativePtr, rootDirectory_pinned.Obj.PinnedPtr, rootDirectory_pinned.Length, CfxDictionaryValue.Unwrap(manifest), CfxExtensionHandler.Unwrap(handler));
            rootDirectory_pinned.Obj.Free();
        }

        /// <summary>
        /// Returns true (1) if this context was used to load the extension identified
        /// by |extensionId|. Other contexts sharing the same storage will also have
        /// access to the extension (see HasExtension). This function must be called on
        /// the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool DidLoadExtension(string extensionId) {
            var extensionId_pinned = new PinnedString(extensionId);
            var __retval = CfxApi.RequestContext.cfx_request_context_did_load_extension(NativePtr, extensionId_pinned.Obj.PinnedPtr, extensionId_pinned.Length);
            extensionId_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns true (1) if this context has access to the extension identified by
        /// |extensionId|. This may not be the context that was used to load the
        /// extension (see DidLoadExtension). This function must be called on the
        /// browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool HasExtension(string extensionId) {
            var extensionId_pinned = new PinnedString(extensionId);
            var __retval = CfxApi.RequestContext.cfx_request_context_has_extension(NativePtr, extensionId_pinned.Obj.PinnedPtr, extensionId_pinned.Length);
            extensionId_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Retrieve the list of all extensions that this context has access to (see
        /// HasExtension). |extensionIds| will be populated with the list of extension
        /// ID values. Returns true (1) on success. This function must be called on the
        /// browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public bool GetExtensions(System.Collections.Generic.List<string> extensionIds) {
            PinnedString[] extensionIds_handles;
            var extensionIds_unwrapped = StringFunctions.UnwrapCfxStringList(extensionIds, out extensionIds_handles);
            var __retval = CfxApi.RequestContext.cfx_request_context_get_extensions(NativePtr, extensionIds_unwrapped);
            StringFunctions.FreePinnedStrings(extensionIds_handles);
            StringFunctions.CfxStringListCopyToManaged(extensionIds_unwrapped, extensionIds);
            CfxApi.Runtime.cfx_string_list_free(extensionIds_unwrapped);
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the extension matching |extensionId| or NULL if no matching
        /// extension is accessible in this context (see HasExtension). This function
        /// must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public CfxExtension GetExtension(string extensionId) {
            var extensionId_pinned = new PinnedString(extensionId);
            var __retval = CfxApi.RequestContext.cfx_request_context_get_extension(NativePtr, extensionId_pinned.Obj.PinnedPtr, extensionId_pinned.Length);
            extensionId_pinned.Obj.Free();
            return CfxExtension.Wrap(__retval);
        }
    }
}
