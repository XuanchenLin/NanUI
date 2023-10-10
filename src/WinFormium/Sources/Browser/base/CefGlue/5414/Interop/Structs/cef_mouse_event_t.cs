// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_mouse_event_t
{
    public int x;
    public int y;
    public CefEventFlags modifiers;

    public cef_mouse_event_t(int x, int y, CefEventFlags modifiers)
    {
        this.x = x;
        this.y = y;
        this.modifiers = modifiers;
    }
}
