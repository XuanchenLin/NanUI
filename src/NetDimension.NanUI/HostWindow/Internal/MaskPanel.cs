using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{

    internal sealed class DragPanel : Panel
    {
        public DragPanel()
        {
            DoubleBuffered = true;
        }
    }
    internal sealed class MaskPanel : Panel
    {
        internal Panel DragHandlerPanel { get; }

        public MaskPanel()
        {
            Dock = DockStyle.Fill;
            BackgroundImage = Properties.Resources.Powered;
            BackgroundImageLayout = ImageLayout.Center;
            DoubleBuffered = true;

            DragHandlerPanel = new DragPanel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
            };

            DragHandlerPanel.MouseDown += DragHandlerPanel_MouseDown;
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
