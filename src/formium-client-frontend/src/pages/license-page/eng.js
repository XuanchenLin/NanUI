import React, { useState } from "react";

const Page = () => {
  const [pageCount, setPageCount] = useState(0);

  return (
    <div className="license-page">
      <div className="switcher">
        <div className="btn-group" role="group">
          <button
            type="button"
            className={`btn ${pageCount === 0 ? "btn-primary" : "btn-light"}`}
            onClick={(e) => setPageCount(0)}
          >
            NanUI License
          </button>
          <button
            type="button"
            className={`btn ${pageCount === 1 ? "btn-primary" : "btn-light"}`}
            onClick={(e) => setPageCount(1)}
          >
            Third Party Licenses
          </button>
        </div>
      </div>
      {pageCount === 0 && (
        <article className="nanui-license">
          <h2>NanUI License</h2>
          <h3>Copyright</h3>
          <p>
            NanUI uses MIT open project source code.
            <b>
              The copyright of this project is owned by the project founder and
              developer Xuanchen Lin.
            </b>
          </p>
          <p>According to the agreement:</p>
          <ol>
            <li>
              You should keep NanUI's copyright information in your derivative
              projects: <code>Powered by NanUI</code>。
            </li>
          </ol>
          <p>
            For details of the MIT agreement, please refer to the following
            documents.
          </p>
          <h3>MIT License</h3>
          <p>Copyright (c) 2014-2020 Xuanchen Lin all rights reserved.</p>
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
        </article>
      )}

      {pageCount === 1 && (
        <article className="third-party-license">
          <h2>Third-Party Licenses</h2>
          <h3>CEF</h3>
          <p>
            Copyright (c) 2008-2020 Marshall A. Greenblatt. Portions Copyright
            (c) 2006-2009 Google Inc. All rights reserved.
          </p>
          <p>
            Redistribution and use in source and binary forms, with or without
            modification, are permitted provided that the following conditions
            are met:
          </p>
          <ul>
            <li>
              Redistributions of source code must retain the above copyright
              notice, this list of conditions and the following disclaimer.
            </li>
            <li>
              Redistributions in binary form must reproduce the above copyright
              notice, this list of conditions and the following disclaimer in
              the documentation and/or other materials provided with the
              distribution.
            </li>
            <li>
              Neither the name of Google Inc. nor the name Chromium Embedded
              Framework nor the names of its contributors may be used to endorse
              or promote products derived from this software without specific
              prior written permission.
            </li>
          </ul>
          <p>
            THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
            "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
            LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
            FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
            COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
            INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
            BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
            LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
            CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
            LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
            ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
            POSSIBILITY OF SUCH DAMAGE.
          </p>
          <p>
            <a
              href="https://github.com/chromiumembedded/cef"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/chromiumembedded/cef
            </a>
          </p>
          <h3>CefGlue</h3>
          <p>MIT License</p>
          <p>Copyright (c) 2020 Xilium CefGlue Authors</p>
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
          <h3>Caliburn.Light</h3>
          <p>The MIT License (MIT)</p>
          <p>
            Copyright (c) 2010 Blue Spire Consulting, Inc. Copyright (c) 2014
            Thomas Ibel
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
              href="https://github.com/tibel/Caliburn.Light"
              rel="noreferrer"
              target="_blank"
            >
              https://github.com/tibel/Caliburn.Light
            </a>
          </p>
          <h3>Vortice.Windows</h3>
          <p>The MIT License (MIT)</p>
          <p>Copyright (c) 2019 Amer Koleci and Vortice contributors.</p>
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
          <h3>ColoredConsole</h3>
          <p>The MIT License (MIT)</p>
          <p>
            Copyright (c) ColoredConsole contributors. (
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

          <h3>React</h3>
          <p>The MIT License (MIT)</p>
          <p>Copyright (c) Facebook, Inc. and its affiliates.</p>
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

          <h3>Bootstrap</h3>
          <p>The MIT License (MIT)</p>
          <p>Copyright (c) 2011-2020 Twitter, Inc.</p>
          <p>Copyright (c) 2011-2020 The Bootstrap Authors</p>

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
              href="https://getbootstrap.com/"
              rel="noreferrer"
              target="_blank"
            >
              https://getbootstrap.com/
            </a>
          </p>
        </article>
      )}
    </div>
  );
};

export default Page;
