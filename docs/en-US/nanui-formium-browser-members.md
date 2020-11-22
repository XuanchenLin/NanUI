# Formium browser related members

[[Home](README.md)]

- [Formium browser related members](#formium-browser-related-members)
  - [Attributes](#attributes)
  - [Method](#method)
  - [Incident](#incident)

## Attributes

**CanGoBack {get; }** `bool`

Whether the current browser page can perform the "back" operation.

**CanGoForward {get; }** `bool`

Whether the current browser page can perform "foreground" operations.

**FrameCount {get; }** `int`

Get the number of frames (Frame) of the current form in the browser, usually including the browser's main frame itself.

**HasDocument {get; }** `bool`

Get whether the current browser has a Document object.

**Identifier {get; }** `int`

Get the ID of the current form browser object.

**IsLoading {get; }** `bool`

Indicates whether the current pile browser is in the loading state.

**IsWebViewReady {get; }** `bool`

Gets whether the current form browser view is already available.

## Method

**public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(string code)**

Execute JavaScript code asynchronously and return the execution result.

parameter

- _code:`string`_: JavaScript code to be executed.

return value

- _System.Threading.Tasks.Task<NetDimension.NanUI.JavaScript.JavaScriptExecutionResult>_: The waitable JavaScriptExecutionResult is the result and return value of this execution.

**public void ExecuteJavaScript(string code)**

Execute JavaScript code directly without waiting for the return result.

**public CefFrame GetFocusedFrame()**

Get the frame that is currently in focus.

return value

- _CefFrame_: Frame example.

parameter

- _code:`string`_: JavaScript code to be executed.

**public CefFrame GetMainFrame()**

Get the frame that is currently in focus.

return value

- _CefFrame_: Frame example.

**public CefFrame GetFrame(string name|int identifier)**

Get the frame instance based on the frame name `name` or frame number `identifier`.

parameter

- _name:`string`|identifier:`int`_: frame name or frame number identifier.

return value

- _CefFrame_: The main frame of the current browser page.

**public long[] GetFrameIdentifiers()**

Get the numbers of all frames in the current page.

return value

- _long[]_: Frame number array.

**public string[] GetFrameNames()**

Get the names of all frames in the current page.

return value

- _string[]_: An array of frame names.

**public CefBrowserHost GetHost()**

Get the `CefBrowserHost` instance of the current window.

return value

- _CefBrowserHost_: CefBrowserHost

**public void GoBack()**

Return to the previous page of the browser history. Need to cooperate with `CanGoBack` property.

**public void GoForward()**

Advance to the next page of the browser history. Need to cooperate with `CanGoForward` property.

**public void RegisterExternalObjectValue(string name, JavaScriptValue value)**

Register the .NET object mapping with the browser environment. Use `JavaScriptValue` to create an object of JavaScript type `Object`, and map the properties or methods of the .NET object to it.

parameter

- _name:`string`_: Object name.
- _value:`JavaScriptValue`_: JavaScript object mapping.

**public void Reload(bool forceReload = false)**

Refresh the current browser page. If the `forceReload` attribute is specified, the cache will be ignored and the current page is forced to refresh.

parameter

- _forceReload:`bool`_: true to force a page refresh; the default is false.

**public void StopLoad()**

Stop loading the page currently being loaded by the browser.

**public void ShowDevTools()**

Open the DevTools window.

## Events

**AddresChanged**

Triggered when the address of the browser address bar changes.

**DocumentTitleChanged**

Fires when the current browser title changes.

**StatusMessage**

Triggered when the content of the current browser status bar changes.

**FullScreenModeChanged**

Triggered when the full screen mode of the current browser changes.

**BeforeClose**

Triggered when the browser page or form is about to close.

**BeforeContextMenu**

When you right-click in the browser, the context menu is triggered just before the context menu appears.

**ContextMenuCommand**
Triggered when the user clicks on the browser's context menu item.

**BeforeDownload**

Triggered when the browser is about to start a file download operation.

**DownloadUpdated**

Triggered when the download progress of the current browser changes.

**BeforePopup**

Triggered when the browser is about to open a new page.

**BrowserCreated**

Triggered when the browser instance is created.

**ConsoleMessage**

Triggered when the browser console receives a new message.

**DragEnter**

Triggered when the user drags content above the browser instance of the current form.

**KeyEvent**

Fires when the user hits the keyboard on the browser instance of the current form.

**PreKeyEvent**

Fires when the user hits the keyboard in the browser instance of the current form.

**LoadStart**

Triggered when the current browser process starts to load the page.

**LoadEnd**

Triggered when the current browser process finishes loading the page.

**LoadError**

Triggered when an error occurs when the current browser process loads the page.

**LoadingProgressChanged**

Triggered when the current browser process loading process changes.

**LoadingStateChanged**

Triggered when the loading status of the current browser process changes.

**RenderProcessTerminated**

Triggered when the rendering process of the current browser hangs.
