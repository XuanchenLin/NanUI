// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure that manages custom scheme registrations.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
    /// </remarks>
    public class CfxSchemeRegistrar : CfxBaseScoped {

        internal static CfxSchemeRegistrar Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxSchemeRegistrar(nativePtr);
        }


        internal CfxSchemeRegistrar(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Register a custom scheme. This function should not be called for the built-
        /// in HTTP, HTTPS, FILE, FTP, ABOUT and DATA schemes.
        /// 
        /// See CfxSchemeOptions for possible values for |options|.
        /// 
        /// This function may be called on any thread. It should only be called once
        /// per unique |schemeName| value. If |schemeName| is already registered or
        /// if an error occurs this function will return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public bool AddCustomScheme(string schemeName, int options) {
            var schemeName_pinned = new PinnedString(schemeName);
            var __retval = CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme(NativePtr, schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, options);
            schemeName_pinned.Obj.Free();
            return 0 != __retval;
        }
    }
}
