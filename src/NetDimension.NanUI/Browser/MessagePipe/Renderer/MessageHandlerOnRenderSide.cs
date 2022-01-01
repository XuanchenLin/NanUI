using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public abstract class MessageHandlerOnRenderSide
{
    internal protected MessageBridgeOnRenderSide Bridge { get; set; }

    List<Func<MessageRequest, MessageResponse>> Handlers { get; } = new List<Func<MessageRequest, MessageResponse>>();

    protected MessageHandlerWrapperBase MessageHandlerWrapper { get; }


    public MessageHandlerOnRenderSide(MessageHandlerWrapperBase messageHandlerWrapper)
    {
        MessageHandlerWrapper = messageHandlerWrapper;
    }

    public MessageResponse ExecuteRequest(MessageRequest request)
    {
        return FormiumMessageBridge.ExecuteRequest(request);
    }
    public Task<MessageResponse> ExecuteRequestAsync(MessageRequest request)
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


    protected void RegisterMessageHandler(Func<MessageRequest, MessageResponse> handler)
    {
        Handlers.Add(handler);
    }


    public abstract void OnMessageReceived(string message, CefFrame frame, string arguments);
    public abstract void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context);
    public abstract void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context);
}
