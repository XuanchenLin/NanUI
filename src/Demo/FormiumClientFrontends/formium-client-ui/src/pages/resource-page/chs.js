import React, { useState } from "react";
import { openLocalFileResourceFolder } from "../../FormiumBridge";
const IFRAME_URL = "http://static.app.local/index.chs.html";

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
      <h2>程序集资源处理器</h2>
      <div className="section-block ">
        <p>
          程序集资源处理器（EmbeddedFileResource）用于加载作为嵌入的资源打包到程序集里的各种资源文件。
        </p>
        <p>
          当前运行的示例所使用的 Web 资源就是使用<b>程序集资源处理器</b>
          进行处理的。
        </p>
        <p>程序集资源处理器的具体使用方法请参照 NanUI 文档中的《<a href="https://gitee.com/dotnetchina/NanUI/blob/master/docs/zh-CN/resource-handler-embedded.md" target="_blank" rel="noreferrer" >程序集资源处理器</a>》相关介绍</p>
      </div>

      <h2>文件资源处理器</h2>
      <div className="section-block ">
        <p>
          文件资源处理器（LocalFileResource）用于加载指定物理文件夹中的各种资源文件。
        </p>
        <p>
          当资源文件太大时把大文件嵌入到程序集或者打包都是不现实的，因此当资源文件比较大（例如视频文件、音频文件等）或者资源文件是需要动态操作的（如需要大量下载的图片、动态生成的文档等），那么使用文件资源处理器将是很好的选择。
        </p>

        <p>
          下面 iframe 中的文件来自于本示例程序目录下面的
          <b>LocalFiles</b>
          文件夹。您可以尝试在示例运行时修改该文件夹里的文件并刷新框架来查看结果。
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
            刷新框架
          </button>{" "}
          <button
            className="btn btn-outline-secondary"
            onClick={() => openLocalFileResourceFolder()}
          >
            打开资源目录
          </button>
        </p>

        <p>文件资源处理器的具体使用方法请参照 NanUI 文档中的《<a href="https://gitee.com/dotnetchina/NanUI/blob/master/docs/zh-CN/resource-handler-local-file.md" target="_blank" rel="noreferrer" >文件资源处理器</a>》相关介绍</p>
      </div>

      <h2>数据资源处理器</h2>
      <div className="section-block ">
        <p>
          数据资源处理器（DataServiceResource）用于向前端环境提供数据。如果您之前接触过 Asp.Net Mvc 的控制器，那么您会发现 NanUI 的数据资源处理器提供了相似的开发体验。
        </p>
        <p>
          您现在可以从左侧打开<b>开发者工具</b>在控制台中输入下面代码测试数据资源处理器。
        </p>
        <p>下面使用两个例子演示数据资源处理器的使用方法。</p>
        <h5>以 GET 方式从数据服务获取数据</h5>
        <p>在这个示例中，我们在 .NET 中注册了一个 Hi 接口，并映射到默认的 /hello/hi 这个地址上。前端通过 GET 方式调用此接口成功后返回 "Hello world!" 文案。</p>
        <p><b>在 .NET 中注册服务</b></p>
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
        <p><b>在 JavaScript 中调用服务</b></p>
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
                .then((result) => alert(`响应结果：\n${result}`));
            }}
          >
            测试
          </button>
        </p>
        <h5>以 POST 方式传递 JSON 对象到数据服务并获取数据</h5>
        <p>下面的示例中，我们在 .NET 中注册了一个 Login 接口，并映射到指定的 /account/user/login 这个地址上（这个地址由服务指定的地址 /account 和接口指定的地址 user/login 组成）。客户端使用 POST 方式提交一段包含了用户名和密码的 JSON 模拟数据，.NET 将处理这段数据并模拟延迟 2 秒后返回成功状态的 JSON 数据。</p>
        <p><b>在 .NET 中注册服务</b></p>
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
        <p><b>在 JavaScript 中调用服务</b></p>
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
          具体实现可以查看本示例源码<b>DataServices</b>文件夹中的数据控制器。
        </p>
        <p>具体使用方法请参照 NanUI 文档中的《<a href="https://gitee.com/dotnetchina/NanUI/blob/master/docs/zh-CN/resource-handler-data-services.md" target="_blank" rel="noreferrer" >数据资源处理器</a>》相关介绍</p>
      </div>
    </article>
  );
};

export default Page;
