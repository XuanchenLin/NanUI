// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
internal class FormiumWindowBindingObject : JavaScriptWindowBindingObject
{
    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(int Description, int ReservedValue);


    public override string Name { get; } = "WinFormium/FormiumWindowBindingObject";
    public override string JavaScriptWindowBindingCode { get; } = Properties.Resources.FormiumWindowBindingObject; // <- Resources\FormiumWindowBindingObject.js

    #region TestCode
//    public override string JavaScriptWindowBindingCode { get; } = """"
//var formium;
//(function ($window) {


//    const CMD_ATTR_PREFIX = "formium-command";

//    let isDocumentReady = false;
//    let isContextReady = false;

//    const readyCallbacks = [];
//    const contextReadyCallbacks = [];

//    class HostWindow {

//        globalMouseEventHandlerRegistered = false;

//        minimize() {
//            native function Minimize();
//            return Minimize();
//        };

//        maximize() {
//            native function Maximize();
//            return Maximize();
//        };

//        close() {
//            native function Close();
//            return Close();
//        };

//        restore() {
//            native function Restore();
//            return Restore();
//        };

//        fullScreen() {
//            native function FullScreen();
//            return FullScreen();
//        };

//        moveTo(x, y) {
//            native function MoveTo();
//            return MoveTo(x, y);
//        };

//        moveBy(deltaX, deltaY) {
//            native function MoveBy();
//            return MoveBy(deltaX, deltaY);
//        };

//        sizeTo(width, height) {
//            native function SizeTo();
//            return SizeTo(width, height);
//        };

//        sizeBy(deltaX, deltaY) {
//            native function SizeBy();
//            return SizeBy(deltaX, deltaY);
//        };

//        active() {
//            native function Active();
//            return Active();
//        };

//        center() {
//            native function Center();
//            return Center();
//        };
//        minimize() {
//            native function Minimize();
//            return Minimize();
//        };

//        maximize() {
//            native function Maximize();
//            return Maximize();
//        };

//        close() {
//            native function Close();
//            return Close();
//        };

//        restore() {
//            native function Restore();
//            return Restore();
//        };

//        fullScreen() {
//            native function FullScreen();
//            return FullScreen();
//        };

//        moveTo(x, y) {
//            native function MoveTo();
//            return MoveTo(x, y);
//        };

//        moveBy(deltaX, deltaY) {
//            native function MoveBy();
//            return MoveBy(deltaX, deltaY);
//        };

//        sizeTo(width, height) {
//            native function SizeTo();
//            return SizeTo(width, height);
//        };

//        sizeBy(deltaX, deltaY) {
//            native function SizeBy();
//            return SizeBy(deltaX, deltaY);
//        };

//        active() {
//            native function Active();
//            return Active();
//        };

//        center() {
//            native function Center();
//            return Center();
//        };

//        raiseHostWindowEvent(eventName, eventArgs) {

//            if (!isContextReady) return;

//            window.dispatchEvent(new CustomEvent(
//                eventName,
//                {
//                    detail: eventArgs,
//                    bubbles: true
//                })
//            );
//        };

//        postMessage(message, args) {
//            native function PostHostWindowMessage();
//            return PostHostWindowMessage(message, args);
//        }
//    }


//    class FomriumStateManager {


//        setContextReadyState() {

//            if (isContextReady) return;

//            while (contextReadyCallbacks.length > 0) {
//                contextReadyCallbacks.pop().apply(this);
//            }

//            isContextReady = true;

//        };

//        setDocumentReadyState() {

//            if (isDocumentReady) return;

//            const { hostWindow } = formium;

//            if (hostWindow.globalMouseEventHandlerRegistered == false) {

//                window.addEventListener("click", (e) => {
//                    if (e.button === 0) {

//                        let srcElement = e.target;

//                        while (srcElement && !srcElement.hasAttribute(CMD_ATTR_PREFIX)) {
//                            srcElement = srcElement.parentElement;
//                        }

//                        if (srcElement) {

//                            const commandString = srcElement.getAttribute(CMD_ATTR_PREFIX).toLowerCase();

//                            const commandMaps = {
//                                close: "close",
//                                maximize: "maximize",
//                                minimize: "minimize",
//                                restore: "restore",
//                                close: "close",
//                                fullscreen: "fullScreen"
//                            };

//                            if (commandMaps.hasOwnProperty(commandString)) {

//                                const command = commandMaps[commandString];

//                                if (command && hostWindow && hostWindow[command]) {

//                                    setTimeout(() => {
//                                        hostWindow[command].apply(hostWindow);
//                                    }, 100);

//                                    e.stopPropagation();
//                                    e.preventDefault();
//                                }
//                            }
//                        }
//                    }
//                });

//                hostWindow.globalMouseEventHandlerRegistered = true;
//            }

//            while (readyCallbacks.length > 0) {
//                readyCallbacks.pop().apply(this);
//            }

//            isDocumentReady = true;
//        };

//    }

//    class Formium {

//        get culture() {
//            native function GetCurrentCulture();
//            return GetCurrentCulture();
//        };

//        version = {
//            get WinFormium() {
//                native function GetWinFormiumVersion();
//                return GetWinFormiumVersion();
//            },
//            get Chromium() {
//                native function GetChromiumVersion();
//                return GetChromiumVersion();
//            },
//            get Application() {
//                native function GetApplicationVersion();
//                return GetApplicationVersion();
//            },
//        };

//        hostWindow = new HostWindow();

//        state = new FomriumStateManager();

//        onDocumentReady(callback) {
//            if (isDocumentReady) {
//                callback.apply(this);
//            }
//            else {
//                readyCallbacks.push(callback);
//            }
//        };

//        onContextReady(callback) {
//            if (isContextReady) {
//                callback.apply(this);
//            }
//            else {
//                contextReadyCallbacks.push(callback);
//            }
//        };
//    }

//    const $formium = $window.formium = new Formium();
//    const $hostWindow = $formium.hostWindow;
//})(this);
//"""";
    #endregion

    public FormiumWindowBindingObject()
    {
        RegisterSynchronousNativeFunction(GetWinFormiumVersion);
        RegisterSynchronousNativeFunction(GetChromiumVersion);
        RegisterSynchronousNativeFunction(GetApplicationVersion);

        RegisterSynchronousNativeFunction(GetCurrentCulture);


        // HostWindow Object functions
        // - methods
        RegisterSynchronousNativeFunction(Minimize);
        RegisterSynchronousNativeFunction(Maximize);
        RegisterSynchronousNativeFunction(Restore);
        RegisterSynchronousNativeFunction(Close);
        RegisterSynchronousNativeFunction(FullScreen);
        RegisterSynchronousNativeFunction(MoveTo);
        RegisterSynchronousNativeFunction(MoveBy);
        RegisterSynchronousNativeFunction(SizeTo);
        RegisterSynchronousNativeFunction(SizeBy);
        RegisterSynchronousNativeFunction(Active);
        RegisterSynchronousNativeFunction(Center);

        // - properties
        RegisterSynchronousNativeFunction(GetWindowState);
        RegisterSynchronousNativeFunction(GetWindowLocation);
        RegisterSynchronousNativeFunction(GetWindowSize);
        RegisterSynchronousNativeFunction(GetWindowRectangle);

        RegisterSynchronousNativeFunction(IsFramelessWindow);
        RegisterSynchronousNativeFunction(IsEmbeddedInControl);

        RegisterSynchronousNativeFunction(PostHostWindowMessage);
        RegisterSynchronousNativeFunction(SendHostWindowMessageRequest);

        RegisterAsynchronousNativeFunction(SendHostWindowMessageRequestAsync);
    }

    private void SendHostWindowMessageRequestAsync(Formium owner, JavaScriptArray arguments, JavaScriptPromise promise)
    {

        if (arguments.Count != 2 || arguments.First().ValueType != JavaScriptValueType.String)
        {
            promise.Reject("It only accepts two parameters, one is the message text and the other is any JavaScript value type.");
            return;
        }

        var message = arguments[0].GetString();
        var data = arguments[1];

        if (message == null || string.IsNullOrEmpty(message)) {
            promise.Reject("The first argument should be message text.");
            return;
        }

        owner.OnBrowserRequestAsync(message, data, promise);


    }

    private JavaScriptValue? SendHostWindowMessageRequest(Formium owner, JavaScriptArray arguments)
    {

        if (arguments.Count != 2) return null;

        if (arguments.First().ValueType != JavaScriptValueType.String) return null;

        var message = arguments[0].GetString();
        var data = arguments[1];

        if (message == null || string.IsNullOrEmpty(message)) return null;

        return owner.OnBrowserRequest(message, data);
    }

    private JavaScriptValue? PostHostWindowMessage(Formium owner, JavaScriptArray arguments)
    {

        if (arguments.Count != 2) return null;

        if (arguments.First().ValueType != JavaScriptValueType.String) return null;

        var message = arguments[0].GetString();
        var data = arguments[1];

        if (message == null || string.IsNullOrEmpty(message)) return null;

        owner.OnBrowserMessage(message, data);

        return null;
    }


    private JavaScriptValue GetCurrentCulture(Formium owner, JavaScriptArray args)
    {

        var retval = new JavaScriptObject
        {
            { "name", $"{Application.CurrentCulture}" },
            { "cultureName", new JavaScriptArray()
                {
                    $"{Thread.CurrentThread.CurrentCulture.DisplayName}",
                    $"{Thread.CurrentThread.CurrentCulture.EnglishName}",
                }
            },
            { "lcid", Application.CurrentCulture.LCID}
        };

        return retval;
    }


    public JavaScriptValue GetWinFormiumVersion(JavaScriptArray _)
    {

        var version = typeof(WinFormiumApp).Assembly?.GetName()?.Version;

        if (version == null) return "UNKNOWN";

        return $"{version}";
    }

    public JavaScriptValue GetChromiumVersion(JavaScriptArray _)
    {
        return $"{CefRuntime.ChromeVersion}";
    }

    public JavaScriptValue GetApplicationVersion(JavaScriptArray _)
    {
        var version = Assembly.GetEntryAssembly()?.GetName()?.Version;
        if (version == null) return "UNKNOWN";

        return $"{version}";
    }

    #region HostWindow

    private JavaScriptValue? Minimize(Formium owner, JavaScriptArray _)
    {

        if (!owner.Minimizable)
            return null;

        owner.InvokeOnUIThread(() =>
        {
            owner.WindowState = FormiumWindowState.Minimized;
        });

        return null;
    }

    private JavaScriptValue? Maximize(Formium owner, JavaScriptArray _)
    {

        if (!owner.Maximizable)
            return null;

        if (owner.WindowState != FormiumWindowState.Maximized)
        {
            owner.InvokeOnUIThread(() => owner.WindowState = FormiumWindowState.Maximized);
        }
        else
        {
            owner.InvokeOnUIThread(() => owner.WindowState = FormiumWindowState.Normal);
        }

        return null;
    }

    private JavaScriptValue? Restore(Formium owner, JavaScriptArray _)
    {

        if (owner.WindowState != FormiumWindowState.Normal)
        {
            owner.InvokeOnUIThread(() => owner.WindowState = FormiumWindowState.Normal);
        }

        return null;
    }

    private JavaScriptValue? FullScreen(Formium owner, JavaScriptArray _)
    {

        if (owner.AllowFullScreen)
        {
            owner.InvokeOnUIThread(() => owner.WindowState = FormiumWindowState.FullScreen);
        }
        return null;
    }

    private JavaScriptValue? Close(Formium owner, JavaScriptArray _)
    {

        owner.InvokeOnUIThread(owner.Close);
        return null;
    }



    private JavaScriptValue? MoveTo(Formium owner, JavaScriptArray arguments)
    {

        if (owner.WindowState != FormiumWindowState.Normal)
            return null;

        var x = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var y = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeOnUIThread(() =>
        {
            owner.Left = x;
            owner.Top = y;
        });

        return null;
    }

    private JavaScriptValue? MoveBy(Formium owner, JavaScriptArray arguments)
    {


        if (owner.WindowState != FormiumWindowState.Normal)
            return null;

        var x = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var y = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeOnUIThread(() =>
        {
            owner.Left += x;
            owner.Top += y;
        });

        return null;
    }

    private JavaScriptValue? SizeTo(Formium owner, JavaScriptArray arguments)
    {

        if (owner.WindowState != FormiumWindowState.Normal)
            return null;

        var width = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var height = arguments.Count == 2 ? arguments[1].GetInt() : 0;

        owner.InvokeOnUIThread(() =>
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

    private JavaScriptValue? SizeBy(Formium owner, JavaScriptArray arguments)
    {

        if (!owner.Sizable || owner.WindowState != FormiumWindowState.Normal)
            return null;

        var width = arguments.Count == 2 ? arguments[0].GetInt() : 0;
        var height = arguments.Count == 2 ? arguments[1].GetInt() : 0;



        owner.InvokeOnUIThread(() =>
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

    private JavaScriptValue? Active(Formium owner, JavaScriptArray _)
    {

        owner.InvokeOnUIThread(owner.Activate);

        return null;
    }

    private JavaScriptValue? Center(Formium owner, JavaScriptArray _)
    {


        if (!owner.Sizable || owner.WindowState != FormiumWindowState.Normal)
            return null;

        owner.InvokeOnUIThread(owner.CenterToParent);

        return null;
    }

    private JavaScriptValue GetWindowState(Formium owner, JavaScriptArray _)
    {

        return new JavaScriptValue($"{owner?.WindowState.ToString().ToLower() ?? "normal"}");
    }

    private JavaScriptValue GetWindowLocation(Formium owner, JavaScriptArray _)
    {

        var obj = new JavaScriptObject
        {
            { "x", owner?.Location.X ?? 0 },
            { "y", owner?.Location.Y ?? 0 }
        };

        return obj;
    }

    private JavaScriptValue GetWindowSize(Formium owner, JavaScriptArray _)
    {

        var obj = new JavaScriptObject
        {
            { "width", owner?.Size.Width ?? 0 },
            { "height", owner?.Size.Height ?? 0 }
        };

        return obj;
    }

    private JavaScriptValue GetWindowRectangle(Formium owner, JavaScriptArray _)
    {

        var obj = new JavaScriptObject
        {
            { "left", owner?.Location.X ?? 0 },
            { "top", owner?.Location.Y ?? 0 },
            { "right", (owner?.Location.X ?? 0) + (owner?.Size.Width ?? 0) },
            { "bottom", (owner?.Location.Y ?? 0) + (owner?.Size.Height ?? 0) },
            { "width", owner?.Size.Width ?? 0 },
            { "height", owner?.Size.Height ?? 0 }
        };

        return obj;
    }

    private JavaScriptValue IsFramelessWindow(Formium owner, JavaScriptArray _)
    {

        return !owner.CurrentFormStyle.HasSystemTitleBar;
    }

    private JavaScriptValue IsEmbeddedInControl(Formium owner, JavaScriptArray _)
    {
        return owner.CurrentFormStyle.AsEmbeddedControl;
    }

    #endregion

}
