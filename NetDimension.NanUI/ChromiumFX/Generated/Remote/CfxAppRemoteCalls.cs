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

	internal class CfxAppCtorRenderProcessCall : RenderProcessCall {

        internal CfxAppCtorRenderProcessCall()
            : base(RemoteCallId.CfxAppCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxApp());
        }
    }

    internal class CfxOnBeforeCommandLineProcessingBrowserProcessCall : BrowserProcessCall {

        internal CfxOnBeforeCommandLineProcessingBrowserProcessCall()
            : base(RemoteCallId.CfxOnBeforeCommandLineProcessingBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnBeforeCommandLineProcessingEventArgs e) {
            var call = new CfxOnBeforeCommandLineProcessingBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrApp.Wrap(this.sender);
            var e = new CfrOnBeforeCommandLineProcessingEventArgs(eventArgsId);
            sender.raise_OnBeforeCommandLineProcessing(sender, e);
        }
    }

    internal class CfxOnBeforeCommandLineProcessingActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeCommandLineProcessingActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeCommandLineProcessingActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.OnBeforeCommandLineProcessing += CfxOnBeforeCommandLineProcessingBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBeforeCommandLineProcessingDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeCommandLineProcessingDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeCommandLineProcessingDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.OnBeforeCommandLineProcessing -= CfxOnBeforeCommandLineProcessingBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBeforeCommandLineProcessingGetProcessTypeRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeCommandLineProcessingGetProcessTypeRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeCommandLineProcessingGetProcessTypeRenderProcessCall) {}

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
            var e = (CfxOnBeforeCommandLineProcessingEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.ProcessType;
        }
    }

    internal class CfxOnBeforeCommandLineProcessingGetCommandLineRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeCommandLineProcessingGetCommandLineRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeCommandLineProcessingGetCommandLineRenderProcessCall) {}

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
            var e = (CfxOnBeforeCommandLineProcessingEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.CommandLine);
        }
    }

    internal class CfxOnRegisterCustomSchemesBrowserProcessCall : BrowserProcessCall {

        internal CfxOnRegisterCustomSchemesBrowserProcessCall()
            : base(RemoteCallId.CfxOnRegisterCustomSchemesBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnRegisterCustomSchemesEventArgs e) {
            var call = new CfxOnRegisterCustomSchemesBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrApp.Wrap(this.sender);
            var e = new CfrOnRegisterCustomSchemesEventArgs(eventArgsId);
            sender.raise_OnRegisterCustomSchemes(sender, e);
        }
    }

    internal class CfxOnRegisterCustomSchemesActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnRegisterCustomSchemesActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnRegisterCustomSchemesActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.OnRegisterCustomSchemes += CfxOnRegisterCustomSchemesBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnRegisterCustomSchemesDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnRegisterCustomSchemesDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnRegisterCustomSchemesDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.OnRegisterCustomSchemes -= CfxOnRegisterCustomSchemesBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnRegisterCustomSchemesGetRegistrarRenderProcessCall : RenderProcessCall {

        internal CfxOnRegisterCustomSchemesGetRegistrarRenderProcessCall()
            : base(RemoteCallId.CfxOnRegisterCustomSchemesGetRegistrarRenderProcessCall) {}

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
            var e = (CfxOnRegisterCustomSchemesEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Registrar);
        }
    }

    internal class CfxGetResourceBundleHandlerBrowserProcessCall : BrowserProcessCall {

        internal CfxGetResourceBundleHandlerBrowserProcessCall()
            : base(RemoteCallId.CfxGetResourceBundleHandlerBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetResourceBundleHandlerEventArgs e) {
            var call = new CfxGetResourceBundleHandlerBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrApp.Wrap(this.sender);
            var e = new CfrGetResourceBundleHandlerEventArgs(eventArgsId);
            sender.raise_GetResourceBundleHandler(sender, e);
        }
    }

    internal class CfxGetResourceBundleHandlerActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetResourceBundleHandlerActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetResourceBundleHandlerActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.GetResourceBundleHandler += CfxGetResourceBundleHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetResourceBundleHandlerDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetResourceBundleHandlerDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetResourceBundleHandlerDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.GetResourceBundleHandler -= CfxGetResourceBundleHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetResourceBundleHandlerSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetResourceBundleHandlerSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetResourceBundleHandlerSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetResourceBundleHandlerEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue((CfxResourceBundleHandler)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxGetRenderProcessHandlerBrowserProcessCall : BrowserProcessCall {

        internal CfxGetRenderProcessHandlerBrowserProcessCall()
            : base(RemoteCallId.CfxGetRenderProcessHandlerBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetRenderProcessHandlerEventArgs e) {
            var call = new CfxGetRenderProcessHandlerBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrApp.Wrap(this.sender);
            var e = new CfrGetRenderProcessHandlerEventArgs(eventArgsId);
            sender.raise_GetRenderProcessHandler(sender, e);
        }
    }

    internal class CfxGetRenderProcessHandlerActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetRenderProcessHandlerActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetRenderProcessHandlerActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.GetRenderProcessHandler += CfxGetRenderProcessHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetRenderProcessHandlerDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetRenderProcessHandlerDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetRenderProcessHandlerDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxApp)RemoteProxy.Unwrap(this.sender);
            sender.GetRenderProcessHandler -= CfxGetRenderProcessHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetRenderProcessHandlerSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetRenderProcessHandlerSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetRenderProcessHandlerSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetRenderProcessHandlerEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue((CfxRenderProcessHandler)RemoteProxy.Unwrap(value));
        }
    }

}
