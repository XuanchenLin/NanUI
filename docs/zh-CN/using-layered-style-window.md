# 使用异形样式窗体

[[返回目录](README.md)] [[返回正文](nanui-formium.md#窗体样式)]

为 Formium 窗体的`WindowType`指定属性值`Layered`即可将窗体样式设置为异形样式。异形样式使用 CEF 的离屏渲染技术，通过 Direct2D 将离屏渲染的图像绘制到 LayeredWindow 上。

```C#
public override HostWindowType WindowType => HostWindowType.Layered;
```

因为离屏渲染无法调用 GPU 进行绘图加速，因此在渲染时流畅度不如非离屏渲染时的流畅度，并且此模式无法使用 WebGL 绘制复杂图形。

异形样式窗体不能在运行时改变窗体大小，所以在窗体启动前就应该规划好窗体尺寸，使用`Size`属性为窗体指定大小。

另外根据网页中的元素来设置透明或半透明区域，即可实现异形（全透明）和半透明效果。

![Layered](../images/layered-style.png)

如上图中的示例，卡通角色所在的页面背景颜色`background-color`设置为`transparent`即实现异形窗体的绘制（鼠标点击透明区域可击穿）；卡通的影子部分`background-color`设置为`rgba(0,0,0,.7)`的一个半透明黑色，此区域即呈现为半透明效果（鼠标点击半透明区域不可击穿）。

透明区域

```CSS
body {
  ...
  background: transparent;
  ...
}
```

半透明区域

```CSS
.shadow {
  ...
  background: #2f2f2f60;
  ...
}
```
