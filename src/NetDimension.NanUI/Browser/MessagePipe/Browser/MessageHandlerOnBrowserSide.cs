using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public abstract class MessageHandlerOnBrowserSide
{
    internal protected MessageBridgeOnBrowserSide Bridge { get; internal set; }
    internal List<Func<BridgeMessageRequest, BridgeMessageResponse>> Handlers { get; } = new List<Func<BridgeMessageRequest, BridgeMessageResponse>>();


    protected MessageHandlerWrapperBase MessageHandlerWrapper { get; }
    internal protected Formium Owner { get; internal set; }

    public MessageHandlerOnBrowserSide(MessageHandlerWrapperBase messageHandlerWrapper)
    {
        MessageHandlerWrapper = messageHandlerWrapper;
    }

    public void SendBridgeMessage(CefFrame frame, BridgeMessage message)
    {
        Bridge.SendBridgeMessage(frame, message);
    }

    public void SendBridgeMessage(CefProcessId side, CefFrame frame, BridgeMessage message)
    {
        FormiumMessageBridge.SendBridgeMessage(side, frame, message);
    }

    protected void RegisterMessageHandler(Func<BridgeMessageRequest, BridgeMessageResponse> handler)
    {
        Handlers.Add(handler);
    }

    public abstract void OnMessageReceived(string message, CefFrame frame, string arguments);
    public abstract void OnBeforeBrowse(CefBrowser browser, CefFrame frame);
    public abstract void OnRenderProcessTerminated(CefBrowser browser);
    public abstract void OnBeforeClose(CefBrowser browser);


}
