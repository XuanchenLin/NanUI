# 注册 JavaScript 扩展

[[返回目录](README.md)]

- [注册 JavaScript 扩展](#注册-javascript-扩展)
  - [JavaScript 代码部分](#javascript-代码部分)
  - [JavaScript 扩展处理程序](#javascript-扩展处理程序)
  - [调用扩展](#调用扩展)
  - [延伸](#延伸)

注册 JavaScript 扩展与注册 JavaScript 对象类似，但又有本质的区别。JavaScript 扩展注册后所有的 Formium 窗体都可以访问到注册的对象；而注册 JavaScript 对象仅对当前 Formium 窗体有效。

与注册对象相比扩展的注册过程比较复杂，需要编写对应的 JavaScript 代码，在代码中指定`native`方法，调用该方法后会通知`CefV8Handler`的处理程序对操作进行处理和反馈。

NanUI 封装和简化了这个过程，您无需处理繁琐的`CefV8Handler`处理程序以及头疼的数据转换，只需编写好 JavaScript 代码并继承抽象类`JavaScriptExtensionBase`，在抽象属性`Name`和`JavaScriptCode`分别指定扩展的唯一名称和上面说的 JavaScript 逻辑代码，剩下的就是编写 JavaScript 对应的`native`方法即可。

## JavaScript 代码部分

下面示例展示了如何编写 JavaScript 扩展的结构代码部分。可以看到示例代码中有定义方法和属性，与传统 JavaScript 代码不同的是，每个方法、属性里都添加了`native`关键字，该关键字指示此方法为`本地方法`，执行和调用时会通知`CefV8Handler`进行处理。而 NanUI 使用`JavaScriptExtensionBase`封装并接收了`CefV8Handler`的处理结果提供给 .NET 环境使用。

```JS
var DemoWindow = DemoWindow || {};

(($this) => {

    $this.test = (msg1, msg2) => {
        native function Test();
        return Test(msg1, msg2);
    };

    $this.add = (a, b) => {
        native function Add();
        return Add(a, b);
    };

    $this.delay = (time, message) => {
        native function Delay();
        return Delay(time, message);
    };

    $this.hello = (message) => {
        native function Hello();
        return Hello(message);
    };

    $this.helloAsync = (time, message) => {
        native function HelloAsync();
        return HelloAsync(time, message);
    };

    $this.__defineGetter__("title", () => {
        native function GetTitle();
        return GetTitle();
    });

    $this.__defineSetter__("title", (title) => {
        native function SetTitle();
        return SetTitle(title);
    });

})(DemoWindow);
```

需要特别注意的是，JavaScript 扩展的结构代码在执行时 DOM 并不存在，因此任何调用 DOM 的 JavaScript 代码都将导致渲染进程崩溃。如果一定要在 JavaScript 扩展的结构代码操作 DOM，需要确保 DOM 已经存在后才能安全的操作。

## JavaScript 扩展处理程序

扩展处理程序类继承自抽象类`JavaScriptExtensionBase`。`Name`属性为该扩展的唯一代码，如果已经存在相同 Name 的扩展，则注册时将抛出异常。`JavaScriptCode`即上面小结中的结构代码。

针对 JavaScript 结构代码中`native`关键字指向的方法，在此类中需要使用`RegisterFunctionHandler`方法注册与之名称相对应的处理函数。

如果注册的方法需要与当前 Formium 窗体产生交互的（例如修改窗体标题、设置或获取窗体属性、调用窗体方法等）则需要使用`Func<Formium, JavaScriptValue[],JavaScriptValue>`代理方法（同步）和`Action<Formium, JavaScriptValue[], JavaScriptAsyncFunctionCallback>`代理方法（异步）。这两个方法将在浏览器进程中执行，所以可以操作浏览器进程相关的接口。

如果注册的方法不与当前窗体产生交互的（例如 EntityFramework 的方法映射、串口通信、硬件调用等）则使用`Func< JavaScriptValue[],JavaScriptValue>`代理方法（同步）和`Action<JavaScriptValue[], JavaScriptAsyncFunctionCallback>`代理方法（异步）。这两个方法将在渲染进程中执行，所以不能操作浏览器进程相关的接口。

关于`浏览器进程`和`渲染进程`先关的内容，请您自行搜索查阅 Chromium 架构的相关文章，本文不展开阐述。

```C#
public class HostWindowExtension : JavaScriptExtensionBase
{
    public override string Name => "Demo/Window";

    // 上面的 JavaScript 结构代码
    public override string JavaScriptCode => Properties.Resources.DemoWindow;

    public HostWindowExtension()
    {
        RegisterFunctionHandler("Test", Test);
        RegisterFunctionHandler("Add", Add);
        RegisterFunctionHandler("Delay", Delay);

        RegisterFunctionHandler("Hello", Hello);
        RegisterFunctionHandler("HelloAsync", HelloAsync);

        RegisterFunctionHandler("GetTitle", (owner, arguments) => JavaScriptValue.CreateString(owner.Subtitle));

        RegisterFunctionHandler("SetTitle", (owner, arguments) => {
            var title = arguments.FirstOrDefault(x => x.IsString)?.GetString() ?? string.Empty;
            owner.Subtitle = title;
            return null;
        });
    }

    // 关联当前 Formium 窗体的异步执行方法。
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

    // 关联当前 Formium 窗体的同步执行方法。
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

    // 与当前 Formium 窗体无关的同步执行方法。
    private JavaScriptValue Test(JavaScriptValue[] arguments)
    {
        return JavaScriptValue.CreateString("OK");
    }

    // 与当前 Formium 窗体无关的带参数的同步执行方法。
    private JavaScriptValue Add(JavaScriptValue[] arguments)
    {
        if(arguments.Length == 2)
        {
            var retval = arguments[0].GetDouble() + arguments[1].GetDouble();

            return JavaScriptValue.CreateNumber(retval);
        }

        return JavaScriptValue.CreateNull();
    }

    // 与当前 Formium 窗体无关的带参数的异步执行方法。
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
```

## 调用扩展

您可以在任意 Formium 窗体中（当然前提是您的 NanUI 项目有多个 Formium 窗体）使用通过 JavaScript 扩展注册的对象。

## 延伸

JavaScript 扩展为 NanUI 带来了强大的扩展能力，正如上面小结中的举例，如果将操作本地数据库的方法作为扩展注入到前端 JavaScript 环境中，在特定的网站中就可以实现使用 JavaScript 代码调用诸如`sqlserver.executeSql('drop database [master]')`这样有趣的代码来实现有趣的功能。
