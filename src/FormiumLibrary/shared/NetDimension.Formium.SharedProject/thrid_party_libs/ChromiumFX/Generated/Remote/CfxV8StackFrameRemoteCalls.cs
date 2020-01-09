// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxV8StackFrameIsValidRemoteCall : RemoteCall {

        internal CfxV8StackFrameIsValidRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_valid(@this);
        }
    }

    internal class CfxV8StackFrameGetScriptNameRemoteCall : RemoteCall {

        internal CfxV8StackFrameGetScriptNameRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameGetScriptNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name(@this));
        }
    }

    internal class CfxV8StackFrameGetScriptNameOrSourceUrlRemoteCall : RemoteCall {

        internal CfxV8StackFrameGetScriptNameOrSourceUrlRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameGetScriptNameOrSourceUrlRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_script_name_or_source_url(@this));
        }
    }

    internal class CfxV8StackFrameGetFunctionNameRemoteCall : RemoteCall {

        internal CfxV8StackFrameGetFunctionNameRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameGetFunctionNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8StackFrame.cfx_v8stack_frame_get_function_name(@this));
        }
    }

    internal class CfxV8StackFrameGetLineNumberRemoteCall : RemoteCall {

        internal CfxV8StackFrameGetLineNumberRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameGetLineNumberRemoteCall) {}

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
            __retval = CfxApi.V8StackFrame.cfx_v8stack_frame_get_line_number(@this);
        }
    }

    internal class CfxV8StackFrameGetColumnRemoteCall : RemoteCall {

        internal CfxV8StackFrameGetColumnRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameGetColumnRemoteCall) {}

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
            __retval = CfxApi.V8StackFrame.cfx_v8stack_frame_get_column(@this);
        }
    }

    internal class CfxV8StackFrameIsEvalRemoteCall : RemoteCall {

        internal CfxV8StackFrameIsEvalRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameIsEvalRemoteCall) {}

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
            __retval = 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_eval(@this);
        }
    }

    internal class CfxV8StackFrameIsConstructorRemoteCall : RemoteCall {

        internal CfxV8StackFrameIsConstructorRemoteCall()
            : base(RemoteCallId.CfxV8StackFrameIsConstructorRemoteCall) {}

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
            __retval = 0 != CfxApi.V8StackFrame.cfx_v8stack_frame_is_constructor(@this);
        }
    }

}
