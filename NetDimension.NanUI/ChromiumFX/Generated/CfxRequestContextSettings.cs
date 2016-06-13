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
	/// Request context initialization settings. Specify NULL or 0 to get the
	/// recommended default values.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxRequestContextSettings : CfxStructure {

        static CfxRequestContextSettings () {
            CfxApiLoader.LoadCfxRequestContextSettingsApi();
        }

        public CfxRequestContextSettings() : base(CfxApi.cfx_request_context_settings_ctor, CfxApi.cfx_request_context_settings_dtor) {}

        /// <summary>
        /// The location where cache data will be stored on disk. If empty then
        /// browsers will be created in "incognito mode" where in-memory caches are
        /// used for storage and no data is persisted to disk. HTML5 databases such as
        /// localStorage will only persist across sessions if a cache path is
        /// specified. To share the global browser cache and related configuration set
        /// this value to match the CfxSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string CachePath {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_request_context_settings_get_cache_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_request_context_settings_set_cache_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// To persist session cookies (cookies without an expiry date or validity
        /// interval) by default when using the global cookie manager set this value to
        /// true (1). Session cookies are generally intended to be transient and most
        /// Web browsers do not persist them. Can be set globally using the
        /// CfxSettings.PersistSessionCookies value. This value will be ignored if
        /// |cachePath| is empty or if it matches the CfxSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool PersistSessionCookies {
            get {
                int value;
                CfxApi.cfx_request_context_settings_get_persist_session_cookies(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_request_context_settings_set_persist_session_cookies(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// To persist user preferences as a JSON file in the cache path directory set
        /// this value to true (1). Can be set globally using the
        /// CfxSettings.PersistUserPreferences value. This value will be ignored if
        /// |cachePath| is empty or if it matches the CfxSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool PersistUserPreferences {
            get {
                int value;
                CfxApi.cfx_request_context_settings_get_persist_user_preferences(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_request_context_settings_set_persist_user_preferences(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Set to true (1) to ignore errors related to invalid SSL certificates.
        /// Enabling this setting can lead to potential security vulnerabilities like
        /// "man in the middle" attacks. Applications that load content from the
        /// internet should not enable this setting. Can be set globally using the
        /// CfxSettings.IgnoreCertificateErrors value. This value will be ignored if
        /// |cachePath| matches the CfxSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool IgnoreCertificateErrors {
            get {
                int value;
                CfxApi.cfx_request_context_settings_get_ignore_certificate_errors(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.cfx_request_context_settings_set_ignore_certificate_errors(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// Comma delimited ordered list of language codes without any whitespace that
        /// will be used in the "Accept-Language" HTTP header. Can be set globally
        /// using the CfxSettings.AcceptLanguageList value or overridden on a per-
        /// browser basis using the CfxBrowserSettings.AcceptLanguageList value. If
        /// all values are empty then "en-US,en" will be used. This value will be
        /// ignored if |cachePath| matches the CfxSettings.CachePath value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string AcceptLanguageList {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.cfx_request_context_settings_get_accept_language_list(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_request_context_settings_set_accept_language_list(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

    }
}
