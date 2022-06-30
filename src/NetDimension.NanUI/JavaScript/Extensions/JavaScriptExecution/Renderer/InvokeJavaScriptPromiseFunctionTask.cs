using NetDimension.NanUI.JavaScript.Renderer;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptExecution;

internal class InvokeJavaScriptPromiseFunctionTask : CefTask
{
    public InvokeJavaScriptFunctionOnRenderSide Handler { get; }
    public CefFrame Frame { get; }

    private JavaScriptArray Arguments { get; }

    private Guid Uuid { get; }

    private bool Success { get; }

    private string ExceptionMessage { get; }


    public InvokeJavaScriptPromiseFunctionTask(InvokeJavaScriptFunctionOnRenderSide invokeJavaScriptFunctionOnRenderSide, CefFrame frame, string arguments)
    {
        Handler = invokeJavaScriptFunctionOnRenderSide;
        Frame = frame;

        dynamic args = JsonConvert.DeserializeObject<dynamic>(arguments);

        Uuid = args.FuncId;
        Success = args.Success;

        string data = args.Data;

        if (!string.IsNullOrEmpty(data))
        {
            var retval = JavaScriptValue.FromJson(data);
            if (retval.IsArray)
            {
                Arguments = retval.ToArray();
            }
            else
            {
                Arguments = new JavaScriptArray();
            }
        }
        else
        {
            ExceptionMessage = args.Message;
        }
    }

    protected override void Execute()
    {
        var storedObject = JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Find(x => x.Uuid == Uuid);

        if (storedObject != null)
        {
            var context = storedObject.V8Context;

            try
            {
                context.Enter();

                if (Success)
                {
                    storedObject.Resolve.ExecuteFunctionWithContext(context, null, Arguments.ToCefV8Arguments());
                }
                else
                {
                    storedObject.Reject.ExecuteFunctionWithContext(context, null, new CefV8Value[] { CefV8Value.CreateString(ExceptionMessage) });
                }

                //storedObject.Resolve.Dispose();
                //storedObject.Reject.Dispose();
                storedObject.PromiseData.Dispose();
            }
            finally
            {
                context.Exit();
            }

            JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Remove(storedObject);
        }


    }
}
