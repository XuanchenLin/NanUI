using NetDimension.NanUI;
using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.JavaScript.WindowBinding;

namespace FormiumClient;

internal class DemoWindowBinding : JavaScriptWindowBindingObject
{
    public override string Name { get; } = "Example/DemoWindow";
    public override string JavaScriptCode { get; } = Properties.Resources.DemoWindowBinding;

    public DemoWindowBinding()
    {
        RegisterHandler(GetTitle);
        RegisterHandler(SetTitle);
        RegisterHandler(Hello);
        RegisterHandler(HelloAsync);
        RegisterHandler(Test);
        RegisterHandler(Add);
        RegisterHandler(Delay);
    }

    private JavaScriptValue GetTitle(Formium owner, JavaScriptArray arguments)
    {
        return new JavaScriptValue(owner.Subtitle);

    }

    // Register sync method that need communicate with Formium object.
    private JavaScriptValue SetTitle(Formium owner, JavaScriptArray arguments)
    {
        var title = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? string.Empty;
        owner.Subtitle = title;
        return null;
    }

    // Register async method that need communicate with Formium object.
    private void HelloAsync(Formium owner, JavaScriptArray arguments, JavaScriptFunctionPromise callback)
    {
        var time = arguments.FirstOrDefault(x => x.IsNumber)?.GetInt() ?? 1000;
        var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";

        var function = arguments.FirstOrDefault(x => x.IsFunction);

        // 添加 Issues #251 的测试
        if (function!= null)
        {
            ((JavaScriptFunction)function).ExecuteAsync();
        }


        Task.Run(async () =>
        {
            await Task.Delay(time);

            MessageBox.Show($"Delayed {time / 1000f} sec.");

            callback.Resovle(new JavaScriptValue(msg));
        });

    }

    // Register sync method that need communicate with Formium object.
    private JavaScriptValue Hello(Formium owner, JavaScriptArray arguments)
    {
        var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";

        owner.InvokeIfRequired(()=> MessageBox.Show(owner.WindowHandle, msg, "Hello from JavaScript", MessageBoxButtons.OK, MessageBoxIcon.Information));

        return null;
    }

    // Register sync method without communicating with Formium object.
    private JavaScriptValue Test(JavaScriptArray arguments)
    {
        return new JavaScriptValue("OK");
    }

    // Register sync method without communicating with Formium object.
    private JavaScriptValue Add(JavaScriptArray arguments)
    {
        if (arguments.Count == 2)
        {
            var retval = arguments[0].GetDouble() + arguments[1].GetDouble();

            return new JavaScriptValue(retval);
        }

        return new JavaScriptValue();
    }

    // Register async method without communicating with Formium object.
    private void Delay(JavaScriptArray arguments, JavaScriptFunctionPromise callback)
    {

        var time = arguments.FirstOrDefault(x => x.IsNumber)?.GetInt() ?? 1000;

        var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";


        Task.Run(async () =>
        {
            await Task.Delay(time);

            callback.Resovle(new JavaScriptValue($"Say: {msg}! after {time / 1000f} sec."));

        });

    }

}
