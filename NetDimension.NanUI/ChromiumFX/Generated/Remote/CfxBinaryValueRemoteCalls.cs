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

	internal class CfxBinaryValueCreateRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueCreateRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueCreateRenderProcessCall) {}

        internal IntPtr data;
        internal int dataSize;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(data);
            h.Write(dataSize);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out data);
            h.Read(out dataSize);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxBinaryValue.Create(data, dataSize));
        }
    }

    internal class CfxBinaryValueIsValidRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueIsValidRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueIsValidRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxBinaryValueIsOwnedRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueIsOwnedRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueIsOwnedRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsOwned;
        }
    }

    internal class CfxBinaryValueIsSameRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueIsSameRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueIsSameRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxBinaryValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxBinaryValueIsEqualRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueIsEqualRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueIsEqualRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsEqual((CfxBinaryValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxBinaryValueCopyRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueCopyRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueCopyRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Copy());
        }
    }

    internal class CfxBinaryValueGetSizeRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueGetSizeRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueGetSizeRenderProcessCall) {}

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
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Size;
        }
    }

    internal class CfxBinaryValueGetDataRenderProcessCall : RenderProcessCall {

        internal CfxBinaryValueGetDataRenderProcessCall()
            : base(RemoteCallId.CfxBinaryValueGetDataRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr buffer;
        internal int bufferSize;
        internal int dataOffset;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(buffer);
            h.Write(bufferSize);
            h.Write(dataOffset);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out buffer);
            h.Read(out bufferSize);
            h.Read(out dataOffset);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxBinaryValue)RemoteProxy.Unwrap(self);
            __retval = self_local.GetData(buffer, bufferSize, dataOffset);
        }
    }

}
