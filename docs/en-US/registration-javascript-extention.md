# Register JavaScript extension

[[Home](README.md)]

- [Register JavaScript extension](#register-javascript-extension)
  - [JavaScript code section](#javascript-code-section)
  - [JavaScript extension handler](#javascript-extension-handler)
  - [Call extension](#call-extension)
  - [More](#more)

Registering JavaScript extensions is similar to registering JavaScript objects, but there are essential differences. After the JavaScript extension is registered, all Formium forms can access the registered objects; the registered JavaScript objects are only valid for the current Formium form.

Compared with the registered object, the extended registration process is more complicated. You need to write the corresponding JavaScript code and specify the `native` method in the code. After calling this method, the handler of `CefV8Handler` will be notified to process and feedback the operation.

NanUI encapsulates and simplifies this process. You don’t need to deal with the cumbersome `CefV8Handler` handler and headache data conversion, just write the JavaScript code and inherit the abstract class `JavaScriptExtensionBase`, specify the abstract attributes `Name` and `JavaScriptCode` separately The unique name of the extension and the JavaScript logic code mentioned above, the rest is to write the corresponding `native` method of JavaScript.

## JavaScript code section

The following example shows how to write the structure code part of the JavaScript extension. You can see that there are defined methods and attributes in the sample code. Different from traditional JavaScript code, the `native` keyword is added to each method and attribute, which indicates that the method is a `native method`, executed and called It will notify `CefV8Handler` for processing. And NanUI uses `JavaScriptExtensionBase` to encapsulate and receive the processing result of `CefV8Handler` for use in the .NET environment.

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

It is important to note that the DOM does not exist when the structure code of the JavaScript extension is executed, so any JavaScript code that calls the DOM will cause the rendering process to crash. If you must operate the DOM in the structured code of the JavaScript extension, you need to ensure that the DOM already exists before you can operate safely.

## JavaScript extension handler

The extension handler class inherits from the abstract class `JavaScriptExtensionBase`. The `Name` attribute is the unique code of the extension. If an extension with the same Name already exists, an exception will be thrown during registration. `JavaScriptCode` is the structure code in the above summary.

For the method pointed to by the `native` keyword in the JavaScript structure code, the `RegisterFunctionHandler` method needs to be used in this class to register the processing function corresponding to its name.

If the registered method needs to interact with the current Formium form (such as modifying the title of the form, setting or obtaining form properties, calling form methods, etc.), you need to use the `Func<Formium, JavaScriptValue[],JavaScriptValue>` proxy method (Synchronous) and ʻAction<Formium, JavaScriptValue[], JavaScriptAsyncFunctionCallback>` proxy method (asynchronous). These two methods will be executed in the browser process, so the interface related to the browser process can be operated.

If the registered method does not interact with the current form (such as EntityFramework method mapping, serial communication, hardware call, etc.), use the `Func<JavaScriptValue[],JavaScriptValue>` proxy method (synchronization) and ʻAction<JavaScriptValue[] , JavaScriptAsyncFunctionCallback>`Proxy method (asynchronous). These two methods will be executed in the rendering process, so the interface related to the browser process cannot be operated.

Regarding the contents of `browser process` and `rendering process`, please search for related articles on Chromium architecture by yourself, this article will not elaborate.

```C#
public class HostWindowExtension : JavaScriptExtensionBase
{
    public override string Name => "Demo/Window";

    // The above JavaScript structure code
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

    // Associate the asynchronous execution method of the current Formium form.
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

    // Associate the synchronous execution method of the current Formium form.
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

    // A synchronous execution method that has nothing to do with the current Formium form.
    private JavaScriptValue Test(JavaScriptValue[] arguments)
    {
        return JavaScriptValue.CreateString("OK");
    }

    // Synchronous execution method with parameters irrelevant to the current Formium form.
    private JavaScriptValue Add(JavaScriptValue[] arguments)
    {
        if(arguments.Length == 2)
        {
            var retval = arguments[0].GetDouble() + arguments[1].GetDouble();

            return JavaScriptValue.CreateNumber(retval);
        }

        return JavaScriptValue.CreateNull();
    }

    // Asynchronous execution method with parameters that has nothing to do with the current Formium form.
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

## Call extension

You can use the objects registered through JavaScript extensions in any Formium form (of course, provided that your NanUI project has multiple Formium forms).

## More

JavaScript extensions bring powerful extension capabilities to NanUI. Just like the example in the above summary, if the method of operating the local database is injected into the front-end JavaScript environment as an extension, you can use JavaScript code to call such as `sqlserver in a specific website .executeSql('drop database [master]')` such interesting code to achieve interesting functions.
