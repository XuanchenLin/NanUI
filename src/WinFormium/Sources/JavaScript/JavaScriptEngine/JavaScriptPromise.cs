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

    internal JavaScriptPromise(CefFrame frame, Guid uuid, ProcessType side = ProcessType.Main)
    {
        Frame = frame;
        Uuid = uuid;
        Side = side;
    }

    /// <summary>
    /// Resolve the promise with the given value.
    /// </summary>
    /// <param name="retvals">
    /// The value to resolve the promise with. This can be any JavaScript value, including undefined.
    /// </param>
    /// <exception cref="InvalidOperationException"></exception>
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

    /// <summary>
    /// Reject the promise with the given reason.
    /// </summary>
    /// <param name="reason">
    /// An optional value that can give more information about the failure.
    /// </param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Reject(string? reason = null)
    {
        if (_isHandled) throw new InvalidOperationException("This method can be only called once.");

        _isHandled = true;



        var message = new BridgeMessage(JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_PROMISE_MESSAGE);

        message.SetData(new ExecuteJavaScriptFunctionMessage { FunctionId = Uuid, Success = false, FrameId = Frame.Identifier, ExceptionText = reason });

        MessageBridge.SendMessageToRemote(Frame, message);

    }
}
