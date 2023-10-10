// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Time information. Values should always be in UTC.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
public struct CefTime
{
    private static readonly DateTime s_maxDateTime = new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Utc);

    /// <summary>
    /// Four or five digit year "2007" (1601 to 30827 on Windows, 1970 to 2038 on
    /// 32-bit POSIX)
    /// </summary>
    public int Year;

    /// <summary>1-based month (values 1 = January, etc.)</summary>
    public int Month;

    /// <summary>0-based day of week (0 = Sunday, etc.)</summary>
    public int DayOfWeek;

    /// <summary>1-based day of month (1-31)</summary>
    public int DayOfMonth;

    /// <summary>Hour within the current day (0-23)</summary>
    public int Hour;

    /// <summary>Minute within the current hour (0-59)</summary>
    public int Minute;

    /// <summary>
    /// Second within the current minute (0-59 plus leap seconds which may take
    /// it up to 60).
    /// </summary>
    public int Second;

    /// <summary>Milliseconds within the current second (0-999)</summary>
    public int Millisecond;

    public CefTime(DateTime value)
    {
        value = value.ToUniversalTime();

        Year = value.Year;
        Month = value.Month;
        DayOfWeek = (int)value.DayOfWeek;
        DayOfMonth = value.Day;
        Hour = value.Hour;
        Minute = value.Minute;
        Second = value.Second;
        Millisecond = value.Millisecond;
    }

    [Obsolete("Avoid use this method. All date manipulations should be in CefBaseTime.")]
    public DateTime ToDateTime()
    {
        if (Year > 9999) return s_maxDateTime;
        return new DateTime(
            Year,
            Month,
            DayOfMonth,
            Hour,
            Minute,
            Second != 60 ? Second : 59,
            Millisecond,
            DateTimeKind.Utc
            );
    }

    [Obsolete("Avoid use this method. All date manipulations should be in CefBaseTime.")]
    public static unsafe DateTime ToDateTime(CefTime* ptr)
    {
        var year = ptr->Year;
        if (year > 9999) return s_maxDateTime;
        return new DateTime(
            year,
            ptr->Month,
            ptr->DayOfMonth,
            ptr->Hour,
            ptr->Minute,
            ptr->Second != 60 ? ptr->Second : 59,
            ptr->Millisecond,
            DateTimeKind.Utc
            );
    }
}
