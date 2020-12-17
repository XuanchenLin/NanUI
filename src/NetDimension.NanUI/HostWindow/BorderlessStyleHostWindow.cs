using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    public sealed class BorderlessStyleHostWindow : BorderlessWindow, IFormiumHostWindow
    {
        private readonly SynchronizationContext _uiThread;
        private readonly Formium _formium;


        public OnWindowsMessageDelegate OnWindowsMessage { get; set; }

        public OnWindowsMessageDelegate OnDefWindowsMessage { get; set; }

        private BorderlessStyleHostWindow()
        {
            MinimumSize = new Size(200, 100);
        }
        internal BorderlessStyleHostWindow(Formium formium) : this()
        {

            _formium = formium;
            _uiThread = WindowsFormsSynchronizationContext.Current;
        }

        public void PostUIThread(Action action)
        {
            _uiThread.Post(_state =>
            {
                action?.Invoke();
            }, null);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
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
