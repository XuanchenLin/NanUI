// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class PageLoadStartEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefTransitionType TransitionType { get; }

    public PageLoadStartEventArgs(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
    {
        Browser = browser;
        Frame = frame;
        TransitionType = transitionType;
    }
}
