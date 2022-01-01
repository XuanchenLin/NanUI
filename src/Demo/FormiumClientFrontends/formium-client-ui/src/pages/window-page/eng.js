import React from "react";
import {
  openSystemWindowDemo,
  openBorderlessWindowDemo,
  openSystemBorderlessWindowDemo,
  openLayeredWindowDemo,
  openKioskWindowDemo
} from "../../FormiumBridge";
import system_style from "./images/system-style.png";
import system_borderless_style from "./images/system-borderless-style.png"
import borderless_style from "./images/borderless-style.png"
import layered_window_style from "./images/layered-window-style.png"
import kiosk_style from "./images/kiosk-style.png"

const Page = () => {
  return (
    <article>
      <h2>Window Types</h2>

      <div className="section-block">
        <p>
          The name of NanUI's window, Formium, is derived from the Form in WinForms and the ium in Chromium. As the name implies, it is the combination of WinForms and Chromium, Form+ium=Formium.
        </p>
        <p>
          Currently NanUI supports kinds of window styles, implements the WindowType abstract property of the Formium derivative class, and sets the corresponding window type to select window styles.
        </p>
        <div className="alert alert-light">
          {`public override HostWindowType WindowType { get; }`}
        </div>
        <p>
          In addition, NanUI has built-in form commands, JavaScript objects, events and other functions to simplify form operations. For more information about NanUI window types, please check the documents in the GitHub or Gitee project repository.
        </p>
        <p>Click the icon below to open the corresponding window style example.</p>

        <div className="icon-list">
          <div className="icon-item" onClick={() => openSystemWindowDemo()}>
            <img src={system_style} alt="" />
            <span>Native</span>
          </div>

          <div className="icon-item" onClick={() => openBorderlessWindowDemo()}>
            <img src={borderless_style} alt="" />
            <span>Borderless</span>
          </div>


          <div className="icon-item" onClick={() => openSystemBorderlessWindowDemo()}>
            <img src={system_borderless_style} alt="" />
            <span>Borderless with DWM</span>
          </div>

          <div className="icon-item" onClick={() => openLayeredWindowDemo()}>
            <img src={layered_window_style} alt="" />
            <span>Layered Window</span>
          </div>

          <div className="icon-item" onClick={() => openKioskWindowDemo()}>
            <img src={kiosk_style} alt="" />
            <span>Kiosk</span>
          </div>
        </div>

      </div>

      <h2>Dragable</h2>
      <div className="section-block">
        <p>In the borderless style, you need to use the CSS property -webkit-app-region to set whether the element can be used to drag and move the window. This attribute has two attribute values drag/no-drag to correspond to the draggable area and the refusal to drag area.</p>
        <div className="alert alert-light">
          <pre>
            {`div {
  -webkit-app-region: drag;
}`}
          </pre>
        </div>
        <p>In the following example, after setting -webkit-app-region: drag in the style attribute of the div element, the position of the form can be moved by dragging the area where the div is located.</p>
        <div className="alert alert-success" style={{ WebkitAppRegion: "drag" }}>
          Drag this area to move the form
        </div>
        <p>Normally, you don't need to explicitly set the no-drag attribute to specify the area where dragging is rejected. By default, the elements are all non-dragable areas. Only when the parent element of the element is set as a draggable area and there is no need to implement draggability in some child elements, set the -webkit-app-region attribute of the child element to no-drag to set the area where the child element is located Exclude from parent element.</p>
        <p>In the example below, the parent element (green part) has embedded child elements (yellow part). The -webkit-app-region: drag attribute is set for the parent element and -webkit-app-region: no- is set for the child element. drag attribute, then when you drag the green part, you can move the form, but nothing happens when you drag the yellow part.</p>
        <div className="alert alert-light">
          <pre>
            {`<div class="bg-success" style="-webkit-app-region: drag">
  <div class="bg-warning" style="-webkit-app-region: no-drag; margin: 0 30px;">No drag area</div>
</div>`}
          </pre>
        </div>
        <div className="bg-success" style={{ WebkitAppRegion: "drag" }}>
          <div className="mx-5 p-3 bg-warning" style={{ WebkitAppRegion: "no-drag" }}>No drag area</div>
        </div>
        <p>You can click the "Developer Tools" button on the left side of this form to open the debugging tool, and then use the element tool to view the -webkit-app-region attribute on these elements.</p>
      </div>

      <h2>Window Commands</h2>
      <div className="section-block">
        <p>The formium-command attribute is built into the front-end environment of Formium forms to help simplify form operations. The maximize, minimize, restore and close commands that can be achieved when the user clicks on the HTML element with the formium-command attribute.</p>

        <ul>
          <li><b>maximize</b> - Maximize window</li>
          <li><b>minimize</b> - Minimize window</li>
          <li><b>restore</b> - Restore window</li>
          <li><b>close</b> - Close the current window</li>
          <li><b>fullscreen</b> - Full screen the current window</li>

        </ul>

        <p>For example, setting the formium-command="close" attribute on the button element can realize the function of closing the form after clicking the element.</p>

        <div className="alert alert-light">
          <pre>
            {`<button formium-command="close">Close the window</button>
<button formium-command="fullscreen">Full screen</button>`}
          </pre>
        </div>

        <p>
          <button className="btn btn-outline-secondary" formium-command="close">Close the window</button>
          {" "}
          <button className="btn btn-outline-secondary" formium-command="fullscreen">Full screen</button>
        </p>

      </div>

    </article>
  );
};

export default Page;
