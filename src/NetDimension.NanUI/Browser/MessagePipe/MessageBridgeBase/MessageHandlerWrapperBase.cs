namespace NetDimension.NanUI.Browser.MessagePipe;

public abstract class MessageHandlerWrapperBase
{
    public abstract MessageHandlerOnBrowserSide BrowserSideMessageHandler { get; }
    public abstract MessageHandlerOnRenderSide RenderSideMessageHandler { get; }
}
