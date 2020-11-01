using NetDimension.NanUI.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    internal class ChromeWidgetMessageInterceptor : NativeWindow
    {
        private readonly Form _hostWindow;
        private Func<Message, bool> _forwardAction;

        internal ChromeWidgetMessageInterceptor(Form hostWindow, IntPtr browserWindowHandle, Func<Message, bool> forwardAction)
        {
            AssignHandle(browserWindowHandle);
            _hostWindow = hostWindow;
            _forwardAction = forwardAction;


            hostWindow.HandleDestroyed += HostWindowHandleDestroyed;
        }

        private void HostWindowHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();
            _hostWindow.HandleDestroyed -= HostWindowHandleDestroyed;
            _forwardAction = null;
        }

        protected override void WndProc(ref Message m)
        {


            var result = _forwardAction?.Invoke(m) ?? false;


            if (!result)
            {
                base.WndProc(ref m);
            }
        }

        internal static void Setup(ChromeWidgetMessageInterceptor interceptor,Formium formium, Func<Message, bool> forwardAction)
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        if (BrowserWidgetHandleFinder.TryFindHandle(formium.BrowserWindowHandle, out IntPtr chromeWidgetHostHandle))
                        {
                            interceptor = new ChromeWidgetMessageInterceptor(formium.HostWindowInternal, chromeWidgetHostHandle, forwardAction);

                            if(WinFormium.Runtime.IsDebuggingMode)
                            {
                                WinFormium.GetLogger().Debug("BrowserWindow has been attached successfully.");
                            }

                            break;
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
                catch
                {

                }
            });
        }
    }
}
