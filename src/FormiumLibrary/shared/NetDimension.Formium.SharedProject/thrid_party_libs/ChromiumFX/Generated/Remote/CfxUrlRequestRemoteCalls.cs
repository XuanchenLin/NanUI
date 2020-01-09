// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxUrlRequestGetRequestRemoteCall : RemoteCall {

        internal CfxUrlRequestGetRequestRemoteCall()
            : base(RemoteCallId.CfxUrlRequestGetRequestRemoteCall) {}

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
            __retval = CfxApi.UrlRequest.cfx_urlrequest_get_request(@this);
        }
    }

    internal class CfxUrlRequestGetClientRemoteCall : RemoteCall {

        internal CfxUrlRequestGetClientRemoteCall()
            : base(RemoteCallId.CfxUrlRequestGetClientRemoteCall) {}

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
            __retval = CfxApi.UrlRequest.cfx_urlrequest_get_client(@this);
        }
    }

    internal class CfxUrlRequestGetRequestStatusRemoteCall : RemoteCall {

        internal CfxUrlRequestGetRequestStatusRemoteCall()
            : base(RemoteCallId.CfxUrlRequestGetRequestStatusRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

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
            __retval = CfxApi.UrlRequest.cfx_urlrequest_get_request_status(@this);
        }
    }

    internal class CfxUrlRequestGetRequestErrorRemoteCall : RemoteCall {

        internal CfxUrlRequestGetRequestErrorRemoteCall()
            : base(RemoteCallId.CfxUrlRequestGetRequestErrorRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

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
            __retval = CfxApi.UrlRequest.cfx_urlrequest_get_request_error(@this);
        }
    }

    internal class CfxUrlRequestGetResponseRemoteCall : RemoteCall {

        internal CfxUrlRequestGetResponseRemoteCall()
            : base(RemoteCallId.CfxUrlRequestGetResponseRemoteCall) {}

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
            __retval = CfxApi.UrlRequest.cfx_urlrequest_get_response(@this);
        }
    }

    internal class CfxUrlRequestResponseWasCachedRemoteCall : RemoteCall {

        internal CfxUrlRequestResponseWasCachedRemoteCall()
            : base(RemoteCallId.CfxUrlRequestResponseWasCachedRemoteCall) {}

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
            __retval = 0 != CfxApi.UrlRequest.cfx_urlrequest_response_was_cached(@this);
        }
    }

    internal class CfxUrlRequestCancelRemoteCall : RemoteCall {

        internal CfxUrlRequestCancelRemoteCall()
            : base(RemoteCallId.CfxUrlRequestCancelRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.UrlRequest.cfx_urlrequest_cancel(@this);
        }
    }

}
