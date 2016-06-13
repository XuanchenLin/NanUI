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
	internal class CfxRuntimeCurrentlyOnRenderProcessCall : RenderProcessCall {

        internal CfxRuntimeCurrentlyOnRenderProcessCall()
            : base(RemoteCallId.CfxRuntimeCurrentlyOnRenderProcessCall) {}

        internal int threadId;
        internal bool __retval;

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
            __retval = CfxRuntime.CurrentlyOn((CfxThreadId)threadId);
        }
    }

    internal class CfxRuntimeFormatUrlForSecurityDisplayRenderProcessCall : RenderProcessCall {

        internal CfxRuntimeFormatUrlForSecurityDisplayRenderProcessCall()
            : base(RemoteCallId.CfxRuntimeFormatUrlForSecurityDisplayRenderProcessCall) {}

        internal string originUrl;
        internal string languages;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(originUrl);
            h.Write(languages);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out originUrl);
            h.Read(out languages);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = CfxRuntime.FormatUrlForSecurityDisplay(originUrl, languages);
        }
    }

    internal class CfxRuntimePostDelayedTaskRenderProcessCall : RenderProcessCall {

        internal CfxRuntimePostDelayedTaskRenderProcessCall()
            : base(RemoteCallId.CfxRuntimePostDelayedTaskRenderProcessCall) {}

        internal int threadId;
        internal IntPtr task;
        internal long delayMs;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(threadId);
            h.Write(task);
            h.Write(delayMs);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out threadId);
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
            __retval = CfxRuntime.PostDelayedTask((CfxThreadId)threadId, (CfxTask)RemoteProxy.Unwrap(task), delayMs);
        }
    }

    internal class CfxRuntimePostTaskRenderProcessCall : RenderProcessCall {

        internal CfxRuntimePostTaskRenderProcessCall()
            : base(RemoteCallId.CfxRuntimePostTaskRenderProcessCall) {}

        internal int threadId;
        internal IntPtr task;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(threadId);
            h.Write(task);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out threadId);
            h.Read(out task);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = CfxRuntime.PostTask((CfxThreadId)threadId, (CfxTask)RemoteProxy.Unwrap(task));
        }
    }

    internal class CfxRuntimeRegisterExtensionRenderProcessCall : RenderProcessCall {

        internal CfxRuntimeRegisterExtensionRenderProcessCall()
            : base(RemoteCallId.CfxRuntimeRegisterExtensionRenderProcessCall) {}

        internal string extensionName;
        internal string javascriptCode;
        internal IntPtr handler;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(extensionName);
            h.Write(javascriptCode);
            h.Write(handler);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out extensionName);
            h.Read(out javascriptCode);
            h.Read(out handler);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = CfxRuntime.RegisterExtension(extensionName, javascriptCode, (CfxV8Handler)RemoteProxy.Unwrap(handler));
        }
    }

}
