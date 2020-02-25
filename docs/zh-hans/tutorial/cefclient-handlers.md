# Cef 行为处理器

`CefClient`类是 Cef 浏览器中重要的组成部分之一，它提供了对浏览器实例的各项功能回调的接口。一个 CefClient 的实例可以在任意数量的浏览器之间共享，它为这些共享它的浏览器实例提供了各项行为的处理，因此，在 NanUI 中，您可以通过这些处理器以及回调来实现各项浏览器功能。

`CefClient`类定义了非常多的接口用于处理浏览器的各项行为，下面的文档中只对常用的接口进行举例说明，如果您关注更多信息，请参考[此文档](<https://magpcss.org/ceforum/apidocs3/projects/(default)/CefClient.html>)。

在 NanUI 中，承载窗体的基类`Formium`类，抽象方法`OnWindowReady`提供的参数`IWebBrowserHandler`包含了`CefClient`类提供的各种接口，NanUI 只实现了这些接口中必要的部分，您需要自行为这些接口创建对应的处理器才能实现完整的浏览器功能（例如：文件下载，更改窗体标题，自定义弹窗行为等）。

## LoadHandler

LoadHandler 主要处理浏览器加载状态的相关事件。

- `OnLoadStart` 处理浏览器开始加载触发的事件
- `OnLoadEnd` 处理浏览器加载完成时触发的事件
- `OnLoadError` 处理浏览器加载失败时的事件，您可以在此事件的参数中拿到错误代码、出错提示文本等信息。

## LifeSpanHandler

LifeSpanHandler 主要包含了浏览器生命周期相关的事件，例如浏览器窗口的创建、关闭等。

- `OnBeforePopup` 处理浏览器新建窗口时触发的事件，如果您的项目需要处理网页中的超链接，并通过特定的行为打开这些超链接，那么您需要为此接口提供处理器。
- `OnBeforeClose` 处理浏览器窗口关闭前触发的事件，您可以通过处理此事件来确定是否真的需要关闭当前窗口的浏览器进程。
- `DoClose` 处理浏览器窗口的关闭事件，这个事件发生在`OnBeforeClose`之后，简言之，就是浏览器确定需要关闭时触发的事件。

## DisplayHandler

DisplayHandler 主要包括了浏览器各种状态的显示相关的接口及事件，例如当前页面标题的变更，浏览器状态变化，控制台信息变化等。

- `OnAddressChange` 浏览器页面地址变更事件。
- `OnConsoleMessage` 控制台消息变更事件。您可以通过为这个事件设置处理器来监控控制台的信息而不必打开`DevTools`。
- `OnFullscreenModeChange` 全屏模式变更事件。常见的 Video 标签播放视频时可选择的“全屏播放”功能将触发此事件，NanUI 默认没有为此事件提供处理器，因此视频将只能铺满承载窗体的客户区域，而不是铺满全屏。如果需要此功能，请自行定制处理器。
- `OnLoadingProgressChange` 浏览器加载进度条变化的事件。
- `OnStatusMessage` 浏览器状态栏信息变更的事件。
- `OnTitleChange` 浏览器标题变更的事件。

## DownloadHandler

DownloadHandler 顾名思义主要用于处理浏览器的下载行为，NanUI 默认也没有对浏览器下载行为提供处理支持，NanUI 的设计理念中，文件的下载、上传、传输等操作都都应该通过.NET 的 System.IO 来实现，因为用.NET 的实现异步操作更简便。

- `OnBeforeDownload` 当浏览器触发下载动作前发生的事件。您需要处理此事件才能实现正常的下载功能。
- `OnDownloadUpdated` 下载进度改变是触发的事件。如果您实现了`OnBeforeDownload`接口的处理器，那么您可以在此事件中获取与下载进度相关的参数。

## RequestHandler

RequestHandler 主要处理与浏览器请求相关的事件。

- `GetAuthCredentials` 浏览器访问 SSL 链接请求证书时触发的事件。您可以在此事件中为您特定的网站忽略证书错误，也可以伪造证书实现特定功能。
- `GetResourceRequestHandler` 获取当前资源请求的处理器。通过处理此事件来实现修改浏览器请求（数据、Cookie 等）。
- `OnBeforeBrowse` 浏览器请求发送之前触发的事件。
- `OnRenderProcessTerminated` 渲染进程挂掉时触发的事件。NanUI 以为此事件提供了默认的处理器，在渲染进程挂掉时刷新当前页面，重新加载并重启渲染进程。如果不处理此事件，渲染进程挂掉时将显示为“白屏”。

## JSDialogHandler

JSDialogHandler 主要包含了处理与 JavaScript 对话框相关的事件，例如您想实现一个有逼格的 Alert 窗口，那么就需要使用到这些接口。
