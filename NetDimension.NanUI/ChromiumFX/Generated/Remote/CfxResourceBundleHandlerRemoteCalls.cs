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

	internal class CfxResourceBundleHandlerCtorRenderProcessCall : RenderProcessCall {

        internal CfxResourceBundleHandlerCtorRenderProcessCall()
            : base(RemoteCallId.CfxResourceBundleHandlerCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxResourceBundleHandler());
        }
    }

    internal class CfxGetLocalizedStringBrowserProcessCall : BrowserProcessCall {

        internal CfxGetLocalizedStringBrowserProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetLocalizedStringEventArgs e) {
            var call = new CfxGetLocalizedStringBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrResourceBundleHandler.Wrap(this.sender);
            var e = new CfrGetLocalizedStringEventArgs(eventArgsId);
            sender.raise_GetLocalizedString(sender, e);
        }
    }

    internal class CfxGetLocalizedStringActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetLocalizedString += CfxGetLocalizedStringBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetLocalizedStringDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetLocalizedString -= CfxGetLocalizedStringBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetLocalizedStringGetStringIdRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringGetStringIdRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringGetStringIdRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

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
            var e = (CfxGetLocalizedStringEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.StringId;
        }
    }

    internal class CfxGetLocalizedStringSetStringRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringSetStringRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringSetStringRenderProcessCall) {}

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
            var e = (CfxGetLocalizedStringEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.String = value;
        }
    }

    internal class CfxGetLocalizedStringGetStringRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringGetStringRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringGetStringRenderProcessCall) {}

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
            var e = (CfxGetLocalizedStringEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.String;
        }
    }

    internal class CfxGetLocalizedStringSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetLocalizedStringSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetLocalizedStringSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetLocalizedStringEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

    internal class CfxGetDataResourceBrowserProcessCall : BrowserProcessCall {

        internal CfxGetDataResourceBrowserProcessCall()
            : base(RemoteCallId.CfxGetDataResourceBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetDataResourceEventArgs e) {
            var call = new CfxGetDataResourceBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrResourceBundleHandler.Wrap(this.sender);
            var e = new CfrGetDataResourceEventArgs(eventArgsId);
            sender.raise_GetDataResource(sender, e);
        }
    }

    internal class CfxGetDataResourceActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetDataResource += CfxGetDataResourceBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetDataResourceDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetDataResource -= CfxGetDataResourceBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetDataResourceGetResourceIdRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceGetResourceIdRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceGetResourceIdRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

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
            var e = (CfxGetDataResourceEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.ResourceId;
        }
    }

    internal class CfxGetDataResourceSetDataRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceSetDataRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceSetDataRenderProcessCall) {}

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
            var e = (CfxGetDataResourceEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.Data = value;
        }
    }

    internal class CfxGetDataResourceSetDataSizeRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceSetDataSizeRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceSetDataSizeRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxGetDataResourceEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.DataSize = value;
        }
    }

    internal class CfxGetDataResourceSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetDataResourceEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

    internal class CfxGetDataResourceForScaleBrowserProcessCall : BrowserProcessCall {

        internal CfxGetDataResourceForScaleBrowserProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetDataResourceForScaleEventArgs e) {
            var call = new CfxGetDataResourceForScaleBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrResourceBundleHandler.Wrap(this.sender);
            var e = new CfrGetDataResourceForScaleEventArgs(eventArgsId);
            sender.raise_GetDataResourceForScale(sender, e);
        }
    }

    internal class CfxGetDataResourceForScaleActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetDataResourceForScale += CfxGetDataResourceForScaleBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetDataResourceForScaleDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxResourceBundleHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetDataResourceForScale -= CfxGetDataResourceForScaleBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetDataResourceForScaleGetResourceIdRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleGetResourceIdRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleGetResourceIdRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

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
            var e = (CfxGetDataResourceForScaleEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.ResourceId;
        }
    }

    internal class CfxGetDataResourceForScaleGetScaleFactorRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleGetScaleFactorRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleGetScaleFactorRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

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
            var e = (CfxGetDataResourceForScaleEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = (int)e.ScaleFactor;
        }
    }

    internal class CfxGetDataResourceForScaleSetDataRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleSetDataRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleSetDataRenderProcessCall) {}

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
            var e = (CfxGetDataResourceForScaleEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.Data = value;
        }
    }

    internal class CfxGetDataResourceForScaleSetDataSizeRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleSetDataSizeRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleSetDataSizeRenderProcessCall) {}

        internal ulong eventArgsId;
        internal int value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(eventArgsId);
            h.Write(value);
        }
        protected override void ReadArgs(StreamHandler h) {
            h.Read(out eventArgsId);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var e = (CfxGetDataResourceForScaleEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.DataSize = value;
        }
    }

    internal class CfxGetDataResourceForScaleSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetDataResourceForScaleSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetDataResourceForScaleSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetDataResourceForScaleEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

}
