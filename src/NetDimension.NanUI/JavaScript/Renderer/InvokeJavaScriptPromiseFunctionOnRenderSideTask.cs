using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.Renderer;

internal class InvokeJavaScriptPromiseFunctionOnRenderSideTask : CefTask
{
    private CefFrame frame;
    private Guid uuid;

    public InvokeJavaScriptPromiseFunctionOnRenderSideTask(CefFrame frame, Guid uuid)
    {
        this.frame = frame;
        this.uuid = uuid;
    }

    public bool Success { get; set; }
    public JavaScriptArray Arguments { get; set; }
    public string Message { get; internal set; }

    protected override void Execute()
    {
        var storedObject = JavaScriptObjectRepositoryOnRenderSide.StoredPromises.Find(x => x.Uuid == uuid);

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
                    storedObject.Reject.ExecuteFunctionWithContext(context, null, new CefV8Value[] { CefV8Value.CreateString(Message) });
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
