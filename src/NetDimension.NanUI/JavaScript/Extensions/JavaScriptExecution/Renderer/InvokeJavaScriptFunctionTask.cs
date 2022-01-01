using NetDimension.NanUI.Browser.MessagePipe;
using NetDimension.NanUI.JavaScript.Renderer;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

internal class InvokeJavaScriptFunctionTask : CefTask
{


    public InvokeJavaScriptFunctionOnRenderSide Handler { get; }
    public CefFrame Frame { get; }

    private int TaskId { get; }
    private JavaScriptArray Arguments { get; }

    private Guid Uuid { get; }

    public InvokeJavaScriptFunctionTask(InvokeJavaScriptFunctionOnRenderSide handler, CefFrame frame, string arguments)
    {
        Handler = handler;
        Frame = frame;

        dynamic args = JsonConvert.DeserializeObject<dynamic>(arguments);
        TaskId = args.TaskId;
        Uuid = args.FuncId;
        string json = args.Args;



        var retval = JavaScriptValue.FromJson(json);

        if (retval.IsArray)
        {
            Arguments = retval.ToArray();
        }
        else
        {
            Arguments = new JavaScriptArray();
        }


    }

    protected override void Execute()
    {
        var func = JavaScriptObjectRepositoryOnRenderSide.StoredFunctions.Find(x => x.Uuid == Uuid);

        if (func != null)
        {
            func.V8Context.Enter();

            CefV8Value[] arguments = null;
            CefV8Value retval = null;

            try
            {
                arguments = Arguments.ToCefV8Arguments();

                retval = func.FunctionDelegate.ExecuteFunctionWithContext(func.V8Context, null, arguments);

                if (retval != null)
                {
                    var jsvalue = retval.ToJavaScriptValue();

                    var message = new BridgeMessage(InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION, JsonConvert.SerializeObject(new { TaskId = TaskId, FuncId = Uuid, Success = true, FrameId = Frame.Identifier, Args = jsvalue.ToJson() }));

                    Handler.SendBridgeMessage(Frame, message);
                }
                else
                {


                    var message = new BridgeMessage(InvokeJavaScriptFunctionHandler.INVOKE_RENDER_SIDE_FUNCTION, JsonConvert.SerializeObject(new { TaskId = TaskId, FuncId = Uuid, Success = false, FrameId = Frame.Identifier }));

                    Handler.SendBridgeMessage(Frame, message);
                }

            }
            finally
            {
                func.V8Context.Exit();
            }


        }

    }
}
