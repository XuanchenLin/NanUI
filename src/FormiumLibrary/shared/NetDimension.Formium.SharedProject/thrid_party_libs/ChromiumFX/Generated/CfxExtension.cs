// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Object representing an extension. Methods may be called on any thread unless
    /// otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
    /// </remarks>
    public class CfxExtension : CfxBaseLibrary {

        internal static CfxExtension Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxExtension)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxExtension(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxExtension(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the unique extension identifier. This is calculated based on the
        /// extension public key, if available, or on the extension path. See
        /// https://developer.chrome.com/extensions/manifest/key for details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public string Identifier {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Extension.cfx_extension_get_identifier(NativePtr));
            }
        }

        /// <summary>
        /// Returns the absolute path to the extension directory on disk. This value
        /// will be prefixed with PK_DIR_RESOURCES if a relative path was passed to
        /// CfxRequestContext.LoadExtension.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public string Path {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Extension.cfx_extension_get_path(NativePtr));
            }
        }

        /// <summary>
        /// Returns the extension manifest contents as a CfxDictionaryValue object.
        /// See https://developer.chrome.com/extensions/manifest for details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public CfxDictionaryValue Manifest {
            get {
                return CfxDictionaryValue.Wrap(CfxApi.Extension.cfx_extension_get_manifest(NativePtr));
            }
        }

        /// <summary>
        /// Returns the handler for this extension. Will return NULL for internal
        /// extensions or if no handler was passed to
        /// CfxRequestContext.LoadExtension.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public CfxExtensionHandler Handler {
            get {
                return CfxExtensionHandler.Wrap(CfxApi.Extension.cfx_extension_get_handler(NativePtr));
            }
        }

        /// <summary>
        /// Returns the request context that loaded this extension. Will return NULL
        /// for internal extensions or if the extension has been unloaded. See the
        /// CfxRequestContext.LoadExtension documentation for more information
        /// about loader contexts. Must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public CfxRequestContext LoaderContext {
            get {
                return CfxRequestContext.Wrap(CfxApi.Extension.cfx_extension_get_loader_context(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this extension is currently loaded. Must be called on
        /// the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public bool IsLoaded {
            get {
                return 0 != CfxApi.Extension.cfx_extension_is_loaded(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this object is the same extension as |that| object.
        /// Extensions are considered the same if identifier, path and loader context
        /// match.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxExtension that) {
            return 0 != CfxApi.Extension.cfx_extension_is_same(NativePtr, CfxExtension.Unwrap(that));
        }

        /// <summary>
        /// Unload this extension if it is not an internal extension and is currently
        /// loaded. Will result in a call to
        /// CfxExtensionHandler.OnExtensionUnloaded on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_capi.h">cef/include/capi/cef_extension_capi.h</see>.
        /// </remarks>
        public void Unload() {
            CfxApi.Extension.cfx_extension_unload(NativePtr);
        }
    }
}
