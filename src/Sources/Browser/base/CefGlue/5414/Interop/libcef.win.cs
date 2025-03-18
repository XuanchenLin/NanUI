// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue.Interop;
internal static unsafe partial class libcef
{
    // CefSetOSModalLoop
    [DllImport(DllName, EntryPoint = "cef_set_osmodal_loop", CallingConvention = libcef.CEF_CALL)]
    public static extern void set_osmodal_loop(int osModalLoop);

    // CefEnableHighDPISupport
    [DllImport(DllName, EntryPoint = "cef_enable_highdpi_support", CallingConvention = libcef.CEF_CALL)]
    public static extern void enable_highdpi_support();
}
