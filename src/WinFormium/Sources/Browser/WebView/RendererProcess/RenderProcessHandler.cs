// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class RenderProcessHandler : CefRenderProcessHandler
{
    private BrowserApp _browserApp;
    private WindowBindingObjectServiceClient WindowBindingObjectServiceClient { get; }

    public ProcessMessageDispatcher MessageDispatcher { get; } = new ProcessMessageDispatcher();

    public MessageBridge? MessageBridge { get; private set; }

    public RenderProcessHandler(BrowserApp browserApp)
    {
        _browserApp = browserApp;
        WindowBindingObjectServiceClient = new WindowBindingObjectServiceClient(_browserApp.GetExtensionPipeName());
    }

    protected override void OnBrowserCreated(CefBrowser browser, CefDictionaryValue? extraInfo)
    {
        MessageBridge = new MessageBridge(_browserApp.ApplicationContext,browser, ProcessType.Renderer, MessageDispatcher);

        MessageBridge.RegisterMessageBridgeHandler(new JavaScriptEngineBridge(MessageBridge));
        MessageBridge.RegisterMessageBridgeHandler(new JavaScriptObjectMappingBridge(MessageBridge));
        MessageBridge.RegisterMessageBridgeHandler(new JavaScriptWindowBindingObjectBridge(MessageBridge,null));
    }

    protected override void OnFocusedNodeChanged(CefBrowser browser, CefFrame frame, CefDomNode node)
    {
        base.OnFocusedNodeChanged(browser, frame, node);
    }

    protected override void OnUncaughtException(CefBrowser browser, CefFrame frame, CefV8Context context, CefV8Exception exception, CefV8StackTrace stackTrace)
    {
        base.OnUncaughtException(browser, frame, context, exception, stackTrace);
    }

    protected override void OnBrowserDestroyed(CefBrowser browser)
    {
        base.OnBrowserDestroyed(browser);
    }

    protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        var message = CefProcessMessage.Create(WinFormiumMessage.WFM_ON_CONTEXT_CREATED);

        frame.SendProcessMessage(CefProcessId.Browser, message);

        MessageBridge?.OnContextCreated(browser, frame, context);

        frame.ExecuteJavaScript("window.formium && formium?.hostWindow.internal?.setContextReadyState()", string.Empty, 0);

        context.Dispose();
    }

    protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        var message = CefProcessMessage.Create(WinFormiumMessage.WFM_ON_CONTEXT_RELEASED);

        frame.SendProcessMessage(CefProcessId.Browser, message);

        MessageBridge?.OnContextReleased(browser, frame, context);


        context.Dispose();
    }


    //List<JavaScriptWindowBindingObject> WindowBindingObjectInstances { get; } = new();

    protected override void OnWebKitInitialized()
    {
        RegisterWindowBindingObjects();
    }

    private void RegisterWindowBindingObjects()
    {
        var response = WindowBindingObjectServiceClient.Request("GetWindowBindingObjects");

        if (string.IsNullOrEmpty(response)) return;

        var formiumHostObject = new FormiumWindowBindingObject();

        CefRuntime.RegisterExtension(formiumHostObject.Name, formiumHostObject.JavaScriptWindowBindingCode, formiumHostObject);

        var windowBindingObjects = _browserApp.ApplicationContext.Services.GetServices<JavaScriptWindowBindingObject>();

        foreach (var windowBindingObject in windowBindingObjects)
        {
            CefRuntime.RegisterExtension(windowBindingObject.Name, windowBindingObject.JavaScriptWindowBindingCode, windowBindingObject);
        }

        try
        {
            var describers = JsonSerializer.Deserialize<List<JavaScriptWindowBindingObjectDescriper>>(response!) ?? new List<JavaScriptWindowBindingObjectDescriper>();

            var assemblies = new Dictionary<string, Assembly>();

            foreach (var describer in describers)
            {
                var path = describer.FilePath.ToLower();
                var typeName = describer.TypeName;

                Assembly assembly;

                if (assemblies.ContainsKey(path))
                {
                    assembly = assemblies[path];
                }
                else
                {
                    assembly = Assembly.LoadFrom(path);
                    assemblies.Add(path, assembly);
                }

                var type = assembly.GetType(typeName);

                if (type == null || !type.IsSubclassOf(typeof(JavaScriptWindowBindingObject))) continue;

                try
                {

                    var instance = Activator.CreateInstance(type) as JavaScriptWindowBindingObject;

                    Logger.Instance.Log.LogDebug($"Registering window binding object: {instance?.Name ?? "[FAILED]"}");

                    if (instance != null)
                    {

                        //WindowBindingObjectInstances.Add(instance);
                        CefRuntime.RegisterExtension(instance.Name, instance.JavaScriptWindowBindingCode, instance);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log.LogError(ex);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }
    }

    protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        MessageDispatcher.DispatchMessage(browser, frame, sourceProcess, message);

        return base.OnProcessMessageReceived(browser, frame, sourceProcess, message);
    }
}
