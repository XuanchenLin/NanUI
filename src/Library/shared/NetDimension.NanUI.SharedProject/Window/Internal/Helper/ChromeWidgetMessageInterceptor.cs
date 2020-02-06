using NetDimension.NanUI.Browser;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI.Window
{
    internal class ChromeWidgetMessageInterceptor : NativeWindow
    {
        private Func<Message, bool> ForwardAction;

        internal ChromeWidgetMessageInterceptor(Control browserControl, IntPtr chromeHostHandle, Func<Message, bool> forwardAction)
        {
            AssignHandle(chromeHostHandle);
            browserControl.HandleDestroyed += BrowserControlDestoryed;
            ForwardAction = forwardAction;
        }

        private void BrowserControlDestoryed(object sender, EventArgs e)
        {
            this.ReleaseHandle();
            var browser = (Control)sender;
            browser.HandleDestroyed -= BrowserControlDestoryed;
            ForwardAction = null;
        }

        protected override void WndProc(ref Message m)
        {

            var result = ForwardAction?.Invoke(m) ?? false;

            if (!result)
            {
                base.WndProc(ref m);
            }
        }

        internal static void Setup(ChromeWidgetMessageInterceptor interceptor, BrowserCore browserCore, Func<Message, bool> forwardAction)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        if (BrowserWidgetHandleFinder.TryFindHandle(browserCore.BrowserWindowHandle, out IntPtr chromeWidgetHostHandle))
                        {
                            interceptor = new ChromeWidgetMessageInterceptor(browserCore.Owner, chromeWidgetHostHandle, forwardAction);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(50);
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
