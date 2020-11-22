using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{

    internal sealed class DragPanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // 实现透明样式

                return cp;
            }
        }

        public DragPanel()
        {
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(0, Color.Transparent)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
    internal sealed class MaskPanel : Panel
    {
        internal Panel DragHandlerPanel { get; }
        internal Formium Owner { get; }

        public MaskPanel(Formium owner)
        {
            BackgroundImage = Properties.Resources.Powered;
            BackgroundImageLayout = ImageLayout.Center;
            DoubleBuffered = true;
            AutoSize = false;
            //Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Dock = DockStyle.Fill;

            DragHandlerPanel = new DragPanel
            {
                Dock = DockStyle.Fill,
            };

            DragHandlerPanel.MouseDown += DragHandlerPanel_MouseDown;
            Owner = owner;
        }

        private void DragHandlerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            User32.ReleaseCapture();

            var wParam = new IntPtr((int)SystemCommandFlags.SC_MOVE + (int)HitTest.HTCAPTION);

            User32.SendMessage(TopLevelControl.Handle, (uint)WindowsMessages.WM_SYSCOMMAND, wParam, IntPtr.Zero);
        }

        public void BringHandlerToTop()
        {
            if (!Controls.Contains(DragHandlerPanel))
            {
                Controls.Add(DragHandlerPanel);
            }

            DragHandlerPanel.BringToFront();
        }

        internal void HideHandler()
        {
            if (Controls.Contains(DragHandlerPanel))
            {
                Controls.Remove(DragHandlerPanel);
            }
        }
    }
}
