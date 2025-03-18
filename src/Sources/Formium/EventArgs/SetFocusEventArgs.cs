// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class SetFocusEventArgs
{
    public SetFocusEventArgs(CefBrowser browser, CefFocusSource source)
    {
        Browser = browser;
        Source = source;
    }

    public CefBrowser Browser { get; }
    public CefFocusSource Source { get; }
    public bool Handled { get; set; }
}
