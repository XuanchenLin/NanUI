// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Information about a specific web plugin.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
    /// </remarks>
    public class CfxWebPluginInfo : CfxBaseLibrary {

        internal static CfxWebPluginInfo Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxWebPluginInfo)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxWebPluginInfo(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxWebPluginInfo(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the plugin name (i.e. Flash).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public string Name {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the plugin file path (DLL/bundle/library).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public string Path {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_path(NativePtr));
            }
        }

        /// <summary>
        /// Returns the version of the plugin (may be OS-specific).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public string Version {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_version(NativePtr));
            }
        }

        /// <summary>
        /// Returns a description of the plugin from the version information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public string Description {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.WebPluginInfo.cfx_web_plugin_info_get_description(NativePtr));
            }
        }
    }
}
