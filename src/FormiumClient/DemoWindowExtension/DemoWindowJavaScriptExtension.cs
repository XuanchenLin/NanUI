using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;
using NetDimension.NanUI.JavaScript;

namespace FormiumClient
{
    public class DemoWindowJavaScriptExtension : JavaScriptExtensionBase
    {
        // Set name of this extension.
        public override string Name { get; } = "Example/DemoWindow";

        // Set the JavaScript code of this extension.
        public override string JavaScriptCode { get; } = Properties.Resources.DemoWindowJavaScriptCode;

        public DemoWindowJavaScriptExtension()
        {
            // Register native methods
            RegisterFunctionHandler("Test", Test);
            RegisterFunctionHandler("Add", Add);
            RegisterFunctionHandler("Delay", Delay);
            RegisterFunctionHandler("Hello", Hello);
            RegisterFunctionHandler("HelloAsync", HelloAsync);
            RegisterFunctionHandler("GetTitle", GetTitle);
            RegisterFunctionHandler("SetTitle", SetTitle);
        }

        // Register sync method that need communicate with Formium object.
        private JavaScriptValue GetTitle(Formium owner, JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateString(owner.Subtitle);

        }

        // Register sync method that need communicate with Formium object.
        private JavaScriptValue SetTitle(Formium owner, JavaScriptValue[] arguments)
        {
            var title = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? string.Empty;
            owner.Subtitle = title;
            return null;
        }

        // Register async method that need communicate with Formium object.
        private void HelloAsync(Formium owner, JavaScriptValue[] arguments, JavaScriptAsyncFunctionCallback callback)
        {
            var time = arguments.FirstOrDefault(x => x.IsNumber)?.GetInt() ?? 1000;
            var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";




            Task.Run(async () =>
            {
                await Task.Delay(time);

                MessageBox.Show($"Delayed {time / 1000f} sec.");

                callback.Success(JavaScriptValue.CreateString(msg));
            });

        }

        // Register sync method that need communicate with Formium object.
        private JavaScriptValue Hello(Formium owner, JavaScriptValue[] arguments)
        {
            var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";

            MessageBox.Show(owner.HostWindow, msg, "Hello from JavaScript", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return null;
        }

        // Register sync method without communicating with Formium object.
        private JavaScriptValue Test(JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateString("OK");
        }

        // Register sync method without communicating with Formium object.
        private JavaScriptValue Add(JavaScriptValue[] arguments)
        {
            if (arguments.Length == 2)
            {
                var retval = arguments[0].GetDouble() + arguments[1].GetDouble();

                return JavaScriptValue.CreateNumber(retval);
            }

            return JavaScriptValue.CreateNull();
        }

        // Register async method without communicating with Formium object.
        private void Delay(JavaScriptValue[] arguments, JavaScriptRendererSideAsyncFunctionCallback callback)
        {

            var time = arguments.FirstOrDefault(x => x.IsNumber)?.GetInt() ?? 1000;

            var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";


            Task.Run(async () =>
            {
                await Task.Delay(time);

                callback.Success(JavaScriptValue.CreateString($"Say: {msg}! after {time / 1000f} sec."));

            });

        }


    }
}
