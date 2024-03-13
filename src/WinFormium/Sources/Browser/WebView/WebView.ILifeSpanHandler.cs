// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Browser.EmbeddedBrowser;

namespace WinFormium.Browser;
internal partial class WebView : ILifeSpanHandler
{
    #region interface
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
        var retval = WebViewHost.LifeSpanHandler?.OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess) ?? false;

        if (!retval)
        {
            OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref extraInfo, ref noJavascriptAccess);

            return false;
        }
        else
        {
            return retval;
        }
    }
    #endregion

    #region implements
    private void OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        var bounds = new Rectangle();

        User32.WINDOWPLACEMENT placement = new();

        User32.GetWindowPlacement(WindowHandle, ref placement);

        var rect = placement.rcNormalPosition;

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

        //System.Diagnostics.Debug.WriteLine($"[Thread] -> {Thread.CurrentThread.ManagedThreadId}");

        var browserWindow = new EmbeddedBrowserWindow();

        client = new EmbeddedlBrowserClient(browserWindow);


        browserWindow.Location = bounds.Location;
        browserWindow.Size = bounds.Size;

        windowInfo.SetAsChild(browserWindow.Handle, new CefRectangle(0, 0, browserWindow.ClientRectangle.Width, browserWindow.ClientRectangle.Height));

        browserWindow.Show();
    }

    private void OnAfterCreated(CefBrowser browser)
    {

        Browser = browser;

        if (BrowserHost == null) throw new NullReferenceException("BrowserHost is null");

        IsBrowserInitialized = true;

        MessageDispatcher.RegisterMessageHandler(WinFormiumMessage.WFM_ON_CONTEXT_CREATED, args => ContextCreated(args.Browser, args.Frame));

        MessageBridge = new MessageBridge(WebViewHost.ApplicationContext, browser, ProcessType.Main, MessageDispatcher);


        BrowserHandle = BrowserHost.GetWindowHandle();

        BrowserHost.NotifyMoveOrResizeStarted();

        BrowserHost.WasResized();

        WebViewHost.LifeSpanHandler?.OnAfterCreated(browser);

        MessageBridge.RegisterMessageBridgeHandler(JavaScriptEngine = new JavaScriptEngineBridge(MessageBridge));
        MessageBridge.RegisterMessageBridgeHandler(JavaScriptObjectMapping = new JavaScriptObjectMappingBridge(MessageBridge));
        MessageBridge.RegisterMessageBridgeHandler(JavaScriptWindowBindingObject = new JavaScriptWindowBindingObjectBridge(MessageBridge, WebViewHost.Formium));




    }

    private bool DoClose(CefBrowser browser)
    {
        var cancel = WebViewHost.LifeSpanHandler?.DoClose(browser) ?? false;

        if (!cancel)
        {
            CanClose = true;

            WebViewHost.Close();
        }

        return true;
    }

    private void OnBeforeClose(CefBrowser browser)
    {

        MessageBridge?.OnBeforeClose(browser);

        WebViewHost.LifeSpanHandler?.OnBeforeClose(browser);

        MessageBridge?.Dispose();
    }

    #endregion
}
