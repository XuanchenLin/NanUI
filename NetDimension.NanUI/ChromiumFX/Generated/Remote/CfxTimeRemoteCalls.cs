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

	internal class CfxTimeCtorRenderProcessCall : RenderProcessCall {

        internal CfxTimeCtorRenderProcessCall()
            : base(RemoteCallId.CfxTimeCtorRenderProcessCall) {}

        internal IntPtr __retval;
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(new CfxTime());
        }
    }

    internal class CfxTimeGetYearRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetYearRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetYearRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Year;
        }
    }
    internal class CfxTimeSetYearRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetYearRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetYearRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Year = value;
        }
    }
    internal class CfxTimeGetMonthRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetMonthRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetMonthRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Month;
        }
    }
    internal class CfxTimeSetMonthRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetMonthRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetMonthRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Month = value;
        }
    }
    internal class CfxTimeGetDayOfWeekRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetDayOfWeekRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetDayOfWeekRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.DayOfWeek;
        }
    }
    internal class CfxTimeSetDayOfWeekRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetDayOfWeekRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetDayOfWeekRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.DayOfWeek = value;
        }
    }
    internal class CfxTimeGetDayOfMonthRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetDayOfMonthRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetDayOfMonthRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.DayOfMonth;
        }
    }
    internal class CfxTimeSetDayOfMonthRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetDayOfMonthRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetDayOfMonthRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.DayOfMonth = value;
        }
    }
    internal class CfxTimeGetHourRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetHourRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetHourRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Hour;
        }
    }
    internal class CfxTimeSetHourRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetHourRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetHourRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Hour = value;
        }
    }
    internal class CfxTimeGetMinuteRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetMinuteRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetMinuteRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Minute;
        }
    }
    internal class CfxTimeSetMinuteRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetMinuteRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetMinuteRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Minute = value;
        }
    }
    internal class CfxTimeGetSecondRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetSecondRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetSecondRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Second;
        }
    }
    internal class CfxTimeSetSecondRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetSecondRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetSecondRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Second = value;
        }
    }
    internal class CfxTimeGetMillisecondRenderProcessCall : RenderProcessCall {

        internal CfxTimeGetMillisecondRenderProcessCall()
            : base(RemoteCallId.CfxTimeGetMillisecondRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            value = sender.Millisecond;
        }
    }
    internal class CfxTimeSetMillisecondRenderProcessCall : RenderProcessCall {

        internal CfxTimeSetMillisecondRenderProcessCall()
            : base(RemoteCallId.CfxTimeSetMillisecondRenderProcessCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var sender = (CfxTime)RemoteProxy.Unwrap(this.sender);
            sender.Millisecond = value;
        }
    }
}
