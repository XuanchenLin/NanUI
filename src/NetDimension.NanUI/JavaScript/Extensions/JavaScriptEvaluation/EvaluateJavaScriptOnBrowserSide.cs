using NetDimension.NanUI.Browser.MessagePipe;
using System.Collections.Concurrent;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptEvaluation;

class EvaluateJavaScriptOnBrowserSide : MessageHandlerOnBrowserSide
{

    internal static ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>> Results { get; } = new ConcurrentDictionary<Tuple<int, long>, TaskCompletionSource<JavaScriptExecutionResult>>();


    EvaluateJavaScriptHandler MessageHandler => (EvaluateJavaScriptHandler)this.MessageHandlerWrapper;

    public EvaluateJavaScriptOnBrowserSide(EvaluateJavaScriptHandler messageHandlerWrapper)
        : base(messageHandlerWrapper)
    {

    }

    public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(CefFrame frame, string code)
    {
        var tsc = new TaskCompletionSource<JavaScriptExecutionResult>();

        var taskId = tsc.GetHashCode();

        if (Results.TryAdd(new Tuple<int, long>(taskId, frame.Identifier), tsc))
        {
            var message = new BridgeMessage(MessageHandler.EVALUATE_JS_MESSAGE, JsonConvert.SerializeObject(new { TaskId = taskId, Code = code }));

            SendBridgeMessage(frame, message);

        }
        else
        {
            tsc.SetException(new ArgumentException());
        }

        return tsc.Task;
    }


    #region Overrides

    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame)
    {
        ClearTasks(frame);
    }

    public override void OnBeforeClose(CefBrowser browser)
    {
        foreach (var id in browser.GetFrameIdentifiers())
        {
            var frame = browser.GetFrame(id);

            ClearTasks(frame);
        }
    }

    private void ClearTasks(CefFrame frame)
    {
        var tasks = Results.Where(x => x.Key.Item2 == frame.Identifier);

        foreach (var task in tasks)
        {
            var tsc = task.Value;

            tsc?.SetResult(null);

            Results.TryRemove(task.Key, out _);
        }

        GC.Collect();
    }

    public override void OnMessageReceived(string message, CefFrame frame, string arguments)
    {
        if (message == MessageHandler.EVALUATE_JS_COMPLETED_MESSAGE)
        {
            CefRuntime.PostTask(CefThreadId.UI, new EvaluateJavaScriptCompletedCallbackTask(this, frame, arguments));
        }
    }

    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }

    #endregion

}
