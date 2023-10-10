// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal sealed class MessageBridge : IDisposable
{
    List<MessageBridgeHandler> MessageBridgeHandlers { get; } = new();

    public CefBrowser Browser { get; }

    public ProcessType Side { get; }

    public WinFormiumApp ApplicationContext { get; }

    public ProcessMessageDispatcher MessageDispatcher { get; }
    internal MessageBridgePipeServer? Pipe { get; }

    internal static string GetPipeName(int browserId)
    {
        int processId;

        if (WinFormiumApp.Current!.ProcessType == ProcessType.Main)
        {
            processId = System.Diagnostics.Process.GetCurrentProcess().Id;
        }
        else
        {
            processId = WinFormiumApp.Current!.BrowserProcessId;
        }

        return $"WinFormium-MessageBridgeProxy-{processId}-{browserId}";
    }

    public MessageBridge(WinFormiumApp app, CefBrowser browser, ProcessType side, ProcessMessageDispatcher messageDispatcher)
    {
        ApplicationContext = app;
        Browser = browser;
        Side = side;
        MessageDispatcher = messageDispatcher;
        MessageDispatcher.RegisterMessageHandler(WinFormiumMessage.WFM_MESSAGE_BRIDGE_MSG, OnMessageBridgeCommunicateCore);

        if (side == ProcessType.Main)
        {
            Pipe = new MessageBridgePipeServer(this, GetPipeName(browser.Identifier));
        }
    }

    public void RegisterMessageBridgeHandler<T>() where T : MessageBridgeHandler, new()
    {
        var type = typeof(T);

        var handler = Activator.CreateInstance(type, this) as MessageBridgeHandler;

        if (handler == null) throw new TypeInitializationException(type.FullName, null);

        MessageBridgeHandlers.Add(handler);
    }

    public void RegisterMessageBridgeHandler(MessageBridgeHandler handler)
    {
        MessageBridgeHandlers.Add(handler);
    }

    private void OnMessageBridgeCommunicateCore(ProcessMessageReceivedEventArgs args)
    {
        var msgs = args.Message.Arguments!;

        var buff = msgs.GetBinary(0).ToArray();

        var json = Encoding.Unicode.GetString(buff);

        var message = BridgeMessage.FromJson(json);

        if (message != null)
        {
            var handlers = MessageBridgeHandlers.SelectMany(x => x.BridgeMessageHandlers).ToDictionary(k => k.Key, v => v.Value);

            if (handlers.TryGetValue(message.Name, out var handler))
            {
                handler.Invoke(args.Browser, args.Frame, args.ProcessId, message);
            }
        }
    }

    internal static void SendMessageToLocal(CefFrame frame, BridgeMessage message)
    {
        SendMessage(CefProcessId.Browser, frame, message);
    }

    internal static void SendMessageToRemote(CefFrame frame, BridgeMessage message)
    {
        SendMessage(CefProcessId.Renderer, frame, message);
    }

    internal static void SendMessage(CefProcessId processId, CefFrame frame, BridgeMessage message)
    {
        var msg = CefProcessMessage.Create(WinFormiumMessage.WFM_MESSAGE_BRIDGE_MSG);
        var json = message.ToJson();
        var buff = Encoding.Unicode.GetBytes(json);
        msg.Arguments!.SetBinary(0, CefBinaryValue.Create(buff));

        frame.SendProcessMessage(processId,msg);
    }

    internal static async Task<MessageBridgeResponse> ExecuteRequestAsync(MessageBridgeRequest request)
    {
        var client = new MessageBridgePipeClient( GetPipeName(request.BrowserId));

        return await client.RequestAsync(request);
    }

    internal static MessageBridgeResponse ExecuteRequest(MessageBridgeRequest request)
    {
        return ExecuteRequestAsync(request).GetAwaiter().GetResult();
    }

    internal MessageBridgeResponse? OnMessageBridgeRequestReviced(MessageBridgeRequest request)
    {
        var MessageRequestHandlers = MessageBridgeHandlers.SelectMany(x => x.BridgeRequestHandlers).ToDictionary(k => k.Key, v => v.Value);

        if (MessageRequestHandlers.TryGetValue(request.Name, out var handler))
        {
            return handler.Invoke(request);
        }

        return null;
    }

    public void Dispose()
    {
        Pipe?.Dispose();
    }
    internal void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        MessageBridgeHandlers.ForEach(handler => handler.OnRemoteContextCreated(browser, frame, context));
    }

    internal void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        MessageBridgeHandlers.ForEach(handler=>handler.OnRemoteContextReleased(browser, frame, context));
    }

    internal void OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        MessageBridgeHandlers.ForEach(handler => handler.OnBeforeBrowse(browser, frame, request, userGesture, isRedirect));
    }

    internal void OnBeforeClose(CefBrowser browser)
    {
        MessageBridgeHandlers.ForEach(handler => handler.OnBeforeClose(browser));
    }

    internal void OnRenderProcessTerminated(CefBrowser browser)
    {
        MessageBridgeHandlers.ForEach(handler => handler.OnRenderProcessTerminated(browser));
    }
}
