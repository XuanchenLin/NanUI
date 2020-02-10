using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    using Chromium;
    using Chromium.Remote;

    class RenderProcessHandler : CfrRenderProcessHandler
    {
        
        private RenderProcess renderProcess;
        private FormiumJavascriptExtension baseExtension;
        private Dictionary<string, ChromiumExtensionBase> customExtensions = new Dictionary<string, ChromiumExtensionBase>();

        public RenderProcessHandler(RenderProcess renderProcess)
        {
            this.renderProcess = renderProcess;

            this.OnContextCreated += RenderProcessHandler_OnContextCreated;
            this.OnBrowserCreated += RenderProcessHandler_OnBrowserCreated;
            this.OnWebKitInitialized += RenderProcessHandler_OnWebKitInitialized;
            this.OnProcessMessageReceived += RenderProcessHandler_OnProcessMessageReceived;
        }


        private void RenderProcessHandler_OnBrowserCreated(object sender, Chromium.Remote.Event.CfrOnBrowserCreatedEventArgs e)
        {
            var browserCore = BrowserCore.GetBrowserCore(e.Browser.Identifier);

            if (browserCore != null)
            {
                var remoteProcess = browserCore.remoteProcess;
                if(remoteProcess!=null && remoteProcess != renderProcess)
                {
                    CfxRemoteCallbackManager.SuspendCallbacks(renderProcess.RemoteProcessId);
                }

                browserCore.SetRemoteBrowser(e.Browser, renderProcess);


            }
        }

        private void RenderProcessHandler_OnContextCreated(object sender, Chromium.Remote.Event.CfrOnContextCreatedEventArgs e)
        {
            var browserCore = BrowserCore.GetBrowserCore(e.Browser.Identifier);

            if (browserCore != null)
            {
                RegisterObjectToGlobal(browserCore, e.Frame, e.Context);

                browserCore.RaiseOnV8ContextCreated(e.Browser, e.Frame, e.Context);
            }
        }

        private void RegisterObjectToGlobal(BrowserCore browser, CfrFrame frame, CfrV8Context context)
        {
            if (frame.IsMain)
            {
                SetProperties(context, browser.GlobalObject);
            }
            else
            {
                if (browser.frameGlobalObjects.TryGetValue(frame.Name, out JSObject obj))
                {
                    SetProperties(context, obj);
                }
            }
        }

        private void SetProperties(CfrV8Context context, JSObject obj)
        {
            foreach (var p in obj)
            {
                var v8Value = p.Value.GetV8Value(context);
                context.Global.SetValue(p.Key, v8Value, CfxV8PropertyAttribute.DontDelete | CfxV8PropertyAttribute.ReadOnly);
            }
        }

        private void RenderProcessHandler_OnWebKitInitialized(object sender, CfrEventArgs e)
        {
            baseExtension = new FormiumJavascriptExtension();
            CfrRuntime.RegisterExtension("NanUI/Base", baseExtension.DefinitionJavascriptCode, baseExtension);

            foreach (var kv in Bootstrap.RegisterChromiumExtensionActions)
            {
                var name = kv.Key;
                var extension = kv.Value?.Invoke();
                if (extension != null)
                {
                    customExtensions.Add(name, extension);

                    CfrRuntime.RegisterExtension(name, extension.DefinitionJavascriptCode, extension);
                }
            }

            BrowserCore.RaiseWebKitInitialized();
        }
        private void RenderProcessHandler_OnProcessMessageReceived(object sender, Chromium.Remote.Event.CfrOnProcessMessageReceivedEventArgs e)
        {
            var browserCore = BrowserCore.GetBrowserCore(e.Browser.Identifier);

            if (e.Message.Name.StartsWith(ProcessMessages.NANUI_MSG_PREFIX))
            {
                var messageName = e.Message.Name.Substring(ProcessMessages.NANUI_MSG_PREFIX.Length);


            }
        }


    }
}
