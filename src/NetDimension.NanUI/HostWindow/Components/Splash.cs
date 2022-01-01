using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

public sealed class Splash
{
    #region Panel extension
    internal sealed class DragablePanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        public DragablePanel()
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

            Dock = DockStyle.Fill;

            DragHandlerPanel = new DragablePanel
            {
                Dock = DockStyle.Fill,
            };

            DragHandlerPanel.MouseDown += DragPanelMouseDown;
            Owner = owner;
        }

        private void DragPanelMouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            var wParam = new IntPtr((int)SysCommand.SC_MOVE + (int)HitTestValues.HTCAPTION);

            SendMessage(TopLevelControl.Handle, (uint)WindowMessage.WM_SYSCOMMAND, wParam, IntPtr.Zero);
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
    #endregion

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

    internal void AdjustPanelSize()
    {
        Panel.Size = new Size(Owner.Width, Owner.Height);
    }

    public Splash(Formium formium)
    {
        Owner = formium;

        const string BLUE = "#0055CC";

        Panel = new MaskPanel(Owner)
        {
            BackColor = ColorTranslator.FromHtml(BLUE),
            Visible = false
        };

        Owner.FormHostWindow.Controls.Add(Panel);

        Owner.LoadEnd += BrowserLoadEnd;
    }

    private void BrowserLoadEnd(object sender, Browser.LoadEndEventArgs e)
    {
        if (e.Frame.IsMain && AutoHide && Panel.Visible)
        {
            HidePanel();
        }
    }

    internal void ShowPanel()
    {
        Panel.BringToFront();
        Panel.Visible = true;
        Panel.BringHandlerToTop();
    }

    internal void HidePanel()
    {
        Panel.Visible = false;
    }
}
