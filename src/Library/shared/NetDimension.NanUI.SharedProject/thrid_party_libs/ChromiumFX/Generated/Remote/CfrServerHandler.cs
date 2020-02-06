// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Implement this structure to handle HTTP server requests. A new thread will be
    /// created for each CfrServer.CreateServer call (the "dedicated server
    /// thread"), and the functions of this structure will be called on that thread.
    /// It is therefore recommended to use a different CfrServerHandler instance
    /// for each CfrServer.CreateServer call to avoid thread safety issues in the
    /// CfrServerHandler implementation.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
    /// </remarks>
    public class CfrServerHandler : CfrBaseClient {


        private CfrServerHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrServerHandler() : base(new CfxServerHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfrServer.IsRunning will return true (1). The server will continue
        /// running until CfrServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnServerCreatedEventHandler OnServerCreated {
            add {
                if(m_OnServerCreated == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnServerCreated += value;
            }
            remove {
                m_OnServerCreated -= value;
                if(m_OnServerCreated == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnServerCreatedEventHandler m_OnServerCreated;


        /// <summary>
        /// Called when |Server| is destroyed. The server thread will be stopped after
        /// this function returns. The client should release any references to |Server|
        /// when this function is called. See OnServerCreated documentation for a
        /// description of server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnServerDestroyedEventHandler OnServerDestroyed {
            add {
                if(m_OnServerDestroyed == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnServerDestroyed += value;
            }
            remove {
                m_OnServerDestroyed -= value;
                if(m_OnServerDestroyed == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnServerDestroyedEventHandler m_OnServerDestroyed;


        /// <summary>
        /// Called when a client connects to |Server|. |ConnectionId| uniquely
        /// identifies the connection. Each call to this function will have a matching
        /// call to OnClientDisconnected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnClientConnectedEventHandler OnClientConnected {
            add {
                if(m_OnClientConnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnClientConnected += value;
            }
            remove {
                m_OnClientConnected -= value;
                if(m_OnClientConnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnClientConnectedEventHandler m_OnClientConnected;


        /// <summary>
        /// Called when a client disconnects from |Server|. |ConnectionId| uniquely
        /// identifies the connection. The client should release any data associated
        /// with |ConnectionId| when this function is called and |ConnectionId|
        /// should no longer be passed to CfrServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfrServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnClientDisconnectedEventHandler OnClientDisconnected {
            add {
                if(m_OnClientDisconnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnClientDisconnected += value;
            }
            remove {
                m_OnClientDisconnected -= value;
                if(m_OnClientDisconnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnClientDisconnectedEventHandler m_OnClientDisconnected;


        /// <summary>
        /// Called when |Server| receives an HTTP request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Call CfrServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnHttpRequestEventHandler OnHttpRequest {
            add {
                if(m_OnHttpRequest == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnHttpRequest += value;
            }
            remove {
                m_OnHttpRequest -= value;
                if(m_OnHttpRequest == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnHttpRequestEventHandler m_OnHttpRequest;


        /// <summary>
        /// Called when |Server| receives a WebSocket request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Execute
        /// |Callback| either synchronously or asynchronously to accept or decline the
        /// WebSocket connection. If the request is accepted then OnWebSocketConnected
        /// will be called after the WebSocket has connected and incoming messages will
        /// be delivered to the OnWebSocketMessage callback. If the request is declined
        /// then the client will be disconnected and OnClientDisconnected will be
        /// called. Call the CfrServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnWebSocketRequestEventHandler OnWebSocketRequest {
            add {
                if(m_OnWebSocketRequest == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 5;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnWebSocketRequest += value;
            }
            remove {
                m_OnWebSocketRequest -= value;
                if(m_OnWebSocketRequest == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 5;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnWebSocketRequestEventHandler m_OnWebSocketRequest;


        /// <summary>
        /// Called after the client has accepted the WebSocket connection for |Server|
        /// and |ConnectionId| via the OnWebSocketRequest callback. See
        /// OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnWebSocketConnectedEventHandler OnWebSocketConnected {
            add {
                if(m_OnWebSocketConnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 6;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnWebSocketConnected += value;
            }
            remove {
                m_OnWebSocketConnected -= value;
                if(m_OnWebSocketConnected == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 6;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnWebSocketConnectedEventHandler m_OnWebSocketConnected;


        /// <summary>
        /// Called when |Server| receives an WebSocket message. |ConnectionId|
        /// uniquely identifies the connection, |Data| is the message content and
        /// |DataSize| is the size of |Data| in bytes. Do not keep a reference to
        /// |Data| outside of this function. See OnWebSocketRequest documentation for
        /// intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfrOnWebSocketMessageEventHandler OnWebSocketMessage {
            add {
                if(m_OnWebSocketMessage == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 7;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnWebSocketMessage += value;
            }
            remove {
                m_OnWebSocketMessage -= value;
                if(m_OnWebSocketMessage == null) {
                    var call = new CfxServerHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 7;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnWebSocketMessageEventHandler m_OnWebSocketMessage;


    }

    namespace Event {

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfrServer.IsRunning will return true (1). The server will continue
        /// running until CfrServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnServerCreatedEventHandler(object sender, CfrOnServerCreatedEventArgs e);

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfrServer.IsRunning will return true (1). The server will continue
        /// running until CfrServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnServerCreatedEventArgs : CfrEventArgs {

            private CfxServerHandlerOnServerCreatedRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnServerCreatedEventArgs(CfxServerHandlerOnServerCreatedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnServerCreated"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}", Server);
            }
        }

        /// <summary>
        /// Called when |Server| is destroyed. The server thread will be stopped after
        /// this function returns. The client should release any references to |Server|
        /// when this function is called. See OnServerCreated documentation for a
        /// description of server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnServerDestroyedEventHandler(object sender, CfrOnServerDestroyedEventArgs e);

        /// <summary>
        /// Called when |Server| is destroyed. The server thread will be stopped after
        /// this function returns. The client should release any references to |Server|
        /// when this function is called. See OnServerCreated documentation for a
        /// description of server lifespan.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnServerDestroyedEventArgs : CfrEventArgs {

            private CfxServerHandlerOnServerDestroyedRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnServerDestroyedEventArgs(CfxServerHandlerOnServerDestroyedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnServerDestroyed"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}", Server);
            }
        }

        /// <summary>
        /// Called when a client connects to |Server|. |ConnectionId| uniquely
        /// identifies the connection. Each call to this function will have a matching
        /// call to OnClientDisconnected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnClientConnectedEventHandler(object sender, CfrOnClientConnectedEventArgs e);

        /// <summary>
        /// Called when a client connects to |Server|. |ConnectionId| uniquely
        /// identifies the connection. Each call to this function will have a matching
        /// call to OnClientDisconnected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnClientConnectedEventArgs : CfrEventArgs {

            private CfxServerHandlerOnClientConnectedRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnClientConnectedEventArgs(CfxServerHandlerOnClientConnectedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnClientConnected"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnClientConnected"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}", Server, ConnectionId);
            }
        }

        /// <summary>
        /// Called when a client disconnects from |Server|. |ConnectionId| uniquely
        /// identifies the connection. The client should release any data associated
        /// with |ConnectionId| when this function is called and |ConnectionId|
        /// should no longer be passed to CfrServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfrServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnClientDisconnectedEventHandler(object sender, CfrOnClientDisconnectedEventArgs e);

        /// <summary>
        /// Called when a client disconnects from |Server|. |ConnectionId| uniquely
        /// identifies the connection. The client should release any data associated
        /// with |ConnectionId| when this function is called and |ConnectionId|
        /// should no longer be passed to CfrServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfrServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnClientDisconnectedEventArgs : CfrEventArgs {

            private CfxServerHandlerOnClientDisconnectedRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnClientDisconnectedEventArgs(CfxServerHandlerOnClientDisconnectedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnClientDisconnected"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnClientDisconnected"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}", Server, ConnectionId);
            }
        }

        /// <summary>
        /// Called when |Server| receives an HTTP request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Call CfrServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnHttpRequestEventHandler(object sender, CfrOnHttpRequestEventArgs e);

        /// <summary>
        /// Called when |Server| receives an HTTP request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Call CfrServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnHttpRequestEventArgs : CfrEventArgs {

            private CfxServerHandlerOnHttpRequestRemoteEventCall call;

            internal CfrServer m_server_wrapped;
            internal string m_client_address;
            internal bool m_client_address_fetched;
            internal CfrRequest m_request_wrapped;

            internal CfrOnHttpRequestEventArgs(CfxServerHandlerOnHttpRequestRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnHttpRequest"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnHttpRequest"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }
            /// <summary>
            /// Get the ClientAddress parameter for the <see cref="CfrServerHandler.OnHttpRequest"/> render process callback.
            /// </summary>
            public string ClientAddress {
                get {
                    CheckAccess();
                    if(!m_client_address_fetched) {
                        m_client_address = call.client_address_str == IntPtr.Zero ? null : (call.client_address_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.client_address_str), call.client_address_length));
                        m_client_address_fetched = true;
                    }
                    return m_client_address;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfrServerHandler.OnHttpRequest"/> render process callback.
            /// </summary>
            public CfrRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}, ClientAddress={{{2}}}, Request={{{3}}}", Server, ConnectionId, ClientAddress, Request);
            }
        }

        /// <summary>
        /// Called when |Server| receives a WebSocket request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Execute
        /// |Callback| either synchronously or asynchronously to accept or decline the
        /// WebSocket connection. If the request is accepted then OnWebSocketConnected
        /// will be called after the WebSocket has connected and incoming messages will
        /// be delivered to the OnWebSocketMessage callback. If the request is declined
        /// then the client will be disconnected and OnClientDisconnected will be
        /// called. Call the CfrServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnWebSocketRequestEventHandler(object sender, CfrOnWebSocketRequestEventArgs e);

        /// <summary>
        /// Called when |Server| receives a WebSocket request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Execute
        /// |Callback| either synchronously or asynchronously to accept or decline the
        /// WebSocket connection. If the request is accepted then OnWebSocketConnected
        /// will be called after the WebSocket has connected and incoming messages will
        /// be delivered to the OnWebSocketMessage callback. If the request is declined
        /// then the client will be disconnected and OnClientDisconnected will be
        /// called. Call the CfrServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnWebSocketRequestEventArgs : CfrEventArgs {

            private CfxServerHandlerOnWebSocketRequestRemoteEventCall call;

            internal CfrServer m_server_wrapped;
            internal string m_client_address;
            internal bool m_client_address_fetched;
            internal CfrRequest m_request_wrapped;
            internal CfrCallback m_callback_wrapped;

            internal CfrOnWebSocketRequestEventArgs(CfxServerHandlerOnWebSocketRequestRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnWebSocketRequest"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnWebSocketRequest"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }
            /// <summary>
            /// Get the ClientAddress parameter for the <see cref="CfrServerHandler.OnWebSocketRequest"/> render process callback.
            /// </summary>
            public string ClientAddress {
                get {
                    CheckAccess();
                    if(!m_client_address_fetched) {
                        m_client_address = call.client_address_str == IntPtr.Zero ? null : (call.client_address_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.client_address_str), call.client_address_length));
                        m_client_address_fetched = true;
                    }
                    return m_client_address;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfrServerHandler.OnWebSocketRequest"/> render process callback.
            /// </summary>
            public CfrRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfrRequest.Wrap(new RemotePtr(connection, call.request));
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfrServerHandler.OnWebSocketRequest"/> render process callback.
            /// </summary>
            public CfrCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfrCallback.Wrap(new RemotePtr(connection, call.callback));
                    return m_callback_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}, ClientAddress={{{2}}}, Request={{{3}}}, Callback={{{4}}}", Server, ConnectionId, ClientAddress, Request, Callback);
            }
        }

        /// <summary>
        /// Called after the client has accepted the WebSocket connection for |Server|
        /// and |ConnectionId| via the OnWebSocketRequest callback. See
        /// OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnWebSocketConnectedEventHandler(object sender, CfrOnWebSocketConnectedEventArgs e);

        /// <summary>
        /// Called after the client has accepted the WebSocket connection for |Server|
        /// and |ConnectionId| via the OnWebSocketRequest callback. See
        /// OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnWebSocketConnectedEventArgs : CfrEventArgs {

            private CfxServerHandlerOnWebSocketConnectedRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnWebSocketConnectedEventArgs(CfxServerHandlerOnWebSocketConnectedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnWebSocketConnected"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnWebSocketConnected"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}", Server, ConnectionId);
            }
        }

        /// <summary>
        /// Called when |Server| receives an WebSocket message. |ConnectionId|
        /// uniquely identifies the connection, |Data| is the message content and
        /// |DataSize| is the size of |Data| in bytes. Do not keep a reference to
        /// |Data| outside of this function. See OnWebSocketRequest documentation for
        /// intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnWebSocketMessageEventHandler(object sender, CfrOnWebSocketMessageEventArgs e);

        /// <summary>
        /// Called when |Server| receives an WebSocket message. |ConnectionId|
        /// uniquely identifies the connection, |Data| is the message content and
        /// |DataSize| is the size of |Data| in bytes. Do not keep a reference to
        /// |Data| outside of this function. See OnWebSocketRequest documentation for
        /// intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfrOnWebSocketMessageEventArgs : CfrEventArgs {

            private CfxServerHandlerOnWebSocketMessageRemoteEventCall call;

            internal CfrServer m_server_wrapped;

            internal CfrOnWebSocketMessageEventArgs(CfxServerHandlerOnWebSocketMessageRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Server parameter for the <see cref="CfrServerHandler.OnWebSocketMessage"/> render process callback.
            /// </summary>
            public CfrServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfrServer.Wrap(new RemotePtr(connection, call.server));
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfrServerHandler.OnWebSocketMessage"/> render process callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return call.connection_id;
                }
            }
            /// <summary>
            /// Get the Data parameter for the <see cref="CfrServerHandler.OnWebSocketMessage"/> render process callback.
            /// </summary>
            public RemotePtr Data {
                get {
                    CheckAccess();
                    return new RemotePtr(connection, call.data);
                }
            }
            /// <summary>
            /// Get the DataSize parameter for the <see cref="CfrServerHandler.OnWebSocketMessage"/> render process callback.
            /// </summary>
            public ulong DataSize {
                get {
                    CheckAccess();
                    return (ulong)call.data_size;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}, Data={{{2}}}, DataSize={{{3}}}", Server, ConnectionId, Data, DataSize);
            }
        }

    }
}
