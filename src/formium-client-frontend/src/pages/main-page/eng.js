import React from "react";
import idea_img from "./images/idea.png";
import social_img from "./images/social.png";
import tech_img from "./images/technology.png";
import logo from "./images/logo.png";

const Page = () => (
  <article>
    <h2>Welcome to NanUI</h2>

    <div className="splash">
      <div className="row">
        <div className="col-md-9 col-sm-12 d-flex">
          <div className="mr-4 d-none d-md-block">
            <img width="96" src={logo} alt="" />
          </div>
          <div className="flex-grow-1">
            <p>
              This is an open source user interface framework for .NET / .NET
              Core Windows Form Applications. Mordern web front-end technologies
              can be used to build the application's user interface. It allows
              you to experience the combination of front-end frameworks such as
              React / Vue / Blazor / Angular and WinForms.
            </p>

            <p>
              Using NanUI framework will bring unlimited possibilities to your
              design of Windows Form Applications.
            </p>

            <p className="mb-4">
              If you like the NanUI project, please give the NanUI project a
              star on GitHub or Gitee!
            </p>

            <p>
              <a
                href="https://github.com/NetDimension/NanUI/"
                target="_blank"
                rel="noreferrer"
                className="btn btn-sm btn-outline-light mr-3"
              >
                <i className="fa fa-github"></i>
                GitHub
              </a>
              <a
                href="https://gitee.com/linxuanchen/NanUI"
                target="_blank"
                rel="noreferrer"
                className="btn btn-sm btn-outline-light"
              >
                <i className="fa fa-download"></i>
                Gitee
              </a>
            </p>
          </div>
        </div>
        <div className="col-md-3 col-sm-12 info">
          <p>Minimum available for Microsoft Windows 7 Service Pack 1</p>
          <p>.NET 5 / .NET Core 3.1 Or .NET Framework 4.6.2+</p>
          <p>
            Based on Chromium Embedded Framework{" "}
            <abbr title="80.0.3987.163">80.1.15</abbr>
          </p>

          <p>
            V0.8.80 •{" "}
            <a
              href="https://github.com/NetDimension/NanUI/blob/master/CHANGELOG"
              target="_blank"
              rel="noreferrer"
              className="text-white"
            >
              Release Notes
            </a>
          </p>
        </div>
      </div>
    </div>

    <h2>Advantages of NanUI</h2>

    <div className="advantage ">
      <div className="row">
        <div className="col-md-4">
          <section className="intro easy-to-use">
            <p>
              <img src={social_img} height="64" alt="" />
            </p>
            <h4>Easy to Use</h4>

            <p className="text-black-50">
              It only takes a few steps to directly use front-end technology to
              render your application interface. NanUI provides a simple and
              rich API to help you complete the complex Chromium configuration
              and initialization work, which will bring you a pleasant
              development experience.
            </p>
          </section>
        </div>
        <div className="col-md-4">
          <section className="intro fully-documentation">
            <p>
              <img src={idea_img} height="64" alt="" />
            </p>
            <h4>Tutorials</h4>
            <p className="text-black-50">
              Documentation and tutorials will guide you quickly into
              development.The community provides various development cases to
              enrich your development experience. When you encounter problems in
              development, you can also retrieve the community information to
              get solutions to problems.
            </p>
          </section>
        </div>
        <div className="col-md-4 ">
          <section className="intro new-technology">
            <p>
              <img src={tech_img} height="64" alt="" />
            </p>
            <h4>The Best Selection</h4>
            <p className="text-black-50">
              NanUI is based on Chromium™. Use the latest Web standards to build
              the interface, so you don't have to waste effort on compatibility
              issues of various versions of browsers. The popular front-end
              framework React / Vue / Blazor / Angular will also become a
              reliable development tool.
            </p>
          </section>
        </div>
      </div>
    </div>

    <h2>Features</h2>
    <div className="features ">
      <div className="row">
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583161111813"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="5629"
                  width="32"
                  height="32"
                >
                  <path
                    d="M965.153288 0.016004L964.977244 0H59.374844l-0.176044 0.016004C26.486622 0.128032 0 25.782446 0 57.502376v907.106776a59.374844 59.374844 0 0 0 59.374844 59.374844h905.6024a59.374844 59.374844 0 0 0 59.374844-59.374844V57.502376c0-31.71993-26.486622-57.374344-59.1988-57.486372z"
                    fill="#666"
                    p-id="5630"
                  ></path>
                  <path
                    d="M928.328082 191.91998h-864.216054v736.20005a32.008002 32.008002 0 0 0 32.008002 31.991998h832.208052a32.008002 32.008002 0 0 0 32.008002-31.991998V191.91998h-32.008002z"
                    fill="#FFFFFF"
                    p-id="5631"
                  ></path>
                  <path
                    d="M416.616154 576.032008a95.607902 95.607902 0 1 0 191.215804 0 95.607902 95.607902 0 0 0-191.215804 0z m-31.863966 0c0-125.135284 127.471868-127.535884 127.471868-127.535884h183.91798c-40.458115-58.23856-107.642911-96.52013-183.91798-96.52013-98.088522 0-180.541135 63.43986-210.900725 151.173793l84.565141 84.101026c-0.336084-3.744936-1.136284-7.377844-1.136284-11.218805z m329.330333-95.63991h-118.429608c26.774694 23.365841 44.027007 57.326332 44.027007 95.655914 0 55.549887-31.527882 86.453613-31.527882 86.453613l-133.105276 133.857465c12.163041 2.032508 24.43811 3.728932 37.177294 3.728932 123.742936 0 224.056014-100.313078 224.056014-224.056014 0-34.36059-8.370093-66.544636-22.197549-95.63991zM512.224056 703.503876c-56.542136 0-86.453613-31.527882-86.453613-31.527882l-133.841461-133.105276c-2.048512 12.147037-3.744936 24.422106-3.744936 37.16129 0 98.088522 63.423856 180.541135 151.173793 210.916729l84.085022-84.565141c-3.76094 0.32008-7.377844 1.12028-11.218805 1.12028z"
                    fill="#999"
                    p-id="5632"
                  ></path>
                  <path
                    d="M736.28007 63.887972l-0.32008 0.032008H96.12003a32.008002 32.008002 0 0 0 0 64.016004h640.16004a32.024006 32.024006 0 0 0 0-64.048012z m96.024006 0a32.008002 32.008002 0 1 0 0.032008 64.048012 32.008002 32.008002 0 0 0-0.032008-64.048012z m96.024006 0a32.008002 32.008002 0 1 0 0.032008 64.048012 32.008002 32.008002 0 0 0-0.032008-64.048012z"
                    fill="#FFFFFF"
                    p-id="5633"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">The Chromium</h5>
                  <p className="text-black-50">
                    The use of a relatively new and stable version of Chromium
                    ensures complete support for Web standards, effectively
                    avoids various browser compatibility issues and improves
                    stability.
                  </p>
                </div>
              </div>
            </div>
          </div>

          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583161461036"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="17587"
                  width="32"
                  height="32"
                >
                  <path
                    d="M170.821818 414.114909l-14.149818-6.702545a90.298182 90.298182 0 0 1 0-163.188364l339.921455-161.047273a90.298182 90.298182 0 0 1 77.358545 0l339.921455 161.047273a90.298182 90.298182 0 0 1 0 163.188364l-25.925819 12.334545 15.266909 7.447273c44.590545 21.876364 63.255273 75.915636 42.542546 121.111273-8.750545 19.083636-23.738182 34.629818-42.542546 43.799272l-28.811636 14.149818 28.392727 13.498182a90.484364 90.484364 0 0 1 0 163.234909l-340.48 162.443637c-24.482909 11.636364-52.875636 11.636364-77.358545 0l-340.48-162.443637a90.484364 90.484364 0 0 1 0-163.188363l28.392727-13.544728-28.858182-14.149818c-44.544-21.829818-63.208727-75.869091-42.496-121.064727 8.750545-19.083636 23.738182-34.629818 42.542546-43.799273l26.717091-13.125818z m107.52 50.967273l-90.996363 44.590545 336.290909 164.770909 336.290909-164.770909-79.592728-39.005091-206.382545 97.792a90.298182 90.298182 0 0 1-77.358545 0L278.341818 465.082182z m489.425455 193.396363l-205.032728 100.445091c-24.669091 12.101818-53.527273 12.101818-78.196363 0l-205.032727-100.445091-89.832728 42.91491 333.963637 159.32509 334.010181-159.32509-89.879272-42.91491zM201.821091 325.818182l333.451636 157.928727L868.724364 325.818182 535.272727 167.889455 201.821091 325.818182z"
                    p-id="17588"
                    fill="#666666"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">Resource Handler</h5>
                  <p className="text-black-50">
                    Users can choose multiple resource processors for different
                    scenarios to provide files, data, etc. for front-end
                    programs. In addition, you can also develop custom resource
                    processors according to specific needs.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583160830219"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="559"
                  width="32"
                  height="32"
                >
                  <path
                    d="M128 384v512h640V384H128z m624 496H144V400h608v480z"
                    p-id="560"
                    fill="#333"
                  ></path>
                  <path
                    d="M144 480h608v16H144zM256 128h16v256h-16zM272 128h624v16H272zM880 144h16v496h-16zM768 624h112v16H768zM272 224h608v16H272zM304 176h208v16H304zM176 432h208v16H176z"
                    p-id="561"
                    fill="#333"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">Host Windows</h5>
                  <p className="text-black-50">
                    The framework provides a variety of window styles, and users
                    can flexibly choose different window styles to achieve
                    different design effects and respond to various business
                    needs.
                  </p>
                </div>
              </div>
            </div>
          </div>

          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583161583545"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="18758"
                  width="32"
                  height="32"
                >
                  <path
                    d="M64 223.995345h168.001164v47.997673c0 26.428509 18.878836 47.997673 41.984 47.997673h140.036654c23.095855 0 41.984-21.569164 41.984-47.997673v-47.997673h504.003491a32.004655 32.004655 0 0 0 0-64.009309H455.996509V111.988364c0-26.428509-18.878836-47.997673-41.984-47.997673H273.985164c-23.095855 0-41.984 21.569164-41.984 47.997673v47.997672H64a32.004655 32.004655 0 0 0 0 64.009309zM288.004655 128h111.997672V256H288.004655V128zM960 479.995345H791.998836v-47.997672c0-26.372655-18.878836-47.997673-41.984-47.997673H609.978182c-23.095855 0-41.984 21.634327-41.984 47.997673v47.997672H64a32.004655 32.004655 0 0 0 0 64.00931h504.003491v47.997672c0 26.363345 18.878836 47.997673 41.984 47.997673h140.036654c23.095855 0 41.984-21.634327 41.984-47.997673v-47.997672h168.001164a32.004655 32.004655 0 1 0-0.009309-64.00931zM735.995345 576H623.997673v-128h111.997672v128zM960 800.293236v-0.288581H455.996509v-47.997673c0-26.363345-18.878836-47.997673-41.984-47.997673H274.050327c-23.105164 0-41.984 21.634327-41.984 47.997673v47.997673H64v0.288581a32.004655 32.004655 0 0 0 0 64.009309c0.986764 0 1.917673-0.195491 2.885818-0.288581h165.115346v47.997672c0 26.363345 18.878836 47.997673 41.984 47.997673h140.036654c23.095855 0 41.984-21.634327 41.984-47.997673v-47.997672h501.108364c0.968145 0.093091 1.899055 0.288582 2.895127 0.288581a32.004655 32.004655 0 1 0-0.009309-64.009309zM400.002327 896H288.004655V768h111.997672v128z"
                    fill="#666666"
                    p-id="18759"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">Customization</h5>
                  <p className="text-black-50">
                    NanUI provides various interfaces of Chromium to respond
                    events, and you can add various browser-related functions to
                    the application.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583160987311"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="2757"
                  width="32"
                  height="32"
                >
                  <path
                    d="M116.7 63.8l71.9 806.9 322.8 89.6 323.7-89.8 72.1-806.7H116.7z m634 263.9H372l9 101.3h360.7l-27.2 303.8-203 56.3-202.7-56.3-13.9-155.4h99.4l7.1 79 110.2 29.7 0.3-0.1L622 656.3 633.5 528h-343l-26.7-299.2h495.7l-8.8 98.9z"
                    fill="#666"
                    p-id="2758"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">Web Standards</h5>
                  <p className="text-black-50">
                    Supports the latest HTML5 / CSS3 / JavaScript standards. The
                    rendering effect of NanUI is usually the same as the current
                    corresponding version of Chrome / Edge browser.
                  </p>
                </div>
              </div>
            </div>
          </div>

          <div className="card mb-3">
            <div className="card-body">
              <div className="media">
                <svg
                  t="1583161727266"
                  className="icon mr-3"
                  viewBox="0 0 1024 1024"
                  version="1.1"
                  xmlns="http://www.w3.org/2000/svg"
                  p-id="21986"
                  width="32"
                  height="32"
                >
                  <path
                    d="M0 0h1024v1024H0V0z m940.117333 779.776c-7.466667-46.72-37.888-85.973333-128.128-122.581333-31.402667-14.72-66.304-24.96-76.672-48.64-3.882667-14.08-4.48-21.76-1.962666-30.08 6.4-27.562667 39.04-35.84 64.64-28.16 16.64 5.12 32 17.92 41.642666 38.4 44.117333-28.842667 44.117333-28.842667 74.88-48-11.52-17.92-17.237333-25.642667-25.002666-33.28-26.88-30.08-62.677333-45.44-120.917334-44.117334l-30.08 3.797334c-28.842667 7.04-56.32 22.4-72.96 42.88-48.64 55.082667-34.602667 151.082667 24.277334 190.762666 58.24 43.52 143.402667 53.077333 154.282666 94.08 10.24 49.92-37.12 65.92-83.882666 60.16-34.602667-7.68-53.76-25.002667-74.88-57.002666l-78.08 44.842666c8.96 20.48 19.2 29.397333 34.56 47.317334 74.24 74.922667 259.84 71.082667 293.162666-42.837334 1.237333-3.84 10.24-30.08 3.157334-70.4l1.962666 2.858667z m-383.274666-309.12h-95.914667c0 82.688-0.384 164.864-0.384 247.68 0 52.565333 2.688 100.821333-5.888 115.669333-14.08 29.397333-50.346667 25.642667-66.816 20.48-16.896-8.362667-25.472-19.882667-35.413333-36.48-2.688-4.48-4.693333-8.362667-5.418667-8.362666l-77.866667 48c13.013333 26.88 32 50.005333 56.490667 64.725333 36.48 21.76 85.504 28.8 136.832 17.28 33.408-9.642667 62.208-29.482667 77.269333-60.202667 21.76-39.68 17.152-88.32 16.938667-142.762666 0.512-87.637333 0-175.317333 0-263.637334l0.170667-2.389333z"
                    fill="#666666"
                    p-id="21987"
                  ></path>
                </svg>
                <div className="media-body">
                  <h5 className="mt-0">JavaScript</h5>
                  <p className="text-black-50">
                    NanUI can easily execute JavaScript code and return the
                    result to the .NET environment. It is also possible to
                    register .NET objects, methods, etc. in the JavaScript
                    environment.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </article>
);

export default Page;
