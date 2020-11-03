# Formium 浏览器相关成员

[[返回目录](README.md)] [[返回正文](nanui-formium.md#设置浏览器相关属性)]

- [Formium 浏览器相关成员](#formium-浏览器相关成员)
  - [属性](#属性)
  - [方法](#方法)
  - [事件](#事件)

## 属性

**CanGoBack { get; }** `bool`

当前浏览器页面是否可以执行“后退”操作。

**CanGoForward { get; }** `bool`

当前浏览器页面是否可以执行“前景”操作。

**FrameCount { get; }** `int`

获取当前窗体在浏览器中存在的框架（Frame）数量，通常也包含浏览器的主框架本身。

**HasDocument { get; }** `bool`

获取当前浏览器是否具有文档（Document）对象。

**Identifier { get; }** `int`

获得当前窗体浏览器对象的 ID。

**IsLoading { get; }** `bool`

指示当前桩体浏览器是否处于加载状态。

**IsWebViewReady { get; }** `bool`

获取当前窗体浏览器视图是否已经处于可用状态。

## 方法

**public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(string code)**

异步执行 JavaScript 代码，并返回执行结果。

参数

- _code:`string`_：待执行的 JavaScript 代码。

返回值

- _System.Threading.Tasks.Task<NetDimension.NanUI.JavaScript.JavaScriptExecutionResult>_：可等待的 JavaScriptExecutionResult 为本次执行的结果和返回值。

**public void ExecuteJavaScript(string code)**

直接执行 JavaScript 代码，不等待返回结果。

**public CefFrame GetFocusedFrame()**

获取当前处于焦点状态的框架。

返回值

- _CefFrame_：框架实例。

参数

- _code:`string`_：待执行的 JavaScript 代码。

**public CefFrame GetMainFrame()**

获取当前处于焦点状态的框架。

返回值

- _CefFrame_：框架实例。

**public CefFrame GetFrame(string name|int identifier)**

根据框架的名称`name`或框架编号`identifier`来获取框架实例。

参数

- _name:`string`|identifier:`int`_:框架名称 name 或框架编号 identifier。

返回值

- _CefFrame_： 当前浏览器页面的主框架。

**public long[] GetFrameIdentifiers()**

获取当前页面中所有框架的编号。

返回值

- _long[]_： 框架编号数组。

**public string[] GetFrameNames()**

获取当前页面中所有框架的名称。

返回值

- _string[]_：框架名称数组。

**public CefBrowserHost GetHost()**

获取当前窗口的`CefBrowserHost`实例。

返回值

- _CefBrowserHost_： CefBrowserHost

**public void GoBack()**

返回浏览器历史记录的上一页。需要配合`CanGoBack`属性。

**public void GoForward()**

前进到浏览器历史记录的下一页。需要配合`CanGoForward`属性。

**public void RegisterExternalObjectValue(string name, JavaScriptValue value)**

向浏览器环境注册 .NET 对象映射。使用`JavaScriptValue`创建 JavaScript 类型为`Object`的对象，并将 .NET 对象的属性或者方法与之映射。

参数

- _name:`string`_：对象名称。
- _value:`JavaScriptValue`_：JavaScript 对象映射。

**public void Reload(bool forceReload = false)**

刷新当前浏览器页面。如果指定`forceReload`属性，将忽略缓存强制刷新当前页面。

参数

- _forceReload:`bool`_：true 强制刷新页面；默认为 false。

**public void StopLoad()**

停止加载当前浏览器正在加载的页面。

**public void ShowDevTools()**

打开调试工具。

## 事件

**AddresChanged**

当浏览器地址栏地址改变时触发。

**DocumentTitleChanged**

当前浏览器标题改变时触发。

**StatusMessage**

当前浏览器状态栏内容改变时触发。

**FullScreenModeChanged**

当前浏览器的全屏模式改变时触发。

**BeforeClose**

当浏览器页面或窗体即将关闭时触发。

**BeforeContextMenu**

当在浏览器点击右键，上下文菜单即将出现前触发。

**ContextMenuCommand**
当用户点击浏览器的上下文菜单项目时触发。

**BeforeDownload**

当浏览器即将开始执行文件下载操作时触发。

**DownloadUpdated**

当前浏览器下载进度改变时触发。

**BeforePopup**

当浏览器即将打开新页面时触发。

**BrowserCreated**

当浏览器实例创建完成后触发。

**ConsoleMessage**

当浏览器的控制台接受到新消息时触发。

**DragEnter**

当用户拖拽内容到当前窗体的浏览器实例上方时触发。

**KeyEvent**

当用户在当前窗体的浏览器实例敲击键盘时触发。

**PreKeyEvent**

当用户在当前窗体的浏览器实例敲击键盘时触发。

**LoadStart**

当前浏览器进程开始加载页面时触发。

**LoadEnd**

当前浏览器进程完成加载页面时触发。

**LoadError**

当前浏览器进程加载页面发生错误时触发。

**LoadingProgressChanged**

当前浏览器进程加载进程改变时触发。

**LoadingStateChanged**

当前浏览器进程加载状态改变时触发。

**RenderProcessTerminated**

当前浏览器的渲染进程挂掉时触发。
