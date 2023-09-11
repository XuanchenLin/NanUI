using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public abstract class MessageHandlerOnRenderSide
{
    internal protected MessageBridgeOnRenderSide Bridge { get; set; }

    List<Func<BridgeMessageRequest, BridgeMessageResponse>> Handlers { get; } = new List<Func<BridgeMessageRequest, BridgeMessageResponse>>();

    protected MessageHandlerWrapperBase MessageHandlerWrapper { get; }


    public MessageHandlerOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
    {
        MessageHandlerWrapper = messageHandlerWrapper;
    }

    public BridgeMessageResponse ExecuteRequest(BridgeMessageRequest request)
    {
        return FormiumMessageBridge.ExecuteRequest(request);
    }
    public Task<BridgeMessageResponse> ExecuteRequestAsync(BridgeMessageRequest request)
    {
        return FormiumMessageBridge.ExecuteRequestAsync(request);
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
    public abstract void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context);
    public abstract void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context);
}
