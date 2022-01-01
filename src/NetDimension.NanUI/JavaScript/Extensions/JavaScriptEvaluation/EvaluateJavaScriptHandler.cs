using NetDimension.NanUI.Browser.MessagePipe;

namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

class EvaluateJavaScriptHandler : MessageHandlerWrapperBase
{
    public string EVALUATE_JS_MESSAGE => FormiumMessageBridge.MESSAGE_PREFIX + "EvaluateJavaScript";
    public string EVALUATE_JS_COMPLETED_MESSAGE => FormiumMessageBridge.MESSAGE_PREFIX + "EvaluateJavaScriptCompleted";

    public override MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public override MessageHandlerOnRenderSide RenderSideMessageHandler { get; }

    public EvaluateJavaScriptHandler()
    {
        BrowserSideMessageHandler = new EvaluateJavaScriptOnBrowserSide(this);
        RenderSideMessageHandler = new EvaluateJavaScriptOnRenderSide(this);
    }
}
