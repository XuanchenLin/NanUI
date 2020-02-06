// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing SSL information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
    /// </remarks>
    public class CfxSslInfo : CfxBaseLibrary {

        internal static CfxSslInfo Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxSslInfo)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxSslInfo(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxSslInfo(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns a bitmask containing any and all problems verifying the server
        /// certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public CfxCertStatus CertStatus {
            get {
                return (CfxCertStatus)CfxApi.SslInfo.cfx_sslinfo_get_cert_status(NativePtr);
            }
        }

        /// <summary>
        /// Returns the X.509 certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public CfxX509Certificate X509Certificate {
            get {
                return CfxX509Certificate.Wrap(CfxApi.SslInfo.cfx_sslinfo_get_x509certificate(NativePtr));
            }
        }
    }
}
