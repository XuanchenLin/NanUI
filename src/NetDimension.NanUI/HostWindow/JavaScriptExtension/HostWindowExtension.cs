using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using NetDimension.NanUI.JavaScript;
using Xilium.CefGlue;

namespace NetDimension.NanUI.HostWindow.JavaScriptExtension
{
    internal class HostWindowExtension : JavaScriptExtensionBase
    {
        public override string Name => "Formium/HostWindow";
        public override string JavaScriptCode => Properties.Resources.HostWindowJavaScriptExtension;

        public HostWindowExtension()
        {
            RegisterFunctionHandler(nameof(Minimize), Minimize);

            RegisterFunctionHandler(nameof(Maximize), Maximize);

            RegisterFunctionHandler(nameof(Close), Close);

            RegisterFunctionHandler(nameof(Restore), Restore);

            RegisterFunctionHandler(nameof(FullScreen), FullScreen);

            RegisterFunctionHandler(nameof(MoveTo), MoveTo);

            RegisterFunctionHandler(nameof(SizeTo), SizeTo);

            RegisterFunctionHandler(nameof(GetWindowState), GetWindowState);

            RegisterFunctionHandler(nameof(GetWindowRectangle), GetWindowRectangle);

            RegisterFunctionHandler(nameof(Active), Active);

            RegisterFunctionHandler(nameof(IsNetworkAvailable), IsNetworkAvailable);

            RegisterFunctionHandler(nameof(GetWinFormiumVersion), GetWinFormiumVersion);

            RegisterFunctionHandler(nameof(GetChromiumVersion), GetChromiumVersion);

            RegisterFunctionHandler(nameof(GetCultureInfo), GetCultureInfo);

            RegisterFunctionHandler(nameof(ShowMask), ShowMask);
            RegisterFunctionHandler(nameof(HideMask), HideMask);

        }

        private JavaScriptValue ShowMask(Formium owner, JavaScriptValue[] arguments)
        {
            owner.Mask.Show();
            return null;
        }

        private JavaScriptValue HideMask(Formium owner, JavaScriptValue[] arguments)
        {
            owner.Mask.Close();
            return null;
        }

        private JavaScriptValue GetCultureInfo(Formium owner, JavaScriptValue[] arguments)
        {
            var retval = JavaScriptValue.CreateObject();

            retval.SetValue("name", JavaScriptValue.CreateString($"{Thread.CurrentThread.CurrentCulture.Name}"));

            retval.SetValue("displayName", JavaScriptValue.CreateString($"{Thread.CurrentThread.CurrentCulture.DisplayName}"));
            retval.SetValue("englishName", JavaScriptValue.CreateString($"{Thread.CurrentThread.CurrentCulture.EnglishName}"));

            retval.SetValue("lcid", JavaScriptValue.CreateNumber(Thread.CurrentThread.CurrentCulture.LCID));

            return retval;
        }

        private JavaScriptValue GetWinFormiumVersion(JavaScriptValue[] _)
        {
            return JavaScriptValue.CreateString($"{Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private JavaScriptValue GetChromiumVersion(JavaScriptValue[] _)
        {
            return JavaScriptValue.CreateString($"{CefRuntime.ChromeVersion}");
        }

        private JavaScriptValue IsNetworkAvailable(Formium owner, JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateBool(NetworkInterface.GetIsNetworkAvailable());
        }

        private JavaScriptValue Active(Formium owner, JavaScriptValue[] arguments)
        {
            owner.HostWindowInternal.Activate();

            return null;
        }


        private JavaScriptValue GetWindowState(Formium owner, JavaScriptValue[] arguments)
        {
            return JavaScriptValue.CreateString(owner.WindowState.ToString().ToLower());
        }

        private JavaScriptValue GetWindowRectangle(Formium owner, JavaScriptValue[] arguments)
        {
            var retval = JavaScriptValue.CreateObject();

            var rect = new RECT();

            User32.GetWindowRect(owner.HostWindowHandle, ref rect);

            retval.SetValue("x", JavaScriptValue.CreateNumber(rect.left));
            retval.SetValue("y", JavaScriptValue.CreateNumber(rect.top));
            retval.SetValue("width", JavaScriptValue.CreateNumber(rect.Width));
            retval.SetValue("height", JavaScriptValue.CreateNumber(rect.Height));

            return retval;
        }

        private JavaScriptValue Minimize(Formium owner, JavaScriptValue[] arguments)
        {
            if (owner.WindowType == HostWindow.HostWindowType.Kiosk || !owner.CanMinimize)
                return null;

            if (owner.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                owner.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            return null;
        }
        private JavaScriptValue Maximize(Formium owner, JavaScriptValue[] arguments)
        {

            if (owner.WindowType == HostWindow.HostWindowType.Kiosk || !owner.CanMaximize)
                return null;


            if (owner.WindowState != System.Windows.Forms.FormWindowState.Maximized)
            {
                owner.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else if (owner.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (owner.IsFullScreen)
                {
                    owner.FullScreen(false);
                }
                else
                {
                    owner.WindowState = System.Windows.Forms.FormWindowState.Normal;
                }
            }

            return null;
        }
        private JavaScriptValue Restore(Formium owner, JavaScriptValue[] arguments)
        {
            if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
                return null;

            if (owner.WindowState != System.Windows.Forms.FormWindowState.Normal)
            {
                owner.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

            return null;
        }

        private JavaScriptValue Close(Formium owner, JavaScriptValue[] arguments)
        {
            if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
                return null;

            owner.Close();

            return null;
        }

        private JavaScriptValue FullScreen(Formium owner, JavaScriptValue[] arguments)
        {
            if (owner.WindowType == HostWindow.HostWindowType.Kiosk)
                return null;

            if (owner.AllowFullScreen)
            {
                owner.FullScreen(!owner.IsFullScreen);
            }
            return null;
        }
        private JavaScriptValue MoveTo(Formium owner, JavaScriptValue[] arguments)
        {
            if (owner.WindowType == HostWindow.HostWindowType.Kiosk || owner.WindowState
                != System.Windows.Forms.FormWindowState.Normal)
                return null;

            var x = arguments.Length == 2 ? arguments[0].GetInt() : 0;
            var y = arguments.Length == 2 ? arguments[1].GetInt() : 0;


            owner.Left = x;
            owner.Top = y;

            return null;
        }
        private JavaScriptValue SizeTo(Formium owner, JavaScriptValue[] arguments)
        {
            if (!owner.Resizable || owner.WindowState
                != System.Windows.Forms.FormWindowState.Normal)
                return null;


            var width = arguments.Length == 2 ? arguments[0].GetInt() : 0;
            var height = arguments.Length == 2 ? arguments[1].GetInt() : 0;

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

            return null;
        }
    }
}
