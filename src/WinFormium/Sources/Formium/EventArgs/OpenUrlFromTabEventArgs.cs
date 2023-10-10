// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class OpenUrlFromTabEventArgs : EventArgs
{
    public OpenUrlFromTabEventArgs(CefBrowser browser, CefFrame frame, string targetUrl, CefWindowOpenDisposition targetDisposition, bool userGesture)
    {
        TargetUrl = targetUrl;
        TargetDisposition = targetDisposition;
        UserGesture = userGesture;
    }

    public string TargetUrl { get; }
    public CefWindowOpenDisposition TargetDisposition { get; }
    public bool UserGesture { get; }

    public bool Cancel { get; set; } = false;
}
