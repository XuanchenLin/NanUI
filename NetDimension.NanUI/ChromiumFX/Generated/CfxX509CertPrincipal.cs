// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing the issuer or subject field of an X.509 certificate.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
    /// </remarks>
    public class CfxX509CertPrincipal : CfxBaseLibrary {

        internal static CfxX509CertPrincipal Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxX509CertPrincipal)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxX509CertPrincipal(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxX509CertPrincipal(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns a name that can be used to represent the issuer. It tries in this
        /// order: Common Name (CN), Organization Name (O) and Organizational Unit Name
        /// (OU) and returns the first non-NULL one found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public string DisplayName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_display_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the common name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public string CommonName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_common_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the locality name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public string LocalityName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_locality_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the state or province name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public string StateOrProvinceName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_state_or_province_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the country name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public string CountryName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_country_name(NativePtr));
            }
        }

        /// <summary>
        /// Retrieve the list of street addresses.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetStreetAddresses() {
            System.Collections.Generic.List<string> addresses = new System.Collections.Generic.List<string>();
            PinnedString[] addresses_handles;
            var addresses_unwrapped = StringFunctions.UnwrapCfxStringList(addresses, out addresses_handles);
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_street_addresses(NativePtr, addresses_unwrapped);
            StringFunctions.FreePinnedStrings(addresses_handles);
            StringFunctions.CfxStringListCopyToManaged(addresses_unwrapped, addresses);
            CfxApi.Runtime.cfx_string_list_free(addresses_unwrapped);
            return addresses;
        }

        /// <summary>
        /// Retrieve the list of organization names.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetOrganizationNames() {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.Runtime.cfx_string_list_free(names_unwrapped);
            return names;
        }

        /// <summary>
        /// Retrieve the list of organization unit names.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetOrganizationUnitNames() {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_organization_unit_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.Runtime.cfx_string_list_free(names_unwrapped);
            return names;
        }

        /// <summary>
        /// Retrieve the list of domain components.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_x509_certificate_capi.h">cef/include/capi/cef_x509_certificate_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetDomainComponents() {
            System.Collections.Generic.List<string> components = new System.Collections.Generic.List<string>();
            PinnedString[] components_handles;
            var components_unwrapped = StringFunctions.UnwrapCfxStringList(components, out components_handles);
            CfxApi.X509CertPrincipal.cfx_x509cert_principal_get_domain_components(NativePtr, components_unwrapped);
            StringFunctions.FreePinnedStrings(components_handles);
            StringFunctions.CfxStringListCopyToManaged(components_unwrapped, components);
            CfxApi.Runtime.cfx_string_list_free(components_unwrapped);
            return components;
        }
    }
}
