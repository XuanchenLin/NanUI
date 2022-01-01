using NetDimension.NanUI.Browser.MessagePipe;

namespace NetDimension.NanUI.JavaScript.WindowBinding;

class InvokeWindowBindingFunctionHandler : MessageHandlerWrapperBase
{
    public static string INVOKE_WINDOW_BINDING_FUNCTION = FormiumMessageBridge.MESSAGE_PREFIX + "InvokeWindowBindingFunction";
    public static string INVOKE_WINDOW_BINDING_ASYNC_FUNCTION = FormiumMessageBridge.MESSAGE_PREFIX + "InvokeWindowBindingAsyncFunction";
    public override MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public override MessageHandlerOnRenderSide RenderSideMessageHandler { get; }

    public InvokeWindowBindingFunctionHandler()
    {
        BrowserSideMessageHandler = new InvokeWindowBindingFunctionOnBrowserSide(this);
        RenderSideMessageHandler = new InvokeWindowBindingFunctionOnRenderSide(this);
    }
}
