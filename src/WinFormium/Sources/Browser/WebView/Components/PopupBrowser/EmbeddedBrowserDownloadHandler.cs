// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.EmbeddedBrowser;
internal class EmbeddedBrowserDownloadHandler : CefDownloadHandler
{
    public EmbeddedlBrowserClient BrowserClient { get; }

    public EmbeddedBrowserDownloadHandler(EmbeddedlBrowserClient browserClient)
    {
        BrowserClient = browserClient;
    }

    protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
        callback.Continue(suggestedName, true);
    }
}
