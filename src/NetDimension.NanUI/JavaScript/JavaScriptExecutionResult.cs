using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public sealed class JavaScriptExecutionResult
{
    internal CefFrame TargetFrame { get; }

    //internal long TargetFrameId => TargetFrame.Identifier;

    public bool Success { get; }
    public string Message { get; }
    public JavaScriptValue Value { get; }

    internal JavaScriptExecutionResult(CefFrame frame, bool isSuccess, string data, string message)
    {
        TargetFrame = frame;
        Success = isSuccess;
        Message = message;

        if (isSuccess)
        {
            Value = JavaScriptValue.FromJson(data);

            Value.BindToFrame(frame);

        }
        else
        {
            Value = JavaScriptValue.CreateUndefined();
        }
    }


}
