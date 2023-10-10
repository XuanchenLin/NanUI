// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.EmbeddedBrowser;
internal class EmbeddedlBrowserClient : CefClient
{
    public EmbeddedBrowserWindow BrowserWindow { get; }

    public EmbeddedlBrowserClient(EmbeddedBrowserWindow browserWindow)
    {
        BrowserWindow = browserWindow;
    }


    protected override CefLifeSpanHandler? GetLifeSpanHandler()
    {
        return new EmbeddedBrowserLifeSpanHandler(this);
    }

    protected override CefDisplayHandler? GetDisplayHandler()
    {
        return new EmbeddedBrowserDisplayHandler(this);
    }

    protected override CefDownloadHandler? GetDownloadHandler()
    {
        return new EmbeddedBrowserDownloadHandler(this);
    }

    protected override CefContextMenuHandler? GetContextMenuHandler()
    {
        return new EmbeddedBrowserContextMenuHandler(this);
    }
}
