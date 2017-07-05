// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxV8ContextGetCurrentContextRemoteCall : RemoteCall {

        internal CfxV8ContextGetCurrentContextRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetCurrentContextRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Context.cfx_v8context_get_current_context();
        }
    }

    internal class CfxV8ContextGetEnteredContextRemoteCall : RemoteCall {

        internal CfxV8ContextGetEnteredContextRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetEnteredContextRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.V8Context.cfx_v8context_get_entered_context();
        }
    }

    internal class CfxV8ContextInContextRemoteCall : RemoteCall {

        internal CfxV8ContextInContextRemoteCall()
            : base(RemoteCallId.CfxV8ContextInContextRemoteCall) {}

        internal bool __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.V8Context.cfx_v8context_in_context();
        }
    }

    internal class CfxV8ContextGetTaskRunnerRemoteCall : RemoteCall {

        internal CfxV8ContextGetTaskRunnerRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetTaskRunnerRemoteCall) {}

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
            __retval = CfxApi.V8Context.cfx_v8context_get_task_runner(@this);
        }
    }

    internal class CfxV8ContextIsValidRemoteCall : RemoteCall {

        internal CfxV8ContextIsValidRemoteCall()
            : base(RemoteCallId.CfxV8ContextIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.V8Context.cfx_v8context_is_valid(@this);
        }
    }

    internal class CfxV8ContextGetBrowserRemoteCall : RemoteCall {

        internal CfxV8ContextGetBrowserRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetBrowserRemoteCall) {}

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
            __retval = CfxApi.V8Context.cfx_v8context_get_browser(@this);
        }
    }

    internal class CfxV8ContextGetFrameRemoteCall : RemoteCall {

        internal CfxV8ContextGetFrameRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetFrameRemoteCall) {}

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
            __retval = CfxApi.V8Context.cfx_v8context_get_frame(@this);
        }
    }

    internal class CfxV8ContextGetGlobalRemoteCall : RemoteCall {

        internal CfxV8ContextGetGlobalRemoteCall()
            : base(RemoteCallId.CfxV8ContextGetGlobalRemoteCall) {}

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
            __retval = CfxApi.V8Context.cfx_v8context_get_global(@this);
        }
    }

    internal class CfxV8ContextEnterRemoteCall : RemoteCall {

        internal CfxV8ContextEnterRemoteCall()
            : base(RemoteCallId.CfxV8ContextEnterRemoteCall) {}

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
            __retval = 0 != CfxApi.V8Context.cfx_v8context_enter(@this);
        }
    }

    internal class CfxV8ContextExitRemoteCall : RemoteCall {

        internal CfxV8ContextExitRemoteCall()
            : base(RemoteCallId.CfxV8ContextExitRemoteCall) {}

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
            __retval = 0 != CfxApi.V8Context.cfx_v8context_exit(@this);
        }
    }

    internal class CfxV8ContextIsSameRemoteCall : RemoteCall {

        internal CfxV8ContextIsSameRemoteCall()
            : base(RemoteCallId.CfxV8ContextIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.V8Context.cfx_v8context_is_same(@this, that);
        }
    }

    internal class CfxV8ContextEvalRemoteCall : RemoteCall {

        internal CfxV8ContextEvalRemoteCall()
            : base(RemoteCallId.CfxV8ContextEvalRemoteCall) {}

        internal IntPtr @this;
        internal string code;
        internal string scriptUrl;
        internal int startLine;
        internal IntPtr retval;
        internal IntPtr exception;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(code);
            h.Write(scriptUrl);
            h.Write(startLine);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out code);
            h.Read(out scriptUrl);
            h.Read(out startLine);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(retval);
            h.Write(exception);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out retval);
            h.Read(out exception);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var code_pinned = new PinnedString(code);
            var scriptUrl_pinned = new PinnedString(scriptUrl);
            __retval = 0 != CfxApi.V8Context.cfx_v8context_eval(@this, code_pinned.Obj.PinnedPtr, code_pinned.Length, scriptUrl_pinned.Obj.PinnedPtr, scriptUrl_pinned.Length, startLine, out retval, out exception);
            code_pinned.Obj.Free();
            scriptUrl_pinned.Obj.Free();
        }
    }

}
