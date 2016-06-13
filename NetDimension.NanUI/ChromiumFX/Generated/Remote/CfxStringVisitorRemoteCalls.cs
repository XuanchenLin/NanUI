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
	using Chromium.Event;
	using Event;

	internal class CfxStringVisitorCtorRenderProcessCall : RenderProcessCall {

        internal CfxStringVisitorCtorRenderProcessCall()
            : base(RemoteCallId.CfxStringVisitorCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxStringVisitor());
        }
    }

    internal class CfxStringVisitorVisitBrowserProcessCall : BrowserProcessCall {

        internal CfxStringVisitorVisitBrowserProcessCall()
            : base(RemoteCallId.CfxStringVisitorVisitBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxStringVisitorVisitEventArgs e) {
            var call = new CfxStringVisitorVisitBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrStringVisitor.Wrap(this.sender);
            var e = new CfrStringVisitorVisitEventArgs(eventArgsId);
            sender.raise_Visit(sender, e);
        }
    }

    internal class CfxStringVisitorVisitActivateRenderProcessCall : RenderProcessCall {

        internal CfxStringVisitorVisitActivateRenderProcessCall()
            : base(RemoteCallId.CfxStringVisitorVisitActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxStringVisitor)RemoteProxy.Unwrap(this.sender);
            sender.Visit += CfxStringVisitorVisitBrowserProcessCall.EventCall;
        }
    }

    internal class CfxStringVisitorVisitDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxStringVisitorVisitDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxStringVisitorVisitDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxStringVisitor)RemoteProxy.Unwrap(this.sender);
            sender.Visit -= CfxStringVisitorVisitBrowserProcessCall.EventCall;
        }
    }

    internal class CfxStringVisitorVisitGetStringRenderProcessCall : RenderProcessCall {

        internal CfxStringVisitorVisitGetStringRenderProcessCall()
            : base(RemoteCallId.CfxStringVisitorVisitGetStringRenderProcessCall) {}

        internal ulong eventArgsId;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
        }
        protected override void WriteReturn(StreamHandler h) {
            h.Write(value);
        }
        protected override void ReadReturn(StreamHandler h) {
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxStringVisitorVisitEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.String;
        }
    }

}
