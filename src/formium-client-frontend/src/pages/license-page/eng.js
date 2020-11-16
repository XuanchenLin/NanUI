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
            NanUI uses LGPL-3.0 open project source code.
            <b>
              The copyright of this project is owned by the project founder and
              developer Xuanchen Lin.
            </b>
          </p>
          <p>According to the agreement:</p>
          <ol>
            <li>
              You can reference NanUI's binary library in any commercial
              software without paying any copyright fees;
            </li>
            <li>
              If your project uses and modifies NanUI's source code, then your
              project also needs to use the LGPL agreement to open source, and
              keep NanUI's copyright information in your derivative projects:{" "}
              <code>Powered by NanUI</code>。
            </li>
            <li>
              If you need to use NanUI's source code in non-open source
              applications, in order to protect your legal rights, please
              consider purchasing a commercial license from the project author.
            </li>
          </ol>
          <p>
            For details of the LGPL-3.0 agreement, please refer to the following
            documents.
          </p>
          <h3>GNU LESSER GENERAL PUBLIC LICENSE</h3>
          <p>Version 3, 29 June 2007</p>
          <p>
            Copyright © 2007 Free Software Foundation, Inc.{" "}
            <a href="https://fsf.org/" rel="noreferrer" target="_blank">
              https://fsf.org/
            </a>
          </p>
          <p>
            Everyone is permitted to copy and distribute verbatim copies of this
            license document, but changing it is not allowed.
          </p>
          <p>
            This version of the GNU Lesser General Public License incorporates
            the terms and conditions of version 3 of the GNU General Public
            License, supplemented by the additional permissions listed below.
          </p>
          <h4>0. Additional Definitions.</h4>
          <p>
            As used herein, “this License” refers to version 3 of the GNU Lesser
            General Public License, and the “GNU GPL” refers to version 3 of the
            GNU General Public License.
          </p>
          <p>
            “The Library” refers to a covered work governed by this License,
            other than an Application or a Combined Work as defined below.
          </p>
          <p>
            An “Application” is any work that makes use of an interface provided
            by the Library, but which is not otherwise based on the Library.
            Defining a subclass of a className defined by the Library is deemed
            a mode of using an interface provided by the Library.
          </p>
          <p>
            A “Combined Work” is a work produced by combining or linking an
            Application with the Library. The particular version of the Library
            with which the Combined Work was made is also called the “Linked
            Version”.
          </p>
          <p>
            The “Minimal Corresponding Source” for a Combined Work means the
            Corresponding Source for the Combined Work, excluding any source
            code for portions of the Combined Work that, considered in
            isolation, are based on the Application, and not on the Linked
            Version.
          </p>
          <p>
            The “Corresponding Application Code” for a Combined Work means the
            object code and/or source code for the Application, including any
            data and utility programs needed for reproducing the Combined Work
            from the Application, but excluding the System Libraries of the
            Combined Work.
          </p>
          <h4>1. Exception to Section 3 of the GNU GPL.</h4>
          <p>
            You may convey a covered work under sections 3 and 4 of this License
            without being bound by section 3 of the GNU GPL.
          </p>
          <h4>2. Conveying Modified Versions.</h4>
          <p>
            If you modify a copy of the Library, and, in your modifications, a
            facility refers to a function or data to be supplied by an
            Application that uses the facility (other than as an argument passed
            when the facility is invoked), then you may convey a copy of the
            modified version:
          </p>
          <ul>
            <li>
              a) under this License, provided that you make a good faith effort
              to ensure that, in the event an Application does not supply the
              function or data, the facility still operates, and performs
              whatever part of its purpose remains meaningful, or
            </li>
            <li>
              b) under the GNU GPL, with none of the additional permissions of
              this License applicable to that copy.
            </li>
          </ul>
          <h4>
            3. Object Code Incorporating Material from Library Header Files.
          </h4>
          <p>
            The object code form of an Application may incorporate material from
            a header file that is part of the Library. You may convey such
            object code under terms of your choice, provided that, if the
            incorporated material is not limited to numerical parameters, data
            structure layouts and accessors, or small macros, inline functions
            and templates (ten or fewer lines in length), you do both of the
            following:
          </p>
          <ul>
            <li>
              a) Give prominent notice with each copy of the object code that
              the Library is used in it and that the Library and its use are
              covered by this License.
            </li>
            <li>
              b) Accompany the object code with a copy of the GNU GPL and this
              license document.
            </li>
          </ul>
          <h4>4. Combined Works.</h4>
          <p>
            You may convey a Combined Work under terms of your choice that,
            taken together, effectively do not restrict modification of the
            portions of the Library contained in the Combined Work and reverse
            engineering for debugging such modifications, if you also do each of
            the following:
          </p>
          <ul>
            <li>
              a) Give prominent notice with each copy of the Combined Work that
              the Library is used in it and that the Library and its use are
              covered by this License.
            </li>
            <li>
              b) Accompany the Combined Work with a copy of the GNU GPL and this
              license document.
            </li>
            <li>
              c) For a Combined Work that displays copyright notices during
              execution, include the copyright notice for the Library among
              these notices, as well as a reference directing the user to the
              copies of the GNU GPL and this license document.
            </li>
            <li>
              d) Do one of the following:
              <ul>
                <li>
                  <ol start="0">
                    <li>
                      Convey the Minimal Corresponding Source under the terms of
                      this License, and the Corresponding Application Code in a
                      form suitable for, and under terms that permit, the user
                      to recombine or relink the Application with a modified
                      version of the Linked Version to produce a modified
                      Combined Work, in the manner specified by section 6 of the
                      GNU GPL for conveying Corresponding Source.
                    </li>
                  </ol>
                </li>
                <li>
                  <ol>
                    <li>
                      Use a suitable shared library mechanism for linking with
                      the Library. A suitable mechanism is one that (a) uses at
                      run time a copy of the Library already present on the
                      user's computer system, and (b) will operate properly with
                      a modified version of the Library that is
                      interface-compatible with the Linked Version.
                    </li>
                  </ol>
                </li>
              </ul>
            </li>
            <li>
              e) Provide Installation Information, but only if you would
              otherwise be required to provide such information under section 6
              of the GNU GPL, and only to the extent that such information is
              necessary to install and execute a modified version of the
              Combined Work produced by recombining or relinking the Application
              with a modified version of the Linked Version. (If you use option
              4d0, the Installation Information must accompany the Minimal
              Corresponding Source and Corresponding Application Code. If you
              use option 4d1, you must provide the Installation Information in
              the manner specified by section 6 of the GNU GPL for conveying
              Corresponding Source.)
            </li>
          </ul>
          <h4>5. Combined Libraries.</h4>
          <p>
            You may place library facilities that are a work based on the
            Library side by side in a single library together with other library
            facilities that are not Applications and are not covered by this
            License, and convey such a combined library under terms of your
            choice, if you do both of the following:
          </p>
          <ul>
            <li>
              a) Accompany the combined library with a copy of the same work
              based on the Library, uncombined with any other library
              facilities, conveyed under the terms of this License.
            </li>
            <li>
              b) Give prominent notice with the combined library that part of it
              is a work based on the Library, and explaining where to find the
              accompanying uncombined form of the same work.
            </li>
          </ul>
          <h4>6. Revised Versions of the GNU Lesser General Public License.</h4>
          <p>
            The Free Software Foundation may publish revised and/or new versions
            of the GNU Lesser General Public License from time to time. Such new
            versions will be similar in spirit to the present version, but may
            differ in detail to address new problems or concerns.
          </p>
          <p>
            Each version is given a distinguishing version number. If the
            Library as you received it specifies that a certain numbered version
            of the GNU Lesser General Public License “or any later version”
            applies to it, you have the option of following the terms and
            conditions either of that published version or of any later version
            published by the Free Software Foundation. If the Library as you
            received it does not specify a version number of the GNU Lesser
            General Public License, you may choose any version of the GNU Lesser
            General Public License ever published by the Free Software
            Foundation.
          </p>
          <p>
            If the Library as you received it specifies that a proxy can decide
            whether future versions of the GNU Lesser General Public License
            shall apply, that proxy's public statement of acceptance of any
            version is permanent authorization for you to choose that version
            for the Library.
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
