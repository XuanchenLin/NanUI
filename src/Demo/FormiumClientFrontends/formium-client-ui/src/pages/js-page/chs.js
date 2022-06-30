import React from "react";
import {
  executeJavaScriptWithRetval,
  executeJavaScriptWithoutRetval,
} from "../../FormiumBridge";

const Page = () => {
  return (
    <article>
      <h2>从 .NET 执行 JavaScript 代码</h2>
      <div className="section-block">
        <p>
          NanUI 提供与 CEF 的 JavaScript 环境交互的能力。您可以在 .NET
          环境中同步或异步执行 JavaScript 代码并获得返回值。
        </p>
        <p>
          <b>执行无返回值 JavaScript 代码</b>
        </p>
        <p>
          在 NanUI 的浏览器环境初始化之后就可以使用 <b>ExecuteJavaScript</b>{" "}
          方法来执行 JavaScript 代码。
        </p>
        <div className="alert alert-light">
          <pre>{`ExecuteJavaScript("alert(1+1)");`}</pre>
        </div>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={() => executeJavaScriptWithoutRetval()}
          >
            执行
          </button>
        </p>
        <p>
          <b>执行有返回值 JavaScript 代码</b>
        </p>
        <p>
          在 NanUI 的浏览器环境初始化之后就可以使用{" "}
          <b>EvaluateJavaScriptAsync</b> 方法来异步执行带返回值的 JavaScript
          代码。
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
    
    // 获取JavaScript执行结果
    var obj = retval.Value.ToObject();

    int value_a = obj["a"];
    string value_b = obj["b"];
    
    // 调用方法c
    await obj["c"].ExecuteAsync(new JavaScriptValue("Hello World!"));
    // 调用方法c
    await obj["c"].ExecuteAsync(new JavaScriptValue("Goodbye World!"));
    
    // 执行异步方法d，并模拟延迟并返回成功结果
    var d1 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction(async (args, promise) =>
    {
        await Task.Delay(1000);
        promise.Resovle(new JavaScriptValue("hello"));
    }));
    // 执行异步方法d，并返回失败结果
    var d2 = await obj["d"].ExecuteAsync(new JavaScriptAsyncFunction((args, promise) =>
    {
        promise.Reject("Oops! This will be caught by catch method in a promise.");
    }));
    
    // 不带参数执行方法e
    var e1 = await obj["e"].ExecuteAsync();
    // 带参数执行方法e
    var e2 = await obj["e"].ExecuteAsync(new JavaScriptValue("Xuanchen Lin"));

    // 执行方法f，并用一个包含了属性的对象作为参数
    var f = await obj["f"].ExecuteAsync(fobj);
}`}
          </pre>
        </div>
        <p>
          您可以在示例源码 MainWindow.cs 的 TestEvaluateJavaScriptAsync
          方法中设置上断点，单步调试方法内的代码来查看每一步代码执行的详情。
        </p>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={() => executeJavaScriptWithRetval()}
          >
            执行
          </button>
        </p>
      </div>

      <h2>在 JavaScript 中注册 .NET 对象</h2>
      <div className="section-block">
        <p>
          使用 <b>RegisterJavaScriptObject</b> 方法并配合 <b>JavaScriptValue</b>{" "}
          对象可将 .NET 的对象、属性或方法等注册到 JavaScript 环境的{" "}
          <b>Formium.external</b> 对象里。
        </p>
        <p>
          <b>在 .NET 中注入对象</b>
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
            // 模拟Reject情况，让这个异步方法有几率触发reject
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
          <b>在 JavaScript 中测试对象</b>
        </p>
        <p>
          您现在可以从左侧打开<b>开发者工具</b>在控制台中输入下面代码观察注入的
          .NET 对象，或者亲自执行一下来自 .NET 的各种方法。
        </p>
        <div className="alert alert-light">
          <pre>{`> Formium.external.tester`}</pre>
        </div>
        <p>您可以使用传统写法来调用 NanUI 异步方法。</p>
        <div className="alert alert-light">
          <pre>{`> Formium.external.tester.asyncfunc().then(result=>console.log(result)).catch(err=>console.log(err))`}</pre>
        </div>
        <p>也可以使用全新的 async/await 关键字来使用异步方法。</p>
        <div className="alert alert-light">
          <pre>{`> await Formium.external.tester.asyncfunc()`}</pre>
        </div>
      </div>

      <h2>JavaScript 窗体绑定</h2>
      <div className="section-block">
        <p>
          除了使用上面的方式把 .NET 的对象注册到当前 JavaScript
          环境中外，您还可以使用 JavaScript 窗体绑定技术来把您的 .NET
          对象注册为全局的 JavaScript 对象。有关 CEF 中的 JavaScript
          窗体绑定的知识，请查阅 CEF 官方文档《
          <a
            href="https://bitbucket.org/chromiumembedded/cef/wiki/JavaScriptIntegration"
            rel="noreferrer"
            target="_blank"
          >
            JavaScriptIntegration
          </a>
          》。
        </p>
        <p>
          NanUI 简化了 CEF 的 JavaScript
          窗体绑定过程。具体实现方式请查看本示例源代码
          <b>DemoWindowExtension\DemoWindow.cs</b>文件以及
          <b>Resources\DemoWindow.js</b>文件。DemoWindow.js 是 JavaScript
          窗体绑定的核心，其中带有 native 关键字的 function 将自动对应到
          DemoWindow.cs 中注册的 .NET 方法。您可以简单的理解为前端的
          DemoWindow.js 文件既是后端的 DemoWindow.cs 的提纲，JavaScript
          提纲中所提及（带有 native 关键字）的方法将自动绑定到 .NET
          对应的方法上。
        </p>
        <p>
          使用 JavaScript 窗体绑定注册的对象将直接绑定到所有浏览器视图（包括
          iframe）里。从左侧打开<b>开发者工具</b>
          在控制台中输入下面代码观察注入的 .NET 对象。
        </p>
        <div className="alert alert-light">
          <pre>{`> DemoWindow`}</pre>
        </div>
      </div>
    </article>
  );
};

export default Page;
