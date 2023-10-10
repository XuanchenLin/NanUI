// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_insets_t
{
    public int top;
    public int left;
    public int bottom;
    public int right;

    public cef_insets_t(int top, int left, int bottom, int right)
    {
        this.top = top;
        this.left = left;
        this.bottom = bottom;
        this.right = right;
    }
}
