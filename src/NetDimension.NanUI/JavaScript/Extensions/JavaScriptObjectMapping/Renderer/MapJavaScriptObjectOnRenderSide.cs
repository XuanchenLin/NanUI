using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;

class MapJavaScriptObjectOnRenderSide : MessageHandlerOnRenderSide
{
    MapJavaScriptObjectHandler MessageHandler => (MapJavaScriptObjectHandler)this.MessageHandlerWrapper;
    public MapJavaScriptObjectOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
: base(messageHandlerWrapper)
    {

    }

    public override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        var msg = new BridgeMessage(MapJavaScriptObjectHandler.PREMAP_OBJECTS);
        FormiumMessageBridge.SendBridgeMessage(CefProcessId.Browser, frame, msg);
    }

    public override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
        if (message == MapJavaScriptObjectHandler.MAP_OBJECTS)
        {
            CefRuntime.PostTask(CefThreadId.Renderer, new MapObjectsTask(frame, arguments));
        }
    }
}
