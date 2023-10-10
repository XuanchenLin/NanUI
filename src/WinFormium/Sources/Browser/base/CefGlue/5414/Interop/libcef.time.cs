// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
internal static unsafe partial class libcef
{
    [DllImport(DllName, EntryPoint = "cef_basetime_now", CallingConvention = CEF_CALL)]
    public static extern CefBaseTime basetime_now();

    [DllImport(DllName, EntryPoint = "cef_time_to_basetime", CallingConvention = CEF_CALL)]
    public static extern int time_to_basetime(in CefTime from, out CefBaseTime to);

    [DllImport(DllName, EntryPoint = "cef_time_from_basetime", CallingConvention = CEF_CALL)]
    public static extern int time_from_basetime(CefBaseTime from, out CefTime to);

    /*
    ///
    // Converts cef_time_t to/from time_t. Returns true (1) on success and false
    // (0) on failure.
    ///
    CEF_EXPORT int cef_time_to_timet(const cef_time_t* cef_time, time_t* time);
    CEF_EXPORT int cef_time_from_timet(time_t time, cef_time_t* cef_time);

    ///
    // Converts cef_time_t to/from a double which is the number of seconds since
    // epoch (Jan 1, 1970). Webkit uses this format to represent time. A value of 0
    // means "not initialized". Returns true (1) on success and false (0) on
    // failure.
    ///
    CEF_EXPORT int cef_time_to_doublet(const cef_time_t* cef_time, double* time);
    CEF_EXPORT int cef_time_from_doublet(double time, cef_time_t* cef_time);

    ///
    // Retrieve the current system time. Returns true (1) on success and false (0)
    // on failure.
    ///
    CEF_EXPORT int cef_time_now(cef_time_t* cef_time);

    ///
    // Retrieve the current system time.
    ///
    CEF_EXPORT cef_basetime_t cef_basetime_now();

    ///
    // Retrieve the delta in milliseconds between two time values. Returns true (1)
    // on success and false (0) on failure.
    ///
    CEF_EXPORT int cef_time_delta(const cef_time_t* cef_time1,
                                  const cef_time_t* cef_time2,
                                  long long* delta);
    ///
    // Converts cef_time_t to cef_basetime_t. Returns true (1) on success and
    // false (0) on failure.
    ///
    CEF_EXPORT int cef_time_to_basetime(const cef_time_t* from, cef_basetime_t* to);

    ///
    // Converts cef_basetime_t to cef_time_t. Returns true (1) on success and
    // false (0) on failure.
    ///
    CEF_EXPORT int cef_time_from_basetime(const cef_basetime_t from,
                                          cef_time_t* to);
    */
}
