// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class ExecuteJavaScriptFunctionTaskOnRemote : CefTask
{
    public JavaScriptEngineBridge Bridge { get; }
    public required CefFrame Frame { get; init; }
    public required ExecuteJavaScriptFunctionMessage TaskData { get; init; }

    public ExecuteJavaScriptFunctionTaskOnRemote(JavaScriptEngineBridge bridge)
    {
        Bridge = bridge;
    }

    protected override void Execute()
    {
        var func = JavaScriptValue.GetJavaScriptValue(TaskData.FunctionId);


        if (func == null || func.ValueType!= JavaScriptValueType.Function || func.GetType()!= typeof(JavaScriptFunctionInvokerOnRemote)) return;


        var caller = (JavaScriptFunctionInvokerOnRemote)func;

        var message = new BridgeMessage(JavaScriptEngineBridge.EXECUTE_JAVASCRIPT_FUNCTION_MESSAGE);


        try
        {
            var args = JavaScriptValue.FromJson(TaskData.Data!);


            CefV8Value[]? arguments;

            var context = Frame.V8Context ?? CefV8Context.GetCurrentContext();

            context.Enter();


            if (args.ValueType != JavaScriptValueType.Array || args == null)
            {
                arguments = new CefV8Value[] { };
            }
            else
            {
                var array = args.ToArray();
                array.AssociateToFrame(Frame);


                arguments = array.ToCefV8Arguments();

            }

            context.Exit();


            var retval = caller.FunctionBody.ExecuteFunctionWithContext(context, caller.FunctionBody, arguments);



            if (retval != null)
            {
                message.SetData(new ExecuteJavaScriptFunctionMessage
                {
                    TaskId = TaskData.TaskId,
                    FunctionId = TaskData.FunctionId,
                    FrameId = Frame.Identifier,
                    Success = true,
                    Data = retval!.ToJavaScriptValue().ToJson()

                });
            }
            else
            {
                message.SetData(new ExecuteJavaScriptFunctionMessage
                {
                    TaskId = TaskData.TaskId,
                    FunctionId = TaskData.FunctionId,
                    FrameId = Frame.Identifier,
                    Success = false,
                    ExceptionText = "Cannot execute function."
                });
            }

            Bridge.SendMessageToLocal(Frame, message);

        }
        catch(Exception ex)
        {
            message.SetData(new ExecuteJavaScriptFunctionMessage
            {
                TaskId = TaskData.TaskId,
                FunctionId = TaskData.FunctionId,
                FrameId = Frame.Identifier,
                Success = false,
                ExceptionText = ex.Message
            });

            Bridge.SendMessageToLocal(Frame, message);

        }

    }
}