// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to represent a web response. The functions of this structure
    /// may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
    /// </remarks>
    public class CfrResponse : CfrBaseLibrary {

        internal static CfrResponse Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrResponse)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrResponse(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new CfrResponse object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public static CfrResponse Create() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxResponseCreateRemoteCall();
            call.RequestExecution(connection);
            return CfrResponse.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrResponse(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseIsReadOnlyRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetErrorRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxErrorCode)call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetErrorRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = (int)value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the response status code.
        /// 
        /// Set the response status code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public int Status {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetStatusRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetStatusRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the response status text.
        /// 
        /// Set the response status text.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string StatusText {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetStatusTextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetStatusTextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the response mime type.
        /// 
        /// Set the response mime type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string MimeType {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetMimeTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetMimeTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the response charset.
        /// 
        /// Set the response charset.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string Charset {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetCharsetRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetCharsetRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
            }
        }

        /// <summary>
        /// Get the resolved URL after redirects or changed as a result of HSTS.
        /// 
        /// Set the resolved URL after redirects or changed as a result of HSTS.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxResponseGetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
            set {
                var connection = RemotePtr.connection;
                var call = new CfxResponseSetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxResponseGetHeaderRemoteCall();
            call.@this = RemotePtr.ptr;
            call.name = name;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Get all response header fields.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetHeaderMap() {
            var connection = RemotePtr.connection;
            var call = new CfxResponseGetHeaderMapRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Set all response header fields.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_response_capi.h">cef/include/capi/cef_response_capi.h</see>.
        /// </remarks>
        public void SetHeaderMap(System.Collections.Generic.List<string[]> headerMap) {
            var connection = RemotePtr.connection;
            var call = new CfxResponseSetHeaderMapRemoteCall();
            call.@this = RemotePtr.ptr;
            call.headerMap = headerMap;
            call.RequestExecution(connection);
        }
    }
}
