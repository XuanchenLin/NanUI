// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

public class WindowDpiChangedEventArgs : EventArgs
{
    public int OldDPI { get; }
    public int NewDPI { get; }

    internal WindowDpiChangedEventArgs(int oldDpi, int newDpi)
    {
        OldDPI = oldDpi;
        NewDPI = newDpi;
    }
}
