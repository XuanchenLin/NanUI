using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

namespace FormiumClient
{
    public class NativeStyleForm : Formium
    {
        public override HostWindowType WindowType { get; } = HostWindowType.System;
        public override string StartUrl { get; } = "https://www.bing.com";

        public NativeStyleForm()
        {
            Size = new Size(1280, 800);

            Title = "Native Style Window Example";

            Icon = Properties.Resources.DefaultIcon;

            StartPosition = FormStartPosition.CenterParent;

            AutoShowMask = false;

        }

        protected override void OnReady()
        {
            DocumentTitleChanged += OnDocumentTitleChanged;
        }

        private void OnDocumentTitleChanged(object sender, NetDimension.NanUI.Browser.DocumentTitleChangedEventArgs e)
        {
            Subtitle = e.Title;
        }
    }
}
