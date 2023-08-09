namespace Xilium.CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    using Xilium.CefGlue.Interop;

    /// <summary>
    /// Represents a wall clock time in UTC. Values are not guaranteed to be
    /// monotonically non-decreasing and are subject to large amounts of skew.
    /// Time is stored internally as microseconds since the Windows epoch (1601).
    ///
    /// <para>This is equivalent of Chromium `base::Time` (see base/time/time.h).</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    public readonly struct CefBaseTime
    {
        private readonly long _microseconds;

        public CefBaseTime(long ticks)
        {
            _microseconds = ticks;
        }

        /// <summary>
        /// Microseconds since the Windows epoch (1601).
        /// </summary>
        public long Ticks => _microseconds;

        /// <summary>
        /// Retrieve the current system time.
        /// </summary>
        public static CefBaseTime Now() => libcef.basetime_now();

        /// <summary>
        /// Converts cef_basetime_t to cef_time_t. Returns true (1) on success and
        /// false (0) on failure.
        /// </summary>
        public unsafe bool UtcExplode(out CefTime exploded)
        {
            return libcef.time_from_basetime(this, out exploded) != 0;
        }

        /// <summary>
        /// Converts cef_time_t to cef_basetime_t. Returns true (1) on success and
        /// false (0) on failure.
        /// </summary>
        public static unsafe bool FromUtcExploded(in CefTime exploded, out CefBaseTime time)
        {
            return libcef.time_to_basetime(in exploded, out time) != 0;
        }
    }
}
