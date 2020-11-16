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
        NanUI provides the ability to interact with CEF's JavaScript
        environment. You can execute JavaScript code synchronously or
        asynchronously in the .NET environment and get the return value from
        JavaScript.
      </p>
      <p>
        NanUI also provides interfaces for registering JavaScript extensions.
        You can use this feature to extend JavaScript functions.
      </p>

      <ul>
        <li>
          <p>
            <b>Execute JavaScript code without return value</b>
          </p>
          <p>
            After the NanUI browser environment is initialized, you can use the{" "}
            <b>ExecuteJavaScript</b> method to execute JavaScript code.
          </p>
          <div className="alert alert-secondary">
            <pre>{`ExecuteJavaScript("alert(1+1)");`}</pre>
          </div>

          <p>
            <button
              className="btn btn-primary"
              onClick={() => executeJavaScriptWithoutRetval()}
            >
              Execute
            </button>
          </p>
        </li>

        <li>
          <p>
            <b>Execute JavaScript code with return value</b>
          </p>
          <p>
            After NanUI's browser environment is initialized, you can use the{" "}
            <b>EvaluateJavaScriptAsync</b> method to asynchronously execute
            JavaScript code with return values.
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
              Execute
            </button>
          </p>
        </li>
        <li>
          <p>
            <b>Register JavaScript objects</b>
          </p>
          <p>
            Use the <b>RegisterExternalObjectValue</b> method in conjunction
            with the <b>JavaScriptValue</b> object to register .NET objects,
            properties, or methods into the <b>Formium.external</b> object in
            the JavaScript environment.
          </p>
          <p>
            You can now open <b>Developer Tools</b> from the left and enter the
            following code in the console to view the injected .NET objects.
          </p>
          <div className="alert alert-secondary">
            <pre>{`> Formium.external.tester`}</pre>
          </div>
        </li>
        <li>
          <p>
            <b>Register JavaScript extensions</b>
          </p>
          <p>
            Objects generated using JavaScript extensions can be called in each
            frame of CEF, which is different from objects registered using the{" "}
            <b>RegisterExternalObjectValue</b> method which can only be used in
            the current frame.
          </p>
          <p>
            You can now open <b>Developer Tools</b> from the left and enter the
            following code in the console to observe the injected JavaScript
            extension.
          </p>
          <div className="alert alert-secondary">
            <pre>{`> DemoWindow`}</pre>
          </div>
          <p>
            NanUI provides an easy way to register extensions, which can
            register synchronous and asynchronous methods. Please check the
            source code in the sample project in the{" "}
            <code>DemoWindowExtension</code> folder.
          </p>
        </li>
      </ul>
    </article>
  );
};

export default Page;
