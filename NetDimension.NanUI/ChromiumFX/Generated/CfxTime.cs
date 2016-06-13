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

namespace Chromium
{
	/// <summary>
	/// Time information. Values should always be in UTC.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
	/// </remarks>
	public sealed partial class CfxTime : CfxStructure {

        static CfxTime () {
            CfxApiLoader.LoadCfxTimeApi();
        }

        internal static CfxTime Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxTime(nativePtr);
        }

        internal static CfxTime WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxTime(nativePtr, CfxApi.cfx_time_dtor);
        }

        public CfxTime() : base(CfxApi.cfx_time_ctor, CfxApi.cfx_time_dtor) {}
        internal CfxTime(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxTime(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int Year {
            get {
                int value;
                CfxApi.cfx_time_get_year(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_year(nativePtrUnchecked, value);
            }
        }

        public int Month {
            get {
                int value;
                CfxApi.cfx_time_get_month(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_month(nativePtrUnchecked, value);
            }
        }

        public int DayOfWeek {
            get {
                int value;
                CfxApi.cfx_time_get_day_of_week(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_day_of_week(nativePtrUnchecked, value);
            }
        }

        public int DayOfMonth {
            get {
                int value;
                CfxApi.cfx_time_get_day_of_month(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_day_of_month(nativePtrUnchecked, value);
            }
        }

        public int Hour {
            get {
                int value;
                CfxApi.cfx_time_get_hour(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_hour(nativePtrUnchecked, value);
            }
        }

        public int Minute {
            get {
                int value;
                CfxApi.cfx_time_get_minute(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_minute(nativePtrUnchecked, value);
            }
        }

        public int Second {
            get {
                int value;
                CfxApi.cfx_time_get_second(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_second(nativePtrUnchecked, value);
            }
        }

        /// <summary>
        /// seconds which may take it up to 60).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
        /// </remarks>
        public int Millisecond {
            get {
                int value;
                CfxApi.cfx_time_get_millisecond(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_time_set_millisecond(nativePtrUnchecked, value);
            }
        }

    }
}
