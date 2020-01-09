// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure that manages custom scheme registrations.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
    /// </remarks>
    public class CfrSchemeRegistrar : CfrBaseScoped {

        internal static CfrSchemeRegistrar Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            return new CfrSchemeRegistrar(remotePtr);
        }



        private CfrSchemeRegistrar(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Register a custom scheme. This function should not be called for the built-
        /// in HTTP, HTTPS, FILE, FTP, ABOUT and DATA schemes.
        /// 
        /// See CfrSchemeOptions for possible values for |options|.
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
            var connection = RemotePtr.connection;
            var call = new CfxSchemeRegistrarAddCustomSchemeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.schemeName = schemeName;
            call.options = options;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
