import React from "react";
import img from "./images/preview.png";
import qrcode_img from "./images/qrcode.png";
import paypal_img from "./images/paypal.png";
const Page = () => (
  <article>
    <section>
      <h2>关于</h2>

      <p>
        NanUI 界面组件是一个开放源代码的 .NET / .NET Core
        窗体应用程序（WinForms）界面组件。她适用于希望使用 HTML5/CSS3
        等前端技术来构建 Windows 窗体应用程序用户界面的 .NET/.NET Core
        开发人员。
      </p>

      <p>
        NanUI 使用谷歌可嵌入的浏览器框架 Chromium Embedded Framework
        作为渲染核心，因此用户可以使用各种前端技术 HTML5/CSS3/JavaScript 和框架
        React/Vue/Angular/Blazor 设计和开发.NET 桌面应用程序的用户界面。
      </p>
      <p>
        同时，WinFormium 特有的 JavaScript Bridge 可以方便简洁地实现浏览器端与
        .NET 之间的通信和数据交换。
      </p>
      <p>
        使用 NanUI 界面框架将为传统的 WinForm
        应用程序的用户界面设计和开发工作带来无限种可能！
      </p>

      <p>
        <img src={img} className="img-fluid" alt="Preview" />
      </p>
      <p>
        <b>如果你喜欢 NanUI 项目，请为本项点亮一颗星 ⭐！</b>
      </p>
      <p>
        此外也请您考虑打赏项目作者或者为项目提供赞助，以便 NanUI
        项目得以长期开发和持续迭代，感谢您的支持和关注！
      </p>
    </section>
    <section>
      <h2>帮助与支持</h2>
      <p>
        帮助文档将帮助您轻松快速的开始使用 NanUI
        进行开发。选择下面地址了解如何使用 NanUI 界面框架进行开发的详细信息。
      </p>
      <ul>
        <li>
          <a
            href="https://github.com/NetDimension/NanUI/NetDimension/NanUI/blob/master/docs/documentation.md"
            target="_blank"
            rel="noreferrer"
          >
            GitHub
          </a>
        </li>

        <li>
          <a
            href="https://gitee.com/linxuanchen/NanUI/blob/master/docs/documentation.md"
            target="_blank"
            rel="noreferrer"
          >
            Gitee
          </a>
        </li>
      </ul>
      <p>此外您还可以在下述平台找到更多关于 NanUI 的话题、文档和视频。</p>
      <ul>
        <li>
          [知乎专栏]{" "}
          <a
            href="https://zhuanlan.zhihu.com/nanui"
            rel="noreferrer"
            target="_blank"
          >
            NanUI 技术内幕
          </a>
        </li>
        <li>
          [Bilibili]{" "}
          <a
            href="https://space.bilibili.com/396855974/channel/detail?cid=113298"
            rel="noreferrer"
            target="_blank"
          >
            码农 JSON 的 NanUI 入门教程频道
          </a>
        </li>
        <li>
          [西瓜视频]{" "}
          <a
            href="https://www.ixigua.com/6804465191196033540?id=6798031330459255303"
            rel="noreferrer"
            target="_blank"
          >
            NanUI 入门教程频
          </a>
        </li>
      </ul>
      <p>
        另外，您还可以加入 NanUI 的 QQ 群获得更及时的版本发布、问题反馈信息。
      </p>
      <ul>
        <li>NanUI 交流群 - 521854872</li>
      </ul>
    </section>
    <section>
      <h2>资助项目</h2>
      <p>
        NanUI 项目基于 LGPL-3.0
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
    </section>
  </article>
);

export default Page;
