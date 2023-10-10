// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class LifeSpanHandler : ILifeSpanHandler
{
    bool ILifeSpanHandler.DoClose(CefBrowser browser)
    {
        return DoClose(browser);
    }

    void ILifeSpanHandler.OnAfterCreated(CefBrowser browser)
    {
        OnAfterCreated(browser);
    }

    void ILifeSpanHandler.OnBeforeClose(CefBrowser browser)
    {
        OnBeforeClose(browser);
    }

    bool ILifeSpanHandler.OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        return OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess);
    }

    internal protected virtual bool DoClose(CefBrowser browser)
    {
        return false;
    }

    internal protected virtual void OnAfterCreated(CefBrowser browser)
    {
    }

    internal protected virtual void OnBeforeClose(CefBrowser browser)
    {
    }

    internal protected virtual bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        return false;
    }
}
