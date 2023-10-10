// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class BeforeBrowseEventArgs : EventArgs
{
    public BeforeBrowseEventArgs(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        Browser = browser;
        Frame = frame;
        Request = request;
        UserGesture = userGesture;
        IsRedirect = isRedirect;
    }

    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public CefRequest Request { get; }
    public bool UserGesture { get; }
    public bool IsRedirect { get; }

    public bool Handled { get; set; }
}
