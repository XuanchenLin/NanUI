# Kisok 窗体样式

## 概述

Kisok 窗体样式是一种特殊的窗体样式，它也被叫做展台窗体样式。它的特点是窗体的标题栏和边框都被隐藏，窗体的大小也被限制在了屏幕的可视区域内，用户无法使用最大化按钮将窗体最大化，也无法通过拖动窗体的边框将窗体拉伸到屏幕之外。

使用 `WindowStyleBuilder` 的扩展方法 `UseKisokForm` 来启用 Kisok 窗体样式，该方法的返回值是 `KisokFormStyle` 类型，该类型继承自 `FormStyle` 类，因此您可以使用 `FormStyle` 类的属性来设置窗体的基础样式，并使用 `KisokFormStyle` 类的属性来设置 Kisok 窗体样式特有的样式属性。

一般情况下，您不应该使用 `FormStyle` 某些属性，例如 `Maximizable`、`Minimizable`、`Sizable`、`WindowState` 等属性，因为这些属性会破坏 Kisok 窗体样式的设计初衷。

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
    var style = builder.UseKisokForm();
    return style
}
```

## DisableTaskBar 属性

Kiosk 窗体样式只有一个可配置的属性， `DisableTaskBar` 属性用于设置是否禁用任务栏，如果禁用任务栏，那么用户将无法使用任务栏的方式切换到其他应用程序。

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
    var style = builder.UseKisokForm();
    style.DisableTaskBar = true;
    return style
}
```

## 另请参阅

- [窗体](./概述.md)
- [窗体功能](./窗体功能.md)
