import React from "react";
import qrcode_img from "./images/qrcode.png";
import paypal_img from "./images/paypal.png";

const Page = () => {
  return (
    <article>
      <h2>About</h2>
      <div className="section-block">
        <p>
          NanUI is an open source .NET / .NET Core UI Component for WinForms. It
          is suitable for .NET developers who want to use front-end technologies
          such as HTML5/CSS3/JavaScript to build the user interface of Windows
          Form Applications.
        </p>
        <p>
          The NanUI project is based on Google's open source project Chromium
          Embedded Framework (CEF), so you can use various web front-end
          technologies and trendy front-end frameworks
          (React/Vue/Angular/Blazor, etc.) to design and develop your. NET
          desktop application program, and using NanUI's{" "}
          <b>JavaScript Bridge</b> and <b>DataServiceResource</b> you can easily
          realize the communication and data exchange between the browser and
          the .NET environment.
        </p>
        <p>
          When you use NanUI for application development, you not only have all
          the functions provided by the .NET framework, but you can also use Web
          technology to make user interfaces quickly and conveniently. So, just
          like NanUI's slogan, using NanUI will bring unlimited possibilities to
          your WinForms application design and development!
        </p>
      </div>

      <h2>Tutorials</h2>

      <div className="section-block">
        <p>
          The help document will help you to start developing with NanUI easily
          and quickly; you can also find more topics, documents and videos about
          NanUI on the following sites.
          <br />
          Navigate to the address below to learn more about how to develop with
          NanUI.
        </p>

        <div className="block-container">
          <div className="panel docs">
            <div>
              <h3>Documentation</h3>
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
              <h3>Videos</h3>
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
                  Zhihu
                </a>
              </p>
              <p>
                <a
                  href="https://www.ixigua.com/6804465191196033540?id=6798031330459255303"
                  rel="noreferrer"
                  target="_blank"
                >
                  XiGua
                </a>
              </p>
            </div>
          </div>
        </div>
      </div>

      <h2>Donation</h2>
      <div className="section-block">
        <p>
          The NanUI project is an open source project based on MIT and it is
          completely free. However, without proper financial support, project
          maintenance and development of new features will not be sustainable.
          If you like this project and approve of my work, you can buy me a cup
          of coffee, or you can become a long-term funder of the project to help
          this project become better.
        </p>

        <p>
          <b>
            Use WeChat or Alipay to scan the QR code below to make a financial
            donation.
          </b>
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
          <b>
            For overseas users, please connect to PayPal by clicking the icon
            below to make a donation.
          </b>
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
