// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.EmbeddedBrowser;
internal class EmbeddedBrowserLifeSpanHandler : CefLifeSpanHandler
{
    public EmbeddedBrowserLifeSpanHandler(EmbeddedlBrowserClient browserClient)
    {
        BrowserClient = browserClient;
    }

    public EmbeddedlBrowserClient BrowserClient { get; }

    protected override void OnAfterCreated(CefBrowser browser)
    {
        BrowserClient.BrowserWindow.BrowserWindowHandle = browser.GetHost().GetWindowHandle();

        BrowserClient.BrowserWindow.Browser = browser;

        var window = BrowserClient.BrowserWindow;

        window.SizeChanged += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
        window.ResizeBegin += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
        window.ResizeEnd += (_, _) => browser?.GetHost()?.WasResized();
        window.Move += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
    }

    protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        var bounds = new Rectangle();

        var window = BrowserClient.BrowserWindow;

        User32.GetWindowRect(window.Handle, out var rect);

        if (popupFeatures.X.HasValue)
        {
            bounds.X = popupFeatures.X.Value;
        }


        if (popupFeatures.Y.HasValue)
        {
            bounds.Y = popupFeatures.Y.Value;
        }

        if (popupFeatures.Width.HasValue)
        {
            bounds.Width = popupFeatures.Width.Value;
        }
        else
        {
            bounds.Width = rect.Width;
        }

        if (popupFeatures.Height.HasValue)
        {
            bounds.Height = popupFeatures.Height.Value;
        }
        else
        {
            bounds.Height = rect.Height;
        }



        var browserWindow = new EmbeddedBrowserWindow();

        browserWindow.Location = bounds.Location;
        browserWindow.Size = bounds.Size;

        client = new EmbeddedlBrowserClient(browserWindow);

        browserWindow.Show();


        windowInfo.SetAsChild(browserWindow.Handle, new CefRectangle(0, 0, browserWindow.ClientRectangle.Width, browserWindow.ClientRectangle.Height));



        return false;
    }

    protected override void OnBeforeClose(CefBrowser browser)
    {
        base.OnBeforeClose(browser);

        //BrowserClient.BrowserWindow.Close();
    }

    protected override bool DoClose(CefBrowser browser)
    {
        return base.DoClose(browser);
    }
}
