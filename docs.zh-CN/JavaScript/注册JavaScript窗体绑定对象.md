# 注册 JavaScript 窗体绑定对象

## 概述

窗体绑定对象 (Window Binding Object) 是 CEF 的一个概念，它是一个 JavaScript 对象，用于在 JavaScript 环境中访问窗体的一些属性和方法。WinFormium 简化了窗体绑定的流程，您可以非常的简单的创建和注册一个窗体绑定对象。

## 创建窗体绑定对象

创建 WinFormium 的窗体绑定对象首先需要继承 `JavaScriptWindowBindingObject` 类，该类是一个抽象类，您还需要实现它的抽象属性 `Name` 和 `JavaScriptWindowBindingCode` 两个属性。

`Name` 属性是指当前创建对象的唯一名称。它没有具体的表现，只是为了区分不同的窗体绑定对象。

`JavaScriptWindowBindingCode` 是窗体绑定对象的 JavaScript 代码，这段代码非常重要，其中使用 `native` 关键字标记的对象就是窗体绑定对象的方法实例。凡是标记了 `native` 关键字的方法才能被绑定到 .NET 环境中。

```js
var TestWindowBindingObject = {
    a: 1,
    b: function (a, b) {
        return a + b;
    },
    test: function(message){
        native function TestMethod();
        return TestMethod(message);
    },
    testAsync: function(message, num){
        native function TestMethodAsync();
        return TestMethodAsync(message,num);
    }
};
```

例如上面的代码中，就是一段窗体绑定的结构代码，我们在 JavaScript 中创建了一个名为 `TestWindowBindingObject` 的对象，可以看到其中有一个 `TestMethod` 方法，和 `TestMethodAsync` 该方法被标记了 `native` 关键字，这两个方法就是我们要绑定到 .NET 环境中的方法。

下面，我们来创建一个窗体绑定对象的实例，我们创建一个名为 `TestWindowBindingObject` 的类，继承 `JavaScriptWindowBindingObject` 类，并实现 `Name` 和 `JavaScriptWindowBindingCode` 两个属性。然后我们还将为上面的结构代码添加对应的 `TestMethod` 和 `TestMethodAsync` 方法的 .NET 实现。

```csharp
using WinFormium;
using WinFormium.JavaScript;

class TestWindowBindingObject : JavaScriptWindowBindingObject
{

    public override string Name => "TestWindowBindingObject";

    // Window Binding Object的JavaScript代码，这个代码会被注入到主进程和渲染进程的JavaScript环境中。这个根据实际情况进行编写，具体内容请自行参考CEF的JavaScript Window Binding Object的相关文档。
    public override string JavaScriptWindowBindingCode => """"
var TestWindowBindingObject = {
    a: 1,
    b: function (a, b) {
        return a + b;
    },
    test: function(message){
        native function TestMethod();
        return TestMethod(message);
    },
    testAsync: function(message, num){
        native function TestMethodAsync();
        return TestMethodAsync(message,num);
    }
};
"""";

    public TestWindowBindingObject()
    {
        // 注册同步方法，带有Formium参数的方法表示这个方法行在主进程中，不带Formium参数的方法表示这个方法运行在渲染进程中。
        RegisterSynchronousNativeFunction(TestMethod);

        // 注册异步方法，带有Formium参数的方法表示这个方法行在主进程中，不带Formium参数的方法表示这个方法运行在渲染进程中。
        RegisterAsynchronousNativeFunction(TestMethodAsync);
    }

    public JavaScriptValue? TestMethod(Formium sender, JavaScriptArray arguments)
    {

        var stringArg = arguments.FirstOrDefault(x => x.ValueType == JavaScriptValueType.String)?.GetString()??string.Empty;

        MessageBox.Show(sender, $"JS Say:{stringArg}");

        return null;
    }

    public async void TestMethodAsync(Formium sender, JavaScriptArray arguments, JavaScriptPromise promise)
    {
        var stringArg = arguments.FirstOrDefault(x => x.ValueType == JavaScriptValueType.String)?.GetString() ?? string.Empty;
        var intArg = arguments.FirstOrDefault(x => x.ValueType == JavaScriptValueType.Number)?.GetInt() ?? 0;
        System.Diagnostics.Debug.WriteLine($"JS Say:{stringArg}");

        var rnd = new Random(DateTime.Now.Millisecond);

        var delayed = rnd.Next(1, 5000);

        // 模拟一个异步操作
        await Task.Delay(delayed);

        promise.Resolve($"Hello from C# with value:{intArg} and delayed:{delayed}ms.");
    }
}
```

使用 `JavaScriptWindowBindingObject` 的 `RegisterSynchronousNativeFunction` 方法来注册同步方法 `TestMethod`，使用 `JavaScriptWindowBindingObject` 的 `RegisterAsynchronousNativeFunction` 方法来注册异步方法 `TestMethodAsync`。

`RegisterSynchronousNativeFunction` 方法的参数是一个 `Func<Formium,JavaScriptArray,JavaScriptValue>` 委托类型，该委托类型的第一个参数是一个 `Formium` 类型的对象，该对象是当前窗体的实例，第二个参数是一个 `JavaScriptArray` 类型的对象，该对象是一个数组，它包含了来自 JavaScript 环境的参数，如果您熟悉 JavaScript 那么这个参数相当于 JS 方法的 `arguments` 参数。该委托类型的返回值是一个 `JavaScriptValue` 类型的对象，该对象是一个返回值，它将返回给 JavaScript 环境。

`RegisterAsynchronousNativeFunction` 方法的参数是一个 `Action<Formium,JavaScriptArray,JavaScriptPromise>` 委托类型，该委托类型的第一个参数是一个 `Formium` 类型的对象，该对象是当前窗体的实例，第二个参数是一个 `JavaScriptArray` 类型的对象，该对象是一个数组，它包含了来自 JavaScript 环境的参数，如果您熟悉 JavaScript 那么这个参数相当于 JS 方法的 `arguments` 参数。该委托类型的第三个参数是一个 `JavaScriptPromise` 类型的对象，该对象提供了 `Resolve` 和 `Reject` 两个方法，您可以使用这两个方法来返回异步方法的执行结果。

`RegisterSynchronousNativeFunction` 和 `RegisterAsynchronousNativeFunction` 都有两个重载方法，一个是带有 `Formium` 参数的，表示这个方法运行在主进程中，另一个是不带 `Formium` 参数的，表示这个方法运行在渲染进程中。

这样，我们就完成了窗体绑定对象的创建。

## 注册窗体绑定对象

在创建窗体绑定对象后，我们还需要注册，这样才能在 JavaScript 环境中访问到该对象。您可以在 WinFormium 应用程序创建阶段使用 `AppBuilder` 的 `RegsiterWindowBindingObject` 方法来注册窗体绑定对象。也可以在 WinFormium 应用程序配置阶段使用 `WinFormiumStartup` 类的 `ConfigureServices` 以配置服务的方式使用 `AddWindowBindingObject` 方法来注册窗体绑定对象。需要注意的是，如果使用第一种注册方式，而刚好您的应用程序使用了独立的子进程，那么您需要在子进程中也注册一次窗体绑定对象，而使用第二种注册方式则不需要，所以强烈推荐在使用了独立子进程的应用程序中使用第二种注册方式。

`AppBuilder` 的 `RegsiterWindowBindingObject` 方法提供两个重载方法，第一个使用 `RegsiterWindowBindingObject<T>()` 泛型方法来注册窗体绑定对象，该方法接受一个泛型参数，该参数是窗体绑定对象的类型。第二个方法是使用 `RegsiterWindowBindingObject<T>(Func<IServiceProvider,T>)` 方法来注册窗体绑定对象，该方法接受一个泛型参数，该参数是窗体绑定对象的类型，第二个参数是一个 `Func<IServiceProvider,T>` 委托类型，该委托类型的参数是一个 `IServiceProvider` 类型的对象，该对象是一个服务容器，您可以使用该对象来获取服务。

```csharp
class Program
{
    [STAThread]
    static void Main()
    {
        var builder = WinFormiumApp.CreateBuilder();

        var app = builder
        //...
        .RegsiterWindowBindingObject<TestWindowBindingObject>()
        .build();

        app.Run();

    }
}
```

或者

```csharp
class Program
{
    [STAThread]
    static void Main()
    {
        var builder = WinFormiumApp.CreateBuilder();

        var app = builder
        //...
        .RegsiterWindowBindingObject(services => new TestWindowBindingObject())
        .build();

        app.Run();

    }
}
```

如果使用 `WinFormiumStartup` 类的 `ConfigureServices` 方法来注册窗体绑定对象，那么您需要使用 `AddWindowBindingObject<T>()` 泛型方法来注册窗体绑定对象，该方法接受一个泛型参数，该参数是窗体绑定对象的类型。

```csharp
class MyApp : WinFormiumStartup
{
    //...

    public override void ConfigureServices(IServiceCollection services)
    {
        //...
        services.AddWindowBindingObject<TestWindowBindingObject>();
        //...
    }

}
```

## 使用窗体绑定对象

在上面的示例中，我们创建了一个名为 `TestWindowBindingObject` 的窗体绑定对象，那么我们如何在 JavaScript 环境中访问该对象呢？其实非常简单，只需要在 JavaScript 环境中使用 `window` 对象的 `TestWindowBindingObject` 属性即可。

```js
console.log(TestWindowBindingObject.a); // 输出：1
console.log(TestWindowBindingObject.b(1, 2)); // 输出：3
TestWindowBindingObject.test("Hello from JavaScript."); // 弹出一个对话框
TestWindowBindingObject.testAsync("Hello from JavaScript.", 123)
  .then((x) => console.log(x))
  .catch((err) => console.log(err)); // 等待随机时间后输出：Hello from C# with value:123 and delayed:1234ms.
```

## 另请参阅

- [概述](./概述.md)
