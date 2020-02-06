// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to make a URL request. URL requests are not associated with a
    /// browser instance so no CfrClient callbacks will be executed. URL requests
    /// can be created on any valid CEF thread in either the browser or render
    /// process. Once created the functions of the URL request object must be
    /// accessed on the same thread that created it.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
    /// </remarks>
    public class CfrUrlRequest : CfrBaseLibrary {

        internal static CfrUrlRequest Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrUrlRequest)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrUrlRequest(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }



        private CfrUrlRequest(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the request object used to create this URL request. The returned
        /// object is read-only and should not be modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfrRequest Request {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxUrlRequestGetRequestRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrRequest.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the client.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public CfrUrlRequestClient Client {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxUrlRequestGetClientRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrUrlRequestClient.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxUrlRequestGetRequestStatusRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxUrlRequestStatus)call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxUrlRequestGetRequestErrorRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxErrorCode)call.__retval;
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
        public CfrResponse Response {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxUrlRequestGetResponseRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrResponse.Wrap(new RemotePtr(connection, call.__retval));
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
            var connection = RemotePtr.connection;
            var call = new CfxUrlRequestResponseWasCachedRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Cancel the request.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_urlrequest_capi.h">cef/include/capi/cef_urlrequest_capi.h</see>.
        /// </remarks>
        public void Cancel() {
            var connection = RemotePtr.connection;
            var call = new CfxUrlRequestCancelRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }
    }
}
