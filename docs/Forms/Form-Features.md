# Form Features

## Overview

This article mainly introduces how to use WinFormium's form `Formium` class and its form-related contents. The browser-related content in the `Formium` class will be introduced in [Browser Features](./Browser-Features.md).

## Create form

You can inherit from the `Formium` class to create and set form properties.

```csharp
using WinFormium;

class MyWindow : Formium
{
     publicMyWindow()
     {
         Url = "https://www.bing.com/"
     }
}
```

Using the above code you can create a simple form. Specifying the value of the `Url` property of the `Formium` class can specify the page that the form loads by default. This property accepts a `string` type parameter, and you can specify a web page address here. Just like the sample code above, it will load the `https://www.bing.com/` web page after the form is displayed.

## Set form style

Formium forms have a variety of built-in form styles. You can overload the `ConfigureWindowStyle` method of the `Formium` class to set the form style. The `ConfigureWindowStyle` method accepts a parameter `WindowStyleBuilder` with which you can set the style of the form.

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
     var style = builder.UseSystemForm();
     return style
}
```

The above code example uses the system form style, which is also the default Formium form style. If your application has no special requirements for window styles, then there is no need to overload the `ConfigureWindowStyle` method.

The `WindowStyleBuilder` object provides multiple `UseXXX` methods to set different form styles. These methods return a `FormStyle` subclass. In addition to the style settings provided in the base class `FormStyle`, different form styles also Provides properties specific to this style. You can set properties of the `FormStyle` class to set the base style of a form, and use its subclasses to set unique style properties.

The following properties are provided in the `FormStyle` object:

| Properties      | Description                                                                                                                                                                          | Type              | Default Value                      |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ----------------- | ---------------------------------- |
| AllowFullScreen | Whether to allow full screen                                                                                                                                                         | bool              | true                               |
| AllowSystemMenu | Whether to allow system menu                                                                                                                                                         | bool              | true                               |
| ColorMode       | Form color mode, property value:<br />`SystemPreference` - Follow the system (Windows 11)<br />`Light` - Light mode<br />`Dark` - Dark mode                                          | FormiumColorMode  | FormiumColorMode. SystemPreference |
| DefaultAppTitle | Default form title                                                                                                                                                                   | string            | WinFormium                         |
| Icon            | Form Icon                                                                                                                                                                            | Icon              | DefaultIcon                        |
| Location        | Form location                                                                                                                                                                        | Point             | Point.Empty                        |
| Maximizable     | Whether to allow maximization                                                                                                                                                        | bool              | true                               |
| MaximiumSize    | The maximum size of the form                                                                                                                                                         | Size              | Size.Empty                         |
| Minimizable     | Whether to allow minimization                                                                                                                                                        | bool              | true                               |
| MinimiumSize    | The minimum size of the form                                                                                                                                                         | Size              | Size.Empty                         |
| ShowInTaskbar   | Whether to display in the taskbar                                                                                                                                                    | bool              | true                               |
| Sizable         | Whether to allow resizing of the form                                                                                                                                                | bool              | true                               |
| Size            | Form size                                                                                                                                                                            | Size              | Size.Empty                         |
| StartCentered   | Whether and how the form is centered, property value:<br />`None` - not centered<br />`CenterScreen` - in the center of the screen<br />`CenterParent` - in the parent form Centered | StartCenteredMode | StartCenteredMode.None             |
| TopMost         | Whether the form is displayed on top                                                                                                                                                 | bool              | false                              |
| UsePageTitle    | Whether to use the web page title as the form title                                                                                                                                  | bool              | false                              |
| WindowState     | Form state, property value:<br />`Normal` - normal<br />`Maximized` - maximized<br />`Minimized` - minimized<br />`FullScreen` - full screen                                         | FormWindowState   | FormWindowState.Normal             |

Currently, WinFormium forms have the following built-in form styles. If you need to know about these form styles, please refer to the following articles:

- [System Style Forms](./System-Style-Forms.md)
- [KIOSK Style Forms](./Kiosk-Style-Forms.md)
- [Borderless Style Forms](./Borderless-Style-Forms.md)
- [Transparency Style Forms](./Transparency-Style-Forms.md)
- [Control Style](./Control-Style.md)

The form style set using the `FormStyle` object is read-only. These settings will take effect when the form is created. After the form creation is completed, you will not be able to modify the form style through `FormStyle` again. The `Formium` class itself provides some properties that you can use to modify the form style after the form is created.

## Show form

When you have finished setting up your Formium form, you can use the `Show` method of the `Formium` class to display the form, or use the `ShowDialog` method to display the form modally.

If you need to use the current Formium form as the main form of the project, please refer to [Startup Configuration - Configure the main form of the application"](../Configuration/Startup.md#configure-the-main-form-of-the-application).

## Hide form

You can use the `Hide()` method to hide the current form. After hiding the form, you can use the `Show()` method to redisplay the form. However, in order to ensure that the form can be hidden and displayed normally, it is strongly recommended that you set the property value of the `Visible` property of `Formium` to hide and display the form.

## Close the form

You can use the `Close()` method to close the current form. After closing the form, the form object will be destroyed and you will not be able to display the form again. If you need to display the form here, you need to create a new form object.

## Activate the form

You can use the `Activate()` method to activate the current form. After activating the form, the form will be brought to the front and the form title bar will be displayed as activated.

## Set form focus

You can use the `Focus()` method to set the focus of the current form. After setting the focus, the form will become the focused form. If the form is a child form, its parent form will lose focus.

## Center the form

You can center the form using the `CenterToScreen()` method, which will center the form on the screen. If your form is a child form, you can use the `CenterToParent()` method to center the form on the parent form.

## Update interface elements in the UI thread

In the process of using WinFormium forms, you will find a large number of asynchronous methods. These asynchronous methods run in different threads from the UI thread. If you want to operate the form in these non-UI threads, then you need to use the `InvokeOnUIThread` method to update interface elements in the UI thread. There are multiple overloads of this method:

| Method                                                                    | Description                                                                          |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------------------ |
| void InvokeOnUIThread(System.Action action)                               | Execute a delegate in the UI thread                                                  |
| object InvokeOnUIThread(System.Delegate method, params object[] args)     | Execute a delegate with a parameter list and return value in the UI thread           |
| T InvokeOnUIThread&lt;T&gt;(System.Delegate method, params object[] args) | Execute a delegate with a parameter list and a generic return value in the UI thread |
| T InvokeOnUIThread&lt;T&gt;(System.Func&lt;T&gt; method)                  | Execute a delegate with a generic return value in the UI thread                      |

For example, to create and display a subform in the UI thread, you can use the following code:

```csharp
InvokeOnUIThread(() =>
{
     //Execute a delegate in the UI thread
     var form = new Form();
     form.Show(this);
});
```

Forms created using the `InvokeOnUIThread` method will be displayed in the UI thread, which can avoid exceptions caused by displaying the form in non-UI threads. Likewise, if you need to modify the form's properties at runtime, you also need to use the `InvokeOnUIThread` method to update the form properties.

## Parent form

You can use the `Owner` property to get the parent form of the current form. If the current form has no parent form, the value of this property is `null`. This property does not return an actual `Form` object, but an `IWin32Window` interface. You can obtain the handle of the parent form through the `Handle` property of this interface, or directly use this interface to connect to certain APIs of WinForm, such as the `MessageBox.Show` method.

## Window size and position

You can set the location of the current form using the `Location` property, which accepts a parameter of type `Point` where you can specify the location of the form. If you need to get the location of a form, you can use the `Location` property to get the location of the form. You can also use the `Top` and `Left` properties to set or get the position of the form on the current desktop. In addition, you can also use the `Right` and `Bottom` properties to get the position of the right and bottom borders of the form. .

You can set the size of the current form using the `Size` property, which accepts a parameter of type `Size` where you can specify the size of the form. If you need to get the size of the form, you can use the `Size` property to get the size of the form. You can also use the `Width` and `Height` properties to set or get the width and height of the form.

In addition, you can use the `Bounds` property to obtain an object of type `Rectangle`, and you can obtain the position and size of the form through the properties of the object.

You can also set the maximum and minimum size of the form using the `MaximiumSize` and `MinimiumSize` properties, which accept a parameter of type `Size` where you can specify the maximum and minimum size of the form.

## Form title

You can use the `AppTitle` property to set the title of the current form. This property accepts a `string` type parameter, where you can specify the title of the form. If you need to get the title of the form, you can get the title of the form through the `Title` property.

In addition, if the property value of the `UsePageTitle` property is `true`, then the title of the form will be spliced using the title of the current web page and the value of the `AppTitle` property. The default splicing method is `PageTitle - AppTitle`. You can change the `TitlePattern` property to set the splicing format of the title string. This property accepts a `string` type parameter, and you can specify the splicing format here.

## Form icon

You can use the `Icon` property to set the icon of the current form. This property accepts a parameter of type `Icon`, where you can specify the icon of the form. If you need to get the icon of the form, you can get the icon of the form through the `Icon` property.

## Form status

You can set the state of the current form using the `WindowState` property, which accepts a parameter of type `FormWindowState` where you can specify the state of the form. If you need to get the state of the form, you can get the state of the form through the `WindowState` property. The property values of the `FormWindowState` type are as follows:

| Property value | Description |
| -------------- | ----------- |
| Normal         | Normal      |
| Maximized      | Maximized   |
| Minimized      | Minimized   |
| FullScreen     | Full screen |

Additionally, you can specify the `AllowFullScreen` property to set whether to allow the form to go full screen. Use the `Minimizable` and `Maximizable` properties to set whether to allow the window to be minimized and maximized. Specify the `Sizable` property to set whether resizing of the form is allowed.

In addition to the above properties and methods, the form state also involves a lot of front-end content. Therefore, for details about the WinFormium form state, please refer to [Form JavaScript Guide] (./Form JavaScript Guide.md).

## Splash screen

You can use the `EnableSplashScreen` property to set whether to enable a form's splash screen. If you need to display a splash screen before the form is displayed, you can set the `EnableSplashScreen` property to `true` in the form constructor. The splash screen will be displayed before the form page is loaded. When the form is displayed, the splash screen will automatically close.

You can customize a form's splash screen by overriding the `PaintSplashScreen` method of the `Formium` class. This method accepts a parameter of type `Graphics` where you can draw your splash screen.

The splash screen is only applicable to forms that do not have CEF off-screen rendering turned on. Forms with CEF off-screen rendering turned on will not display the splash screen.

By default, the following splash screen will be displayed:

![Default splash screen](splash-screen-preview.png)

Overload the `PaintSplashScreen` method and delete the `base.PaintSplashScreen(e);` code to delete the default splash screen. Then use GDI+ code to customize the splash screen:

```csharp
protected override void PaintSplashScreen(PaintEventArgs e)
{
     e.Graphics.Clear(Color.Yellow);
     e.Graphics.DrawString("Loading...", SystemFonts.DefaultFont, Brushes.Black, 10, 10);
}
```

## API Reference

### Attributes

| Property name      | Description                                                                                                      | Type               | Default value                     |
| ------------------ | ---------------------------------------------------------------------------------------------------------------- | ------------------ | --------------------------------- |
| AllowDrop          | Gets or sets a value that indicates whether the control can accept data dragged and dropped onto it by the user. | bool               | false                             |
| AllowFullScreen    | Gets or sets a value indicating whether the form allows full screen.                                             | bool               | true                              |
| AllowSystemMenu    | Gets or sets a value indicating whether the form allows system menus.                                            | bool               | true                              |
| ApplicationContext | Gets or sets the application context.                                                                            | ApplicationContext | WinFormiumApp                     |
| AppTitle           | Gets or sets the title of the form.                                                                              | string             | WinFormium                        |
| Bottom             | Gets the position of the bottom border of the form.                                                              | int                | 0                                 |
| Bounds             | Get the position and size of the form.                                                                           | Rectangle          | Rectangle.Empty                   |
| ColorMode          | Gets or sets the color mode of the form.                                                                         | FormiumColorMode   | FormiumColorMode.SystemPreference |
| DisableAboutMenu   | Gets or sets a value indicating whether the form's About menu is disabled.                                       | bool               | false                             |
| Enabled            | Gets or sets a value that indicates whether the control can respond to user interaction.                         | bool               | true                              |
| EnableSplashScreen | Gets or sets a value that indicates whether to enable the form's splash screen.                                  | bool               | true                              |
| Handle             | Get the handle of the form.                                                                                      | IntPtr             | IntPtr.Zero                       |
| Height             | Gets or sets the height of the form.                                                                             | int                | 0                                 |
| Icon               | Gets or sets the icon of the form.                                                                               | Icon               | DefaultIcon                       |
| IsDisposed         | Gets a value indicating whether the form has been released.                                                      | bool               | false                             |
| IsFullscreen       | Gets a value indicating whether the form is in full screen state.                                                | bool               | false                             |
| Left               | Gets or sets the position of the left border of the form.                                                        | int                | 0                                 |
| Location           | Gets or sets the location of the form.                                                                           | Point              | Point.Empty                       |
| Maximizable        | Gets or sets a value indicating whether the form allows maximization.                                            | bool               | true                              |
| MaximiumSize       | Gets or sets the maximum size of the form.                                                                       | Size               | Size.Empty                        |
| Minimizable        | Gets or sets a value indicating whether the form allows minimization.                                            | bool               | true                              |
| MinimiumSize       | Gets or sets the minimum size of the form.                                                                       | Size               | Size.Empty                        |
| Modal              | Gets a value indicating whether the form is displayed modally.                                                   | bool               | false                             |
| Owner              | Gets the handle of the parent form of the current form.                                                          | IWin32Window       | null                              |
| Right              | Gets the position of the right border of the form.                                                               | int                | 0                                 |
| Services           | Gets the form's services container.                                                                              | IServiceProvider   | null                              |
| Sizable            | Gets or sets a value indicating whether the form allows resizing.                                                | bool               | true                              |
| Size               | Gets or sets the size of the form.                                                                               | Size               | Size.Empty                        |
| TitlePattern       | Gets or sets the splicing format of the form title.                                                              | string             | {0} - {1}                         |
| Top                | Gets or sets the position of the top border of the form.                                                         | int                | 0                                 |
| TopMost            | Gets or sets a value indicating whether the form is displayed on top.                                            | bool               | false                             |
| UsePageTitle       | Gets or sets a value that indicates whether the form uses the page title as the form title.                      | bool               | false                             |
| Visible            | Gets or sets a value indicating whether the form is visible.                                                     | bool               | true                              |
| Width              | Gets or sets the width of the form.                                                                              | int                | 0                                 |
| WindowState        | Gets or sets the state of the form.                                                                              | FormWindowState    | FormWindowState.Normal            |

### Methods

| Method name                                                             | Description                                                                           | Return value |
| ----------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------ |
| Activate()                                                              | Activate the form.                                                                    | void         |
| CenterToParent()                                                        | Center the form on the parent form.                                                   | void         |
| CenterToScreen()                                                        | Center the form on the screen.                                                        | void         |
| Close()                                                                 | Close the form.                                                                       | void         |
| ConfigureWindowStyle(WindowStyleBuilder builder)                        | Configure the form style.                                                             | FormStyle    |
| Dispose()                                                               | Disposes the form.                                                                    | void         |
| Focus()                                                                 | Sets the form focus.                                                                  | void         |
| Hide()                                                                  | Hide the form.                                                                        | void         |
| InvokeOnUIThread(System.Action action)                                  | Execute a delegate in the UI thread.                                                  | void         |
| InvokeOnUIThread(System.Delegate method, params object[] args)          | Execute a delegate with a parameter list and return value in the UI thread.           | object       |
| InvokeOnUIThread&lt;T&gt;(System.Delegate method, params object[] args) | Execute a delegate with a parameter list and a generic return value in the UI thread. | T            |
| InvokeOnUIThread&lt;T&gt;(System.Func&lt;T&gt; method)                  | Execute a delegate with a generic return value in the UI thread.                      | T            |
| Show()                                                                  | Display the form.                                                                     | void         |
| Show(System.IntPtr)                                                     | Display the form with the specified handle as the parent form.                        | void         |
| Show(System.Windows.Forms.IWin32Window)                                 | Display the form with the specified handle as the parent form.                        | void         |
| Show(WinFormium.Formium)                                                | Display the form with the specified handle as the parent form.                        | void         |
| ShowAboutDialog()                                                       | Displays the form's About dialog box.                                                 | void         |
| ShowDialog()                                                            | Display the form modally and return DialogResult                                      | DialogResult |
| ShowDialog(System.IntPtr)                                               | Display the form modally and use the specified handle as the parent form.             | DialogResult |
| ShowDialog(System.Windows.Forms.IWin32Window)                           | Display the form modally and use the specified handle as the parent form.             | DialogResult |
| ShowDialog(WinFormium.Formium)                                          | Display the form modally and use the specified handle as the parent form.             | DialogResult |

### Events

| Event name         | Description                                | Parameters                            |
| ------------------ | ------------------------------------------ | ------------------------------------- |
| Activated          | Occurs when the form is activated.         | System.EventArgs                      |
| Closing            | Occurs when the form is closed.            | System.ComponentModel.CancelEventArgs |
| Closed             | Occurs when the form is closed.            | System.EventArgs                      |
| Deactive           | Occurs when a form loses focus.            | System.EventArgs                      |
| GotFocus           | Occurs when a form gains focus.            | System.EventArgs                      |
| Loaded             | Occurs when the form has finished loading. | System.EventArgs                      |
| Move               | Occurs when the form moves.                | System.EventArgs                      |
| Resize             | Occurs when the form size changes.         | System.EventArgs                      |
| ResizeBegin        | Occurs when the form begins to resize.     | System.EventArgs                      |
| ResizeEnd          | Occurs when the form ends resizing.        | System.EventArgs                      |
| Shown              | Occurs when the form is shown.             | System.EventArgs                      |
| VisibleChanged     | Occurs when the form's visibility changes. | System.EventArgs                      |
| WindowStateChanged | Occurs when the form state changes.        | System.EventArgs                      |

## See also

- [Forms](./overview.md)
- [Browser Features](./Browser-Features.md)
- [Form JavaScript Guide](./Form-JavaScript-Guide.md)
