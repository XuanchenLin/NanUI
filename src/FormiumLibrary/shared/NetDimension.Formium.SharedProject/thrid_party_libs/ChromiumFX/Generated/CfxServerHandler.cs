// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Implement this structure to handle HTTP server requests. A new thread will be
    /// created for each CfxServer.CreateServer call (the "dedicated server
    /// thread"), and the functions of this structure will be called on that thread.
    /// It is therefore recommended to use a different CfxServerHandler instance
    /// for each CfxServer.CreateServer call to avoid thread safety issues in the
    /// CfxServerHandler implementation.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
    /// </remarks>
    public class CfxServerHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_server_created_native = on_server_created;
            on_server_destroyed_native = on_server_destroyed;
            on_client_connected_native = on_client_connected;
            on_client_disconnected_native = on_client_disconnected;
            on_http_request_native = on_http_request;
            on_web_socket_request_native = on_web_socket_request;
            on_web_socket_connected_native = on_web_socket_connected;
            on_web_socket_message_native = on_web_socket_message;

            on_server_created_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_server_created_native);
            on_server_destroyed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_server_destroyed_native);
            on_client_connected_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_client_connected_native);
            on_client_disconnected_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_client_disconnected_native);
            on_http_request_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_http_request_native);
            on_web_socket_request_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_web_socket_request_native);
            on_web_socket_connected_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_web_socket_connected_native);
            on_web_socket_message_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_web_socket_message_native);
        }

        // on_server_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_server_created_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release);
        private static on_server_created_delegate on_server_created_native;
        private static IntPtr on_server_created_native_ptr;

        internal static void on_server_created(IntPtr gcHandlePtr, IntPtr server, out int server_release) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnServerCreatedEventArgs();
            e.m_server = server;
            self.m_OnServerCreated?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        // on_server_destroyed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_server_destroyed_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release);
        private static on_server_destroyed_delegate on_server_destroyed_native;
        private static IntPtr on_server_destroyed_native_ptr;

        internal static void on_server_destroyed(IntPtr gcHandlePtr, IntPtr server, out int server_release) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnServerDestroyedEventArgs();
            e.m_server = server;
            self.m_OnServerDestroyed?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        // on_client_connected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_client_connected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_client_connected_delegate on_client_connected_native;
        private static IntPtr on_client_connected_native_ptr;

        internal static void on_client_connected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnClientConnectedEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            self.m_OnClientConnected?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        // on_client_disconnected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_client_disconnected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_client_disconnected_delegate on_client_disconnected_native;
        private static IntPtr on_client_disconnected_native_ptr;

        internal static void on_client_disconnected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnClientDisconnectedEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            self.m_OnClientDisconnected?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        // on_http_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_http_request_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release);
        private static on_http_request_delegate on_http_request_native;
        private static IntPtr on_http_request_native_ptr;

        internal static void on_http_request(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                request_release = 1;
                return;
            }
            var e = new CfxOnHttpRequestEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            e.m_client_address_str = client_address_str;
            e.m_client_address_length = client_address_length;
            e.m_request = request;
            self.m_OnHttpRequest?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }

        // on_web_socket_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_request_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release, IntPtr callback, out int callback_release);
        private static on_web_socket_request_delegate on_web_socket_request_native;
        private static IntPtr on_web_socket_request_native_ptr;

        internal static void on_web_socket_request(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release, IntPtr callback, out int callback_release) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                request_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxOnWebSocketRequestEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            e.m_client_address_str = client_address_str;
            e.m_client_address_length = client_address_length;
            e.m_request = request;
            e.m_callback = callback;
            self.m_OnWebSocketRequest?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
        }

        // on_web_socket_connected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_connected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_web_socket_connected_delegate on_web_socket_connected_native;
        private static IntPtr on_web_socket_connected_native_ptr;

        internal static void on_web_socket_connected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnWebSocketConnectedEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            self.m_OnWebSocketConnected?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        // on_web_socket_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_message_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr data, UIntPtr data_size);
        private static on_web_socket_message_delegate on_web_socket_message_native;
        private static IntPtr on_web_socket_message_native_ptr;

        internal static void on_web_socket_message(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr data, UIntPtr data_size) {
            var self = (CfxServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                server_release = 1;
                return;
            }
            var e = new CfxOnWebSocketMessageEventArgs();
            e.m_server = server;
            e.m_connection_id = connection_id;
            e.m_data = data;
            e.m_data_size = data_size;
            self.m_OnWebSocketMessage?.Invoke(self, e);
            e.m_isInvalid = true;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }

        public CfxServerHandler() : base(CfxApi.ServerHandler.cfx_server_handler_ctor) {}

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfxServer.IsRunning will return true (1). The server will continue
        /// running until CfxServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnServerCreatedEventHandler OnServerCreated {
            add {
                lock(eventLock) {
                    if(m_OnServerCreated == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 0, on_server_created_native_ptr);
                    }
                    m_OnServerCreated += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnServerCreated -= value;
                    if(m_OnServerCreated == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnServerCreatedEventHandler m_OnServerCreated;

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
        public event CfxOnServerDestroyedEventHandler OnServerDestroyed {
            add {
                lock(eventLock) {
                    if(m_OnServerDestroyed == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 1, on_server_destroyed_native_ptr);
                    }
                    m_OnServerDestroyed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnServerDestroyed -= value;
                    if(m_OnServerDestroyed == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnServerDestroyedEventHandler m_OnServerDestroyed;

        /// <summary>
        /// Called when a client connects to |Server|. |ConnectionId| uniquely
        /// identifies the connection. Each call to this function will have a matching
        /// call to OnClientDisconnected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnClientConnectedEventHandler OnClientConnected {
            add {
                lock(eventLock) {
                    if(m_OnClientConnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 2, on_client_connected_native_ptr);
                    }
                    m_OnClientConnected += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnClientConnected -= value;
                    if(m_OnClientConnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnClientConnectedEventHandler m_OnClientConnected;

        /// <summary>
        /// Called when a client disconnects from |Server|. |ConnectionId| uniquely
        /// identifies the connection. The client should release any data associated
        /// with |ConnectionId| when this function is called and |ConnectionId|
        /// should no longer be passed to CfxServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfxServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnClientDisconnectedEventHandler OnClientDisconnected {
            add {
                lock(eventLock) {
                    if(m_OnClientDisconnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 3, on_client_disconnected_native_ptr);
                    }
                    m_OnClientDisconnected += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnClientDisconnected -= value;
                    if(m_OnClientDisconnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnClientDisconnectedEventHandler m_OnClientDisconnected;

        /// <summary>
        /// Called when |Server| receives an HTTP request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Call CfxServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnHttpRequestEventHandler OnHttpRequest {
            add {
                lock(eventLock) {
                    if(m_OnHttpRequest == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 4, on_http_request_native_ptr);
                    }
                    m_OnHttpRequest += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnHttpRequest -= value;
                    if(m_OnHttpRequest == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnHttpRequestEventHandler m_OnHttpRequest;

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
        /// called. Call the CfxServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnWebSocketRequestEventHandler OnWebSocketRequest {
            add {
                lock(eventLock) {
                    if(m_OnWebSocketRequest == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 5, on_web_socket_request_native_ptr);
                    }
                    m_OnWebSocketRequest += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnWebSocketRequest -= value;
                    if(m_OnWebSocketRequest == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnWebSocketRequestEventHandler m_OnWebSocketRequest;

        /// <summary>
        /// Called after the client has accepted the WebSocket connection for |Server|
        /// and |ConnectionId| via the OnWebSocketRequest callback. See
        /// OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public event CfxOnWebSocketConnectedEventHandler OnWebSocketConnected {
            add {
                lock(eventLock) {
                    if(m_OnWebSocketConnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 6, on_web_socket_connected_native_ptr);
                    }
                    m_OnWebSocketConnected += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnWebSocketConnected -= value;
                    if(m_OnWebSocketConnected == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnWebSocketConnectedEventHandler m_OnWebSocketConnected;

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
        public event CfxOnWebSocketMessageEventHandler OnWebSocketMessage {
            add {
                lock(eventLock) {
                    if(m_OnWebSocketMessage == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 7, on_web_socket_message_native_ptr);
                    }
                    m_OnWebSocketMessage += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnWebSocketMessage -= value;
                    if(m_OnWebSocketMessage == null) {
                        CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnWebSocketMessageEventHandler m_OnWebSocketMessage;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnServerCreated != null) {
                m_OnServerCreated = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnServerDestroyed != null) {
                m_OnServerDestroyed = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnClientConnected != null) {
                m_OnClientConnected = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnClientDisconnected != null) {
                m_OnClientDisconnected = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnHttpRequest != null) {
                m_OnHttpRequest = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_OnWebSocketRequest != null) {
                m_OnWebSocketRequest = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_OnWebSocketConnected != null) {
                m_OnWebSocketConnected = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_OnWebSocketMessage != null) {
                m_OnWebSocketMessage = null;
                CfxApi.ServerHandler.cfx_server_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfxServer.IsRunning will return true (1). The server will continue
        /// running until CfxServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnServerCreatedEventHandler(object sender, CfxOnServerCreatedEventArgs e);

        /// <summary>
        /// Called when |Server| is created. If the server was started successfully
        /// then CfxServer.IsRunning will return true (1). The server will continue
        /// running until CfxServer.Shutdown is called, after which time
        /// OnServerDestroyed will be called. If the server failed to start then
        /// OnServerDestroyed will be called immediately after this function returns.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnServerCreatedEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;

            internal CfxOnServerCreatedEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnServerCreated"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
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
        public delegate void CfxOnServerDestroyedEventHandler(object sender, CfxOnServerDestroyedEventArgs e);

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
        public class CfxOnServerDestroyedEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;

            internal CfxOnServerDestroyedEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnServerDestroyed"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
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
        public delegate void CfxOnClientConnectedEventHandler(object sender, CfxOnClientConnectedEventArgs e);

        /// <summary>
        /// Called when a client connects to |Server|. |ConnectionId| uniquely
        /// identifies the connection. Each call to this function will have a matching
        /// call to OnClientDisconnected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnClientConnectedEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;

            internal CfxOnClientConnectedEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnClientConnected"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnClientConnected"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
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
        /// should no longer be passed to CfxServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfxServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnClientDisconnectedEventHandler(object sender, CfxOnClientDisconnectedEventArgs e);

        /// <summary>
        /// Called when a client disconnects from |Server|. |ConnectionId| uniquely
        /// identifies the connection. The client should release any data associated
        /// with |ConnectionId| when this function is called and |ConnectionId|
        /// should no longer be passed to CfxServer functions. Disconnects can
        /// originate from either the client or the server. For example, the server
        /// will disconnect automatically after a CfxServer.SendHttpXXXResponse
        /// function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnClientDisconnectedEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;

            internal CfxOnClientDisconnectedEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnClientDisconnected"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnClientDisconnected"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
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
        /// contents (URL, function, headers and optional POST data). Call CfxServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnHttpRequestEventHandler(object sender, CfxOnHttpRequestEventArgs e);

        /// <summary>
        /// Called when |Server| receives an HTTP request. |ConnectionId| uniquely
        /// identifies the connection, |ClientAddress| is the requesting IPv4 or IPv6
        /// client address including port number, and |Request| contains the request
        /// contents (URL, function, headers and optional POST data). Call CfxServer
        /// functions either synchronously or asynchronusly to send a response.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnHttpRequestEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;
            internal IntPtr m_client_address_str;
            internal int m_client_address_length;
            internal string m_client_address;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;

            internal CfxOnHttpRequestEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnHttpRequest"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnHttpRequest"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
                }
            }
            /// <summary>
            /// Get the ClientAddress parameter for the <see cref="CfxServerHandler.OnHttpRequest"/> callback.
            /// </summary>
            public string ClientAddress {
                get {
                    CheckAccess();
                    m_client_address = StringFunctions.PtrToStringUni(m_client_address_str, m_client_address_length);
                    return m_client_address;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxServerHandler.OnHttpRequest"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
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
        /// called. Call the CfxServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnWebSocketRequestEventHandler(object sender, CfxOnWebSocketRequestEventArgs e);

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
        /// called. Call the CfxServer.SendWebSocketMessage function after
        /// receiving the OnWebSocketConnected callback to respond with WebSocket
        /// messages.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnWebSocketRequestEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;
            internal IntPtr m_client_address_str;
            internal int m_client_address_length;
            internal string m_client_address;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal IntPtr m_callback;
            internal CfxCallback m_callback_wrapped;

            internal CfxOnWebSocketRequestEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnWebSocketRequest"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnWebSocketRequest"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
                }
            }
            /// <summary>
            /// Get the ClientAddress parameter for the <see cref="CfxServerHandler.OnWebSocketRequest"/> callback.
            /// </summary>
            public string ClientAddress {
                get {
                    CheckAccess();
                    m_client_address = StringFunctions.PtrToStringUni(m_client_address_str, m_client_address_length);
                    return m_client_address;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxServerHandler.OnWebSocketRequest"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxServerHandler.OnWebSocketRequest"/> callback.
            /// </summary>
            public CfxCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxCallback.Wrap(m_callback);
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
        public delegate void CfxOnWebSocketConnectedEventHandler(object sender, CfxOnWebSocketConnectedEventArgs e);

        /// <summary>
        /// Called after the client has accepted the WebSocket connection for |Server|
        /// and |ConnectionId| via the OnWebSocketRequest callback. See
        /// OnWebSocketRequest documentation for intended usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_server_capi.h">cef/include/capi/cef_server_capi.h</see>.
        /// </remarks>
        public class CfxOnWebSocketConnectedEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;

            internal CfxOnWebSocketConnectedEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnWebSocketConnected"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnWebSocketConnected"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
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
        public delegate void CfxOnWebSocketMessageEventHandler(object sender, CfxOnWebSocketMessageEventArgs e);

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
        public class CfxOnWebSocketMessageEventArgs : CfxEventArgs {

            internal IntPtr m_server;
            internal CfxServer m_server_wrapped;
            internal int m_connection_id;
            internal IntPtr m_data;
            internal UIntPtr m_data_size;

            internal CfxOnWebSocketMessageEventArgs() {}

            /// <summary>
            /// Get the Server parameter for the <see cref="CfxServerHandler.OnWebSocketMessage"/> callback.
            /// </summary>
            public CfxServer Server {
                get {
                    CheckAccess();
                    if(m_server_wrapped == null) m_server_wrapped = CfxServer.Wrap(m_server);
                    return m_server_wrapped;
                }
            }
            /// <summary>
            /// Get the ConnectionId parameter for the <see cref="CfxServerHandler.OnWebSocketMessage"/> callback.
            /// </summary>
            public int ConnectionId {
                get {
                    CheckAccess();
                    return m_connection_id;
                }
            }
            /// <summary>
            /// Get the Data parameter for the <see cref="CfxServerHandler.OnWebSocketMessage"/> callback.
            /// </summary>
            public IntPtr Data {
                get {
                    CheckAccess();
                    return m_data;
                }
            }
            /// <summary>
            /// Get the DataSize parameter for the <see cref="CfxServerHandler.OnWebSocketMessage"/> callback.
            /// </summary>
            public ulong DataSize {
                get {
                    CheckAccess();
                    return (ulong)m_data_size;
                }
            }

            public override string ToString() {
                return String.Format("Server={{{0}}}, ConnectionId={{{1}}}, Data={{{2}}}, DataSize={{{3}}}", Server, ConnectionId, Data, DataSize);
            }
        }

    }
}
