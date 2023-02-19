using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

sealed class EvaluateJavaScriptTask : CefTask
{
    public EvaluateJavaScriptOnRenderSide Handler { get; }
    public CefFrame Frame { get; }


    private int TaskId { get; }
    private string Code { get; }
    public EvaluateJavaScriptTask(EvaluateJavaScriptOnRenderSide handler, CefFrame frame, string data)
    {
        Handler = handler;
        Frame = frame;

        var args = JsonSerializer.Deserialize<EvaluateJavaScriptMessageParameter>(data);

        TaskId = args.TaskId;
        Code = args.Code;
    }



    protected override void Execute()
    {
        var v8 = Frame.V8Context;

        var message = new BridgeMessage(Handler.MessageHandler.EVALUATE_JS_COMPLETED_MESSAGE);


        if (v8.TryEval(Code, Frame.Url, 0, out var retval, out var v8Exception))
        {
            v8.Enter();

            try
            {
                message.Data = JsonSerializer.Serialize(new JavaScriptEvaluationResultMessage
                {
                    TaskId = TaskId,
                    Success = true,
                    Data = retval.ToJavaScriptValue().ToJson()
                });
            }
            catch (Exception ex)
            {
                message.Data = JsonSerializer.Serialize(new JavaScriptEvaluationResultMessage
                {
                    TaskId = TaskId,
                    Success = false,
                    Message = ex.Message
                });
            }
            finally
            {
                v8.Exit();
            }
        }
        else
        {
            message.Data = JsonSerializer.Serialize(new JavaScriptEvaluationResultMessage
            {
                TaskId = TaskId,
                Success = false,
                Message = v8Exception.Message,
                Exception = new JavaScriptException
                {
                    StartColumn = v8Exception.StartColumn,
                    StartPosition = v8Exception.StartPosition,
                    EndColumn = v8Exception.EndColumn,
                    EndPosition = v8Exception.EndPosition,
                    LineNumber = v8Exception.LineNumber,
                    ScriptResourceName = v8Exception.ScriptResourceName,
                    SourceLine = v8Exception.SourceLine,
                }
            });
        }


        Handler.SendBridgeMessage(Frame, message);

        retval?.Dispose();
        v8Exception?.Dispose();
    }
}
