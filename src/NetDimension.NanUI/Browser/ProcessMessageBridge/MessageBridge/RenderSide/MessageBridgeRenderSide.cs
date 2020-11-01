using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    using static NetDimension.NanUI.Browser.MessageBridge;

    public sealed class MessageBridgeRenderSide
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        //internal Dictionary<string, Action<JavascriptBridgeRenderSide, CefFrame, JavascriptArrayValue>> ProcessMessageHandlers { get; } = new Dictionary<string, Action<JavascriptBridgeRenderSide, CefFrame, JavascriptArrayValue>>();


        //internal void AddProcessMessageHandler(string message, Action<JavascriptBridgeRenderSide, CefFrame, JavascriptArrayValue> handler)
        //{
        //    ProcessMessageHandlers.Add(message, handler);
        //}

        //internal void RemoveProcessMessageHandler(string message)
        //{
        //    ProcessMessageHandlers.Remove(message);
        //}
        internal List<ProcessMessageBridgeHandler> MessageHandlers { get; } = new List<ProcessMessageBridgeHandler>();

        public void AddMessageHandler(ProcessMessageBridgeHandler handler)
        {
            handler.RenderSideBridge = this;
            handler.ProcessType = CefProcessId.Renderer;
            MessageHandlers.Add(handler);
        }

        public void RemoveMessageHandler(ProcessMessageBridgeHandler handler)
        {
            if (MessageHandlers.Contains(handler))
            {
                MessageHandlers.Remove(handler);
            }
        }

        internal bool OnBrowserProcessMessage(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {

            if (message.Name == PROCESS_MESSAGE_BRIDGE_MESSAGE)
            {
                var buff = message.Arguments.GetBinary(0);
                var json = Encoding.UTF8.GetString(buff.ToArray());



                var msg = BridgeMessage.FromJson(json);
                buff.Dispose();



                foreach (var handler in MessageHandlers)
                {
                    handler.OnBrowserSideMessageReceived(msg.Name, frame, msg.Arguments);
                }
                //if (ProcessMessageHandlers.ContainsKey(msg.Name))
                //{
                //    ProcessMessageHandlers[msg.Name].Invoke(this, frame, msg.Arguments);
                //}

                return true;

            }

            return false;
        }

        //internal void SendProcessMessage(CefFrame frame, JavascriptMessage message)
        //{
        //    var msg = CefProcessMessage.Create(JAVASCRIPT_BRIDGE_MESSAGE);
        //    msg.Arguments.SetString(0, message.ToJson());
        //    frame.SendProcessMessage(CefProcessId.Browser, msg);
        //    msg.Dispose();
        //}

        internal MessageBridgeResponse SendRequest(MessageBridgeRequest request)
        {

            return SendRequestAsync(request).GetAwaiter().GetResult();
        }

        internal Task<MessageBridgeResponse> SendRequestAsync(MessageBridgeRequest request)
        {
            return Task.Run(() =>
            {

                var serviceName = GetServiceName(request.BrowserId);


                var client = new MessageBridgeNamedPipeClient(this, serviceName, _cancellationTokenSource);

                return client.RequestAsync(request);

            }, _cancellationTokenSource.Token);
        }

        public void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            foreach (var handler in MessageHandlers)
            {
                handler.OnContextCreated(frame,context);
            }
        }

        public void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            foreach (var handler in MessageHandlers)
            {
                handler.OnContextCreated(frame, context);
            }
        }



    }
}
