// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxServer : CfxBaseLibrary {

        internal static CfxServer Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxServer)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxServer(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxServer(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new server that binds to |address| and |port|. |address| must be a
        /// valid IPv4 or IPv6 address (e.g. 127.0.0.1 or ::1) and |port| must be a port
        /// number outside of the reserved range (e.g. between 1025 and 65535 on most
        /// platforms). |backlog| is the maximum number of pending connections. A new
        /// thread will be created for each CreateServer call (the "dedicated server
        /// thread"). It is therefore recommended to use a different CfxServerHandler
        /// instance for each CreateServer call to avoid thread safety issues in the
        /// CfxServerHandler implementation. The
        /// CfxServerHandler.OnServerCreated function will be called on the
        /// dedicated server thread to report success or failure. See
        /// CfxServerHandler.OnServerCreated documentation for a description of
        /// server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public static void Create(string address, ushort port, int backlog, CfxServerHandler handler) {
            var address_pinned = new PinnedString(address);
            CfxApi.Server.cfx_server_create(address_pinned.Obj.PinnedPtr, address_pinned.Length, port, backlog, CfxServerHandler.Unwrap(handler));
            address_pinned.Obj.Free();
        }

        /// <summary>
        /// Returns the task runner for the dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public CfxTaskRunner TaskRunner {
            get {
                return CfxTaskRunner.Wrap(CfxApi.Server.cfx_server_get_task_runner(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the server is currently running and accepting incoming
        /// connections. See CfxServerHandler.OnServerCreated documentation for a
        /// description of server lifespan. This function must be called on the
        /// dedicated server thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public bool IsRunning {
            get {
                return 0 != CfxApi.Server.cfx_server_is_running(NativePtr);
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
                return StringFunctions.ConvertStringUserfree(CfxApi.Server.cfx_server_get_address(NativePtr));
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
                return 0 != CfxApi.Server.cfx_server_has_connection(NativePtr);
            }
        }

        /// <summary>
        /// Stop the server and shut down the dedicated server thread. See
        /// CfxServerHandler.OnServerCreated documentation for a description of
        /// server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void Shutdown() {
            CfxApi.Server.cfx_server_shutdown(NativePtr);
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
            return 0 != CfxApi.Server.cfx_server_is_valid_connection(NativePtr, connectionId);
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
        public void SendHttp200response(int connectionId, string contentType, IntPtr data, ulong dataSize) {
            var contentType_pinned = new PinnedString(contentType);
            CfxApi.Server.cfx_server_send_http200response(NativePtr, connectionId, contentType_pinned.Obj.PinnedPtr, contentType_pinned.Length, data, (UIntPtr)dataSize);
            contentType_pinned.Obj.Free();
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
            CfxApi.Server.cfx_server_send_http404response(NativePtr, connectionId);
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
            var errorMessage_pinned = new PinnedString(errorMessage);
            CfxApi.Server.cfx_server_send_http500response(NativePtr, connectionId, errorMessage_pinned.Obj.PinnedPtr, errorMessage_pinned.Length);
            errorMessage_pinned.Obj.Free();
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
            var contentType_pinned = new PinnedString(contentType);
            PinnedString[] extraHeaders_handles;
            var extraHeaders_unwrapped = StringFunctions.UnwrapCfxStringMultimap(extraHeaders, out extraHeaders_handles);
            CfxApi.Server.cfx_server_send_http_response(NativePtr, connectionId, responseCode, contentType_pinned.Obj.PinnedPtr, contentType_pinned.Length, contentLength, extraHeaders_unwrapped);
            contentType_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(extraHeaders_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(extraHeaders_unwrapped, extraHeaders);
            CfxApi.Runtime.cfx_string_multimap_free(extraHeaders_unwrapped);
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
        public void SendRawData(int connectionId, IntPtr data, ulong dataSize) {
            CfxApi.Server.cfx_server_send_raw_data(NativePtr, connectionId, data, (UIntPtr)dataSize);
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
            CfxApi.Server.cfx_server_close_connection(NativePtr, connectionId);
        }

        /// <summary>
        /// Send a WebSocket message to the connection identified by |connectionId|.
        /// |data| is the response content and |dataSize| is the size of |data| in
        /// bytes. The contents of |data| will be copied. See
        /// CfxServerHandler.OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public void SendWebSocketMessage(int connectionId, IntPtr data, ulong dataSize) {
            CfxApi.Server.cfx_server_send_web_socket_message(NativePtr, connectionId, data, (UIntPtr)dataSize);
        }
    }
}
