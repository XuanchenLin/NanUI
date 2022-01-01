using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public sealed class MessageBridgeOnBrowserSide : FormiumMessageBridge
{
    public Formium Host { get; }
    internal JavaScriptPipeServer MessagePipe { get; }

    internal List<MessageHandlerOnBrowserSide> MessageHandlers { get; } = new List<MessageHandlerOnBrowserSide>();


    internal MessageBridgeOnBrowserSide(Formium host)
    {
        Host = host;

        MessagePipe = new JavaScriptPipeServer(this, GetServiceName(Host.Browser.Identifier), CancellationToken);
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



    internal bool OnRenderSideMessage(CefBrowser broser, CefFrame frame, CefProcessId processId, CefProcessMessage message)
    {
        if (message.Name == PROCESS_MESSAGE_BRIDGE_MESSAGE)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(message.Arguments.GetString(0)));

            var msg = JsonConvert.DeserializeObject<BridgeMessage>(json);


            foreach (var handler in MessageHandlers)
            {
                handler.OnMessageReceived(msg.Name, frame, msg.Data);
            }

            return true;
        }


        return false;
    }

    internal void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
    {

        ClearTasks(frame);

        foreach (var handler in MessageHandlers)
        {
            handler.OnBeforeBrowse(browser, frame);
        }


    }

    internal void OnBeforeClose(CefBrowser browser)
    {
        foreach (var handler in MessageHandlers)
        {
            handler.OnBeforeClose(browser);
        }

        foreach (var id in browser.GetFrameIdentifiers())
        {
            var frame = browser.GetFrame(id);

            ClearTasks(frame);
        }
    }

    private void ClearTasks(CefFrame frame)
    {
        JavaScript.JavaScriptObject.ReleaseObjects(frame);
        JavaScript.JavaScriptFunction.ReleaseTasks(frame);
        JavaScript.JavaScriptAsyncFunction.ReleaseFunctions(frame);
        JavaScript.JavaScriptSyncFunction.ReleaseFunctions(frame);
        JavaScript.JavaScriptProperty.ReleaseProps(frame);
    }


    public Formium Owner { get; private set; }

    internal void BindHostForm(Formium owner)
    {
        Owner = owner;

        foreach (var handler in MessageHandlers)
        {
            handler.Owner = owner;
        }
    }

    private void ClearAllTasks()
    {
        JavaScript.JavaScriptObject.ReleaseObjects();
        JavaScript.JavaScriptFunction.ReleaseTasks();
        JavaScript.JavaScriptAsyncFunction.ReleaseFunctions();
        JavaScript.JavaScriptSyncFunction.ReleaseFunctions();
        JavaScript.JavaScriptProperty.ReleaseProps();
    }

    internal void OnRenderProcessTerminated(CefBrowser browser)
    {
        foreach (var handler in MessageHandlers)
        {
            handler.OnRenderProcessTerminated(browser);
        }

        ClearAllTasks();

    }



    public void SendBridgeMessage(CefFrame frame, BridgeMessage message)
    {
        SendBridgeMessage(CefProcessId.Renderer, frame, message);
    }

    public void AddMessageHandler(MessageHandlerOnBrowserSide handler)
    {
        handler.Bridge = this;
        MessageHandlers.Add(handler);
    }

    public void RemoveMessageHandler(MessageHandlerOnBrowserSide handler)
    {
        if (MessageHandlers.Contains(handler))
        {
            MessageHandlers.Remove(handler);
        }
    }

}
