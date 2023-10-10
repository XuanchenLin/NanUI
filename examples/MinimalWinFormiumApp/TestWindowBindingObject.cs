using WinFormium;
using WinFormium.JavaScript;

namespace MinimalWinFormiumApp;

// 演示 JavaScript Window Binding Object 的使用，需要在Builder中通过RegsiterWindowBindingObject<TestWindowBindingObject>()方法注册这个对象。使用RegsiterWindowBindingObject<T>方法来注册JavaScript Window Binding Object，这个方法会自动创建一个T类型的实例，并将这个实例自动注册到主进程和渲染进程的JavaScript环境中。
// Demonstrates the usage of JavaScript Window Binding Object. It is required to register this object in the Builder using the RegisterWindowBindingObject<TestWindowBindingObject>() method. The RegisterWindowBindingObject<T> method is used to register the JavaScript Window Binding Object. This method automatically creates an instance of type T and registers it in the JavaScript environment of both the main process and the rendering process.
// 使用RegsiterWindowBindingObject还提供了另外一种方式，就是直接传入代理来注册对象实例，这个对象实例必须继承自JavaScriptWindowBindingObject类，如果你的应用使用了独立的Subprocess，那么在Subprocess中也需要注册这个对象实例。(类型0.9版本的那种方式)
// The RegisterWindowBindingObject also provides another way to register object instances by directly passing a proxy. The object instance must inherit from the JavaScriptWindowBindingObject class. If your application uses a separate subprocess, you also need to register this object instance in the subprocess. (This is the approach used in version 0.9 of the library.)
// 所以，建议使用RegsiterWindowBindingObject<T>方法来注册。
// Therefore, it is recommended to use the RegsiterWindowBindingObject<T> method to register.
internal class TestWindowBindingObject : JavaScriptWindowBindingObject
{

    public override string Name => "TestWindowBindingObject";

    // Window Binding Object的JavaScript代码，这个代码会被注入到JavaScript环境中。这个根据实际情况进行编写，具体内容请自行参考CEF的JavaScript Window Binding Object的相关文档。
    // JavaScript code for the Window Binding Object, which will be injected into the JavaScript environment. This code should be written based on your specific requirements. Please refer to the relevant documentation of CEF's JavaScript Window Binding Object for specific details.
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
        // Registering synchronous methods. Methods with the Formium parameter indicate that they run in the main process, while methods without the Formium parameter indicate that they run in the rendering process.
        RegisterSynchronousNativeFunction(TestMethod);

        // 注册异步方法，带有Formium参数的方法表示这个方法行在主进程中，不带Formium参数的方法表示这个方法运行在渲染进程中。
        // Registering asynchronous methods. Methods with the Formium parameter indicate that they run in the main process, while methods without the Formium parameter indicate that they run in the rendering process.
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
        // Simulating an asynchronous operation
        await Task.Delay(delayed);

        promise.Resolve($"Hello from C# with value:{intArg} and delayed:{delayed}ms.");
    }
}
