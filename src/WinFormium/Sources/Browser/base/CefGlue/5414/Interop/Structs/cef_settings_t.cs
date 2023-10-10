// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_settings_t
{
    public UIntPtr size;
    public int no_sandbox;
    public cef_string_t browser_subprocess_path;
    public cef_string_t framework_dir_path;
    public cef_string_t main_bundle_path;
    public int chrome_runtime;
    public int multi_threaded_message_loop;
    public int external_message_pump;
    public int windowless_rendering_enabled;
    public int command_line_args_disabled;
    public cef_string_t cache_path;
    public cef_string_t root_cache_path;
    public cef_string_t user_data_path;
    public int persist_session_cookies;
    public int persist_user_preferences;
    public cef_string_t user_agent;
    public cef_string_t user_agent_product;
    public cef_string_t locale;
    public cef_string_t log_file;
    public CefLogSeverity log_severity;
    public cef_string_t javascript_flags;
    public cef_string_t resources_dir_path;
    public cef_string_t locales_dir_path;
    public int pack_loading_disabled;
    public int remote_debugging_port;
    public int uncaught_exception_stack_size;
    public uint background_color;
    public cef_string_t accept_language_list;
    public cef_string_t cookieable_schemes_list;
    public int cookieable_schemes_exclude_defaults;

    #region Alloc & Free
    private static int _sizeof;

    static cef_settings_t()
    {
        _sizeof = Marshal.SizeOf(typeof(cef_settings_t));
    }

    public static cef_settings_t* Alloc()
    {
        var ptr = (cef_settings_t*)Marshal.AllocHGlobal(_sizeof);
        *ptr = new cef_settings_t();
        ptr->size = (UIntPtr)_sizeof;
        return ptr;
    }

    public static void Free(cef_settings_t* ptr)
    {
        Marshal.FreeHGlobal((IntPtr)ptr);
    }
    #endregion
}
