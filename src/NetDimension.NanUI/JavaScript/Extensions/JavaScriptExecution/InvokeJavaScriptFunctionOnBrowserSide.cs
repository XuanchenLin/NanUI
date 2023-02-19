using NetDimension.NanUI.Browser.MessagePipe;
using NetDimension.NanUI.JavaScript.Renderer;

using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

class InvokeJavaScriptFunctionOnBrowserSide : MessageHandlerOnBrowserSide
{



    InvokeJavaScriptFunctionHandler MessageHandler => (InvokeJavaScriptFunctionHandler)this.MessageHandlerWrapper;

    public InvokeJavaScriptFunctionOnBrowserSide(MessageHandlerWrapperBase messageHandlerWrapper)
        : base(messageHandlerWrapper)
    {
        RegisterMessageHandler(ResponseForRenderFunctionInvoke);
        RegisterMessageHandler(ResponseForRenderPromiseInvoke);
    }

    MessageResponse ResponseForRenderFunctionInvoke(MessageRequest request)
    {
        if (request.Name == InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION)
        {
            var requestData = JsonSerializer.Deserialize<BrowserSideFunctionMessageParameter>(request.Data);

            var funcId = requestData.Uuid;
            var data = requestData.Arguments;

            var args = JavaScriptValue.FromJson(data).ToArray();

            var func = JavaScriptSyncFunction.Bag.FirstOrDefault(x => x.Uuid == funcId);


            MessageResponse response;

            if (func == null)
            {
                response = new MessageResponse(false, "Promise is not exits.");
            }
            else
            {
                try
                {
                    var retval = func.FunctionDelegate.Invoke(args);

                    if (retval == null)
                    {
                        retval = JavaScriptValue.CreateUndefined();
                    }

                    response = new MessageResponse()
                    {
                        Data = retval.ToJson()
                    };
                }
                catch (Exception ex)
                {
                    response = new MessageResponse(false, ex.Message);

                }
            }

            return response;
        }

        return null;
    }

    MessageResponse ResponseForRenderPromiseInvoke(MessageRequest request)
    {
        if (request.Name == InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_PROMISE_FUNCTION)
        {
            var requestData = JsonSerializer.Deserialize<BrowserSideFunctionMessageParameter>(request.Data);

            var funcId = requestData.Uuid;
            var data = requestData.Arguments;

            var args = JavaScriptValue.FromJson(data).ToArray();


            MessageResponse response;

            var func = JavaScriptAsyncFunction.Bag.FirstOrDefault(x => x.Uuid == funcId);

            if (func == null)
            {
                response = new MessageResponse(false, "Promise is not exits.");
            }
            else
            {

                try
                {
                    // Owner.InvokeIfRequired(() =>
                    // {
                    //     func.FunctionDelegate.Invoke(args, new JavaScriptFunctionPromise(func.Frame, funcId));
                    // });
                    func.FunctionDelegate.Invoke(args, new JavaScriptFunctionPromise(func.Frame, funcId));

                    response = new MessageResponse();
                }
                catch (Exception ex)
                {
                    response = new MessageResponse(false, ex.Message);
                }


            }

            //if (args.Length != 2)
            //{
            //    response = new MessageResponse(false, "Async function need both Resolve and Reject methods.");
            //}
            //else
            //{
            //    var func = JavaScriptAsyncFunction.Bag.FirstOrDefault(x => x.Uuid == funcId);

            //    if (func == null)
            //    {
            //        response = new MessageResponse(false, "Promise is not exits.");
            //    }
            //    else
            //    {

            //        try
            //        {
            //            // Owner.InvokeIfRequired(() =>
            //            // {
            //            //     func.FunctionDelegate.Invoke(args, new JavaScriptFunctionPromise(func.Frame, funcId));
            //            // });
            //            func.FunctionDelegate.Invoke(args, new JavaScriptFunctionPromise(func.Frame, funcId));

            //            response = new MessageResponse();
            //        }
            //        catch (Exception ex)
            //        {
            //            response = new MessageResponse(false, ex.Message);
            //        }


            //    }

            //}



            return response;
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
        if (message == InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION)
        {
            CefRuntime.PostTask(CefThreadId.UI, new InvokeJavaScriptFunctionCompletedCallbackTask(this, frame, arguments));
        }
    }

    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }
}
