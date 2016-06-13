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

	/// <summary>
	/// Time information. Values should always be in UTC.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
	/// </remarks>
	public sealed partial class CfrTime : CfrStructure {

        internal static CfrTime Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrTime)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrTime(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxTimeCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        private CfrTime(IntPtr proxyId) : base(proxyId) {}
        public CfrTime() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
        }

        int m_Year;
        bool m_Year_fetched;

        public int Year {
            get {
                if(!m_Year_fetched) {
                    var call = new CfxTimeGetYearRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Year = call.value;
                    m_Year_fetched = true;
                }
                return m_Year;
            }
            set {
                var call = new CfxTimeSetYearRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Year = value;
                m_Year_fetched = true;
            }
        }

        int m_Month;
        bool m_Month_fetched;

        public int Month {
            get {
                if(!m_Month_fetched) {
                    var call = new CfxTimeGetMonthRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Month = call.value;
                    m_Month_fetched = true;
                }
                return m_Month;
            }
            set {
                var call = new CfxTimeSetMonthRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Month = value;
                m_Month_fetched = true;
            }
        }

        int m_DayOfWeek;
        bool m_DayOfWeek_fetched;

        public int DayOfWeek {
            get {
                if(!m_DayOfWeek_fetched) {
                    var call = new CfxTimeGetDayOfWeekRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_DayOfWeek = call.value;
                    m_DayOfWeek_fetched = true;
                }
                return m_DayOfWeek;
            }
            set {
                var call = new CfxTimeSetDayOfWeekRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_DayOfWeek = value;
                m_DayOfWeek_fetched = true;
            }
        }

        int m_DayOfMonth;
        bool m_DayOfMonth_fetched;

        public int DayOfMonth {
            get {
                if(!m_DayOfMonth_fetched) {
                    var call = new CfxTimeGetDayOfMonthRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_DayOfMonth = call.value;
                    m_DayOfMonth_fetched = true;
                }
                return m_DayOfMonth;
            }
            set {
                var call = new CfxTimeSetDayOfMonthRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_DayOfMonth = value;
                m_DayOfMonth_fetched = true;
            }
        }

        int m_Hour;
        bool m_Hour_fetched;

        public int Hour {
            get {
                if(!m_Hour_fetched) {
                    var call = new CfxTimeGetHourRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Hour = call.value;
                    m_Hour_fetched = true;
                }
                return m_Hour;
            }
            set {
                var call = new CfxTimeSetHourRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Hour = value;
                m_Hour_fetched = true;
            }
        }

        int m_Minute;
        bool m_Minute_fetched;

        public int Minute {
            get {
                if(!m_Minute_fetched) {
                    var call = new CfxTimeGetMinuteRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Minute = call.value;
                    m_Minute_fetched = true;
                }
                return m_Minute;
            }
            set {
                var call = new CfxTimeSetMinuteRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Minute = value;
                m_Minute_fetched = true;
            }
        }

        int m_Second;
        bool m_Second_fetched;

        public int Second {
            get {
                if(!m_Second_fetched) {
                    var call = new CfxTimeGetSecondRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Second = call.value;
                    m_Second_fetched = true;
                }
                return m_Second;
            }
            set {
                var call = new CfxTimeSetSecondRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Second = value;
                m_Second_fetched = true;
            }
        }

        int m_Millisecond;
        bool m_Millisecond_fetched;

        /// <summary>
        /// seconds which may take it up to 60).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
        /// </remarks>
        public int Millisecond {
            get {
                if(!m_Millisecond_fetched) {
                    var call = new CfxTimeGetMillisecondRenderProcessCall();
                    call.sender = this.proxyId;
                    call.RequestExecution(this);
                    m_Millisecond = call.value;
                    m_Millisecond_fetched = true;
                }
                return m_Millisecond;
            }
            set {
                var call = new CfxTimeSetMillisecondRenderProcessCall();
                call.sender = this.proxyId;
                call.value = value;
                call.RequestExecution(this);
                m_Millisecond = value;
                m_Millisecond_fetched = true;
            }
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
