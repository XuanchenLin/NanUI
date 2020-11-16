import React from "react";
import {
  executeJavaScriptWithRetval,
  executeJavaScriptWithoutRetval,
} from "../../FormiumBridge";

const Page = () => {
  return (
    <article>
      <h2>JavaScript</h2>
      <p>
        NanUI 提供与 CEF 的 JavaScript 环境交互的能力。您可以在 .NET
        环境中同步或异步执行 JavaScript 代码并获得返回值。
      </p>
      <p>
        此外 NanUI 还提供了注册 JavaScript 扩展的接口，您可以使用此功能扩展
        JavaScript 的功能。
      </p>

      <ul>
        <li>
          <p>
            <b>执行无返回值 JavaScript 代码</b>
          </p>
          <p>
            在 NanUI 的浏览器环境初始化之后就可以使用 <b>ExecuteJavaScript</b>{" "}
            方法来执行 JavaScript 代码。
          </p>
          <div className="alert alert-secondary">
            <pre>{`ExecuteJavaScript("alert(1+1)");`}</pre>
          </div>

          <p>
            <button
              className="btn btn-primary"
              onClick={() => executeJavaScriptWithoutRetval()}
            >
              执行
            </button>
          </p>
        </li>

        <li>
          <p>
            <b>执行有返回值 JavaScript 代码</b>
          </p>
          <p>
            在 NanUI 的浏览器环境初始化之后就可以使用{" "}
            <b>EvaluateJavaScriptAsync</b> 方法来异步执行带返回值的 JavaScript
            代码。
          </p>
          <div className="alert alert-secondary">
            <pre>
              {`var result = await EvaluateJavaScriptAsync("(function(){ return {a:1,b:'hello',c:(s)=>alert(s)}; })()");\n`}
              {`if(result.Success)\n`}
              {`{\n`}
              {`\tvar retval = result.ResultValue;\n`}
              {`\tMessageBox.Show($"a={retval.GetInt("a")} b={retval.GetString("b")}", "Value from JS");\n`}
              {`\tawait retval.GetValue("c").ExecuteFunctionAsync(GetMainFrame(), new JavaScriptValue[] { JavaScriptValue.CreateString("Hello from C#") });\n`}
              {`}`}
            </pre>
          </div>
          <p>
            <button
              className="btn btn-primary"
              onClick={() => executeJavaScriptWithRetval()}
            >
              执行
            </button>
          </p>
        </li>
        <li>
          <p>
            <b>注册 JavaScript 对象</b>
          </p>
          <p>
            使用 <b>RegisterExternalObjectValue</b> 方法并配合{" "}
            <b>JavaScriptValue</b> 对象可以将 .NET 的对象，属性或方法等注册到
            JavaScript 环境的 <b>Formium.external</b> 对象里。
          </p>
          <p>
            您现在可以从左侧打开<b>开发者工具</b>
            在控制台中输入下面代码观察注入的 .NET 对象。
          </p>
          <div className="alert alert-secondary">
            <pre>{`> Formium.external.tester`}</pre>
          </div>
        </li>
        <li>
          <p>
            <b>注册 JavaScript 扩展</b>
          </p>
          <p>
            使用 JavaScript 扩展生成的对象可以在 CEF 的各个 Frame
            中调用，这点与使用 <b>RegisterExternalObjectValue</b>{" "}
            方法注册的对象只能用于当前 frame 有所区别。
          </p>
          <p>
            您现在可以从左侧打开<b>开发者工具</b>
            在控制台中输入下面代码观察注入的 JavaScript 扩展。
          </p>
          <div className="alert alert-secondary">
            <pre>{`> DemoWindow`}</pre>
          </div>
          <p>
            NanUI
            提供简便的注册扩展的方法，能够注册同步和异步的方法。请查看示例项目
            <code>DemoWindowExtension</code>文件夹中的源码。
          </p>
        </li>
      </ul>
    </article>
  );
};

export default Page;
