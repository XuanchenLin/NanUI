# Execute JavaScript code

[[Home](README.md)]

- [Execute JavaScript code](#execute-javascript-code)
  - [Execute JavaScript code (no return value)](#execute-javascript-code-no-return-value)
  - [Execute JavaScript code (with return value)](#execute-javascript-code-with-return-value)
  - [About JavaScriptValue](#about-javascriptvalue)

## Execute JavaScript code (no return value)

In the Formium form, use the `ExecuteJavaScript` method to execute JavaScript code. The `ExecuteJavaScript` method needs to be called after the browser is initialized, so the best location should be in the `OnReady` overload method.

```C#
ExecuteJavaScript(@"alert('Hello NanUI!')");
```

## Execute JavaScript code (with return value)

Use `EvaluateJavaScriptAsync` method to asynchronously execute JavaScript code with return value.

```C#
var result = await EvaluateJavaScriptAsync("(function(){ return {a:1,b:\"hello\",c:(s)=>alert(s)}; })()");

if (result.Success)
{
  var retval = result.ResultValue;

  MessageBox.Show($"a={retval.GetInt("a")} b={retval.GetString("b")}", "Value from JavaScript");

  await retval.GetValue("c").ExecuteFunctionAsync(GetMainFrame(), new JavaScriptValue[] {JavaScriptValue.CreateString("Hello from C#") });
}
```

## About JavaScriptValue

`JavaScriptValue` is the basic data structure of NanUI's JavaScript Bridge. All data exchanges between processes are converted by JavaScriptValue.

The JavaScriptValue data structure mainly provides some conversion methods from .NET CLR data types to CEF data types. If you want to convert a .NET object into a data structure usable by NanUI JavaScript Bridge, you need to map it through JavaScriptValue.

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
    "https://www.formium.net"}
};

var nanuiObject = JavaScriptValue.CreateObject();

nanuiObject.SetValue(nameof(clrObject.Name), JavaScriptValue.CreateString(clrObject.Name));
nanuiObject.SetValue(nameof(clrObject.Age), JavaScriptValue.CreateNumber(clrObject.Age));
nanuiObject.SetValue(nameof(clrObject.CreatedAt), JavaScriptValue.CreateDateTime(clrObject.CreatedAt));
nanuiObject.SetValue(nameof(clrObject.Active), JavaScriptValue.CreateBool(clrObject.Active));

var nanuiArray = JavaScriptValue.CreateArray();

foreach (var host in clrObject.Hosts)
{
    nanuiArray.AddArrayValue(JavaScriptValue.CreateString(host));
}

nanuiObject.SetValue(nameof(clrObject.Hosts), nanuiArray);
```

At present, it seems that the mapping process from .NET data to JavaScriptValue is a bit more complicated. In subsequent versions, you may consider adding a data type converter `Converter` between them to simplify the above operations.
