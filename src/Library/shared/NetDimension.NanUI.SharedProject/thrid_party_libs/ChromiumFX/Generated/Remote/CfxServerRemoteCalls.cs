// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxServerCreateRemoteCall : RemoteCall {

        internal CfxServerCreateRemoteCall()
            : base(RemoteCallId.CfxServerCreateRemoteCall) {}

        internal string address;
        internal ushort port;
        internal int backlog;
        internal IntPtr handler;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(address);
            h.Write(port);
            h.Write(backlog);
            h.Write(handler);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out address);
            h.Read(out port);
            h.Read(out backlog);
            h.Read(out handler);
        }

        protected override void RemoteProcedure() {
            var address_pinned = new PinnedString(address);
            CfxApi.Server.cfx_server_create(address_pinned.Obj.PinnedPtr, address_pinned.Length, port, backlog, handler);
            address_pinned.Obj.Free();
        }
    }

    internal class CfxServerGetTaskRunnerRemoteCall : RemoteCall {

        internal CfxServerGetTaskRunnerRemoteCall()
            : base(RemoteCallId.CfxServerGetTaskRunnerRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Server.cfx_server_get_task_runner(@this);
        }
    }

    internal class CfxServerShutdownRemoteCall : RemoteCall {

        internal CfxServerShutdownRemoteCall()
            : base(RemoteCallId.CfxServerShutdownRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Server.cfx_server_shutdown(@this);
        }
    }

    internal class CfxServerIsRunningRemoteCall : RemoteCall {

        internal CfxServerIsRunningRemoteCall()
            : base(RemoteCallId.CfxServerIsRunningRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Server.cfx_server_is_running(@this);
        }
    }

    internal class CfxServerGetAddressRemoteCall : RemoteCall {

        internal CfxServerGetAddressRemoteCall()
            : base(RemoteCallId.CfxServerGetAddressRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Server.cfx_server_get_address(@this));
        }
    }

    internal class CfxServerHasConnectionRemoteCall : RemoteCall {

        internal CfxServerHasConnectionRemoteCall()
            : base(RemoteCallId.CfxServerHasConnectionRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Server.cfx_server_has_connection(@this);
        }
    }

    internal class CfxServerIsValidConnectionRemoteCall : RemoteCall {

        internal CfxServerIsValidConnectionRemoteCall()
            : base(RemoteCallId.CfxServerIsValidConnectionRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.Server.cfx_server_is_valid_connection(@this, connectionId);
        }
    }

    internal class CfxServerSendHttp200responseRemoteCall : RemoteCall {

        internal CfxServerSendHttp200responseRemoteCall()
            : base(RemoteCallId.CfxServerSendHttp200responseRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal string contentType;
        internal IntPtr data;
        internal ulong dataSize;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
            h.Write(contentType);
            h.Write(data);
            h.Write(dataSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
            h.Read(out contentType);
            h.Read(out data);
            h.Read(out dataSize);
        }

        protected override void RemoteProcedure() {
            var contentType_pinned = new PinnedString(contentType);
            CfxApi.Server.cfx_server_send_http200response(@this, connectionId, contentType_pinned.Obj.PinnedPtr, contentType_pinned.Length, data, (UIntPtr)dataSize);
            contentType_pinned.Obj.Free();
        }
    }

    internal class CfxServerSendHttp404responseRemoteCall : RemoteCall {

        internal CfxServerSendHttp404responseRemoteCall()
            : base(RemoteCallId.CfxServerSendHttp404responseRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
        }

        protected override void RemoteProcedure() {
            CfxApi.Server.cfx_server_send_http404response(@this, connectionId);
        }
    }

    internal class CfxServerSendHttp500responseRemoteCall : RemoteCall {

        internal CfxServerSendHttp500responseRemoteCall()
            : base(RemoteCallId.CfxServerSendHttp500responseRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal string errorMessage;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
            h.Write(errorMessage);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
            h.Read(out errorMessage);
        }

        protected override void RemoteProcedure() {
            var errorMessage_pinned = new PinnedString(errorMessage);
            CfxApi.Server.cfx_server_send_http500response(@this, connectionId, errorMessage_pinned.Obj.PinnedPtr, errorMessage_pinned.Length);
            errorMessage_pinned.Obj.Free();
        }
    }

    internal class CfxServerSendHttpResponseRemoteCall : RemoteCall {

        internal CfxServerSendHttpResponseRemoteCall()
            : base(RemoteCallId.CfxServerSendHttpResponseRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal int responseCode;
        internal string contentType;
        internal long contentLength;
        internal System.Collections.Generic.List<string[]> extraHeaders;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
            h.Write(responseCode);
            h.Write(contentType);
            h.Write(contentLength);
            h.Write(extraHeaders);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
            h.Read(out responseCode);
            h.Read(out contentType);
            h.Read(out contentLength);
            h.Read(out extraHeaders);
        }

        protected override void RemoteProcedure() {
            var contentType_pinned = new PinnedString(contentType);
            PinnedString[] extraHeaders_handles;
            var extraHeaders_unwrapped = StringFunctions.UnwrapCfxStringMultimap(extraHeaders, out extraHeaders_handles);
            CfxApi.Server.cfx_server_send_http_response(@this, connectionId, responseCode, contentType_pinned.Obj.PinnedPtr, contentType_pinned.Length, contentLength, extraHeaders_unwrapped);
            contentType_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(extraHeaders_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(extraHeaders_unwrapped, extraHeaders);
            CfxApi.Runtime.cfx_string_multimap_free(extraHeaders_unwrapped);
        }
    }

    internal class CfxServerSendRawDataRemoteCall : RemoteCall {

        internal CfxServerSendRawDataRemoteCall()
            : base(RemoteCallId.CfxServerSendRawDataRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal IntPtr data;
        internal ulong dataSize;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
            h.Write(data);
            h.Write(dataSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
            h.Read(out data);
            h.Read(out dataSize);
        }

        protected override void RemoteProcedure() {
            CfxApi.Server.cfx_server_send_raw_data(@this, connectionId, data, (UIntPtr)dataSize);
        }
    }

    internal class CfxServerCloseConnectionRemoteCall : RemoteCall {

        internal CfxServerCloseConnectionRemoteCall()
            : base(RemoteCallId.CfxServerCloseConnectionRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
        }

        protected override void RemoteProcedure() {
            CfxApi.Server.cfx_server_close_connection(@this, connectionId);
        }
    }

    internal class CfxServerSendWebSocketMessageRemoteCall : RemoteCall {

        internal CfxServerSendWebSocketMessageRemoteCall()
            : base(RemoteCallId.CfxServerSendWebSocketMessageRemoteCall) {}

        internal IntPtr @this;
        internal int connectionId;
        internal IntPtr data;
        internal ulong dataSize;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(connectionId);
            h.Write(data);
            h.Write(dataSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out connectionId);
            h.Read(out data);
            h.Read(out dataSize);
        }

        protected override void RemoteProcedure() {
            CfxApi.Server.cfx_server_send_web_socket_message(@this, connectionId, data, (UIntPtr)dataSize);
        }
    }

}
