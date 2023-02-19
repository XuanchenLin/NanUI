using NetDimension.NanUI.Browser.MessagePipe;
using System.Collections.Concurrent;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public static class JavaScriptRenderSideFunctionExtension
{
    public static JavaScriptFunction ToFunction(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.IsFunction && jsValue is JavaScriptFunction)
        {

            return (JavaScriptFunction)jsValue;

        }
        else
        {
            throw new InvalidOperationException($"This is not a {nameof(JavaScriptFunction)}.");

        }
    }

    public static Task<JavaScriptExecutionResult> ExecuteAsync(this JavaScriptValue jsValue, params JavaScriptValue[] arguments)
    {
        if (!jsValue.IsFunction && !(jsValue is JavaScriptFunction)) throw new InvalidOperationException($"{nameof(ExecuteAsync)} is only allowed for JavaScriptFunction type.");

        return ((JavaScriptFunction)jsValue).ExecuteAsync(arguments);
    }

    public static Task<JavaScriptExecutionResult> ExecuteAsync(this JavaScriptValue jsValue, JavaScriptArray arguments = null)
    {
        if (!jsValue.IsFunction && !(jsValue is JavaScriptFunction)) throw new InvalidOperationException($"{nameof(ExecuteAsync)} is only allowed for JavaScriptFunction type.");

        return ((JavaScriptFunction)jsValue).ExecuteAsync(arguments);
    }
}




public sealed class JavaScriptFunction : JavaScriptValue
{
    internal static ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>> Results { get; } = new ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>>();



    internal JavaScriptFunction()
        : base(JavaScriptValueType.Function)
    {

    }
    internal bool IsAsyncFunction { get; set; }
    internal CefProcessType Side { get; set; }

    internal Task<JavaScriptExecutionResult> ExecuteAsync(CefFrame frame, params JavaScriptValue[] arguments)
    {
        Frame = frame;
        return ExecuteAsync(arguments);
    }

    internal Task<JavaScriptExecutionResult> ExecuteAsync(CefFrame frame, JavaScriptArray arguments = null)
    {
        Frame = frame;
        return ExecuteAsync(arguments);
    }


    public Task<JavaScriptExecutionResult> ExecuteAsync(params JavaScriptValue[] arguments)
    {
        var array = new JavaScriptArray();

        if (arguments != null)
        {
            foreach (var item in arguments)
            {
                array.Add(item);
            }
        }

        array.BindToFrame(Frame);

        return ExecuteAsync(array);

    }



    public Task<JavaScriptExecutionResult> ExecuteAsync(JavaScriptArray arguments = null)
    {

        var tsc = new TaskCompletionSource<JavaScriptExecutionResult>();
        var taskId = tsc.GetHashCode();

        if (arguments == null)
        {
            arguments = new JavaScriptArray();
        }

        arguments.BindToFrame(Frame);


        if (Results.TryAdd(new Tuple<int, long>(taskId, Frame.Identifier), tsc))
        {
            var message = new BridgeMessage(JavaScriptExecution.InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION, JsonSerializer.Serialize(new JavaScriptFuntionMessageParameter { TaskId = taskId, FuncId = Uuid, FrameId = Frame.Identifier, Args = arguments.ToJson() }));

            FormiumMessageBridge.SendBridgeMessage(CefProcessId.Renderer, Frame, message);

        }
        else
        {
            tsc.SetException(new ArgumentException());
        }

        return tsc.Task;
    }

    internal static void ReleaseTasks(CefFrame frame)
    {

        if (frame == null) return;


        var tasks = Results.Where(x => x.Key.Item2 == frame.Identifier);

        foreach (var task in tasks)
        {
            var tsc = task.Value;

            tsc?.SetResult(null);

            Results.TryRemove(task.Key, out _);
        }

        GC.Collect();
    }

    internal static void ReleaseTasks()
    {

        foreach (var task in Results)
        {
            var tsc = task.Value;

            tsc?.SetResult(null);

            Results.TryRemove(task.Key, out _);
        }

        GC.Collect();
    }
}


public class JavaScriptFuntionMessageParameter
{
    //new { TaskId = taskId, FuncId = Uuid, FrameId = Frame.Identifier, Args = arguments.ToJson() })

    public int TaskId { get; set; }
    public Guid FuncId { get; set; }
    public long FrameId { get; set; }
    public string Args { get; set; }
}
