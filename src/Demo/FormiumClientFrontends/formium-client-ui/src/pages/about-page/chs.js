import "./Page.scss";
import React from "react";
import qrcode_img from "./images/qrcode.png";
import paypal_img from "./images/paypal.png";

const Page = () => {
  return (
    <article>
      <h2>项目简介</h2>
      <div className="section-block">
        <p>
          NanUI 界面组件是一个开放源代码的 .NET / .NET Core
          窗体应用程序（WinForms）框架。它适用于希望使用 HTML5/CSS3/JavaScript
          等前端技术来构建 Windows 窗体应用程序用户界面的 .NET 开发人员。
        </p>
        <p>
          因为 NanUI 项目基于谷歌公司开源的可嵌入式浏览器框架 Chromium Embedded
          Framework (CEF)，所以您可以使用各种 Web 前端技术和潮流前端框架
          （React/Vue/Angular/Blazor等）来设计和布局您的 .NET
          桌面应用程序界面，并通过 NanUI 特有的<b>JavaScript Bridge</b>和
          <b>数据资源处理器</b>方便地实现浏览器前端与 .NET
          后台之间的通信和数据交换。
        </p>
        <p>
          使用 NanUI 进行应用程序开发时，您既拥有了 .NET
          框架所提供的全部功能，同时还能使用 Web
          技术方便快速的制作用户界面。所以，正如 NanUI 的宣传口号一样，使用
          NanUI 界面框架将给 WinForms 应用程序的设计和开发带来无限种可能！
        </p>
      </div>

      <h2>教程和帮助</h2>

      <div className="section-block">
        <p>
          帮助文档将帮助您轻松快速的开始使用 NanUI
          进行开发；您还可以在下述平台找到更多关于 NanUI 的话题、文档和视频。
          <br />
          导航到下面地址，了解更多有关于如何使用 NanUI 进行开发的信息。
        </p>

        <div className="block-container">
          <div className="panel docs">
            <div>
              <h3>文档</h3>
              <p>
                <a
                  href="https://github.com/NetDimension/NanUI/blob/master/docs/documentation.md"
                  target="_blank"
                  rel="noreferrer"
                >
                  GitHub
                </a>
              </p>
              <p>
                <a
                  href="https://gitee.com/dotNetChina/NanUI/blob/master/docs/documentation.md"
                  target="_blank"
                  rel="noreferrer"
                >
                  Gitee
                </a>
              </p>
            </div>
          </div>
          <div className="panel video">
            <div>
              <h3>视频</h3>
              <p>
                <a
                  href="https://space.bilibili.com/396855974/channel/detail?cid=113298"
                  rel="noreferrer"
                  target="_blank"
                >
                  bilibili
                </a>
              </p>
              <p>
                <a
                  href="https://zhuanlan.zhihu.com/nanui"
                  rel="noreferrer"
                  target="_blank"
                >
                  知乎专栏
                </a>
              </p>
              <p>
                <a
                  href="https://www.ixigua.com/6804465191196033540?id=6798031330459255303"
                  rel="noreferrer"
                  target="_blank"
                >
                  西瓜视频
                </a>
              </p>
            </div>
          </div>
        </div>
      </div>

      <h2>捐赠或赞助</h2>
      <div className="section-block">
        <p>
          NanUI 项目基于 MIT
          协议的开源项目并且它是完全免费的。尽管如此，如果没有适当的资金支持，项目维护和新功能的开发是无法持续下去的。所以如果你喜欢这个项目并认可我的工作，你可以支付我一杯咖啡的钱请我喝一杯咖啡，或者你也可以成为长期的项目资助人以帮助此项目变得更好。
        </p>

        <p>
          <b>使用微信或者支付宝扫描下方二维码来进行资金方面的捐助。</b>
        </p>
        <p>
          <img
            src={qrcode_img}
            className="img-fluid"
            alt="DONATE"
            style={{ maxWidth: "500px" }}
          />
        </p>
        <p>
          <b>海外用户请通过点击下方图标连接到 PayPal 平台进行捐助。</b>
        </p>
        <p>
          <a
            href="https://www.paypal.me/mrjson"
            className="img-fluid"
            target="_blank"
            rel="noreferrer"
          >
            <img src={paypal_img} alt="DONATE" />
          </a>
        </p>
      </div>
    </article>
  );
};

export default Page;
