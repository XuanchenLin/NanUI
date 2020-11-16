import React, { useState } from "react";
import { openLocalFileResourceFolder } from "../../FormiumBridge";
const IFRAME_URL = "http://static.app.local";

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
      <section>
        <h2>资源</h2>
        <p>
          资源控制器是 NanUI 加载外部资源的重要组件。NanUI 对 CEF
          的资源控制器进行了封装和简化，您无需自己处理数据流和各种资源接口。
        </p>
        <p>NanUI 以扩展插件的形式实现了四种常用的资源控制器：</p>
        <ul>
          <li>
            <h5>程序集资源处理器</h5>
            <p>
              程序集资源处理器（EmbeddedFileResource）用于加载作为嵌入的资源打包到程序集里的各种资源文件。
            </p>
            <p>
              当前运行的示例所使用的 Web 资源就是使用<b>程序集资源处理器</b>
              进行处理的。
            </p>
          </li>
          <li>
            <h5>压缩包资源处理器</h5>
            <p>
              压缩包资源处理器（ZippedResource）用于加载程序集内或者物理路径中使用
              ZIP 压缩后的各种资源文件。
            </p>
            <p>
              <b>窗体样式</b>选项卡中的<b>亚克力窗体示例</b>
              使用的资源就是使用<b>压缩包资源处理器</b>
              从Zip压缩包中获取的，该压缩包作为本示例的资源嵌入到了程序集内。
            </p>
          </li>
          <li>
            <h5>文件资源处理器</h5>
            <p>
              文件资源处理器（LocalFileResource）用于加载指定物理文件夹中的各种资源文件。
            </p>
            <p>
              当资源文件太大时把大文件嵌入到程序集或者打包都是不现实的。所以如果资源文件比较大（例如视频、音频等）或者资源文件是需要动态操作的（例如大量下载的图片、动态生成的文档等），那么使用文件资源处理器将是是一个很好的选择。
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
                className="btn btn-primary"
                onClick={() => refreshFrame()}
              >
                刷新框架
              </button>{" "}
              <button
                className="btn btn-light"
                onClick={() => openLocalFileResourceFolder()}
              >
                打开资源目录
              </button>
            </p>
            <p>
              上面 iframe 中的文件来自于本示例程序目录下面的
              <b>LocalFiles</b>
              文件夹。您可以尝试在示例运行时修改该文件夹里的文件并刷新框架来查看结果。
            </p>
          </li>
          <li>
            <h5>数据资源处理器</h5>
            <p>
              数据资源处理器（DataServiceResource）用于向前端环境提供后台数据。如果您之前接触过
              Asp.Net Mvc 的控制器，那么 NanUI
              的数据资源处理器提供了类似的开发体验。
            </p>
            <p>
              您现在可以从左侧打开<b>开发者工具</b>
              在控制台中输入下面代码测试数据资源处理器。
            </p>
            <p>以 GET 方式从数据服务获取数据。</p>
            <div className="alert alert-secondary">
              {`fetch("https://api.app.local/Hello/Hi").then(response=>response.text()).then(text=>console.log(text));`}
            </div>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => {
                  fetch("https://api.app.local/Hello/Hi")
                    .then((response) => response.text())
                    .then((text) => alert(`响应结果：\n${text}`));
                }}
              >
                测试
              </button>
            </p>
            <p>以 POST 方式传递 JSON 对象到数据服务并获取数据。</p>
            <div className="alert alert-secondary">
              {`fetch("https://api.app.local/account/user/login",{ method:"post",body:JSON.stringify( {passport:'<用户名>',password:'iamapassword'}), headers: new Headers({'Content-Type':'application/json'}) }).then(response=>response.json()).then(json=>console.log(json));`}
            </div>
            <p>
              <button
                className="btn btn-primary"
                disabled={isPostingDataToDataService}
                onClick={(e) => {
                  alert(
                    `即将使用JSON格式以POST方式提交数据：{passport:"admin", password:"I Love NanUI"}。数据服务将模拟延迟2秒后返回结果。`
                  );

                  setIsPostingDataToDataService(true);

                  fetch("https://api.app.local/account/user/login", {
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
              具体实现可以查看本示例源码<b>DataServices</b>
              文件夹中的数据控制器。
            </p>
          </li>
        </ul>
      </section>
    </article>
  );
};

export default Page;
