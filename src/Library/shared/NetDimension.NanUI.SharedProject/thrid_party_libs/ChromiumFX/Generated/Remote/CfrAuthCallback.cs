// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Callback structure used for asynchronous continuation of authentication
    /// requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
    /// </remarks>
    public class CfrAuthCallback : CfrBaseLibrary {

        internal static CfrAuthCallback Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrAuthCallback)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrAuthCallback(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }



        private CfrAuthCallback(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Continue the authentication request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
        /// </remarks>
        public void Continue(string userName, string password) {
            var connection = RemotePtr.connection;
            var call = new CfxAuthCallbackContinueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.userName = userName;
            call.password = password;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Cancel the authentication request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            var connection = RemotePtr.connection;
            var call = new CfxAuthCallbackCancelRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }
    }
}
