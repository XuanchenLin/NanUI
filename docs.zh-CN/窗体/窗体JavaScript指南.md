# 窗体 JavaScript 指南

## 概述

在 WinFormium 中，您可以使用 JavaScript 接口来控制窗体的行为，例如移动窗体、最小化窗体、最大化窗体、还原窗体、全屏化窗体等。这是因为在 WinFormium 中内置了一系列的 JavaScript API，这些 API 可以让您在前端页面中控制窗体的行为。

本文将介绍 WinFormium 内置的 JavaScript API 以及与其相关的 CSS 样式。

## 内置 JavaScript 对象

### Formium 对象

在 WinFormium 中，您可以在前端环境中使用 `formium` 对象来访问 WinFormium 的 JavaScript 对象，例如：

```js
formium.hostWindow.close();
```

在上面的示例中，`formium` 对象是一个全局对象，您可以在任何地方访问它。`formium` 对象包含了以下属性和方法：

**属性**

| 属性名     | 描述                       |
| ---------- | -------------------------- |
| hostWindow | 获取窗体对象               |
| version    | 获取 WinFormium 的版本信息 |
| culture    | 获取应用程序的当前区域信息 |

**方法**
| 方法名 | 描述 |
| ------ | ---- |
|onContextReady(callback)| 当前窗体的上下文环境已经准备就绪时触发回调函数 |
|onDocumentReady(callback)| 当前窗体的文档已经准备就绪时触发回调函数 |
|postMessage(message,data)| 当前的宿主窗体发送消息 |
|addMessageHandler(name,handler)| 添加一个消息处理器 |
|removeMessageHandler(name)| 移除一个消息处理器 |
|sendRequest(string,data)| 向当前的宿主窗体发送消息请求，并立即获取返回值 |
|sendRequestAsync(string,data)| 向当前的宿主窗体发送消息请求，并异步获取返回值 |

在 `formium` 对象中提供了多个方法来于宿主窗体通信，请参考文档后面的[通信](#通信)一节。

### HostWindow 对象

`HostWindow` 对象关联了当前 WinFormium 窗体。使用 `formium.hostWindow` 对象来访问其属性和方法：

**属性**

| 属性名      | 描述                 |
| ----------- | -------------------- |
| bounds      | 获取窗体的位置和大小 |
| location    | 获取或设置窗体的位置 |
| size        | 获取或设置窗体的大小 |
| windowState | 获取或设置窗体的状态 |

**方法**

| 方法名                  | 描述                            |
| ----------------------- | ------------------------------- |
| active()                | 激活窗体                        |
| center()                | 居中窗体                        |
| close()                 | 关闭窗体                        |
| fullScreen()            | 切换窗体全屏化状态              |
| maximize()              | 最大化窗体                      |
| minimize()              | 最小化窗体                      |
| restore()               | 还原窗体                        |
| moveBy(x, y)            | 按偏移量 `(x,y)` 移动窗体       |
| moveTo(x, y)            | 移动窗体到 `(x,y)` 位置         |
| resizeBy(dx, dy)        | 按偏移量 `(dx,dy)` 调整窗体大小 |
| resizeTo(width, height) | 调整窗体大小到 `(width,height)` |

### Version 对象

`Version` 对象包含了 WinFormium 的版本信息，您可以使用 `formium.version` 对象来访问其属性：

**属性**

| 属性名      | 描述                       |
| ----------- | -------------------------- |
| Application | 获取应用程序的版本信息     |
| Chromium    | 获取 Chromium 的版本信息   |
| WinFormium  | 获取 WinFormium 的版本信息 |

### Culture 对象

`Culture` 对象包含了应用程序的当前区域信息，您可以使用 `formium.culture` 对象来访问其属性：

**属性**

| 属性名      | 描述                       |
| ----------- | -------------------------- |
| cultureName | 获取当前区域的名称数组列表 |
| lcid        | 获取当前区域的 LCID        |
| name        | 获取当前区域的名称         |

### External 对象

`External` 对象用于装载 WinFormium 窗体中使用 `RegisterJavaScriptObject` 方法注册的 JavaScript 对象，您可以使用 `window.external` 来访问这些注册的对象。

有关 `RegisterJavaScriptObject` 方法的更多信息，请参考[《在 JavaScript 中注册 .NET 映射对象》](./JavaScript/在JavaScript中注册.NET映射对象.md)一文。

## 事件

在 WinFormium 窗体状态改变时，将触发一系列的事件，您可以通过 JavaScript 来订阅这些事件。

同时，在某些窗体状态改变时，还会在当前页面的 `html` 元素上标记上一些 CSS 类名称，您可以使用这些 CSS 类名称来实现一些特殊的前端样式效果。这些 CSS 类名称采用 `BEM` 命名规范，请注意区分。

| 事件名                    | 描述                                                                                                                   | 关联的 CSS 类名称                                                 |
| ------------------------- | ---------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- |
| hostwindowstatechanged    | 当窗体状态改变时触发，参数 `{ state: "<state>" }` 为：`normal`,`maximized`,`minimized`,`fullscreen` 指示窗体当前状态。 | `formium--maximized`, `formium--minimized`, `formium--fullscreen` |
| hostresized               | 当窗体大小改变时触发，参数 `{x, y, width, height, rectangle :{ top, right, bottom, left }}` 为窗体的位置和大小。       | 无                                                                |
| hostmoved                 | 当窗体位置改变时触发，参数 `{x, y}` 为窗体的位置。                                                                     | 无                                                                |
| hostcolorschemechanged    | 当窗体颜色方案改变时触发，参数 `{ scheme: "<colorScheme>" }` 为：`light`,`dark` 指示窗体当前颜色方案。                 | `formium-color-scheme--light`, `formium-color-scheme--dark`       |
| hostactivatedstatechanged | 当窗体激活状态改变时触发，参数 `{ activated: "<activated>" }` 为：`true`,`false` 指示窗体当前激活状态。                | `formium--activated`, `formium--deactivate`                       |
| hostactivated             | 当窗体激活时触发。                                                                                                     | 无                                                                |
| hostdeactivate            | 当窗体失去激活时触发。                                                                                                 | 无                                                                |

您可以为某一个事件添加一个事件处理器。在这些事件触发时，事件处理器将会被调用，其中的参数 `detail` 包括了事件的各项附加参数。例如：

```js
window.addEventListener("hostresized", function (e) {
  console.log(e.detail);
  // console: {x: 0, y: 0, width: 800, height: 600, rectangle: { left: 0, top: 0, right: 800, bottom: 600 }}
});
```

以下示例是一个使用 React 编写的最大化按钮组件，该组件对事件 `hostwindowstatechanged` 进行监听以此来实现窗体状态改变时呈现不同的图标，并且在单击事件时对 WinFormium 状态进行正确处理。

```jsx
import React, { useEffect, useState } from "react";

const MaximizeButton = () => {
  const [isMaximized, setIsMaximized] = useState(
    formium?.hostWindow.windowState === "maximized"
  );

  const handleWindowStateChanged = (e) => {
    const {
      detail: { state },
    } = e;
    setIsMaximized(state === "maximized");
  };

  useEffect(() => {
    window.addEventListener("hostwindowstatechanged", handleWindowStateChanged);

    return () => {
      window.removeEventListener(
        "hostwindowstatechanged",
        handleWindowStateChanged
      );
    };
  }, [isMaximized]);

  const handleClick = () => {
    if (isMaximized) {
      formium?.hostWindow?.restore();
    } else {
      formium?.hostWindow?.maximize();
    }
  };

  return (
    <div className="command-buttons__maximiaze" onClick={handleClick}>
      {isMaximized ? (
        <i className="icon icon-restore" title="Restore"></i>
      ) : (
        <i className="icon icon-maximize" title="Maximize"></i>
      )}
    </div>
  );
};

export default MaximizeButton;
```

## 通信

在 WinFormium 的前端对象 `formium` 中内置了一系列的方法来实现与宿主窗体的通信，您可以使用这些方法来实现与宿主窗体的通信。WinFormium 前端与后端的通信被分为两种形式：**消息**和**请求**。

### 消息

消息是 WinFormium 前后端通信的一种方式，每个消息都配有一个名称和其对应的参数，在 JavaScript 环境中使用 `window.formium.postMessage` 方法来发送消息。同样的，您也可以在 C# 环境中使用 `Formium` 的 `PostJavaScriptMessage` 方法来发送消息。

既然是消息，那么就需要有消息的接收者，您可以在 C# 环境中使用 `Formium` 的 `RegisterJavaScriptMessagHandler` 方法来注册消息处理器，这样就可以接收到前端发送的消息。在 JavaScript 环境中，您可以使用 `window.formium.onMessage` 方法来注册消息处理器以接收 C# 环境发送过来的消息和数据。

以下示例是一个简单的前后端通信示例：

**C#**

注册 `HelloMate` 消息处理器，并接收该消息附加的数据，在 `Formium` 类的任意方法中（根据业务需求，您可以提前或稍后再注册消息处理器。）添加以下代码：

```csharp
RegisterJavaScriptMessagHandler("HelloMate", args =>
{
    string data = args; // args: JavaScriptValue 类型，此处显式转换为 string 类型

    MessageBox.Show($"Hello, friend from {data}!"); // 显示消息框：Hello, friend from JavaScript!

    PostJavaScriptMessage("HelloMate", "WinFormium"); // 发送消息到 JavaScript 环境
});
```

**JavaScript**

注册 `HelloMate` 消息处理器，并接收该消息附加的数据，在 JavaScript 环境中添加以下代码：

```js
window.formium.onMessage("HelloMate", (data) => {
  alert(`Greetings, friend from ${data}!`); // 显示消息框： Greetings, friend from WinFormium!
});
```

发送 `HelloMate` 消息，并附加数据：

```js
window.formium.postMessage("HelloMate", "JavaScript"); // 发送消息，第一个参数为消息名称，第二个参数为任意 JavaScript 数据类型
```

在任何时候，在 C# 环境使用 `RemoveJavaScriptMessageHandler(message)` 方法来移除消息处理器, 或在 JavaScript 环境使用 `window.formium.removeMessageDispatcher(message)` 方法来移除消息处理器。

### 请求

请求是 WinFormium 前端向后端通信的一种方式，与消息不同的是，请求需要有返回值，并且这种请求只能从 JavaScript 向 C# 单向发送。

在 JavaScript 环境中，您可以使用 `window.formium.sendRequest` 方法来发送同步请求，该方法将会立即返回请求的结果，或者使用 `window.formium.sendRequestAsync` 方法来发送异步请求，该方法将会在请求完成后返回请求的结果。

在 C# 环境中，您可用 `Formium` 的 `RegisterJavaScriptRequestHandler` 方法处理前端的同步和异步请求。

以下示例是一个简单的前端向后端请求数据的示例：

**C#**

```csharp
// 同步请求处理器
RegisterJavaScriptRequestHandler("sync", args => "OK sync");

// 异步请求处理器
RegisterJavaScriptRequestHandler("async", async (args, promise) => {
    await Task.Delay(3000); // 模拟异步操作
    promise.Resolve("OK async");
});
```

**JavaScript**

```js
// 同步请求
const sync = window.formium.sendRequest("sync");
console.log(sync); // console: OK sync

// 异步请求
window.formium.sendRequestAsync("async").then((data) => {
  console.log(data); // console: OK async
});
```

## 另请参阅

- [窗体](./概述.md)
- [窗体功能](./窗体功能.md)
- [浏览器功能](./浏览器功能.md)
- [无标题栏窗体](./无标题栏窗体.md)
