// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;


public abstract class JavaScriptWindowBindingObject : CefV8Handler
{
    GCHandle _gcHandle;
    protected JavaScriptWindowBindingObject()
    {
        _gcHandle = GCHandle.Alloc(this);
    }

    public abstract string Name { get; }
    public abstract string JavaScriptWindowBindingCode { get; }

    internal List<JavaScriptWindowBindingObjectFunction> WindowBindingFunctions { get; } = new();

    #region Local side
    // sync function
    internal protected void RegisterSynchronousNativeFunction(Func<Formium, JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        RegisterSynchronousNativeFunction(functionDelegate.Method.Name, functionDelegate);
    }

    internal protected void RegisterSynchronousNativeFunction(string functionName, Func<Formium, JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        WindowBindingFunctions.Add(new JavaScriptWindowBindingObjectFunction(functionDelegate) { FunctionName = functionName });
    }

    // async function
    internal protected void RegisterAsynchronousNativeFunction(Action<Formium, JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        RegisterAsynchronousNativeFunction(functionDelegate.Method.Name, functionDelegate);
    }
    internal protected void RegisterAsynchronousNativeFunction(string functionName, Action<Formium, JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        WindowBindingFunctions.Add(new JavaScriptWindowBindingObjectFunction(functionDelegate) { FunctionName = functionName });
    }

    #endregion

    #region Remote side
    // sync functions
    internal protected void RegisterSynchronousNativeFunction(Func<JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        RegisterSynchronousNativeFunction(functionDelegate.Method.Name, functionDelegate);
    }

    internal protected void RegisterSynchronousNativeFunction(string functionName, Func<JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        WindowBindingFunctions.Add(new JavaScriptWindowBindingObjectFunction(functionDelegate) { FunctionName = functionName });
    }

    // async funcions
    internal protected void RegisterAsynchronousNativeFunction(Action<JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        RegisterAsynchronousNativeFunction(functionDelegate.Method.Name, functionDelegate);
    }


    internal protected void RegisterAsynchronousNativeFunction(string functionName, Action<JavaScriptArray, JavaScriptPromise> functionDelegate)
    {
        WindowBindingFunctions.Add(new JavaScriptWindowBindingObjectFunction(functionDelegate) { FunctionName = functionName });
    }
    #endregion

    protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
    {
        var context = CefV8Context.GetCurrentContext();
        var browser = context.GetBrowser();
        var frame = context.GetFrame();

        var func = WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == name);

        if (func == null)
        {
            exception = $"[{nameof(WinFormium)}]: Native Function `{name}` is not defined.";
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
            case JavaScriptWindowBindingObjectFunctionType.SynchronousFunctionOnLocal:
                {
                    var response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
                    {
                        Name = JavaScriptWindowBindingObjectBridge.EXECUTE_WINDOW_BINDING_OBJECT_SYNC_FUNCTION_MESSAGE,
                        BrowserId = browser.Identifier,
                        FrameId = frame.Identifier,
                        IsRemote = true,
                        Payload = JsonSerializer.Serialize(new JavaScriptWindowBindingObjectMessage
                        {
                            ObjectName = Name,
                            Uuid = func.Uuid,
                            FunctionName = func.FunctionName,
                            Arguments = args.ToJson()
                        })
                    });

                    if (response.IsSuccess && response.Data != null)
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
                        exception = response.Exception ?? string.Empty;
                    }


                }
                break;

            case JavaScriptWindowBindingObjectFunctionType.AsynchronousFunctionOnLocal:
                {
                    var response = MessageBridge.ExecuteRequest(new MessageBridgeRequest
                    {
                        Name = JavaScriptWindowBindingObjectBridge.EXECUTE_WINDOW_BINDING_OBJECT_ASYNC_FUNCTION_MESSAGE,
                        BrowserId = browser.Identifier,
                        FrameId = frame.Identifier,
                        IsRemote = true,
                        Payload = JsonSerializer.Serialize(new JavaScriptWindowBindingObjectMessage
                        {
                            ObjectName = Name,
                            Uuid = func.Uuid,
                            FunctionName = func.FunctionName,
                            Arguments = args.ToJson()
                        })
                    });

                    if (response.IsSuccess)
                    {
                        returnValue = context.CreateJavaScriptPromiseContext(func.Uuid);

                        exception = null;
                    }
                    else
                    {
                        returnValue = null;
                        exception = response.Exception ?? string.Empty;
                    }


                }
                break;

            case JavaScriptWindowBindingObjectFunctionType.SynchronousFunctionOnRemote:
                {
                    if (func.SynchronousFunctionOnRemote == null)
                    {
                        returnValue = null;
                        exception = $"[{nameof(WinFormium)}]: Synchronous function `{name}` has no function handler.";

                        break;
                    }

                    var retval = func.SynchronousFunctionOnRemote.Invoke(args);

                    returnValue = retval?.ToCefV8Value() ?? CefV8Value.CreateUndefined();
                }
                break;
            case JavaScriptWindowBindingObjectFunctionType.AsynchronousFunctionOnRemote:
                {
                    if (func.AsynchronousFunctionOnRemote == null)
                    {
                        returnValue = null;
                        exception = $"[{nameof(WinFormium)}]: Asynchronous function `{name}` has no function handler.";

                        break;
                    }

                    func.AsynchronousFunctionOnRemote.Invoke(args, new JavaScriptPromise(frame, func.Uuid, ProcessType.Renderer));


                    returnValue = context.CreateJavaScriptPromiseContext(func.Uuid);
                }
                break;
            default:
                returnValue = null;
                break;

        }

        return true;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _gcHandle.Free();
        }

        base.Dispose(disposing);
    }

}
