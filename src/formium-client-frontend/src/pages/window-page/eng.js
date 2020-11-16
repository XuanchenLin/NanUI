import React from "react";
import {
  openNativeStyleForm,
  openKisokModeForm,
  openAcrylicStyleForm,
  openLayeredStyleForm,
} from "../../FormiumBridge";

const Page = () => {
  return (
    <article>
      <section>
        <h2>Window Styles</h2>
        <p>
          Formium the form base of NanUI, its name is derived from <b>Form</b>{" "}
          in WinForms and <b>ium</b> in Chromium. As the name implies, it is the
          combination of WinForms and Chromium, <b>Form</b> + <b>ium</b> ={" "}
          <b>Formium</b>. Currently NanUI supports 5 different window styles.
          Set the WindowType property value to one of the following parameters:
        </p>
        <ul>
          <li>
            <p>
              <strong>System</strong>
            </p>
            <p>
              The system native form style is consistent with the traditional
              WinForm application interface, with the title bar, border and
              system command area of the system style, similar to that when
              dragging the WebBrowser control on the traditional Form control
              and setting the Dock property to Fill.
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openNativeStyleForm()}
              >
                Example
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Borderless</strong>
            </p>
            <p>
              In the borderless window style, the system's native title bar and
              border are hidden, and you can use the entire window area to draw
              your application interface.
            </p>
            <p>This example uses the borderless form style.</p>
          </li>
          <li>
            <p>
              <strong>Layered</strong>
            </p>
            <p>
              Using Layered style allows you to create profiled,
              semi-transparent forms. It should be noted that the special-shaped
              window does not provide the option to change the size of the
              window in real time. According to the settings of the transparent
              or semi-transparent area in the web page, the special-shaped and
              semi-transparent effect can be achieved.
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openLayeredStyleForm()}
              >
                Example
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Acrylic</strong>
            </p>
            <p>
              Acrylic special effects are a new feature provided after the
              Windows 10 Creators Update. It allows the transparent or
              translucent area of the form to be blurred and blended with
              desktop elements to achieve a special matte acrylic effect. Same
              as the Layered style, according to the settings of the transparent
              or semi-transparent area in the web page, a frosted glass effect
              with a specific effect will be achieved.
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openAcrylicStyleForm()}
              >
                Example
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Kiosk</strong>
            </p>
            <p>
              Kiosk style windows are commonly used in scenarios that require
              full-screen display of window content.
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => {
                  alert(
                    "Kisok Mode will take all the screen area. If you want to quit Kisok Mode you should press the Win key and close it on taskbar."
                  );
                  openKisokModeForm();
                }}
              >
                Example
              </button>
            </p>
          </li>
        </ul>
        <p>
          In addition, NanUI also has built-in various form commands, objects,
          events and other functions in the JavaScript environment. For more
          information about NanUI forms, please check the documents in GitHub or
          Gitee project repository.
        </p>
      </section>
    </article>
  );
};

export default Page;
