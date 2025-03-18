// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

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
