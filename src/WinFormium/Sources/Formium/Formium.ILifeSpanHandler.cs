// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium : ILifeSpanHandler
{

    #region interface
    void ILifeSpanHandler.OnAfterCreated(CefBrowser browser)
    {

        if (LifeSpanHandler != null)
        {
            LifeSpanHandler.OnAfterCreated(browser);
        }

        InvokeOnUIThread(() => BrowserCreatedCore(browser));

    }

    bool ILifeSpanHandler.DoClose(CefBrowser browser)
    {

        var retval = LifeSpanHandler?.DoClose(browser) ?? false;

        return retval ? retval : OnBrowserClosingCore(browser);
    }



    void ILifeSpanHandler.OnBeforeClose(CefBrowser browser)
    {

        if (LifeSpanHandler != null)
        {
            LifeSpanHandler.OnAfterCreated(browser);
        }

        OnBrowserClosedCore(browser);
    }

    bool ILifeSpanHandler.OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {

        if (LifeSpanHandler != null)
        {
            var retval = LifeSpanHandler?.OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess) ?? false;

            return retval;
        }

        var useEmbeddedBrowser = ApplicationContext.Properties.GetValue<bool>(nameof(AppBuilder.UseEmbeddedBrowser));

        if (!useEmbeddedBrowser)
        {
            var ps = new System.Diagnostics.ProcessStartInfo(targetUrl)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            System.Diagnostics.Process.Start(ps);

            return true;
        }

        return OnBeforePopupCore(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess);
    }
    #endregion

    #region implements
    private bool OnBeforePopupCore(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        return BeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess);
    }

    private bool OnBrowserClosingCore(CefBrowser browser)
    {
        var args = new ClosingEventArgs();

        InvokeOnUIThread(OnClosingCore, args);

        return args.Cancel;
    }

    private void OnBrowserClosedCore(CefBrowser browser)
    {
        InvokeOnUIThread(OnClosedCore);
    }
    #endregion
}
