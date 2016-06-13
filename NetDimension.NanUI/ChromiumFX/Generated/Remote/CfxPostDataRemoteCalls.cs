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

	internal class CfxPostDataCreateRenderProcessCall : RenderProcessCall {

        internal CfxPostDataCreateRenderProcessCall()
            : base(RemoteCallId.CfxPostDataCreateRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxPostData.Create());
        }
    }

    internal class CfxPostDataIsReadOnlyRenderProcessCall : RenderProcessCall {

        internal CfxPostDataIsReadOnlyRenderProcessCall()
            : base(RemoteCallId.CfxPostDataIsReadOnlyRenderProcessCall) {}

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
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            __retval = self_local.IsReadOnly;
        }
    }

    internal class CfxPostDataHasExcludedElementsRenderProcessCall : RenderProcessCall {

        internal CfxPostDataHasExcludedElementsRenderProcessCall()
            : base(RemoteCallId.CfxPostDataHasExcludedElementsRenderProcessCall) {}

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
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            __retval = self_local.HasExcludedElements;
        }
    }

    internal class CfxPostDataGetElementCountRenderProcessCall : RenderProcessCall {

        internal CfxPostDataGetElementCountRenderProcessCall()
            : base(RemoteCallId.CfxPostDataGetElementCountRenderProcessCall) {}

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
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            __retval = self_local.ElementCount;
        }
    }

    internal class CfxPostDataGetElementsRenderProcessCall : RenderProcessCall {

        internal CfxPostDataGetElementsRenderProcessCall()
            : base(RemoteCallId.CfxPostDataGetElementsRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr[] __retval;

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
            var elements = ((CfxPostData)RemoteProxy.Unwrap(self)).Elements;
            if(elements != null) {
                __retval = new IntPtr[elements.Length];
                for(int i = 0; i < elements.Length; ++i) {
                    __retval[i] = RemoteProxy.Wrap(elements[i]);
                }
            }
        }
    }

    internal class CfxPostDataRemoveElementRenderProcessCall : RenderProcessCall {

        internal CfxPostDataRemoveElementRenderProcessCall()
            : base(RemoteCallId.CfxPostDataRemoveElementRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr element;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(element);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out element);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            __retval = self_local.RemoveElement((CfxPostDataElement)RemoteProxy.Unwrap(element));
        }
    }

    internal class CfxPostDataAddElementRenderProcessCall : RenderProcessCall {

        internal CfxPostDataAddElementRenderProcessCall()
            : base(RemoteCallId.CfxPostDataAddElementRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr element;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(element);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out element);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            __retval = self_local.AddElement((CfxPostDataElement)RemoteProxy.Unwrap(element));
        }
    }

    internal class CfxPostDataRemoveElementsRenderProcessCall : RenderProcessCall {

        internal CfxPostDataRemoveElementsRenderProcessCall()
            : base(RemoteCallId.CfxPostDataRemoveElementsRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxPostData)RemoteProxy.Unwrap(self);
            self_local.RemoveElements();
        }
    }

}
