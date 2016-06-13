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

	internal class CfxV8AccessorCtorRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorCtorRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxV8Accessor());
        }
    }

    internal class CfxV8AccessorGetBrowserProcessCall : BrowserProcessCall {

        internal CfxV8AccessorGetBrowserProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxV8AccessorGetEventArgs e) {
            var call = new CfxV8AccessorGetBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrV8Accessor.Wrap(this.sender);
            var e = new CfrV8AccessorGetEventArgs(eventArgsId);
            sender.raise_Get(sender, e);
        }
    }

    internal class CfxV8AccessorGetActivateRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetActivateRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxV8Accessor)RemoteProxy.Unwrap(this.sender);
            sender.Get += CfxV8AccessorGetBrowserProcessCall.EventCall;
        }
    }

    internal class CfxV8AccessorGetDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxV8Accessor)RemoteProxy.Unwrap(this.sender);
            sender.Get -= CfxV8AccessorGetBrowserProcessCall.EventCall;
        }
    }

    internal class CfxV8AccessorGetGetNameRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetGetNameRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetGetNameRenderProcessCall) {}

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
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.Name;
        }
    }

    internal class CfxV8AccessorGetGetObjectRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetGetObjectRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetGetObjectRenderProcessCall) {}

        internal ulong eventArgsId;
        internal IntPtr value;

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
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Object);
        }
    }

    internal class CfxV8AccessorGetSetRetvalRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetSetRetvalRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetSetRetvalRenderProcessCall) {}

        internal ulong eventArgsId;
        internal IntPtr value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.Retval = (CfxV8Value)RemoteProxy.Unwrap(value);
        }
    }

    internal class CfxV8AccessorGetSetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetSetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetSetExceptionRenderProcessCall) {}

        internal ulong eventArgsId;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.Exception = value;
        }
    }

    internal class CfxV8AccessorGetGetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetGetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetGetExceptionRenderProcessCall) {}

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
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.Exception;
        }
    }

    internal class CfxV8AccessorGetSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorGetSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorGetSetReturnValueRenderProcessCall) {}

        internal ulong eventArgsId;
        internal bool value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxV8AccessorGetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

    internal class CfxV8AccessorSetBrowserProcessCall : BrowserProcessCall {

        internal CfxV8AccessorSetBrowserProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxV8AccessorSetEventArgs e) {
            var call = new CfxV8AccessorSetBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrV8Accessor.Wrap(this.sender);
            var e = new CfrV8AccessorSetEventArgs(eventArgsId);
            sender.raise_Set(sender, e);
        }
    }

    internal class CfxV8AccessorSetActivateRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetActivateRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxV8Accessor)RemoteProxy.Unwrap(this.sender);
            sender.Set += CfxV8AccessorSetBrowserProcessCall.EventCall;
        }
    }

    internal class CfxV8AccessorSetDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxV8Accessor)RemoteProxy.Unwrap(this.sender);
            sender.Set -= CfxV8AccessorSetBrowserProcessCall.EventCall;
        }
    }

    internal class CfxV8AccessorSetGetNameRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetGetNameRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetGetNameRenderProcessCall) {}

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
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.Name;
        }
    }

    internal class CfxV8AccessorSetGetObjectRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetGetObjectRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetGetObjectRenderProcessCall) {}

        internal ulong eventArgsId;
        internal IntPtr value;

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
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Object);
        }
    }

    internal class CfxV8AccessorSetGetValueRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetGetValueRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetGetValueRenderProcessCall) {}

        internal ulong eventArgsId;
        internal IntPtr value;

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
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Value);
        }
    }

    internal class CfxV8AccessorSetSetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetSetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetSetExceptionRenderProcessCall) {}

        internal ulong eventArgsId;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.Exception = value;
        }
    }

    internal class CfxV8AccessorSetGetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetGetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetGetExceptionRenderProcessCall) {}

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
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.Exception;
        }
    }

    internal class CfxV8AccessorSetSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxV8AccessorSetSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxV8AccessorSetSetReturnValueRenderProcessCall) {}

        internal ulong eventArgsId;
        internal bool value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxV8AccessorSetEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

}
