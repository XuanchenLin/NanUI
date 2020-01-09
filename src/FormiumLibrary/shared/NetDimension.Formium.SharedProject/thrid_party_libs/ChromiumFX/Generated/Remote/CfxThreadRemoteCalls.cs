// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxThreadCreateRemoteCall : RemoteCall {

        internal CfxThreadCreateRemoteCall()
            : base(RemoteCallId.CfxThreadCreateRemoteCall) {}

        internal string displayName;
        internal int priority;
        internal int messageLoopType;
        internal bool stoppable;
        internal int comInitMode;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(displayName);
            h.Write(priority);
            h.Write(messageLoopType);
            h.Write(stoppable);
            h.Write(comInitMode);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out displayName);
            h.Read(out priority);
            h.Read(out messageLoopType);
            h.Read(out stoppable);
            h.Read(out comInitMode);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var displayName_pinned = new PinnedString(displayName);
            __retval = CfxApi.Thread.cfx_thread_create(displayName_pinned.Obj.PinnedPtr, displayName_pinned.Length, (int)priority, (int)messageLoopType, stoppable ? 1 : 0, (int)comInitMode);
            displayName_pinned.Obj.Free();
        }
    }

    internal class CfxThreadGetTaskRunnerRemoteCall : RemoteCall {

        internal CfxThreadGetTaskRunnerRemoteCall()
            : base(RemoteCallId.CfxThreadGetTaskRunnerRemoteCall) {}

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
            __retval = CfxApi.Thread.cfx_thread_get_task_runner(@this);
        }
    }

    internal class CfxThreadGetPlatformThreadIdRemoteCall : RemoteCall {

        internal CfxThreadGetPlatformThreadIdRemoteCall()
            : base(RemoteCallId.CfxThreadGetPlatformThreadIdRemoteCall) {}

        internal IntPtr @this;
        internal uint __retval;

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
            __retval = CfxApi.Thread.cfx_thread_get_platform_thread_id(@this);
        }
    }

    internal class CfxThreadStopRemoteCall : RemoteCall {

        internal CfxThreadStopRemoteCall()
            : base(RemoteCallId.CfxThreadStopRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Thread.cfx_thread_stop(@this);
        }
    }

    internal class CfxThreadIsRunningRemoteCall : RemoteCall {

        internal CfxThreadIsRunningRemoteCall()
            : base(RemoteCallId.CfxThreadIsRunningRemoteCall) {}

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
            __retval = 0 != CfxApi.Thread.cfx_thread_is_running(@this);
        }
    }

}
