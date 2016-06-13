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

	internal class CfxRenderProcessHandlerCtorRenderProcessCall : RenderProcessCall {

        internal CfxRenderProcessHandlerCtorRenderProcessCall()
            : base(RemoteCallId.CfxRenderProcessHandlerCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxRenderProcessHandler());
        }
    }

    internal class CfxOnRenderThreadCreatedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnRenderThreadCreatedBrowserProcessCall()
            : base(RemoteCallId.CfxOnRenderThreadCreatedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnRenderThreadCreatedEventArgs e) {
            var call = new CfxOnRenderThreadCreatedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnRenderThreadCreatedEventArgs(eventArgsId);
            sender.raise_OnRenderThreadCreated(sender, e);
        }
    }

    internal class CfxOnRenderThreadCreatedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnRenderThreadCreatedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnRenderThreadCreatedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnRenderThreadCreated += CfxOnRenderThreadCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnRenderThreadCreatedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnRenderThreadCreatedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnRenderThreadCreatedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnRenderThreadCreated -= CfxOnRenderThreadCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnRenderThreadCreatedGetExtraInfoRenderProcessCall : RenderProcessCall {

        internal CfxOnRenderThreadCreatedGetExtraInfoRenderProcessCall()
            : base(RemoteCallId.CfxOnRenderThreadCreatedGetExtraInfoRenderProcessCall) {}

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
            var e = (CfxOnRenderThreadCreatedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.ExtraInfo);
        }
    }

    internal class CfxOnWebKitInitializedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnWebKitInitializedBrowserProcessCall()
            : base(RemoteCallId.CfxOnWebKitInitializedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxEventArgs e) {
            var call = new CfxOnWebKitInitializedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrEventArgs(eventArgsId);
            sender.raise_OnWebKitInitialized(sender, e);
        }
    }

    internal class CfxOnWebKitInitializedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnWebKitInitializedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnWebKitInitializedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnWebKitInitialized += CfxOnWebKitInitializedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnWebKitInitializedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnWebKitInitializedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnWebKitInitializedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnWebKitInitialized -= CfxOnWebKitInitializedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBrowserCreatedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnBrowserCreatedBrowserProcessCall()
            : base(RemoteCallId.CfxOnBrowserCreatedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnBrowserCreatedEventArgs e) {
            var call = new CfxOnBrowserCreatedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnBrowserCreatedEventArgs(eventArgsId);
            sender.raise_OnBrowserCreated(sender, e);
        }
    }

    internal class CfxOnBrowserCreatedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserCreatedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserCreatedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBrowserCreated += CfxOnBrowserCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBrowserCreatedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserCreatedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserCreatedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBrowserCreated -= CfxOnBrowserCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBrowserCreatedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserCreatedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserCreatedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnBrowserCreatedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnBrowserDestroyedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnBrowserDestroyedBrowserProcessCall()
            : base(RemoteCallId.CfxOnBrowserDestroyedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnBrowserDestroyedEventArgs e) {
            var call = new CfxOnBrowserDestroyedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnBrowserDestroyedEventArgs(eventArgsId);
            sender.raise_OnBrowserDestroyed(sender, e);
        }
    }

    internal class CfxOnBrowserDestroyedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserDestroyedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserDestroyedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBrowserDestroyed += CfxOnBrowserDestroyedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBrowserDestroyedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserDestroyedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserDestroyedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBrowserDestroyed -= CfxOnBrowserDestroyedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBrowserDestroyedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnBrowserDestroyedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnBrowserDestroyedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnBrowserDestroyedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxGetLoadHandlerBrowserProcessCall : BrowserProcessCall {

        internal CfxGetLoadHandlerBrowserProcessCall()
            : base(RemoteCallId.CfxGetLoadHandlerBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxGetLoadHandlerEventArgs e) {
            var call = new CfxGetLoadHandlerBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrGetLoadHandlerEventArgs(eventArgsId);
            sender.raise_GetLoadHandler(sender, e);
        }
    }

    internal class CfxGetLoadHandlerActivateRenderProcessCall : RenderProcessCall {

        internal CfxGetLoadHandlerActivateRenderProcessCall()
            : base(RemoteCallId.CfxGetLoadHandlerActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetLoadHandler += CfxGetLoadHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetLoadHandlerDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxGetLoadHandlerDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxGetLoadHandlerDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.GetLoadHandler -= CfxGetLoadHandlerBrowserProcessCall.EventCall;
        }
    }

    internal class CfxGetLoadHandlerSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxGetLoadHandlerSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxGetLoadHandlerSetReturnValueRenderProcessCall) {}

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
            var e = (CfxGetLoadHandlerEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue((CfxLoadHandler)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxOnBeforeNavigationBrowserProcessCall : BrowserProcessCall {

        internal CfxOnBeforeNavigationBrowserProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnBeforeNavigationEventArgs e) {
            var call = new CfxOnBeforeNavigationBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnBeforeNavigationEventArgs(eventArgsId);
            sender.raise_OnBeforeNavigation(sender, e);
        }
    }

    internal class CfxOnBeforeNavigationActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBeforeNavigation += CfxOnBeforeNavigationBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBeforeNavigationDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnBeforeNavigation -= CfxOnBeforeNavigationBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnBeforeNavigationGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnBeforeNavigationGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationGetFrameRenderProcessCall) {}

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnBeforeNavigationGetRequestRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationGetRequestRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationGetRequestRenderProcessCall) {}

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Request);
        }
    }

    internal class CfxOnBeforeNavigationGetNavigationTypeRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationGetNavigationTypeRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationGetNavigationTypeRenderProcessCall) {}

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = (int)e.NavigationType;
        }
    }

    internal class CfxOnBeforeNavigationGetIsRedirectRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationGetIsRedirectRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationGetIsRedirectRenderProcessCall) {}

        internal ulong eventArgsId;
        internal bool value;

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.IsRedirect;
        }
    }

    internal class CfxOnBeforeNavigationSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxOnBeforeNavigationSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxOnBeforeNavigationSetReturnValueRenderProcessCall) {}

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
            var e = (CfxOnBeforeNavigationEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

    internal class CfxOnContextCreatedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnContextCreatedBrowserProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnContextCreatedEventArgs e) {
            var call = new CfxOnContextCreatedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnContextCreatedEventArgs(eventArgsId);
            sender.raise_OnContextCreated(sender, e);
        }
    }

    internal class CfxOnContextCreatedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnContextCreatedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnContextCreated += CfxOnContextCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnContextCreatedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnContextCreatedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnContextCreated -= CfxOnContextCreatedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnContextCreatedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnContextCreatedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnContextCreatedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnContextCreatedGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnContextCreatedGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedGetFrameRenderProcessCall) {}

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
            var e = (CfxOnContextCreatedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnContextCreatedGetContextRenderProcessCall : RenderProcessCall {

        internal CfxOnContextCreatedGetContextRenderProcessCall()
            : base(RemoteCallId.CfxOnContextCreatedGetContextRenderProcessCall) {}

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
            var e = (CfxOnContextCreatedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Context);
        }
    }

    internal class CfxOnContextReleasedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnContextReleasedBrowserProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnContextReleasedEventArgs e) {
            var call = new CfxOnContextReleasedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnContextReleasedEventArgs(eventArgsId);
            sender.raise_OnContextReleased(sender, e);
        }
    }

    internal class CfxOnContextReleasedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnContextReleasedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnContextReleased += CfxOnContextReleasedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnContextReleasedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnContextReleasedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnContextReleased -= CfxOnContextReleasedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnContextReleasedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnContextReleasedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnContextReleasedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnContextReleasedGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnContextReleasedGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedGetFrameRenderProcessCall) {}

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
            var e = (CfxOnContextReleasedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnContextReleasedGetContextRenderProcessCall : RenderProcessCall {

        internal CfxOnContextReleasedGetContextRenderProcessCall()
            : base(RemoteCallId.CfxOnContextReleasedGetContextRenderProcessCall) {}

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
            var e = (CfxOnContextReleasedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Context);
        }
    }

    internal class CfxOnUncaughtExceptionBrowserProcessCall : BrowserProcessCall {

        internal CfxOnUncaughtExceptionBrowserProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnUncaughtExceptionEventArgs e) {
            var call = new CfxOnUncaughtExceptionBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnUncaughtExceptionEventArgs(eventArgsId);
            sender.raise_OnUncaughtException(sender, e);
        }
    }

    internal class CfxOnUncaughtExceptionActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnUncaughtException += CfxOnUncaughtExceptionBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnUncaughtExceptionDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnUncaughtException -= CfxOnUncaughtExceptionBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnUncaughtExceptionGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnUncaughtExceptionEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnUncaughtExceptionGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionGetFrameRenderProcessCall) {}

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
            var e = (CfxOnUncaughtExceptionEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnUncaughtExceptionGetContextRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionGetContextRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionGetContextRenderProcessCall) {}

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
            var e = (CfxOnUncaughtExceptionEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Context);
        }
    }

    internal class CfxOnUncaughtExceptionGetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionGetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionGetExceptionRenderProcessCall) {}

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
            var e = (CfxOnUncaughtExceptionEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Exception);
        }
    }

    internal class CfxOnUncaughtExceptionGetStackTraceRenderProcessCall : RenderProcessCall {

        internal CfxOnUncaughtExceptionGetStackTraceRenderProcessCall()
            : base(RemoteCallId.CfxOnUncaughtExceptionGetStackTraceRenderProcessCall) {}

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
            var e = (CfxOnUncaughtExceptionEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.StackTrace);
        }
    }

    internal class CfxOnFocusedNodeChangedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnFocusedNodeChangedBrowserProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnFocusedNodeChangedEventArgs e) {
            var call = new CfxOnFocusedNodeChangedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnFocusedNodeChangedEventArgs(eventArgsId);
            sender.raise_OnFocusedNodeChanged(sender, e);
        }
    }

    internal class CfxOnFocusedNodeChangedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnFocusedNodeChangedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnFocusedNodeChanged += CfxOnFocusedNodeChangedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnFocusedNodeChangedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnFocusedNodeChangedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnFocusedNodeChanged -= CfxOnFocusedNodeChangedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnFocusedNodeChangedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnFocusedNodeChangedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnFocusedNodeChangedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnFocusedNodeChangedGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnFocusedNodeChangedGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedGetFrameRenderProcessCall) {}

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
            var e = (CfxOnFocusedNodeChangedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnFocusedNodeChangedGetNodeRenderProcessCall : RenderProcessCall {

        internal CfxOnFocusedNodeChangedGetNodeRenderProcessCall()
            : base(RemoteCallId.CfxOnFocusedNodeChangedGetNodeRenderProcessCall) {}

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
            var e = (CfxOnFocusedNodeChangedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Node);
        }
    }

    internal class CfxOnProcessMessageReceivedBrowserProcessCall : BrowserProcessCall {

        internal CfxOnProcessMessageReceivedBrowserProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnProcessMessageReceivedEventArgs e) {
            var call = new CfxOnProcessMessageReceivedBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrRenderProcessHandler.Wrap(this.sender);
            var e = new CfrOnProcessMessageReceivedEventArgs(eventArgsId);
            sender.raise_OnProcessMessageReceived(sender, e);
        }
    }

    internal class CfxOnProcessMessageReceivedActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnProcessMessageReceived += CfxOnProcessMessageReceivedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnProcessMessageReceivedDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxRenderProcessHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnProcessMessageReceived -= CfxOnProcessMessageReceivedBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnProcessMessageReceivedGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnProcessMessageReceivedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnProcessMessageReceivedGetSourceProcessRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedGetSourceProcessRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedGetSourceProcessRenderProcessCall) {}

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
            var e = (CfxOnProcessMessageReceivedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = (int)e.SourceProcess;
        }
    }

    internal class CfxOnProcessMessageReceivedGetMessageRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedGetMessageRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedGetMessageRenderProcessCall) {}

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
            var e = (CfxOnProcessMessageReceivedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Message);
        }
    }

    internal class CfxOnProcessMessageReceivedSetReturnValueRenderProcessCall : RenderProcessCall {

        internal CfxOnProcessMessageReceivedSetReturnValueRenderProcessCall()
            : base(RemoteCallId.CfxOnProcessMessageReceivedSetReturnValueRenderProcessCall) {}

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
            var e = (CfxOnProcessMessageReceivedEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            e.SetReturnValue(value);
        }
    }

}
