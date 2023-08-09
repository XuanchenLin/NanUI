//
// CEF provides functions for converting between UTF-8, -16 and -32 strings.
// CEF string types are safe for reading from multiple threads but not for
// modification. It is the user's responsibility to provide synchronization if
// modifying CEF strings from multiple threads.
//
//
// This file manually written from cef/include/internal/cef_win.h.
//
namespace Xilium.CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    internal static unsafe partial class libcef
    {
        // CefSetOSModalLoop
        [DllImport(DllName, EntryPoint = "cef_set_osmodal_loop", CallingConvention = libcef.CEF_CALL)]
        public static extern void set_osmodal_loop(int osModalLoop);

        // CefEnableHighDPISupport
        [DllImport(DllName, EntryPoint = "cef_enable_highdpi_support", CallingConvention = libcef.CEF_CALL)]
        public static extern void enable_highdpi_support();
    }
}
