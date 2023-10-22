# Register JavaScript Window Binding Object

## Overview

Window Binding Object is a concept of CEF. It is a JavaScript object used to access some properties and methods of the form in the JavaScript environment. WinFormium simplifies the form binding process. You can easily create and register a Window Binding Object.

## Create a Window Binding Object

To create a WinFormium Window Binding Object, you first need to inherit the `JavaScriptWindowBindingObject` class, which is an abstract class. You also need to implement its abstract properties `Name` and `JavaScriptWindowBindingCode`.

The `Name` property refers to the unique name of the currently created object. It has no specific performance, just to distinguish different Window Binding Objects.

`JavaScriptWindowBindingCode` is the JavaScript code of the Window Binding Object. This code is very important. The object marked with the `native` keyword is the method instance of the Window Binding Object. Only methods marked with the `native` keyword can be bound to the .NET environment.

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

For example, in the above code, it is a structural code for form binding. We created an object named `TestWindowBindingObject` in JavaScript. You can see that there is a `TestMethod` method, and `TestMethodAsync`. This method is marked With the `native` keyword, these two methods are the methods we want to bind to the .NET environment.

Next, we create an instance of the Window Binding Object. We create a class named `TestWindowBindingObject`, inherit the `JavaScriptWindowBindingObject` class, and implement the two properties `Name` and `JavaScriptWindowBindingCode`. We will then add the corresponding .NET implementations of the `TestMethod` and `TestMethodAsync` methods to the above structure code.

```csharp
using WinFormium;
using WinFormium.JavaScript;

class TestWindowBindingObject : JavaScriptWindowBindingObject
{

     public override string Name => "TestWindowBindingObject";

     //The JavaScript code of the Window Binding Object. This code will be injected into the JavaScript environment of the main process and the rendering process. This is written based on the actual situation. For specific content, please refer to the relevant documentation of CEF's JavaScript Window Binding Object.
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
         //Register the synchronization method. The method with Formium parameters indicates that this method runs in the main process. The method without Formium parameters indicates that this method runs in the rendering process.
         RegisterSynchronousNativeFunction(TestMethod);

         //Register an asynchronous method. A method with Formium parameters indicates that this method runs in the main process. A method without Formium parameters indicates that this method runs in the rendering process.
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

         // Simulate an asynchronous operation
         await Task.Delay(delayed);

         promise.Resolve($"Hello from C# with value:{intArg} and delayed:{delayed}ms.");
     }
}
```

Use the `RegisterSynchronousNativeFunction` method of `JavaScriptWindowBindingObject` to register the synchronous method `TestMethod`, and use the `RegisterAsynchronousNativeFunction` method of `JavaScriptWindowBindingObject` to register the asynchronous method `TestMethodAsync`.

The parameter of the `RegisterSynchronousNativeFunction` method is a `Func<Formium,JavaScriptArray,JavaScriptValue>` delegate type. The first parameter of the delegate type is an object of type `Formium`, which is an instance of the current form. The second parameter The parameter is an object of type `JavaScriptArray`, which is an array that contains parameters from the JavaScript environment. If you are familiar with JavaScript, this parameter is equivalent to the `arguments` parameter of the JS method. The return value of this delegate type is an object of type `JavaScriptValue`, which is a return value that will be returned to the JavaScript environment.

The parameter of the `RegisterAsynchronousNativeFunction` method is an `Action<Formium,JavaScriptArray,JavaScriptPromise>` delegate type. The first parameter of the delegate type is an object of type `Formium`, which is an instance of the current form. The second parameter The parameter is an object of type `JavaScriptArray`, which is an array that contains parameters from the JavaScript environment. If you are familiar with JavaScript, this parameter is equivalent to the `arguments` parameter of the JS method. The third parameter of this delegate type is an object of type `JavaScriptPromise`, which provides two methods `Resolve` and `Reject`. You can use these two methods to return the execution result of the asynchronous method.

Both `RegisterSynchronousNativeFunction` and `RegisterAsynchronousNativeFunction` have two overloaded methods, one with `Formium` parameter, indicating that this method runs in the main process, and the other without `Formium` parameter, indicating that this method runs in in the rendering process.

In this way, we have completed the creation of the Window Binding Object.

## Register Window Binding Object

After creating the Window Binding Object, we also need to register it so that it can be accessed in the JavaScript environment. You can register a Window Binding Object during the WinFormium application creation phase using the `RegsiterWindowBindingObject` method of `AppBuilder`. You can also use the `ConfigureServices` of the `WinFormiumStartup` class during the WinFormium application configuration phase to configure the service using the `AddWindowBindingObject` method to register the Window Binding Object. It should be noted that if you use the first registration method and your application happens to use an independent sub-process, then you need to register the Window Binding Object once in the sub-process, while if you use the second registration method No, so it is strongly recommended to use the second registration method in applications that use independent child processes.

The `RegsiterWindowBindingObject` method of `AppBuilder` provides two overloaded methods. The first one uses the `RegsiterWindowBindingObject<T>()` generic method to register the Window Binding Object. This method accepts a generic parameter, which is the window The type of body binding object. The second method is to use the `RegsiterWindowBindingObject<T>(Func<IServiceProvider,T>)` method to register the Window Binding Object. This method accepts a generic parameter, which is the type of the Window Binding Object. The second method The first parameter is a `Func<IServiceProvider,T>` delegate type. The parameter of this delegate type is an object of type `IServiceProvider`. This object is a service container. You can use this object to obtain services.

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

or

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

If you use the `ConfigureServices` method of the `WinFormiumStartup` class to register the Window Binding Object, then you need to use the `AddWindowBindingObject<T>()` generic method to register the Window Binding Object, which accepts a generic parameter, This parameter is the type of the Window Binding Object.

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

## Use Window Binding Objects

In the above example, we created a Window Binding Object named `TestWindowBindingObject`, so how do we access this object in the JavaScript environment? It's actually very simple, just use the `TestWindowBindingObject` property of the `window` object in the JavaScript environment.

```js
console.log(TestWindowBindingObject.a); // Output: 1
console.log(TestWindowBindingObject.b(1, 2)); // Output: 3
TestWindowBindingObject.test("Hello from JavaScript."); // Pop up a dialog box
TestWindowBindingObject.testAsync("Hello from JavaScript.", 123)
  .then((x) => console.log(x))
  .catch((err) => console.log(err)); // Wait for a random time and output: Hello from C# with value:123 and delayed:1234ms.
```

## See also

- [Overview](./overview.md)
