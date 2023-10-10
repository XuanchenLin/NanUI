// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptEngineBridge
{
    internal static List<JavaScriptPromiseContext> JavaScriptPromiseContexts { get; } = new ();



    public override void OnRemoteContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        ReleaseStoredObjectByContext(frame);
    }

    public override void OnRemoteContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        ReleaseStoredObjectByContext(frame);
    }

    private void ReleaseStoredObjectByContext(CefFrame frame)
    {
        try
        {
            JavaScriptValue.Release(frame);

            var storedPromises = JavaScriptPromiseContexts.Where(x => x.Context.IsSame(frame.V8Context)).ToArray();


            for (var i = 0; i < storedPromises.Length; i++)
            {
                var func = storedPromises[i];
                JavaScriptPromiseContexts.Remove(func);
                func?.Dispose();
            }
        }
        catch(Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }
    }

    private void HandleEvaluateJavaScriptMessageOnRemote(CefBrowser browser, CefFrame frame, CefProcessId processId, BridgeMessage message)
    {
        var data = message.DeserializeData<EvaluateJavaScriptMessage>()!;


        CefRuntime.PostTask(CefThreadId.Renderer, new EvaluateJavaScriptTaskOnRemote(this) { Frame = frame, TaskData = data });
    }

    private void HandleExecuteJavaScriptFunctionMessageOnRemote(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {

        var data = message.DeserializeData<ExecuteJavaScriptFunctionMessage>()!;

        CefRuntime.PostTask(CefThreadId.Renderer, new ExecuteJavaScriptFunctionTaskOnRemote(this) { Frame = frame, TaskData = data });
    }

    private void HandleExecuteJavaScriptPromiseMessageOnRemote(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        var data = message.DeserializeData<ExecuteJavaScriptFunctionMessage>()!;

        CefRuntime.PostTask(CefThreadId.Renderer, new ExecuteJavaScriptFunctionPromiseTaskOnRemote(this) { Frame = frame, TaskData = data });
    }
}
