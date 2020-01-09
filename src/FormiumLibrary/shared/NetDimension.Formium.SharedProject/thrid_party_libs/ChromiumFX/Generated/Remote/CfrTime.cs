// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Time information. Values should always be in UTC.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
    /// </remarks>
    public sealed partial class CfrTime : CfrStructure {

        internal static CfrTime Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            return (CfrTime)weakCache.GetOrAdd(remotePtr.ptr, () => new CfrTime(remotePtr));
        }


        private CfrTime(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrTime() : base(new CfxTimeCtorRemoteCall(), new CfxTimeDtorRemoteCall()) {}

        int m_Year;
        bool m_Year_fetched;

        public int Year {
            get {
                if(!m_Year_fetched) {
                    var call = new CfxTimeGetYearRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Year = call.value;
                    m_Year_fetched = true;
                }
                return m_Year;
            }
            set {
                var call = new CfxTimeSetYearRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Year = value;
                m_Year_fetched = true;
            }
        }

        int m_Month;
        bool m_Month_fetched;

        public int Month {
            get {
                if(!m_Month_fetched) {
                    var call = new CfxTimeGetMonthRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Month = call.value;
                    m_Month_fetched = true;
                }
                return m_Month;
            }
            set {
                var call = new CfxTimeSetMonthRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Month = value;
                m_Month_fetched = true;
            }
        }

        int m_DayOfWeek;
        bool m_DayOfWeek_fetched;

        public int DayOfWeek {
            get {
                if(!m_DayOfWeek_fetched) {
                    var call = new CfxTimeGetDayOfWeekRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_DayOfWeek = call.value;
                    m_DayOfWeek_fetched = true;
                }
                return m_DayOfWeek;
            }
            set {
                var call = new CfxTimeSetDayOfWeekRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_DayOfWeek = value;
                m_DayOfWeek_fetched = true;
            }
        }

        int m_DayOfMonth;
        bool m_DayOfMonth_fetched;

        public int DayOfMonth {
            get {
                if(!m_DayOfMonth_fetched) {
                    var call = new CfxTimeGetDayOfMonthRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_DayOfMonth = call.value;
                    m_DayOfMonth_fetched = true;
                }
                return m_DayOfMonth;
            }
            set {
                var call = new CfxTimeSetDayOfMonthRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_DayOfMonth = value;
                m_DayOfMonth_fetched = true;
            }
        }

        int m_Hour;
        bool m_Hour_fetched;

        public int Hour {
            get {
                if(!m_Hour_fetched) {
                    var call = new CfxTimeGetHourRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Hour = call.value;
                    m_Hour_fetched = true;
                }
                return m_Hour;
            }
            set {
                var call = new CfxTimeSetHourRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Hour = value;
                m_Hour_fetched = true;
            }
        }

        int m_Minute;
        bool m_Minute_fetched;

        public int Minute {
            get {
                if(!m_Minute_fetched) {
                    var call = new CfxTimeGetMinuteRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Minute = call.value;
                    m_Minute_fetched = true;
                }
                return m_Minute;
            }
            set {
                var call = new CfxTimeSetMinuteRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Minute = value;
                m_Minute_fetched = true;
            }
        }

        int m_Second;
        bool m_Second_fetched;

        public int Second {
            get {
                if(!m_Second_fetched) {
                    var call = new CfxTimeGetSecondRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Second = call.value;
                    m_Second_fetched = true;
                }
                return m_Second;
            }
            set {
                var call = new CfxTimeSetSecondRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Second = value;
                m_Second_fetched = true;
            }
        }

        int m_Millisecond;
        bool m_Millisecond_fetched;

        public int Millisecond {
            get {
                if(!m_Millisecond_fetched) {
                    var call = new CfxTimeGetMillisecondRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Millisecond = call.value;
                    m_Millisecond_fetched = true;
                }
                return m_Millisecond;
            }
            set {
                var call = new CfxTimeSetMillisecondRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Millisecond = value;
                m_Millisecond_fetched = true;
            }
        }
    }
}
