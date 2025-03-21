// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_request_context_settings_t
{
    public UIntPtr size;
    public cef_string_t cache_path;
    public int persist_session_cookies;
    public int persist_user_preferences;
    public cef_string_t accept_language_list;
    public cef_string_t cookieable_schemes_list;
    public int cookieable_schemes_exclude_defaults;

    #region Alloc & Free
    private static int _sizeof;

    static cef_request_context_settings_t()
    {
        _sizeof = Marshal.SizeOf(typeof(cef_request_context_settings_t));
    }

    public static cef_request_context_settings_t* Alloc()
    {
        var ptr = (cef_request_context_settings_t*)Marshal.AllocHGlobal(_sizeof);
        *ptr = new cef_request_context_settings_t();
        ptr->size = (UIntPtr)_sizeof;
        return ptr;
    }

    public static void Free(cef_request_context_settings_t* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }
    #endregion
}
