// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptObjectMapCreationTaskOnRemote : CefTask
{
    public JavaScriptObjectMappingBridge Bridge { get; }

    public JavaScriptObject Objects { get; }
    public required CefFrame Frame { get; init; }

    public JavaScriptObjectMapCreationTaskOnRemote(JavaScriptObjectMappingBridge bridge, string data)
    {
        Bridge = bridge;

        try
        {
            Objects = JavaScriptValue.FromJson(data)!.ToObject();
        }
        catch
        {
            Objects = new JavaScriptObject();
        }
    }

    protected override void Execute()
    {
        if (Frame == null) return;

        CefV8Context context;

        try
        {

            context = Frame.V8Context;
            if (context == null) return;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
        }
        


        context.Enter();
        try
        {
            using var global = context.GetGlobal();

            if (global.HasValue("external"))
            {
                global.DeleteValue("external");
            }

            CefV8Value externalObject = CefV8Value.CreateObject();

            global.SetValue("external", externalObject, CefV8PropertyAttribute.DontDelete | CefV8PropertyAttribute.DontEnum);


            foreach (var key in Objects.PropertyNames)
            {
                var source = Objects.GetValue(key);

                externalObject.SetValue(key, source.ToCefV8Value(), CefV8PropertyAttribute.DontDelete | CefV8PropertyAttribute.DontEnum);
            }

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
