// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class TooltipEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public string Text { get; }

    public bool Handled { get; set; }

    public TooltipEventArgs(CefBrowser browser, string text)
    {
        Browser = browser;
        Text = text;
    }
}
