// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxTimeCtorRemoteCall : CtorRemoteCall {

        internal CfxTimeCtorRemoteCall()
            : base(RemoteCallId.CfxTimeCtorRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.Time.cfx_time_ctor();
        }
    }

    internal class CfxTimeDtorRemoteCall : DtorRemoteCall {

        internal CfxTimeDtorRemoteCall()
            : base(RemoteCallId.CfxTimeDtorRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_dtor(nativePtr);
        }
    }

    internal class CfxTimeGetYearRemoteCall : RemoteCall {

        internal CfxTimeGetYearRemoteCall()
            : base(RemoteCallId.CfxTimeGetYearRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_year(sender, out value);
        }
    }
    internal class CfxTimeSetYearRemoteCall : RemoteCall {

        internal CfxTimeSetYearRemoteCall()
            : base(RemoteCallId.CfxTimeSetYearRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_year(sender, value);
        }
    }
    internal class CfxTimeGetMonthRemoteCall : RemoteCall {

        internal CfxTimeGetMonthRemoteCall()
            : base(RemoteCallId.CfxTimeGetMonthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_month(sender, out value);
        }
    }
    internal class CfxTimeSetMonthRemoteCall : RemoteCall {

        internal CfxTimeSetMonthRemoteCall()
            : base(RemoteCallId.CfxTimeSetMonthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_month(sender, value);
        }
    }
    internal class CfxTimeGetDayOfWeekRemoteCall : RemoteCall {

        internal CfxTimeGetDayOfWeekRemoteCall()
            : base(RemoteCallId.CfxTimeGetDayOfWeekRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_day_of_week(sender, out value);
        }
    }
    internal class CfxTimeSetDayOfWeekRemoteCall : RemoteCall {

        internal CfxTimeSetDayOfWeekRemoteCall()
            : base(RemoteCallId.CfxTimeSetDayOfWeekRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_day_of_week(sender, value);
        }
    }
    internal class CfxTimeGetDayOfMonthRemoteCall : RemoteCall {

        internal CfxTimeGetDayOfMonthRemoteCall()
            : base(RemoteCallId.CfxTimeGetDayOfMonthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_day_of_month(sender, out value);
        }
    }
    internal class CfxTimeSetDayOfMonthRemoteCall : RemoteCall {

        internal CfxTimeSetDayOfMonthRemoteCall()
            : base(RemoteCallId.CfxTimeSetDayOfMonthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_day_of_month(sender, value);
        }
    }
    internal class CfxTimeGetHourRemoteCall : RemoteCall {

        internal CfxTimeGetHourRemoteCall()
            : base(RemoteCallId.CfxTimeGetHourRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_hour(sender, out value);
        }
    }
    internal class CfxTimeSetHourRemoteCall : RemoteCall {

        internal CfxTimeSetHourRemoteCall()
            : base(RemoteCallId.CfxTimeSetHourRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_hour(sender, value);
        }
    }
    internal class CfxTimeGetMinuteRemoteCall : RemoteCall {

        internal CfxTimeGetMinuteRemoteCall()
            : base(RemoteCallId.CfxTimeGetMinuteRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_minute(sender, out value);
        }
    }
    internal class CfxTimeSetMinuteRemoteCall : RemoteCall {

        internal CfxTimeSetMinuteRemoteCall()
            : base(RemoteCallId.CfxTimeSetMinuteRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_minute(sender, value);
        }
    }
    internal class CfxTimeGetSecondRemoteCall : RemoteCall {

        internal CfxTimeGetSecondRemoteCall()
            : base(RemoteCallId.CfxTimeGetSecondRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_second(sender, out value);
        }
    }
    internal class CfxTimeSetSecondRemoteCall : RemoteCall {

        internal CfxTimeSetSecondRemoteCall()
            : base(RemoteCallId.CfxTimeSetSecondRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_second(sender, value);
        }
    }
    internal class CfxTimeGetMillisecondRemoteCall : RemoteCall {

        internal CfxTimeGetMillisecondRemoteCall()
            : base(RemoteCallId.CfxTimeGetMillisecondRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_get_millisecond(sender, out value);
        }
    }
    internal class CfxTimeSetMillisecondRemoteCall : RemoteCall {

        internal CfxTimeSetMillisecondRemoteCall()
            : base(RemoteCallId.CfxTimeSetMillisecondRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Time.cfx_time_set_millisecond(sender, value);
        }
    }
}
