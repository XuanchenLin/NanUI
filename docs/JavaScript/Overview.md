# JavaScript

## Overview

WinFormium uses Chromium Embedded Framework (CEF) as its rendering engine, so you can use JavaScript to complete various tasks, such as front-end and back-end communication, writing custom interactive functions, etc.

How to use JavaScript in Using the objects provided by WinFormium, this chapter will introduce more about the WinFormium framework and JavaScript.

## JavaScriptValue object

The object responsible for JavaScript interaction in WinFormium is `JavaScriptValue`, which is an important bridge between .NET and JavaScript to transfer data. The JavaScript interactive functions that will be introduced later are based on the `JavaScriptValue` object.

You can simply think of the JavaScriptValue class as a basic JavaScript data type in .NET. It can represent any data type in JavaScript, such as strings, numbers, Boolean values, arrays, objects, methods, etc. Among them, the array is represented by its derived class `JavaScriptArray`, the object is represented by its derived class `JavaScriptObject`, and the method is represented by its derived class `JavaScriptFunction`.

## Execute JavaScript code

WinFormium provides the `ExecuteJavaScript` method to execute JavaScript code. You can use this method to execute any JavaScript code, such as calling JavaScript functions, modifying property values of JavaScript objects, etc.

```csharp
//Execute JavaScript code
ExecuteJavaScript("alert('Hello World!');");
```

At the same time, WinFormium also provides another method to execute JavaScript code and return the execution results, which is `EvaluateJavaScriptAsync`. This method returns an awaitable `Task<JavaScriptResult>` object. You can use the `await` keyword to wait for JavaScript code execution to complete and obtain the execution result. The `JavaScriptResult` contains the result of JavaScript code execution, the `Success` attribute indicates whether the JavaScript code was executed successfully, and when the code is executed incorrectly, the `ExceptionText` attribute contains the error message of the JavaScript code. The `ReturnValue` property contains the return value of the JavaScript code when the code executes successfully.

```csharp
// Execute a JavaScript expression with results. If you do not need to return a result, you can use the ExecuteJavaScript method.
var retval = await EvaluateJavaScriptAsync("3+4");

// Get the return result, the type is JavaScriptValue. You can use various methods of JavaScriptValue to get the value of the return result.
// This version provides various explicit and implicit conversion operators for JavaScriptValue, which can directly convert JavaScriptValue into various basic types.
// For example, the following code converts JavaScriptValue to int type.
int value1 = retval.ReturnValue;

// Get the page title
var retval2 = await EvaluateJavaScriptAsync("document.title");

//Explicit conversion to nullable string type
string? value2 = retval2.ReturnValue;

// Return a function object
var retval3 = await EvaluateJavaScriptAsync("(a)=>{ const v = a.apply(); console.log(`value:${v}`); }");

// Get the Invoker of the function object. You can call this function object through ExecuteAsync of the Invoker type. JavaScriptSynchronousFunction is used here, which means that the function object is executed synchronously. If it is executed asynchronously, JavaScriptAsynchronousFunction can be used, selected according to the parameter type of the function object.
var retval4 = await ((JavaScriptFunctionInvoker)retval3.ReturnValue).ExecuteAsync(new JavaScriptSynchronousFunction((a) => "Callback function for retval3."));

//The return result of the function object, here is the string type
string? value3 = retval4.ReturnValue;

// Return a function object. This function object is executed asynchronously, so use JavaScriptAsynchronousFunction
var retval5 = await EvaluateJavaScriptAsync("(callback)=>{ callback().then(x=>console.log(`success:${x}`)).catch(err=>console.log(`success:$ {err}`)); }");

// A Promise parameter is provided in JavaScriptAsynchronousFunction. You can use the Resolve method of this parameter to return the result, or you can use the Reject method to return an error. Because it is asynchronous, the await keyword is used here to wait for the execution result of this asynchronous function.

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
```

In the above sample code, various situations in which `EvaluateJavaScriptAsync` executes JavaScript code have been shown, and the type conversion of the `ReturnValue` property as a `JavaScriptValue` type in different situations has been shown, as well as its use as a callback JavaScript front-end method When using the `JavaScriptFunctionInvoker` type.

As for the use of arrays and objects, they will be introduced in specific examples in later chapters.

## Register the .NET mapping objects in JavaScript

WinFormium provides the ability to register .NET objects in a front-end JavaScript environment. You can use the `RegisterJavaScriptObject` method to register a mapping of .NET objects, and then find and use the object you registered in the JavaScript `window.external` object.

For more information about .NET mapped objects, please refer to [Register the .NET mapping objects in JavaScript](./Register-Mapping-Objects.md).

## Register JavaScript Window Binding Object

Window Binding Object is a concept of CEF. It is a JavaScript object used to access some properties and methods of the form in the JavaScript environment. For more information about form binding objects, please refer to CEF's [Window Binding Object](https://bitbucket.org/chromiumembedded/cef/wiki/JavaScriptIntegration.md#markdown-header-window-binding-object) article, although the document is coded in C++, it is very helpful for understanding the principles of form binding.

For more information about creating and registering form binding objects in WinFormium, please refer to [Register JavaScript Window Binding Object](./Register-Window-Binding-Objects.md).

## See also

- [Documentation](../Home.md)
- [Register the .NET mapping objects in JavaScript](./Register-Mapping-Objects.md)
- [Register JavaScript Window Binding Object](./Register-Window-Binding-Objects.md)
