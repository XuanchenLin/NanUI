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

	internal class CfxValueCreateRenderProcessCall : RenderProcessCall {

        internal CfxValueCreateRenderProcessCall()
            : base(RemoteCallId.CfxValueCreateRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxValue.Create());
        }
    }

    internal class CfxValueIsValidRenderProcessCall : RenderProcessCall {

        internal CfxValueIsValidRenderProcessCall()
            : base(RemoteCallId.CfxValueIsValidRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxValueIsOwnedRenderProcessCall : RenderProcessCall {

        internal CfxValueIsOwnedRenderProcessCall()
            : base(RemoteCallId.CfxValueIsOwnedRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsOwned;
        }
    }

    internal class CfxValueIsReadOnlyRenderProcessCall : RenderProcessCall {

        internal CfxValueIsReadOnlyRenderProcessCall()
            : base(RemoteCallId.CfxValueIsReadOnlyRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsReadOnly;
        }
    }

    internal class CfxValueIsSameRenderProcessCall : RenderProcessCall {

        internal CfxValueIsSameRenderProcessCall()
            : base(RemoteCallId.CfxValueIsSameRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxValueIsEqualRenderProcessCall : RenderProcessCall {

        internal CfxValueIsEqualRenderProcessCall()
            : base(RemoteCallId.CfxValueIsEqualRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsEqual((CfxValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxValueCopyRenderProcessCall : RenderProcessCall {

        internal CfxValueCopyRenderProcessCall()
            : base(RemoteCallId.CfxValueCopyRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Copy());
        }
    }

    internal class CfxValueGetTypeRenderProcessCall : RenderProcessCall {

        internal CfxValueGetTypeRenderProcessCall()
            : base(RemoteCallId.CfxValueGetTypeRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = (int)self_local.Type;
        }
    }

    internal class CfxValueGetBoolRenderProcessCall : RenderProcessCall {

        internal CfxValueGetBoolRenderProcessCall()
            : base(RemoteCallId.CfxValueGetBoolRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Bool;
        }
    }

    internal class CfxValueGetIntRenderProcessCall : RenderProcessCall {

        internal CfxValueGetIntRenderProcessCall()
            : base(RemoteCallId.CfxValueGetIntRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Int;
        }
    }

    internal class CfxValueGetDoubleRenderProcessCall : RenderProcessCall {

        internal CfxValueGetDoubleRenderProcessCall()
            : base(RemoteCallId.CfxValueGetDoubleRenderProcessCall) {}

        internal IntPtr self;
        internal double __retval;

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Double;
        }
    }

    internal class CfxValueGetStringRenderProcessCall : RenderProcessCall {

        internal CfxValueGetStringRenderProcessCall()
            : base(RemoteCallId.CfxValueGetStringRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.String;
        }
    }

    internal class CfxValueGetBinaryRenderProcessCall : RenderProcessCall {

        internal CfxValueGetBinaryRenderProcessCall()
            : base(RemoteCallId.CfxValueGetBinaryRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Binary);
        }
    }

    internal class CfxValueGetDictionaryRenderProcessCall : RenderProcessCall {

        internal CfxValueGetDictionaryRenderProcessCall()
            : base(RemoteCallId.CfxValueGetDictionaryRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Dictionary);
        }
    }

    internal class CfxValueGetListRenderProcessCall : RenderProcessCall {

        internal CfxValueGetListRenderProcessCall()
            : base(RemoteCallId.CfxValueGetListRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.List);
        }
    }

    internal class CfxValueSetNullRenderProcessCall : RenderProcessCall {

        internal CfxValueSetNullRenderProcessCall()
            : base(RemoteCallId.CfxValueSetNullRenderProcessCall) {}

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
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetNull();
        }
    }

    internal class CfxValueSetBoolRenderProcessCall : RenderProcessCall {

        internal CfxValueSetBoolRenderProcessCall()
            : base(RemoteCallId.CfxValueSetBoolRenderProcessCall) {}

        internal IntPtr self;
        internal bool value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetBool(value);
        }
    }

    internal class CfxValueSetIntRenderProcessCall : RenderProcessCall {

        internal CfxValueSetIntRenderProcessCall()
            : base(RemoteCallId.CfxValueSetIntRenderProcessCall) {}

        internal IntPtr self;
        internal int value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetInt(value);
        }
    }

    internal class CfxValueSetDoubleRenderProcessCall : RenderProcessCall {

        internal CfxValueSetDoubleRenderProcessCall()
            : base(RemoteCallId.CfxValueSetDoubleRenderProcessCall) {}

        internal IntPtr self;
        internal double value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetDouble(value);
        }
    }

    internal class CfxValueSetStringRenderProcessCall : RenderProcessCall {

        internal CfxValueSetStringRenderProcessCall()
            : base(RemoteCallId.CfxValueSetStringRenderProcessCall) {}

        internal IntPtr self;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetString(value);
        }
    }

    internal class CfxValueSetBinaryRenderProcessCall : RenderProcessCall {

        internal CfxValueSetBinaryRenderProcessCall()
            : base(RemoteCallId.CfxValueSetBinaryRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetBinary((CfxBinaryValue)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxValueSetDictionaryRenderProcessCall : RenderProcessCall {

        internal CfxValueSetDictionaryRenderProcessCall()
            : base(RemoteCallId.CfxValueSetDictionaryRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetDictionary((CfxDictionaryValue)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxValueSetListRenderProcessCall : RenderProcessCall {

        internal CfxValueSetListRenderProcessCall()
            : base(RemoteCallId.CfxValueSetListRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetList((CfxListValue)RemoteProxy.Unwrap(value));
        }
    }

}
