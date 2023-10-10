// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class StatusMessageChangeEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public string Message { get; }

    public StatusMessageChangeEventArgs(CefBrowser browser, string value)
    {
        Browser = browser;
        Message = value;
    }
}
