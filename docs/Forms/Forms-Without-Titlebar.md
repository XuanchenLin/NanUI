# Forms without Titlbar

## Overview

You can set the style of the form when creating a WinFormium form. There are many form styles that remove the system title bar and command buttons, such as: borderless form style, system form style with title bar removed, transparent Form styles, etc. Creating a form with this style will prevent you from dragging the form, and you will not be able to minimize, maximize, and close the form through system command buttons. If you need to implement these functions in this type of form, you can use the methods provided by the `Formium` class. WinFormium also provides some JavaScript APIs and css styles on the front end of the web page to implement these functions.

## Drag the form

When you create a borderless form or a system form with the title bar removed, you need to add the css attribute `app-region: drag` to an element on the front-end page that is used as a drag area, for example:

```html
<html>
  <head>
    <title>Drag to Move</title>
  </head>
  <body>
    <div>
      <h1 style="app-region: drag">
        Drag to Move<span style="app-region: no-drag">Exclude This Area</span>
      </h1>
    </div>
  </body>
</html>
```

In the above example, the `app-region: drag` attribute is added to the `h1` css attribute. After running the program, you can drag the `h1` element to move the form. Of course, if you want to exclude some areas from being draggable, you can add the `app-region: no-drag` attribute to the element, such as the `span` element in the example above.

It is very useful to flexibly use the `drag | no-drag` attribute value of the `app-region` attribute. You can use this attribute to realize dragging of the form, and you can also use this attribute to exclude some areas and make these areas inaccessible. drag. For example, when using html to simulate a system title bar, you can add the `app-region: drag` attribute to the entire region of the title bar, so that the title bar can be dragged to move the form, and the commands on the right side of the title bar You can add the `app-region: no-drag` attribute to the button area to exclude this area from the draggable area. This can avoid the problem of the command button not responding to mouse click events on the web page.

## System commands

### Use built-in commands

When you create a borderless form or a system form with the title bar removed, you need to add the html attribute `formium-command: [command]` to an element on the front-end page that is a form system command. To achieve the purpose of simulating command buttons, for example:

```html
<html>
  <head>
    <title>Drag to Move</title>
  </head>
  <body>
    <div>
      <h1 style="app-region: drag">
        Drag to Move<span style="app-region: no-drag" formium-command="close"
          >Click to Close</span
        >
      </h1>
    </div>
  </body>
</html>
```

In the above code, the `formium-command` attribute value of the `span` element is `close`. After running the program, you can click the `span` element to close the form. The value of the `formium-command` attribute can be the following:

| value      | description      |
| ---------- | ---------------- |
| close      | Close the form   |
| minimize   | Minimize form    |
| maximize   | Maximize form    |
| restore    | restore form     |
| fullscreen | full screen form |

### Using JavaScript API

In addition to using the built-in commands, you can also use the JavaScript API to implement the functionality of the forms system commands. WinFormium provides a `formium.hostWindow` class in the front-end environment, which provides a series of methods to implement the functions of form system commands, such as:

```js
formium.hostWindow.close();
```

You can call these methods using any JavaScript call, for example:

```html
<html>
  <head>
    <title>Drag to Move</title>
  </head>
  <body>
    <div>
      <h1 style="app-region: drag">
        Drag to Move<span style="app-region: no-drag" onclick="clicked()"
          >Click to Close</span
        >
      </h1>
    </div>
    <script>
      function clicked() {
        const hostWindow = window.formium?.hostWindow;
        if (hostWindow) {
          hostWindow.close();
        } else {
          alert("This is not running in WinFormium");
        }
      }
    </script>
  </body>
</html>
```

It should be noted that the `formium.hostWindow` class only exists in the WinFormium environment. If your web page is not running in the WinFormium environment, the `formium.hostWindow` class will not exist, so you need to determine before calling these methods. Whether the `formium.hostWindow` class exists.

If you want to know more about the `formium.hostWindow` class, please see ["Forms JavaScript Guide"](./Forms JavaScript Guide.md).

## See also

- [Forms](./Overview.md)
- [Form Features](./Form-Features.md)
- [Form JavaScript Guide](./Form-JavaScript-Guide.md)
