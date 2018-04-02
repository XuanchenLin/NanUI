// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Generic callback structure used for asynchronous continuation.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
    /// </remarks>
    public class CfrCallback : CfrBaseLibrary {

        internal static CfrCallback Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrCallback)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrCallback(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }



        private CfrCallback(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Continue processing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
        /// </remarks>
        public void Continue() {
            var connection = RemotePtr.connection;
            var call = new CfxCallbackContinueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Cancel processing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_callback_capi.h">cef/include/capi/cef_callback_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            var connection = RemotePtr.connection;
            var call = new CfxCallbackCancelRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }
    }
}
