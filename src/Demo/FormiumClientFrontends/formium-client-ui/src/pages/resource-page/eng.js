import React, { useState } from "react";
import { openLocalFileResourceFolder } from "../../FormiumBridge";
const IFRAME_URL = "http://static.app.local/index.eng.html";

const Page = () => {
  const iframeRef = React.createRef();

  const refreshFrame = () => {
    const iframe = iframeRef.current?.contentWindow;

    if (iframe) {
      iframe.postMessage("refresh", IFRAME_URL);
    }
  };

  const [isPostingDataToDataService, setIsPostingDataToDataService] = useState(
    false
  );

  return (
    <article>
      <h2>EmbeddedFileResource</h2>
      <div className="section-block ">
        <p>
          EmbeddedFileResource handler is used to load resource files that are packaged in assemblies.
        </p>
        <p>
          The resources used in this program are processed using the <b>EmbeddedFileResource</b> handler.
        </p>
        <p>For more usage information please see <a href="https://github.com/NetDimension/NanUI/blob/master/docs/en-US/resource-handler-embedded.md " target="_blank" rel="noreferrer" >EmbeddedFileResource</a>.</p>
      </div>

      <h2>LocalFileResource</h2>
      <div className="section-block ">
        <p>
          LocalFileResource is used to load resource files in the specified
          physical folder.
        </p>
        <p>
          When the resource file is too large, it is unrealistic to embed
          the large file into the assembly or package it. So if the resource
          file is relatively large, such as video, audio, etc., or the
          resource file needs to be dynamically operated, such as downloaded
          pictures, dynamically generated documents, etc., then using a file
          resource processor will be a good choice.
        </p>

        <p>
          The files below in the iframe come from the <b>LocalFiles</b> folder under the currently running example directory. You can try to modify the files in the folder and refresh the iframe while the example is running to see the changes.
        </p>
        <p>
          <iframe
            src={IFRAME_URL}
            ref={iframeRef}
            allow="autoplay"
            id={`resource_page_chs`}
            title="resource_page_chs"
          ></iframe>
        </p>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={() => refreshFrame()}
          >
            Refresh
          </button>{" "}
          <button
            className="btn btn-outline-secondary"
            onClick={() => openLocalFileResourceFolder()}
          >
            Resource Folder
          </button>
        </p>

        <p>For more usage information please see  <a href="https://github.com/NetDimension/NanUI/blob/master/docs/en-US/resource-handler-local-file.md" target="_blank" rel="noreferrer" >LocalFileResource</a>.</p>
      </div>

      <h2>DataServiceResource</h2>
      <div className="section-block ">
        <p>
          DataServiceResource is used to provide background data to the
          front-end environment. If you have used the Asp.Net Mvc controller
          before, DataServiceResource will provide a similar development
          experience.
        </p>
        <p>
          You can now open <b>Developer Tools</b> from the left and enter
          the following code in the console to test the DataServiceResource.
        </p>
        <p>The following two examples are used to introduce how to use the DataServiceResource.</p>
        <h5>Get data from the data service by GET</h5>
        <p>In this example, we have registered a Hi interface in .NET and mapped it to the default /hello/hi address. The front end successfully calls this interface via GET and returns the "Hello world!".</p>
        <p><b>Register the service in .NET</b></p>
        <div className="alert alert-light">
          <pre>
            {`public class HelloService : DataService
{
    //GET /hello/hi
    public ResourceResponse Hi(ResourceRequest request)
    {
        return Text("Hello world!");
    }
}`}
          </pre>
        </div>
        <p><b>Invoke the service in JavaScript</b></p>
        <div className="alert alert-light">
          <pre>
            {`fetch("http://api.app.local/Hello/Hi")
.then(response=>response.text())
.then(text=>console.log(text));`}
          </pre>

        </div>
        <p>
          <button
            className="btn btn-outline-secondary"
            onClick={(e) => {
              fetch("http://api.app.local/Hello/Hi")
                .then((response) => response.text())
                .then((result) => alert(`Result:\n${result}`));
            }}
          >
            Run
          </button>
        </p>
        <h5>Pass the JSON object to the data service by POST and get the response data</h5>
        <p>In the following example, we have registered a Login interface in .NET and mapped it to the specified address /account/user/login (this address is composed of the address specified by the service /account and the address specified by the interface user/login) . The client uses the POST method to submit a piece of JSON simulation data that contains the username and password. .NET will process this data and simulate the JSON data that returns a success status after a delay of 2 seconds.</p>
        <p><b>Register the service in .NET</b></p>
        <div className="alert alert-light">
          <pre>
            {`[DataRoute("/account")]
public class PassportService : DataService
{
    public class UserInfo
    {
        public string Passport { get; set; }
        public string Password { get; set; }

    }
    
    private string GetTimeStamp()
    {
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }

    //POST /account/user/login
    [RoutePost("user/login")]
    public ResourceResponse Login(ResourceRequest request)
    {
        var result = request.DeserializeObjectFromJson<UserInfo>();

        Task.Delay(2000).GetAwaiter().GetResult();

        return Json(new { success = true, timestamp = GetTimeStamp(), result });
    }
}`}
          </pre>
        </div>
        <p><b>Invoke the service in JavaScript</b></p>
        <div className="alert alert-light">
          <pre>
            {`fetch("http://api.app.local/account/user/login",{
  method: "post",
  body: JSON.stringify({
    passport: 'admin',
    password: 'I Love NanUI'
  }),
  headers: new Headers({
    'Content-Type': 'application/json'
  })
})
.then(response => response.json())
.then(result => console.log(result));`}
          </pre>
        </div>
        <p>
          <button
            className="btn btn-outline-secondary"
            disabled={isPostingDataToDataService}
            onClick={(e) => {
              setIsPostingDataToDataService(true);

              fetch("http://api.app.local/account/user/login", {
                method: "post",
                body: JSON.stringify({
                  passport: "admin",
                  password: "I Love NanUI",
                }),
                headers: new Headers({
                  "Content-Type": "application/json",
                }),
              })
                .then((response) => response.json())
                .then((json) =>
                  alert(`响应结果：\n${JSON.stringify(json)}`)
                )
                .finally(() => setIsPostingDataToDataService(false));
            }}
          >
            {isPostingDataToDataService ? "等待中..." : "测试"}
          </button>
        </p>
        <p>
          For specific implementation, you can view the data controller in the <b>DataServices</b> folder of the source code of this example.
        </p>
        <p>For more usage information please see  <a href="https://github.com/NetDimension/NanUI/blob/master/docs/zh-CN/resource-handler-data-services.md" target="_blank" rel="noreferrer" >DataServiceResource</a>.</p>
      </div>
    </article>
  );
};

export default Page;
