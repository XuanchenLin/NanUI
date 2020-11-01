using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    using static NetDimension.NanUI.Browser.MessageBridge;

    public abstract class ProcessMessageBridgeHandler
    {
        internal protected CefProcessId ProcessType { get; set; }
        internal protected MessageBridgeBrowserSide BrowserSideBridge { get; internal set; }
        internal protected MessageBridgeRenderSide RenderSideBridge { get; internal set; }
        internal List<Func<MessageBridgeRequest, MessageBridgeResponse>> JavascriptRequestHandlers { get; } = new List<Func<MessageBridgeRequest, MessageBridgeResponse>>();

        private void RequireRenderThread()
        {
            if (ProcessType != CefProcessId.Renderer)
            {
                throw new InvalidOperationException("This operation is only availabel in render process.");
            }
        }

        public ProcessMessageBridgeHandler()
        {

        }

        public MessageBridgeResponse SendExecutionRequest(MessageBridgeRequest request)
        {
            return RenderSideBridge.SendRequest(request);
        }
        public Task<MessageBridgeResponse> SendExecutionRequestAsync(MessageBridgeRequest request)
        {
            RequireRenderThread();

            return RenderSideBridge.SendRequestAsync(request);
        }

        public void SendProcessMessage(CefFrame frame, BridgeMessage message)
        {
            var msg = CefProcessMessage.Create(PROCESS_MESSAGE_BRIDGE_MESSAGE);
            var json = message.ToJson();

            msg.Arguments.SetBinary(0, CefBinaryValue.Create(Encoding.UTF8.GetBytes(json)));
            frame.SendProcessMessage(ProcessType, msg);
            msg.Dispose();
        }

        //public void SendProcessMessage(CefProcessId processId, CefFrame frame, BridgeMessage message)
        //{
        //    var msg = CefProcessMessage.Create(PROCESS_MESSAGE_BRIDGE_MESSAGE);
        //    var json = message.ToJson();

        //    msg.Arguments.SetBinary(0, CefBinaryValue.Create(Encoding.UTF8.GetBytes(json)));
        //    frame.SendProcessMessage(processId, msg);
        //    msg.Dispose();
        //}

        public static void SendProcessMessage(CefProcessId processId, CefFrame frame, BridgeMessage message)
        {
            var msg = CefProcessMessage.Create(PROCESS_MESSAGE_BRIDGE_MESSAGE);
            var json = message.ToJson();
            msg.Arguments.SetBinary(0, CefBinaryValue.Create(Encoding.UTF8.GetBytes(json)));
            frame.SendProcessMessage(processId, msg);
            msg.Dispose();

        }

        protected void RegisterJavascriptMessageHandler(Func<MessageBridgeRequest, MessageBridgeResponse> handler)
        {
            JavascriptRequestHandlers.Add(handler);
        }

        #region OnBrowserSide
        public abstract void OnRenderSideMessageReceived(string message, CefFrame frame, MessageArrayValue arguments);
        public abstract void OnBeforeBrowse(CefFrame frame);
        public abstract void OnRenderProcessTerminated(CefBrowser browser);
        public abstract void OnBeforeClose(CefBrowser browser);
        #endregion

        #region OnRenderSide
        public abstract void OnBrowserSideMessageReceived(string message, CefFrame frame, MessageArrayValue arguments);
        public abstract void OnContextCreated(CefFrame frame, CefV8Context context);
        public abstract void OnContextReleased(CefFrame frame, CefV8Context context);
        #endregion





    }
}
