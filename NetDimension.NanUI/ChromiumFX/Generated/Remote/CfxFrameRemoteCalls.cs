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

	internal class CfxFrameIsValidRenderProcessCall : RenderProcessCall {

        internal CfxFrameIsValidRenderProcessCall()
            : base(RemoteCallId.CfxFrameIsValidRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxFrameUndoRenderProcessCall : RenderProcessCall {

        internal CfxFrameUndoRenderProcessCall()
            : base(RemoteCallId.CfxFrameUndoRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Undo();
        }
    }

    internal class CfxFrameRedoRenderProcessCall : RenderProcessCall {

        internal CfxFrameRedoRenderProcessCall()
            : base(RemoteCallId.CfxFrameRedoRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Redo();
        }
    }

    internal class CfxFrameCutRenderProcessCall : RenderProcessCall {

        internal CfxFrameCutRenderProcessCall()
            : base(RemoteCallId.CfxFrameCutRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Cut();
        }
    }

    internal class CfxFrameCopyRenderProcessCall : RenderProcessCall {

        internal CfxFrameCopyRenderProcessCall()
            : base(RemoteCallId.CfxFrameCopyRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Copy();
        }
    }

    internal class CfxFramePasteRenderProcessCall : RenderProcessCall {

        internal CfxFramePasteRenderProcessCall()
            : base(RemoteCallId.CfxFramePasteRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Paste();
        }
    }

    internal class CfxFrameDelRenderProcessCall : RenderProcessCall {

        internal CfxFrameDelRenderProcessCall()
            : base(RemoteCallId.CfxFrameDelRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.Delete();
        }
    }

    internal class CfxFrameSelectAllRenderProcessCall : RenderProcessCall {

        internal CfxFrameSelectAllRenderProcessCall()
            : base(RemoteCallId.CfxFrameSelectAllRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.SelectAll();
        }
    }

    internal class CfxFrameGetSourceRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetSourceRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetSourceRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out visitor);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.GetSource((CfxStringVisitor)RemoteProxy.Unwrap(visitor));
        }
    }

    internal class CfxFrameGetTextRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetTextRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetTextRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out visitor);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.GetText((CfxStringVisitor)RemoteProxy.Unwrap(visitor));
        }
    }

    internal class CfxFrameLoadRequestRenderProcessCall : RenderProcessCall {

        internal CfxFrameLoadRequestRenderProcessCall()
            : base(RemoteCallId.CfxFrameLoadRequestRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr request;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(request);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out request);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.LoadRequest((CfxRequest)RemoteProxy.Unwrap(request));
        }
    }

    internal class CfxFrameLoadUrlRenderProcessCall : RenderProcessCall {

        internal CfxFrameLoadUrlRenderProcessCall()
            : base(RemoteCallId.CfxFrameLoadUrlRenderProcessCall) {}

        internal IntPtr self;
        internal string url;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(url);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out url);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.LoadUrl(url);
        }
    }

    internal class CfxFrameLoadStringRenderProcessCall : RenderProcessCall {

        internal CfxFrameLoadStringRenderProcessCall()
            : base(RemoteCallId.CfxFrameLoadStringRenderProcessCall) {}

        internal IntPtr self;
        internal string stringVal;
        internal string url;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(stringVal);
            h.Write(url);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out stringVal);
            h.Read(out url);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.LoadString(stringVal, url);
        }
    }

    internal class CfxFrameExecuteJavaScriptRenderProcessCall : RenderProcessCall {

        internal CfxFrameExecuteJavaScriptRenderProcessCall()
            : base(RemoteCallId.CfxFrameExecuteJavaScriptRenderProcessCall) {}

        internal IntPtr self;
        internal string code;
        internal string scriptUrl;
        internal int startLine;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(code);
            h.Write(scriptUrl);
            h.Write(startLine);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out code);
            h.Read(out scriptUrl);
            h.Read(out startLine);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.ExecuteJavaScript(code, scriptUrl, startLine);
        }
    }

    internal class CfxFrameIsMainRenderProcessCall : RenderProcessCall {

        internal CfxFrameIsMainRenderProcessCall()
            : base(RemoteCallId.CfxFrameIsMainRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.IsMain;
        }
    }

    internal class CfxFrameIsFocusedRenderProcessCall : RenderProcessCall {

        internal CfxFrameIsFocusedRenderProcessCall()
            : base(RemoteCallId.CfxFrameIsFocusedRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.IsFocused;
        }
    }

    internal class CfxFrameGetNameRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetNameRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetNameRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.Name;
        }
    }

    internal class CfxFrameGetIdentifierRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetIdentifierRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetIdentifierRenderProcessCall) {}

        internal IntPtr self;
        internal long __retval;

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.Identifier;
        }
    }

    internal class CfxFrameGetParentRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetParentRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetParentRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Parent);
        }
    }

    internal class CfxFrameGetUrlRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetUrlRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetUrlRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = self_local.Url;
        }
    }

    internal class CfxFrameGetBrowserRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetBrowserRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetBrowserRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Browser);
        }
    }

    internal class CfxFrameGetV8ContextRenderProcessCall : RenderProcessCall {

        internal CfxFrameGetV8ContextRenderProcessCall()
            : base(RemoteCallId.CfxFrameGetV8ContextRenderProcessCall) {}

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
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.V8Context);
        }
    }

    internal class CfxFrameVisitDomRenderProcessCall : RenderProcessCall {

        internal CfxFrameVisitDomRenderProcessCall()
            : base(RemoteCallId.CfxFrameVisitDomRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out visitor);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxFrame)RemoteProxy.Unwrap(self);
            self_local.VisitDom((CfxDomVisitor)RemoteProxy.Unwrap(visitor));
        }
    }

}
