// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptPostBrowserMessageTaskOnRemote : CefTask
{
    public required CefFrame Frame { get; init; }
    public required JavaScriptPostBrowserMessageMessage TaskData { get; init; }
    public JavaScriptWindowBindingObjectBridge Bridge { get; }

    public JavaScriptPostBrowserMessageTaskOnRemote(JavaScriptWindowBindingObjectBridge bridge)
    {
        Bridge = bridge;
    }

    protected override void Execute()
    {
        var context = Frame.V8Context ?? CefV8Context.GetCurrentContext();


        context.Enter();

        try
        {
            var retval = TaskData.Data ==null ? new JavaScriptValue() :  JavaScriptValue.FromJson(TaskData.Data);

            using var global = context.GetGlobal();

            using var formium = global.GetValue("formium");

            if (formium == null) return;

            using var hostWindow = formium.GetValue("hostWindow");

            if (hostWindow == null) return;

            using var internalMethods = hostWindow.GetValue("internal");

            if (internalMethods == null) return;

            using var dispatchMessage = internalMethods.GetValue("dispatchMessage");

            if (dispatchMessage == null) return;

            using var args = retval.ToCefV8Value();

            dispatchMessage.ExecuteFunctionWithContext(context, hostWindow, new CefV8Value[] { CefV8Value.CreateString(TaskData.Message), args });

        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }
        finally
        {
            context.Exit();
        }
    }
}
