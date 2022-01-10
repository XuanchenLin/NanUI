using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.JavaScript.WindowBinding;
using System.Net.NetworkInformation;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.WindowBinding;

class FormiumObjectWindowBinding : JavaScriptWindowBindingObject
{
    public override string Name { get; } = "WinFormiumWindowBindingObject";
    public override string JavaScriptCode { get; } = Properties.Resources.FormiumWindowBinding;

    public FormiumObjectWindowBinding()
    {
        // WinFormium Object functions
        RegisterHandler(GetCurrentCulture);

        // Network Object functions
        RegisterHandler(GetNetworkAvailableStatus);

        // Version Object functions
        RegisterHandler(GetWinFormiumVersion);
        RegisterHandler(GetChromiumVersion);

        // HostWindow Object functions
        // - methods
        RegisterHandler(Minimize);
        RegisterHandler(Maximize);
        RegisterHandler(Restore);
        RegisterHandler(Close);
        RegisterHandler(FullScreen);
        RegisterHandler(MoveTo);
        RegisterHandler(MoveBy);
        RegisterHandler(SizeTo);
        RegisterHandler(SizeBy);
        RegisterHandler(Active);
        RegisterHandler(Center);

        // - properties
        RegisterHandler(GetWindowState);
        RegisterHandler(GetWindowLocation);
        RegisterHandler(GetWindowSize);
        RegisterHandler(GetWindowRectangle);

        // SplashScreen Object functions
        RegisterHandler(ShowSplashScreen);
        RegisterHandler(HideSplashScreen);

        // Borderless Window settings
        RegisterHandler(GetCornerStyle);
        RegisterHandler(SetCornerStyle);
        RegisterHandler(GetShadowEffect);
        RegisterHandler(SetShadowEffect);
        RegisterHandler(GetShadowColor);
        RegisterHandler(SetShadowColor);
        RegisterHandler(GetInactiveShadowColor);
        RegisterHandler(SetInactiveShadowColor);

        RegisterHandler(SendDataMessage);
    }

    #region WinFormium
    private JavaScriptValue GetCurrentCulture(JavaScriptArray _)
    {
        var retval = new JavaScriptObject();

        retval.Add("name", $"{Thread.CurrentThread.CurrentCulture.Name}");

        var array = new JavaScriptArray()
            {
                $"{Thread.CurrentThread.CurrentCulture.DisplayName}",
                $"{Thread.CurrentThread.CurrentCulture.EnglishName}",
            };


        retval.Add("cultureName", array);
        retval.Add("lcid", Thread.CurrentThread.CurrentCulture.LCID);

        return retval;
    }

    #endregion

    #region Network
    private JavaScriptValue GetNetworkAvailableStatus(JavaScriptArray _)
    {
        return new JavaScriptValue(NetworkInterface.GetIsNetworkAvailable());
    }
    #endregion

    #region Version
    private JavaScriptValue GetWinFormiumVersion(JavaScriptArray _)
    {
        return new JavaScriptValue($"{Assembly.GetExecutingAssembly().GetName().Version}");
    }

    private JavaScriptValue GetChromiumVersion(JavaScriptArray _)
    {
        return new JavaScriptValue($"{CefRuntime.ChromeVersion}");
    }
    #endregion

    #region HostWindow

    private JavaScriptValue Minimize(Formium owner, JavaScriptArray _)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk || !owner.Minimizable)
            return null;

        owner.InvokeIfRequired(() => owner.WindowState = FormWindowState.Minimized);

        return null;
    }

    private JavaScriptValue Maximize(Formium owner, JavaScriptArray _)
    {

        if (owner.WindowType == HostWindow.HostWindowType.Kiosk || !owner.Maximizable)
            return null;

        if (owner.WindowState != FormWindowState.Maximized)
        {
            owner.InvokeIfRequired(() => owner.WindowState = FormWindowState.Maximized);
        }
        else if (owner.WindowState == FormWindowState.Maximized)
        {
            if (owner.FullScreen)
            {
                owner.InvokeIfRequired(() => owner.FullScreen = !owner.FullScreen);
            }
            else
            {
                owner.InvokeIfRequired(() => owner.WindowState = FormWindowState.Normal);
            }
        }

        return null;
    }

    private JavaScriptValue Restore(Formium owner, JavaScriptArray _)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
            return null;

        if (owner.WindowState != FormWindowState.Normal)
        {
            if (owner.FullScreen)
            {
                owner.InvokeIfRequired(() => owner.FullScreen = false);
            }

            owner.InvokeIfRequired(() => owner.WindowState = FormWindowState.Normal);
        }

        return null;
    }

    private JavaScriptValue Close(Formium owner, JavaScriptArray _)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
        {
            return null;
        }

        owner.InvokeIfRequired(() =>
        {
            owner.Close();
        });
        return null;
    }

    private JavaScriptValue FullScreen(Formium owner, JavaScriptArray _)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
            return null;

        if (owner.AllowFullScreen)
        {
            owner.InvokeIfRequired(() => owner.FullScreen = !owner.FullScreen);
        }
        return null;
    }

    private JavaScriptValue MoveTo(Formium owner, JavaScriptArray arguments)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk || owner.WindowState
            != System.Windows.Forms.FormWindowState.Normal)
            return null;

        var x = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var y = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeIfRequired(() =>
        {
            owner.Left = x;
            owner.Top = y;
        });

        return null;
    }

    private JavaScriptValue MoveBy(Formium owner, JavaScriptArray arguments)
    {
        if (owner.WindowType == HostWindow.HostWindowType.Kiosk || owner.WindowState
            != System.Windows.Forms.FormWindowState.Normal)
            return null;

        var x = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var y = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeIfRequired(() =>
        {
            owner.Left += x;
            owner.Top += y;
        });

        return null;
    }

    private JavaScriptValue SizeTo(Formium owner, JavaScriptArray arguments)
    {
        if (!owner.Sizable || owner.WindowState
            != System.Windows.Forms.FormWindowState.Normal)
            return null;

        var width = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var height = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeIfRequired(() =>
        {


            if (width > 0 && height > 0)
            {
                owner.Size = new Size(width, height);
            }
            else if (width <= 0)
            {
                owner.Size = new Size(owner.Width, height);

            }
            else if (height <= 0)
            {
                owner.Size = new Size(width, owner.Height);
            }
        });

        return null;
    }

    private JavaScriptValue SizeBy(Formium owner, JavaScriptArray arguments)
    {
        if (!owner.Sizable || owner.WindowState
            != System.Windows.Forms.FormWindowState.Normal)
            return null;

        var width = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var height = arguments.Count == 2 ? arguments[1].GetInt() : 0;



        owner.InvokeIfRequired(() =>
        {

            width = owner.Width + width;
            height = owner.Height + height;

            if (width > 0 && height > 0)
            {
                owner.Size = new Size(width, height);
            }
            else if (width <= 0)
            {
                owner.Size = new Size(owner.Width, height);

            }
            else if (height <= 0)
            {
                owner.Size = new Size(width, owner.Height);
            }
        });

        return null;
    }

    private JavaScriptValue Active(Formium owner, JavaScriptArray _)
    {
        owner.InvokeIfRequired(() =>
        {
            owner.Active();
        });

        return null;
    }

    private JavaScriptValue Center(Formium owner, JavaScriptArray _)
    {

        if (owner.WindowType == HostWindow.HostWindowType.Kiosk || owner.WindowState
!= FormWindowState.Normal)
            return null;

        owner.InvokeIfRequired(() =>
        {
            var scr = Screen.FromHandle(owner.HostWindowHandle);

            if (scr != null)
            {
                owner.Location = new Point(scr.WorkingArea.Left + (scr.WorkingArea.Width - owner.Width) / 2, scr.WorkingArea.Top + (scr.WorkingArea.Height - owner.Height) / 2);
            }
        });

        return null;
    }

    private JavaScriptValue GetWindowState(Formium owner, JavaScriptArray _)
    {
        return new JavaScriptValue($"{owner?.WindowState.ToString().ToLower() ?? "normal"}");
    }

    private JavaScriptValue GetWindowLocation(Formium owner, JavaScriptArray _)
    {
        var obj = new JavaScriptObject();

        obj.Add("x", owner?.Location.X ?? 0);
        obj.Add("y", owner?.Location.Y ?? 0);

        return obj;
    }

    private JavaScriptValue GetWindowSize(Formium owner, JavaScriptArray _)
    {
        var obj = new JavaScriptObject();

        obj.Add("width", owner?.Size.Width ?? 0);
        obj.Add("height", owner?.Size.Height ?? 0);

        return obj;
    }

    private JavaScriptValue GetWindowRectangle(Formium owner, JavaScriptArray _)
    {
        var obj = new JavaScriptObject();

        obj.Add("left", owner?.Location.X ?? 0);
        obj.Add("top", owner?.Location.Y ?? 0);
        obj.Add("right", (owner?.Location.X ?? 0) + (owner?.Size.Width ?? 0));
        obj.Add("bottom", (owner?.Location.Y ?? 0) + (owner?.Size.Height ?? 0));
        obj.Add("width", owner?.Size.Width ?? 0);
        obj.Add("height", owner?.Size.Height ?? 0);

        return obj;
    }
    #endregion

    #region SplashScreen
    private JavaScriptValue ShowSplashScreen(Formium owner, JavaScriptArray _)
    {
        owner.InvokeIfRequired(() =>
        {
            owner.SplashScreen.ShowPanel();
        });

        return null;
    }

    private JavaScriptValue HideSplashScreen(Formium owner, JavaScriptArray _)
    {
        owner.InvokeIfRequired(() =>
        {
            owner.SplashScreen.HidePanel();
        });

        return null;
    }
    #endregion

    #region BorderlessWindow
    private JavaScriptValue GetCornerStyle(Formium owner, JavaScriptArray _)
    {
        if(owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            return new JavaScriptValue($"{target.CornerStyle}");
        }

        return null;
    }

    private JavaScriptValue SetCornerStyle(Formium owner, JavaScriptArray args)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            var isStringParam = args.FirstOrDefault()?.IsString ?? false;

            if (isStringParam)
            {
                string param = args.First();

                target.InvokeIfRequired(() =>
                {
                    if(Enum.TryParse<HostWindow.CornerStyle>(param, true, out var result))
                    {
                        target.CornerStyle = result;
                    }
                });

            }
        }
        return null;
    }

    private JavaScriptValue GetShadowEffect(Formium owner, JavaScriptArray _)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            return new JavaScriptValue($"{target.ShadowEffect}");
        }

        return null;
    }

    private JavaScriptValue SetShadowEffect(Formium owner, JavaScriptArray args)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            var isStringParam = args.FirstOrDefault()?.IsString ?? false;

            if (isStringParam)
            {
                string param = args.First();

                target.InvokeIfRequired(() =>
                {
                    if (Enum.TryParse<HostWindow.ShadowEffect>(param, true, out var result))
                    {
                        target.ShadowEffect = result;
                    }
                });

            }
        }
        return null;
    }

    private JavaScriptValue GetShadowColor(Formium owner, JavaScriptArray _)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            return new JavaScriptValue(ColorTranslator.ToHtml(target.ShadowColor));
        }

        return null;
    }

    private JavaScriptValue SetShadowColor(Formium owner, JavaScriptArray args)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            var isStringParam = args.FirstOrDefault()?.IsString ?? false;

            if (isStringParam)
            {
                string param = args.First();

                target.InvokeIfRequired(() =>
                {
                    try
                    {
                        var color = ColorTranslator.FromHtml(param);
                        target.ShadowColor = color;
                    }
                    catch
                    {

                    }

                });

            }
        }
        return null;
    }

    private JavaScriptValue GetInactiveShadowColor(Formium owner, JavaScriptArray _)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            if (target.InactiveShadowColor.HasValue)
            {
                return new JavaScriptValue(ColorTranslator.ToHtml(target.InactiveShadowColor.Value));
            }
            else
            {
                return new JavaScriptValue();
            }
        }

        return null;
    }

    private JavaScriptValue SetInactiveShadowColor(Formium owner, JavaScriptArray args)
    {
        if (owner.FormHostWindow is HostWindow.BorderlessWindow)
        {
            var target = (HostWindow.BorderlessWindow)owner.FormHostWindow;
            var isStringParam = args.FirstOrDefault()?.IsString ?? false;
            var isNullParam =  args.FirstOrDefault()?.IsNull ?? false;
            if (isStringParam)
            {
                string param = args.First();

                target.InvokeIfRequired(() =>
                {
                    try
                    {
                        var color = ColorTranslator.FromHtml(param);
                        target.InactiveShadowColor = color;
                    }
                    catch
                    {

                    }

                });
            }
            else if (isNullParam)
            {
                target.InvokeIfRequired(() =>
                {
                    target.InactiveShadowColor = null;
                });
            }
        }
        return null;
    }
    #endregion

    #region DataMessage
    private JavaScriptValue SendDataMessage(Formium owner, JavaScriptArray args)
    {
        if (args.Count < 1 || !args[0].IsString)
        {
            return null;
        }

        string messageName = args[0];
        string json = null;

        if (args.Count >= 2 && args[1].IsString)
        {
            json = args[1];
        }


        owner.InvokeIfRequired(() =>
        {
            owner.OnDataMessageReceived(messageName, json);
        });

        return null;
    }
    #endregion

}
