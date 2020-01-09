// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing a X.509 certificate.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
    /// </remarks>
    public class CfxX509Certificate : CfxBaseLibrary {

        internal static CfxX509Certificate Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxX509Certificate)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxX509Certificate(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxX509Certificate(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the subject of the X.509 certificate. For HTTPS server certificates
        /// this represents the web server.  The common name of the subject should
        /// match the host name of the web server.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxX509CertPrincipal Subject {
            get {
                return CfxX509CertPrincipal.Wrap(CfxApi.X509Certificate.cfx_x509certificate_get_subject(NativePtr));
            }
        }

        /// <summary>
        /// Returns the issuer of the X.509 certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxX509CertPrincipal Issuer {
            get {
                return CfxX509CertPrincipal.Wrap(CfxApi.X509Certificate.cfx_x509certificate_get_issuer(NativePtr));
            }
        }

        /// <summary>
        /// Returns the DER encoded serial number for the X.509 certificate. The value
        /// possibly includes a leading 00 byte.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue SerialNumber {
            get {
                return CfxBinaryValue.Wrap(CfxApi.X509Certificate.cfx_x509certificate_get_serial_number(NativePtr));
            }
        }

        /// <summary>
        /// Returns the date before which the X.509 certificate is invalid.
        /// CfxTime.GetTimeT() will return 0 if no date was specified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxTime ValidStart {
            get {
                var __retval = CfxApi.X509Certificate.cfx_x509certificate_get_valid_start(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxTime.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Returns the date after which the X.509 certificate is invalid.
        /// CfxTime.GetTimeT() will return 0 if no date was specified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxTime ValidExpiry {
            get {
                var __retval = CfxApi.X509Certificate.cfx_x509certificate_get_valid_expiry(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxTime.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Returns the DER encoded data for the X.509 certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue DerEncoded {
            get {
                return CfxBinaryValue.Wrap(CfxApi.X509Certificate.cfx_x509certificate_get_derencoded(NativePtr));
            }
        }

        /// <summary>
        /// Returns the PEM encoded data for the X.509 certificate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue PemEncoded {
            get {
                return CfxBinaryValue.Wrap(CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded(NativePtr));
            }
        }

        /// <summary>
        /// Returns the number of certificates in the issuer chain. If 0, the
        /// certificate is self-signed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public ulong IssuerChainSize {
            get {
                return (ulong)CfxApi.X509Certificate.cfx_x509certificate_get_issuer_chain_size(NativePtr);
            }
        }

        /// <summary>
        /// Returns the DER encoded data for the certificate issuer chain. If we failed
        /// to encode a certificate in the chain it is still present in the array but
        /// is an NULL string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue[] DerEncodedIssuerChain {
            get {
                var count = IssuerChainSize;
                if(count == 0) return new CfxBinaryValue[0];
                IntPtr[] ptrs = new IntPtr[count];
                var ptrs_p = new PinnedObject(ptrs);
                CfxApi.X509Certificate.cfx_x509certificate_get_derencoded_issuer_chain(NativePtr, (UIntPtr)count, ptrs_p.PinnedPtr);
                ptrs_p.Free();
                CfxBinaryValue[] retval = new CfxBinaryValue[count];
                for(ulong i = 0; i < count; ++i) {
                    retval[i] = CfxBinaryValue.Wrap(ptrs[i]);
                }
                return retval;
            }
        }

        /// <summary>
        /// Returns the PEM encoded data for the certificate issuer chain. If we failed
        /// to encode a certificate in the chain it is still present in the array but
        /// is an NULL string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue[] PemEncodedIssuerChain {
            get {
                var count = IssuerChainSize;
                if(count == 0) return new CfxBinaryValue[0];
                IntPtr[] ptrs = new IntPtr[count];
                var ptrs_p = new PinnedObject(ptrs);
                CfxApi.X509Certificate.cfx_x509certificate_get_pemencoded_issuer_chain(NativePtr, (UIntPtr)count, ptrs_p.PinnedPtr);
                ptrs_p.Free();
                CfxBinaryValue[] retval = new CfxBinaryValue[count];
                for(ulong i = 0; i < count; ++i) {
                    retval[i] = CfxBinaryValue.Wrap(ptrs[i]);
                }
                return retval;
            }
        }
    }
}
