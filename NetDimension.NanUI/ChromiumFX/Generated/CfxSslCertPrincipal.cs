// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Structure representing the issuer or subject field of an X.509 certificate.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
	/// </remarks>
	public class CfxSslCertPrincipal : CfxBase {

        static CfxSslCertPrincipal () {
            CfxApiLoader.LoadCfxSslCertPrincipalApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxSslCertPrincipal Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxSslCertPrincipal)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxSslCertPrincipal(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxSslCertPrincipal(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns a name that can be used to represent the issuer.  It tries in this
        /// order: CN, O and OU and returns the first non-NULL one found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public string DisplayName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_sslcert_principal_get_display_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the common name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public string CommonName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_sslcert_principal_get_common_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the locality name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public string LocalityName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_sslcert_principal_get_locality_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the state or province name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public string StateOrProvinceName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_sslcert_principal_get_state_or_province_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the country name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public string CountryName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_sslcert_principal_get_country_name(NativePtr));
            }
        }

        /// <summary>
        /// Retrieve the list of street addresses.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetStreetAddresses() {
            System.Collections.Generic.List<string> addresses = new System.Collections.Generic.List<string>();
            PinnedString[] addresses_handles;
            var addresses_unwrapped = StringFunctions.UnwrapCfxStringList(addresses, out addresses_handles);
            CfxApi.cfx_sslcert_principal_get_street_addresses(NativePtr, addresses_unwrapped);
            StringFunctions.FreePinnedStrings(addresses_handles);
            StringFunctions.CfxStringListCopyToManaged(addresses_unwrapped, addresses);
            CfxApi.cfx_string_list_free(addresses_unwrapped);
            return addresses;
        }

        /// <summary>
        /// Retrieve the list of organization names.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetOrganizationNames() {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            CfxApi.cfx_sslcert_principal_get_organization_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.cfx_string_list_free(names_unwrapped);
            return names;
        }

        /// <summary>
        /// Retrieve the list of organization unit names.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetOrganizationUnitNames() {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            CfxApi.cfx_sslcert_principal_get_organization_unit_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.cfx_string_list_free(names_unwrapped);
            return names;
        }

        /// <summary>
        /// Retrieve the list of domain components.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_ssl_info_capi.h">cef/include/capi/cef_ssl_info_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetDomainComponents() {
            System.Collections.Generic.List<string> components = new System.Collections.Generic.List<string>();
            PinnedString[] components_handles;
            var components_unwrapped = StringFunctions.UnwrapCfxStringList(components, out components_handles);
            CfxApi.cfx_sslcert_principal_get_domain_components(NativePtr, components_unwrapped);
            StringFunctions.FreePinnedStrings(components_handles);
            StringFunctions.CfxStringListCopyToManaged(components_unwrapped, components);
            CfxApi.cfx_string_list_free(components_unwrapped);
            return components;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
