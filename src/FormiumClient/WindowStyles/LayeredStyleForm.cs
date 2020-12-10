using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

namespace FormiumClient
{
    public class LayeredStyleForm : Formium
    {
        public override HostWindowType WindowType => HostWindowType.Layered;
        public override string StartUrl => "http://layered.example.local";

        public LayeredStyleForm()
        {
            Size = new System.Drawing.Size(400, 400);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Icon = Properties.Resources.DefaultIcon;
        }
    }
}
