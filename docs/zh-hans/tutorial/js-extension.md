# 注册 Javascript 扩展程序

Cef 的 Javascript 扩展程序是标准的，向 Javascript 环境注册对象的标准流程。在 NanUI 中，有很多内置的方法（比如控制浏览器承载窗口的最大化、最小化等）就是采用了这种方法来注册的。其核心使用的是 Cef 的`CefV8Handler`类，这个类主要功能就是负责处理 V8 引擎中的各种数据。

在 NanUI 中提供了便捷的`ChromiumExtensionBase`类来方便您注册扩展程序。

本章节中涉及的内容

- [ChromiumExtensionBase 类](#chromiumextensionbase-类)
- [Javascript 构造代码](#javascript-构造代码)
- [处理器实现](#处理器实现)
- [注册扩展程序](#注册扩展程序)
- [使用扩展](#使用扩展)

## ChromiumExtensionBase 类

`ChromiumExtensionBase`类包含抽象属性`DefinitionJavascriptCode`和抽象方法`OnExtensionExecute`。您需要为`DefinitionJavascriptCode`属性提供 Javascript 的构造代码，抽象方法`OnExtensionExecute`是构造代码中的本地方法执行时触发的事件。

```C#
class ChromiumExtensionBase : CfrV8Value
{
    public abstract string DefinitionJavascriptCode { get; }
    public abstract CfrV8Value OnExtensionExecute(string nativeFunctionName, CfrV8Value[] arguments, CfrV8Value @this, ref string exception);
}
```

## Javascript 构造代码

Javascript 构造代码是特别针对与本地交互的操作而特别设置的代码。请注意，您不能在这种交互代码中执行 DOM 操作，换句话来说，您的代码可以使用 Javascript 环境中的`window`对象，但不能访问`window`对象里的`document`或者`body`对象。

下面就是一段构造代码的例子。

```JS
var DotNet = DotNet || {};

(function(dotNet){

    // 定义属性
    dotNet.__defineGetter__("version", function() {
        native function GetVersion();
        return GetVersion();
    });

    // 定义方法
    dotNet.messagebox = function(text) {
        native function MessageBox();
        return MessageBox(text);
    }

})(DotNet);
```

请注意，任何与本地交互的属性或者方法，都需要指定特别的关键字`native`，以此来标注执行此方法时触发`CefV8Handler`的`Execute`方法，只是`ChromiumExtensionBase`为您简化了此过程。

## 处理器实现

在有了构造代码后，您就需要实现处理器的逻辑。

```C#
class DotNetExampleObject : ChromiumExtensionBase
{
    public override string DefinitionJavascriptCode => "<上述Javascript构造代码>";
    public override CfrV8Value OnExtensionExecute(string nativeFunctionName, CfrV8Value[] arguments, CfrV8Value @this, ref string exception)
    {
        CfrV8Value retval = null;
        if(nativeFunctionName == "GetVersion")
        {
            // 返回.Net环境的版本号
            retval = CfrV8Value.CreateString(Environment.Version.ToString());
        }

        if(nativeFunctionName == "MessageBox")
        {
            var text = arguments[0].StringValue;
            MessageBox.Show(text);
        }

        return retval;
    }
}
```

如此，您的扩展程序就设计完成了。这个扩展只实现了 2 个简单的功能：

- `DotNet.version` 获取当前.NET 的版本号
- `messagebox(str)` 通过.NET 环境显示一个内容为参数`str`的 MessageBox
-

## 注册扩展程序

设计完扩展程序，您还需要将他注册到 Cef 的 V8 环境中。在 NanUI 初始化时，使用`RegisterChromiumExtension`方法来注册您的扩展程序。

```C#
Bootstrap
    .Initialize()
    .RegisterChromiumExtension("DotNet/Extension", () => new DotNetExampleObject())
    .Run(() => new MainWindow());
```

## 使用扩展

打开 DevTools，在控制台中输入`DotNet`来查看是否将这个对象注册到了 Javascript 环境。

```
> DotNet
Object {}
```

执行`DotNet.verson`将打印当前.NET 框架的版本号。

```
> DotNet.version
[4.0.30319.42000]
```

使用`DotNet.messagebox()`来显示一个 MessageBox。

```
> DotNet.messagebox("Hello NanUI!");
undefined
```
