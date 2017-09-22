// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxWaitableEventCreateRemoteCall : RemoteCall {

        internal CfxWaitableEventCreateRemoteCall()
            : base(RemoteCallId.CfxWaitableEventCreateRemoteCall) {}

        internal bool automaticReset;
        internal bool initiallySignaled;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(automaticReset);
            h.Write(initiallySignaled);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out automaticReset);
            h.Read(out initiallySignaled);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.WaitableEvent.cfx_waitable_event_create(automaticReset ? 1 : 0, initiallySignaled ? 1 : 0);
        }
    }

    internal class CfxWaitableEventResetRemoteCall : RemoteCall {

        internal CfxWaitableEventResetRemoteCall()
            : base(RemoteCallId.CfxWaitableEventResetRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.WaitableEvent.cfx_waitable_event_reset(@this);
        }
    }

    internal class CfxWaitableEventSignalRemoteCall : RemoteCall {

        internal CfxWaitableEventSignalRemoteCall()
            : base(RemoteCallId.CfxWaitableEventSignalRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.WaitableEvent.cfx_waitable_event_signal(@this);
        }
    }

    internal class CfxWaitableEventIsSignaledRemoteCall : RemoteCall {

        internal CfxWaitableEventIsSignaledRemoteCall()
            : base(RemoteCallId.CfxWaitableEventIsSignaledRemoteCall) {}

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
            __retval = 0 != CfxApi.WaitableEvent.cfx_waitable_event_is_signaled(@this);
        }
    }

    internal class CfxWaitableEventWaitRemoteCall : RemoteCall {

        internal CfxWaitableEventWaitRemoteCall()
            : base(RemoteCallId.CfxWaitableEventWaitRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.WaitableEvent.cfx_waitable_event_wait(@this);
        }
    }

    internal class CfxWaitableEventTimedWaitRemoteCall : RemoteCall {

        internal CfxWaitableEventTimedWaitRemoteCall()
            : base(RemoteCallId.CfxWaitableEventTimedWaitRemoteCall) {}

        internal IntPtr @this;
        internal long maxMs;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(maxMs);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out maxMs);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.WaitableEvent.cfx_waitable_event_timed_wait(@this, maxMs);
        }
    }

}
