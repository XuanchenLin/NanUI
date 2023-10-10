// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


namespace WinFormium.JavaScript;
public class JavaScriptPromise
{
    private bool _isHandled = false;

    internal ProcessType Side { get; }
    internal CefFrame Frame { get; }
    internal Guid Uuid { get; }

    public JavaScriptPromise(CefFrame frame, Guid uuid, ProcessType side = ProcessType.Main)
    {
        Frame = frame;
        Uuid = uuid;
        Side = side;
    }

    public void Resolve(params JavaScriptValue[] retvals)
    {
        if (_isHandled) throw new InvalidOperationException("This method can be only called once.");

        _isHandled = true;

        var arguments = new JavaScriptArray();

        foreach (var retval in retvals)
        {
            arguments.Add(retval);
        }

        var message = new BridgeMessage(JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_PROMISE_MESSAGE);

        message.SetData(new ExecuteJavaScriptFunctionMessage { FunctionId = Uuid, Success = true, FrameId = Frame.Identifier, Data = arguments.ToJson() });

        MessageBridge.SendMessageToRemote(Frame, message);

    }

    public void Reject(string? reason = null)
    {
        if (_isHandled) throw new InvalidOperationException("This method can be only called once.");

        _isHandled = true;



        var message = new BridgeMessage(JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_PROMISE_MESSAGE);

        message.SetData(new ExecuteJavaScriptFunctionMessage { FunctionId = Uuid, Success = false, FrameId = Frame.Identifier, ExceptionText = reason });

        MessageBridge.SendMessageToRemote(Frame, message);

    }
}
