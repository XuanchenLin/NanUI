// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium;
public partial class Formium
{
    /// <summary>
    /// Gets the window SafeHWND that the form is bound to.
    /// </summary>
    internal protected IntPtr WindowHandle { get; private set; }

    /// <summary>
    /// Gets the window SafeHWND of the browser.
    /// </summary>
    internal protected IntPtr BrowserHandle { get; private set; }

    /// <summary>
    /// Gets the window handle of the form's owner.
    /// </summary>
    internal protected IntPtr? OwnerHandle { get; private set; }

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance.
    /// </summary>
    protected IServiceProvider Services => ApplicationContext.Services;

    /// <summary>
    /// Gets the <see cref="CefBrowser"/> instance.
    /// </summary>
    internal protected CefBrowser? Browser => WebView.Browser;

    /// <summary>
    /// Gets the <see cref="CefBrowserHost"/> instance.
    /// </summary>
    internal protected CefBrowserHost? BrowserHost => WebView.BrowserHost;

    protected virtual bool DisableAboutMenu => false;

    /// <summary>
    /// Gets or sets the system menu will show when right clicking in dragable regions.
    /// </summary>
    protected bool AllowSystemMenu { get => CurrentFormStyle.AllowSystemMenu; set => CurrentFormStyle.AllowSystemMenu = value; }

    /// <summary>
    /// Gets or sets the url of the page to be loaded.
    /// </summary>
    public string Url
    {
        get => WebView.Url;
        set => WebView.Url = value;
    }

    /// <summary>
    /// Resizes the WebView to fit the current window size.
    /// </summary>
    internal protected void ResizeWebView()
    {
        if (HostWindow == null || WindowHandle == (nint)0) return;


        if (HostWindow.WindowState != FormWindowState.Minimized)
        {
            GetClientRect(WindowHandle, out var rect);
            WebView.ResizeWebView(rect.Width, rect.Height);
        }

        if (WindowState == FormiumWindowState.Minimized || Visible == false)
        {
            WebView.WasHidden(true);
        }
        else
        {
            WebView.WasHidden(false);
        }
    }

    /// <summary>
    /// Processes Windows messages.
    /// </summary>
    /// <param name="m">The Windows <see cref="Message"/> to process.</param>
    /// <returns>
    /// Returns true if the message was handled, false otherwise.
    /// </returns>
    protected virtual bool WndProc(ref Message m)
    {
        return false;
    }

    /// <summary>
    /// Processes messages that called by DefWindowMessage.
    /// </summary>
    /// <param name="m">
    /// The Windows <see cref="Message"/> to process.
    /// </param>
    /// <returns>
    /// Returns true if the message was handled, false otherwise.
    /// </returns>
    protected virtual bool DefWndProc(ref Message m)
    {
        return false;
    }

    /// <summary>
    /// Processes messages of browser window.
    /// </summary>
    /// <param name="m">
    /// The Windows <see cref="Message"/> to process.
    /// </param>
    /// <returns>Returns true if the message was handled, false otherwise.</returns>
    protected virtual bool BrowserWndProc(ref Message m)
    {
        return false;
    }

    /// <summary>
    /// Called before the browser instance is created, allowing for customization of the browser settings.
    /// </summary>
    /// <param name="settings">
    /// A <see cref="CefBrowserSettings"/> instance that can be used to configure the browser.
    /// </param>
    protected virtual void CreateBrowser(CefBrowserSettings settings)
    {
    }

    /// <summary>
    /// Called before the host window is created, allowing for customization of the window.
    /// </summary>
    /// <param name="windowStyle">
    /// A <see cref="WindowStyleBuilder"/> instance that can be used to configure style of the host window.
    /// </param>
    /// <returns>
    /// A <see cref="FormStyle"/> value that indicates the style of the host window.
    /// </returns>
    protected virtual FormStyle ConfigureWindowStyle(WindowStyleBuilder windowStyle)
    {
        return windowStyle.UseSystemForm();
    }

    /// <summary>
    /// Called when the host window instance is created.
    /// </summary>
    /// <param name="form">
    /// The host window instance.
    /// </param>
    protected virtual void CreateWindow(Form form)
    {
    }


    /// <summary>
    /// Called when a context of browser instance is created.
    /// </summary>
    /// <param name="browser">
    /// The browser instance.
    /// </param>
    /// <param name="frame">
    /// The frame that owns the context.
    /// </param>
    protected virtual void ContextCreated(CefBrowser browser, CefFrame frame)
    {
    }

    /// <summary>
    /// Called on the UI thread before a new popup browser is created. The
    /// <see cref="CefBrowser"/> and <see cref="CefFrame"/> values represent the source of the popup request.
    /// The <paramref name="targetUrl"/> and <paramref name="targetFrameName"/> values indicate where the popup
    /// browser should navigate and may be empty if not specified with the
    /// request. The <paramref name="targetDisposition"/> value indicates where the user intended
    /// to open the popup (e.g. current tab, new tab, etc). The <paramref name="userGesture"/>
    /// value will be true if the popup was opened via explicit user gesture (e.g.
    /// clicking a link) or false if the popup opened automatically (e.g. via the
    /// DomContentLoaded event). The <paramref name="popupFeatures"/> structure contains additional
    /// information about the requested popup window. To allow creation of the
    /// popup browser optionally modify <paramref name="windowInfo"/>, <paramref name="client"/>, <paramref name="settings"/> and
    /// <paramref name="noJavascriptAccess"/> and return false. To cancel creation of the popup
    /// browser return true. The <paramref name="client"/> and <paramref name="settings"/> values will default to
    /// the source browser's values. If the <paramref name="noJavascriptAccess"/> value is set to
    /// false the new browser will not be scriptable and may not be hosted in the
    /// same renderer process as the source browser. Any modifications to
    /// <paramref name="windowInfo"/> will be ignored if the parent browser is wrapped in a
    /// CefBrowserView. Popup browser creation will be canceled if the parent
    /// browser is destroyed before the popup browser creation completes
    /// (indicated by a call to OnAfterCreated for the popup browser). The
    /// |extra_info| parameter provides an opportunity to specify extra
    /// information specific to the created popup browser that will be passed to
    /// CefRenderProcessHandler::OnBrowserCreated() in the render process.
    /// </summary>
    /// <param name="browser">
    /// The browser instance that launched this popup.
    /// </param>
    /// <param name="frame">
    /// The HTML frame that launched this popup.
    /// </param>
    /// <param name="targetUrl">
    /// The URL of the popup content.
    /// </param>
    /// <param name="targetFrameName">
    /// The name of the target frame. This value will be empty if the target is not a named frame.
    /// </param>
    /// <param name="targetDisposition">
    /// The value indicates where the user intended to navigate the browser based on standard Chromium behaviors (e.g. current tab, new tab, etc).
    /// </param>
    /// <param name="userGesture">
    /// The value will be true if the browser navigated via explicit user gesture (e.g. clicking a link) or false if it navigated automatically (e.g. via the DomContentLoaded event).
    /// </param>
    /// <param name="popupFeatures">
    /// Structure contains additional information about the requested popup window
    /// </param>
    /// <param name="windowInfo">
    /// Window information
    /// </param>
    /// <param name="client">
    /// Set to the client for the new browser window. If left empty the url will be opened in the current browser window.
    /// </param>
    /// <param name="settings">
    /// Browser settings, defaults to source browsers
    /// </param>
    /// <param name="extraInfo">
    /// Set to the extra information that will be passed to new popup.
    /// </param>
    /// <param name="noJavascriptAccess">
    /// A value indicates whether the new browser window should be scriptable and in the same process as the source browser.
    /// </param>
    /// <returns>
    /// Returns true to cancel the navigation or false to allow the navigation to proceed.
    /// </returns>
    protected virtual bool BeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
    {
        return false;
    }

    /// <summary>
    /// Registers a synchronous request handler for the specified message.
    /// </summary>
    /// <param name="message">
    /// The message name.
    /// </param>
    /// <param name="handler">
    /// The request handler. You should return a value immediately from <seealso cref="JavaScriptValue"/>.
    /// </param>
    protected void RegisterJavaScriptRequestHandler(string message, Func<JavaScriptValue, JavaScriptValue> handler)
    {
        JavaScriptBrowserRequestHandlers[message] = handler;
    }

    /// <summary>
    /// Registers an asynchronous request handler for the specified message.
    /// </summary>
    /// <param name="message">
    /// The message name.
    /// </param>
    /// <param name="handler">
    /// The request handler. You can use <seealso cref="JavaScriptPromise"/> to resolve or reject the request later.
    /// </param>
    protected void RegisterJavaScriptRequestHandler(string message, Action<JavaScriptValue, JavaScriptPromise> handler)
    {
        JavaScriptBrowserRequestAsyncHandlers[message] = handler;
    }

    /// <summary>
    /// Registers a message handler for the specified message.
    /// </summary>
    /// <param name="message">
    /// The message name.
    /// </param>
    /// <param name="handler">
    /// The message handler. The <seealso cref="JavaScriptValue"/> is the data passed from the front end environment.
    /// </param>
    protected void RegisterJavaScriptMessagHandler(string message, Action<JavaScriptValue> handler)
    {
        JavaScriptBrowserMessageHandlers[message] = handler;
    }

    /// <summary>
    /// Remove all message handlers for the specified message.
    /// </summary>
    /// <param name="message">
    /// The message name.
    /// </param>
    protected void RegisterJavaScriptMessagHandler(string message)
    {
        JavaScriptBrowserMessageHandlers.Remove(message);
    }


}
