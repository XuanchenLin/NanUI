// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Browser;
internal class WebViewDownloadHandler : CefDownloadHandler
{
    public IDownloadHandler Handler { get; }

    public WebViewDownloadHandler(IDownloadHandler handler)
    {
        Handler = handler;
    }

    protected override bool CanDownload(CefBrowser browser, string url, string requestMethod)
    {
        return Handler.CanDownload(browser, url, requestMethod);
    }

    protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
        Handler.OnBeforeDownload(browser, downloadItem, suggestedName, callback);
    }

    protected override void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
        Handler.OnDownloadUpdated(browser, downloadItem, callback);
    }

}
