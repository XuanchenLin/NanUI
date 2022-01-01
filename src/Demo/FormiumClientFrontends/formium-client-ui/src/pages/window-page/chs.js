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
      <h2>窗体样式</h2>

      <div className="section-block">
        <p>
          关于 NanUI 的窗体的名称 Formium，源自于 WinForms 中的 Form 以及
          Chromium 中的ium。顾名思义就是 WinForms 与 Chromium
          的结合，Form+ium=Formium。
        </p>
        <p>
          目前 NanUI 支持多种窗体样式，实现 Formium 衍生类的 WindowType 抽象属性，并设置相应的窗体类型来选用各种窗体样式。
        </p>
        <div className="alert alert-light">
          {`public override HostWindowType WindowType { get; }`}
        </div>
        <p>
          此外，NanUI 还内置了各种窗体命令以及 JavaScript 对象、事件等功能来简化窗体操作。更多 NanUI 窗体相关的信息请您查看 GitHub
          或 Gitee 项目仓库中的文档。
        </p>
        <p>点击下面图标打开对应的窗体样式示例。</p>

        <div className="icon-list">
          <div className="icon-item" onClick={() => openSystemWindowDemo()}>
            <img src={system_style} alt="" />
            <span>原生窗体</span>
          </div>

          <div className="icon-item" onClick={() => openBorderlessWindowDemo()}>
            <img src={borderless_style} alt="" />
            <span>无边框窗体</span>
          </div>


          <div className="icon-item" onClick={() => openSystemBorderlessWindowDemo()}>
            <img src={system_borderless_style} alt="" />
            <span>系统无边框窗体</span>
          </div>

          <div className="icon-item" onClick={() => openLayeredWindowDemo()}>
            <img src={layered_window_style} alt="" />
            <span>分层（异形）窗体</span>
          </div>

          <div className="icon-item" onClick={() => openKioskWindowDemo()}>
            <img src={kiosk_style} alt="" />
            <span>Kiosk窗体</span>
          </div>
        </div>
        {/* 
        <p>WindowType 值说明</p>

        <ul>
          <li>
            <p>
              <strong>HostWindowType.System</strong>：原生窗体样式。
            </p>
            <p>
              系统原生窗体样式与传统的 WinForm
              应用程序界面一致，拥有系统样式的标题栏，边框和系统命令区域，类似在传统的
              Form 控件上拖入 WebBrowser 控件并设置 Dock 属性为 Fill
              时的样子一致。
            </p>
          </li>
          <li>
            <p>
              <strong>HostWindowType.Borderless</strong>：无边框窗体样式。
            </p>
            <p>
              在无边框窗体样式中系统原生的标题栏和边框被隐藏，您可以使用整个窗体区域来绘制您的应用程序界面。并可以设置不同的窗体圆角样式、窗体阴影效果以及投影的颜色。
            </p>
          </li>
          <li>
            <p>
              <strong>HostWindowType.SystemBorderless</strong>：系统无边框窗体样式。
            </p>
            <p>
              与无边框窗体样式类似的原生窗体的标题栏和边框被隐藏。由于 NanUI 通过调用系统的桌面管理器（DWM）来实现这个过程，所以在这种窗体模式中无法设置窗体圆角和投影的样式，但也正因为使用了 DWM 所以这中样式比 Borderless 模式渲染更快。
            </p>
          </li>
          <li>
            <p>
              <strong>HostWindowType.Layered</strong>：异形窗口样式。
            </p>
            <p>
              使用 Layered
              样式允许您创建异形、半透明窗体。需要注意的是异形窗口不提供实时改变窗体大小的选项。根据网页中透明或者半透明区域的设置，即可实现异形和半透明特效。
            </p>
          </li>
          <li>
            <p>
              <strong>HostWindowType.Kiosk</strong>：Kiosk 模式样式。
            </p>
            <p>Kiosk 样式的窗体用于需要全屏展示窗体内容的场景，在此模式中应用程序将遮蔽任务栏的位置并占据整个屏幕。</p>
            <p>通常在需要全屏运行的应用使用这种窗体样式，例如：工控上位机界面、查询机界面、数据大屏幕等。</p>
          </li>
        </ul>
      */}
      </div>

      <h2>拖动区域</h2>
      <div className="section-block">
        <p>在无边框样式中，需要通过 CSS 属性 -webkit-app-region 来设置元素是否可以用于拖动并移动窗体。这个属性具有2个属性值 drag/no-drag 来对应可拖动区域和拒绝拖动区域。</p>
        <div className="alert alert-light">
          <pre>
            {`div {
  -webkit-app-region: drag;
}`}
          </pre>
        </div>
        <p>比如下面的示例，在 div 元素的 style 属性中为 div 设置了 -webkit-app-region: drag 后即可通过拖动该 div 所在区域拖动移动窗体位置。</p>
        <div className="alert alert-success" style={{ WebkitAppRegion: "drag" }}>
          拖动此区域即可移动窗体！
        </div>
        <p>通常情况，您不需要显式的设置 no-drag 属性来指定拒绝拖动区域，元素默认都是不可拖动区域。只有当元素的父元素被设置为可拖动区域并且在某些子元素中不需要实现可拖动时，设置子元素的 -webkit-app-region 属性值为 no-drag 将子元素所在的区域从父元素中排除。</p>
        <p>比如下面的例子父级元素（绿色部分）内嵌了子元素（黄色部分），为父元素设置了 -webkit-app-region: drag 属性的同时为子元素设置了 -webkit-app-region: no-drag 属性，那么当您拖动绿色部分时可以实现窗体的移动，而拖动黄色部分时什么都不会发生。</p>
        <div className="alert alert-light">
          <pre>
            {`<div class="bg-success" style="-webkit-app-region: drag">
  <div class="bg-warning" style="-webkit-app-region: no-drag; margin: 0 30px;">禁止拖动区域</div>
</div>`}
          </pre>
        </div>
        <div className="bg-success" style={{ WebkitAppRegion: "drag" }}>
          <div className="mx-5 p-3 bg-warning" style={{ WebkitAppRegion: "no-drag" }}>禁止拖动区域</div>
        </div>
        <p>您可以点击本窗体左侧的“开发人员工具”按钮打开调试工具，然后使用元素工具查看上面这些元素上的 -webkit-app-region 属性。</p>
      </div>

      <h2>窗体命令</h2>
      <div className="section-block">
        <p>在 Formium 窗体的前端环境中内置了 formium-command 属性来帮助简化窗体操作。用户点击具有formium-command属性的 HTML 元素时可以实现的最大化、最小化、还原及关闭命令。</p>

        <ul>
          <li><b>maximize</b> - 最大化窗口</li>
          <li><b>minimize</b> - 最小化窗口</li>
          <li><b>restore</b> - 还原窗口</li>
          <li><b>close</b> - 关闭当前窗口</li>
          <li><b>fullscreen</b> - 全屏化当前窗口</li>

        </ul>

        <p>例如，在 button 元素上设置 formium-command="close" 属性可以实现点击该元素后关闭窗体的功能。</p>

        <div className="alert alert-light">
          <pre>
            {`<button formium-command="close">关闭窗口</button>
<button formium-command="fullscreen">全屏</button>`}
          </pre>
        </div>

        <p>
          <button className="btn btn-outline-secondary" formium-command="close">关闭窗口</button>
          {" "}
          <button className="btn btn-outline-secondary" formium-command="fullscreen">全屏</button>
        </p>

      </div>

    </article>
  );
};

export default Page;
