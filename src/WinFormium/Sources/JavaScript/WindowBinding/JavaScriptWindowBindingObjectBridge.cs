// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptWindowBindingObjectBridge : MessageBridgeHandler
{

    public static readonly string EXECUTE_WINDOW_BINDING_OBJECT_SYNC_FUNCTION_MESSAGE = "WinFormium.ExecuteWindowBindingObjectSynchronousFunction";
    public static readonly string EXECUTE_WINDOW_BINDING_OBJECT_ASYNC_FUNCTION_MESSAGE = "WinFormium.ExecuteWindowBindingObjectAsynchronousFunction";

    public static readonly string EXECUTE_WINDOW_BINDING_OBJECT_POST_MESSAGE_MESSAGE = "WinFormium.ExecuteWindowBindingObjectPostMessage";
    public static List<Type> WindowBindingObjectTypes { get; } = new List<Type>();

    public List<JavaScriptWindowBindingObject> WindowBindingObjects { get; } = new ();



    public JavaScriptWindowBindingObjectBridge(MessageBridge bridge, Formium target) : base(bridge)
    {
        InvokerInstance = target;

        WindowBindingObjects.Add(new FormiumWindowBindingObject());

        if (bridge.Side == ProcessType.Main)
        {
            WindowBindingObjects.AddRange(ApplicationContext.Services.GetServices<JavaScriptWindowBindingObject>());

            foreach (var type in WindowBindingObjectTypes)
            {
                if (type == null || !type.IsSubclassOf(typeof(JavaScriptWindowBindingObject))) continue;

                var instance = Activator.CreateInstance(type) as JavaScriptWindowBindingObject;
                if (instance != null)
                {
                    WindowBindingObjects.Add(instance);
                }
            }

            RegisterRequestHandler(EXECUTE_WINDOW_BINDING_OBJECT_SYNC_FUNCTION_MESSAGE, HandleExecuteWindowBindingObjectSynchronousFunctionRequestOnLocal);

            RegisterRequestHandler(EXECUTE_WINDOW_BINDING_OBJECT_ASYNC_FUNCTION_MESSAGE, HandleExecuteWindowBindingObjectAsynchronousFunctionRequestOnLocal);


        }
        else
        {
            RegisterMessageHandler(EXECUTE_WINDOW_BINDING_OBJECT_POST_MESSAGE_MESSAGE, HandlePostBrowserMessageOnRemote);

        }
    }



    public void PostBrowserMessage(CefFrame frame, string message, JavaScriptValue? value)
    {
        MessageBridge.SendMessageToRemote(frame, new BridgeMessage(EXECUTE_WINDOW_BINDING_OBJECT_POST_MESSAGE_MESSAGE, new JavaScriptPostBrowserMessageMessage { Message = message, Data = value?.ToJson() }));
    }
}
