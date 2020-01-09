// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to represent a web request. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
    /// </remarks>
    public class CfrRequest : CfrBaseLibrary {

        internal static CfrRequest Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrRequest)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrRequest(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrRequest object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public static CfrRequest Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxRequestCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrRequest.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrRequest(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Get the fully qualified URL.
        /// 
        /// Set the fully qualified URL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxRequestSetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
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
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetMethodRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxRequestSetMethodRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
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
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetReferrerUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetReferrerPolicyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxReferrerPolicy)call.__retval;
            }
        }

        /// <summary>
        /// Get the post data.
        /// 
        /// Set the post data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public CfrPostData PostData {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetPostDataRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrPostData.Wrap(new RemotePtr(connection, call.__retval));
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxRequestSetPostDataRemoteCall();
                call.@this = RemotePtr.ptr;
                if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
                call.value = CfrObject.Unwrap(value).ptr;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the flags used in combination with CfrUrlRequest. See
        /// CfrUrlRequestFlags for supported values.
        /// 
        /// Set the flags used in combination with CfrUrlRequest.  See
        /// CfrUrlRequestFlags for supported values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public int Flags {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetFlagsRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxRequestSetFlagsRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the URL to the first party for cookies used in combination with
        /// CfrUrlRequest.
        /// 
        /// Set the URL to the first party for cookies used in combination with
        /// CfrUrlRequest.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public string FirstPartyForCookies {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetFirstPartyForCookiesRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxRequestSetFirstPartyForCookiesRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
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
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetResourceTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxResourceType)call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetTransitionTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxTransitionType)call.__retval;
            }
        }

        /// <summary>
        /// Returns the globally unique identifier for this request or 0 if not
        /// specified. Can be used by CfrResourceRequestHandler implementations in
        /// the browser process to track a single request across multiple callbacks.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public ulong Identifier {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxRequestGetIdentifierRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxRequestSetReferrerRemoteCall();
            call.@this = RemotePtr.ptr;
            call.referrerUrl = referrerUrl;
            call.policy = (int)policy;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Get the header values. Will not include the Referer value if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetHeaderMap() {
            var connection = RemotePtr.connection;
            var call = new CfxRequestGetHeaderMapRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxRequestSetHeaderMapRemoteCall();
            call.@this = RemotePtr.ptr;
            call.headerMap = headerMap;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxRequestGetHeaderByNameRemoteCall();
            call.@this = RemotePtr.ptr;
            call.name = name;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxRequestSetHeaderByNameRemoteCall();
            call.@this = RemotePtr.ptr;
            call.name = name;
            call.value = value;
            call.overwrite = overwrite;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Set all values at one time.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_capi.h">cef/include/capi/cef_request_capi.h</see>.
        /// </remarks>
        public void Set(string url, string method, CfrPostData postData, System.Collections.Generic.List<string[]> headerMap) {
            var connection = RemotePtr.connection;
            var call = new CfxRequestSetRemoteCall();
            call.@this = RemotePtr.ptr;
            call.url = url;
            call.method = method;
            if(!CfrObject.CheckConnection(postData, connection)) throw new ArgumentException("Render process connection mismatch.", "postData");
            call.postData = CfrObject.Unwrap(postData).ptr;
            call.headerMap = headerMap;
            call.RequestExecution(connection);
        }
    }
}
