using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;


namespace NetDimension.NanUI.Browser;

class RenderProcessHandler : CefRenderProcessHandler
{
    internal MessageBridgeOnRenderSide MessageBridge { get; }
    public RenderProcessHandler()
    {

        MessageBridge = new MessageBridgeOnRenderSide();

        //TODO:Add internal MessageHandler
        MessageBridge.AddMessageHandler(new JavaScript.WindowBinding.InvokeWindowBindingFunctionHandler().RenderSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptObjectMapping.MapJavaScriptObjectHandler().RenderSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptEvaluation.EvaluateJavaScriptHandler().RenderSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptExecution.InvokeJavaScriptFunctionHandler().RenderSideMessageHandler);
        MessageBridge.AddMessageHandler(new JavaScript.JavaScriptProperties.JavaScriptPropertyHandler().RenderSideMessageHandler);


        var handlers = WinFormium.Runtime.Container.GetAllInstances<MessageHandlerWrapperBase>();

        foreach (var wrapper in handlers.Where(x => x.RenderSideMessageHandler != null))
        {
            MessageBridge.AddMessageHandler(wrapper.RenderSideMessageHandler);
        }

    }

    protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        MessageBridge.OnContextCreated(browser, frame, context);

        if (frame.IsMain)
        {
            frame.ExecuteJavaScript($"Formium.__setContextReady__();", frame.Url, 0);
        }

        frame.SendProcessMessage(CefProcessId.Browser, CefProcessMessage.Create(WinFormiumApp.ON_CONTEXT_CREATED));
    }

    protected override void OnWebKitInitialized()
    {
        var extensions = WinFormium.Runtime.Container.GetAllInstances<JavaScript.WindowBinding.JavaScriptWindowBindingObject>();

        foreach (var ext in extensions)
        {
            CefRuntime.RegisterExtension(ext.Name, ext.JavaScriptCode, ext.GetV8Handler());
        }
    }

    protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        MessageBridge.OnContextReleased(browser, frame, context);
    }

    protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        if (MessageBridge.OnBrowserSideMessage(browser, frame, sourceProcess, message))
        {
            return true;
        }
        return false;
    }
}
