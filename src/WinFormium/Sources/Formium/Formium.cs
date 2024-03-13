// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium;

public abstract partial class Formium
{
    /// <summary>
    /// Gets the <see cref="ChromiumEnvironment"/> instance.
    /// </summary>
    public ChromiumEnvironment ChromiumEnviroment { get; }

    /// <summary>
    /// Gets the <see cref="WinFormiumApp"/> instance.
    /// </summary>
    public WinFormiumApp ApplicationContext { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the form can accept data that the user drags onto it.
    /// </summary>
    public bool AllowDrop { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether the form can be fullscreen.
    /// </summary>
    public bool AllowFullScreen { get => CurrentFormStyle.AllowFullScreen; set => CurrentFormStyle.AllowFullScreen = value; }


    public bool EnableSplashScreen { get; set; } = true;

    /// <summary>
    /// Gets or sets the size of the form.
    /// </summary>
    public Size Size
    {
        get => HostWindow?.Size ?? Size.Empty;
        set
        {
            if (HostWindow != null)
            {
                HostWindow.Size = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value that represents the upper-left corner of the form in screen coordinates.
    /// </summary>
    public Point Location
    {
        get => HostWindow?.Location ?? new Point(0, 0);
        set
        {
            if (HostWindow != null)
            {
                HostWindow.Location = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether which color mode will be used.
    /// </summary>
    /// <value>
    /// A FormiumColorMode that represents whether form will use system preference, light or dark color mode.
    /// </value>
    public FormiumColorMode ColorMode
    {
        get => CurrentFormStyle.ColorMode;

        set
        {
            CurrentFormStyle.ColorMode = value;
            SystemColorModeChangedCore();
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether form is minimized, maximized, fullscreen or normal.
    /// </summary>
    public FormiumWindowState WindowState
    {
        get
        {
            if (HostWindow == null) return FormiumWindowState.Normal;

            if (IsFullscreen) return FormiumWindowState.FullScreen;

            return (FormiumWindowState)HostWindow.WindowState;
        }
        set
        {
            if (value == WindowState) return;

            if (value == FormiumWindowState.FullScreen)
            {
                SetFullscreenState(true);
            }
            else
            {
                SetFullscreenState(false, (FormWindowState)value);
            }

        }
    }





    /// <summary>
    /// Gets or sets a value indicating whether the form should be displayed as a topmost form.
    /// </summary>
    public bool TopMost
    {
        get => HostWindow?.TopMost ?? false;
        set
        {
            if (HostWindow != null)
            {
                HostWindow.TopMost = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the form can be maximized.
    /// </summary>
    public bool Maximizable
    {
        get => HostWindow?.MaximizeBox ?? CurrentFormStyle.Maximizable;
        set
        {
            if (HostWindow != null)
            {
                HostWindow.MaximizeBox = value;
            }
        }
    }
    /// <summary>
    /// Gets or sets a value indicating whether the form can be minimized to the taskbar.
    /// </summary>
    public bool Minimizable
    {
        get => HostWindow?.MinimizeBox ?? CurrentFormStyle.Minimizable;
        set
        {
            if (HostWindow != null)
            {
                HostWindow.MinimizeBox = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the icon for the form.
    /// </summary>
    public Icon? Icon
    {
        get => HostWindow?.Icon ?? CurrentFormStyle.Icon;
        set
        {
            if (HostWindow != null)
            {
                HostWindow.Icon = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the form can be resized by the user.
    /// </summary>
    /// <value>
    /// true if the form can be resized by the user; otherwise, false. The default is true.
    /// </value>
    public bool Sizable
    {
        get => CurrentFormStyle.Sizable;
        set
        {
            CurrentFormStyle.Sizable = value;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the form will use the page title as the form title.
    /// </summary>
    public bool UsePageTitle { get; set; } = false;

    /// <summary>
    /// Gets or sets the title of the form.
    /// </summary>
    public string AppTitle
    {
        get => _appTitle ?? string.Empty;
        set
        {
            _appTitle = value;

            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Text = BuildTitleString());
            }
        }
    }

    /// <summary>
    /// Gets or sets the title of the page.
    /// </summary>
    internal string PageTitle { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title pattern of the form.
    /// </summary>
    public string TitlePattern { get; set; } = "{0} - {1}";

    /// <summary>
    /// Gets or sets the distance, in pixels, between the left edge of the form and the left edge of the working area of the screen.
    /// </summary>
    public int Left
    {
        get => HostWindow?.Left ?? 0;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Left = value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the distance, in pixels, between the top edge of the form and the top edge of the working area of the screen.
    /// </summary>
    public int Top
    {
        get => HostWindow?.Top ?? 0;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Top = value);
            }
        }
    }

    /// <summary>
    /// Gets the distance, in pixels, between the right edge of the form and the right edge of the working area of the screen.
    /// </summary>
    public int Right { get => HostWindow?.Right ?? 0; }

    /// <summary>
    /// Gets the distance, in pixels, between the bottom edge of the form and the bottom edge of the working area of the screen.
    /// </summary>
    public int Bottom { get => HostWindow?.Bottom ?? 0; }

    /// <summary>
    /// Gets or sets the width of the form.
    /// </summary>
    public int Width
    {
        get => HostWindow!.Width;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Width = value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the height of the form.
    /// </summary>
    public int Height
    {
        get => HostWindow!.Height;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Height = value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the size that is the upper limit of the form can specify.
    /// </summary>
    public Size MaximumSize
    {
        get => HostWindow?.MaximumSize ?? Size.Empty;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.MaximumSize = value);
            }
        }
    }

    /// <summary>
    /// Gets or sets the size that is the lower limit of the form can specify.
    /// </summary>
    public Size MinimumSize
    {
        get => HostWindow?.MinimumSize ?? Size.Empty;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.MinimumSize = value);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether this form is displayed modally.
    /// </summary>
    public bool Modal => HostWindow?.Modal ?? false;

    /// <summary>
    /// Gets or sets a value indicating whether the form is displayed.
    /// </summary>
    public bool Visible
    {
        get => HostWindow?.Visible ?? false;
        set
        {
            if (HostWindow != null)
            {
                InvokeOnUIThread(() => HostWindow.Visible = value);
            }
        }
    }

    /// <summary>
    /// Gets the size and location of the form, in pixels, relative to the screen.
    /// </summary>
    public Rectangle Bounds => new Rectangle(Left, Top, Width, Height);

    /// <summary>
    /// Gets the window handle that the form is bound to.
    /// </summary>
    public IntPtr Handle => WindowHandle;

    /// <summary>
    /// Gets the form's owner.
    /// </summary>
    public IWin32Window? Owner => HostWindow?.Owner;

    /// <summary>
    /// Gets the value that indicates whether the form is fullscreen or not.
    /// </summary>
    public bool IsFullscreen { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the form can respond to user interaction.
    /// </summary>
    public bool Enabled
    {
        get => _enabled;
        set
        {
            if (value == _enabled) return;

            _enabled = value;

            OnEnabledChangedCore();
        }
    }
    /// <summary>
    /// Gets a value indicating whether the browser can be navigated backward.
    /// </summary>
    public bool CanGoBack => Browser?.CanGoBack ?? false;

    /// <summary>
    /// Gets a value indicating whether the browser can be navigated forward.
    /// </summary>
    public bool CanGoForward => Browser?.CanGoForward ?? false;

    /// <summary>
    /// Gets a value indicating whether the browser is loading.
    /// </summary>
    public bool IsLoading => Browser?.IsLoading ?? false;

    /// <summary>
    /// Navigates the browser backward.
    /// </summary>
    public void GoBack() => Browser?.GoBack();

    /// <summary>
    /// Navigates the browser forward.
    /// </summary>
    public void GoForward() => Browser?.GoForward();

    /// <summary>
    /// Reloads the browser.
    /// </summary>
    /// <param name="igroneCache">
    /// A value indicating whether the cache should be ignored.
    /// </param>
    public void Reload(bool igroneCache = false)
    {
        if (igroneCache)
        {
            Browser?.ReloadIgnoreCache();
        }
        else
        {
            Browser?.Reload();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the browser has a DevTools window.
    /// </summary>
    public bool HasDevTools => BrowserHost?.HasDevTools ?? false;

    /// <summary>
    /// Shows DevTools window.
    /// </summary>
    public void ShowDevTools()
    {
        WebView.ShowDevTools();
    }

    /// <summary>
    /// Hides DevTools window.
    /// </summary>
    public void CloseDevTools()
    {
        WebView.HideDevTools();
    }

    /// <summary>
    /// Centers the position of the form within the bounds of the parent form.
    /// </summary>
    public void CenterToParent()
    {
        if (OwnerHandle == null)
        {
            CenterToScreen();
            return;
        }

        GetWindowRect(OwnerHandle.Value, out var rect);

        InvokeOnUIThread(() => { Location = new Point(rect.Left + (rect.Width - Width) / 2, rect.Top + (rect.Height - Height) / 2); });
    }

    /// <summary>
    /// Centers the position of the form on the current screen.
    /// </summary>
    public void CenterToScreen()
    {
        var screen = Screen.FromHandle(Handle);

        if (screen == null) return;

        InvokeOnUIThread(() => { Location = new Point(screen.WorkingArea.Left + (screen.WorkingArea.Width - Width) / 2, screen.WorkingArea.Top + (screen.WorkingArea.Height - Height) / 2); });
    }



    /// <summary>
    /// Shows the form.
    /// </summary>
    public void Show()
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.Show();

        });
    }

    /// <summary>
    /// Shows the form with the specified owner.
    /// </summary>
    /// <param name="owner">Any object that implements <see cref="IWin32Window"/> and represents the top-level window that will own this form.</param>
    public void Show(IWin32Window owner)
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.Show(owner);

            HostWindow?.Activate();
        });

    }

    /// <summary>
    /// Shows the form with the specified owner.
    /// </summary>
    /// <param name="owner">Any object that implements <see cref="Formium"/> and represents the top-level window that will own this form.</param>
    public void Show(Formium owner)
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.Show(owner.HostWindow);

            HostWindow?.Activate();
        });
    }

    /// <summary>
    /// Creates the form but does not show it yet.
    /// </summary>
    public void ShowInvisible()
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.ShowInvisible();
        });
    }

    //public void ShowInvisible(IWin32Window owner)
    //{
    //    InvokeOnUIThread(() =>
    //    {
    //        HostWindow?.ShowInvisible();
    //    });
    //}

    //public void ShowInvisible(Formium owner)
    //{
    //    InvokeOnUIThread(() =>
    //    {
    //        HostWindow?.ShowInvisible();
    //    });
    //}

    /// <summary>
    /// Shows the form as a modal dialog box.
    /// </summary>
    public DialogResult ShowDialog()
    {
        return InvokeOnUIThread(() =>
        {
            return HostWindow?.ShowDialog() ?? DialogResult.None;
        });
    }

    /// <summary>
    /// Shows the form as a modal dialog box with the specified owner.
    /// </summary>
    /// <param name="owner">Any object that implements <see cref="IWin32Window"/> and represents the top-level window that will own this form.</param>
    public DialogResult ShowDialog(IWin32Window owner)
    {
        return InvokeOnUIThread(() =>
        {
            return HostWindow?.ShowDialog(owner) ?? DialogResult.None;
        });
    }

    /// <summary>
    /// Shows the form as a modal dialog box with the specified owner.
    /// </summary>
    /// <param name="owner">
    /// Any object that implements <see cref="Formium"/> and represents the top-level window that will own this form.
    /// </param>
    public DialogResult ShowDialog(Formium owner)
    {
        return InvokeOnUIThread(() =>
        {
            return HostWindow?.ShowDialog(owner.HostWindow) ?? DialogResult.None;
        });
    }

    /// <summary>
    /// Shows the form as a modal dialog box with the specified owner.
    /// </summary>
    /// <param name="handle">
    /// A handle to the owner window of the form.
    /// </param>
    public DialogResult ShowDialog(IntPtr handle)
    {
        return InvokeOnUIThread(() =>
        {
            var owner = new Win32WindowWrap(handle);

            return HostWindow?.ShowDialog(owner) ?? DialogResult.None;
        });

    }

    /// <summary>
    /// Shows the form with the specified owner.
    /// </summary>
    /// <param name="handle">
    /// A handle to the owner window of the form.
    /// </param>
    public void Show(IntPtr handle)
    {
        InvokeOnUIThread(() =>
        {
            var owner = new Win32WindowWrap(handle);

            HostWindow?.Show(owner);

            HostWindow?.Activate();
        });

    }

    /// <summary>
    /// Hides the form.
    /// </summary>
    public void Hide()
    {
        InvokeOnUIThread(() => HostWindow?.Hide());
    }

    /// <summary>
    /// Closes the form.
    /// </summary>
    public void Close()
    {
        InvokeOnUIThread(() => HostWindow?.Close());
    }

    public bool IsDisposed => HostWindow?.IsDisposed ?? true;

    #region InvokeOnUIThread
    /// <summary>
    /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
    /// </summary>
    /// <param name="action">action to be performed on the form.</param>
    public void InvokeOnUIThread(Action action)
    {
        if (HostWindow == null || HostWindow.IsDisposed) return;

        if (HostWindow!.InvokeRequired)
        {
            HostWindow!.Invoke(new System.Windows.Forms.MethodInvoker(action));
        }
        else
        {
            action.Invoke();
        }
    }

    /// <summary>
    /// Executes the specified delegate synchronously on the UI thread, blocks execution on the calling thread until action has been executed.
    /// </summary>
    /// <param name="method">
    /// A delegate that contains a method to be called in the UI thread context.
    /// </param>
    /// <param name="args">
    /// An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.
    /// </param>
    /// <returns>
    /// An object that contains the return value from the delegate being invoked, or null if the delegate has no return value.
    /// </returns>
    public object? InvokeOnUIThread(Delegate method, params object[] args)
    {
        if (HostWindow == null || HostWindow.IsDisposed) return default;

        if (HostWindow!.InvokeRequired)
        {
            return HostWindow!.Invoke(method, args);
        }

        return method.DynamicInvoke(args);
    }

    /// <summary>
    /// Executes the specified delegate synchronously on the UI thread, blocks execution on the calling thread until action has been executed.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="method">A function to be called in the UI thread context.</param>
    /// <param name="args">
    /// An array of objects to pass as arguments to the specified method. This parameter can be null if the method takes no arguments.
    /// </param>
    /// <returns>The return value from the function being invoked.</returns>
    public T? InvokeOnUIThread<T>(Delegate method, params object[] args)
    {
        if (HostWindow == null || HostWindow.IsDisposed) return default;

        if (HostWindow!.InvokeRequired)
        {
            return (T?)HostWindow!.Invoke(method, args);
        }


        return (T?)method.DynamicInvoke(args);

    }

    /// <summary>
    /// Executes the specified delegate synchronously on the UI thread, blocks execution on the calling thread until action has been executed.
    /// </summary>
    /// <typeparam name="T">The return type of the method.</typeparam>
    /// <param name="method">A function to be called in the UI thread context.</param>
    /// <returns>The return value from the function being invoked.</returns>
    public T? InvokeOnUIThread<T>(Func<T> method)
    {
        if (HostWindow == null || HostWindow.IsDisposed) return default;

        if (HostWindow!.InvokeRequired)
        {
            return (T)HostWindow!.Invoke((Func<T>)method);
        }


        return method.Invoke();
    }
    #endregion

    /// <summary>
    /// Activates the form and gives it focus.
    /// </summary>
    public void Activate()
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.Activate();
            HostWindow?.Focus();
        });
    }

    /// <summary>
    /// Gives the form focus.
    /// </summary>
    public void Focus()
    {
        InvokeOnUIThread(() =>
        {
            HostWindow?.Focus();
        });
        SetBrowserFocus();
    }

    /// <summary>
    /// Disposes the <see cref="Formium"/> instance.
    /// </summary>
    public void Dispose()
    {
        WebView?.Dispose();
        HostWindow?.Dispose();
    }

    /// <summary>
    /// Executes the JavaScript code.
    /// </summary>
    /// <param name="code">
    /// The JavaScript code to be executed.
    /// </param>
    /// <param name="url">
    /// The URL where the script in question can be found, if any.
    /// </param>
    /// <param name="line">
    /// The base line number to use for error reporting.
    /// </param>
    public void ExecuteJavaScript(string code, string url = "", int line = 0)
    {
        WebView.ExecuteJavaScript(code, url, line);
    }

    /// <summary>
    /// Executes the JavaScript code on the specified frame.
    /// </summary>
    /// <param name="frame">
    /// The frame to execute the JavaScript code.
    /// </param>
    /// <param name="code">
    /// The JavaScript code to be executed.
    /// </param>
    /// <param name="url">
    /// The URL where the script in question can be found, if any.
    /// </param>
    /// <param name="line">
    /// The base line number to use for error reporting.
    /// </param>
    public void ExecuteJavaScript(CefFrame frame, string code, string url = "", int line = 0)
    {
        WebView.ExecuteJavaScript(frame, code, url, line);
    }

    /// <summary>
    /// Evaluates the JavaScript code asynchronously.
    /// </summary>
    /// <param name="code">
    /// The JavaScript code to be executed.
    /// </param>
    /// <param name="url">
    /// The URL where the script in question can be found, if any.
    /// </param>
    /// <param name="line">
    /// The base line number to use for error reporting.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// </returns>
    public Task<JavaScriptResult> EvaluateJavaScriptAsync(string code, string url = "", int line = 0)
    {
        return WebView.EvaluateJavaScriptAsync(code, url, line);
    }

    /// <summary>
    /// Evaluates the JavaScript code asynchronously on the specified frame.
    /// </summary>
    /// <param name="frame">
    /// The frame to execute the JavaScript code.
    /// </param>
    /// <param name="code">
    /// The JavaScript code to be executed.
    /// </param>
    /// <param name="url">
    /// The URL where the script in question can be found, if any.
    /// </param>
    /// <param name="line">
    /// The base line number to use for error reporting.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// </returns>
    public Task<JavaScriptResult> EvaluateJavaScriptAsync(CefFrame frame, string code, string url = "", int line = 0)
    {
        return WebView.EvaluateJavaScriptAsync(frame, code, url, line);
    }

    /// <summary>
    /// Begins a new JavaScript object registration.
    /// </summary>
    /// <param name="frame">
    /// The frame to register the JavaScript object.
    /// </param>
    /// <returns>
    /// A <see cref="JavaScriptObjectRegisterHandle"/> that represents the registration.
    /// </returns>
    public JavaScriptObjectRegisterHandle BeginRegisterJavaScriptObject(CefFrame frame)
    {
        return WebView.BeginRegisterJavaScriptObject(frame);
    }

    /// <summary>
    /// Ends a JavaScript object registration and creates objects on render process.
    /// </summary>
    /// <param name="handle">
    /// The handle of the registration.
    /// </param>
    public void EndRegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle)
    {
        WebView.EndRegisterJavaScriptObject(handle);
    }

    /// <summary>
    /// Registers a JavaScript object to external object in the window.
    /// </summary>
    /// <param name="handle">
    /// The handle of the registration.
    /// </param>
    /// <param name="name">
    /// The name of a JavaScript object that to be registered
    /// </param>
    /// <param name="jsObject">
    /// The JavaScript object to be registered.
    /// </param>
    /// <returns>
    /// Returns true for success, otherwise false.
    /// </returns>
    public bool RegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle, string name, JavaScriptObject jsObject)
    {
        return WebView.RegisterJavaScriptObject(handle, name, jsObject);
    }

    /// <summary>
    /// Registers a JavaScript object using a object wrapper to external object in the window.
    /// </summary>
    /// <param name="handle">
    /// The handle of the registration.
    /// </param>
    /// <param name="name">
    /// The name of a JavaScript object that to be registered
    /// </param>
    /// <param name="jsHostObject">
    /// The JavaScript object to be registered.
    /// </param>
    /// <returns>
    /// Returns true for success, otherwise false.
    /// </returns>

    public bool RegisterJavaScriptObject(JavaScriptObjectRegisterHandle handle, string name, JavaScriptObjectWrapper jsHostObject)
    {
        return WebView.RegisterJavaScriptObject(handle, name, jsHostObject);
    }

    /// <summary>
    /// Posts a message with or without a <seealso cref="JavaScriptValue"/> to the front end environment.
    /// </summary>
    /// <param name="message">
    /// The message name.
    /// </param>
    /// <param name="args">
    /// The <seealso cref="JavaScriptValue"/> passed to the front end environment. It can be null if no data is needed.
    /// </param>
    public void PostJavaScriptMessage(string message, JavaScriptValue? args = null)
    {
        var frame = Browser?.GetMainFrame();

        if (frame == null || WebView.JavaScriptWindowBindingObject == null) return;

        WebView.JavaScriptWindowBindingObject.PostBrowserMessage(frame, message, args);
    }



    /// <summary>
    /// Shows the about dialog.
    /// </summary>
    public void ShowAboutDialog()
    {
        WebView.ShowAboutDialog();
    }

    public Form GetHostWindow()
    {
        return HostWindow!;
    }
}
