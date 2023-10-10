// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_base_scoped_t
{
    internal UIntPtr _size;
    internal IntPtr _del;

    [UnmanagedFunctionPointer(libcef.CEF_CALLBACK)]
#if !DEBUG
    [SuppressUnmanagedCodeSecurity]
#endif
    public delegate void del_delegate(cef_base_ref_counted_t* self);
}
