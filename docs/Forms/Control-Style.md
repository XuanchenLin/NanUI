# Control Style

## Overview

Control style is a special form style added in this version. This style is a technology that allows WinFormium forms to be embedded as controls in WinForm container controls. Using control styles allows you to use WinFormium in local controls of a WinForm form, thereby achieving a richer user interaction interface.

Use the extension method `UseAsEmbedded` of the `WindowStyleBuilder` class to enable the control style of the WinFormium form. This method accepts a `Control` type parameter, which needs to be obtained from the `ContainerControl` property of the `WindowStyleBuilder` parameter.

The `Formium` subclass that enables control styles also needs to pass in a `Control` type parameter in its constructor, which will serve as the container control of the WinFormium form.

```csharp
protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
{
     var style = builder.UseAsEmbedded(builder.ContainerControl);
     return style
}
```

## Example

The following example details how to use a WinFormium form to create a control that can be used in a WinForm form.

First, you still need to create a class `MyEmbeddedFormium` that inherits `Formium`:

```csharp
class MyEmbeddedFormium : Formium
{
     public MyEmbeddedFormium(Control containerControl)
       : base(containerControl)
     {
     }

     protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
     {
         var style = builder.UseAsEmbedded(builder.ContainerControl);
         return style
     }
}
```

After you create the `MyEmbeddedFormium` class you can use it directly in your WinForm form's code, or you can create a container control for it. If you need to reference the control in multiple places, it is recommended that you create a container control to avoid duplication of initialization code.

The following will introduce how to use the `MyEmbeddedFormium` class in the code of a WinForm form and how to create a container control for it.

**Use MyEmbeddedFormium class directly**

You can create an instance of the MyEmbeddedFormium class in any WinForm form constructor and add it to any container control on the form (or the form itself).

The following example assumes that you have created a WinForm form `Form1` and added a container control `panel1` for embedding the WinFormium form to it. You can create a `MyEmbeddedFormium` class in the constructor of the form instance and add it to the `panel1` container control.

```csharp
class Form1 : Form
{
     MyEmbeddedFormium embeddedFormium;
     public Form1()
     {
         InitializeComponent();

         embeddedFormium = new MyEmbeddedFormium(panel1);

     }
}
```

**Create container control**

You can also create a container control for the `MyEmbeddedFormium` class to avoid duplication of initialization code. The created container control will also be automatically added to Visual Studio's control toolbox, and you can drag and drop the control directly into the form in the designer.

But please use the `DesignMode` property to avoid initializing the CEF runtime environment in the designer, which is not supported.

In the following example, continue to use the above `MyEmbeddedFormium` class, and create a new `MyFormiumBrowserControl` control based on this class, which inherits from the `Control` class.

```csharp
public class MyFormiumBrowserControl : Control
{
     MyEmbeddedFormium embeddedFormium;

     public MyEmbeddedFormium EmbeddedFormium
     {
         get { return embeddedFormium; }
     }

     public MyFormiumBrowserControl()
     {
         if (!DesignMode)
         {
             embeddedFormium = new MyEmbeddedFormium(this);
         }
     }
}
```

## See also

- [Forms](./overview.md)
- [Form Features](./Form-Features.md)
