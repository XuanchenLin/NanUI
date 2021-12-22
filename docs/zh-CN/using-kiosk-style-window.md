# 使用 Kiosk 样式窗体

[[返回目录](README.md)] [[返回正文](nanui-formium.md#窗体样式)]

为 Formium 窗体的`WindowType`指定属性值`Kiosk`即可将窗体样式设置为 Kiosk 样式。Kiosk 可以简单的理解为**全屏占有**模式。Kiosk 模式就是去掉用户可操作的界面，仅仅给用户一个和服务有关的界面。

设置窗体为 Kiosk 模式后，窗体将以全屏独占模式开启。因此您不能对 Kiosk 模式的窗体设置大小、启动位置等属性；也不能执行最大化、最小化、还原等操作；用户也不能对窗体执行关闭操作。

在开发过程中，您还需要注意应该尽量避免新窗口打开。

在实际的项目事件中，这种模式一般用于工控上位机界面、查询机界面、数据大屏幕等。

```C#
public override HostWindowType WindowType => HostWindowType.Kiosk;
```

Kiosk 样式不具备特殊样式属性设置，因此`KioskWindowStyle`属性中没有内容，该属性只是为了未来扩展需要而保留。
