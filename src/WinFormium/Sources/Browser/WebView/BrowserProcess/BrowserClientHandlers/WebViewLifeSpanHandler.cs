// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewLifeSpanHandler : CefLifeSpanHandler
{
    public ILifeSpanHandler Handler { get; }

    public WebViewLifeSpanHandler(ILifeSpanHandler handler)
    {
        Handler = handler;
    }

    protected override void OnAfterCreated(CefBrowser browser)
    {
        Handler.OnAfterCreated(browser);
    }

    protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        return Handler.OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess);
    }

    protected override void OnBeforeClose(CefBrowser browser)
    {
        Handler.OnBeforeClose(browser);
    }

    protected override bool DoClose(CefBrowser browser)
    {
        return Handler.DoClose(browser);
    }

}
