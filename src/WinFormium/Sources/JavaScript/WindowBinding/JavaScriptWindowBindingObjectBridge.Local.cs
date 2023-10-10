// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptWindowBindingObjectBridge
{
    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
    }

    public override void OnBeforeClose(CefBrowser browser)
    {
    }
    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }


    public Formium InvokerInstance { get; }


    private MessageBridgeResponse HandleExecuteWindowBindingObjectAsynchronousFunctionRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<JavaScriptWindowBindingObjectMessage>(request.Payload!)!;

        var objectName = requestData.ObjectName;
        var funcId = requestData.Uuid;
        var funcName = requestData.FunctionName;
        var data = requestData.Arguments;
        var frame = Bridge.Browser.GetFrame(request.FrameId);
        var args = JavaScriptValue.FromJson(data).ToArray();

        var windowBindingObject = WindowBindingObjects.SingleOrDefault(x => x.Name == objectName);

        if (windowBindingObject == null)
        {

            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"[{nameof(WinFormium)}]: The `{objectName}` window binding object is not exists."
            };
        }

        args.AssociateToFrame(frame);

        var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

        if (function == null)
        {

            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"[{nameof(WinFormium)}]: The `{funcName}` function is not defined."
            };
        }

        if (function.FunctionType == JavaScriptWindowBindingObjectFunctionType.AsynchronousFunctionOnLocal)
        {
            try
            {
                function.AsynchronousFunctionOnLocal!.Invoke(InvokerInstance!, args, new JavaScriptPromise(frame, funcId));

                return new MessageBridgeResponse();
            }
            catch (Exception ex)
            {
                return new MessageBridgeResponse
                {
                    IsSuccess = false,
                    Exception = $"[{nameof(WinFormium)}]: {ex.Message}"
                };
            }
        }

        return new MessageBridgeResponse
        {
            IsSuccess = false,
            Exception = $"[{nameof(WinFormium)}]: The handler of `{funcName}` function is not defined."
        };
    }

    private MessageBridgeResponse HandleExecuteWindowBindingObjectSynchronousFunctionRequestOnLocal(MessageBridgeRequest request)
    {
        var requestData = JsonSerializer.Deserialize<JavaScriptWindowBindingObjectMessage>(request.Payload!)!;

        var objectName = requestData.ObjectName;
        var funcId = requestData.Uuid;
        var funcName = requestData.FunctionName;
        var data = requestData.Arguments;
        var frame = Bridge.Browser.GetFrame(request.FrameId);
        var args = JavaScriptValue.FromJson(data).ToArray();


        var windowBindingObject = WindowBindingObjects.SingleOrDefault(x => x.Name == objectName);

        if (windowBindingObject == null)
        {

            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"[{nameof(WinFormium)}]: The `{objectName}` window binding object is not exists."
            };
        }

        args.AssociateToFrame(frame);

        var function = windowBindingObject.WindowBindingFunctions.SingleOrDefault(x => x.FunctionName == funcName);

        if (function == null)
        {

            return new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = $"[{nameof(WinFormium)}]: The `{funcName}` function is not defined."
            };
        }



        if (function.FunctionType == JavaScriptWindowBindingObjectFunctionType.SynchronousFunctionOnLocal)
        {

            try
            {
                var retval = function.SynchronousFunctionOnLocal!.Invoke(InvokerInstance!, args) ?? new JavaScriptValue();

                return new MessageBridgeResponse()
                {
                    Data = retval.ToJson()
                };
            }
            catch (Exception ex)
            {
                return new MessageBridgeResponse
                {
                    IsSuccess = false,
                    Exception = $"[{nameof(WinFormium)}]: {ex.Message}"
                };
            }
        }



        return new MessageBridgeResponse
        {
            IsSuccess = false,
            Exception = $"[{nameof(WinFormium)}]: The handler of `{funcName}` function is not defined."
        };


    }
}
