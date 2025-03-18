// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

internal class Win32WindowWrap : IWin32Window
{
    public IntPtr Handle { get; }

    public Win32WindowWrap(IntPtr handle)
    {
        Handle = handle;
    }
}
