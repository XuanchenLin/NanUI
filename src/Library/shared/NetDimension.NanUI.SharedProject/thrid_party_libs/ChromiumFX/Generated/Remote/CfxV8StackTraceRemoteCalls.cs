// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxV8StackTraceGetCurrentRemoteCall : RemoteCall {

        internal CfxV8StackTraceGetCurrentRemoteCall()
            : base(RemoteCallId.CfxV8StackTraceGetCurrentRemoteCall) {}

        internal int frameLimit;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(frameLimit);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out frameLimit);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8StackTrace.cfx_v8stack_trace_get_current(frameLimit);
        }
    }

    internal class CfxV8StackTraceIsValidRemoteCall : RemoteCall {

        internal CfxV8StackTraceIsValidRemoteCall()
            : base(RemoteCallId.CfxV8StackTraceIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.V8StackTrace.cfx_v8stack_trace_is_valid(@this);
        }
    }

    internal class CfxV8StackTraceGetFrameCountRemoteCall : RemoteCall {

        internal CfxV8StackTraceGetFrameCountRemoteCall()
            : base(RemoteCallId.CfxV8StackTraceGetFrameCountRemoteCall) {}

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
            __retval = CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame_count(@this);
        }
    }

    internal class CfxV8StackTraceGetFrameRemoteCall : RemoteCall {

        internal CfxV8StackTraceGetFrameRemoteCall()
            : base(RemoteCallId.CfxV8StackTraceGetFrameRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8StackTrace.cfx_v8stack_trace_get_frame(@this, index);
        }
    }

}
