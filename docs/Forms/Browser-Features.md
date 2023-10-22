# Browser Features

## Overview

This article mainly introduces how to use WinFormium's form `Formium` class and its content related to browser functions. The form-related content in the `Formium` class will be introduced in ["Form Function"](./Form Function.md).

## Load web page

You can use the `Url` attribute to specify the address of the web page that needs to be loaded. Before the browser is initialized, you can specify the `Url` attribute in the constructor, then the specified web page will be automatically loaded after the browser is loaded. If the browser is loaded, modifying the `Url` attribute will load the new web page immediately.

In addition, `Formium` provides the `Reload` method to reload the current web page. You can call this method to reload the current web page when needed. This method has an optional `ignoreCache` parameter, which if set to `true` will ignore the cache when reloading the web page.

## Navigation

You can use the `GoBack` and `GoForward` methods to implement the browser's forward and backward functionality. Before calling these two methods, you can first determine whether the value of the `CanGoBack` and `CanGoForward` properties is `true`. If it is `true`, you can call the `GoBack` and `GoForward` methods.

## Debugging tools

You can display the browser's debugging tools using the `ShowDevTools` method of the `Formium` class. Use the `CloseDevTools` method to hide debugging tools. Use the `HasDevTools` property to determine whether debugging tools are displayed.

## Execute JavaScript code

You can use the `ExecuteJavaScript` method to execute JavaScript code. You can also use the `EvaluateJavaScript` method to execute JavaScript code and return the execution results.

For more information about executing JavaScript in WinFormium, see the JavaScript chapter.

## Web page title

You can use the `UsePageTitle` property to specify whether to use the page title to set the form title. If set to `true`, the page title will be used to set the form title. If set to `false`, the default form title will be used to set the form title.

## API Reference

### Attributes

**Common Properties**

| Property name       | Description                                                                          | Type                | Default value   |
| ------------------- | ------------------------------------------------------------------------------------ | ------------------- | --------------- |
| CanGoBack           | Gets a value indicating whether the browser can navigate backwards.                  | bool                | false           |
| CanGoForward        | Gets a value indicating whether the browser can navigate forward.                    | bool                | false           |
| ChromiumEnvironment | Get the Chromium environment of the current browser.                                 | ChromiumEnvironment |                 |
| HasDevTools         | Gets a value indicating whether the browser's debugging tools have been displayed.   | bool                | false           |
| IsLoading           | Gets a value that indicates whether the browser is loading the web page.             | bool                | false           |
| Url                 | Get or set the address of the web page currently loaded by the browser.              | string              | "formium:blank" |
| UsePageTitle        | Gets or sets a value indicating whether to use the page title to set the form title. | bool                | true            |

**BrowserClient interface properties**

| Attribute name     | Description                                           | Type                          |
| ------------------ | ----------------------------------------------------- | ----------------------------- |
| AudioHandler       | Gets or sets the browser's audio handler.             | WinFormium.AudioHandler       |
| ContextMenuHandler | Gets or sets the browser's context menu handler.      | WinFormium.ContextMenuHandler |
| DialogHandler      | Gets or sets the browser's dialog handler.            | WinFormium.DialogHandler      |
| DisplayHandler     | Gets or sets the browser's display handler.           | WinFormium.DisplayHandler     |
| DownloadHandler    | Gets or sets the browser's download handler.          | WinFormium.DownloadHandler    |
| DragHandler        | Gets or sets the browser's drag and drop handler.     | WinFormium.DragHandler        |
| FindHandler        | Gets or sets the browser's find handler.              | WinFormium.FindHandler        |
| FocusHandler       | Gets or sets the browser's focus handler.             | WinFormium.FocusHandler       |
| FrameHandler       | Gets or sets the browser's frame handler.             | WinFormium.FrameHandler       |
| JsDialogHandler    | Gets or sets the browser's JavaScript dialog handler. | WinFormium.JsDialogHandler    |
| KeyboardHandler    | Gets or sets the browser's keyboard handler.          | WinFormium.KeyboardHandler    |
| LifeSpanHandler    | Gets or sets the browser's life cycle handler.        | WinFormium.LifeSpanHandler    |
| LoadHandler        | Gets or sets the browser's load handler.              | WinFormium.LoadHandler        |
| PermissionHandler  | Gets or sets the browser's permission handler.        | WinFormium.PermissionHandler  |
| RenderHandler      | Gets or sets the browser's rendering handler.         | WinFormium.RenderHandler      |
| RequestHandler     | Gets or sets the browser's request handler.           | WinFormium.RequestHandler     |

### Methods

| Method name                                                                              | Description                                              | Return value                   |
| ---------------------------------------------------------------------------------------- | -------------------------------------------------------- | ------------------------------ |
| BeginRegisterJavaScriptObject(CefFrame)                                                  | Start registering JavaScript objects.                    | JavaScriptObjectRegisterHandle |
| RegisterJavaScriptObject(JavaScriptObjectRegisterHandle,string, JavaScriptObject)        | Register a JavaScript object.                            | bool                           |
| RegisterJavaScriptObject(JavaScriptObjectRegisterHandle,string, JavaScriptObjectWrapper) | Register a JavaScript object.                            | bool                           |
| EndRegisterJavaScriptObject(JavaScriptObjectRegisterHandle)                              | End registration of JavaScript objects.                  | void                           |
| EvaluateJavaScript(string,string,int)                                                    | Execute JavaScript code and return the execution result. | Task<JavaScriptResult>         |
| EvaluateJavaScript(CefFrame,string,string,int)                                           | Execute JavaScript code and return the execution result. | Task<JavaScriptResult>         |
| ExecuteJavaScript(string,string,int)                                                     | Execute JavaScript code.                                 | void                           |
| ExecuteJavaScript(CefFrame,string,string,int)                                            | Execute JavaScript code.                                 | void                           |
| GoBack()                                                                                 | Navigate to the previous web page.                       | void                           |
| GoForward()                                                                              | Navigate to the next web page.                           | void                           |
| ShowDevTools()                                                                           | Shows the browser's debugging tools.                     | void                           |
| CloseDevTools()                                                                          | Hide the browser's debugging tools.                      | void                           |
| Reload(bool)                                                                             | Reload the current web page.                             | void                           |
| PostBrowserJavaScriptMessage(string,JavaScriptValue)                                     | Send a JavaScript message to the current browser.        | void                           |

### Events

| Event name                | Description                                                     | Parameters                         |
| ------------------------- | --------------------------------------------------------------- | ---------------------------------- |
| BeforeBrowse              | Occurs before the browser navigates to a new web page.          | BeforeBrowseEventArgs              |
| BeforeDownload            | Occurs before the browser starts downloading the file.          | BeforeDownloadEventArgs            |
| BeforeKeyEvent            | Occurs before the browser receives a keyboard event.            | BeforeKeyEventEventArgs            |
| BrowserCreated            | Occurs after the browser is created.                            | BrowserCreatedEventArgs            |
| CanDownload               | Occurs before the browser starts downloading the file.          | CanDownloadEventArgs               |
| ConsoleMessage            | Occurs when a message is output to the browser console.         | ConsoleMessageEventArgs            |
| CursorChange              | Occurs when the browser's cursor changes.                       | CursorChangeEventArgs              |
| DocumentAvailable         | Occurs after the browser loads the web document.                | DocumentAvailableEventArgs         |
| DownloadUpdated           | Occurs when the browser downloads a file.                       | DownloadUpdatedEventArgs           |
| FaviconUrlChange          | Occurs when the browser's web page icon changes.                | FaviconUrlChangeEventArgs          |
| FramePageAddressChange    | Occurs when the browser's web page address changes.             | FramePageAddressChangeEventArgs    |
| FramePageLoadEnd          | Occurs after the browser's web page has finished loading.       | FramePageLoadEndEventArgs          |
| FramePageLoadError        | Occurs when the browser's web page fails to load.               | FramePageLoadErrorEventArgs        |
| FramePageLoadStart        | Occurs after the browser's web page starts loading.             | FramePageLoadStartEventArgs        |
| FullscreenModeChange      | Occurs when the browser's full screen mode changes.             | FullscreenModeChangeEventArgs      |
| GetAuthCredentials        | Occurs when the browser requires the user to enter credentials. | GetAuthCredentialsEventArgs        |
| KeyEvent                  | Occurs when the browser receives a keyboard event.              | KeyEventArgs                       |
| MediaAccessChange         | Occurs when the browser's media access permissions change.      | MediaAccessChangeEventArgs         |
| OpenUrlFromTab            | Occurs when the browser needs to open a new web page.           | OpenUrlFromTabEventArgs            |
| PageAddressChange         | Occurs when the browser's web page address changes.             | PageAddressChangeEventArgs         |
| PageLoadEnd               | Occurs after the browser's page has finished loading.           | PageLoadEndEventArgs               |
| PageLoadError             | Occurs when the browser fails to load a web page.               | PageLoadErrorEventArgs             |
| PageLoadStart             | Occurs after the browser page has started loading.              | PageLoadStartEventArgs             |
| PageLoadingProgressChange | Occurs when the browser's page loading progress changes.        | PageLoadingProgressChangeEventArgs |
| PageLoadingStateChange    | Occurs when the browser's page loading state changes.           | PageLoadingStateChangeEventArgs    |
| PageTitleChange           | Occurs when the browser's page title changes.                   | PageTitleChangeEventArgs           |
| RenderProcessCrashed      | Occurs when the browser's rendering process crashes.            | RenderProcessCrashedEventArgs      |
| SetFocus                  | Occurs when the browser gains focus.                            | SetFocusEventArgs                  |
| StatusMessageChange       | Occurs when the browser's status message changes.               | StatusMessageChangeEventArgs       |
| TakeFocus                 | Occurs when the browser loses focus.                            | TakeFocusEventArgs                 |
| Tooltip                   | Occurs when the browser's tooltip changes.                      | TooltipEventArgs                   |

## See also

- [Forms](./overview.md)
- [Form Features](./Form-Features.md)
- [Forms JavaScript Guide](./Form-JavaScript-Guide.md)
