// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Callback structure used to select a client certificate for authentication.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
    /// </remarks>
    public class CfxSelectClientCertificateCallback : CfxBaseLibrary {

        internal static CfxSelectClientCertificateCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxSelectClientCertificateCallback)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxSelectClientCertificateCallback(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxSelectClientCertificateCallback(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Chooses the specified certificate for client certificate authentication.
        /// NULL value means that no client certificate should be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_handler_capi.h">cef/include/capi/cef_request_handler_capi.h</see>.
        /// </remarks>
        public void Select(CfxX509Certificate cert) {
            CfxApi.SelectClientCertificateCallback.cfx_select_client_certificate_callback_select(NativePtr, CfxX509Certificate.Unwrap(cert));
        }
    }
}
