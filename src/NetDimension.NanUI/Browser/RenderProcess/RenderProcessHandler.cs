using NetDimension.NanUI.Browser.ProcessMessageBridge;
using NetDimension.NanUI.JavaScript;
using Xilium.CefGlue;


namespace NetDimension.NanUI.Browser
{
    class RenderProcessHandler : CefRenderProcessHandler
    {
        internal MessageBridgeRenderSide MessageBridge { get; }

        internal JavaScriptCommunicationBridge JSBridge { get; }

        public RenderProcessHandler()
        {

            MessageBridge = new MessageBridgeRenderSide();

            JSBridge = new JavaScriptCommunicationBridge();
            MessageBridge.AddMessageHandler(JSBridge);

            var handlers = WinFormium.Runtime.Container.GetAllInstances<ProcessMessageBridgeHandler>();

            foreach (var handler in handlers)
            {
                MessageBridge.AddMessageHandler(handler);
            }

        }

        protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            MessageBridge.OnContextCreated(browser, frame, context);

            if (frame.IsMain)
            {
                frame.ExecuteJavaScript($"{JavaScript.JavaScriptCommunicationBridge.ROOT_OBJECT_KEY_TARGET}._setContextReady();", frame.Url, 0);
            }
        }




        protected override void OnWebKitInitialized()
        {
            var extensions = WinFormium.Runtime.Container.GetAllInstances<JavaScriptExtensionBase>();

            foreach (var ext in extensions)
            {
                CefRuntime.RegisterExtension(ext.Name, ext.JavaScriptCode, ext.GetHandler(JSBridge));
            }
        }

        

        protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {

            MessageBridge.OnContextReleased(browser, frame, context);


        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {

            if (MessageBridge.OnBrowserProcessMessage(browser, frame, sourceProcess, message))
            {
                return true;
            }

            return false;
        }
    }
}
