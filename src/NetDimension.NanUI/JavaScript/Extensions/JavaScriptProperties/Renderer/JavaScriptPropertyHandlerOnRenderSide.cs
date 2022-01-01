using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptProperties;

class JavaScriptPropertyHandlerOnRenderSide : MessageHandlerOnRenderSide
{
    internal JavaScriptPropertyHandler MessageHandler => (JavaScriptPropertyHandler)this.MessageHandlerWrapper;

    public JavaScriptPropertyHandlerOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
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
    }


}
