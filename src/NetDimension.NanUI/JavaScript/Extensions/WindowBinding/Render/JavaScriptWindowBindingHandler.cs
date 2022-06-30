using NetDimension.NanUI.Browser.MessagePipe;
using NetDimension.NanUI.JavaScript.Renderer;

using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.WindowBinding;

class JavaScriptWindowBindingHandler : CefV8Handler
{
    public JavaScriptWindowBindingHandler(JavaScriptWindowBindingObject targetObject)
    {
        TargetObject = targetObject;
    }

    public JavaScriptWindowBindingObject TargetObject { get; }

    protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
    {
        var context = CefV8Context.GetCurrentContext();

        var frame = context.GetFrame();

        var func = TargetObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == name);

        if (func == null)
        {
            exception = $"[NanUI]: Native Function `{name}` is not defined.";
            returnValue = null;

            return true;
        }

        var args = new JavaScriptArray();

        foreach (var arg in arguments)
        {
            args.Add(arg.ToJavaScriptValue());
        }

        exception = null;


        switch (func.FunctionType)
        {
            case JavaScriptWindowBindingFunctionType.SyncFunctionOnBrowserSide:
                {
                    var response = FormiumMessageBridge.ExecuteRequest(new MessageRequest(InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_FUNCTION, frame.Browser.Identifier, frame.Identifier, context.GetHashCode())
                    {
                        Data = JsonConvert.SerializeObject(new
                        {
                            FrameId = frame.Identifier,
                            ObjectName = TargetObject.Name,
                            Uuid = func.Uuid,
                            FunctionName = func.FunctionName,
                            Arguments = args.ToJson()
                        })
                    });

                    if (response.IsSuccess)
                    {
                        var retval = JavaScriptValue.FromJson(response.Data).ToCefV8Value();

                        if (retval != null)
                        {
                            returnValue = retval;
                        }
                        else
                        {
                            returnValue = CefV8Value.CreateUndefined();
                        }
                    }
                    else
                    {
                        returnValue = null;
                        exception = $"[NanUI]: {response.Result}";
                    }


                }
                break;

            case JavaScriptWindowBindingFunctionType.AsyncFucntionOnBrowserSide:
                {
                    var response = FormiumMessageBridge.ExecuteRequest(new MessageRequest(InvokeWindowBindingFunctionHandler.INVOKE_WINDOW_BINDING_ASYNC_FUNCTION, frame.Browser.Identifier, frame.Identifier, context.GetHashCode())
                    {
                        Data = JsonConvert.SerializeObject(new
                        {
                            FrameId = frame.Identifier,
                            ObjectName = TargetObject.Name,
                            Uuid = func.Uuid,
                            FunctionName = func.FunctionName,
                            Arguments = args.ToJson()
                        })
                    });

                    if (response.IsSuccess)
                    {
                        //var callback = CefV8Value.CreateFunction("promise", new JavaScriptPromiseThenableCallbackFunction(func.Uuid, context));

                        //returnValue = callback;

                        //var global = context.GetGlobal();

                        //var formiumInstance = global.GetValue("Formium");

                        //var promiseCreateFunc = formiumInstance.GetValue("createPromise");

                        //var promiseData = promiseCreateFunc.ExecuteFunctionWithContext(context, null, new CefV8Value[] { });

                        //returnValue = promiseData?.GetValue("promise");

                        //if (returnValue != null)
                        //{
                        //    var promiseFunction = new JavaScriptRenderSidePromiseContext(func.Uuid, context, promiseData);

                        //    JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Add(promiseFunction);

                        //}

                        returnValue = context.CreateJavaScriptPromiseContext(func.Uuid);



                    }
                    else
                    {
                        returnValue = null;
                        exception = $"[NanUI]: {response.Result}";
                    }


                }
                break;

            case JavaScriptWindowBindingFunctionType.SyncFunctionOnRenderSide:
                {
                    var retval = func.RenderSideSyncFunction.Invoke(args);

                    returnValue = retval?.ToCefV8Value() ?? CefV8Value.CreateUndefined();
                }
                break;
            case JavaScriptWindowBindingFunctionType.AsyncFunctionOnRenderSide:
                {

                    func.RenderSideAsyncFunction.Invoke(args, new JavaScriptFunctionPromise(frame, func.Uuid, CefProcessId.Renderer));

                    //var global = context.GetGlobal();

                    //var formiumInstance = global.GetValue("Formium");


                    //var promiseCreateFunc = formiumInstance.GetValue("createPromise");

                    ////var callback = CefV8Value.CreateFunction("promise", new JavaScriptPromiseThenableCallbackFunction(func.Uuid, context));

                    //var promiseData = promiseCreateFunc.ExecuteFunctionWithContext(context, null, new CefV8Value[] { });

                    //returnValue = promiseData?.GetValue("promise");

                    //if (returnValue != null)
                    //{
                    //    var promiseFunction = new JavaScriptRenderSidePromiseContext(func.Uuid, context, promiseData);

                    //    JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Add(promiseFunction);

                    //}



                    //returnValue = callback;

                    //returnValue = callback.ExecuteFunctionWithContext(context, null, new CefV8Value[] { callback });


                    returnValue = context.CreateJavaScriptPromiseContext(func.Uuid);

                }
                break;
            default:
                returnValue = null;
                break;

        }



        return true;
    }


}
