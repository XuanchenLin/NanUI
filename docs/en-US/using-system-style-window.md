# Use Native Style Form

[[Home](README.md)]

Specify the property value `System` for the `WindowType` of the Formium form to set the form style to the native style.

```C#
public override HostWindowType WindowType => HostWindowType.System;
```

The native style does not have special style property settings, so there is no content in the `SystemWindowProperties` property value. This property is only reserved for future expansion needs.
