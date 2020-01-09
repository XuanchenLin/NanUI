// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a server that supports HTTP and WebSocket requests.
    /// Server capacity is limited and is intended to handle only a small number of
    /// simultaneous connections (e.g. for communicating between applications on
    /// localhost). The functions of this structure are safe to call from any thread
    /// in the brower process unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
    /// </remarks>
    public class CfrServer : CfrBaseLibrary {

        internal static CfrServer Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrServer)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrServer(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new server that binds to |address| and |port|. |address| must be a
        /// valid IPv4 or IPv6 address (e.g. 127.0.0.1 or ::1) and |port| must be a port
        /// number outside of the reserved range (e.g. between 1025 and 65535 on most
        /// platforms). |backlog| is the maximum number of pending connections. A new
        /// thread will be created for each CreateServer call (the "dedicated server
        /// thread"). It is therefore recommended to use a different CfrServerHandler
        /// instance for each CreateServer call to avoid thread safety issues in the
        /// CfrServerHandler implementation. The
        /// CfrServerHandler.OnServerCreated function will be called on the
        /// dedicated server thread to report success or failure. See
        /// CfrServerHandler.OnServerCreated documentation for a description of
        /// server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public static void Create(string address, ushort port, int backlog, CfrServerHandler handler) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxServerCreateRemoteCall();
            call.address = address;
            call.port = port;
            call.backlog = backlog;
            if(!CfrObject.CheckConnection(handler, connection)) throw new ArgumentException("Render process connection mismatch.", "handler");
            call.handler = CfrObject.Unwrap(handler).ptr;
            call.RequestExecution(connection);
        }


        private CfrServer(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the task runner for the dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public CfrTaskRunner TaskRunner {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxServerGetTaskRunnerRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrTaskRunner.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns true (1) if the server is currently running and accepting incoming
        /// connections. See CfrServerHandler.OnServerCreated documentation for a
        /// description of server lifespan. This function must be called on the
        /// dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public bool IsRunning {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxServerIsRunningRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the server address including the port number.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public string Address {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxServerGetAddressRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the server currently has a connection. This function
        /// must be called on the dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public bool HasConnection {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxServerHasConnectionRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Stop the server and shut down the dedicated server thread. See
        /// CfrServerHandler.OnServerCreated documentation for a description of
        /// server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void Shutdown() {
            var connection = RemotePtr.connection;
            var call = new CfxServerShutdownRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Returns true (1) if |connectionId| represents a valid connection. This
        /// function must be called on the dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public bool IsValidConnection(int connectionId) {
            var connection = RemotePtr.connection;
            var call = new CfxServerIsValidConnectionRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Send an HTTP 200 "OK" response to the connection identified by
        /// |connectionId|. |contentType| is the response content type (e.g.
        /// "text/html"), |data| is the response content, and |dataSize| is the size
        /// of |data| in bytes. The contents of |data| will be copied. The connection
        /// will be closed automatically after the response is sent.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendHttp200response(int connectionId, string contentType, RemotePtr data, ulong dataSize) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendHttp200responseRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.contentType = contentType;
            if(data.connection != connection) throw new ArgumentException("Render process connection mismatch.", "data");
            call.data = data.ptr;
            call.dataSize = dataSize;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Send an HTTP 404 "Not Found" response to the connection identified by
        /// |connectionId|. The connection will be closed automatically after the
        /// response is sent.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendHttp404response(int connectionId) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendHttp404responseRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Send an HTTP 500 "Internal Server Error" response to the connection
        /// identified by |connectionId|. |errorMessage| is the associated error
        /// message. The connection will be closed automatically after the response is
        /// sent.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendHttp500response(int connectionId, string errorMessage) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendHttp500responseRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.errorMessage = errorMessage;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Send a custom HTTP response to the connection identified by
        /// |connectionId|. |responseCode| is the HTTP response code sent in the
        /// status line (e.g. 200), |contentType| is the response content type sent as
        /// the "Content-Type" header (e.g. "text/html"), |contentLength| is the
        /// expected content length, and |extraHeaders| is the map of extra response
        /// headers. If |contentLength| is >= 0 then the "Content-Length" header will
        /// be sent. If |contentLength| is 0 then no content is expected and the
        /// connection will be closed automatically after the response is sent. If
        /// |contentLength| is &lt; 0 then no "Content-Length" header will be sent and
        /// the client will continue reading until the connection is closed. Use the
        /// SendRawData function to send the content, if applicable, and call
        /// CloseConnection after all content has been sent.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendHttpResponse(int connectionId, int responseCode, string contentType, long contentLength, System.Collections.Generic.List<string[]> extraHeaders) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendHttpResponseRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.responseCode = responseCode;
            call.contentType = contentType;
            call.contentLength = contentLength;
            call.extraHeaders = extraHeaders;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Send raw data directly to the connection identified by |connectionId|.
        /// |data| is the raw data and |dataSize| is the size of |data| in bytes. The
        /// contents of |data| will be copied. No validation of |data| is performed
        /// internally so the client should be careful to send the amount indicated by
        /// the "Content-Length" header, if specified. See SendHttpResponse
        /// documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendRawData(int connectionId, RemotePtr data, ulong dataSize) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendRawDataRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            if(data.connection != connection) throw new ArgumentException("Render process connection mismatch.", "data");
            call.data = data.ptr;
            call.dataSize = dataSize;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Close the connection identified by |connectionId|. See SendHttpResponse
        /// documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void CloseConnection(int connectionId) {
            var connection = RemotePtr.connection;
            var call = new CfxServerCloseConnectionRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Send a WebSocket message to the connection identified by |connectionId|.
        /// |data| is the response content and |dataSize| is the size of |data| in
        /// bytes. The contents of |data| will be copied. See
        /// CfrServerHandler.OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendWebSocketMessage(int connectionId, RemotePtr data, ulong dataSize) {
            var connection = RemotePtr.connection;
            var call = new CfxServerSendWebSocketMessageRemoteCall();
            call.@this = RemotePtr.ptr;
            call.connectionId = connectionId;
            if(data.connection != connection) throw new ArgumentException("Render process connection mismatch.", "data");
            call.data = data.ptr;
            call.dataSize = dataSize;
            call.RequestExecution(connection);
        }
    }
}
