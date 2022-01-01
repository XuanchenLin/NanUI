using NetDimension.NanUI.Browser.MessagePipe;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

class InvokeJavaScriptFunctionHandler : MessageHandlerWrapperBase
{
    public static string INVOKE_RENDER_SIDE_FUNCTION = FormiumMessageBridge.MESSAGE_PREFIX + "InvokeRenderSideFunction";
    public static string INVOKE_RENDER_SIDE_PROMISE_FUNCTION = FormiumMessageBridge.MESSAGE_PREFIX + "InvokeRenderSidePromiseFunction";


    public override MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public override MessageHandlerOnRenderSide RenderSideMessageHandler { get; }

    public InvokeJavaScriptFunctionHandler()
    {
        BrowserSideMessageHandler = new InvokeJavaScriptFunctionOnBrowserSide(this);
        RenderSideMessageHandler = new InvokeJavaScriptFunctionOnRenderSide(this);
    }
}
