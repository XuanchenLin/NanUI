# Formium related members

[[Home](README.md)]

- [Formium related members](#formium-related-members)
  - [Attributes](#attributes)
  - [Method](#method)

## Attributes

**AllowFullScreen {get; set; }** `bool`

Whether to allow the current window to be able to perform full-screen operations. The default value is `false`. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**AllowSystemMenu {get; set; }** `bool`

Whether to display the system menu when the user right-clicks on the draggable area. This setting is invalid when `WindowType` is `Kiosk`.

**AutoShowMask {get; set; }** `bool`

When the form starts and waits for the page to load, whether to automatically display the waiting page.

**CanMaximize {get; set; }** `bool`

Set or get whether the current form can use the "maximize" command. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**CanMinimize {get; set; }** `bool`

Set or get whether the current form can use the "minimize" command. This setting is invalid when `WindowType` is `Kiosk`.

**ClientSize {get; }** `System.Drawing.Size`

Get the size of the user area of ​​the current form.

**Height {get; set; }** `int`

Set or get the height of the current form.

**Icon {get; set; }** `System.Drawing.Icon`

Set or get the icon of the current form.

**IsFullScreen {get; }** `bool`

Indicates whether the current window is in full screen state. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**Left {get; set; }** `int`

Set or get the abscissa of the screen where the form is currently located.

**Location {get; set; }** `System.Drawing.Point`

Set or get the current screen position of the form.

**Mask {get; }** `ViewMask`

Get an instance of the mask layer of the current form.

**MaximumSize {get; set; }** `System.Drawing.Size`

Set or get the maximum size that the current window can reach. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**MinimumSize {get; set; }** `System.Drawing.Size`

Set or get the minimum size that the current window can reach. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**Resizable {get; set; }** `bool`

Specify whether the current window can be resized. This setting is invalid when `WindowType` is `Kiosk` or `Layered`.

**ShowInTaskbar {get; set; }** `bool`

Set or get whether the current window is displayed in the taskbar. This setting is invalid when `WindowType` is `Kiosk`.

**Size {get; set; }** `Size`

Set or get the size of the current window.

**StartPosition {get; set; }** `System.Windows.Forms.FormStartPosition`

Set or get the start position of the window. This setting is invalid when `WindowType` is `Kiosk`.

**Subtitle {get; set; }** `string`

Set or get the subtitle of the current window.

**Title {get; set; }** `string`

Set or get the main title of the current window. When the subtitle is empty, the window displays the main title; when the subtitle is composed of content, it will display "[Subtitle]-[Main Title]". If you need to modify the display style, you can specify it by overloading the `GetWindowTitle` method.

**Top {get; set; }** `int`

Set or get the ordinate of the current window.

**TopMost {get; set; }** `bool`

Set or get whether the current window is the top-level window.

**Width {get; set; }** `int`

Set or get the width of the current window.

**WindowState {get; set; }** `System.Windows.Forms.FormWindowState`

Set or get the status of the current window. This setting is invalid when `WindowType` is `Kiosk`.

## Method

**public void Close(bool force)**

Close the current window.

parameter

- _force:`bool`_: `true` is forcibly closed. The default is `false`.

**protected void CloseMask()**

Turn off the mask layer displayed in the current window.

**public void FullScreen(bool toggle)**

Set the maximized state of the window.

parameter

- _toggle:`bool`_: true to set full screen; false to cancel full screen.

**public void Hide()**

Hide the current window.

**public void Show(Formium owner|.IWin32Window owner|void)**

Display the current form. You can specify the `owner` parameter for this method to set its parent form. When the `owner` parameter is not specified, the secondary window has no parent window.

parameter

- _owner:`Formium`|owner:`IWin32Window`|void_: You can specify the parent form of Formium and IWin32Window type. When this parameter is omitted, the window has no parent window.

**public void ShowDialog(Formium owner|.IWin32Window owner|void)**

Open the current window modally. You can specify the `owner` parameter for this method to set its parent form. When the `owner` parameter is not specified, the secondary window has no parent window.

parameter

- _owner:`Formium`|owner:`IWin32Window`|void_: You can specify the parent form of Formium and IWin32Window type. When this parameter is omitted, the window has no parent window.

**public void ShowDevTools()**

Open the browser's debugging tools (DevTools).

**protected void ShowMask()**

The mask layer is displayed in the current frame.
