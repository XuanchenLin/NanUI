// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Time information. Values should always be in UTC.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_time.h">cef/include/internal/cef_time.h</see>.
    /// </remarks>
    public sealed partial class CfxTime : CfxStructure {

        internal static CfxTime Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxTime(nativePtr);
        }

        internal static CfxTime WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxTime(nativePtr, CfxApi.Time.cfx_time_dtor);
        }

        public CfxTime() : base(CfxApi.Time.cfx_time_ctor, CfxApi.Time.cfx_time_dtor) {}
        internal CfxTime(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxTime(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int Year {
            get {
                int value;
                CfxApi.Time.cfx_time_get_year(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_year(nativePtrUnchecked, value);
            }
        }

        public int Month {
            get {
                int value;
                CfxApi.Time.cfx_time_get_month(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_month(nativePtrUnchecked, value);
            }
        }

        public int DayOfWeek {
            get {
                int value;
                CfxApi.Time.cfx_time_get_day_of_week(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_day_of_week(nativePtrUnchecked, value);
            }
        }

        public int DayOfMonth {
            get {
                int value;
                CfxApi.Time.cfx_time_get_day_of_month(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_day_of_month(nativePtrUnchecked, value);
            }
        }

        public int Hour {
            get {
                int value;
                CfxApi.Time.cfx_time_get_hour(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_hour(nativePtrUnchecked, value);
            }
        }

        public int Minute {
            get {
                int value;
                CfxApi.Time.cfx_time_get_minute(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_minute(nativePtrUnchecked, value);
            }
        }

        public int Second {
            get {
                int value;
                CfxApi.Time.cfx_time_get_second(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_second(nativePtrUnchecked, value);
            }
        }

        public int Millisecond {
            get {
                int value;
                CfxApi.Time.cfx_time_get_millisecond(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.Time.cfx_time_set_millisecond(nativePtrUnchecked, value);
            }
        }

    }
}
