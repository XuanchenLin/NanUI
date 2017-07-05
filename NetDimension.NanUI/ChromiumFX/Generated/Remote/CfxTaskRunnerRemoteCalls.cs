// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxTaskRunnerGetForCurrentThreadRemoteCall : RemoteCall {

        internal CfxTaskRunnerGetForCurrentThreadRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerGetForCurrentThreadRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.TaskRunner.cfx_task_runner_get_for_current_thread();
        }
    }

    internal class CfxTaskRunnerGetForThreadRemoteCall : RemoteCall {

        internal CfxTaskRunnerGetForThreadRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerGetForThreadRemoteCall) {}

        internal int threadId;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(threadId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out threadId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.TaskRunner.cfx_task_runner_get_for_thread((int)threadId);
        }
    }

    internal class CfxTaskRunnerIsSameRemoteCall : RemoteCall {

        internal CfxTaskRunnerIsSameRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerIsSameRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr that;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(that);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out that);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.TaskRunner.cfx_task_runner_is_same(@this, that);
        }
    }

    internal class CfxTaskRunnerBelongsToCurrentThreadRemoteCall : RemoteCall {

        internal CfxTaskRunnerBelongsToCurrentThreadRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerBelongsToCurrentThreadRemoteCall) {}

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
            __retval = 0 != CfxApi.TaskRunner.cfx_task_runner_belongs_to_current_thread(@this);
        }
    }

    internal class CfxTaskRunnerBelongsToThreadRemoteCall : RemoteCall {

        internal CfxTaskRunnerBelongsToThreadRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerBelongsToThreadRemoteCall) {}

        internal IntPtr @this;
        internal int threadId;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(threadId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out threadId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.TaskRunner.cfx_task_runner_belongs_to_thread(@this, (int)threadId);
        }
    }

    internal class CfxTaskRunnerPostTaskRemoteCall : RemoteCall {

        internal CfxTaskRunnerPostTaskRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerPostTaskRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr task;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(task);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out task);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.TaskRunner.cfx_task_runner_post_task(@this, task);
        }
    }

    internal class CfxTaskRunnerPostDelayedTaskRemoteCall : RemoteCall {

        internal CfxTaskRunnerPostDelayedTaskRemoteCall()
            : base(RemoteCallId.CfxTaskRunnerPostDelayedTaskRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr task;
        internal long delayMs;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(task);
            h.Write(delayMs);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out task);
            h.Read(out delayMs);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.TaskRunner.cfx_task_runner_post_delayed_task(@this, task, delayMs);
        }
    }

}
