// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxServerHandlerRemoteClient {

        static CfxServerHandlerRemoteClient() {
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

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_server_created_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_server_destroyed_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_client_connected_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_client_disconnected_native_ptr : IntPtr.Zero);
                    break;
                case 4:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_http_request_native_ptr : IntPtr.Zero);
                    break;
                case 5:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_web_socket_request_native_ptr : IntPtr.Zero);
                    break;
                case 6:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_web_socket_connected_native_ptr : IntPtr.Zero);
                    break;
                case 7:
                    CfxApi.ServerHandler.cfx_server_handler_set_callback(self, index, active ? on_web_socket_message_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // on_server_created
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_server_created_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release);
        private static on_server_created_delegate on_server_created_native;
        private static IntPtr on_server_created_native_ptr;

        internal static void on_server_created(IntPtr gcHandlePtr, IntPtr server, out int server_release) {
            var call = new CfxServerHandlerOnServerCreatedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.RequestExecution();
            server_release = call.server_release;
        }

        // on_server_destroyed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_server_destroyed_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release);
        private static on_server_destroyed_delegate on_server_destroyed_native;
        private static IntPtr on_server_destroyed_native_ptr;

        internal static void on_server_destroyed(IntPtr gcHandlePtr, IntPtr server, out int server_release) {
            var call = new CfxServerHandlerOnServerDestroyedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.RequestExecution();
            server_release = call.server_release;
        }

        // on_client_connected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_client_connected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_client_connected_delegate on_client_connected_native;
        private static IntPtr on_client_connected_native_ptr;

        internal static void on_client_connected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var call = new CfxServerHandlerOnClientConnectedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.RequestExecution();
            server_release = call.server_release;
        }

        // on_client_disconnected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_client_disconnected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_client_disconnected_delegate on_client_disconnected_native;
        private static IntPtr on_client_disconnected_native_ptr;

        internal static void on_client_disconnected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var call = new CfxServerHandlerOnClientDisconnectedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.RequestExecution();
            server_release = call.server_release;
        }

        // on_http_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_http_request_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release);
        private static on_http_request_delegate on_http_request_native;
        private static IntPtr on_http_request_native_ptr;

        internal static void on_http_request(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release) {
            var call = new CfxServerHandlerOnHttpRequestRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.client_address_str = client_address_str;
            call.client_address_length = client_address_length;
            call.request = request;
            call.RequestExecution();
            server_release = call.server_release;
            request_release = call.request_release;
        }

        // on_web_socket_request
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_request_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release, IntPtr callback, out int callback_release);
        private static on_web_socket_request_delegate on_web_socket_request_native;
        private static IntPtr on_web_socket_request_native_ptr;

        internal static void on_web_socket_request(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr client_address_str, int client_address_length, IntPtr request, out int request_release, IntPtr callback, out int callback_release) {
            var call = new CfxServerHandlerOnWebSocketRequestRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.client_address_str = client_address_str;
            call.client_address_length = client_address_length;
            call.request = request;
            call.callback = callback;
            call.RequestExecution();
            server_release = call.server_release;
            request_release = call.request_release;
            callback_release = call.callback_release;
        }

        // on_web_socket_connected
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_connected_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id);
        private static on_web_socket_connected_delegate on_web_socket_connected_native;
        private static IntPtr on_web_socket_connected_native_ptr;

        internal static void on_web_socket_connected(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id) {
            var call = new CfxServerHandlerOnWebSocketConnectedRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.RequestExecution();
            server_release = call.server_release;
        }

        // on_web_socket_message
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_web_socket_message_delegate(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr data, UIntPtr data_size);
        private static on_web_socket_message_delegate on_web_socket_message_native;
        private static IntPtr on_web_socket_message_native_ptr;

        internal static void on_web_socket_message(IntPtr gcHandlePtr, IntPtr server, out int server_release, int connection_id, IntPtr data, UIntPtr data_size) {
            var call = new CfxServerHandlerOnWebSocketMessageRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.server = server;
            call.connection_id = connection_id;
            call.data = data;
            call.data_size = data_size;
            call.RequestExecution();
            server_release = call.server_release;
        }

    }
}
