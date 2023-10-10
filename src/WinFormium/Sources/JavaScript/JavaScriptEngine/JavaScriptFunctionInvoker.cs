// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public sealed class JavaScriptFunctionInvoker : JavaScriptValue
{


    public required bool IsAsynchronous { get; init; }
    public required ProcessType Side { get; init; }

    internal JavaScriptFunctionInvoker()
    : base(JavaScriptValueType.Function)
    {

    }

    public Task<JavaScriptResult> ExecuteAsync(params JavaScriptValue[] arguments)
    {
        var array = new JavaScriptArray();

        if (arguments != null)
        {
            foreach (var item in arguments)
            {
                array.Add(item);
            }
        }

        array.AssociateToFrame(Frame);


        return ExecuteAsync(array);

    }

    public Task<JavaScriptResult> ExecuteAsync(JavaScriptArray? arguments = null)
    {
        var tcs = new TaskCompletionSource<JavaScriptResult>();
        var taskId = tcs.GetHashCode();

        if (arguments == null)
        {
            arguments = new JavaScriptArray();
        }

        arguments.AssociateToFrame(Frame);

        if (Frame != null && JavaScriptEngineBridge.JavaScriptExecutionResults.TryAdd((taskId, Frame.Identifier), tcs))
        {
            MessageBridge.SendMessageToRemote(Frame, new BridgeMessage(JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE, new ExecuteJavaScriptFunctionMessage()
            {
                TaskId = taskId,
                FunctionId = Uuid,
                FrameId = Frame.Identifier,
                Data = arguments.ToJson()
            }));
        }
        else
        {
            tcs.SetException(new ArgumentException());
        }

        return tcs.Task;
    }


}
