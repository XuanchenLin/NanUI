using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser;


internal sealed class FormiumWebView : IDisposable
{
    const string ABOUT_BLANK = "about:blank";

    private readonly CefBrowserSettings _settings;

    private string _startUrl;

    private Formium Owner { get; }

    internal IntPtr OwnerHandle { get; }

    internal Region DraggableRegion { get; set; }

    internal BrowserClient BrowserClient { get; private set; }

    internal CefBrowser Browser { get; private set; }

    internal MessageBridgeOnBrowserSide MessageBridge { get; private set; }

    internal IntPtr BrowserWindowHandle { get; private set; }

    internal CefBrowserHost BrowserHost => Browser?.GetHost();

    //internal MessageBridgeBrowserSide ProcessMessageBridge { get; private set; }

    //internal JavaScriptCommunicationBridge JSBridge { get; private set; }

    public bool IsReady
    {
        get;
        internal set;
    } = false;

    private FormiumWebView()
    {
    }

    public FormiumWebView(Formium formium, CefBrowserSettings settings = null, string startUrl = ABOUT_BLANK) : this()
    {
        Owner = formium;

        OwnerHandle = formium.HostWindowHandle;

        if (settings == null)
        {
            settings = WinFormium.DefaultBrowserSettings;

        }

        _settings = settings;

        _startUrl = startUrl;
    }

    internal void OnBrowserCreated(CefBrowser browser)
    {
        BrowserWindowHandle = browser.GetHost().GetWindowHandle();
        Browser = browser;

        MessageBridge = new MessageBridgeOnBrowserSide(Owner);


        //TODO:Add internal MessageHandler
        MessageBridge.AddMessageHandler(new JavaScript.WindowBinding.InvokeWindowBindingFunctionHandler().BrowserSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptObjectMapping.MapJavaScriptObjectHandler().BrowserSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptEvaluation.EvaluateJavaScriptHandler().BrowserSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptExecution.InvokeJavaScriptFunctionHandler().BrowserSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptProperties.JavaScriptPropertyHandler().BrowserSideMessageHandler);




        var handlers = WinFormium.Runtime.Container.GetAllInstances<MessageHandlerWrapperBase>();

        foreach (var wrapper in handlers.Where(x => x.BrowserSideMessageHandler != null))
        {
            MessageBridge.AddMessageHandler(wrapper.BrowserSideMessageHandler);
        }

        MessageBridge.BindHostForm(Owner);



        Owner.OnBrowserCreated();

        Browser.GetHost()?.WasResized();

        Browser.GetHost()?.SetFocus(true);


        IsReady = true;
    }


    internal void InvokeAsyncIfPossible(Action action)
    {
        var task = new Task(action);

        task.ContinueWith(r =>
        {
            switch (task.Status)
            {
                case TaskStatus.RanToCompletion:
                case TaskStatus.Canceled:
                    break;
                case TaskStatus.Faulted:
                    action.Invoke();
                    break;
            }
        }).Start();
    }

    internal void CreateBrowser(CefWindowInfo windowInfo)
    {
        if (BrowserClient == null)
        {
            BrowserClient = new BrowserClient(Owner);
        }

        CefBrowserHost.CreateBrowser(windowInfo, BrowserClient, _settings, _startUrl);
    }

    internal void CloseBrowser()
    {
        unsafe
        {
            if (Browser != null && typeof(CefBrowser).GetField("_self", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(Browser) is Pointer self && Pointer.Unbox(self) != null)
            {
                BrowserHost?.CloseBrowser(true);
                BrowserHost?.Dispose();
                Browser?.Dispose();
                Dispose();
            }
        }
    }

    public void Dispose()
    {
        Browser = null;
        GC.SuppressFinalize(this);
    }

}
