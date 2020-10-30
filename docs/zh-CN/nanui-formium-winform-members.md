# Formium 窗体相关成员

[[返回目录](README.md)] [[返回正文](nanui-formium.md#设置窗体相关属性)]

- [Formium 窗体相关成员](#formium-窗体相关成员)
  - [属性](#属性)
  - [方法](#方法)

## 属性

**AllowFullScreen { get; set; }** `bool`

是否允许当前窗体能够执行全屏操作的状态。默认值是`false`。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**AllowSystemMenu { get; set; }** `bool`

在用户右键点击可拖动区域时是否显示系统菜单。当`WindowType`为`Kiosk`时此设置无效。

**AutoShowMask { get; set; }** `bool`

在窗体启动并等待页面加载时，是否自动显示等待页面。

**CanMaximize { get; set; }** `bool`

设置或获取当前窗体是否能够使用“最大化”命令。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**CanMinimize { get; set; }** `bool`

设置或获取当前窗体是否能够使用“最小化”命令。当`WindowType`为`Kiosk`时此设置无效。

**ClientSize { get; }** `System.Drawing.Size`

获取当前窗体的用户区域大小。

**Height { get; set; }** `int`

设置或获取当前窗体的高度。

**Icon { get; set; }** `System.Drawing.Icon`

设置或获取当前窗体的图标。

**IsFullScreen { get; }** `bool`

指示当前窗体是否处于全屏状态。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**Left { get; set; }** `int`

设置或获取窗体当前所在屏幕的横坐标。

**Location { get; set; }** `System.Drawing.Point`

设置或获取窗体当前所在屏幕的位置。

**Mask { get; }** `ViewMask`

获取当前窗体遮罩层的实例。

**MaximumSize { get; set; }** `System.Drawing.Size`

设置或获取当前窗体能够达到的最大尺寸。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**MinimumSize { get; set; }** `System.Drawing.Size`

设置或获取当前窗体能够达到的最小尺寸。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**Resizable { get; set; }** `bool`

指定当前窗口是否能够改变大小。当`WindowType`为`Kiosk`或`Layered`时此设置无效。

**ShowInTaskbar { get; set; }** `bool`

设置或获取当前窗口是否在任务栏显示。当`WindowType`为`Kiosk`时此设置无效。

**Size { get; set; }** `Size`

设置或获取当前窗口的尺寸。

**StartPosition { get; set; }** `System.Windows.Forms.FormStartPosition`

设置或获取窗口的启动位置。当`WindowType`为`Kiosk`时此设置无效。

**Subtitle { get; set; }** `string`

设置或获取当前窗口的副标题。

**Title { get; set; }** `string`

设置或获取当前窗口的主标题。当副标题为空时窗口显示主标题；当副标题由内容时，将显示“[副标题] - [主标题]”。如果需要修改显示样式可以通过重载`GetWindowTitle`方法来指定。

**Top { get; set; }** `int`

设置或获取当前窗口的纵坐标。

**TopMost { get; set; }** `bool`

设置或获取当前窗口是否为顶层窗口。

**Width { get; set; }** `int`

设置或获取当前窗口的宽度。

**WindowState { get; set; }** `System.Windows.Forms.FormWindowState`

设置或获取当前窗口的状态。当`WindowType`为`Kiosk`时此设置无效。

## 方法

**public void Close(bool force)**

关闭当前窗口。

参数

- _force:`bool`_：`true`为强制关闭。默认为`false`。

**protected void CloseMask()**

关闭当前窗体中显示遮罩层。

**public void FullScreen(bool toggle)**

设置窗口的最大化状态。

参数

- _toggle:`bool`_：true 为设置全屏；false 取消全屏。

**public void Hide()**

隐藏当前窗口。

**public void Show(Formium owner|.IWin32Window owner|void)**

显示当前窗体。可以为此方法指定`owner`参数以设置其父窗体。当不指定`owner`参数时次窗口无父窗口。

参数

- _owner:`Formium`|owner:`IWin32Window`|void_：可指定 Formium 和 IWin32Window 类型的父窗体。忽略此参数时窗口无父窗口。

**public void ShowDialog(Formium owner|.IWin32Window owner|void)**

以模态方式打开当前窗体。可以为此方法指定`owner`参数以设置其父窗体。当不指定`owner`参数时次窗口无父窗口。

参数

- _owner:`Formium`|owner:`IWin32Window`|void_：可指定 Formium 和 IWin32Window 类型的父窗体。忽略此参数时窗口无父窗口。

**public void ShowDevTools()**

打开浏览器的调试工具（DevTools）。

**protected void ShowMask()**

在当前窗体中显示遮罩层。
