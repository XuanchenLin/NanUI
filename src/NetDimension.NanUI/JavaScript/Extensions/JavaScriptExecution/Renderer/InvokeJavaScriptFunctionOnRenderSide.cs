using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

class InvokeJavaScriptFunctionOnRenderSide : MessageHandlerOnRenderSide
{

    internal InvokeJavaScriptFunctionHandler MessageHandler => (InvokeJavaScriptFunctionHandler)this.MessageHandlerWrapper;

    public InvokeJavaScriptFunctionOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
: base(messageHandlerWrapper)
    {

    }

    public override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
        if (message == InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION)
        {
            CefRuntime.PostTask(CefThreadId.Renderer, new InvokeJavaScriptFunctionTask(this, frame, arguments));
        }

        if (message == InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_PROMISE_FUNCTION)
        {
            CefRuntime.PostTask(CefThreadId.Renderer, new InvokeJavaScriptPromiseFunctionTask(this, frame, arguments));
        }
    }
}
