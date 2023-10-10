// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : IDownloadHandler
{
    #region interface
    bool IDownloadHandler.CanDownload(CefBrowser browser, string url, string requestMethod)
    {
        var retval = DownloadHandler?.CanDownload(browser, url, requestMethod) ?? false;

        return retval ? retval : CanDownloadCore(browser, url, requestMethod);
    }

    void IDownloadHandler.OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
        DownloadHandler?.OnBeforeDownload(browser, downloadItem, suggestedName, callback);

        OnBeforeDownloadCore(browser, downloadItem, suggestedName, callback);
    }

    void IDownloadHandler.OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
        DownloadHandler?.OnDownloadUpdated(browser, downloadItem, callback);

        OnDownloadUpdatedCore(browser, downloadItem, callback);
    }
    #endregion

    #region implements
    private bool CanDownloadCore(CefBrowser browser, string url, string requestMethod)
    {
        var args = new CanDownloadEventArgs(browser, url, requestMethod);

        InvokeOnUIThread(OnCanDownload, args);

        return args.AllowDownload;
    }

    private void OnBeforeDownloadCore(CefBrowser browser, CefDownloadItem item, string suggestedName, CefBeforeDownloadCallback callback)
    {
        var args = new BeforeDownloadEventArgs(browser,item, suggestedName, callback);

        InvokeOnUIThread(OnBeforeDownload, args);
    }

    private void OnDownloadUpdatedCore(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
        var args = new DownloadUpdatedEventArgs(browser, downloadItem, callback);

        InvokeOnUIThread(OnDownloadUpdated, args);
    }
    #endregion

}
