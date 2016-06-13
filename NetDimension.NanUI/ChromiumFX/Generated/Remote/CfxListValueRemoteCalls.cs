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

	internal class CfxListValueCreateRenderProcessCall : RenderProcessCall {

        internal CfxListValueCreateRenderProcessCall()
            : base(RemoteCallId.CfxListValueCreateRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxListValue.Create());
        }
    }

    internal class CfxListValueIsValidRenderProcessCall : RenderProcessCall {

        internal CfxListValueIsValidRenderProcessCall()
            : base(RemoteCallId.CfxListValueIsValidRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxListValueIsOwnedRenderProcessCall : RenderProcessCall {

        internal CfxListValueIsOwnedRenderProcessCall()
            : base(RemoteCallId.CfxListValueIsOwnedRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsOwned;
        }
    }

    internal class CfxListValueIsReadOnlyRenderProcessCall : RenderProcessCall {

        internal CfxListValueIsReadOnlyRenderProcessCall()
            : base(RemoteCallId.CfxListValueIsReadOnlyRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsReadOnly;
        }
    }

    internal class CfxListValueIsSameRenderProcessCall : RenderProcessCall {

        internal CfxListValueIsSameRenderProcessCall()
            : base(RemoteCallId.CfxListValueIsSameRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxListValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxListValueIsEqualRenderProcessCall : RenderProcessCall {

        internal CfxListValueIsEqualRenderProcessCall()
            : base(RemoteCallId.CfxListValueIsEqualRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.IsEqual((CfxListValue)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxListValueCopyRenderProcessCall : RenderProcessCall {

        internal CfxListValueCopyRenderProcessCall()
            : base(RemoteCallId.CfxListValueCopyRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Copy());
        }
    }

    internal class CfxListValueSetSizeRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetSizeRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetSizeRenderProcessCall) {}

        internal IntPtr self;
        internal int size;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(size);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out size);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetSize(size);
        }
    }

    internal class CfxListValueGetSizeRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetSizeRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetSizeRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Size;
        }
    }

    internal class CfxListValueClearRenderProcessCall : RenderProcessCall {

        internal CfxListValueClearRenderProcessCall()
            : base(RemoteCallId.CfxListValueClearRenderProcessCall) {}

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
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Clear();
        }
    }

    internal class CfxListValueRemoveRenderProcessCall : RenderProcessCall {

        internal CfxListValueRemoveRenderProcessCall()
            : base(RemoteCallId.CfxListValueRemoveRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.Remove(index);
        }
    }

    internal class CfxListValueGetTypeRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetTypeRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetTypeRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = (int)self_local.GetType(index);
        }
    }

    internal class CfxListValueGetValueRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetValueRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetValueRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetValue(index));
        }
    }

    internal class CfxListValueGetBoolRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetBoolRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetBoolRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.GetBool(index);
        }
    }

    internal class CfxListValueGetIntRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetIntRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetIntRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.GetInt(index);
        }
    }

    internal class CfxListValueGetDoubleRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetDoubleRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetDoubleRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal double __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.GetDouble(index);
        }
    }

    internal class CfxListValueGetStringRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetStringRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetStringRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.GetString(index);
        }
    }

    internal class CfxListValueGetBinaryRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetBinaryRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetBinaryRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetBinary(index));
        }
    }

    internal class CfxListValueGetDictionaryRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetDictionaryRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetDictionaryRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetDictionary(index));
        }
    }

    internal class CfxListValueGetListRenderProcessCall : RenderProcessCall {

        internal CfxListValueGetListRenderProcessCall()
            : base(RemoteCallId.CfxListValueGetListRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetList(index));
        }
    }

    internal class CfxListValueSetValueRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetValueRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetValueRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetValue(index, (CfxValue)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxListValueSetNullRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetNullRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetNullRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetNull(index);
        }
    }

    internal class CfxListValueSetBoolRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetBoolRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetBoolRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal bool value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetBool(index, value);
        }
    }

    internal class CfxListValueSetIntRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetIntRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetIntRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal int value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetInt(index, value);
        }
    }

    internal class CfxListValueSetDoubleRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetDoubleRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetDoubleRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal double value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetDouble(index, value);
        }
    }

    internal class CfxListValueSetStringRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetStringRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetStringRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetString(index, value);
        }
    }

    internal class CfxListValueSetBinaryRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetBinaryRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetBinaryRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetBinary(index, (CfxBinaryValue)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxListValueSetDictionaryRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetDictionaryRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetDictionaryRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetDictionary(index, (CfxDictionaryValue)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxListValueSetListRenderProcessCall : RenderProcessCall {

        internal CfxListValueSetListRenderProcessCall()
            : base(RemoteCallId.CfxListValueSetListRenderProcessCall) {}

        internal IntPtr self;
        internal int index;
        internal IntPtr value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(index);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out index);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxListValue)RemoteProxy.Unwrap(self);
            __retval = self_local.SetList(index, (CfxListValue)RemoteProxy.Unwrap(value));
        }
    }

}
