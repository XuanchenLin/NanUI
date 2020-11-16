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
        public override string Name { get; } = "Example/DemoWindow";
        public override string JavaScriptCode { get; } = Properties.Resources.DemoWindowJavaScriptCode;

        public DemoWindowJavaScriptExtension()
        {
            RegisterFunctionHandler("Test", Test);
            RegisterFunctionHandler("Add", Add);
            RegisterFunctionHandler("Delay", Delay);

            RegisterFunctionHandler("Hello", Hello);
            RegisterFunctionHandler("HelloAsync", HelloAsync);

            RegisterFunctionHandler("GetTitle", GetTitle);

            RegisterFunctionHandler("SetTitle", SetTitle);
        }

        private JavaScriptValue GetTitle(Formium owner, JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateString(owner.Subtitle);

        }

        private JavaScriptValue SetTitle(Formium owner, JavaScriptValue[] arguments)
        {
            var title = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? string.Empty;
            owner.Subtitle = title;
            return null;
        }

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

        private JavaScriptValue Hello(Formium owner, JavaScriptValue[] arguments)
        {
            var msg = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? "hello world";

            if (owner.WindowState != FormWindowState.Maximized)
            {
                owner.WindowState = FormWindowState.Maximized;
            }
            else
            {
                owner.WindowState = FormWindowState.Normal;
            }


            return null;
        }

        private JavaScriptValue Test(JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateString("OK");
        }

        private JavaScriptValue Add(JavaScriptValue[] arguments)
        {
            if (arguments.Length == 2)
            {
                var retval = arguments[0].GetDouble() + arguments[1].GetDouble();

                return JavaScriptValue.CreateNumber(retval);
            }

            return JavaScriptValue.CreateNull();
        }

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
