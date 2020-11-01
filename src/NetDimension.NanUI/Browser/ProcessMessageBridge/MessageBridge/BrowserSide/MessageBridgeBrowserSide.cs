using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    using static NetDimension.NanUI.Browser.MessageBridge;

    public sealed class MessageBridgeBrowserSide
    {
        public Formium Owner { get; }
        internal MessageBridgeNamedPipeServer MessagePipe { get; }

        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        internal List<Func<MessageBridgeRequest, MessageBridgeResponse>> JavascriptRequestHandlers
        {
            get
            {
                return MessageHandlers.SelectMany(x => x.JavascriptRequestHandlers).ToList();
            }
        }

        //internal Dictionary<string, Action<JavascriptBridgeBrowserSide, CefFrame, JavascriptArrayValue>> ProcessMessageHandlers { get; } = new Dictionary<string, Action<JavascriptBridgeBrowserSide, CefFrame, JavascriptArrayValue>>();

        internal HashSet<ProcessMessageBridgeHandler> MessageHandlers { get; } = new HashSet<ProcessMessageBridgeHandler>();

        public void AddMessageHandler(ProcessMessageBridgeHandler handler)
        {
            handler.BrowserSideBridge = this;
            handler.ProcessType = CefProcessId.Browser;
            MessageHandlers.Add(handler);
        }

        public void RemoveMessageHandler(ProcessMessageBridgeHandler handler)
        {
            if (MessageHandlers.Contains(handler))
            {
                MessageHandlers.Remove(handler);
            }
        }


        internal MessageBridgeBrowserSide(Formium owner)
        {
            Owner = owner;
            MessagePipe = new MessageBridgeNamedPipeServer(this, GetServiceName(owner.Browser.Identifier), CancellationTokenSource);
        }

        internal bool OnRenderProcessMessage(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {

            if (message.Name == PROCESS_MESSAGE_BRIDGE_MESSAGE)
            {
                var buff = message.Arguments.GetBinary(0);
                var json = Encoding.UTF8.GetString(buff.ToArray());
                var msg = BridgeMessage.FromJson(json);
                buff.Dispose();

                foreach (var handler in MessageHandlers)
                {
                    handler.OnRenderSideMessageReceived(msg.Name, frame, msg.Arguments);
                }

                return true;
            }

            return false;
        }

        public void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
        {
            if (frame.IsMain)
            {
                foreach (var handler in MessageHandlers)
                {
                    handler.OnBeforeBrowse(frame);
                }
            }

        }

        public void OnRenderProcessTerminated(CefBrowser browser)
        {
            foreach (var handler in MessageHandlers)
            {
                handler.OnRenderProcessTerminated(browser);
            }
        }

        public void OnBeforeClose(CefBrowser browser)
        {
            foreach (var handler in MessageHandlers)
            {
                handler.OnBeforeClose(browser);
            }
        }


    }
}
