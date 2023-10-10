// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal abstract class MessageBridgeHandler
{
    internal Dictionary<string, Func<MessageBridgeRequest, MessageBridgeResponse>> BridgeRequestHandlers { get; } = new();

    internal Dictionary<string, Action<CefBrowser, CefFrame, CefProcessId, BridgeMessage>> BridgeMessageHandlers { get; } = new();

    protected MessageBridge Bridge { get; }

    protected ProcessType Side => Bridge.Side;

    protected void RegisterRequestHandler(string name, Func<MessageBridgeRequest, MessageBridgeResponse> handler)
    {
        BridgeRequestHandlers[name] = handler;
    }

    protected void RegisterMessageHandler(string name, Action<CefBrowser, CefFrame, CefProcessId, BridgeMessage> handler)
    {
        BridgeMessageHandlers[name] = handler;
    }

    protected WinFormiumApp ApplicationContext => Bridge.ApplicationContext;

    public MessageBridgeHandler(MessageBridge bridge)
    {
        Bridge = bridge;
    }

    public void SendMessageToLocal(CefFrame frame, BridgeMessage message)
    {
        MessageBridge.SendMessageToLocal(frame, message);
    }

    public void SendMessageToRemote(CefFrame frame, BridgeMessage message)
    {
        MessageBridge.SendMessageToRemote(frame, message);
    }

    public MessageBridgeResponse ExecuteRequest(MessageBridgeRequest request)
    {
        return MessageBridge.ExecuteRequest(request);
    }

    public Task<MessageBridgeResponse> ExecuteRequestAsync(MessageBridgeRequest request)
    {
        return MessageBridge.ExecuteRequestAsync(request);
    }

    public abstract void OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect);
    public abstract void OnBeforeClose(CefBrowser browser);

    public abstract void OnRenderProcessTerminated(CefBrowser browser);

    public abstract void OnRemoteContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context);
    public abstract void OnRemoteContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context);
}
