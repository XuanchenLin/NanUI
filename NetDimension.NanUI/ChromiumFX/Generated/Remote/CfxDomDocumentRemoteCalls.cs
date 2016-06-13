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

	internal class CfxDomDocumentGetTypeRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetTypeRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetTypeRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = (int)self_local.Type;
        }
    }

    internal class CfxDomDocumentGetDocumentRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetDocumentRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetDocumentRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Document);
        }
    }

    internal class CfxDomDocumentGetBodyRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetBodyRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetBodyRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Body);
        }
    }

    internal class CfxDomDocumentGetHeadRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetHeadRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetHeadRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Head);
        }
    }

    internal class CfxDomDocumentGetTitleRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetTitleRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetTitleRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.Title;
        }
    }

    internal class CfxDomDocumentGetElementByIdRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetElementByIdRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetElementByIdRenderProcessCall) {}

        internal IntPtr self;
        internal string id;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetElementById(id));
        }
    }

    internal class CfxDomDocumentGetFocusedNodeRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetFocusedNodeRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetFocusedNodeRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.FocusedNode);
        }
    }

    internal class CfxDomDocumentHasSelectionRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentHasSelectionRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentHasSelectionRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.HasSelection;
        }
    }

    internal class CfxDomDocumentGetSelectionStartOffsetRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetSelectionStartOffsetRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetSelectionStartOffsetRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.SelectionStartOffset;
        }
    }

    internal class CfxDomDocumentGetSelectionEndOffsetRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetSelectionEndOffsetRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetSelectionEndOffsetRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.SelectionEndOffset;
        }
    }

    internal class CfxDomDocumentGetSelectionAsMarkupRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetSelectionAsMarkupRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetSelectionAsMarkupRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.SelectionAsMarkup;
        }
    }

    internal class CfxDomDocumentGetSelectionAsTextRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetSelectionAsTextRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetSelectionAsTextRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.SelectionAsText;
        }
    }

    internal class CfxDomDocumentGetBaseUrlRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetBaseUrlRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetBaseUrlRenderProcessCall) {}

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
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.BaseUrl;
        }
    }

    internal class CfxDomDocumentGetCompleteUrlRenderProcessCall : RenderProcessCall {

        internal CfxDomDocumentGetCompleteUrlRenderProcessCall()
            : base(RemoteCallId.CfxDomDocumentGetCompleteUrlRenderProcessCall) {}

        internal IntPtr self;
        internal string partialURL;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(partialURL);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out partialURL);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxDomDocument)RemoteProxy.Unwrap(self);
            __retval = self_local.GetCompleteUrl(partialURL);
        }
    }

}
