import "./App.scss";
import { useState } from "react";
import { ReactComponent as CloseIcon } from "./close.svg";
import Globalization from "./Globalization.json";

function App() {
  const [version] = useState({
    formium: window?.Formium?.version.formium || "N/A",
    chromium: window?.Formium?.version.chromium || "N/A",
  });

  const culture = window?.Formium?.culture.name || "en-US";

  let messages = {};

  if (Globalization.hasOwnProperty(culture)) {
    messages = Globalization[culture];
  } else {
    messages = Globalization["en-US"];
  }

  return (
    <div className="dialog-container">
      <header>
        <span className="title">{messages.title}</span>
        <div
          className="control-box"
          formium-command="close"
          title={messages.closeButtonTooltip}
        >
          <CloseIcon />
        </div>
      </header>
      <section className="version">
        <div className="logo-img"></div>

        <div className="version-info">
          <ul>
            <li>NanUI Formium Engine</li>
            <li>
              {messages.version} {version.formium}
            </li>
          </ul>
        </div>

        <div className="version-info">
          <ul>
            <li>Chromium Embedded Framework</li>
            <li>
              {messages.version} {version.chromium}
            </li>
          </ul>
        </div>
      </section>
      <main>
        <h2>{messages.license}</h2>
        <article>
          <h3>MIT License</h3>
          <p>
            Copyright &copy; 2014-{new Date().getFullYear()} Xuanchen Lin all
            rights reserved.
          </p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <i>{messages.repository}</i>
          </p>
          <ul>
            <li>
              <a
                href="https://github.com/NetDimension/NanUI/"
                rel="noreferrer"
                target="_blank"
              >
                https://github.com/NetDimension/NanUI/
              </a>
            </li>
            <li>
              <a
                href="https://gitee.com/dotnetchina/NanUI/"
                rel="noreferrer"
                target="_blank"
              >
                https://gitee.com/dotnetchina/NanUI/
              </a>
            </li>
          </ul>
          <p>
            NanUI has joined the{" "}
            <strong>
              <a
                href="https://gitee.com/dotnetchina/"
                rel="noreferrer"
                target="_blank"
              >
                dotNet China
              </a>
            </strong>
            .
          </p>
        </article>

        <h2>{messages.thirdPartyLicense}</h2>
        <article>
          <h3>CefGlue</h3>
          <p>MIT License</p>
          <p>Copyright &copy; 2020 Xilium CefGlue Authors</p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a
              href="https://gitlab.com/xiliumhq/chromiumembedded/cefglue"
              rel="noreferrer"
              target="_blank"
            >
              https://gitlab.com/xiliumhq/chromiumembedded/cefglue
            </a>
          </p>
        </article>
        <article>
          <h3>Vanara</h3>
          <p>MIT License</p>
          <p>Copyright &copy; 2017 David Hall</p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a
              href="https://github.com/dahall/Vanara/"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/dahall/Vanara/
            </a>
          </p>
        </article>
        <article>
          <h3>Vortice.Windows</h3>
          <p>The MIT License (MIT)</p>
          <p>Copyright &copy; 2019 Amer Koleci and Vortice contributors.</p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a
              href="https://github.com/amerkoleci/Vortice.Windows"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/amerkoleci/Vortice.Windows
            </a>
          </p>
        </article>
        <article>
          <h3>SkiaSharp</h3>
          <p>The MIT License (MIT)</p>
          <p>
            Copyright &copy; 2015-2016 Xamarin, Inc.
            <br />
            Copyright &copy; 2017-2018 Microsoft Corporation.
          </p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a
              href="https://github.com/colored-console/colored-console"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/colored-console/colored-console
            </a>
          </p>
        </article>
        <article>
          <h3>ColoredConsole</h3>
          <p>The MIT License (MIT)</p>
          <p>
            Copyright &copy; ColoredConsole contributors. (
            <a
              href="mailto:coloredconsole@gmail.com"
              rel="noreferrer"
              target="_blank"
            >
              coloredconsole@gmail.com
            </a>
            )
          </p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a
              href="https://github.com/colored-console/colored-console"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/colored-console/colored-console
            </a>
          </p>
        </article>
        <article>
          <h3>React</h3>
          <p>The MIT License (MIT)</p>
          <p>Copyright &copy; Facebook, Inc. and its affiliates.</p>
          <p>
            Permission is hereby granted, free of charge, to any person
            obtaining a copy of this software and associated documentation files
            (the "Software"), to deal in the Software without restriction,
            including without limitation the rights to use, copy, modify, merge,
            publish, distribute, sublicense, and/or sell copies of the Software,
            and to permit persons to whom the Software is furnished to do so,
            subject to the following conditions:
          </p>
          <p>
            The above copyright notice and this permission notice shall be
            included in all copies or substantial portions of the Software.
          </p>
          <p>
            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
            BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
            ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
            CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
            SOFTWARE.
          </p>
          <p>
            <a href="https://reactjs.org/" rel="noreferrer" target="_blank">
              https://reactjs.org/
            </a>
          </p>
        </article>
      </main>
    </div>
  );
}

export default App;
