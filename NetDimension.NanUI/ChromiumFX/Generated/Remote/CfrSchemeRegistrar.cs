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

namespace Chromium.Remote
{

	/// <summary>
	/// Structure that manages custom scheme registrations.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
	/// </remarks>
	public class CfrSchemeRegistrar : CfrBase {

        internal static CfrSchemeRegistrar Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrSchemeRegistrar)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrSchemeRegistrar(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }



        private CfrSchemeRegistrar(IntPtr proxyId) : base(proxyId) {}

        /// <summary>
        /// Register a custom scheme. This function should not be called for the built-
        /// in HTTP, HTTPS, FILE, FTP, ABOUT and DATA schemes.
        /// If |isStandard| is true (1) the scheme will be treated as a standard
        /// scheme. Standard schemes are subject to URL canonicalization and parsing
        /// rules as defined in the Common Internet Scheme Syntax RFC 1738 Section 3.1
        /// available at http://www.ietf.org/rfc/rfc1738.txt
        /// In particular, the syntax for standard scheme URLs must be of the form:
        /// &lt;pre>
        /// [scheme]://[username]:[password]@[host]:[port]/[url-path]
        /// &lt;/pre> Standard scheme URLs must have a host component that is a fully
        /// qualified domain name as defined in Section 3.5 of RFC 1034 [13] and
        /// Section 2.1 of RFC 1123. These URLs will be canonicalized to
        /// "scheme://host/path" in the simplest case and
        /// "scheme://username:password@host:port/path" in the most explicit case. For
        /// example, "scheme:host/path" and "scheme:///host/path" will both be
        /// canonicalized to "scheme://host/path". The origin of a standard scheme URL
        /// is the combination of scheme, host and port (i.e., "scheme://host:port" in
        /// the most explicit case).
        /// For non-standard scheme URLs only the "scheme:" component is parsed and
        /// canonicalized. The remainder of the URL will be passed to the handler as-
        /// is. For example, "scheme:///some%20text" will remain the same. Non-standard
        /// scheme URLs cannot be used as a target for form submission.
        /// If |isLocal| is true (1) the scheme will be treated as local (i.e., with
        /// the same security rules as those applied to "file" URLs). Normal pages
        /// cannot link to or access local URLs. Also, by default, local URLs can only
        /// perform XMLHttpRequest calls to the same URL (origin + path) that
        /// originated the request. To allow XMLHttpRequest calls from a local URL to
        /// other URLs with the same origin set the
        /// CfrSettings.FileAccessFromFileUrlsAllowed value to true (1). To allow
        /// XMLHttpRequest calls from a local URL to all origins set the
        /// CfrSettings.UniversalAccessFromFileUrlsAllowed value to true (1).
        /// If |isDisplayIsolated| is true (1) the scheme will be treated as display-
        /// isolated. This means that pages cannot display these URLs unless they are
        /// from the same scheme. For example, pages in another origin cannot create
        /// iframes or hyperlinks to URLs with this scheme.
        /// This function may be called on any thread. It should only be called once
        /// per unique |schemeName| value. If |schemeName| is already registered or
        /// if an error occurs this function will return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_scheme_capi.h">cef/include/capi/cef_scheme_capi.h</see>.
        /// </remarks>
        public bool AddCustomScheme(string schemeName, bool isStandard, bool isLocal, bool isDisplayIsolated) {
            var call = new CfxSchemeRegistrarAddCustomSchemeRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.schemeName = schemeName;
            call.isStandard = isStandard;
            call.isLocal = isLocal;
            call.isDisplayIsolated = isDisplayIsolated;
            call.RequestExecution(this);
            return call.__retval;
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
