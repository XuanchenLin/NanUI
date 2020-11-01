using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    public sealed class SystemStyleHostWindow : SystemNativeWindow, IFormiumHostWindow
    {
        private readonly SynchronizationContext _uiThread;
        private readonly Formium _formium;

        public OnWindowsMessageDelegate OnWindowsMessage { get; set; }

        public OnWindowsMessageDelegate OnDefWindowsMessage { get; set; }

        private SystemStyleHostWindow() {
            MinimumSize = new Size(200, 100);
        }

        internal SystemStyleHostWindow(Formium formium)
            :this()
        {
            _formium = formium;
            _uiThread = WindowsFormsSynchronizationContext.Current;
        }


        public void PostUIThread(Action action)
        {
            _uiThread.Post(_state => {
                action?.Invoke();
            }, null);
        }

        protected override void WndProc(ref Message m)
        {
            var retval = OnWindowsMessage?.Invoke(ref m);

            if (retval == null || retval == false)
            {
                base.WndProc(ref m);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            var retval = OnDefWindowsMessage?.Invoke(ref m);

            if (retval == null || retval == false)
            {
                base.DefWndProc(ref m);
            }
        }
    }
}
