using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

namespace FormiumClient
{
    public class KisokModeForm : Formium
    {
        public override HostWindowType WindowType { get; } = HostWindowType.Kiosk;
        public override string StartUrl { get; } = "https://github.com/NetDimension/NanUI";

        public KisokModeForm()
        {
            Icon = Properties.Resources.DefaultIcon;
        }

        protected override void OnReady()
        {
            
        }

    }
}
