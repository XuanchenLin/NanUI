import React from "react";
import {
  executeJavaScriptWithRetval,
  executeJavaScriptWithoutRetval,
} from "../../FormiumBridge";

const Page = () => {
  return (
    <article>
      <h2>Execute JavaScript code from .NET</h2>
      <div className="section-block">
        <p>
          NanUI provides the ability to interact in the JavaScript environment.
          You can execute JavaScript code synchronously or asynchronously in the
          .NET environment and get the return value.
        </p>
        <p>
          <b>Execute JavaScript code without return value</b>
        </p>
        <p>
          After the browser is initialized, you can use the{" "}
          <b>ExecuteJavaScript</b> method to execute JavaScript code.
        </p>
        <div className="alert alert-light">
          <pre>{`ExecuteJavaScript("alert(1+1)");`}</pre>
        </div>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={() => executeJavaScriptWithoutRetval()}
          >
            Run
          </button>
        </p>
        <p>
          <b>Execute JavaScript code with return value</b>
        </p>
        <p>
          After the browser environment is initialized, you can use the{" "}
          <b>EvaluateJavaScriptAsync</b> method to asynchronously execute the
          JavaScript code with the return value.
        </p>
        <div className="alert alert-light">
          <pre>
            {`private async void TestEvaluateJavaScriptAsync()
{
    var fobj = new JavaScriptObject();

    fobj.DefineProperty("test", () => new JavaScriptValue(Title), (v) =>
    {
        InvokeIfRequired(() => MessageBox.Show(WindowHandle, $"JavaScript Result: {v.GetString()}", "JavaScript"));
    });

    var retval = await EvaluateJavaScriptAsync(@"
(function() { 
return { 
    a:1,
    b:'hello',
    c:(text)=>console.log(text||'hello with empty text'),
    d:(callback)=> {
        callback(111)
            .then(x=>console.log(\`success:\${x}\`))
            .catch(m=>console.log(\`error:\${m}\`));
    },
    e:(s)=> s? \`hello \${s}\` : \`hello from javascript\`,
    f:(o)=>{
        console.log(o.test);
        setTimeout(()=>o.test=new Date(),3000);
    }
}; 
})()");
    
    // Get JavaScript execution result
    var obj = retval.Value.ToObject();

    int value_a = obj["a"];
    string value_b = obj["b"];
    
    // Call method c
    await obj["c"].ExecuteAsync(new JavaScriptValue("Hello World!"));
    // Call method c
    await obj["c"].ExecuteAsync(new JavaScriptValue("Goodbye World!"));
    
    // Execute asynchronous method d, simulate the delay and return a successful result
    var d1 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction(async (args, promise) =>
    {
        await Task.Delay(1000);
        promise.Resovle(new JavaScriptValue("hello"));
    }));
    // Execute asynchronous method d, and return the result of failure
    var d2 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction((args, promise) =>
    {
        promise.Reject("Oops! This will be caught by catch method in a promise.");
    }));
    
    // Execute method e without parameters
    var e1 = await obj["e"].ExecuteAsync();
    // Execute method e with parameters
    var e2 = await obj["e"].ExecuteAsync(new JavaScriptValue("Xuanchen Lin"));

    // Execute method f, and use an object containing attributes as a parameter
    var f = await obj["f"].ExecuteAsync(fobj);
}`}
          </pre>
        </div>
        <p>
          You can set a breakpoint in the TestEvaluateJavaScriptAsync method of
          the sample source MainWindow.cs, and step through the code in the
          method to view the details of each step of the code execution.
        </p>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={() => executeJavaScriptWithRetval()}
          >
            Run
          </button>
        </p>
      </div>

      <h2>Register .NET objects into JavaScript</h2>
      <div className="section-block">
        <p>
          Use the <b>RegisterJavaScriptObject</b> method and use the{" "}
          <b>JavaScriptValue</b> object to register .NET objects, properties, or
          methods to the <b>Formium.external</b> object of the JavaScript
          environment.
        </p>
        <p>
          <b>Inject objects into .NET</b>
        </p>
        <div className="alert alert-light">
          <pre>{`private void TestJSObject()
{
    var pObj = new JavaScriptObject();

    pObj.DefineProperty("title", () => new JavaScriptValue(Title), (v) =>
    {
        InvokeIfRequired(() => Title = v);
    });

    pObj.Add("version", $"{Assembly.GetExecutingAssembly().GetName().Version}");

    pObj.Add("syncfunc", (args) =>
    {
        InvokeIfRequired(() =>
        {
            string x = args.Count > 0 ? args[0] : "no content";
            MessageBox.Show(WindowHandle, $"JavaScript Result: {x}", "Test");
        });

        return null;
    }
    );

    var childObj = new JavaScriptObject();

    childObj.DefineProperty("now", () => new JavaScriptValue(DateTime.Now));

    childObj.Add("msgbox", (args) =>
    {
        var msg = args.FirstOrDefault(x => x.IsString)?.GetString() ?? "Nothing";

        InvokeIfRequired(() =>
        {
            MessageBox.Show(WindowHandle, $"JavaScript said: {msg}", "Message from JavaScript");
        });

        return null;
    });

    childObj.Add("NullTest", new JavaScriptValue());

    pObj.Add("innerObject", childObj);

    pObj.Add("jsonObject", new JavaScriptJsonValue(new { a = 1, b = 2, c = "test" }));

    pObj.Add("asyncfunc", async (args, promise) =>
    {
        var delayedExpire = new Random().Next(3000);

        await Task.Delay(delayedExpire);

        var rnd = new Random().Next(50);

        if(rnd <=5)
        {
            // Simulate the Reject situation, so that this asynchronous method has a chance to trigger reject
            promise.Reject($"[REJECTED]: Delayed for {delayedExpire} ms");
        }
        else
        {
            promise.Resovle(new JavaScriptValue($"[RESOVLED]: Delayed for {delayedExpire} ms"));
        }
    });

    RegisterJavaScriptObject("tester", pObj);
}`}</pre>
        </div>
        <p>
          <b>Test objects in JavaScript</b>
        </p>
        <p>
          You can now open <b>Developer Tools</b> from the left and enter the
          following code in the console to observe the injected .NET objects, or
          perform various methods from .NET yourself.
        </p>
        <div className="alert alert-light">
          <pre>{`> Formium.external.tester`}</pre>
        </div>
        <p>
          You can use traditional way to call NanUI async methods like this.
        </p>
        <div className="alert alert-light">
          <pre>{`> Formium.external.tester.asyncfunc().then(result=>console.log(result)).catch(err=>console.log(err))`}</pre>
        </div>
        <p>
          Async methods can also be used using the new async/await keywords.
        </p>
        <div className="alert alert-light">
          <pre>{`> await Formium.external.tester.asyncfunc()`}</pre>
        </div>
      </div>

      <h2>JavaScript Window Binding</h2>
      <div className="section-block">
        <p>
          In addition to using the above method to register .NET objects in the
          current JavaScript environment, you can also use JavaScript Window
          Binding technology to register your .NET objects as global JavaScript
          objects. For the knowledge of JavaScript Window Binding in CEF, please
          refer to the official CEF document "
          <a
            href="https://bitbucket.org/chromiumembedded/cef/wiki/JavaScriptIntegration"
            rel="noreferrer"
            target="_blank"
          >
            JavaScriptIntegration
          </a>
          ".{" "}
        </p>
        <p>
          NanUI simplifies the binding process of CEF's JavaScript form. For
          specific implementation methods, please check the sample source code{" "}
          <b>DemoWindowExtension\DemoWindow.cs</b> file and{" "}
          <b>Resources\DemoWindow.js</b> file. DemoWindow.js is the core of
          JavaScript window binding, and the function with the native keyword
          will automatically correspond to the .NET method registered in
          DemoWindow.cs. You can simply understand that the front-end
          DemoWindow.js file is the outline of the back-end DemoWindow.cs, and
          the methods mentioned in the JavaScript outline (with the native
          keyword) will be automatically bound to the corresponding methods of
          .NET.
        </p>
        <p>
          Objects registered using JavaScript Window Binding will be directly
          bound to all browser views (including iframes). Open the{" "}
          <b>Developer Tools</b> from the left and enter the following code in
          the console to observe the injected .NET object.
        </p>
        <div className="alert alert-light">
          <pre>{`> DemoWindow`}</pre>
        </div>
      </div>
    </article>
  );
};

export default Page;
