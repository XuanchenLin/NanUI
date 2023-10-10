// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class ExecuteJavaScriptFunctionPromiseTaskOnRemote : CefTask
{
    public JavaScriptEngineBridge Bridge { get; }
    public required CefFrame Frame { get; init; }
    public required ExecuteJavaScriptFunctionMessage TaskData { get; init; }

    public ExecuteJavaScriptFunctionPromiseTaskOnRemote(JavaScriptEngineBridge bridge)
    {
        Bridge = bridge;
    }

    protected override void Execute()
    {
        var storedObject = JavaScriptEngineBridge.JavaScriptPromiseContexts.Find(x => x.Uuid == TaskData.FunctionId);

        if (storedObject != null)
        {
            try
            {
                var context = Frame.V8Context ?? CefV8Context.GetCurrentContext();
                using var global = context.GetGlobal();

                if (TaskData.Success)
                {
                    var args = JavaScriptValue.FromJson(TaskData.Data!);

                    CefV8Value[]? arguments;


                    context.Enter();
                    if (args.ValueType != JavaScriptValueType.Array || args == null)
                    {
                        arguments = new CefV8Value[] { };
                    }
                    else
                    {
                        arguments = args.ToArray().ToCefV8Arguments();
                    }
                    context.Exit();


                    storedObject.Resolve.ExecuteFunctionWithContext(context, global, arguments);
                }
                else
                {
                    storedObject.Reject.ExecuteFunctionWithContext(context, global, new CefV8Value[] { CefV8Value.CreateString(TaskData.ExceptionText ?? string.Empty) });
                }

            }
            catch(Exception ex)
            {
                Logger.Instance.Log.LogError(ex);
            }
            finally
            {
                JavaScriptEngineBridge.JavaScriptPromiseContexts.Remove(storedObject);
                storedObject.Dispose();
            }

        }
    }
}
