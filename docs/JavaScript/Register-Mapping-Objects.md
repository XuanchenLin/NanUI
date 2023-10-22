# Register the .NET mapping objects in JavaScript

## Overview

WinFormium provides the ability to register .NET objects in a front-end JavaScript environment. You can use the `RegisterJavaScriptObject` method to register a mapping of .NET objects, and then find and use the object you registered in the JavaScript `window.external` object.

The .NET mapping object is actually the specific implementation of the `JavaScriptValue` derived class `JavaScriptObject`. You can use an object in JavaScript by creating a normal JavaScript object type, binding .NET properties and methods to the type, and then registering the object with the JavaScript environment.

## Create mapping object

First, you need to create a `JavaScriptObject` object class, which will serve as the object type you register in JavaScript.

```csharp
var obj = new JavaScriptObject
{
     { "name", "linxuanchen" },
     { "age", 38 }
};
```

**Fields and Properties**

In the above code, we create an object of type `JavaScriptObject` and add two fields to it, namely `name` and `age`.

Next, we continue to add some **properties** to this object. It is necessary to pay attention to the difference between `field` and `property`. The difference between field and property is that field is a variable and property is a method. There is no perceptual difference between reading and writing fields and properties in the JavaScript environment, but fields are inherent data when the object is created, so it will not be linked to methods inside the object. As mentioned earlier, the property is a method, which will trigger the `get` or `set` method of the property when reading or writing. Therefore, if this property is associated with a .NET object, then reading and writing in the JavaScript environment When this attribute is used, the method logic of .NET will be linked.

Define properties using the `DefineProperty` method of `JavaScriptObject`. This method accepts two parameters. The first parameter is the `Func<JavaScriptValue>` delegate type, which corresponds to the `get` method of the property. The second parameter is `Action<JavaScriptValue> >` Delegate type, corresponding to the `set` method of the property.

```csharp
//Define a read-only property
obj.DefineProperty("now", () => DateTime.Now);

//Define a readable and writable property
obj.DefineProperty("title", () => AppTitle, v => AppTitle = ((string?)v ?? string.Empty));
```

In the above code example, we define two properties, one is the read-only property `now`, and the other is the read-write property `title`. When the front-end JavaScript code reads the `now` property, the `() => DateTime.Now` method will be executed. When the front-end JavaScript code reads the `title` property, it will return the `AppTitle` property value of the current Formium object, and when writing the `title` property, it will execute `v => AppTitle = ((string?)v ?? string .Empty)` method, this method will receive the assignment from the JavaScript environment and pay the value to the `AppTitle` property in the .NET environment.

**Synchronization methods**

Next, we add a synchronized method to the object. The `Add` method of `JavaScriptObject` allows you to add many data types to the object. Adding a synchronized method uses an overloaded method of the `Add` method `Add(string,Func<JavaScriptArray,JavaScriptValue>)`. This method accepts two `Func<JavaScriptArray,JavaScriptValue>` delegate types. The parameter of this delegate type is an object of type `JavaScriptArray`. The object is an array that contains parameters from the JavaScript environment. If you are familiar with JavaScript, then This parameter is equivalent to the `arguments` parameter of the JS method. The return value of this delegate type is an object of type `JavaScriptValue`, which is a return value that will be returned to the JavaScript environment.

```csharp
obj.Add("hello", args=>{
     var retval = string.Join(",", args.Select(x => x.GetString()));

     InvokeOnUIThread(() =>
     {
         MessageBox.Show(this, $"Caller arguments:{retval}", "JS Value");
     });

     return "C# Value";
})
```

**Asynchronous methods**

Next, we are adding an asynchronous method to this object. Adding an asynchronous method uses another overloaded method of the `Add` method `Add(string, Action<JavaScriptArray,JavaScriptPromise>)`. This method accepts two `Action<JavaScriptArray,JavaScriptPromise>` delegate types. The parameter of this delegate type is an object of type `JavaScriptArray`. The object is an array that contains parameters from the JavaScript environment. If you are familiar with JavaScript, then This parameter is equivalent to the `arguments` parameter of the JS method. The second parameter of this delegate type is an object of type `JavaScriptPromise`, which provides two methods: `Resolve` and `Reject`. You can use these two methods to return the execution result of the asynchronous method.

An asynchronous method will return a `Promise` object immediately after being executed in the JavaScript environment. You can use the `then`, `catch` and `finally` methods to obtain the execution result of the asynchronous method. Of course, if you prefer the try...catch...finally approach, that's also acceptable.

```csharp
obj.Add("async", async (args, promise) =>
{
     var retval = string.Join(",", args.Select(x => x.GetString()));

     var rnd = new Random();

     var x = rnd.Next(1, 6);

     await Task.Delay(x * 500);

     if(x==5)
     {
         promise.Reject("Rejected by random.");
     }
     else
     {
         promise.Resolve(new string(retval.Reverse().ToArray()) ?? "No argument.");
     }
});
```

You can see that the `async` method above uses the async keyword on the delegate parameter. This method is an asynchronous method. It will call the `promise.Resolve` or `promise.Reject` method to return to the asynchronous method after the asynchronous execution is completed. The execution result of the method. In the example, deferred execution is simulated using random numbers, and then a `Resolve` or `Reject` result is returned randomly.

## Register mapping object

After creating the mapping object, we need to register it in the JavaScript environment so that the front-end JavaScript code can access the object. Before calling the `RegisterJavaScriptObject` method to register an object, you need to execute the `BeginRegisterJavaScriptObject` method to specify the frame in which the object is registered. This method returns a handle. After the registration is completed, you need to call the `EndRegisterJavaScriptObject` method to end the registration.

```csharp
var hbrjso = BeginRegisterJavaScriptObject(frame);

RegisterJavaScriptObject(hbrjso, "test", obj);

EndRegisterJavaScriptObject(hbrjso);
```

In the above code example, we use the `BeginRegisterJavaScriptObject` method to specify the registered frame, and then use the `RegisterJavaScriptObject` method to register an object named `test`, which is an object of type `JavaScriptObject` we created earlier. . Finally, we use the `EndRegisterJavaScriptObject` method to end the registration.

## JavaScriptObjectWrapper

In order to create mapping objects more intuitively, WinFormium provides the `JavaScriptObjectWrapper` abstract class, which you can inherit to create mapping objects. The `JavaScriptObjectWrapper` class provides the following methods to simplify the process of creating mapped objects:

| Method                                                                            | Description                                        |
| --------------------------------------------------------------------------------- | -------------------------------------------------- |
| AddField(string,JavaScriptValue)                                                  | Add a field to the mapping object                  |
| DefineProperty(string,Func&lt;JavaScriptValue&gt;,Action&lt;JavaScriptValue&gt;?) | Add properties to the mapping object               |
| AddSynchronousFunction(string,Func&lt;JavaScriptArray,JavaScriptValue&gt;)        | Add a synchronization method to the mapping object |
| AddAsynchronousFunction(string,Action&lt;JavaScriptArray,JavaScriptPromise&gt;)   | Add an asynchronous method to the mapping object   |

The registration method of `JavaScriptObjectWrapper` is the same as that of ordinary `JavaScriptObject`. `RegisterJavaScriptObject` provides an overloaded method to register this type.

## Use mapping objects

Once registered, you can use the object in front-end JavaScript code. In front-end JavaScript code, you can use this object using the `window.external` object.

```javascript
console.log(window.external.test.name); // Output: linxuanchen

console.log(window.external.test.now); // Output the current time

console.log(window.external.test.title); // Output: WinFormium

window.external.test.title = "New Title"; // Set title

console.log(window.external.test.title); // Output: New Title

window.external.test.hello("Hello", "World"); // Call the synchronization method, output: C# Value, and pop up a dialog box

window.external.test
  .async("Hello", "World")
  .then((x) => console.log(x))
  .catch((err) => console.log(err)); // Call the asynchronous method. After a random delay, if it succeeds, it will output: dlroW,olleH, or output: Rejected by random. Indicates random Reject.
```

## See also

- [Overview](./overview.md)
