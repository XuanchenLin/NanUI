# 在您的NanUI应用程序中使用无边框样式

通过上一篇文档的介绍，您已经了解了创建NanUI应用以及创建Formium浏览器承载窗口的基础知识。使用与之前文档中介绍的相同套路创建完应用程序后，您只需要设置浏览器承载窗体的WindowType为Borderless模式即可创建无边框样式的窗体。

本篇文档将主要介绍无边框样式窗体的相关的知识点，内容涉及了NanUI系统中特殊的CSS、NanUI特有的html标记属性、Javascript对象和全局事件等。

## 设置承载窗体为无边框样式

指定WindowType属性为Borderless，让窗体以无边框样式呈现。

```C#
 public override HostWindowType WindowType => HostWindowType.Borderless;
```

## 设置可拖拽/不可拖拽区域

当窗体以无边框样式呈现时，默认窗口失去了原生窗口的标题栏及其控制区域，因此无法通过拖拽来移动窗体。这时，您需要通过设置特殊的CSS属性-webkit-app-region来确定web页面中的哪一部分区域支持拖拽，您可以通过灵活的设计可拖拽和不可拖拽区域来创建异形拖拽区域。

**设置可拖拽区域**
```CSS
.draggable-area {
    -webkit-app-region: drag;
}
```

**设置不可拖拽区域**
```CSS
.draggable-area {
    -webkit-app-region: no-drag;
}
```

使用下面的示例代码，绘制一个可拖拽的矩形区域，并在该区域内排除className="controls"的矩形区域。

**HTML**
```html
<div class="titlebar">
    <span>Welcome to NanUI</span>
    <div class="controls">
        <a title="Minimize" class="control-btn">
            <svg x="0px" y="0px" viewBox="0 0 10.2 1" data-radium="true" style="width: 10px; height: 10px;"><rect fill="#ffffff" width="10.2" height="1"></rect></svg>
        </a>
        <a title="Maximize" class="control-btn">
            <svg x="0px" y="0px" viewBox="0 0 10.2 10.1" data-radium="true" style="width: 10px; height: 10px;"><path fill="#ffffff" d="M0,0v10.1h10.2V0H0z M9.2,9.2H1.1V1h8.1V9.2z"></path></svg>
        </a>
        <a title="Close" class="control-btn">
            <svg x="0px" y="0px" viewBox="0 0 10.2 10.2" data-radium="true" style="width: 10px; height: 10px;"><polygon fill="#ffffff" points="10.2,0.7 9.5,0 5.1,4.4 0.7,0 0,0.7 4.4,5.1 0,9.5 0.7,10.2 5.1,5.8 9.5,10.2 10.2,9.5 5.8,5.1 "></polygon></svg>
        </a>
    </div>
</div>
```

**SCSS**
```SCSS
.titlebar {
    // scss ...
    -webkit-app-region: drag;

    > controls {
        // scss ...
        -webkit-app-region: no-drag;
    }
}

```

## 使用NanUI的内置命令

NanUI内置了html属性nanui-command，通过该属性您可以快速的实现无边框窗体的最大化、最小化、还原及关闭窗口命令。

例如设置nanui-command="close"可以实现点击该元素后关闭窗体。

```html
<a title="Minimize" class="control-btn" nanui-command="close">
    // 关闭按钮 ...
</a>
```

nanui-command属性的值有以下几组：

| 属性名   | 命令作用     |
| :------- | :----------- |
| maximize | 最大化窗口   |
| minimize | 最小化窗口   |
| restore  | 还原窗口     |
| close    | 关闭当前窗口 |

## 浏览器中的NanUI对象

NanUI在Chromium的Javascript环境中注册了NanUI对象，通过该对象您能够获取当前窗体的相关信息，或者使用内置的函数来改变窗体的各项状态。

**NanUI对象**

- `version` - type:*object* | NanUI版本信息对象
    - `cef` - type:*string* | 显示CEF版本字符串
    - `chromium` - type:*string* | 显示CEF版本字符串
    - `nanui` - type:*string* | 显示NanUI版本字符串
- `hostWindow` - type:*object* | NanUI承载窗口对象
    - `close()` - type:*function* | 关闭承载窗口
    - `maximize()` - type:*function* | 最大化承载窗口
    - `minimize()` - type:*function* | 最小化承载窗口
    - `restore()` - type:*function* | 还原承载窗口
    - `moveTo(x, y)` - type:*function* | 移动承载窗口到x,y的位置
    - `sizeTo(wdth*,heigh*)` - type:*function* | 设置承载窗口的宽为width,高为height
    - `height` - type:*integer* | 当前承载窗口的高度
    - `width` - type:*integer* | 当前承载窗口的宽度
    - `state` - type:*object* | NanUI承载窗口的详细状态
      - `clientHeight` - type:*integer* | 承载窗口客户区域高度
      - `clientWidth` - type:*integer* | 承载窗口客户区域宽度
      - `height` - type:*integer* | 承载窗口的高度
      - `width` - type:*integer* | 承载窗口的宽度
        - `windowState` - type:*object* | 承载窗口最大化最小化状态对象
          - `state` - type:*string* | 承载窗口状态名称[`normal`|`minimized`|`maximized`]
          - `code` - type:*object* | 承载窗口状态编码[`0`:normal|`1`:minimized|`2`:maximized]

## 浏览器中的自定义事件
NanUI除了在Chromium的Javascript环境中注册了对象以外，还注册了一些承载窗口改变的通知事件。您可以通过注册事件句柄来捕获这些事件，以此来实现各项功能。

- `hostactived` - *承载窗口获得焦点并被激活*

- `hostdeactivate` - *承载窗口失去焦点*

- `hostactivestatechange` - *承载窗口焦点状态改变*
  - 参数：actived - type:*boolean* | 激活状态[true:获得焦点|false:失去焦点]

- `hoststatechange` - *承载窗口最大化最小化状态改变*
  - 参数：state - type:*string* | 承载窗口状态名称[normal|minimized|maximized]
  - 参数：code - type:*integer* | 承载窗口状态编码[0:normal|1:minimized|2:maximized]
  
- `hostsizechange` - *承载窗口状态尺寸改变*
  - 参数：width - type:*integer* | 承载窗口客户区域宽度
  - 参数：height  - type:*integer* | 承载窗口客户区域高度

例如，我们可以通过捕获承载窗口最大化最小化状态改变的事件来为窗体添加不同的样式：
```JS
window.addEventListener("hoststatechange", e => {
    if (e.detail.code === 2) {
        console.log("最大化状态");
    } else if(e.detail.code === 1) {
        console.log("最小化状态");
    }
    else {
        console.log("正常状态");
    }
});
```