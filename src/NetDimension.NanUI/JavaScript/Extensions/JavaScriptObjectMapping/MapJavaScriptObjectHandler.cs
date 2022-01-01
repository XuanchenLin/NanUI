using NetDimension.NanUI.Browser.MessagePipe;

namespace NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;

class MapJavaScriptObjectHandler : MessageHandlerWrapperBase
{
    public static string PREMAP_OBJECTS = FormiumMessageBridge.MESSAGE_PREFIX + "Pre_Map_Objects";
    public static string MAP_OBJECTS = FormiumMessageBridge.MESSAGE_PREFIX + "Map_Objects";

    public override MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public override MessageHandlerOnRenderSide RenderSideMessageHandler { get; }

    public MapJavaScriptObjectHandler()
    {
        BrowserSideMessageHandler = new MapJavaScriptObjectOnBrowserSide(this);
        RenderSideMessageHandler = new MapJavaScriptObjectOnRenderSide(this);
    }

}
