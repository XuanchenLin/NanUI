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

	internal class CfxBrowserCanGoBackRenderProcessCall : RenderProcessCall {

        internal CfxBrowserCanGoBackRenderProcessCall()
            : base(RemoteCallId.CfxBrowserCanGoBackRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.CanGoBack;
        }
    }

    internal class CfxBrowserGoBackRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGoBackRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGoBackRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            self_local.GoBack();
        }
    }

    internal class CfxBrowserCanGoForwardRenderProcessCall : RenderProcessCall {

        internal CfxBrowserCanGoForwardRenderProcessCall()
            : base(RemoteCallId.CfxBrowserCanGoForwardRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.CanGoForward;
        }
    }

    internal class CfxBrowserGoForwardRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGoForwardRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGoForwardRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            self_local.GoForward();
        }
    }

    internal class CfxBrowserIsLoadingRenderProcessCall : RenderProcessCall {

        internal CfxBrowserIsLoadingRenderProcessCall()
            : base(RemoteCallId.CfxBrowserIsLoadingRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.IsLoading;
        }
    }

    internal class CfxBrowserReloadRenderProcessCall : RenderProcessCall {

        internal CfxBrowserReloadRenderProcessCall()
            : base(RemoteCallId.CfxBrowserReloadRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            self_local.Reload();
        }
    }

    internal class CfxBrowserReloadIgnoreCacheRenderProcessCall : RenderProcessCall {

        internal CfxBrowserReloadIgnoreCacheRenderProcessCall()
            : base(RemoteCallId.CfxBrowserReloadIgnoreCacheRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            self_local.ReloadIgnoreCache();
        }
    }

    internal class CfxBrowserStopLoadRenderProcessCall : RenderProcessCall {

        internal CfxBrowserStopLoadRenderProcessCall()
            : base(RemoteCallId.CfxBrowserStopLoadRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            self_local.StopLoad();
        }
    }

    internal class CfxBrowserGetIdentifierRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetIdentifierRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetIdentifierRenderProcessCall) {}

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.Identifier;
        }
    }

    internal class CfxBrowserIsSameRenderProcessCall : RenderProcessCall {

        internal CfxBrowserIsSameRenderProcessCall()
            : base(RemoteCallId.CfxBrowserIsSameRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr that;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(that);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out that);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxBrowser)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxBrowserIsPopupRenderProcessCall : RenderProcessCall {

        internal CfxBrowserIsPopupRenderProcessCall()
            : base(RemoteCallId.CfxBrowserIsPopupRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.IsPopup;
        }
    }

    internal class CfxBrowserHasDocumentRenderProcessCall : RenderProcessCall {

        internal CfxBrowserHasDocumentRenderProcessCall()
            : base(RemoteCallId.CfxBrowserHasDocumentRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.HasDocument;
        }
    }

    internal class CfxBrowserGetMainFrameRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetMainFrameRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetMainFrameRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.MainFrame);
        }
    }

    internal class CfxBrowserGetFocusedFrameRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFocusedFrameRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFocusedFrameRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.FocusedFrame);
        }
    }

    internal class CfxBrowserGetFrameByIdentifierRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFrameByIdentifierRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFrameByIdentifierRenderProcessCall) {}

        internal IntPtr self;
        internal long identifier;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(identifier);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out identifier);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetFrame(identifier));
        }
    }

    internal class CfxBrowserGetFrameRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFrameRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFrameRenderProcessCall) {}

        internal IntPtr self;
        internal string name;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetFrame(name));
        }
    }

    internal class CfxBrowserGetFrameCountRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFrameCountRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFrameCountRenderProcessCall) {}

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.FrameCount;
        }
    }

    internal class CfxBrowserGetFrameIdentifiersRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFrameIdentifiersRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFrameIdentifiersRenderProcessCall) {}

        internal IntPtr self;
        internal long[] __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.FrameIdentifiers;
        }
    }

    internal class CfxBrowserGetFrameNamesRenderProcessCall : RenderProcessCall {

        internal CfxBrowserGetFrameNamesRenderProcessCall()
            : base(RemoteCallId.CfxBrowserGetFrameNamesRenderProcessCall) {}

        internal IntPtr self;
        internal System.Collections.Generic.List<string> __retval;

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
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.GetFrameNames();
        }
    }

    internal class CfxBrowserSendProcessMessageRenderProcessCall : RenderProcessCall {

        internal CfxBrowserSendProcessMessageRenderProcessCall()
            : base(RemoteCallId.CfxBrowserSendProcessMessageRenderProcessCall) {}

        internal IntPtr self;
        internal int targetProcess;
        internal IntPtr message;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(targetProcess);
            h.Write(message);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out targetProcess);
            h.Read(out message);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBrowser)RemoteProxy.Unwrap(self);
            __retval = self_local.SendProcessMessage((CfxProcessId)targetProcess, (CfxProcessMessage)RemoteProxy.Unwrap(message));
        }
    }

}
