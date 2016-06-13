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

	internal class CfxV8ExceptionGetMessageRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetMessageRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetMessageRenderProcessCall) {}

        internal IntPtr self;
        internal string __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.Message;
        }
    }

    internal class CfxV8ExceptionGetSourceLineRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetSourceLineRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetSourceLineRenderProcessCall) {}

        internal IntPtr self;
        internal string __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.SourceLine;
        }
    }

    internal class CfxV8ExceptionGetScriptResourceNameRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetScriptResourceNameRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetScriptResourceNameRenderProcessCall) {}

        internal IntPtr self;
        internal string __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.ScriptResourceName;
        }
    }

    internal class CfxV8ExceptionGetLineNumberRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetLineNumberRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetLineNumberRenderProcessCall) {}

        internal IntPtr self;
        internal int __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.LineNumber;
        }
    }

    internal class CfxV8ExceptionGetStartPositionRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetStartPositionRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetStartPositionRenderProcessCall) {}

        internal IntPtr self;
        internal int __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.StartPosition;
        }
    }

    internal class CfxV8ExceptionGetEndPositionRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetEndPositionRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetEndPositionRenderProcessCall) {}

        internal IntPtr self;
        internal int __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.EndPosition;
        }
    }

    internal class CfxV8ExceptionGetStartColumnRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetStartColumnRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetStartColumnRenderProcessCall) {}

        internal IntPtr self;
        internal int __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.StartColumn;
        }
    }

    internal class CfxV8ExceptionGetEndColumnRenderProcessCall : RenderProcessCall {

        internal CfxV8ExceptionGetEndColumnRenderProcessCall()
            : base(RemoteCallId.CfxV8ExceptionGetEndColumnRenderProcessCall) {}

        internal IntPtr self;
        internal int __retval;

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
            var self_local = (CfxV8Exception)RemoteProxy.Unwrap(self);
            __retval = self_local.EndColumn;
        }
    }

}
