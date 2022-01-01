using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

class EvaluateJavaScriptOnRenderSide : MessageHandlerOnRenderSide
{

    internal EvaluateJavaScriptHandler MessageHandler => (EvaluateJavaScriptHandler)this.MessageHandlerWrapper;


    public EvaluateJavaScriptOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
        : base(messageHandlerWrapper)
    {

    }

    #region Overrides
    public override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
        if (message == MessageHandler.EVALUATE_JS_MESSAGE)
        {
            CefRuntime.PostTask(CefThreadId.Renderer, new EvaluateJavaScriptTask(this, frame, arguments));
        }
    }


    #endregion

}
