// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to make a URL request. URL requests are not associated with a
    /// browser instance so no CfxClient callbacks will be executed. URL requests
    /// can be created on any valid CEF thread in either the browser or render
    /// process. Once created the functions of the URL request object must be
    /// accessed on the same thread that created it.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
    /// </remarks>
    public class CfxUrlRequest : CfxBaseLibrary {

        internal static CfxUrlRequest Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxUrlRequest)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxUrlRequest(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxUrlRequest(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new URL request that is not associated with a specific browser or
        /// frame. Use CfxFrame.CreateURLRequest instead if you want the request to
        /// have this association, in which case it may be handled differently (see
        /// documentation on that function). Requests may originate from the both browser
        /// process and the render process.
        /// 
        /// For requests originating from the browser process:
        ///   - It may be intercepted by the client via CfxResourceRequestHandler or
        ///     CfxSchemeHandlerFactory.
        ///   - POST data may only contain only a single element of type PDE_TYPE_FILE
        ///     or PDE_TYPE_BYTES.
        ///   - If |requestContext| is empty the global request context will be used.
        /// For requests originating from the render process:
        ///   - It cannot be intercepted by the client so only http(s) and blob schemes
        ///     are supported.
        ///   - POST data may only contain a single element of type PDE_TYPE_BYTES.
        ///   - The |requestContext| parameter must be NULL.
        /// 
        /// The |request| object will be marked as read-only after calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public static CfxUrlRequest Create(CfxRequest request, CfxUrlRequestClient client, CfxRequestContext requestContext) {
            return CfxUrlRequest.Wrap(CfxApi.UrlRequest.cfx_urlrequest_create(CfxRequest.Unwrap(request), CfxUrlRequestClient.Unwrap(client), CfxRequestContext.Unwrap(requestContext)));
        }

        /// <summary>
        /// Returns the request object used to create this URL request. The returned
        /// object is read-only and should not be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfxRequest Request {
            get {
                return CfxRequest.Wrap(CfxApi.UrlRequest.cfx_urlrequest_get_request(NativePtr));
            }
        }

        /// <summary>
        /// Returns the client.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfxUrlRequestClient Client {
            get {
                return CfxUrlRequestClient.Wrap(CfxApi.UrlRequest.cfx_urlrequest_get_client(NativePtr));
            }
        }

        /// <summary>
        /// Returns the request status.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfxUrlRequestStatus RequestStatus {
            get {
                return (CfxUrlRequestStatus)CfxApi.UrlRequest.cfx_urlrequest_get_request_status(NativePtr);
            }
        }

        /// <summary>
        /// Returns the request error if status is UR_CANCELED or UR_FAILED, or 0
        /// otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfxErrorCode RequestError {
            get {
                return (CfxErrorCode)CfxApi.UrlRequest.cfx_urlrequest_get_request_error(NativePtr);
            }
        }

        /// <summary>
        /// Returns the response, or NULL if no response information is available.
        /// Response information will only be available after the upload has completed.
        /// The returned object is read-only and should not be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfxResponse Response {
            get {
                return CfxResponse.Wrap(CfxApi.UrlRequest.cfx_urlrequest_get_response(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the response body was served from the cache. This
        /// includes responses for which revalidation was required.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public bool ResponseWasCached() {
            return 0 != CfxApi.UrlRequest.cfx_urlrequest_response_was_cached(NativePtr);
        }

        /// <summary>
        /// Cancel the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            CfxApi.UrlRequest.cfx_urlrequest_cancel(NativePtr);
        }
    }
}
