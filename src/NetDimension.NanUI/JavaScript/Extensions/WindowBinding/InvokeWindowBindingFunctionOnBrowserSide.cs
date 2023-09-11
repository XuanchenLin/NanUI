using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.WindowBinding;

class InvokeWindowBindingFunctionOnBrowserSide : MessageHandlerOnBrowserSide
{
    InvokeWindowBindingFunctionHandler MessageHandler => (InvokeWindowBindingFunctionHandler)this.MessageHandlerWrapper;

    public InvokeWindowBindingFunctionOnBrowserSide(MessageHandlerWrapperBase messageHandlerWrapper)
: base(messageHandlerWrapper)
    {
        RegisterMessageHandler(WindowBindingFunction);
        RegisterMessageHandler(WindowBindingAsyncFunction);
    }

    BridgeMessageResponse WindowBindingFunction(BridgeMessageRequest request)
    {
        if (request.Name == InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_FUNCTION)
        {
            var requestData = JsonSerializer.Deserialize<JavaScriptWindowBindingMessageParameter>(request.Data);

            var objectName = requestData.ObjectName;
            var funcId = requestData.Uuid;
            var funcName = requestData.FunctionName;
            var data = requestData.Arguments;

            var args = JavaScriptValue.FromJson(data).ToArray();


            var windowBindingObject = WinFormium.Runtime.Container.GetInstance<JavaScriptWindowBindingObject>(objectName);

            if (windowBindingObject == null)
            {
                return new BridgeMessageResponse(false, $"[NanUI]: The `{objectName}` window binding object is not exists.");
            }

            var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

            if (function == null)
            {
                return new BridgeMessageResponse(false, $"[NanUI]: The `{funcName}` function is not exists.");
            }

            if (function.FunctionType == JavaScriptWindowBindingFunctionType.SyncFunctionOnBrowserSide)
            {

                try
                {
                    var retval = function.BrowserSideSyncFuncion.Invoke(Owner, args) ?? JavaScriptValue.CreateUndefined();

                    return new BridgeMessageResponse()
                    {
                        Data = retval.ToJson()
                    };
                }
                catch (Exception ex)
                {
                    return new BridgeMessageResponse(false, ex.Message);
                }


            }



            return new BridgeMessageResponse(false, $"[NanUI]: The handler of `{funcName}` function is not defined.");
        }

        return null;
    }


    BridgeMessageResponse WindowBindingAsyncFunction(BridgeMessageRequest request)
    {
        if (request.Name == InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_ASYNC_FUNCTION)
        {
            var requestData = JsonSerializer.Deserialize<JavaScriptWindowBindingMessageParameter>(request.Data);

            var objectName = requestData.ObjectName;
            var funcId = requestData.Uuid;
            var funcName = requestData.FunctionName;
            var data = requestData.Arguments;
            var frameId = requestData.FrameId;

            var frame = Owner.GetFrame(frameId);

            var args = JavaScriptValue.FromJson(data).ToArray();



            var windowBindingObject = WinFormium.Runtime.Container.GetInstance<JavaScriptWindowBindingObject>(objectName);

            if (windowBindingObject == null)
            {
                return new BridgeMessageResponse(false, $"The `{objectName}` window binding object is not exists.");
            }

            var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

            if (function == null)
            {
                return new BridgeMessageResponse(false, $"The `{funcName}` function is not exists.");
            }

            if (function.FunctionType == JavaScriptWindowBindingFunctionType.AsyncFucntionOnBrowserSide)
            {

                try
                {
                    args.BindToFrame(frame);


                    function.BrowserSideAsyncFunction.Invoke(Owner, args, new JavaScriptFunctionPromise(frame, funcId));

                    return new BridgeMessageResponse();
                }
                catch (Exception ex)
                {
                    return new BridgeMessageResponse(false, ex.Message);
                }
            }
            return new BridgeMessageResponse(false, $"The handler of `{funcName}` function is not defined.");
        }

        return null;
    }

    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
    {
    }

    public override void OnBeforeClose(CefBrowser browser)
    {
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
    }

    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }
}
