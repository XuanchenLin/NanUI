# Use Kiosk Style Form

[[Home](README.md)]

Specify the property value `Kiosk` for the `WindowType` of the Formium form to set the form style to Kiosk style. Kiosk can be simply understood as the **full screen possession** mode. Kiosk mode is to remove the user-operable interface and only give the user a service-related interface.

After setting the window to Kiosk mode, the window will be opened in full-screen exclusive mode. Therefore, you cannot set the size, start position and other properties of the window in Kiosk mode; you cannot perform operations such as maximizing, minimizing, and restoring; and users cannot close the window.

In the development process, you also need to pay attention to avoid opening new windows as much as possible.

In actual project events, this mode is generally used for industrial control host computer interface, query machine interface, large data screen, etc.

```C#
public override HostWindowType WindowType => HostWindowType.Kiosk;
```

Kiosk styles do not have special style property settings, so there is no content in the `KioskWindowProperties` property value. This property is only reserved for future expansion needs.
