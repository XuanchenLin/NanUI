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

    MessageResponse WindowBindingFunction(MessageRequest request)
    {
        if (request.Name == InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_FUNCTION)
        {
            dynamic requestData = JsonConvert.DeserializeObject<dynamic>(request.Data);

            string objectName = requestData.ObjectName;
            Guid funcId = requestData.Uuid;
            string funcName = requestData.FunctionName;
            string data = requestData.Arguments;

            var args = JavaScriptValue.FromJson(data).ToArray();


            var windowBindingObject = WinFormium.Runtime.Container.GetInstance<JavaScriptWindowBindingObject>(objectName);

            if (windowBindingObject == null)
            {
                return new MessageResponse(false, $"[NanUI]: The `{objectName}` window binding object is not exists.");
            }

            var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

            if (function == null)
            {
                return new MessageResponse(false, $"[NanUI]: The `{funcName}` function is not exists.");
            }

            if (function.FunctionType == JavaScriptWindowBindingFunctionType.SyncFunctionOnBrowserSide)
            {

                try
                {
                    var retval = function.BrowserSideSyncFuncion.Invoke(Owner, args) ?? JavaScriptValue.CreateUndefined();

                    return new MessageResponse()
                    {
                        Data = retval.ToJson()
                    };
                }
                catch (Exception ex)
                {
                    return new MessageResponse(false, ex.Message);
                }


            }



            return new MessageResponse(false, $"[NanUI]: The handler of `{funcName}` function is not defined.");
        }

        return null;
    }


    MessageResponse WindowBindingAsyncFunction(MessageRequest request)
    {
        if (request.Name == InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_ASYNC_FUNCTION)
        {
            dynamic requestData = JsonConvert.DeserializeObject<dynamic>(request.Data);

            string objectName = requestData.ObjectName;
            Guid funcId = requestData.Uuid;
            string funcName = requestData.FunctionName;
            string data = requestData.Arguments;
            long frameId = requestData.FrameId;

            var frame = Owner.GetFrame(frameId);

            var args = JavaScriptValue.FromJson(data).ToArray();



            var windowBindingObject = WinFormium.Runtime.Container.GetInstance<JavaScriptWindowBindingObject>(objectName);

            if (windowBindingObject == null)
            {
                return new MessageResponse(false, $"The `{objectName}` window binding object is not exists.");
            }

            var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

            if (function == null)
            {
                return new MessageResponse(false, $"The `{funcName}` function is not exists.");
            }

            if (function.FunctionType == JavaScriptWindowBindingFunctionType.AsyncFucntionOnBrowserSide)
            {

                try
                {
                    args.BindToFrame(frame);


                    function.BrowserSideAsyncFunction.Invoke(Owner, args, new JavaScriptFunctionPromise(frame, funcId));

                    return new MessageResponse();
                }
                catch (Exception ex)
                {
                    return new MessageResponse(false, ex.Message);
                }
            }
            return new MessageResponse(false, $"The handler of `{funcName}` function is not defined.");
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
