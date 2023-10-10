// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
internal struct cef_main_args_t
{
}

[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_main_args_t_windows
{
    public IntPtr instance;

    #region Alloc & Free
    private static int _sizeof;

    static cef_main_args_t_windows()
    {
        _sizeof = Marshal.SizeOf(typeof(cef_main_args_t_windows));
    }

    public static cef_main_args_t_windows* Alloc()
    {
        var ptr = (cef_main_args_t_windows*)Marshal.AllocHGlobal(_sizeof);
        *ptr = new cef_main_args_t_windows();
        return ptr;
    }

    public static void Free(cef_main_args_t_windows* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }
    #endregion
}

[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_main_args_t_posix
{
    public int argc;
    public IntPtr argv;

    #region Alloc & Free
    private static int _sizeof;

    static cef_main_args_t_posix()
    {
        _sizeof = Marshal.SizeOf(typeof(cef_main_args_t_posix));
    }

    public static cef_main_args_t_posix* Alloc()
    {
        var ptr = (cef_main_args_t_posix*)Marshal.AllocHGlobal(_sizeof);
        *ptr = new cef_main_args_t_posix();
        return ptr;
    }

    public static void Free(cef_main_args_t_posix* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }
    #endregion
}
