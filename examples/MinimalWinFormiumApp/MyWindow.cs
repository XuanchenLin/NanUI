using WinFormium;
using WinFormium.CefGlue;
using WinFormium.Forms;
using WinFormium.JavaScript;


namespace MinimalWinFormiumApp;
internal class MyWindow : Formium
{
    public MyWindow() { }

    public MyWindow(ChromiumEnvironment env) // 依赖注入测试; Dependency Injection Testing;
    {

        //默认测试，加载普通网页
        //Default test, load web page
        //Url = "https://www.bing.com";

        //测试加载本地资源
        //Test loading local resources
        //Url = "http://static.app.local/";

        //测试嵌入资源
        //Test loading embedded resources
        //Url = "http://embedded.app.local/";

        //错误地址测试，指定了错误页面的地址，如果页面加载失败，将会自动显示WinFormium内置的错误页面。
        //Error address test specifies the address of the error page. If the page fails to load, WinFormium's built-in error page will be automatically displayed.
        //Url = "http://static1.app.local/";

        //注意，默认没有指定任何Url，新版WinFormium将会自动加载一个欢迎页面。
        //If no URL is specified, WinFormium will automatically load a welcome page.


        //这个事件对应WinForm的Load事件，对应NanUI的OnReady抽象方法
        //OnReady of old version NanUI
        Loaded += MyWindow_Loaded;


        PageLoadEnd += MyWindow_PageLoadEnd;


    }

    private void MyWindow_Loaded(object? sender, BrowserEventArgs e)
    {
        var frame = e.Browser.GetMainFrame();

        // 测试JS对象映射
        // Test JS object mapping

        TestJSObjectMapping(frame);

        // 注册前端消息处理器，比如这里注册bbb，那么在前端调用 formium.postMessage("bbb", "[任意数据类型/字符/数字/数组/对象]")来向这个处理器发送消息。
        // Register front-end message handler. For example, by registering “bbb” here, you can send messages to this handler from the front-end using the formium.postMessage("bbb", "[any data type/string/number/array/object]") method.
        RegisterJavaScriptMessagHandler("bbb", args =>
        {

        });

        // 注册前端请求处理器，请求处理和消息处理器的不同在于，消息处理器不需要返回结果，而请求处理器需要返回结果。
        // Register front-end request handler. The difference between a request handler and a message handler is that a request handler needs to return a result.

        // 请求处理器提供了2中不同的接口返回数据，一种是同步接口，一种是异步接口。
        // The request handler provides two different interfaces for returning data: synchronous and asynchronous.

        // 这是同步接口，前端使用 formium.sendHostWindowRequest("rrr", "[任意数据类型/字符/数字/数组/对象]") 来向这个处理器发送请求，这个请求会阻塞前端线程，直到这个处理器返回结果。
        // This is the synchronous interface. The front-end can send a request to this handler using formium.sendHostWindowRequest("rrr", "[any data type/string/number/array/object]"), and this request will block the front-end thread until the handler returns a result.
        RegisterJavaScriptRequestHandler("rrr", args => "OK sync");

        // 这是异步接口，前端使用 formium.sendHostWindowRequestAsync("aaa", "[任意数据类型/字符/数字/数组/对象]") 来向这个处理器发送请求，这个请求不会阻塞前端线程，前端线程会继续执行，使用promise参数的resolve([data: any])或者reject([reason: string])方法来指定这个异步是否成功执行。
        // This is the asynchronous interface. The front-end can send a request to this handler using formium.sendHostWindowRequestAsync("aaa", "[any data type/string/number/array/object]"), and this request will not block the front-end thread. The front-end thread will continue executing, and you can use the resolve([data: any]) or reject([reason: string]) methods of the promise parameter to specify whether this asynchronous operation is successfully executed.

        // 前端的formium.sendHostWindowRequestAsync()方法将返回一个可等待的promise对象，可以使用await关键字来等待这个promise对象的执行结果。当然，使用传统的then/catch方法也可以。
        // The front-end's formium.sendHostWindowRequestAsync() method will return a awaitable promise object. You can use the await keyword to wait for the execution result of this promise object. Alternatively, you can also use the traditional then/catch methods.
        RegisterJavaScriptRequestHandler("aaa", async (args, promise) => {

            await Task.Delay(3000);

            promise.Resolve("OK async");

        });


    }

    private void MyWindow_PageLoadEnd(object? sender, PageLoadEndEventArgs e)
    {
        //测试JS引擎
        //Test JS engine
        TestJSEngine();

        //测试从后端Post消息到前端，前端需要使用formium.addMessageDispatcher("test", msg=>{})方法来接收消息。
        //Test post message from back-end to front-end, the front-end needs to use the formium.addMessageDispatcher("test", msg=>{}) method to receive the message.
        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(5000);

                PostJavaScriptMessage("test", DateTime.Now);
            }

        });

    }

    // 使用对象映射的方式来为WinFormium提供可前后端交互的JavaScript对象。
    // Use object mapping to provide JavaScript objects that can interact with the front and back ends for WinFormium.
    private void TestJSObjectMapping(CefFrame frame)
    {
        var obj = new JavaScriptObject
        {
            { "name", "linxuanchen" },
            { "age", 38 }
        };

        obj.DefineProperty("now", () => DateTime.Now);
        obj.DefineProperty("title", () => AppTitle, v => AppTitle = ((string?)v ?? string.Empty));

        obj.Add("sync", (args) =>
        {
            var retval = string.Join(",", args.Select(x => x.GetString()));

            InvokeOnUIThread(() =>
            {
                MessageBox.Show(this, $"Caller arguments:{retval}", "JavaScriptSyncFunction");
            });

            return null;
        });

        obj.Add("exit", args =>
        {
            WinFormiumApp.Shutdown();
            return null;
        });

        obj.Add("async", async (args, promise) =>
        {
            var retval = string.Join(",", args.Select(x => x.GetString()));

            var rnd = new Random();

            var x = rnd.Next(1, 6);

            await Task.Delay(x * 500);

            if (x == 5)
            {
                promise.Reject("Rejected by random.");
            }
            else
            {
                promise.Resolve(new string(retval.Reverse().ToArray()) ?? "No argument.");
            }
        });

        // 与0.9相比，注册对象前需要先调用BeginRegisterJavaScriptObject()方法，注册完毕后需要调用EndRegisterJavaScriptObject()方法，这样可以确保EndRegisterJavaScriptObject时才像渲染进程发送注册对象的消息。
        // Compared with 0.9, you need to call the BeginRegisterJavaScriptObject() method before registering the object, and call the EndRegisterJavaScriptObject() method after the registration is completed. This ensures that the registration object is sent to the rendering process when EndRegisterJavaScriptObject is called.
        var hbrjso = BeginRegisterJavaScriptObject(frame);

        RegisterJavaScriptObject(hbrjso, "test", obj);

        EndRegisterJavaScriptObject(hbrjso);
    }


    private async void TestJSEngine()
    {


        // 执行带结果的JavaScript表达式，如果不需要返回结果，可以使用ExecuteJavaScript方法。
        // Execute JavaScript expressions with results. If you don't need to return results, you can use the ExecuteJavaScript method.
        var retval = await EvaluateJavaScriptAsync("3+4");

        // 获取返回结果，类型为JavaScriptValue，可以使用JavaScriptValue的各种方法来获取返回结果的值。
        // Retrieve the return result, which is of type JavaScriptValue. You can use various methods of JavaScriptValue to access the value of the return result.

        // 这个版本为JavaScriptValue提供了各类显式、隐式转换操作符，可以直接将JavaScriptValue转换为各种基本类型。
        // This version provides various explicit and implicit conversion operators for JavaScriptValue, allowing direct conversion of JavaScriptValue to various primitive types.

        // 例如下面的代码将JavaScriptValue转换为int类型。
        // For example, the following code converts JavaScriptValue to int type.
        int value1 = retval.ReturnValue;

        // 获取页面标题
        // Get the page title.
        var retval2 = await EvaluateJavaScriptAsync("document.title");

        // 显式转换为可空string类型
        // Explicitly convert to nullable string type.
        string? value2 = retval2.ReturnValue;

        // 返回一个函数对象
        // Return a function object.
        var retval3 = await EvaluateJavaScriptAsync("(a)=>{ const v = a.apply(); console.log(`value:${v}`); }");

        // 获取函数对象的Invoker，可以通过该Invoker类型的ExecuteAsync调用这个函数对象。这里使用了JavaScriptSynchronousFunction，表示这个函数对象是同步执行的，如果是异步执行的，可以使用JavaScriptAsynchronousFunction，根据函数对象的参数类型来选择。
        // Get the Invoker of the function object, which can be used to invoke the function object using the ExecuteAsync method of the Invoker type. Here, we are using JavaScriptSynchronousFunction, which indicates that the function object is executed synchronously. If it is executed asynchronously, you can use JavaScriptAsynchronousFunction and choose based on the parameter types of the function object.
        var retval4 = await ((JavaScriptFunctionInvoker)retval3.ReturnValue).ExecuteAsync(new JavaScriptSynchronousFunction((a) => "Callback function for retval3."));

        // 函数对象的返回结果，这里是string类型
        // The return result of the function object is of string type.
        string? value3 = retval4.ReturnValue;

        // 返回一个函数对象，这个函数对象是异步执行的，所以使用JavaScriptAsynchronousFunction
        // Return a function object that is executed asynchronously, using JavaScriptAsynchronousFunction.
        var retval5 = await EvaluateJavaScriptAsync("(callback)=>{ callback().then(x=>console.log(`success:${x}`)).catch(err=>console.log(`success:${err}`)); }");

        // 在JavaScriptAsynchronousFunction中提供了一个Promise参数，可以使用这个参数的Resolve方法来返回结果，也可以使用Reject方法来返回错误。因为是异步的，所以这里使用了await关键字来等待这个异步函数的执行结果。
        // In JavaScriptAsynchronousFunction, a Promise parameter is provided. You can use the Resolve method of this parameter to return the result, or use the Reject method to return an error. Since it is asynchronous, the await keyword is used here to wait for the execution result of this asynchronous function.

        // promise resovle
        var retval6 = await ((JavaScriptFunctionInvoker)retval5.ReturnValue).ExecuteAsync(new JavaScriptAsynchronousFunction(async (args, promise) =>
        {
            await Task.Delay(5000);
            promise.Resolve("Resolved for retval5.");
        }));

        // promise reject
        var retval7 = await ((JavaScriptFunctionInvoker)retval5.ReturnValue).ExecuteAsync(new JavaScriptAsynchronousFunction(async (args, promise) =>
        {
            await Task.Delay(1000);
            promise.Reject("Rejected for retval5.");
        }));


        InvokeOnUIThread(() => { MessageBox.Show(this, $"value1={value1} value2={value2}"); });
    }

    protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
    {
        var style = builder.UseSystemForm();

        // 移除系统窗体的标题栏
        // To remove the title bar of a system window and achieve a borderless form
        style.TitleBar = false;

        // 指定系统深浅色主题模式，默认将自动检测当前系统的深浅色主题模式。也可以手动指定
        // Specify the system's light or dark theme mode. By default, it will automatically detect the current system's theme mode. It can also be manually specified.
        //style.ColorMode = FormiumColorMode.Dark;


        // 是否启用网页的页面标题
        // Whether to enable the page title of the webpage.
        //style.UsePageTitle = true;

        //style.StartCentered = true;

        // 是否启用Kiosk模式，启用后将禁用任务栏
        // Whether to enable Kiosk mode, which disables the taskbar when enabled.
        //var style = builder.UseKisokForm();
        //style.DisableTaskBar = true;

        return style;
    }
}
