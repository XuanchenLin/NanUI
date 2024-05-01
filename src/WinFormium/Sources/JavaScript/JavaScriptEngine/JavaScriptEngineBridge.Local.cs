// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Collections.Concurrent;

namespace WinFormium.JavaScript;
internal partial class JavaScriptEngineBridge
{

    internal static ConcurrentDictionary<(int, long), TaskCompletionSource<JavaScriptResult>> JavaScriptExecutionResults { get; } = new();

    private MessageBridgeResponse HandleGetJavaScriptObjectPropertyRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<AccessJavaScriptObjectPropertyMessage>(request.Payload!)!;

        var name = requestData.PropertyName;
        var propUuid = requestData.PropertyUuid;
        var objUuid = requestData.ObjectUuid;

        var func = JavaScriptValue.GetJavaScriptValue(propUuid);
        if (func == null || func.ValueType != JavaScriptValueType.Property || func.GetAssociatedFrame() == null || func.GetType() != typeof(JavaScriptProperty))
        {
            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"Property {name} is not defined."
            };
        }

        var caller = (JavaScriptProperty)func;

        if (caller.Getter != null)
        {
            var retval = caller.Getter.Invoke();
            return new MessageBridgeResponse()
            {
                Data = retval.ToJson()
            };
        }

        return new MessageBridgeResponse
        {
            IsSuccess = false,
            Exception = $"Property {name} is not readable."
        };

    }
    private MessageBridgeResponse HandleSetJavaScriptObjectPropertyRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<AccessJavaScriptObjectPropertyMessage>(request.Payload!)!;

        var name = requestData.PropertyName;
        var propUuid = requestData.PropertyUuid;
        var objUuid = requestData.ObjectUuid;
        var value = JavaScriptValue.FromJson(requestData.Data!);

        var func = JavaScriptValue.GetJavaScriptValue(propUuid);
        if (func == null || func.ValueType != JavaScriptValueType.Property || func.GetAssociatedFrame() == null || func.GetType() != typeof(JavaScriptProperty))
        {
            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"Property {name} is not defined."
            };
        }

        var caller = (JavaScriptProperty)func;

        if (caller.Setter == null)
        {
            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"Property {name} is not writable."
            };
        }

        caller.Setter.Invoke(value);

        return new MessageBridgeResponse();
    }

    private MessageBridgeResponse HandleExecuteJavaScriptPromiseRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<ExecuteJavaScriptFunctionOnLocalMessage>(request.Payload!)!;

        var funcId = requestData.FunctionId;
        var args = requestData.Data != null ? JavaScriptValue.FromJson(requestData.Data).ToArray() ?? new JavaScriptArray() : new JavaScriptArray();
        var func = JavaScriptValue.GetJavaScriptValue(funcId);

        if (func == null || func.ValueType != JavaScriptValueType.Function || func.GetType() != typeof(JavaScriptAsynchronousFunction))
        {
            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = "Function not found."
            };
        }

        if (func.Frame == null)
        {
            func.AssociateToFrame(Bridge.Browser.GetFrame(request.FrameId));
        }

        if (args.Frame == null)
        {
            args.AssociateToFrame(Bridge.Browser.GetFrame(request.FrameId));
        }

        var caller = (JavaScriptAsynchronousFunction)func;

        MessageBridgeResponse response;

        try
        {
            caller.FunctionDelegate.Invoke(args, new JavaScriptPromise(func.Frame!, funcId));

            response = new MessageBridgeResponse
            {
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            response = new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = ex.Message
            };

        }

        return response;
    }

    private MessageBridgeResponse HandleExecuteJavaScriptFunctionRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<ExecuteJavaScriptFunctionOnLocalMessage>(request.Payload!)!;

        var funcId = requestData.FunctionId;
        var args = requestData.Data != null ? JavaScriptValue.FromJson(requestData.Data).ToArray() ?? new JavaScriptArray() : new JavaScriptArray();

        var func = JavaScriptValue.GetJavaScriptValue(funcId);

        if (func == null || func.ValueType != JavaScriptValueType.Function || func.GetType() != typeof(JavaScriptSynchronousFunction))
        {
            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = "Function not found."
            };
        }

        if (args.Frame == null)
        {
            args.AssociateToFrame(Bridge.Browser.GetFrame(request.FrameId));
        }

        var caller = (JavaScriptSynchronousFunction)func;

        MessageBridgeResponse response;

        try
        {


            var retval = caller.FunctionDelegate.Invoke(args);


            if (retval == null)
            {
                retval = new JavaScriptValue(JavaScriptValueType.Null,null);
            }

            response = new MessageBridgeResponse
            {
                Data = retval.ToJson()
            };
        }
        catch (Exception ex)
        {
            response = new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = ex.Message
            };

        }

        return response;
    }


    private void HandleEvaluateJavaScriptMessageOnLocal(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        var data = message.DeserializeData<EvaluateJavaScriptCompleteMessage>()!;

        CefRuntime.PostTask(CefThreadId.UI, new EvaluateJavaScriptCompleteTaskOnLocal(this) { Frame = frame, TaskData = data });
    }

    private void HandleExecuteJavaScriptFunctionMessageOnLocal(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        var data = message.DeserializeData<ExecuteJavaScriptFunctionMessage>()!;

        CefRuntime.PostTask(CefThreadId.UI, new ExecuteJavaScriptCompleteTaskOnLocal(this) { Frame = frame, TaskData = data });

    }

    private Task<JavaScriptResult> EvaluateJavaScriptOnLocal(CefFrame frame, string code, string url = "", int line = 0)
    {
        var tcs = new TaskCompletionSource<JavaScriptResult>();

        var taskId = tcs.GetHashCode();

        if (JavaScriptExecutionResults.TryAdd((taskId, frame.Identifier), tcs))
        {
            MessageBridge.SendMessageToRemote(frame, new BridgeMessage(EVALUATE_JAVASCRIPT_MESSAGE, new EvaluateJavaScriptMessage()
            {
                TaskId = taskId,
                Code = code,
                Url = url,
                Line = line
            }));
        }
        else
        {
            tcs.SetException(new ArgumentException());
        }

        return tcs.Task;
    }

    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
        try
        {
            var tasks = JavaScriptExecutionResults.Where(x => x.Key.Item2 == frame.Identifier).ToList();

            foreach (var task in tasks)
            {
                JavaScriptExecutionResults.TryRemove(task.Key, out var tcs);
                tcs?.SetCanceled();
            }
        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }

    }

    public override void OnBeforeClose(CefBrowser browser)
    {
        try
        {
            var tasks = JavaScriptExecutionResults.Where(x => x.Key.Item1 == browser.Identifier).ToList();

            foreach (var task in tasks)
            {
                JavaScriptExecutionResults.TryRemove(task.Key, out var tcs);
                tcs?.SetCanceled();
            }

            JavaScriptValue.Release(browser);

        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }

    }

    public override void OnRenderProcessTerminated(CefBrowser browser)
    {

    }
}
