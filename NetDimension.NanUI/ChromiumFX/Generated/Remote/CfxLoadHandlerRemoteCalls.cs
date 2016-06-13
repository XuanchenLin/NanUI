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

	internal class CfxLoadHandlerCtorRenderProcessCall : RenderProcessCall {

        internal CfxLoadHandlerCtorRenderProcessCall()
            : base(RemoteCallId.CfxLoadHandlerCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxLoadHandler());
        }
    }

    internal class CfxOnLoadingStateChangeBrowserProcessCall : BrowserProcessCall {

        internal CfxOnLoadingStateChangeBrowserProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnLoadingStateChangeEventArgs e) {
            var call = new CfxOnLoadingStateChangeBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrLoadHandler.Wrap(this.sender);
            var e = new CfrOnLoadingStateChangeEventArgs(eventArgsId);
            sender.raise_OnLoadingStateChange(sender, e);
        }
    }

    internal class CfxOnLoadingStateChangeActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadingStateChange += CfxOnLoadingStateChangeBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadingStateChangeDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadingStateChange -= CfxOnLoadingStateChangeBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadingStateChangeGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnLoadingStateChangeEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnLoadingStateChangeGetIsLoadingRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeGetIsLoadingRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeGetIsLoadingRenderProcessCall) {}

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
            var e = (CfxOnLoadingStateChangeEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.IsLoading;
        }
    }

    internal class CfxOnLoadingStateChangeGetCanGoBackRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeGetCanGoBackRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeGetCanGoBackRenderProcessCall) {}

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
            var e = (CfxOnLoadingStateChangeEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.CanGoBack;
        }
    }

    internal class CfxOnLoadingStateChangeGetCanGoForwardRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadingStateChangeGetCanGoForwardRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadingStateChangeGetCanGoForwardRenderProcessCall) {}

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
            var e = (CfxOnLoadingStateChangeEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.CanGoForward;
        }
    }

    internal class CfxOnLoadStartBrowserProcessCall : BrowserProcessCall {

        internal CfxOnLoadStartBrowserProcessCall()
            : base(RemoteCallId.CfxOnLoadStartBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnLoadStartEventArgs e) {
            var call = new CfxOnLoadStartBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrLoadHandler.Wrap(this.sender);
            var e = new CfrOnLoadStartEventArgs(eventArgsId);
            sender.raise_OnLoadStart(sender, e);
        }
    }

    internal class CfxOnLoadStartActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadStartActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadStartActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadStart += CfxOnLoadStartBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadStartDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadStartDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadStartDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadStart -= CfxOnLoadStartBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadStartGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadStartGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadStartGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnLoadStartEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnLoadStartGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadStartGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadStartGetFrameRenderProcessCall) {}

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
            var e = (CfxOnLoadStartEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnLoadEndBrowserProcessCall : BrowserProcessCall {

        internal CfxOnLoadEndBrowserProcessCall()
            : base(RemoteCallId.CfxOnLoadEndBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnLoadEndEventArgs e) {
            var call = new CfxOnLoadEndBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrLoadHandler.Wrap(this.sender);
            var e = new CfrOnLoadEndEventArgs(eventArgsId);
            sender.raise_OnLoadEnd(sender, e);
        }
    }

    internal class CfxOnLoadEndActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadEndActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadEndActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadEnd += CfxOnLoadEndBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadEndDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadEndDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadEndDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadEnd -= CfxOnLoadEndBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadEndGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadEndGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadEndGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnLoadEndEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnLoadEndGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadEndGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadEndGetFrameRenderProcessCall) {}

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
            var e = (CfxOnLoadEndEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnLoadEndGetHttpStatusCodeRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadEndGetHttpStatusCodeRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadEndGetHttpStatusCodeRenderProcessCall) {}

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
            var e = (CfxOnLoadEndEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.HttpStatusCode;
        }
    }

    internal class CfxOnLoadErrorBrowserProcessCall : BrowserProcessCall {

        internal CfxOnLoadErrorBrowserProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorBrowserProcessCall) {}

        internal static void EventCall(object sender, CfxOnLoadErrorEventArgs e) {
            var call = new CfxOnLoadErrorBrowserProcessCall();
            call.sender = RemoteProxy.Wrap((CfxBase)sender);
            call.eventArgsId = AddEventArgs(e);
            call.RequestExecution(RemoteClient.connection);
            RemoveEventArgs(call.eventArgsId);
        }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = CfrLoadHandler.Wrap(this.sender);
            var e = new CfrOnLoadErrorEventArgs(eventArgsId);
            sender.raise_OnLoadError(sender, e);
        }
    }

    internal class CfxOnLoadErrorActivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorActivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorActivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadError += CfxOnLoadErrorBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadErrorDeactivateRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorDeactivateRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorDeactivateRenderProcessCall) {}

        internal IntPtr sender;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxLoadHandler)RemoteProxy.Unwrap(this.sender);
            sender.OnLoadError -= CfxOnLoadErrorBrowserProcessCall.EventCall;
        }
    }

    internal class CfxOnLoadErrorGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorGetBrowserRenderProcessCall) {}

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
            var e = (CfxOnLoadErrorEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Browser);
        }
    }

    internal class CfxOnLoadErrorGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorGetFrameRenderProcessCall) {}

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
            var e = (CfxOnLoadErrorEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = RemoteProxy.Wrap(e.Frame);
        }
    }

    internal class CfxOnLoadErrorGetErrorCodeRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorGetErrorCodeRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorGetErrorCodeRenderProcessCall) {}

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
            var e = (CfxOnLoadErrorEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = (int)e.ErrorCode;
        }
    }

    internal class CfxOnLoadErrorGetErrorTextRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorGetErrorTextRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorGetErrorTextRenderProcessCall) {}

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
            var e = (CfxOnLoadErrorEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.ErrorText;
        }
    }

    internal class CfxOnLoadErrorGetFailedUrlRenderProcessCall : RenderProcessCall {

        internal CfxOnLoadErrorGetFailedUrlRenderProcessCall()
            : base(RemoteCallId.CfxOnLoadErrorGetFailedUrlRenderProcessCall) {}

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
            var e = (CfxOnLoadErrorEventArgs)BrowserProcessCall.GetEventArgs(eventArgsId);
            value = e.FailedUrl;
        }
    }

}
