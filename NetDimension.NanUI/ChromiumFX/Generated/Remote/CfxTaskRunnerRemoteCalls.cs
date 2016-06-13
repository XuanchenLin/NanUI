// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote
{

	internal class CfxTaskRunnerGetForCurrentThreadRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerGetForCurrentThreadRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerGetForCurrentThreadRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxTaskRunner.GetForCurrentThread());
        }
    }

    internal class CfxTaskRunnerGetForThreadRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerGetForThreadRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerGetForThreadRenderProcessCall) {}

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

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxTaskRunner.GetForThread((CfxThreadId)threadId));
        }
    }

    internal class CfxTaskRunnerIsSameRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerIsSameRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerIsSameRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr that;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(that);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out that);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxTaskRunner)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxTaskRunner)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxTaskRunnerBelongsToCurrentThreadRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerBelongsToCurrentThreadRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerBelongsToCurrentThreadRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxTaskRunner)RemoteProxy.Unwrap(self);
            __retval = self_local.BelongsToCurrentThread();
        }
    }

    internal class CfxTaskRunnerBelongsToThreadRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerBelongsToThreadRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerBelongsToThreadRenderProcessCall) {}

        internal IntPtr self;
        internal int threadId;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(threadId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out threadId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxTaskRunner)RemoteProxy.Unwrap(self);
            __retval = self_local.BelongsToThread((CfxThreadId)threadId);
        }
    }

    internal class CfxTaskRunnerPostTaskRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerPostTaskRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerPostTaskRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr task;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(task);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out task);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxTaskRunner)RemoteProxy.Unwrap(self);
            __retval = self_local.PostTask((CfxTask)RemoteProxy.Unwrap(task));
        }
    }

    internal class CfxTaskRunnerPostDelayedTaskRenderProcessCall : RenderProcessCall {

        internal CfxTaskRunnerPostDelayedTaskRenderProcessCall()
            : base(RemoteCallId.CfxTaskRunnerPostDelayedTaskRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr task;
        internal long delayMs;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(task);
            h.Write(delayMs);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out task);
            h.Read(out delayMs);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxTaskRunner)RemoteProxy.Unwrap(self);
            __retval = self_local.PostDelayedTask((CfxTask)RemoteProxy.Unwrap(task), delayMs);
        }
    }

}
