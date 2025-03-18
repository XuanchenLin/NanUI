// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class CanDownloadEventArgs : EventArgs
{


    public CanDownloadEventArgs(CefBrowser browser, string url, string requestMethod)
    {
        Browser = browser;
        Url = url;
        RequestMethod = requestMethod;
    }

    public CefBrowser Browser { get; }
    public string Url { get; }
    public string RequestMethod { get; }

    public bool AllowDownload { get; set; } = true;
}
