using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

namespace FormiumClient
{
    public class AcrylicStyleForm : Formium
    {
        public override HostWindowType WindowType { get; } = HostWindowType.Acrylic;
        public override string StartUrl { get; } = "http://acrylic.example.local";


        public AcrylicStyleForm()
        {

            Size = new Size(800, 480);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Icon = Properties.Resources.DefaultIcon;

            var mainColor = ColorTranslator.FromHtml("#E83B90");

            Mask.BackColor = mainColor;
            AcrylicWindowProperties.ShadowEffect = ShadowEffect.DropShadow;
            AcrylicWindowProperties.ShadowColor = mainColor;


            Resizable = false;

        }

    }
}
