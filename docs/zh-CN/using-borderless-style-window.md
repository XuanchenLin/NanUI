# 使用无边框样式窗体

[[返回目录](README.md)] [[返回正文](nanui-formium.md#窗体样式)]

- [使用无边框样式窗体](#使用无边框样式窗体)
  - [CornerStyle 圆角效果](#cornerstyle-圆角效果)
  - [ShadowEffect 阴影效果](#shadoweffect-阴影效果)

为 Formium 窗体的`WindowType`指定属性值`Borderless`即可将窗体样式设置为无边框样式。无边框样式移除了原生系统的标题栏和边框，您可以使用整个窗体区域来绘制您的应用程序界面。

特别需要指出的，如果`WindowType`设置为`SystemBorderless`后，NanUI 将使用 DWM 渲染窗体界面，所以下述内容和设置无法应用于`SystemBorderless`无边框样式。

无边框窗体具备特有的样式属性集合，您可以通过使用泛型方法`UseExtendedStyles<T>()`和泛型`BorderlessWindowStyle`来获得访问这些属性的对象。下面，将详细介绍这些属性。

## CornerStyle 圆角效果

NanUI 为 Formium 的无边框窗体内置了圆角效果：

- **不使用圆角**

  不使用圆角设置后 Formium 窗体将不窗体圆角，浏览器占满所有客户区域范围。

  ```C#
  var style = UseExtendedStyles<BorderlessWindowStyle>();
  style.CornerStyle = CornerStyle.None;
  ```

  ![None](../images/bordereffect-none.png)

  您可以使用 CSS 的 Border 属性来为顶层元素设置边框也能实现具备边线的效果。

  ![None](../images/bordereffect-none-css-border.png)

  ```html
  <div class="main-window">contents...</div>
  ```

  ```css
  .main-window {
    height: 100%;
    box-sizing: border-box;
    border: 1px solid #666;
  }
  ```


- **使用圆角**

  设置圆角样式后，窗体的四角将呈现为圆角，窗体整体变为圆角矩形。内置属性中提供了不同大小的圆角供您选择。不建议为圆角边框窗体设置边线效果，因为四角的边线将被截去。



  ![None](../images/bordereffect-round-corner.png)

## ShadowEffect 阴影效果

Formium 无边框窗体的`ShadowEffect`属性提供了不同大小的投影效果供您选择。

- **不使用投影效果**

  无阴影。关闭 Formium 窗体的阴影效果。

  ```C#
  var style = UseExtendedStyles<BorderlessWindowStyle>();
  style.ShadowEffect = BorderEffect.None;
  ```

  ![None](../images/shadoweffect-none.png)

- **设置投影效果**

  Formium 无边框窗体提供了多种大小的投影，根据您的喜好选择合适您应用程序的投影效果。

  ```C#
  var style = UseExtendedStyles<BorderlessWindowStyle>();
  style.CornerStyle = CornerStyle.Normal;
  ```

  ![None](../images/shadoweffect-dropshadow.png)

除了设置投影效果，您还可以为您的投影设置颜色。使用`ShadowColor`属性来设置窗体激活状态时的阴影颜色；设置`InactiveShadowColor`属性来设置非激活状态时的阴影颜色。`InactiveShadowColor`设置为 NULL 时，NanUI 将自动通过`ShadowColor`的色彩值为 Formium 窗体的阴影计算一个合适的色彩。

```C#
var style = UseExtendedStyles<BorderlessWindowStyle>();
style.ShadowColor = ColorTranslator.FromHtml("#963B6F");
```

