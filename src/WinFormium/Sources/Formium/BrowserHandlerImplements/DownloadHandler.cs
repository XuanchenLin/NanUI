// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class DownloadHandler : IDownloadHandler
{
    bool IDownloadHandler.CanDownload(CefBrowser browser, string url, string requestMethod)
    {
        return CanDownload(browser, url, requestMethod);
    }

    void IDownloadHandler.OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
        OnBeforeDownload(browser, downloadItem, suggestedName, callback);
    }

    void IDownloadHandler.OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
        OnDownloadUpdated(browser, downloadItem, callback);
    }

    internal protected virtual bool CanDownload(CefBrowser browser, string url, string requestMethod)
    {
        return false;
    }

    internal protected virtual void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
    }

    internal protected virtual void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
    }
}
