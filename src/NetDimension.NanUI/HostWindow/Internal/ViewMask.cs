using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI.Browser;

namespace NetDimension.NanUI.HostWindow
{
    public sealed class ViewMask
    {
        internal MaskPanel Panel { get; }
        internal Formium Owner { get; }

        public bool AutoHide { get; set; } = true;

        public Color BackColor
        {
            get => Panel.BackColor;
            set => Panel.BackColor = value;
        }

        public Image Image
        {
            get => Panel.BackgroundImage;
            set => Panel.BackgroundImage = value;
        }

        public ImageLayout ImageLayout
        {
            get => Panel.BackgroundImageLayout;
            set => Panel.BackgroundImageLayout = value;
        }

        public Control.ControlCollection Content => Panel.Controls;

        public ViewMask(Formium formium)
        {
            Owner = formium;

            Panel = new MaskPanel(Owner)
            {
                Visible = false,
                BackColor = ColorTranslator.FromHtml("#0055CC"),
            };

            Owner.HostWindowInternal.Controls.Add(Panel);

            Owner.LoadEnd += OnBrowserLoadEnd;
        }



        private void OnBrowserLoadEnd(object sender, LoadEndEventArgs e)
        {
            if (e.Frame.IsMain && AutoHide && Panel.Visible)
            {
                Close();
            }
        }

        internal void Show()
        {

            Panel.BringToFront();

            Panel.BringHandlerToTop();
            Panel.Visible = true;

        }
        internal void Close()
        {
            Panel.Visible = false;
        }
    }
}
