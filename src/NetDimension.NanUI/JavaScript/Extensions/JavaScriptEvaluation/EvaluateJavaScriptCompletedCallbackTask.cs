using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

sealed class EvaluateJavaScriptCompletedCallbackTask : CefTask
{
    public EvaluateJavaScriptCompletedCallbackTask(EvaluateJavaScriptOnBrowserSide handler, CefFrame frame, string data)
    {
        Handler = handler;
        Frame = frame;
        Result = JsonSerializer.Deserialize<JavaScriptEvaluationResultMessage>(data);

    }

    public EvaluateJavaScriptOnBrowserSide Handler { get; }
    public CefFrame Frame { get; }

    public JavaScriptEvaluationResultMessage Result { get; private set; }

    protected override void Execute()
    {
        var bag = EvaluateJavaScriptOnBrowserSide.Results;


        if (bag.TryRemove(new Tuple<int, long>(Result.TaskId, Frame.Identifier), out var tsc))
        {
            tsc.SetResult(new JavaScriptExecutionResult(Frame, Result.Success, Result.Data, Result.Message));
        }
        else
        {
            tsc.SetResult(new JavaScriptExecutionResult(Frame, false, null, "JavaScript evalutation callback handler is not exists."));
        }

    }
}
