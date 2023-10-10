// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe partial struct cef_string_t
{
    internal char* _str;
    internal UIntPtr _length;
    internal IntPtr _dtor;

    [UnmanagedFunctionPointer(libcef.CEF_CALL)]
#if !DEBUG
    [SuppressUnmanagedCodeSecurity]
#endif
    public delegate void dtor_delegate(char* str);

    public cef_string_t(char* str, int length)
    {
        _str = str;
        _length = (UIntPtr)length;
        _dtor = IntPtr.Zero;
    }

    public static void Copy(string value, cef_string_t* str)
    {
        fixed (char* value_ptr = value)
        {
            libcef.string_set(value_ptr, value != null ? (UIntPtr)value.Length : UIntPtr.Zero, str, 1); // FIXME: do not ignore result
        }
    }

    public static string ToString(cef_string_t* obj)
    {
        if (obj == null) return null;

        return new string((char*)obj->_str, 0, (int)obj->_length);
    }
}
