# 使用原生样式窗体

[[返回目录](README.md)] [[返回正文](nanui-formium.md#窗体样式)]

为 Formium 窗体的`WindowType`指定属性值`System`即可将窗体样式设置为原生样式。

```C#
public override HostWindowType WindowType => HostWindowType.System;
```

原生样式不具备特殊样式属性设置，因此`SystemWindowStyle`属性值内没有内容，该属性只是为了未来扩展需要而保留。
