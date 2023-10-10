// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class FramePageLoadEndEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public int HttpStatusCode { get; }

    public FramePageLoadEndEventArgs(CefBrowser browser, CefFrame frame, int httpStatusCode)
    {
        Browser = browser;
        Frame = frame;
        HttpStatusCode = httpStatusCode;
    }
}
