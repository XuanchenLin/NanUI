// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
internal static unsafe partial class libcef
{
    // These functions set string values. If |copy| is true (1) the value will be
    // copied instead of referenced. It is up to the user to properly manage
    // the lifespan of references.

    [DllImport(DllName, EntryPoint = "cef_string_utf16_set", CallingConvention = CEF_CALL)]
    public static extern int string_set(char* src, UIntPtr src_len, cef_string_t* output, int copy);


    // These functions clear string values. The structure itself is not freed.

    [DllImport(DllName, EntryPoint = "cef_string_utf16_clear", CallingConvention = CEF_CALL)]
    public static extern void string_clear(cef_string_t* str);


    // These functions allocate a new string structure. They must be freed by
    // calling the associated free function.

    [DllImport(DllName, EntryPoint = "cef_string_userfree_utf16_alloc", CallingConvention = CEF_CALL)]
    public static extern cef_string_userfree* string_userfree_alloc();


    // These functions free the string structure allocated by the associated
    // alloc function. Any string contents will first be cleared.

    [DllImport(DllName, EntryPoint = "cef_string_userfree_utf16_free", CallingConvention = CEF_CALL)]
    public static extern void string_userfree_free(cef_string_userfree* str);
}
