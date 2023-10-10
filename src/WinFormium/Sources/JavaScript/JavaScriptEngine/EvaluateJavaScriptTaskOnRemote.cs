// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class EvaluateJavaScriptTaskOnRemote : CefTask
{
    public JavaScriptEngineBridge Bridge { get; }

    public required CefFrame Frame { get; init; }

    public required EvaluateJavaScriptMessage TaskData { get; init; }

    public EvaluateJavaScriptTaskOnRemote(JavaScriptEngineBridge handler)
    {
        Bridge = handler;
    }

    protected override void Execute()
    {
        var v8 = Frame.V8Context;

        var message = new BridgeMessage(JavaScriptEngineBridge.EVALUATE_JAVASCRIPT_COMPLETE_MESSAGE);

        var isExecutedSuccess = v8.TryEval(TaskData.Code, TaskData.Url, TaskData.Line, out var retval, out var v8Exception);

        if (isExecutedSuccess)
        {
            if (v8.Enter())
            {
                message.SetData(new EvaluateJavaScriptCompleteMessage
                {
                    TaskId = TaskData.TaskId,
                    Success = true,
                    Data = retval!.ToJavaScriptValue().ToJson()
                });

                v8.Exit();
            }
            else
            {
                message.SetData(new EvaluateJavaScriptCompleteMessage
                {
                    TaskId = TaskData.TaskId,
                    Success = false,
                    Message = "Cannot enter v8 context."
                });
            }


        }
        else
        {
            message.SetData(new EvaluateJavaScriptCompleteMessage
            {
                TaskId = TaskData.TaskId,
                Success = false,
                Message = v8Exception!.Message,
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


        Bridge.SendMessageToLocal(Frame, message);

        //retval?.Dispose();
        //v8Exception?.Dispose();
        v8?.Dispose();
    }
}

