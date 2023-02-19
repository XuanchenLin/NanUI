using NetDimension.NanUI.JavaScript.Renderer;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public sealed class MessageBridgeOnRenderSide : FormiumMessageBridge
{

    internal List<MessageHandlerOnRenderSide> MessageHandlers { get; } = new List<MessageHandlerOnRenderSide>();





    internal bool OnBrowserSideMessage(CefBrowser broser, CefFrame frame, CefProcessId processId, CefProcessMessage message)
    {

        if (message.Name == PROCESS_MESSAGE_BRIDGE_MESSAGE)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(message.Arguments.GetString(0)));

            var msg = JsonSerializer.Deserialize<BridgeMessage>(json);


            foreach (var handler in MessageHandlers)
            {
                handler.OnMessageReceived(msg.Name, frame, msg.Data);
            }

            return true;
        }

        return false;
    }

    internal void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        JavaScriptObjectRepositoryOnRenderSide.ReleaseStoreByContext(context);


        foreach (var handler in MessageHandlers)
        {
            handler.OnContextCreated(browser, frame, context);
        }
    }

    internal void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        foreach (var handler in MessageHandlers)
        {
            handler.OnContextCreated(browser, frame, context);
        }

        JavaScriptObjectRepositoryOnRenderSide.ReleaseStoreByContext(context);
    }

    internal object GetInstance(Type handler)
    {
        var entry = MessageHandlers.Find(x => x.GetType() == handler);

        return entry;
    }

    internal TInstance GetInstance<TInstance>()
    {
        return (TInstance)GetInstance(typeof(TInstance));
    }




    public void SendBridgeMessage(CefFrame frame, BridgeMessage message)
    {
        SendBridgeMessage(CefProcessId.Browser, frame, message);
    }

    public void AddMessageHandler(MessageHandlerOnRenderSide handler)
    {
        handler.Bridge = this;
        MessageHandlers.Add(handler);
    }

    public void RemoveMessageHandler(MessageHandlerOnRenderSide handler)
    {
        if (MessageHandlers.Contains(handler))
        {
            MessageHandlers.Remove(handler);
        }
    }

}
