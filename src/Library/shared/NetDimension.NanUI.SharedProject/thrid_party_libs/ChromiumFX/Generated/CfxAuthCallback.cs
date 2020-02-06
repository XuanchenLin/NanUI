// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used for asynchronous continuation of authentication
    /// requests.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
    /// </remarks>
    public class CfxAuthCallback : CfxBaseLibrary {

        internal static CfxAuthCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxAuthCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxAuthCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxAuthCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Continue the authentication request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
        /// </remarks>
        public void Continue(string userName, string password) {
            var userName_pinned = new PinnedString(userName);
            var password_pinned = new PinnedString(password);
            CfxApi.AuthCallback.cfx_auth_callback_cont(NativePtr, userName_pinned.Obj.PinnedPtr, userName_pinned.Length, password_pinned.Obj.PinnedPtr, password_pinned.Length);
            userName_pinned.Obj.Free();
            password_pinned.Obj.Free();
        }

        /// <summary>
        /// Cancel the authentication request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_auth_callback_capi.h">cef/include/capi/cef_auth_callback_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.AuthCallback.cfx_auth_callback_cancel(NativePtr);
        }
    }
}
