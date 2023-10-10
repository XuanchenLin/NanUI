// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptFunctionInvokerHandler : CefV8Handler
{
    public JavaScriptFunctionInvoker JsValue { get; }
    public CefV8Context Context { get; }

    public JavaScriptFunctionInvokerHandler(JavaScriptValue jsvalue, CefV8Context context)
    {
        JsValue = jsvalue.ToFunction();
        Context = context;
    }

    protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
    {

        var browser = Context.GetBrowser();
        var frame = Context.GetFrame();

        var args = new JavaScriptArray();

        foreach (var arg in arguments)
        {
            args.Add(arg.ToJavaScriptValue());
        }


        MessageBridgeResponse response;

        if (JsValue.IsAsynchronous)
        {
            response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
            {
                Name = JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_PROMISE_MESSAGE,
                BrowserId = browser.Identifier,
                FrameId = frame.Identifier,
                IsRemote = true,
                Payload = JsonSerializer.Serialize(new ExecuteJavaScriptFunctionOnLocalMessage
                {
                    FunctionId = JsValue.Uuid,
                    Data = args.ToJson()
                })
            });


        }
        else
        {
            response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
            {
                Name = JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE,
                BrowserId = browser.Identifier,
                FrameId = frame.Identifier,
                IsRemote = true,
                Payload = JsonSerializer.Serialize(new ExecuteJavaScriptFunctionOnLocalMessage
                {
                    FunctionId = JsValue.Uuid,
                    Data = args.ToJson()
                })
            });
        }

        if (response.IsSuccess)
        {
            if (JsValue.IsAsynchronous)
            {
                returnValue = Context.CreateJavaScriptPromiseContext(JsValue.Uuid);
            }
            else
            {

                Context.Enter();

                var retval = JavaScriptValue.FromJson(response.Data!).ToCefV8Value();

                Context.Exit();

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
            exception = $"[{nameof(WinFormium)}]: {response.Exception}";
            returnValue = CefV8Value.CreateUndefined();
        }


        return true;
    }

}
