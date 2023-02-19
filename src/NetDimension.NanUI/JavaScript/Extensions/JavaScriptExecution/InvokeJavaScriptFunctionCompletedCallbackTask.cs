using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

class InvokeJavaScriptFunctionCompletedCallbackTask : CefTask
{

    public InvokeJavaScriptFunctionOnBrowserSide Handler { get; }
    public CefFrame Frame { get; }

    private int TaskId { get; }
    private Guid Uuid { get; }

    private bool Success { get; }

    private string ResultData { get; }


    public InvokeJavaScriptFunctionCompletedCallbackTask(InvokeJavaScriptFunctionOnBrowserSide handler, CefFrame frame, string data)
    {
        Handler = handler;
        Frame = frame;

        var json = JsonSerializer.Deserialize<InvokeJavaScriptFunctionTaskMessageParameter>(data);

        TaskId = json.TaskId;
        Uuid = json.FuncId;
        Success = json.Success;

        if (Success)
        {
            ResultData = json.Args;
        }

    }

    protected override void Execute()
    {
        if (JavaScriptFunction.Results.TryRemove(new Tuple<int, long>(TaskId, Frame.Identifier), out var func))
        {
            if (Success)
            {
                func.SetResult(new JavaScriptExecutionResult(Frame, Success, ResultData, string.Empty));
            }
            else
            {
                func.SetResult(new JavaScriptExecutionResult(Frame, Success, null, Resources.Messages.JavaScript_InvokeFailed));

            }
        }

    }
}
