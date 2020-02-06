// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxUrlRequestClientCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxUrlRequestClientCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxUrlRequestClientCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.UrlRequestClient.cfx_urlrequest_client_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxUrlRequestClientGetGcHandleRemoteCall : GetGcHandleRemoteCall {

        internal CfxUrlRequestClientGetGcHandleRemoteCall()
            : base(RemoteCallId.CfxUrlRequestClientGetGcHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            gc_handle = CfxApi.UrlRequestClient.cfx_urlrequest_client_get_gc_handle(self);
        }
    }

    internal class CfxUrlRequestClientSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxUrlRequestClientSetCallbackRemoteCall()
            : base(RemoteCallId.CfxUrlRequestClientSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxUrlRequestClientRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxUrlRequestClientOnRequestCompleteRemoteEventCall : RemoteEventCall {

        internal CfxUrlRequestClientOnRequestCompleteRemoteEventCall()
            : base(RemoteCallId.CfxUrlRequestClientOnRequestCompleteRemoteEventCall) {}

        internal IntPtr request;
        internal int request_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(request);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out request);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(request_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out request_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnRequestCompleteEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnRequestComplete?.Invoke(self, e);
            e.connection = null;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }
    }

    internal class CfxUrlRequestClientOnUploadProgressRemoteEventCall : RemoteEventCall {

        internal CfxUrlRequestClientOnUploadProgressRemoteEventCall()
            : base(RemoteCallId.CfxUrlRequestClientOnUploadProgressRemoteEventCall) {}

        internal IntPtr request;
        internal int request_release;
        internal long current;
        internal long total;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(request);
            h.Write(current);
            h.Write(total);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out request);
            h.Read(out current);
            h.Read(out total);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(request_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out request_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnUploadProgressEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnUploadProgress?.Invoke(self, e);
            e.connection = null;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }
    }

    internal class CfxUrlRequestClientOnDownloadProgressRemoteEventCall : RemoteEventCall {

        internal CfxUrlRequestClientOnDownloadProgressRemoteEventCall()
            : base(RemoteCallId.CfxUrlRequestClientOnDownloadProgressRemoteEventCall) {}

        internal IntPtr request;
        internal int request_release;
        internal long current;
        internal long total;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(request);
            h.Write(current);
            h.Write(total);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out request);
            h.Read(out current);
            h.Read(out total);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(request_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out request_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnDownloadProgressEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnDownloadProgress?.Invoke(self, e);
            e.connection = null;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }
    }

    internal class CfxUrlRequestClientOnDownloadDataRemoteEventCall : RemoteEventCall {

        internal CfxUrlRequestClientOnDownloadDataRemoteEventCall()
            : base(RemoteCallId.CfxUrlRequestClientOnDownloadDataRemoteEventCall) {}

        internal IntPtr request;
        internal int request_release;
        internal IntPtr data;
        internal UIntPtr data_length;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(request);
            h.Write(data);
            h.Write(data_length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out request);
            h.Read(out data);
            h.Read(out data_length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(request_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out request_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnDownloadDataEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnDownloadData?.Invoke(self, e);
            e.connection = null;
            request_release = e.m_request_wrapped == null? 1 : 0;
        }
    }

    internal class CfxUrlRequestClientGetAuthCredentialsRemoteEventCall : RemoteEventCall {

        internal CfxUrlRequestClientGetAuthCredentialsRemoteEventCall()
            : base(RemoteCallId.CfxUrlRequestClientGetAuthCredentialsRemoteEventCall) {}

        internal int isProxy;
        internal IntPtr host_str;
        internal int host_length;
        internal int port;
        internal IntPtr realm_str;
        internal int realm_length;
        internal IntPtr scheme_str;
        internal int scheme_length;
        internal IntPtr callback;
        internal int callback_release;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(isProxy);
            h.Write(host_str);
            h.Write(host_length);
            h.Write(port);
            h.Write(realm_str);
            h.Write(realm_length);
            h.Write(scheme_str);
            h.Write(scheme_length);
            h.Write(callback);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out isProxy);
            h.Read(out host_str);
            h.Read(out host_length);
            h.Read(out port);
            h.Read(out realm_str);
            h.Read(out realm_length);
            h.Read(out scheme_str);
            h.Read(out scheme_length);
            h.Read(out callback);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(callback_release);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out callback_release);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrUrlRequestClient)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrUrlRequestClientGetAuthCredentialsEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetAuthCredentials?.Invoke(self, e);
            e.connection = null;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
