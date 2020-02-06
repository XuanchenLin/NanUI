// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a web response. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
    /// </remarks>
    public class CfxResponse : CfxBaseLibrary {

        internal static CfxResponse Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxResponse)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxResponse(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxResponse(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxResponse object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public static CfxResponse Create() {
            return CfxResponse.Wrap(CfxApi.Response.cfx_response_create());
        }

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.Response.cfx_response_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Get the response error code. Returns ERR_NONE if there was no error.
        /// 
        /// Set the response error code. This can be used by custom scheme handlers to
        /// return errors during initial request processing.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public CfxErrorCode Error {
            get {
                return (CfxErrorCode)CfxApi.Response.cfx_response_get_error(NativePtr);
            }
            set {
                CfxApi.Response.cfx_response_set_error(NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Get or set the response status code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public int Status {
            get {
                return CfxApi.Response.cfx_response_get_status(NativePtr);
            }
            set {
                CfxApi.Response.cfx_response_set_status(NativePtr, value);
            }
        }

        /// <summary>
        /// Get or set the response status text.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string StatusText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_status_text(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Response.cfx_response_set_status_text(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get or set the response mime type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string MimeType {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_mime_type(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Response.cfx_response_set_mime_type(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get or set the response charset.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string Charset {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_charset(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Response.cfx_response_set_charset(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get or set the resolved URL after redirects or changed as a result of HSTS.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_url(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.Response.cfx_response_set_url(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get the value for the specified response header field.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string GetHeader(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.Response.cfx_response_get_header(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Get all response header fields.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetHeaderMap() {
            System.Collections.Generic.List<string[]> headerMap = new System.Collections.Generic.List<string[]>();
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Response.cfx_response_get_header_map(NativePtr, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
            return headerMap;
        }

        /// <summary>
        /// Set all response header fields.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public void SetHeaderMap(System.Collections.Generic.List<string[]> headerMap) {
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Response.cfx_response_set_header_map(NativePtr, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }
    }
}
