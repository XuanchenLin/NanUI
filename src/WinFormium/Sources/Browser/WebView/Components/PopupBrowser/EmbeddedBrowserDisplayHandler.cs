// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Properties;

namespace WinFormium.Browser.EmbeddedBrowser;
internal class EmbeddedBrowserDisplayHandler : CefDisplayHandler
{
    public EmbeddedlBrowserClient BrowserClient { get; }

    public EmbeddedBrowserDisplayHandler(EmbeddedlBrowserClient browserClient)
    {
        BrowserClient = browserClient;
    }

    protected override void OnTitleChange(CefBrowser browser, string title)
    {
        BrowserClient.BrowserWindow.Text = $"{title} - {Messages.External_Browser_Title}";
    }

    protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
    {
        BrowserClient.BrowserWindow.Text = $"{Messages.External_Browser_Loading} - {Messages.External_Browser_Title}";
    }


    protected override void OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
    {
        var browserWindow = BrowserClient.BrowserWindow;

        if (browserWindow == null) return;

        if (fullscreen)
        {

            browserWindow.FormBorderStyle = FormBorderStyle.None;
            browserWindow.WindowState = FormWindowState.Maximized;
        }
        else
        {
            browserWindow.FormBorderStyle = FormBorderStyle.Sizable;
            browserWindow.WindowState = FormWindowState.Normal;
        }
    }
}
