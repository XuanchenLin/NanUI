# Form JavaScript Guide

## Overview

In WinFormium, you can use the JavaScript interface to control the behavior of the form, such as moving the form, minimizing the form, maximizing the form, restoring the form, making the form full screen, etc. This is because there is a series of JavaScript APIs built into WinFormium that allow you to control the behavior of the form in the front-end page.

This article will introduce WinFormium's built-in JavaScript API and its related CSS styles.

## Built-in JavaScript objects

### Formium object

In WinFormium, you can use the `formium` object in the front-end environment to access WinFormium's JavaScript objects, for example:

```js
formium.hostWindow.close();
```

In the above example, the `formium` object is a global object and you can access it from anywhere. The `formium` object contains the following properties and methods:

**Attributes**

| Attribute name | Description                                           |
| -------------- | ----------------------------------------------------- |
| hostWindow     | Get the form object                                   |
| version        | Get WinFormium version information                    |
| culture        | Get the current region information of the application |

**method**
| Method name | Description |
| ------ | ---- |
|onContextReady(callback)| The callback function is triggered when the context of the current form is ready |
|onDocumentReady(callback)| The callback function is triggered when the document of the current form is ready |
|postMessage(message,data)| The current host form sends a message |
|addMessageHandler(name,handler)| Add a message handler |
|removeMessageHandler(name)| Remove a message processor |
|sendRequest(string,data)| Send a message request to the current host window and get the return value immediately |
|sendRequestAsync(string,data)| Send a message request to the current host window and obtain the return value asynchronously |

Multiple methods are provided in the `formium` object to communicate with the host form. Please refer to the [Communication](#communication) section later in the document.

### HostWindow object

The `HostWindow` object is associated with the current WinFormium form. Use the `formium.hostWindow` object to access its properties and methods:

**Attributes**

| Attribute name | Description                           |
| -------------- | ------------------------------------- |
| bounds         | Get the position and size of the form |
| location       | Get or set the location of the form   |
| size           | Get or set the size of the form       |
| windowState    | Get or set the state of the form      |

**Methods**

| Method name             | Description                          |
| ----------------------- | ------------------------------------ |
| active()                | Activate the form                    |
| center()                | Center the form                      |
| close()                 | Close the form                       |
| fullScreen()            | Switch the form to full screen state |
| maximize()              | Maximize the form                    |
| minimize()              | Minimize the form                    |
| restore()               | Restore form                         |
| moveBy(x, y)            | Move the window by offset `(x,y)`    |
| moveTo(x, y)            | Move the form to `(x,y)` position    |
| resizeBy(dx, dy)        | Resize the form by offset `(dx,dy)`  |
| resizeTo(width, height) | Resize the form to `(width,height)`  |

### Version object

The `Version` object contains WinFormium version information, and you can use the `formium.version` object to access its properties:

**Attributes**

| Attribute name | Description                                    |
| -------------- | ---------------------------------------------- |
| Application    | Get the version information of the application |
| Chromium       | Get Chromium version information               |
| WinFormium     | Get WinFormium version information             |

### Culture object

The `Culture` object contains information about the current locale of the application, and you can access its properties using the `formium.culture` object:

**Attributes**

| Attribute name | Description                                   |
| -------------- | --------------------------------------------- |
| cultureName    | Get the name array list of the current region |
| lcid           | Get the LCID of the current region            |
| name           | Get the name of the current area              |

### External object

The `External` object is used to load JavaScript objects registered in the WinFormium form using the `RegisterJavaScriptObject` method. You can use `window.external` to access these registered objects.

For more information about the `RegisterJavaScriptObject` method, please refer to the article ["Register .NET Mapping Objects in JavaScript"](./JavaScript/Register-Mapping-Objects.md).

## Events

When the WinFormium form state changes, a series of events will be triggered, and you can subscribe to these events through JavaScript.

At the same time, when the state of some forms changes, some CSS class names will also be marked on the `html` element of the current page. You can use these CSS class names to achieve some special front-end style effects. These CSS class names adopt the `BEM` naming convention, please pay attention to the distinction.

| Event name                | Description                                                                                                                                                                      | Associated CSS class name                                         |
| ------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- |
| hostwindowstatechanged    | Triggered when the form state changes. The parameters `{ state: "<state>" }` are: `normal`, `maximized`, `minimized`, `fullscreen` indicating the current state of the form.     | `formium--maximized`, `formium--minimized`, `formium--fullscreen` |
| hostresized               | Triggered when the size of the form changes. The parameters `{x, y, width, height, rectangle :{ top, right, bottom, left }}` are the position and size of the form.              | None                                                              |
| hostmoved                 | Triggered when the position of the form changes, the parameters `{x, y}` are the position of the form.                                                                           | None                                                              |
| hostcolorschemechanged    | Triggered when the form color scheme changes, the parameters `{ scheme: "<colorScheme>" }` are: `light`, `dark` indicates the current color scheme of the form.                  | `formium-color-scheme--light`, `formium-color-scheme--dark`       |
| hostactivatedstatechanged | Triggered when the activation state of the form changes. The parameters `{ activated: "<activated>" }` are: `true`, `false` indicating the current activation state of the form. | `formium--activated`, `formium--deactivate`                       |
| hostactivated             | Fired when the form is activated.                                                                                                                                                | None                                                              |
| hostdeactivate            | Fired when the form loses activation.                                                                                                                                            | None                                                              |

You can add an event handler for an event. When these events are triggered, the event handler will be called, and the parameter `detail` includes various additional parameters of the event. For example:

```js
window.addEventListener("hostresized", function (e) {
  console.log(e.detail);
  // console: {x: 0, y: 0, width: 800, height: 600, rectangle: { left: 0, top: 0, right: 800, bottom: 600 }}
});
```

The following example is a maximize button component written in React. The component listens to the event `hostwindowstatechanged` to present different icons when the form state changes, and correctly handles the WinFormium state when the event is clicked.

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

## Communication

A series of methods are built into WinFormium's front-end object `formium` to communicate with the host form. You can use these methods to communicate with the host form. The communication between WinFormium front-end and back-end is divided into two forms: **message** and **request**.

### Messages

Messages are a way for WinFormium's front-end and back-end communication. Each message is equipped with a name and its corresponding parameters. Use the `formium.postMessage` method to send messages in the JavaScript environment. Similarly, you can also use `Formium`'s `PostBrowserJavaScriptMessage` method to send messages in a C# environment.

Since it is a message, you need to have a receiver of the message. You can use the `RegisterJavaScriptMessagDispatcher` method of `Formium` in the C# environment to register the message processor, so that you can receive the message sent by the front end. In a JavaScript environment, you can use the `formium.addMessageDispatcher` method to register a message handler to receive messages and data sent from a C# environment.

The following example is a simple front-end communication example:

**C#**

Register the `HelloMate` message processor and receive the data attached to the message. In any method of the `Formium` class (according to business needs, you can register the message processor in advance or later.) Add the following code:

```csharp
RegisterJavaScriptMessagDispatcher("HelloMate", args =>
{
     string data = args; // args: JavaScriptValue type, explicitly converted to string type here

     MessageBox.Show($"Hello, friend from {data}!"); // Display message box: Hello, friend from JavaScript!

     PostBrowserJavaScriptMessage("HelloMate", "WinFormium"); // Send message to JavaScript environment
});
```

**JavaScript**

To register the `HelloMate` message handler and receive the data attached to the message, add the following code in the JavaScript environment:

```js
formium.addMessageDispatcher("HelloMate", (data) => {
  alert(`Greetings, friend from ${data}!`); // Display message box: Greetings, friend from WinFormium!
});
```

Send a `HelloMate` message, appending data:

```js
formium.postMessage("HelloMate", "JavaScript"); //Send a message, the first parameter is the message name, and the second parameter is any JavaScript data type
```

At any time, use the `RemoveJavaScriptMessageDispatcher(message)` method in a C# environment to remove a message handler, or in a JavaScript environment use the `formium.removeMessageDispatcher(message)` method to remove a message handler.

### Requests

Requests are a way for the WinFormium front-end to communicate with the back-end. Unlike messages, requests need to have a return value, and such requests can only be sent in one direction from JavaScript to C#.

In a JavaScript environment, you can use the `formium.sendHostWindowRequest` method to send a synchronous request, which will return the result of the request immediately, or use the `formium.sendHostWindowRequestAsync` method to send an asynchronous request, which will return the result of the request after the request is completed. Returns the requested result.

In a C# environment, you can use the `RegisterJavaScriptSynchronousRequestDispatcher` method of `Formium` to handle synchronous requests from the front end, or the `RegisterJavaScriptAsynchronousRequestDispatcher` method to handle asynchronous requests from the front end.

The following example is a simple front-end requesting data from the back-end:

**C#**

```csharp
// Synchronous request handler
RegisterJavaScriptSynchronousRequestDispatcher("sync", args => "OK sync");

//Asynchronous request handler
RegisterJavaScriptAsynchronousRequestDispatcher("async", async (args, promise) => {
     await Task.Delay(3000); // Simulate asynchronous operation
     promise.Resolve("OK async");
});
```

**JavaScript**

```js
// Synchronous request
const sync = formium.sendHostWindowRequest("sync");
console.log(sync); // console: OK sync

// Asynchronous request
formium.sendHostWindowRequestAsync("async").then((data) => {
  console.log(data); // console: OK async
});
```

## See also

- [Forms](./overview.md)
- [Form Features](./Form-Features.md)
- [Browser Features](./Browser-Features.md)
- [Forms without Titlebar](./Forms-Without-Titlebar.md)
