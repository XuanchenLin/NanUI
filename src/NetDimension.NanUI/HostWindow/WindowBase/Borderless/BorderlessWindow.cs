using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }

    public enum BorderEffect
    {
        None,
        BorderLine,
        RoundCorner
    }

    public enum ShadowEffect
    {
        None,
        Glow,
        Shadow,
        DropShadow
    }

    public class WindowDpiChangedEventArgs : EventArgs
    {
        public int OldDPI { get; }
        public int NewDPI { get; }

        internal WindowDpiChangedEventArgs(int oldDpi, int newDpi)
        {
            OldDPI = oldDpi;
            NewDPI = newDpi;
        }
    }


    public class BorderlessWindow : Form
    {

        private int _deviceDpi;


        private FieldInfo _clientWidthField;
        private FieldInfo _clientHeightField;
        private FieldInfo _formStateSetClientSizeField;
        private FieldInfo _formStateField;
        private FieldInfo _formStateCoreField;
        private FieldInfo _formStateWindowActivated;



        internal static readonly Point MinimizedFormLocation = new Point(-32000, -32000);
        internal static readonly Point InvalidPoint = new Point(-10000, -10000);

        public event EventHandler<WindowDpiChangedEventArgs> SystemDpiChanged;

        private BorderEffect _borderEffect = BorderEffect.BorderLine;
        private Color _borderColor = ColorTranslator.FromHtml("#0055CC");
        private Color? _inactiveBorderColop = null;

        private Rectangle _regionRect = Rectangle.Empty;

        private bool _isLoaded;

        protected virtual Padding FormBorders => new Padding(1, 1, 1, 1);

        protected float ScaleFactor { get; private set; } = 1.0f;

        private FieldInfo FormStateCoreField
        {
            get
            {
                if (_formStateCoreField == null)
                    _formStateCoreField = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);
                return _formStateCoreField;
            }
        }

        private FieldInfo FormStateWindowActivatedField
        {
            get
            {
                if (_formStateWindowActivated == null)
                    _formStateWindowActivated = typeof(Form).GetField("FormStateIsWindowActivated", BindingFlags.NonPublic | BindingFlags.Static);
                return _formStateWindowActivated;
            }
        }

        //public bool EnableHitTest { 
        //    get => _shadowDecorator?.AllowHitTest ?? false; 
        //    set => _shadowDecorator.AllowHitTest = value; 
        //}

        /// <summary>
        /// 窗体的阴影样式
        /// </summary>
        public ShadowEffect ShadowEffect
        {
            get => _shadowDecorator.ShadowEffect;
            set
            {
                _shadowDecorator.ShadowEffect = value;
            }
        }

        /// <summary>
        /// 窗体的边框样式
        /// </summary>
        public BorderEffect BorderEffect
        {
            get => _borderEffect;

            set
            {
                if (value != _borderEffect)
                {
                    _borderEffect = value;

                    if (_shadowDecorator != null)
                    {
                        if (_borderEffect == BorderEffect.RoundCorner)
                        {
                            _shadowDecorator.IsRoundedCornerStyle = true;
                        }
                        else
                        {
                            _shadowDecorator.IsRoundedCornerStyle = false;
                        }

                        if(_borderEffect == BorderEffect.BorderLine)
                        {
                            _shadowDecorator.IsBorderLineStyle = true;
                        }
                        else
                        {
                            _shadowDecorator.IsBorderLineStyle = false;
                        }
                    }

                }
            }
        }

        public Color ShadowColor
        {
            get => _shadowDecorator.ShadowColor;
            set
            {
                _shadowDecorator.ShadowColor = value;
            }
        }

        public Color? InactiveShadowColor
        {
            get => _shadowDecorator.InactiveShadowColor;
            set
            {
                _shadowDecorator.InactiveShadowColor = value;
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                if (value != _borderColor)
                {
                    _borderColor = value;

                    InvalidateNonClient();

                    SendFrameChanged(Handle);



                }
            }
        }

        public Color? InactiveBorderColor
        {
            get => _inactiveBorderColop;
            set
            {
                if (value != _inactiveBorderColop)
                {
                    _inactiveBorderColop = value;

                    InvalidateNonClient();

                    SendFrameChanged(Handle);
                }
            }
        }

        


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int CurrentDpi => DpiHelper.IsPerMonitorV2Awareness ? _deviceDpi : DpiHelper.DeviceDpi;

        /// <summary>
        /// Gets and sets the active state of the window.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool IsWindowActivatedCore
        {
            get
            {
                var bv = (BitVector32)FormStateCoreField.GetValue(this);
                BitVector32.Section s = (BitVector32.Section)FormStateWindowActivatedField.GetValue(this);
                return bv[s] == 1;
            }
        }

        protected bool IsWindowActivated
        {
            get;
            private set;
        }


        private void InitializeReflectedFields()
        {
#if NETCOREAPP3_1 || NET5_0
            _clientWidthField = typeof(Control).GetField("_clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            _clientHeightField = typeof(Control).GetField("_clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
#else
            _clientWidthField = typeof(Control).GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            _clientHeightField = typeof(Control).GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
#endif
            _formStateSetClientSizeField = typeof(Form).GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
            _formStateField = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected void CheckResetDPIAutoScale(bool force = false)
        {
            if (force)
            {
                var fi = typeof(ContainerControl).GetField("currentAutoScaleDimensions", BindingFlags.NonPublic | BindingFlags.Instance);
                var dpi = IsHandleCreated ? DpiHelper.GetDpiForCurrentWindow(Handle) : 96;
                if (fi != null)
                    fi.SetValue(this, new SizeF(dpi, dpi));
            }
        }

        protected FormWindowState MinMaxState
        {
            get
            {
                var s = (int)User32.GetWindowLongPtr(Handle, WindowLongFlags.GWL_STYLE);

                var max = (s & (int)WindowStyles.WS_MAXIMIZE) > 0;
                if (max)
                    return FormWindowState.Maximized;
                var min = (s & (int)WindowStyles.WS_MINIMIZE) > 0;
                if (min)
                    return FormWindowState.Minimized;
                return FormWindowState.Normal;
            }
        }

        internal protected Rectangle RealFormRectangle
        {
            get
            {
                var windowRect = new RECT();

                User32.GetWindowRect(Handle, ref windowRect);

                return new Rectangle(0, 0, windowRect.Width, windowRect.Height);
            }
        }

        internal protected Rectangle RealFormBounds
        {
            get
            {
                var windowRect = new RECT();

                User32.GetWindowRect(Handle, ref windowRect);

                return windowRect.ToRectangle();
            }
        }

        protected virtual Padding GetNonclientArea()
        {
            RECT boundsRect = new RECT();

            Rectangle screenClient;

            CreateParams cp = this.CreateParams;

            //if (this.IsHandleCreated)
            //{
            //    screenClient = this.RectangleToScreen(this.ClientRectangle);
            //}
            //else
            //{

            //}

            screenClient = this.ClientRectangle;
            screenClient.Offset(-this.Location.X, -this.Location.Y);

            boundsRect.left = screenClient.Left;
            boundsRect.top = screenClient.Top;
            boundsRect.right = screenClient.Right;
            boundsRect.bottom = screenClient.Bottom;

            Padding result;

            AdjustWindowRectEx(ref boundsRect, cp.Style, false, cp.ExStyle);

            result = new Padding(
                        screenClient.Left - boundsRect.left,
                        screenClient.Top - boundsRect.top,
                        boundsRect.right - screenClient.Right,
                        boundsRect.bottom - screenClient.Bottom);

            return result;
        }

        internal protected void AdjustWindowRectEx(ref RECT rect, int style, bool bMenu, int exStyle)
        {
            if (DpiHelper.IsPerMonitorV2Awareness)
            {
                User32.AdjustWindowRectExForDpi(ref rect, style, bMenu, exStyle, DpiHelper.GetDpiForCurrentWindow(Handle));
            }
            else
            {
                User32.AdjustWindowRectEx(ref rect, style, bMenu, exStyle);
            }
        }

        protected virtual Size PatchFormSizeInRestoreWindowBoundsIfNecessary(int width, int height)
        {
            if (WindowState == FormWindowState.Normal)
            {
                try
                {
                    var restoredWindowBoundsSpecified = typeof(Form).GetField("restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance);
                    var restoredSpecified = (BoundsSpecified)restoredWindowBoundsSpecified.GetValue(this);

                    if ((restoredSpecified & BoundsSpecified.Size) != BoundsSpecified.None)
                    {
                        var formStateExWindowBoundsFieldInfo = typeof(Form).GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                        var formStateExFieldInfo = typeof(Form).GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                        var restoredBoundsFieldInfo = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);

                        if (formStateExWindowBoundsFieldInfo != null && formStateExFieldInfo != null && restoredBoundsFieldInfo != null)
                        {
                            var restoredWindowBounds = (Rectangle)restoredBoundsFieldInfo.GetValue(this);
                            BitVector32.Section section = (BitVector32.Section)formStateExWindowBoundsFieldInfo.GetValue(this);
                            var vector = (BitVector32)formStateExFieldInfo.GetValue(this);
                            if (vector[section] == 1)
                            {

                                width = restoredWindowBounds.Width; //+ (BorderEffect == BorderEffect.BorderLine ? FormBorders.Horizontal : 0);
                                height = restoredWindowBounds.Height;// + (BorderEffect == BorderEffect.BorderLine ? FormBorders.Vertical : 0);


                            }
                        }
                    }
                }
                catch
                {
                }
            }
            return new Size(width, height);
        }

        protected virtual Size ClientSizeFromSize(Size formSize)
        {
            if (formSize == Size.Empty)
            {
                return Size.Empty;
            }

            var sz = SizeFromClientSize(Size.Empty);

            var res = new Size(formSize.Width - sz.Width, formSize.Height - sz.Height);




            if (MinMaxState != FormWindowState.Maximized)
                return res;

            var rect = new RECT();

            var ncMargin = GetNonclientArea();

            rect.left = 0;
            rect.top = 0;
            rect.right = res.Width - ncMargin.Horizontal + sz.Width;
            rect.bottom = res.Height - ncMargin.Bottom * 2 + sz.Height;

            return new Size(rect.right, rect.bottom);
        }

        protected Region GetRoundedRegion(Rectangle rectangle)
        {
            var hRng = Gdi32.CreateRoundRectRgn(0, 0, rectangle.Width + 1, rectangle.Height + 1, 20, 20);

            var region = Region.FromHrgn(hRng);

            Gdi32.DeleteObject(hRng);

            return region;
        }


        protected void InvalidateNonClient()
        {
            InvalidateNonClient(Rectangle.Empty, true);
        }

        protected void InvalidateNonClient(Rectangle invalidRect)
        {
            InvalidateNonClient(invalidRect, true);
        }

        protected void InvalidateNonClient(Rectangle invalidRect, bool excludeClientArea)
        {
            if (!IsDisposed && !Disposing && IsHandleCreated)
            {
                if (invalidRect.IsEmpty)
                {
                    Rectangle realWindowRectangle = RealFormRectangle;

                    invalidRect = new Rectangle(realWindowRectangle.Left, realWindowRectangle.Top, realWindowRectangle.Width, realWindowRectangle.Height);
                }

                using (var invalidRegion = new Region(invalidRect))
                {
                    if (excludeClientArea)
                    {
                        var clientRect = new RECT();

                        User32.GetClientRect(Handle, ref clientRect);

                        var clientBounds = new Rectangle(clientRect.left, clientRect.top, clientRect.right, clientRect.bottom);

                        clientBounds.Offset(-clientBounds.Left, -clientBounds.Top);

                        if (BorderEffect == BorderEffect.BorderLine)
                        {
                            clientBounds.Offset(FormBorders.Left, FormBorders.Top);
                        }



                        invalidRegion.Exclude(clientBounds);
                    }

                    using (Graphics g = Graphics.FromHwnd(Handle))
                    {
                        var hRgn = invalidRegion.GetHrgn(g);

                        User32.RedrawWindow(Handle, IntPtr.Zero, hRgn, (uint)(RedrawWindowFlags.RDW_FRAME | RedrawWindowFlags.RDW_UPDATENOW | RedrawWindowFlags.RDW_INVALIDATE));

                        Gdi32.DeleteObject(hRgn);
                    }
                }
            }
        }

        private void SetRegion(Region region, Rectangle rect)
        {
            if (_regionRect == rect)
            {
                if (region != null)
                    region.Dispose();
                return;
            }

            //if (Region != null)
            //{
            //    Region.Dispose();
            //}

            Region = region;

            if (Equals(region, Region))
            {
                _regionRect = rect;
            }
        }

        private void PatchClientSize()
        {
            if (FormBorderStyle != FormBorderStyle.None)
            {
                var size = ClientSizeFromSize(Size);
                _clientWidthField.SetValue(this, size.Width);
                _clientHeightField.SetValue(this, size.Height);

            }
        }

        private void SendFrameChanged(IntPtr hWnd)
        {
            User32.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOCOPYBITS | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOREPOSITION | SetWindowPosFlags.SWP_NOSENDCHANGING | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
        }

        private void CorrectFormPostion()
        {

            if (StartPosition == FormStartPosition.CenterParent && Owner != null)
            {
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                Owner.Location.Y + Owner.Height / 2 - Height / 2);
            }
            else if (StartPosition == FormStartPosition.CenterScreen || (StartPosition == FormStartPosition.CenterParent && Owner == null))
            {
                var currentScreen = Screen.FromPoint(MousePosition);


                var initScreen = Screen.FromHandle(Handle);



                var w = RealFormRectangle.Width;
                var h = RealFormRectangle.Height;

                var screenLeft = 0;
                var screenTop = 0;

                if (DpiHelper.IsPerMonitorV2Awareness)
                {
                    var screenDpi = DpiHelper.GetScreenDpiFromPoint(MousePosition);

                    var screenScaleFactor = (screenDpi / 96f) / ScaleFactor;

                    var bounds = GetScaledBounds(RealFormRectangle, new SizeF(screenScaleFactor, screenScaleFactor), BoundsSpecified.Size);

                    w = bounds.Width;
                    h = bounds.Height;
                }

                if (currentScreen.DeviceName != initScreen.DeviceName)
                {
                    screenLeft += currentScreen.WorkingArea.Left;
                    screenTop += currentScreen.WorkingArea.Top;
                }


                User32.SetWindowPos(Handle, IntPtr.Zero, screenLeft + (currentScreen.WorkingArea.Width - w) / 2, screenTop + (currentScreen.WorkingArea.Height - h) / 2, RealFormRectangle.Width, RealFormRectangle.Height, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);


            }

        }

        internal protected bool IsMinimizedState(Rectangle bounds)
        {
            return WindowState == FormWindowState.Minimized && bounds.Location == MinimizedFormLocation;
        }

        protected Point ScreenToWindow(Point screenPt)
        {
            // First of all convert to client coordinates
            Point clientPt = PointToClient(screenPt);

            // Now adjust to take into account the top and left borders
            //Padding borders = RealWindowBorders;
            Padding borders = GetNonclientArea();
            clientPt.Offset(borders.Left, borders.Top);

            return clientPt;
        }

        private void OnNCPaint(Graphics g, Rectangle bounds)
        {
            var clientRect = new RECT();

            User32.GetClientRect(Handle, ref clientRect);

            Rectangle clientBounds = new Rectangle(clientRect.left, clientRect.top, clientRect.right, clientRect.bottom);

            clientBounds.Offset(-clientBounds.Left, -clientBounds.Top);

            if (BorderEffect == BorderEffect.BorderLine)
            {
                clientBounds.Offset(FormBorders.Left, FormBorders.Top);

                var region = new Region(bounds);

                if (WindowState == FormWindowState.Maximized)
                {
                    region.Exclude(bounds);
                }
                else
                {
                    region.Exclude(clientBounds);
                }

                var inactiveColor = Color.FromArgb(BorderColor.A, Convert.ToInt32(BorderColor.R * .6f), Convert.ToInt32(BorderColor.G * .6f), Convert.ToInt32(BorderColor.B * .6f));

                if (InactiveBorderColor.HasValue)
                {
                    inactiveColor = InactiveBorderColor.Value;
                }

                var borderColor = IsWindowActivated ? BorderColor : inactiveColor;

                g.FillRegion(new SolidBrush(borderColor), region);
            }

            if (BorderEffect == BorderEffect.RoundCorner && MinMaxState == FormWindowState.Normal)
            {
                var rect = RealFormRectangle;

                SetRegion(GetRoundedRegion(rect), rect);
            }



        }






        #region Overrides

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal protected new AutoScaleMode AutoScaleMode => AutoScaleMode.None;
        internal ShadowDecorator _shadowDecorator;

        public BorderlessWindow()
        {
            base.AutoScaleMode = AutoScaleMode.None;

            base.BackColor = Color.FromArgb(33, 33, 33);

            DpiHelper.InitializeDpiHelper();

            InitializeReflectedFields();

            _deviceDpi = DpiHelper.DeviceDpi;



            _shadowDecorator = new ShadowDecorator(this, false);

            SuspendLayout();
        }



        protected override void OnHandleCreated(EventArgs e)
        {

            try
            {
                UxTheme.SetWindowTheme(Handle, string.Empty, string.Empty);
                User32.DisableProcessWindowsGhosting();

                ScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);


            }
            catch { }

            base.OnHandleCreated(e);



            CheckResetDPIAutoScale(true);

            ResumeLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateShadows();

        }




        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                if (ScaleFactor != 1.0f)
                {
                    Scale(new SizeF(ScaleFactor, ScaleFactor));
                }

                var currentScreenScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

                var primaryScreenScaleFactor = DpiHelper.GetScreenDpi(Screen.PrimaryScreen) / 96f;

                if (primaryScreenScaleFactor != 1.0f)
                {
                    Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size / primaryScreenScaleFactor), Font.Style);
                }

                Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size * currentScreenScaleFactor), Font.Style);


                CorrectFormPostion();



            }

            _isLoaded = true;

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            IsWindowActivated = true;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            IsWindowActivated = false;
        }



        protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
        {

            var rect = base.GetScaledBounds(bounds, factor, specified);

            Size sz = SizeFromClientSize(Size.Empty);
            if (!GetStyle(ControlStyles.FixedWidth) && ((specified & BoundsSpecified.Width) != BoundsSpecified.None))
            {
                int clientWidth = bounds.Width - sz.Width;
                rect.Width = ((int)Math.Round((double)(clientWidth * factor.Width))) + sz.Width;
            }
            if (!GetStyle(ControlStyles.FixedHeight) && ((specified & BoundsSpecified.Height) != BoundsSpecified.None))
            {
                int clientHeight = bounds.Height - sz.Height;
                rect.Height = ((int)Math.Round((double)(clientHeight * factor.Height))) + sz.Height;
            }

            return rect;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {

            if (!_allowBoundsChange)
            {
                return;
            }

            if (DesignMode)
            {
                base.SetBoundsCore(x, y, width, height, specified);

                return;
            }

            if (_isMaximizedTest && WindowState != FormWindowState.Minimized)
            {
                if (y != Top)
                {
                    y = Top;

                }

                if (x != Left)
                {
                    x = Left;
                }

                _isMaximizedTest = false;
            }

            var size = PatchFormSizeInRestoreWindowBoundsIfNecessary(width, height);

            base.SetBoundsCore(x, y, size.Width, size.Height, specified);
        }

        Size startupSize = Size.Empty;


        protected override void SetClientSizeCore(int x, int y)
        {

            if (_clientWidthField != null && _clientHeightField != null && _formStateField != null && _formStateSetClientSizeField != null)
            {

                _clientWidthField.SetValue(this, x);
                _clientHeightField.SetValue(this, y);

                BitVector32.Section section = (BitVector32.Section)_formStateSetClientSizeField.GetValue(this);

                var vector = (BitVector32)_formStateField.GetValue(this);

                vector[section] = 1;

                _formStateField.SetValue(this, vector);

                OnClientSizeChanged(EventArgs.Empty);

                vector[section] = 0;

                _formStateField.SetValue(this, vector);

                Size = SizeFromClientSize(new Size(x, y));

                //Size = new Size(x, y);

                if (startupSize == Size.Empty)
                {
                    startupSize = Size;
                }

            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _shadowDecorator.Dispose();
            base.OnClosed(e);
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            //TODO:修理一下边框的大小

            //if (BorderEffect == BorderEffect.BorderLine)
            //{
            //    clientSize.Width -= FormBorders.Horizontal;
            //    clientSize.Height -= FormBorders.Vertical;
            //}

            return clientSize;
        }

        protected override void OnSizeChanged(EventArgs e)
        {


            PatchClientSize();

            base.OnSizeChanged(e);
        }




        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            var maxSizeState = MaximumSize;
            var minSizeState = MinimumSize;

            MinimumSize = Size.Empty;
            MaximumSize = Size.Empty;

            base.ScaleControl(factor, specified);


            if (minSizeState != Size.Empty)
            {
                minSizeState = new Size((int)Math.Round(minSizeState.Width * factor.Width), (int)Math.Round(minSizeState.Height * factor.Height));
            }
            if (maxSizeState != Size.Empty)
            {
                maxSizeState = new Size((int)Math.Round(maxSizeState.Width * factor.Width), (int)Math.Round(maxSizeState.Height * factor.Height));
            }

            MinimumSize = minSizeState;
            MaximumSize = maxSizeState;

        }


        public new DialogResult ShowDialog(IWin32Window owner)
        {
            return base.ShowDialog(CheckOwner(owner));
        }
        static IWin32Window CheckOwner(IWin32Window owner)
        {
            var form = owner as BorderlessWindow;
            if (form != null)
            {
                if (form.Location == InvalidPoint)
                {
                    return form.OwnedForms.FirstOrDefault(x => IsAppropriateOwner(x));
                }
            }
            return owner;
        }
        static bool IsAppropriateOwner(Form condidateForm)
        {
            return true;
        }


        #endregion

        #region Shadows
        private bool _isShown = false;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_shadowDecorator != null && !_shadowDecorator.IsEnabled && MinMaxState == FormWindowState.Normal)
            {
                PerformShadows(true);
            }
            else if (_shadowDecorator != null && MinMaxState != FormWindowState.Normal)
            {
                PerformShadows(false);
            }

            _isShown = true;

        }

        protected bool IsResizing { get; set; } = false;

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);

            IsResizing = true;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            IsResizing = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_isShown)
            {
                if (_shadowDecorator != null && !_shadowDecorator.IsEnabled && MinMaxState == FormWindowState.Normal)
                {
                    PerformShadows(true);
                }
                else if (_shadowDecorator != null && _shadowDecorator.IsEnabled && MinMaxState != FormWindowState.Normal)
                {
                    PerformShadows(false);
                }
            }
        }

        private void PerformShadows(bool enabled)
        {
            if (_shadowDecorator == null)
                return;

            if (ShadowEffect == ShadowEffect.None)
            {
                _shadowDecorator.Enable(false);

                return;

            }

            _shadowDecorator.Enable(enabled);

            if (IsWindowActivatedCore && enabled)
            {
                _shadowDecorator.SetFocus();
            }
        }



        private void UpdateShadows()
        {
            if (DesignMode || _shadowDecorator == null)
            {
                return;
            }

            if (!IsMdiChild && FormBorderStyle != FormBorderStyle.None)
            {
                _shadowDecorator.InitializeShadows();


                if (Owner != null)
                {
                    _shadowDecorator.SetOwner(Owner.Handle);
                }
                //else
                //{
                //    _shadowDecorator.SetOwner(Handle);
                //}



            }
        }

        #endregion

        #region Messages
        private bool _allowBoundsChange = true;
        private bool _isMaximizedTest;

        protected override void WndProc(ref Message m)
        {
            switch ((WindowsMessages)m.Msg)
            {
                case WindowsMessages.WM_DPICHANGED:
                    {
                        WmDpiChanged(ref m);
                        break;
                    }
                case WindowsMessages.WM_NCCALCSIZE:
                    {
                        WmNCCalcSize(ref m);

                        base.WndProc(ref m);

                        break;
                    }
                case WindowsMessages.WM_NCPAINT:
                    {
                        WmNCPaint(ref m);

                        break;
                    }
                case WindowsMessages.WM_NCACTIVATE:
                    {
                        WmNCActivate(ref m);

                        break;
                    }
                case WindowsMessages.WM_SIZE:
                    {
                        WmSize(ref m);

                        base.WndProc(ref m);

                        break;
                    }
                case WindowsMessages.WM_SYSCOMMAND:
                    {
                        WmSystemCommand(ref m);

                        break;
                    }
                case WindowsMessages.WM_ACTIVATEAPP:
                    {
                        InvalidateNonClient();
                        SendFrameChanged(Handle);
                        break;
                    }
                case WindowsMessages.WM_NCLBUTTONDOWN:
                    {

                        InvalidateNonClient();
                        SendFrameChanged(Handle);

                        base.WndProc(ref m);

                        break;
                    }
                case WindowsMessages.WM_NCLBUTTONUP:
                case WindowsMessages.WM_NCLBUTTONDBLCLK:
                    {
                        InvalidateNonClient();
                        SendFrameChanged(Handle);

                        base.WndProc(ref m);

                        break;
                    }
                case WindowsMessages.WM_NCMOUSEMOVE:
                case WindowsMessages.WM_NCMOUSELEAVE:
                case WindowsMessages.WM_NCUAHDRAWCAPTION:
                case WindowsMessages.WM_NCUAHDRAWFRAME:
                case WindowsMessages.WM_UNKNOWN_GHOST:
                    {
                        InvalidateNonClient();
                        SendFrameChanged(Handle);
                        m.Result = Win32.FALSE;
                    }

                    break;
                default:
                    {

                        base.WndProc(ref m);
                        break;
                    }
            }
        }

        private void WmSystemCommand(ref Message m)
        {
            var state = (SystemCommandFlags)m.WParam;

            if (state == SystemCommandFlags.SC_MAXIMIZE)
            {

            }

            if (state == SystemCommandFlags.SC_CLOSE)
            {
                var pi = typeof(Form).GetProperty("CloseReason", BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.NonPublic);

                pi.SetValue(this, CloseReason.UserClosing, null);
            }

            if (state != SystemCommandFlags.SC_KEYMENU)
            {
                DefWndProc(ref m);

                InvalidateNonClient();

            }
        }


        private void WmDpiChanged(ref Message m)
        {

            var oldDeviceDpi = _deviceDpi;
            var newDeviceDpi = Win32.SignedHIWORD(m.WParam);

            var suggestedRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

            ScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

            _deviceDpi = newDeviceDpi;

            var maxSizeState = MaximumSize;
            var minSizeState = MinimumSize;
            MinimumSize = Size.Empty;
            MaximumSize = Size.Empty;

            User32.SetWindowPos(Handle, IntPtr.Zero, suggestedRect.left, suggestedRect.top, suggestedRect.Width, suggestedRect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);

            var scaleFactor = (float)newDeviceDpi / oldDeviceDpi;

            MinimumSize = DpiHelper.CalcScaledSize(minSizeState, new SizeF(scaleFactor, scaleFactor));
            MaximumSize = DpiHelper.CalcScaledSize(maxSizeState, new SizeF(scaleFactor, scaleFactor));

            OnWmDpiChanged(oldDeviceDpi, newDeviceDpi, suggestedRect.ToRectangle());
        }

        private void OnWmDpiChanged(int oldDeviceDpi, int newDeviceDpi, Rectangle suggestedRectangle)
        {
            _allowBoundsChange = false;



            CheckResetDPIAutoScale(true);
            PerformLayout();
            Update();

            _allowBoundsChange = true;


            SystemDpiChanged?.Invoke(this, new WindowDpiChangedEventArgs(oldDeviceDpi, newDeviceDpi));

        }

        private void WmNCPaint(ref Message m)
        {
            if (!IsHandleCreated)
            {
                return;
            }

            Rectangle bounds = RealFormRectangle;

            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
            }

            int getDCEXFlags = (int)(DCX.WINDOW | DCX.CACHE | DCX.CLIPSIBLINGS | DCX.VALIDATE);
            IntPtr hRegion = IntPtr.Zero;

            if (m.WParam != (IntPtr)1)
            {
                getDCEXFlags |= (int)DCX.INTERSECTRGN;
                hRegion = m.WParam;
            }


            IntPtr hDC = User32.GetDCEx(Handle, hRegion, getDCEXFlags);

            try
            {
                if (hDC != IntPtr.Zero)
                {
                    using (Graphics drawingSurface = Graphics.FromHdc(hDC))
                    {
                        OnNCPaint(drawingSurface, bounds);
                    }
                }
            }
            finally
            {
                User32.ReleaseDC(m.HWnd, hDC);
            }

            m.Result = Win32.MESSAGE_PROCESS;

        }



        private void WmNCActivate(ref Message m)
        {
            IsWindowActivated = (m.WParam == Win32.TRUE);



            if (MinMaxState == FormWindowState.Minimized)
            {
                DefWndProc(ref m);
            }
            else
            {


                if (IsWindowActivated)
                {
                    _shadowDecorator.SetFocus();

                }
                else
                {
                    _shadowDecorator.KillFocus();
                }

                // Allow default processing of activation change
                m.Result = Win32.MESSAGE_HANDLED;
                // Message processed, do not pass onto base class for processing

                InvalidateNonClient();

                SendFrameChanged(Handle);

            }







        }

        private void WmSize(ref Message m)
        {

            if (DesignMode || !_isLoaded)
                return;


            var formBounds = Bounds;

            if (WindowState == FormWindowState.Maximized)
            {
                _isMaximizedTest = true;


                var screen = Screen.FromHandle(Handle);

                var bounds = FormBorderStyle == FormBorderStyle.None ? screen.Bounds : screen.WorkingArea;

                var regionBounds = new Rectangle(bounds.X - formBounds.X, bounds.Y - formBounds.Y, formBounds.Width - (formBounds.Width - bounds.Width), formBounds.Height - (formBounds.Height - bounds.Height));

                SetRegion(new Region(regionBounds), regionBounds);
            }
            else if (BorderEffect != BorderEffect.RoundCorner && WindowState == FormWindowState.Normal)
            {
                SetRegion(null, Rectangle.Empty);
            }
            else if (BorderEffect == BorderEffect.RoundCorner && MinMaxState == FormWindowState.Normal)
            {
                var rect = RealFormRectangle;

                SetRegion(GetRoundedRegion(rect), rect);
            }

            SendFrameChanged(Handle);

        }

        private void WmNCCalcSize(ref Message m)
        {
            if (m.WParam == Win32.TRUE)
            {
                var rcSize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

                var ncMargin = GetNonclientArea();

                var calculatedBorderSize = FormBorders;


                if (FormBorderStyle == FormBorderStyle.None)
                {
                    calculatedBorderSize = Padding.Empty;
                    ncMargin = Padding.Empty;
                }

                rcSize.rectProposed.top -= ncMargin.Top;
                rcSize.rectBeforeMove = rcSize.rectProposed;




                if (WindowState != FormWindowState.Maximized)
                {
                    rcSize.rectProposed.right += ncMargin.Right;
                    rcSize.rectProposed.bottom += ncMargin.Bottom;
                    rcSize.rectProposed.left -= ncMargin.Left;

                    if (BorderEffect == BorderEffect.BorderLine)
                    {
                        rcSize.rectProposed.top += calculatedBorderSize.Top;
                        rcSize.rectProposed.left += calculatedBorderSize.Left;
                        rcSize.rectProposed.right -= calculatedBorderSize.Right;
                        rcSize.rectProposed.bottom -= calculatedBorderSize.Bottom;
                    }

                }
                else if (WindowState == FormWindowState.Maximized)
                {
                    rcSize.rectProposed.top += ncMargin.Bottom;
                }


                Marshal.StructureToPtr(rcSize, m.LParam, false);
                m.Result = (IntPtr)0x0400;
            }
        }
        #endregion


    }
}
