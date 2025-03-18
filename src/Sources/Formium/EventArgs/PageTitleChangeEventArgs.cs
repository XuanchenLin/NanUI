// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class PageTitleChangeEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public string Title { get; }

    public PageTitleChangeEventArgs(CefBrowser browser, string title)
    {
        Browser = browser;
        Title = title;
    }
}
