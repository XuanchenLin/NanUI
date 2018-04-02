// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing the SSL information for a navigation entry.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
    /// </remarks>
    public class CfxSslStatus : CfxBaseLibrary {

        internal static CfxSslStatus Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxSslStatus)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxSslStatus(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxSslStatus(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns true (1) if the status is related to a secure SSL/TLS connection.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
        /// </remarks>
        public bool IsSecureConnection {
            get {
                return 0 != CfxApi.SslStatus.cfx_sslstatus_is_secure_connection(NativePtr);
            }
        }

        /// <summary>
        /// Returns a bitmask containing any and all problems verifying the server
        /// certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
        /// </remarks>
        public CfxCertStatus CertStatus {
            get {
                return (CfxCertStatus)CfxApi.SslStatus.cfx_sslstatus_get_cert_status(NativePtr);
            }
        }

        /// <summary>
        /// Returns the SSL version used for the SSL connection.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
        /// </remarks>
        public CfxSslVersion SslVersion {
            get {
                return (CfxSslVersion)CfxApi.SslStatus.cfx_sslstatus_get_sslversion(NativePtr);
            }
        }

        /// <summary>
        /// Returns a bitmask containing the page security content status.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
        /// </remarks>
        public CfxSslContentStatus ContentStatus {
            get {
                return (CfxSslContentStatus)CfxApi.SslStatus.cfx_sslstatus_get_content_status(NativePtr);
            }
        }

        /// <summary>
        /// Returns the X.509 certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_status_capi.h">cef/include/capi/cef_ssl_status_capi.h</see>.
        /// </remarks>
        public CfxX509Certificate X509Certificate {
            get {
                return CfxX509Certificate.Wrap(CfxApi.SslStatus.cfx_sslstatus_get_x509certificate(NativePtr));
            }
        }
    }
}
