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
        <h2>窗体样式</h2>
        <p>
          关于 NanUI 的窗体的名称 Formium，源自于 WinForms 中的 Form 以及
          Chromium 中的ium。顾名思义就是 WinForms 与 Chromium
          的结合，Form+ium=Formium。目前 NanUI 支持5种不同的窗体样式，将
          WindowType 属性值设置为以下参数之一：
        </p>
        <ul>
          <li>
            <p>
              <strong>System</strong>：系统原生窗体样式。
            </p>
            <p>
              系统原生窗体样式与传统的 WinForm
              应用程序界面一致，拥有系统样式的标题栏，边框和系统命令区域，类似在传统的
              Form 控件上拖入 WebBrowser 控件并设置 Dock 属性为 Fill
              时的样子一致。
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openNativeStyleForm()}
              >
                查看示例
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Borderless</strong>：无边框窗体样式。
            </p>
            <p>
              在无边框窗体样式中系统原生的标题栏和边框被隐藏，您可以使用整个窗体区域来绘制您的应用程序界面。
            </p>
            <p>本示例就是使用了无边框窗体样式。</p>
          </li>
          <li>
            <p>
              <strong>Layered</strong>：异形窗口样式。
            </p>
            <p>
              使用 Layered
              样式允许您创建异形、半透明窗体。需要注意的是异形窗口不提供实时改变窗体大小的选项。根据网页中透明或者半透明区域的设置，即可实现异形和半透明效果。
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openLayeredStyleForm()}
              >
                查看示例
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Acrylic</strong>：亚克力特效窗体样式。
            </p>
            <p>
              亚克力特效是 Windows 10
              创意者更新版之后提供的新功能，它允许窗体的透明或半透明区域与桌面元素进行模糊混合，实现特殊的磨砂亚克力效果。与
              Layered
              样式相同，根据网页中透明或者半透明区域的设置，将实现特定效果的磨砂玻璃效果。
            </p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => openAcrylicStyleForm()}
              >
                查看示例
              </button>
            </p>
          </li>
          <li>
            <p>
              <strong>Kiosk</strong>：Kiosk 模式样式。
            </p>
            <p>Kiosk 样式的窗体用于需要全屏展示窗体内容的场景。</p>
            <p>
              <button
                className="btn btn-primary"
                onClick={(e) => {
                  alert(
                    "Kisok 模式窗体将占用整个屏幕，请按“Win”键调出本示例窗体通过点击按钮关闭。"
                  );
                  openKisokModeForm();
                }}
              >
                查看示例
              </button>
            </p>
          </li>
        </ul>
        <p>
          除此之外，NanUI 还内置了各种窗体命令以及 JavaScript
          环境中的对象，事件等等功能。更多 NanUI 窗体相关的信息请您查看 GitHub
          或 Gitee 项目仓库中的文档。
        </p>
      </section>
    </article>
  );
};

export default Page;
