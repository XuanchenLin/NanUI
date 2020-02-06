// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxV8ExceptionGetMessageRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetMessageRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetMessageRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_message(@this));
        }
    }

    internal class CfxV8ExceptionGetSourceLineRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetSourceLineRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetSourceLineRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_source_line(@this));
        }
    }

    internal class CfxV8ExceptionGetScriptResourceNameRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetScriptResourceNameRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetScriptResourceNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.V8Exception.cfx_v8exception_get_script_resource_name(@this));
        }
    }

    internal class CfxV8ExceptionGetLineNumberRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetLineNumberRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetLineNumberRemoteCall) {}

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
            __retval = CfxApi.V8Exception.cfx_v8exception_get_line_number(@this);
        }
    }

    internal class CfxV8ExceptionGetStartPositionRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetStartPositionRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetStartPositionRemoteCall) {}

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
            __retval = CfxApi.V8Exception.cfx_v8exception_get_start_position(@this);
        }
    }

    internal class CfxV8ExceptionGetEndPositionRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetEndPositionRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetEndPositionRemoteCall) {}

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
            __retval = CfxApi.V8Exception.cfx_v8exception_get_end_position(@this);
        }
    }

    internal class CfxV8ExceptionGetStartColumnRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetStartColumnRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetStartColumnRemoteCall) {}

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
            __retval = CfxApi.V8Exception.cfx_v8exception_get_start_column(@this);
        }
    }

    internal class CfxV8ExceptionGetEndColumnRemoteCall : RemoteCall {

        internal CfxV8ExceptionGetEndColumnRemoteCall()
            : base(RemoteCallId.CfxV8ExceptionGetEndColumnRemoteCall) {}

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
            __retval = CfxApi.V8Exception.cfx_v8exception_get_end_column(@this);
        }
    }

}
