// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxServerHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxServerHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxServerHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.ServerHandler.cfx_server_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxServerHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxServerHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxServerHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxServerHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxServerHandlerOnServerCreatedRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnServerCreatedRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnServerCreatedRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnServerCreatedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnServerCreated?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnServerDestroyedRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnServerDestroyedRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnServerDestroyedRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnServerDestroyedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnServerDestroyed?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnClientConnectedRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnClientConnectedRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnClientConnectedRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnClientConnectedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnClientConnected?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnClientDisconnectedRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnClientDisconnectedRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnClientDisconnectedRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnClientDisconnectedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnClientDisconnected?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnHttpRequestRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnHttpRequestRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnHttpRequestRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;
        internal IntPtr client_address_str;
        internal int client_address_length;
        internal IntPtr request;
        internal int request_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
            h.Write(client_address_str);
            h.Write(client_address_length);
            h.Write(request);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
            h.Read(out client_address_str);
            h.Read(out client_address_length);
            h.Read(out request);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
            h.Write(request_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
            h.Read(out request_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnHttpRequestEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnHttpRequest?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnWebSocketRequestRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnWebSocketRequestRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnWebSocketRequestRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;
        internal IntPtr client_address_str;
        internal int client_address_length;
        internal IntPtr request;
        internal int request_release;
        internal IntPtr callback;
        internal int callback_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
            h.Write(client_address_str);
            h.Write(client_address_length);
            h.Write(request);
            h.Write(callback);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
            h.Read(out client_address_str);
            h.Read(out client_address_length);
            h.Read(out request);
            h.Read(out callback);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
            h.Write(request_release);
            h.Write(callback_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
            h.Read(out request_release);
            h.Read(out callback_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnWebSocketRequestEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnWebSocketRequest?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnWebSocketConnectedRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnWebSocketConnectedRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnWebSocketConnectedRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnWebSocketConnectedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnWebSocketConnected?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

    internal class CfxServerHandlerOnWebSocketMessageRemoteEventCall : RemoteEventCall {

        internal CfxServerHandlerOnWebSocketMessageRemoteEventCall()
            : base(RemoteCallId.CfxServerHandlerOnWebSocketMessageRemoteEventCall) {}

        internal IntPtr server;
        internal int server_release;
        internal int connection_id;
        internal IntPtr data;
        internal UIntPtr data_size;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(server);
            h.Write(connection_id);
            h.Write(data);
            h.Write(data_size);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out server);
            h.Read(out connection_id);
            h.Read(out data);
            h.Read(out data_size);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(server_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out server_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrServerHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnWebSocketMessageEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnWebSocketMessage?.Invoke(self, e);
            e.connection = null;
            server_release = e.m_server_wrapped == null? 1 : 0;
        }
    }

}
