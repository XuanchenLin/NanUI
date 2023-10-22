#WinFormium form

## Introduction

The core of the WinFormium form is the `Formium` class. Its principle is to embed the Chromium kernel in the WinForm form to display web pages in the WinForm form. WinFormium forms retain most of the features of Windows Forms and try to remain consistent with Windows Forms in terms of programming methods. Therefore, if you are familiar with Windows Forms, you will be able to get started with WinFormium forms quickly.

WinFormium forms have a variety of built-in styles to choose from. You can choose the appropriate form style according to your needs. Combined with the powerful front-end rendering function of the Chromium browser, you can easily implement a variety of rich user interaction interfaces.

Since the `Formium` class does not inherit from `System.Windows.Forms.Form`, it is not a control. Internally, it maintains its own Form components and CEF components. Normally you cannot access these components directly, but you can achieve the above purpose through the methods and properties provided by the `Formium` class.

In this chapter, the form part and browser part of the `Formium` class will be introduced separately, which can better help you understand the working principle of the WinFormium form.

## Form function

As mentioned in the introduction, the `Formium` class does not inherit from `System.Windows.Forms.Form`, so it is not a control, nor is it a form in the traditional sense. However, it provides a series of properties and methods to operate the form objects maintained internally. These properties and methods are similar to those of the `System.Windows.Forms.Form` class, but not exactly the same.

For more information about the form part of the `Formium` class, please refer to ["Form Function"](./Form Function.md).

## Browser functions

The browser part of the `Formium` class is the core of the WinFormium form, which encapsulates the complete Chromium browser. However, as a user interface framework, WinFormium does not fully implement all the interfaces of the Chromium browser, because the purpose of WinFormium is to allow you to use web pages in WinForm forms to design the user interface of your application. As for other functions, such as: Downloading, printing, plug-ins, request interception, etc., these functions are not the focus of WinFormium, so there are no relevant interfaces to implement these functions. If your application needs to use these unimplemented interfaces, please implement them yourself.

For more information about the browser part of the `Formium` class, please refer to ["Browser Functions"](./browser functions.md).

## See also

- [Documentation](../Home.md)
- [Form Features](./Form-Features.md)
- [Browser Features](./Browser-Features.md)
