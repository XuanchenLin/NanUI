// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptEngineBridge : MessageBridgeHandler
{
    public static readonly string EVALUATE_JAVASCRIPT_MESSAGE = "WinFormium.EvaluateJavaScript";
    public static readonly string EVALUATE_JAVASCRIPT_COMPLETE_MESSAGE = "WinFormium.EvaluateJavaScriptComplete";

    public static readonly string EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE = "WinFormium.ExecuteJavaScriptFunction";
    public static readonly string EXECUTE_JAVASCRIPT_PROMISE_MESSAGE = "WinFormium.ExecuteJavaScriptPromise";

    public static readonly string GET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE = "WinFormium.GetJavaScriptObjectProperty";
    public static readonly string SET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE = "WinFormium.SetJavaScriptObjectProperty";

    public JavaScriptEngineBridge(MessageBridge bridge) : base(bridge)
    {
        // local
        if (Bridge.Side == ProcessType.Main)
        {
            RegisterMessageHandler(EVALUATE_JAVASCRIPT_COMPLETE_MESSAGE, HandleEvaluateJavaScriptMessageOnLocal);
            RegisterMessageHandler(EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE, HandleExecuteJavaScriptFunctionMessageOnLocal);

            // Handle JavaScript Function & Promise Function execution request on local
            RegisterRequestHandler(EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE, HandleExecuteJavaScriptFunctionRequestOnLocal);

            RegisterRequestHandler(EXECUTE_JAVASCRIPT_PROMISE_MESSAGE, HandleExecuteJavaScriptPromiseRequestOnLocal);

            // Handle JavaScript Object Property access request on local
            RegisterRequestHandler(GET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE, HandleGetJavaScriptObjectPropertyRequestOnLocal);
            RegisterRequestHandler(SET_JAVASCRIPT_OBJECT_PROPERTY_MESSAGE, HandleSetJavaScriptObjectPropertyRequestOnLocal);
        }


        // remote

        if (Bridge.Side == ProcessType.Renderer)
        {
            // Handle JavaScript evaluation on remote
            RegisterMessageHandler(EVALUATE_JAVASCRIPT_MESSAGE, HandleEvaluateJavaScriptMessageOnRemote);

            // Handle JavaScript Function & Promise Function execution request on remote
            RegisterMessageHandler(EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE, HandleExecuteJavaScriptFunctionMessageOnRemote);

            RegisterMessageHandler(EXECUTE_JAVASCRIPT_PROMISE_MESSAGE, HandleExecuteJavaScriptPromiseMessageOnRemote);
        }

    }


    public Task<JavaScriptResult> EvaluateJavaScriptAsync(CefFrame frame, string code, string url = "about:blank", int line = 0)
    {
        return EvaluateJavaScriptOnLocal(frame, code, url, line);
    }

}

