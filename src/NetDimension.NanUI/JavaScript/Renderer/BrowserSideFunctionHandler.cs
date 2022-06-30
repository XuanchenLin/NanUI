
using NetDimension.NanUI.Browser.MessagePipe;

using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class BrowserSideFunctionHandler : CefV8Handler
{
    public BrowserSideFunctionHandler(JavaScriptValue jsvalue, CefV8Context context)
    {
        JsValue = jsvalue.ToFunction();
        Context = context;
    }

    public JavaScriptFunction JsValue { get; }
    public CefV8Context Context { get; }

    protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
    {
        var browser = Context.GetBrowser();
        var frame = Context.GetFrame();

        var args = new JavaScriptArray();

        foreach (var arg in arguments)
        {
            args.Add(arg.ToJavaScriptValue());
        }


        MessageResponse response;

        if (JsValue.IsAsyncFunction)
        {
            response = FormiumMessageBridge.ExecuteRequest(new MessageRequest(JavaScriptExecution.InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_PROMISE_FUNCTION, browser.Identifier, frame.Identifier, Context.GetHashCode())
            {
                Data = JsonConvert.SerializeObject(new
                {
                    Uuid = JsValue.Uuid,
                    Arguments = args.ToJson()
                })
            });
        }
        else
        {
            response = FormiumMessageBridge.ExecuteRequest(new MessageRequest(JavaScriptExecution.InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION, browser.Identifier, frame.Identifier, Context.GetHashCode())
            {
                Data = JsonConvert.SerializeObject(new
                {
                    Uuid = JsValue.Uuid,
                    Arguments = args.ToJson()
                })
            });
        }



        if (response.IsSuccess)
        {
            if (JsValue.IsAsyncFunction)
            {
                //var promise = Context.GetGlobal().GetValue("Promise");

                //var resolve = promise.GetValue("resolve");

                //WinFormium.GetLogger().Info($"Current resolve Object State: {resolve.IsFunction}");


                //resolve.ExecuteFunctionWithContext(Context, null, new CefV8Value[] { CefV8Value.CreateString("123") });

                //var thenable = CefV8Value.CreateObject();


                //var callback = CefV8Value.CreateFunction("promise", new JavaScriptPromiseThenableCallbackFunction(JsValue.Uuid, Context));

                //thenable.SetValue("then", callback);

                //var retval = resolve.ExecuteFunctionWithContext(Context, Context.GetGlobal(), new CefV8Value[] { thenable });

                //returnValue = callback.ExecuteFunctionWithContext(Context, null, new CefV8Value[] { callback });

                //returnValue = callback;

                //var context = Context;


                //var global = context.GetGlobal();

                //var formiumInstance = global.GetValue("Formium");


                //var promiseCreateFunc = formiumInstance.GetValue("createPromise");

                //var promiseData = promiseCreateFunc.ExecuteFunctionWithContext(context, null, new CefV8Value[] { });

                //returnValue = promiseData?.GetValue("promise");
                //if (returnValue != null)
                //{
                //    var promiseFunction = new JavaScriptRenderSidePromiseContext(JsValue.Uuid, context, promiseData);

                //    JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Add(promiseFunction);
                //}

                returnValue = Context.CreateJavaScriptPromiseContext(JsValue.Uuid);
            }
            else
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
            exception = null;
        }
        else
        {
            exception = $"[NanUI]: {response.Result}";
            returnValue = null;
        }


        return true;
    }
}
