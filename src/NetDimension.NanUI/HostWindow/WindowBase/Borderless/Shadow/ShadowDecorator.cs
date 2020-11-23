using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{


    internal static class CONSTS
    {
        internal const string CLASS_NAME = "FlatWindowShadowEffect";

    }

    internal enum ShadowDockPositon
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3

    }

    internal partial class FakeClassToDisableWinFormDesigner
    {

    }


    internal delegate void FormShadowResizeEventHandler(object sender, FormShadowResizeArgs args);
    internal class FormShadowResizeArgs : EventArgs
    {
        public ShadowDockPositon Side { get; }

        public Point ScreenPoint { get; }

        public HitTest Mode { get; }

        internal FormShadowResizeArgs(ShadowDockPositon side, HitTest mode, Point point)
        {
            Side = side;
            Mode = mode;
            ScreenPoint = point;
        }
    }

    internal class ShadowDecorator : NativeWindow
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct ANIMATIONINFO
        {
            public uint cbSize;
            public int iMinAnimate;
        };

        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction,
                                                       uint uiParam,
                                                       ref ANIMATIONINFO pvParam,
                                                       uint fWinIni);

        public static uint SPIF_SENDCHANGE = 0x02;
        public static uint SPI_SETANIMATION = 0x0049;
        public static uint SPI_GETANIMATION = 0x0048;


        private IntPtr ParentWindowHWnd => parentWindow.Handle;

        private Form parentWindow;

        private ShadowElement _topFormShadow;
        private ShadowElement _leftFormShadow;
        private ShadowElement _bottomFormShadow;
        private ShadowElement _rightFormShadow;


        private readonly List<ShadowElement> shadows = new List<ShadowElement>();
        private Color _shadowColor = Color.Black;
        private Color? _inactiveShadowColor;
        private bool _isFocused = false;
        private bool _isWindowMinimized = false;
        private bool _isAnimationDelayed = false;
        private ShadowEffect _shadowEffect = ShadowEffect.Glow;


        private Bitmap[] cachedImages;

        internal Bitmap ActiveBitmapTemplate => cachedImages?[1];
        internal Bitmap InactiveBitmapTemplate => cachedImages?[2];

        internal bool Resizable => parentWindow.FormBorderStyle == FormBorderStyle.SizableToolWindow || parentWindow.FormBorderStyle == FormBorderStyle.Sizable;

        internal int ShadowSize { get; private set; } = 20;

        private void InitializeBitmapCache()
        {
            cachedImages = new Bitmap[3];

            switch (_shadowEffect)
            {
                case ShadowEffect.Glow:


                    if (IsRoundedCornerStyle)
                    {
                        cachedImages[0] = Properties.Resources.RoundedGlowShadow;
                        ShadowSize = 15;
                    }
                    else
                    {
                        cachedImages[0] = Properties.Resources.GlowShadow;
                        ShadowSize = 10;
                    }
                    break;
                case ShadowEffect.DropShadow:

                    if (IsRoundedCornerStyle)
                    {
                        cachedImages[0] = Properties.Resources.RoundedDropShadow;
                        ShadowSize = 30;
                    }
                    else
                    {
                        cachedImages[0] = Properties.Resources.DropShadow;
                        ShadowSize = 25;
                    }
                    break;
                default:


                    if (IsRoundedCornerStyle)
                    {
                        cachedImages[0] = Properties.Resources.RoundedShadow;
                        ShadowSize = 25;
                    }
                    else
                    {
                        cachedImages[0] = Properties.Resources.Shadow;
                        ShadowSize = 20;
                    }
                    break;
            }

            var rawImage = cachedImages[0];
            var activeImageCore = cachedImages[1] = (Bitmap)rawImage.Clone();
            var inactiveImageCore = cachedImages[2] = (Bitmap)rawImage.Clone();

            BlendBitmapWithColor(activeImageCore, ShadowColor);

            if (InactiveShadowColor.HasValue)
            {
                BlendBitmapWithColor(inactiveImageCore, InactiveShadowColor.Value);
            }
            else
            {
                BlendBitmapWithColor(inactiveImageCore, ShadowColor, 0.6f);
            }

        }

        public bool IsInitialized { get; private set; } = false;
        public bool IsEnabled { get; private set; }

        private bool _isRoundedCorner = false;
        internal bool IsRoundedCornerStyle
        {
            get => _isRoundedCorner;
            set
            {
                if (value != _isRoundedCorner)
                {
                    _isRoundedCorner = value;


                }
            }
        }

        internal bool IsBorderLineStyle { get; set; }

        internal ShadowEffect ShadowEffect
        {
            get
            {
                return _shadowEffect;
            }
            set
            {
                if (_shadowEffect != value)
                {
                    _shadowEffect = value;

                    InitializeBitmapCache();
                }


            }
        }

        internal Color ShadowColor
        {
            get
            {
                return _shadowColor;
            }

            set
            {

                if (_shadowColor == value)
                    return;

                _shadowColor = value;


                InitializeBitmapCache();



                if (!IsInitialized)
                    return;

                foreach (var sideShadow in shadows)
                {
                    sideShadow.UpdateShadow();
                }
            }
        }

        internal Color? InactiveShadowColor
        {
            get
            {
                return _inactiveShadowColor;
            }

            set
            {
                if (_inactiveShadowColor == value)
                    return;

                _inactiveShadowColor = value;

                InitializeBitmapCache();

                if (!IsInitialized)
                    return;

                foreach (var sideShadow in shadows)
                {
                    sideShadow.UpdateShadow();
                }
            }
        }



        public void InitializeShadows()
        {
            _topFormShadow = new ShadowElement(ShadowDockPositon.Top, ParentWindowHWnd, this);
            _leftFormShadow = new ShadowElement(ShadowDockPositon.Left, ParentWindowHWnd, this);
            _bottomFormShadow = new ShadowElement(ShadowDockPositon.Bottom, ParentWindowHWnd, this);
            _rightFormShadow = new ShadowElement(ShadowDockPositon.Right, ParentWindowHWnd, this);

            shadows.Add(_topFormShadow);
            shadows.Add(_leftFormShadow);
            shadows.Add(_bottomFormShadow);
            shadows.Add(_rightFormShadow);

            User32.ShowWindow(_topFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(_leftFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(_bottomFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(_rightFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);

            _topFormShadow.ExternalResizeEnable = Resizable;
            _leftFormShadow.ExternalResizeEnable = Resizable;
            _bottomFormShadow.ExternalResizeEnable = Resizable;
            _rightFormShadow.ExternalResizeEnable = Resizable;


            IsInitialized = true;

            AssignHandle(ParentWindowHWnd);
            
            AlignSideShadowToTopMost();



            //Enable(true);





            if (ShadowColor == _shadowColor)
            {
                InitializeBitmapCache();
            }
            // ShadowColor = _shadowColor;

            // InactiveShadowColor = _inactiveShadowColor;


        }

        public void Enable(bool enable)
        {
            if ((IsEnabled && !enable) || _shadowEffect == ShadowEffect.None)
            {
                ShowBorder(false);
                UnregisterEvents();
            }
            else if (!IsEnabled && enable)
            {
                RegisterEvents();
                if (parentWindow != null)
                {
                    UpdateLocations(new WINDOWPOS
                    {
                        x = parentWindow.Left,
                        y = parentWindow.Top,
                        cx = parentWindow.Width,
                        cy = parentWindow.Height,
                        //flags = (uint)SetWindowPosFlags.SWP_SHOWWINDOW
                    });

                    //UpdateSizes(parentWindow.Width, parentWindow.Height);
                }
            }

            IsEnabled = enable;
        }

        public void SetOwner(IntPtr owner)
        {
            foreach (ShadowElement sideShadow in shadows)
            {
                sideShadow.SetOwner(owner);
            }
        }
        public void SetFocus()
        {
            if (!IsEnabled)
                return;

            UpdateFocus(true);

            UpdateZOrder();
        }
        public void KillFocus()
        {
            if (!IsEnabled)
                return;

            UpdateFocus(false);

            UpdateZOrder();
        }

        private void UpdateZOrder()
        {
            foreach (var shadow in shadows)
            {
                shadow.UpdateZOrder();
            }
        }

        public ShadowDecorator(BorderlessWindow window, bool enable = true)
        {

            parentWindow = window;
            IsEnabled = enable;
        }

        private void BlendBitmapWithColor(Bitmap source, Color color, float? alphaDepth = null)
        {
            var rect = new Rectangle(0, 0, source.Width, source.Height);


            var alpha = 1f;


            if (alphaDepth != null)
            {
                if (alphaDepth <= 1f)
                {
                    alpha = alphaDepth.Value;
                }
            }
            else
            {
                alpha = color.A / 255f;
            }


            var bmp = new LockBitmap(source);
            bmp.LockBits();

            for (var y = rect.Top; y < rect.Bottom; y++)
            {
                for (var x = rect.Left; x < rect.Right; x++)
                {
                    var targetColor = bmp.GetPixel(x, y);

                    var a = Convert.ToByte(targetColor.A * alpha);

                    var r = color.R;
                    var g = color.G;
                    var b = color.B;

                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            bmp.UnlockBits();
        }



        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {

            if (IsDisposed)
            {
                base.WndProc(ref m);
                return;
            }


            switch ((WindowsMessages)m.Msg)
            {
                case WindowsMessages.WM_WINDOWPOSCHANGED:
                    {
                        base.WndProc(ref m);

                        WmWindowPosChanged(ref m);


                        break;
                    }
                case WindowsMessages.WM_ACTIVATEAPP:
                    {
                        var className = new StringBuilder(256);

                        if (m.LParam != IntPtr.Zero && User32.GetClassName(m.LParam, className, className.Capacity) != 0)
                        {
                            var hWndShadow = m.LParam;
                            var name = className.ToString();
                            if (name.StartsWith(CONSTS.CLASS_NAME) && _isFocused && shadows.Exists(p => p.Handle == hWndShadow))
                            {
                                return;
                            }
                        }


                        if (m.WParam == Win32.FALSE)
                        {
                            _isFocused = false;
                            KillFocus();
                        }
                        else
                        {
                            _isFocused = true;
                            SetFocus();
                        }

                    }
                    break;
                case WindowsMessages.WM_SIZE:
                    {

                        base.WndProc(ref m);
                        WmSize(m.WParam, m.LParam);

                        break;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }

        }

        private void WmWindowPosChanged(ref Message m)
        {
            if (!IsEnabled)
                return;

            var windowpos = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));

            UpdateLocations(new WINDOWPOS
            {
                x = windowpos.x,
                y = windowpos.y,
                cx = windowpos.cx,
                cy = windowpos.cy
            });
        }

        private void WmSize(IntPtr wParam, IntPtr lParam)
        {
            if ((int)wParam == 1)
            {
                _isWindowMinimized = true;
            }

            if (!IsEnabled)
                return;

            // maximized/minimized
            if ((int)wParam == 2 || (int)wParam == 1)
            {
                ShowBorder(false);

            }
            else
            {
                var rect = new RECT();

                User32.GetWindowRect(parentWindow.TopLevelControl?.Handle ?? parentWindow.Handle, ref rect);

                ShowBorder(true);

            }
        }

        private void DestroyShadows()
        {

            CloseShadows();

            parentWindow = null;
        }

        private void RegisterEvents()
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.MouseDown += HandleSideMouseDown;
            }

            if (parentWindow != null)
            {
                parentWindow.VisibleChanged += HandleWindowVisibleChanged;
            }
        }

        private void UnregisterEvents()
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.MouseDown -= HandleSideMouseDown;
            }

            if (parentWindow != null)
            {
                parentWindow.VisibleChanged -= HandleWindowVisibleChanged;
            }
        }

        private void HandleWindowVisibleChanged(object sender, EventArgs e)
        {
            ShowBorder(parentWindow?.Visible??false);
        }

        private void HandleSideMouseDown(object sender, FormShadowResizeArgs e)
        {
            if (e.Mode == HitTest.HTNOWHERE || e.Mode == HitTest.HTCAPTION)
            {
                return;
            }

            if (Resizable)
            {
                User32.PostMessage(ParentWindowHWnd, (uint)WindowsMessages.WM_SYSCOMMAND, (IntPtr)(GetSizeMode(e.Mode)), IntPtr.Zero);
            }

        }

        private int GetSizeMode(HitTest handles)
        {
            switch (handles)
            {
                case HitTest.HTNOWHERE:
                case HitTest.HTCAPTION:
                    return 0;
                case HitTest.HTLEFT:
                    return (int)ResizeDirection.Left;
                case HitTest.HTRIGHT:
                    return (int)ResizeDirection.Right;
                case HitTest.HTTOP:
                    return (int)ResizeDirection.Top;
                case HitTest.HTTOPLEFT:
                    return (int)ResizeDirection.TopLeft;
                case HitTest.HTTOPRIGHT:
                    return (int)ResizeDirection.TopRight;
                case HitTest.HTBOTTOM:
                    return (int)ResizeDirection.Bottom;
                case HitTest.HTBOTTOMLEFT:
                    return (int)ResizeDirection.BottomLeft;
                case HitTest.HTBOTTOMRIGHT:
                    return (int)ResizeDirection.BottomRight;
                default:
                    return 0;
            }

        }

        private void CloseShadows()
        {
            //Enable(false);

            foreach (var sideShadow in shadows)
            {
                sideShadow.Close();
            }

            shadows.Clear();

            _topFormShadow = null;
            _bottomFormShadow = null;
            _leftFormShadow = null;
            _rightFormShadow = null;
        }

        private void ShowBorder(bool show)
        {
            var action = new Action(() =>
            {

                foreach (var sideShadow in shadows)
                {
                    sideShadow.Show(show);
                }

                if (show)
                {
                    _isWindowMinimized = false;
                }
            });

            var isMinimized = User32.IsIconic(Handle);

            if (show == true && _isWindowMinimized)
            {
                if (_isAnimationDelayed)
                {
                    return;
                }

                _isAnimationDelayed = true;

                Task.Run(async () =>
                {
                    await Task.Delay(200);

                    if (_isAnimationDelayed)
                        parentWindow.Invoke(new MethodInvoker(action));

                    _isAnimationDelayed = false;

                });

            }
            else
            {
                action();

                _isAnimationDelayed = false;
            }

        }

        private void UpdateFocus(bool isFocused)
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.ParentWindowIsFocused = isFocused;
            }


        }


        private void UpdateLocations(WINDOWPOS location)
        {
            var hDWP = User32.BeginDeferWindowPos(4);

            foreach (var sideShadow in shadows)
            {
                sideShadow.SetWindowPos(hDWP, location);
            }

            User32.EndDeferWindowPos(hDWP);

            if ((location.flags & (uint)SetWindowPosFlags.SWP_HIDEWINDOW) != 0)
            {
                ShowBorder(false);
            }
            else if ((location.flags & (uint)SetWindowPosFlags.SWP_SHOWWINDOW) != 0)
            {
                ShowBorder(true);
            }

        }

        private void AlignSideShadowToTopMost()
        {
            if (shadows == null)
            {
                return;
            }

            UpdateLocations(new WINDOWPOS
            {
                flags = (uint)(SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE)
            });
        }






        #region Dispose

        private bool _isDisposed;


        /// <summary>
        /// IsDisposed status
        /// </summary>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Standard Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">True if disposing, false otherwise</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // release unmanaged resources
                }

                _isDisposed = true;

                UnregisterEvents();

                DestroyShadows();


                this.ReleaseHandle();

                parentWindow = null;
            }
        }

        #endregion

    }
}
