# Kisok Style Forms

## Overview

Kisok form style is a special form style, which is also called kiosk form style. Its characteristic is that the title bar and borders of the form are hidden, and the size of the form is also limited to the visible area of the screen. Users cannot use the maximize button to maximize the form, nor can they drag the form. The border stretches the form off the screen.

Use the extension method `UseKisokForm` of `WindowStyleBuilder` to enable the Kisok form style. The return value of this method is the `KisokFormStyle` type, which inherits from the `FormStyle` class, so you can use the properties of the `FormStyle` class to set the window The basic style of the form, and use the properties of the `KisokFormStyle` class to set the style properties specific to the Kisok form style.

In general, you should not use certain properties of `FormStyle`, such as `Maximizable`, `Minimizable`, `Sizable`, `WindowState`, etc., because these properties defeat the original design intention of Kisok form style.

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
     var style = builder.UseKisokForm();
     return style
}
```

## DisableTaskBar property

The Kiosk form style has only one configurable property. The `DisableTaskBar` property is used to set whether to disable the taskbar. If the taskbar is disabled, the user will not be able to use the taskbar to switch to other applications.

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
     var style = builder.UseKisokForm();
     style.DisableTaskBar = true;
     return style
}
```

## See also

- [Forms](./overview.md)
- [Form Features](./Form-Features.md)
