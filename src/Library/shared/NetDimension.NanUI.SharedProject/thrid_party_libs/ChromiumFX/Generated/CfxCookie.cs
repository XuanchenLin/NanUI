// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Cookie information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxCookie : CfxStructure {

        internal static CfxCookie Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxCookie(nativePtr);
        }

        internal static CfxCookie WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxCookie(nativePtr, CfxApi.Cookie.cfx_cookie_dtor);
        }

        public CfxCookie() : base(CfxApi.Cookie.cfx_cookie_ctor, CfxApi.Cookie.cfx_cookie_dtor) {}
        internal CfxCookie(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxCookie(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        /// <summary>
        /// The cookie name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string Name {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.Cookie.cfx_cookie_get_name(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Cookie.cfx_cookie_set_name(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// The cookie value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string Value {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.Cookie.cfx_cookie_get_value(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Cookie.cfx_cookie_set_value(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// If |domain| is empty a host cookie will be created instead of a domain
        /// cookie. Domain cookies are stored with a leading "." and are visible to
        /// sub-domains whereas host cookies are not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string Domain {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.Cookie.cfx_cookie_get_domain(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Cookie.cfx_cookie_set_domain(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// If |path| is non-empty only URLs at or below the path will get the cookie
        /// value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public string Path {
            get {
                IntPtr value_str;
                int value_length;
                CfxApi.Cookie.cfx_cookie_get_path(nativePtrUnchecked, out value_str, out value_length);
                return StringFunctions.PtrToStringUni(value_str, value_length);
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Cookie.cfx_cookie_set_path(nativePtrUnchecked, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// If |secure| is true the cookie will only be sent for HTTPS requests.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool Secure {
            get {
                int value;
                CfxApi.Cookie.cfx_cookie_get_secure(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_secure(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// If |httpOnly| is true the cookie will only be sent for HTTP requests.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool HttpOnly {
            get {
                int value;
                CfxApi.Cookie.cfx_cookie_get_httponly(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_httponly(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        /// <summary>
        /// The cookie creation date. This is automatically populated by the system on
        /// cookie creation.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxTime Creation {
            get {
                IntPtr value;
                CfxApi.Cookie.cfx_cookie_get_creation(nativePtrUnchecked, out value);
                return CfxTime.Wrap(value);
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_creation(nativePtrUnchecked, CfxTime.Unwrap(value));
            }
        }

        /// <summary>
        /// The cookie last access date. This is automatically populated by the system
        /// on access.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public CfxTime LastAccess {
            get {
                IntPtr value;
                CfxApi.Cookie.cfx_cookie_get_last_access(nativePtrUnchecked, out value);
                return CfxTime.Wrap(value);
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_last_access(nativePtrUnchecked, CfxTime.Unwrap(value));
            }
        }

        /// <summary>
        /// The cookie expiration date is only valid if |hasExpires| is true.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
        /// </remarks>
        public bool HasExpires {
            get {
                int value;
                CfxApi.Cookie.cfx_cookie_get_has_expires(nativePtrUnchecked, out value);
                return 0 != value;
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_has_expires(nativePtrUnchecked, value ? 1 : 0);
            }
        }

        public CfxTime Expires {
            get {
                IntPtr value;
                CfxApi.Cookie.cfx_cookie_get_expires(nativePtrUnchecked, out value);
                return CfxTime.Wrap(value);
            }
            set {
                CfxApi.Cookie.cfx_cookie_set_expires(nativePtrUnchecked, CfxTime.Unwrap(value));
            }
        }

    }
}
