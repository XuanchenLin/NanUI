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

    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    public partial class BorderlessWindow : Form
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









    }
}
