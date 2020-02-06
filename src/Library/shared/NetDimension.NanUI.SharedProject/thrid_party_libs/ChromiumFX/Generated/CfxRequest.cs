// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a web request. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
    /// </remarks>
    public class CfxRequest : CfxBaseLibrary {

        internal static CfxRequest Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxRequest)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxRequest(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxRequest(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxRequest object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public static CfxRequest Create() {
            return CfxRequest.Wrap(CfxApi.Request.cfx_request_create());
        }

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.Request.cfx_request_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Get or set the fully qualified URL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_url(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Request.cfx_request_set_url(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get the request function type. The value will default to POST if post data
        /// is provided and GET otherwise.
        /// 
        /// Set the request function type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string Method {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_method(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Request.cfx_request_set_method(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get the referrer URL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string ReferrerUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_referrer_url(NativePtr));
            }
        }

        /// <summary>
        /// Get the referrer policy.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxReferrerPolicy ReferrerPolicy {
            get {
                return (CfxReferrerPolicy)CfxApi.Request.cfx_request_get_referrer_policy(NativePtr);
            }
        }

        /// <summary>
        /// Get or set the post data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxPostData PostData {
            get {
                return CfxPostData.Wrap(CfxApi.Request.cfx_request_get_post_data(NativePtr));
            }
            set {
                CfxApi.Request.cfx_request_set_post_data(NativePtr, CfxPostData.Unwrap(value));
            }
        }

        /// <summary>
        /// Get the flags used in combination with CfxUrlRequest. See
        /// CfxUrlRequestFlags for supported values.
        /// 
        /// Set the flags used in combination with CfxUrlRequest.  See
        /// CfxUrlRequestFlags for supported values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public int Flags {
            get {
                return CfxApi.Request.cfx_request_get_flags(NativePtr);
            }
            set {
                CfxApi.Request.cfx_request_set_flags(NativePtr, value);
            }
        }

        /// <summary>
        /// Get the URL to the first party for cookies used in combination with
        /// CfxUrlRequest.
        /// 
        /// Set the URL to the first party for cookies used in combination with
        /// CfxUrlRequest.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string FirstPartyForCookies {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_first_party_for_cookies(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Request.cfx_request_set_first_party_for_cookies(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get the resource type for this request. Only available in the browser
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxResourceType ResourceType {
            get {
                return (CfxResourceType)CfxApi.Request.cfx_request_get_resource_type(NativePtr);
            }
        }

        /// <summary>
        /// Get the transition type for this request. Only available in the browser
        /// process and only applies to requests that represent a main frame or sub-
        /// frame navigation.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfxTransitionType TransitionType {
            get {
                return (CfxTransitionType)CfxApi.Request.cfx_request_get_transition_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns the globally unique identifier for this request or 0 if not
        /// specified. Can be used by CfxResourceRequestHandler implementations in
        /// the browser process to track a single request across multiple callbacks.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public ulong Identifier {
            get {
                return CfxApi.Request.cfx_request_get_identifier(NativePtr);
            }
        }

        /// <summary>
        /// Set the referrer URL and policy. If non-NULL the referrer URL must be fully
        /// qualified with an HTTP or HTTPS scheme component. Any username, password or
        /// ref component will be removed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetReferrer(string referrerUrl, CfxReferrerPolicy policy) {
            var referrerUrl_pinned = new PinnedString(referrerUrl);
            CfxApi.Request.cfx_request_set_referrer(NativePtr, referrerUrl_pinned.Obj.PinnedPtr, referrerUrl_pinned.Length, (int)policy);
            referrerUrl_pinned.Obj.Free();
        }

        /// <summary>
        /// Get the header values. Will not include the Referer value if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetHeaderMap() {
            System.Collections.Generic.List<string[]> headerMap = new System.Collections.Generic.List<string[]>();
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Request.cfx_request_get_header_map(NativePtr, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
            return headerMap;
        }

        /// <summary>
        /// Set the header values. If a Referer value exists in the header map it will
        /// be removed and ignored.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetHeaderMap(System.Collections.Generic.List<string[]> headerMap) {
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Request.cfx_request_set_header_map(NativePtr, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }

        /// <summary>
        /// Returns the first header value for |name| or an NULL string if not found.
        /// Will not return the Referer value if any. Use GetHeaderMap instead if
        /// |name| might have multiple values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string GetHeaderByName(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.Request.cfx_request_get_header_by_name(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Set the header |name| to |value|. If |overwrite| is true (1) any existing
        /// values will be replaced with the new value. If |overwrite| is false (0) any
        /// existing values will not be overwritten. The Referer value cannot be set
        /// using this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void SetHeaderByName(string name, string value, bool overwrite) {
            var name_pinned = new PinnedString(name);
            var value_pinned = new PinnedString(value);
            CfxApi.Request.cfx_request_set_header_by_name(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length, overwrite ? 1 : 0);
            name_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }

        /// <summary>
        /// Set all values at one time.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void Set(string url, string method, CfxPostData postData, System.Collections.Generic.List<string[]> headerMap) {
            var url_pinned = new PinnedString(url);
            var method_pinned = new PinnedString(method);
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Request.cfx_request_set(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length, method_pinned.Obj.PinnedPtr, method_pinned.Length, CfxPostData.Unwrap(postData), headerMap_unwrapped);
            url_pinned.Obj.Free();
            method_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }
    }
}
