using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NetDimension.WinForm.Win32;

namespace NetDimension.WinForm
{
    internal static class CONSTS
    {
        internal const string CLASS_NAME = "NetDimensionChromeShadowWindow";

    }

    internal enum ShadowDockPositon
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3

    }

    internal delegate void FormShadowResizeEventHandler(object sender, FormShadowResizeArgs args);
    internal class FormShadowResizeArgs : EventArgs
    {
        private readonly ShadowDockPositon _side;
        private readonly HitTest _mode;
        private readonly Point _point;

        public ShadowDockPositon Side
        {
            get { return _side; }
        }

        public Point ScreenPoint
        {
            get
            {
                return _point;
            }
        }

        public HitTest Mode
        {
            get { return _mode; }
        }

        internal FormShadowResizeArgs(ShadowDockPositon side, HitTest mode, Point point)
        {
            _side = side;
            _mode = mode;
            _point = point;
        }
    }

    internal class ChromeDecorator : NativeWindow
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


        private IntPtr parentWindowHWnd => parentWindow.Handle;
        private Form parentWindow;

        private ChromeShadowElement topFormShadow;
        private ChromeShadowElement leftFormShadow;
        private ChromeShadowElement bottomFormShadow;
        private ChromeShadowElement rightFormShadow;

        private WINDOWPOS lastLocation;

        private readonly List<ChromeShadowElement> shadows = new List<ChromeShadowElement>();
        private Color shadowColor = Color.Black;

        private bool isEnabled;
        private bool isFocused = false;
        private bool isWindowMinimized = false;
        private bool isAnimationDelayed = false;

        private bool isInitialized = false;

        private Bitmap[] cachedImages;

        internal Bitmap ActiveBitmapTemplate => cachedImages?[1];
        internal Bitmap InactiveBitmapTemplate => cachedImages?[2];

        internal bool Resizable => parentWindow.FormBorderStyle == FormBorderStyle.SizableToolWindow || parentWindow.FormBorderStyle == FormBorderStyle.Sizable;

        public Color ShadowColor
        {
            get
            {
                return shadowColor;
            }

            set
            {
                shadowColor = value;


                InitializeBitmapCache();



                if (!isInitialized) return;

                foreach (var sideShadow in shadows)
                {
                    sideShadow.UpdateShadow();
                }
            }
        }

        public bool IsInitialized => isInitialized;
        public bool IsEnabled => isEnabled;
        public void InitializeShadows()
        {
            topFormShadow = new ChromeShadowElement(ShadowDockPositon.Top, parentWindowHWnd, this);
            leftFormShadow = new ChromeShadowElement(ShadowDockPositon.Left, parentWindowHWnd, this);
            bottomFormShadow = new ChromeShadowElement(ShadowDockPositon.Bottom, parentWindowHWnd, this);
            rightFormShadow = new ChromeShadowElement(ShadowDockPositon.Right, parentWindowHWnd, this);

            shadows.Add(topFormShadow);
            shadows.Add(leftFormShadow);
            shadows.Add(bottomFormShadow);
            shadows.Add(rightFormShadow);

            User32.ShowWindow(topFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(leftFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(bottomFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
            User32.ShowWindow(rightFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);

            topFormShadow.ExternalResizeEnable = Resizable;
            leftFormShadow.ExternalResizeEnable = Resizable;
            bottomFormShadow.ExternalResizeEnable = Resizable;
            rightFormShadow.ExternalResizeEnable = Resizable;


            isInitialized = true;

            AssignHandle(parentWindowHWnd);

            AlignSideShadowToTopMost();

            ShadowColor = shadowColor;


        }

        public void Enable(bool enable)
        {
            if (isEnabled && !enable)
            {
                ShowBorder(false);
                UnregisterEvents();
            }
            else if (!isEnabled && enable)
            {
                RegisterEvents();
                if (parentWindow != null)
                {


                    UpdateSizes(parentWindow.Width, parentWindow.Height);


                    UpdateLocations(new WINDOWPOS
                    {
                        x = parentWindow.Left,
                        y = parentWindow.Top,
                        cx = parentWindow.Width,
                        cy = parentWindow.Height,
                        flags = (uint)SetWindowPosFlags.SWP_SHOWWINDOW
                    });

                }
            }

            isEnabled = enable;
        }

        public void SetOwner(IntPtr owner)
        {
            foreach (ChromeShadowElement sideShadow in shadows)
            {
                sideShadow.SetOwner(owner);
            }
        }
        public void SetFocus()
        {
            if (!isEnabled) return;
            UpdateFocus(true);
        }
        public void KillFocus()
        {
            if (!isEnabled) return;

            UpdateFocus(false);
        }

        public ChromeDecorator(Form window, bool enable = true)
        {
            //ANIMATIONINFO ai = new ANIMATIONINFO();
            //ai.cbSize =(uint)Marshal.SizeOf(ai);
            //ai.iMinAnimate = 400;   // turn all animation off
            //SystemParametersInfo(SPI_GETANIMATION, (uint)Marshal.SizeOf(typeof(ANIMATIONINFO)), ref ai, 0);

            parentWindow = window;
            isEnabled = enable;

            cachedImages = new Bitmap[3];
            cachedImages[0] = NetDimension.NanUI.Properties.Resources.ShadowTemplate;
            InitializeBitmapCache();
        }

        private void InitializeBitmapCache()
        {
            var rawImage = cachedImages[0];
            var activeImageCore = cachedImages[1] = (Bitmap)rawImage.Clone();
            var inactiveImageCore = cachedImages[2] = (Bitmap)rawImage.Clone();
            BlendBitmapWithColor(activeImageCore, ShadowColor);
            BlendBitmapWithColor(inactiveImageCore, ShadowColor, 0.6f);
        }

        private void BlendBitmapWithColor(Bitmap source, Color color, float alphaDepth = 1f)
        {
            var rect = new Rectangle(0, 0, source.Width, source.Height);
            if (alphaDepth > 1) alphaDepth = 1;

            var bmp = new LockBitmap(source);
            bmp.LockBits();

            for (var y = rect.Top; y < rect.Bottom; y++)
            {
                for (var x = rect.Left; x < rect.Right; x++)
                {
                    var targetColor = bmp.GetPixel(x, y);

                    var alpha = Convert.ToByte(targetColor.A * alphaDepth);

                    var r = color.R;
                    var g = color.G;
                    var b = color.B;

                    bmp.SetPixel(x, y, Color.FromArgb(alpha, r, g, b));
                }
            }

            bmp.UnlockBits();
        }

        protected override void WndProc(ref Message m)
        {

            if (!isEnabled || IsDisposed)
            {
                base.WndProc(ref m);
                return;
            }
            var msg = (WindowsMessages)m.Msg;


            switch (msg)
            {

                case WindowsMessages.WM_WINDOWPOSCHANGED:
                    lastLocation = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
                    WindowPosChanged(lastLocation);
                    base.WndProc(ref m);
                    break;
                case WindowsMessages.WM_ACTIVATEAPP:
                    {
                        var className = new StringBuilder(256);

                        if (m.LParam != IntPtr.Zero && User32.GetClassName(m.LParam, className, className.Capacity) != 0)
                        {
                            var hWndShadow = m.LParam;
                            var name = className.ToString();
                            if (name.StartsWith(CONSTS.CLASS_NAME) && isFocused && shadows.Exists(p => p.Handle == hWndShadow))
                            {
                                return;
                            }
                        }


                        if (m.WParam == Win32.FALSE)
                        {
                            isFocused = false;
                            KillFocus();
                        }
                        else
                        {
                            isFocused = true;
                            SetFocus();
                        }

                    }
                    break;

                case WindowsMessages.WM_SIZE:

                    base.WndProc(ref m);

                    Size(m.WParam, m.LParam);

                    break;
                default:
                    base.WndProc(ref m);
                    break;
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

        private void HandleWindowVisibleChanged(object sender, EventArgs e)
        {
            ShowBorder(parentWindow.Visible);
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

        private void HandleSideMouseDown(object sender, FormShadowResizeArgs e)
        {
            if (e.Mode == HitTest.HTNOWHERE || e.Mode == HitTest.HTCAPTION)
            {
                return;
            }

            if (Resizable)
            {
                User32.SendMessage(parentWindowHWnd, (uint)WindowsMessages.WM_SYSCOMMAND, (IntPtr)(GetSizeMode(e.Mode)), IntPtr.Zero);
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
            foreach (var sideShadow in shadows)
            {
                sideShadow.Close();
            }

            shadows.Clear();

            topFormShadow = null;
            bottomFormShadow = null;
            leftFormShadow = null;
            rightFormShadow = null;
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
                    isWindowMinimized = false;
                }
            });

            if (show == true && isWindowMinimized)
            {
                if (isAnimationDelayed)
                {
                    return;
                }

                isAnimationDelayed = true;
                Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(300);
                    if (isAnimationDelayed)
                        parentWindow.Invoke(new MethodInvoker(action));

                    isAnimationDelayed = false;

                });

            }
            else
            {
                action();

                isAnimationDelayed = false;
            }

        }

        private void UpdateFocus(bool isFocused)
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.ParentWindowIsFocused = isFocused;
            }


        }

        private void UpdateSizes(int width, int height)
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.SetSize(width, height);
            }
        }

        private void UpdateLocations(WINDOWPOS location)
        {
            foreach (var sideShadow in shadows)
            {
                sideShadow.SetLocation(location);
            }

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

            foreach (var sideShadow in shadows)
            {
                sideShadow.UpdateZOrder();
            }
        }




        private void WindowPosChanged(WINDOWPOS location)
        {
            if (!isEnabled) return;
            UpdateLocations(location);
        }


        private void Size(IntPtr wParam, IntPtr lParam)
        {
            int width = (int)User32.LOWORD(lParam);
            int height = (int)User32.HIWORD(lParam);

            if (!isEnabled) return;

            if ((int)wParam == 2 || (int)wParam == 1) // maximized/minimized
            {

                if ((int)wParam == 1)
                {
                }

                isWindowMinimized = true;


                ShowBorder(false);

            }
            else
            {
                var rect = new RECT();

                User32.GetWindowRect(parentWindow.TopLevelControl != null ? parentWindow.TopLevelControl.Handle : parentWindow.Handle, ref rect);

                UpdateSizes(rect.right - rect.left, rect.bottom - rect.top);
                ShowBorder(true);

            }
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

                DestroyShadows();

                UnregisterEvents();

                this.ReleaseHandle();

                parentWindow = null;
            }
        }

        #endregion

    }
}
