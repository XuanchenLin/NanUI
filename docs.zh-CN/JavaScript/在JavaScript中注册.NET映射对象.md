# 在 JavaScript 中注册 .NET 映射对象

## 概述

WinFormium 提供给了在前端 JavaScript 环境中注册 .NET 对象的功能。您可以使用 `RegisterJavaScriptObject` 方法来注册一个 .NET 对象的映射，然后在 JavaScript 的 `window.external` 对象中找到并使用您注册的对象。

.NET 映射对象其实就是 `JavaScriptValue` 衍生类 `JavaScriptObject` 的具体实现。您通过创建一个普通的 JavaScript 对象类型，并为该类型绑定 .NET 的属性和方法，然后将该对象注册到 JavaScript 环境中，就可以在 JavaScript 中使用该对象了。

## 创建映射对象

首先，您需要创建一个 `JavaScriptObject` 对象类，该类将作为您在 JavaScript 中注册的对象类型。

```csharp
var obj = new JavaScriptObject
{
    { "name", "linxuanchen" },
    { "age", 38 }
};
```

**字段与属性**

在上面的代码中，我们创建了一个 `JavaScriptObject` 类型的对象，并为其添加了两个**字段**，分别是 `name` 和 `age`。

下面，我们继续为该对象添加一些**属性**。需要注意`字段`和`属性`的区别，字段和属性的区别在于，字段是一个变量，而属性是一个方法。在 JavaScript 环境中读写字段和属性从感知上是没有区别的，但字段是对象创建时就固有的数据，因此它不会联动对象内部的方法。而属性正如前面所述，是一个方法，它在读写时都将触发该属性的 `get` 或 `set` 方法，因此，如果这个属性与 .NET 对象关联后，那么在 JavaScript 环境中读写该属性时，将会联动 .NET 的方法逻辑。

定义属性使用 `JavaScriptObject` 的 `DefineProperty` 方法，该方法接受两个参数，第一个参数是 `Func<JavaScriptValue>` 委托类型，对应属性的 `get` 方法，第二个参数是 `Action<JavaScriptValue>` 委托类型，对应属性的 `set` 方法。

```csharp
// 定义一个只读属性
obj.DefineProperty("now", () => DateTime.Now);

// 定义一个可读写属性
obj.DefineProperty("title", () => AppTitle, v => AppTitle = ((string?)v ?? string.Empty));
```

上面的代码示例中，我们定义了两个属性，一个是只读属性 `now`，一个是可读写属性 `title`。当前端 JavaScript 代码读取 `now` 属性时，将会执行 `() => DateTime.Now` 方法。当前端 JavaScript 代码读取 `title` 属性时，将返回当前 Formium 对象的 `AppTitle` 属性值，而写入 `title` 属性时将会执行 `v => AppTitle = ((string?)v ?? string.Empty)` 方法，这个方法会接收到来自 JavaScript 环境的赋值，并把该值付给 .NET 环境中的 `AppTitle` 属性。

**同步方法**

接下来，我们为该对象添加一个同步方法。`JavaScriptObject` 的 `Add` 方法允许您向该对象添加很多数据类型，添加同步方法使用的是 `Add` 方法的一个重载方法 `Add(string,Func<JavaScriptArray,JavaScriptValue>)`。该方法接受二个 `Func<JavaScriptArray,JavaScriptValue>` 委托类型，该委托类型的参数是一个 `JavaScriptArray` 类型的对象，该对象是一个数组，它包含了来自 JavaScript 环境的参数，如果您熟悉 JavaScript 那么这个参数相当于 JS 方法的 `arguments` 参数。该委托类型的返回值是一个 `JavaScriptValue` 类型的对象，该对象是一个返回值，它将返回给 JavaScript 环境。

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

**异步方法**

下面，我们在为该对象添加一个异步方法。添加异步方法使用的是 `Add` 方法的另一个重载方法 `Add(string, Action<JavaScriptArray,JavaScriptPromise>)`。该方法接受二个 `Action<JavaScriptArray,JavaScriptPromise>` 委托类型，该委托类型的参数是一个 `JavaScriptArray` 类型的对象，该对象是一个数组，它包含了来自 JavaScript 环境的参数，如果您熟悉 JavaScript 那么这个参数相当于 JS 方法的 `arguments` 参数。该委托类型的第二个参数是一个 `JavaScriptPromise` 类型的对象，该对象提供了 `Resolve` 和 `Reject` 两个方法，您可以使用这两个方法来返回异步方法的执行结果。

异步方法在 JavaScript 环境执行后将立即返回一个 `Promise` 对象，您可以使用 `then`、`catch` 和 `finally` 方法来获取异步方法的执行结果。当然，如果您更喜欢 try...catch...finally 的写法也是可以接受的。

```csharp
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
```

可以看到上面的这个 `async` 方法在委托参数上使用了 async 关键字，这个方法是一个异步方法，它将在异步执行完成后调用 `promise.Resolve` 或 `promise.Reject` 方法来返回异步方法的执行结果。在示例中，使用随机数模拟了延迟执行，然后随机返回一个 `Resolve` 或 `Reject` 结果。

## 注册映射对象

在创建好映射对象后，我们需要将其注册到 JavaScript 环境中，这样前端 JavaScript 代码才能够访问到该对象。在调用 `RegisterJavaScriptObject` 方法来注册对象前，您需要先执行 `BeginRegisterJavaScriptObject` 方法来指定该对象注册的 frame，该方法返回一个句柄，您需要在注册完成后调用 `EndRegisterJavaScriptObject` 方法来结束注册。

```csharp
var hbrjso = BeginRegisterJavaScriptObject(frame);

RegisterJavaScriptObject(hbrjso, "test", obj);

EndRegisterJavaScriptObject(hbrjso);
```

上面的代码示例中，我们使用 `BeginRegisterJavaScriptObject` 方法来指定了注册的 frame，然后使用 `RegisterJavaScriptObject` 方法来注册了一个名为 `test` 的对象，该对象是我们前面创建的 `JavaScriptObject` 类型的对象。最后，我们使用 `EndRegisterJavaScriptObject` 方法来结束注册。

## JavaScriptObjectWrapper

为了更直观的创建映射对象，WinFormium 提供了 `JavaScriptObjectWrapper` 抽象类，您可以继承该类来创建映射对象。`JavaScriptObjectWrapper` 类提供了以下方法来简化创建映射对象的过程：

| 方法                                                                              | 说明                   |
| --------------------------------------------------------------------------------- | ---------------------- |
| AddField(string,JavaScriptValue)                                                  | 为映射对象添加一个字段 |
| DefineProperty(string,Func&lt;JavaScriptValue&gt;,Action&lt;JavaScriptValue&gt;?) | 为映射对象添加属性     |
| AddSynchronousFunction(string,Func&lt;JavaScriptArray,JavaScriptValue&gt;)        | 为映射对象添加同步方法 |
| AddAsynchronousFunction(string,Action&lt;JavaScriptArray,JavaScriptPromise&gt;)   | 为映射对象添加异步方法 |

`JavaScriptObjectWrapper` 的注册方式于普通 `JavaScriptObject` 的注册方式一致，`RegisterJavaScriptObject` 提供了一个重载方法来实现对该类型的注册。

## 使用映射对象

在注册完成后，您就可以在前端 JavaScript 代码中使用该对象了。在前端 JavaScript 代码中，您可以使用 `window.external` 对象来使用该对象。

```javascript
console.log(window.external.test.name); // 输出：linxuanchen

console.log(window.external.test.now); // 输出当前时间

console.log(window.external.test.title); // 输出：WinFormium

window.external.test.title = "New Title"; // 设置标题

console.log(window.external.test.title); // 输出：New Title

window.external.test.hello("Hello", "World"); // 调用同步方法，输出：C# Value，并且弹出一个对话框

window.external.test
  .async("Hello", "World")
  .then((x) => console.log(x))
  .catch((err) => console.log(err)); // 调用异步方法，随机延时后如果成功输出：dlroW,olleH，或者输出：Rejected by random.表示随机Reject
```

## 另请参阅

- [概述](./概述.md)
