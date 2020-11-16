import React from "react";
import img from "./images/preview.png";
import qrcode_img from "./images/qrcode.png";
import paypal_img from "./images/paypal.png";
const Page = () => (
  <article>
    <section>
      <h2>About</h2>
      <p>
        WinFormium, the rendering engine of NanUI is based on Chromium Embedded
        Framework, so you can use various front-end technologies
        (HTML5/CSS3/JavaScript) and frameworks (React/Vue/Angular/Blazor) to
        design and develop user interface of .NET desktop applications.
      </p>

      <p>
        NanUI uses Chromium Embedded Framework as the rendering core, so users
        can use various front-end technologies HTML5/CSS3/JavaScript and
        frameworks such as React/Vue/Angular/Blazor to design and develop the
        user interface of .NET desktop applications.
      </p>
      <p>
        And The JavaScript Bridge can easily and concisely relize the
        communication and data exchanges between the browser and .NET
        enviroment.
      </p>
      <p>
        Using NanUI will bring you unlimited possibilities for designing and
        developmenting the UI of traditional WinForm applications!
      </p>

      <p>
        <img src={img} className="img-fluid" alt="Preview" />
      </p>
      <p>
        <b>
          If you like NanUI project, please light up a star⭐ for this project!
        </b>
      </p>
      <p>
        Please consider rewarding the project author or sponsoring the project
        so that the NanUI project can be developed and iterated continuously.
        Thank you for your support and attention!
      </p>
    </section>
    <section>
      <h2>Documentation</h2>
      <p>
        The Documentation will help you to start developing with NanUI easily
        and quickly. You can find more information about NanUI from links below.
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
    </section>
    <section>
      <h2>Sponsor</h2>
      <p>
        The NanUI project is an open source project based on the LGPL-3.0
        agreement and it is completely free. Without proper financial support,
        project maintenance and the development of new features cannot be
        sustained. So if you like this project and approve of my work, you buy
        me a cup of coffee, or you can become a long-term project sponsor to
        help NanUI better.
      </p>

      <p>
        <b>
          Use WeChat or Alipay to scan the QR code below to make a donation.
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
          If you are not in China, please click the icon below to jump to the
          PayPal to make a donation.
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
    </section>
  </article>
);

export default Page;
