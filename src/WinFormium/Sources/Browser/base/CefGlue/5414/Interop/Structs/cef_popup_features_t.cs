// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue.Interop;
[StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
internal unsafe struct cef_popup_features_t
{
    public int x;
    public int xSet;
    public int y;
    public int ySet;
    public int width;
    public int widthSet;
    public int height;
    public int heightSet;

    public int menuBarVisible;
    public int statusBarVisible;
    public int toolBarVisible;
    public int scrollbarsVisible;
}
