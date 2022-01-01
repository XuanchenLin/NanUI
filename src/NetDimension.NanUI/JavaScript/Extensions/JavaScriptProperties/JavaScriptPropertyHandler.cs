using NetDimension.NanUI.Browser.MessagePipe;

namespace NetDimension.NanUI.JavaScript.JavaScriptProperties;

class JavaScriptPropertyHandler : MessageHandlerWrapperBase
{
    public static string OBJECT_GET_PROPERTY_VALUE = FormiumMessageBridge.MESSAGE_PREFIX + "ObjectGetPropertyValue";
    public static string OBJECT_SET_PROPERTY_VALUE = FormiumMessageBridge.MESSAGE_PREFIX + "ObjectSetPropertyValue";
    public override MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public override MessageHandlerOnRenderSide RenderSideMessageHandler { get; }

    public JavaScriptPropertyHandler()
    {
        BrowserSideMessageHandler = new JavaScriptPropertyHandlerOnBrowserSide(this);
        RenderSideMessageHandler = new JavaScriptPropertyHandlerOnRenderSide(this);
    }

}
