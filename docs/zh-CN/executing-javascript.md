# 执行 JavaScript 代码

[[返回目录](README.md)]

- [执行 JavaScript 代码](#执行-javascript-代码)
  - [执行 JavaScript 代码（无返回值）](#执行-javascript-代码无返回值)
  - [执行 JavaScript 代码（有返回值）](#执行-javascript-代码有返回值)
  - [关于 JavaScriptValue](#关于-javascriptvalue)

## 执行 JavaScript 代码（无返回值）

在 Formium 窗体中，使用`ExecuteJavaScript`方法来执行 JavaScript 代码。调用`ExecuteJavaScript`方法需要在浏览器初始化完成后，所以最佳位置应在`OnReady`重载方法中。

```C#
ExecuteJavaScript(@"alert('Hello NanUI!')");
```

## 执行 JavaScript 代码（有返回值）

使用`EvaluateJavaScriptAsync`方法来异步执行带返回值的 JavaScript 代码。

```C#
var result = await EvaluateJavaScriptAsync("(function(){ return {a:1,b:\"hello\",c:(s)=>alert(s)}; })()");

if (result.Success)
{
  var retval = result.ResultValue;

  MessageBox.Show($"a={retval.GetInt("a")} b={retval.GetString("b")}", "Value from JavaScript");

  await retval.GetValue("c").ExecuteFunctionAsync(GetMainFrame(), new JavaScriptValue[] { new JavaScriptValue("Hello from C#") });
}
```

## 关于 JavaScriptValue

`JavaScriptValue`是 NanUI 的 JavaScript Bridge 的基础数据结构，所有进程间的数据交换都是通过 JavaScriptValue 转换而成的。

JavaScriptValue 数据结构主要提供了一些 .NET CLR 数据类型到 CEF 数据类型的转换方法。如果要将一个 .NET 对象转换为 NanUI JavaScript Bridge 可用的数据结构就需要通过 JavaScriptValue 进行映射。

```C#
var clrObject = new
{
  Name = "NanUI",
  Age = 5,
  CreatedAt = new DateTime(2014, 12, 1),
  Active = true,
  Hosts = new string[] {
    "https://github.com/NetDimension/NanUI",
    "https://gitee.com/linxuanchen/NanUI",
    "https://www.formium.net" }
};

// 对象
var nanuiObject = new JavaScriptObject();

nanuiObject.Add(nameof(clrObject.Name), new JavaScriptValue(clrObject.Name));
nanuiObject.Add(nameof(clrObject.Age), new JavaScriptValue(clrObject.Age));
nanuiObject.Add(nameof(clrObject.CreatedAt), new JavaScriptValue(clrObject.CreatedAt));
nanuiObject.Add(nameof(clrObject.Active), new JavaScriptValue(clrObject.Active));

// 数组
var nanuiArray = new JavaScriptArray();

foreach (var host in clrObject.Hosts)
{
    nanuiArray.Add(host);
}

nanuiObject.Add(nameof(clrObject.Hosts), nanuiArray);
```
