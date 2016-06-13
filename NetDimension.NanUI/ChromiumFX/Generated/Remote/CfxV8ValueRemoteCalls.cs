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

	internal class CfxV8ValueCreateUndefinedRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateUndefinedRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateUndefinedRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateUndefined());
        }
    }

    internal class CfxV8ValueCreateNullRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateNullRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateNullRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateNull());
        }
    }

    internal class CfxV8ValueCreateBoolRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateBoolRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateBoolRenderProcessCall) {}

        internal bool value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateBool(value));
        }
    }

    internal class CfxV8ValueCreateIntRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateIntRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateIntRenderProcessCall) {}

        internal int value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateInt(value));
        }
    }

    internal class CfxV8ValueCreateUintRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateUintRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateUintRenderProcessCall) {}

        internal uint value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateUint(value));
        }
    }

    internal class CfxV8ValueCreateDoubleRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateDoubleRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateDoubleRenderProcessCall) {}

        internal double value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateDouble(value));
        }
    }

    internal class CfxV8ValueCreateDateRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateDateRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateDateRenderProcessCall) {}

        internal IntPtr date;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(date);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out date);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateDate((CfxTime)RemoteProxy.Unwrap(date)));
        }
    }

    internal class CfxV8ValueCreateStringRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateStringRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateStringRenderProcessCall) {}

        internal string value;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateString(value));
        }
    }

    internal class CfxV8ValueCreateObjectRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateObjectRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateObjectRenderProcessCall) {}

        internal IntPtr accessor;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(accessor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out accessor);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateObject((CfxV8Accessor)RemoteProxy.Unwrap(accessor)));
        }
    }

    internal class CfxV8ValueCreateArrayRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateArrayRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateArrayRenderProcessCall) {}

        internal int length;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateArray(length));
        }
    }

    internal class CfxV8ValueCreateFunctionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueCreateFunctionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueCreateFunctionRenderProcessCall) {}

        internal string name;
        internal IntPtr handler;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(name);
            h.Write(handler);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out name);
            h.Read(out handler);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxV8Value.CreateFunction(name, (CfxV8Handler)RemoteProxy.Unwrap(handler)));
        }
    }

    internal class CfxV8ValueIsValidRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsValidRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsValidRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxV8ValueIsUndefinedRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsUndefinedRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsUndefinedRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsUndefined;
        }
    }

    internal class CfxV8ValueIsNullRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsNullRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsNullRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsNull;
        }
    }

    internal class CfxV8ValueIsBoolRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsBoolRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsBoolRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsBool;
        }
    }

    internal class CfxV8ValueIsIntRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsIntRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsIntRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsInt;
        }
    }

    internal class CfxV8ValueIsUintRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsUintRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsUintRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsUint;
        }
    }

    internal class CfxV8ValueIsDoubleRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsDoubleRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsDoubleRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsDouble;
        }
    }

    internal class CfxV8ValueIsDateRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsDateRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsDateRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsDate;
        }
    }

    internal class CfxV8ValueIsStringRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsStringRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsStringRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsString;
        }
    }

    internal class CfxV8ValueIsObjectRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsObjectRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsObjectRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsObject;
        }
    }

    internal class CfxV8ValueIsArrayRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsArrayRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsArrayRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsArray;
        }
    }

    internal class CfxV8ValueIsFunctionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsFunctionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsFunctionRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsFunction;
        }
    }

    internal class CfxV8ValueIsSameRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsSameRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsSameRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsSame((CfxV8Value)RemoteProxy.Unwrap(that));
        }
    }

    internal class CfxV8ValueGetBoolValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetBoolValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetBoolValueRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.BoolValue;
        }
    }

    internal class CfxV8ValueGetIntValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetIntValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetIntValueRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IntValue;
        }
    }

    internal class CfxV8ValueGetUintValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetUintValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetUintValueRenderProcessCall) {}

        internal IntPtr self;
        internal uint __retval;

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.UintValue;
        }
    }

    internal class CfxV8ValueGetDoubleValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetDoubleValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetDoubleValueRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.DoubleValue;
        }
    }

    internal class CfxV8ValueGetDateValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetDateValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetDateValueRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.DateValue);
        }
    }

    internal class CfxV8ValueGetStringValueRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetStringValueRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetStringValueRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.StringValue;
        }
    }

    internal class CfxV8ValueIsUserCreatedRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueIsUserCreatedRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueIsUserCreatedRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.IsUserCreated;
        }
    }

    internal class CfxV8ValueHasExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueHasExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueHasExceptionRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.HasException;
        }
    }

    internal class CfxV8ValueGetExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetExceptionRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Exception);
        }
    }

    internal class CfxV8ValueClearExceptionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueClearExceptionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueClearExceptionRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.ClearException();
        }
    }

    internal class CfxV8ValueWillRethrowExceptionsRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueWillRethrowExceptionsRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueWillRethrowExceptionsRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.WillRethrowExceptions();
        }
    }

    internal class CfxV8ValueSetRethrowExceptionsRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueSetRethrowExceptionsRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueSetRethrowExceptionsRenderProcessCall) {}

        internal IntPtr self;
        internal bool rethrow;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(rethrow);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out rethrow);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.SetRethrowExceptions(rethrow);
        }
    }

    internal class CfxV8ValueHasValueByKeyRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueHasValueByKeyRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueHasValueByKeyRenderProcessCall) {}

        internal IntPtr self;
        internal string key;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.HasValue(key);
        }
    }

    internal class CfxV8ValueHasValueByIndexRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueHasValueByIndexRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueHasValueByIndexRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.HasValue(index);
        }
    }

    internal class CfxV8ValueDeleteValueByKeyRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueDeleteValueByKeyRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueDeleteValueByKeyRenderProcessCall) {}

        internal IntPtr self;
        internal string key;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.DeleteValue(key);
        }
    }

    internal class CfxV8ValueDeleteValueByIndexRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueDeleteValueByIndexRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueDeleteValueByIndexRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.DeleteValue(index);
        }
    }

    internal class CfxV8ValueGetValueByKeyRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetValueByKeyRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetValueByKeyRenderProcessCall) {}

        internal IntPtr self;
        internal string key;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(key);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out key);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetValue(key));
        }
    }

    internal class CfxV8ValueGetValueByIndexRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetValueByIndexRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetValueByIndexRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.GetValue(index));
        }
    }

    internal class CfxV8ValueSetValueByKeyRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueSetValueByKeyRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueSetValueByKeyRenderProcessCall) {}

        internal IntPtr self;
        internal string key;
        internal IntPtr value;
        internal int attribute;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(key);
            h.Write(value);
            h.Write(attribute);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out key);
            h.Read(out value);
            h.Read(out attribute);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.SetValue(key, (CfxV8Value)RemoteProxy.Unwrap(value), (CfxV8PropertyAttribute)attribute);
        }
    }

    internal class CfxV8ValueSetValueByIndexRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueSetValueByIndexRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueSetValueByIndexRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.SetValue(index, (CfxV8Value)RemoteProxy.Unwrap(value));
        }
    }

    internal class CfxV8ValueSetValueByAccessorRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueSetValueByAccessorRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueSetValueByAccessorRenderProcessCall) {}

        internal IntPtr self;
        internal string key;
        internal int settings;
        internal int attribute;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(key);
            h.Write(settings);
            h.Write(attribute);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out key);
            h.Read(out settings);
            h.Read(out attribute);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.SetValue(key, (CfxV8AccessControl)settings, (CfxV8PropertyAttribute)attribute);
        }
    }

    internal class CfxV8ValueGetKeysRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetKeysRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetKeysRenderProcessCall) {}

        internal IntPtr self;
        internal System.Collections.Generic.List<string> keys;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(keys);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out keys);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.GetKeys(keys);
        }
    }

    internal class CfxV8ValueSetUserDataRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueSetUserDataRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueSetUserDataRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr userData;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(userData);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out userData);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.SetUserData(CfxBase.Cast(userData));
        }
    }

    internal class CfxV8ValueGetUserDataRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetUserDataRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetUserDataRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = CfxBase.Unwrap(self_local.UserData);
        }
    }

    internal class CfxV8ValueGetExternallyAllocatedMemoryRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetExternallyAllocatedMemoryRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetExternallyAllocatedMemoryRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.ExternallyAllocatedMemory;
        }
    }

    internal class CfxV8ValueAdjustExternallyAllocatedMemoryRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueAdjustExternallyAllocatedMemoryRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueAdjustExternallyAllocatedMemoryRenderProcessCall) {}

        internal IntPtr self;
        internal int changeInBytes;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(changeInBytes);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out changeInBytes);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.AdjustExternallyAllocatedMemory(changeInBytes);
        }
    }

    internal class CfxV8ValueGetArrayLengthRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetArrayLengthRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetArrayLengthRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.ArrayLength;
        }
    }

    internal class CfxV8ValueGetFunctionNameRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetFunctionNameRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetFunctionNameRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = self_local.FunctionName;
        }
    }

    internal class CfxV8ValueGetFunctionHandlerRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueGetFunctionHandlerRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueGetFunctionHandlerRenderProcessCall) {}

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
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.FunctionHandler);
        }
    }

    internal class CfxV8ValueExecuteFunctionRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueExecuteFunctionRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueExecuteFunctionRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr @object;
        internal IntPtr[] arguments;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(@object);
            h.Write(arguments);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out @object);
            h.Read(out arguments);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            CfxV8Value[] arguments_unwrapped;
            if(arguments != null) {
                arguments_unwrapped = new CfxV8Value[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    arguments_unwrapped[i] = (CfxV8Value)RemoteProxy.Unwrap(arguments[i]);
                }
            } else {
                arguments_unwrapped = null;
            }
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.ExecuteFunction((CfxV8Value)RemoteProxy.Unwrap(@object), arguments_unwrapped));
        }
    }

    internal class CfxV8ValueExecuteFunctionWithContextRenderProcessCall : RenderProcessCall {

        internal CfxV8ValueExecuteFunctionWithContextRenderProcessCall()
            : base(RemoteCallId.CfxV8ValueExecuteFunctionWithContextRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr context;
        internal IntPtr @object;
        internal IntPtr[] arguments;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(context);
            h.Write(@object);
            h.Write(arguments);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out context);
            h.Read(out @object);
            h.Read(out arguments);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            CfxV8Value[] arguments_unwrapped;
            if(arguments != null) {
                arguments_unwrapped = new CfxV8Value[arguments.Length];
                for(int i = 0; i < arguments.Length; ++i) {
                    arguments_unwrapped[i] = (CfxV8Value)RemoteProxy.Unwrap(arguments[i]);
                }
            } else {
                arguments_unwrapped = null;
            }
            var self_local = (CfxV8Value)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.ExecuteFunctionWithContext((CfxV8Context)RemoteProxy.Unwrap(context), (CfxV8Value)RemoteProxy.Unwrap(@object), arguments_unwrapped));
        }
    }

}
