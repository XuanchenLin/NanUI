using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vortice;
using Vortice.Direct2D1;

namespace NetDimension.NanUI.HostWindow
{


    internal class ShadowElement : IDisposable
    {
        private GCHandle gcHandle;

        #region private
        private const int ERROR_CLASS_ALREADY_EXISTS = 1410;
        private bool _disposed;
        private readonly IntPtr _parentHandle;
        private readonly ShadowDecorator _decorator;
        private Size _cachedSize = Size.Empty;

        private WndProcHandler _wndProcDelegate;

        const int AcSrcOver = 0x00;
        const int AcSrcAlpha = 0x01;

        const int ROUND_CORNER_SIZE = 5;

        protected int ShadowSize => _decorator.ShadowSize;
        private readonly ShadowDockPositon _side;
        private const SetWindowPosFlags SWP_NOSIZE_NOMOVE = (SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE);

        private bool _parentWindowIsFocused;

        private readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private readonly IntPtr HWND_TOPMOST = new IntPtr(-1);


        ID2D1Factory _d2dFactory = null;
        ID2D1DCRenderTarget _renderTarget = null;

        private IntPtr _screenDC;
        private IntPtr _memDC;



        #endregion

        #region constuctor


        internal ShadowElement(ShadowDockPositon side, IntPtr parent, ShadowDecorator decorator)
        {
            _side = side;
            _parentHandle = parent;
            _decorator = decorator;


            CreateWindow($"{CONSTS.CLASS_NAME}_{side}_{parent}");
        }

        internal void SetOwner(IntPtr owner)
        {
            User32.SetWindowLongPtr(Handle, WindowLongFlags.GWL_HWNDPARENT, owner);
        }

        #endregion

        #region internal

        internal bool ExternalResizeEnable { get; set; }

        internal event FormShadowResizeEventHandler MouseDown;

        private int _view_width;
        private int _view_height;

        private int _view_top;
        private int _view_left;

        private int _lastUpdateHeight, _lastUpdateWidth;


        internal void SetWindowPos(IntPtr hDWP, WINDOWPOS pos)
        {
            var left = 0;
            var top = 0;
            var width = pos.cx;
            var height = pos.cy;

            var isPosChanged = false;
            var isSizeChanged = false;

            switch (_side)
            {
                case ShadowDockPositon.Top:
                    left = pos.x - ShadowSize;
                    top = pos.y - ShadowSize;

                    if (_decorator.IsRoundedCornerStyle)
                    {
                        top += ROUND_CORNER_SIZE;
                        left += ROUND_CORNER_SIZE;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        top += 1;
                        left += 1;
                    }

                    break;
                case ShadowDockPositon.Bottom:
                    left = pos.x - ShadowSize;
                    top = pos.y + pos.cy;
                    if (_decorator.IsRoundedCornerStyle)
                    {
                        top -= ROUND_CORNER_SIZE;
                        left += ROUND_CORNER_SIZE;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        top -= 1;
                        left += 1;
                    }

                    break;
                case ShadowDockPositon.Left:
                    left = pos.x - ShadowSize;
                    top = pos.y;
                    if (_decorator.IsRoundedCornerStyle)
                    {
                        top += ROUND_CORNER_SIZE;
                        left += ROUND_CORNER_SIZE;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        top += 1;
                        left += 1;
                    }

                    break;
                case ShadowDockPositon.Right:
                    left = pos.x + pos.cx;
                    top = pos.y;
                    if (_decorator.IsRoundedCornerStyle)
                    {
                        top += ROUND_CORNER_SIZE;
                        left -= ROUND_CORNER_SIZE;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        top += 1;
                        left -= 1;
                    }
                    break;
            }

            if (/*!isNoMoveFlag && */(top != _view_top || left != _view_left))
            {
                _view_top = top;
                _view_left = left;

                isPosChanged = true;
            }


            if (pos.cx != 0 && pos.cy != 0/* && !isNoSizeFlag*/)
            {
                if (_side == ShadowDockPositon.Top || _side == ShadowDockPositon.Bottom)
                {
                    height = ShadowSize;
                    width = width + ShadowSize * 2;

                    if (_decorator.IsRoundedCornerStyle)
                    {
                        width -= 10;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        width -= 2;
                    }
                }
                else
                {
                    width = ShadowSize;

                    if (_decorator.IsRoundedCornerStyle)
                    {
                        height -= 10;
                    }
                    else if (_decorator.IsBorderLineStyle)
                    {
                        height -= 2;
                    }
                }





                if (width != _view_width || height != _view_height)
                {


                    _view_width = width;
                    _view_height = height;

                    DiscardDeviceResource();

                    isSizeChanged = true;

                }
            }

            var dwpFlags = (SetWindowPosFlags)pos.flags | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOZORDER;

            if (!isSizeChanged)
            {
                dwpFlags |= SetWindowPosFlags.SWP_NOSIZE;
            }
            else
            {
                Render();
            }

            if (!isPosChanged)
            {
                dwpFlags |= SetWindowPosFlags.SWP_NOMOVE;
            }

            User32.DeferWindowPos(hDWP, Handle, !IsTopMost ? HWND_NOTOPMOST : HWND_TOPMOST, left, top, width, height, (uint)dwpFlags);

            User32.DeferWindowPos(hDWP, Handle, _parentHandle, 0, 0, 0, 0, (uint)(SWP_NOSIZE_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE));


        }


        internal void UpdateZOrder()
        {
            User32.SetWindowPos(Handle, !IsTopMost ? HWND_NOTOPMOST : HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);

            User32.SetWindowPos(Handle, _parentHandle, 0, 0, 0, 0, SWP_NOSIZE_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE);

            Render(true);
        }



        internal void UpdateShadow()
        {
            Render(true);
        }


        internal IntPtr Handle { get; private set; }

        internal bool ParentWindowIsFocused
        {
            set
            {
                var needRefresh = false;
                
                if (_parentWindowIsFocused != value)
                {
                    needRefresh = true;
                }

                _parentWindowIsFocused = value;

                if (needRefresh)
                    Render(true);
            }
        }

        internal bool IsTopMost { get; set; }

        internal void Show(bool show)
        {
            const int swShowNoActivate = 4;

            User32.ShowWindow(Handle, (short)(show ? swShowNoActivate : 0));
        }

        internal void Close()
        {
            User32.SetParent((int)Handle, 0);

            User32.CloseWindow(Handle);

            User32.DestroyWindow(Handle);
        }

        #endregion

        #region private



        private void CreateWindow(string className)
        {
            if (className == null)
                throw new Exception("class_name is null");
            if (className == String.Empty)
                throw new Exception("class_name is empty");

            _wndProcDelegate = CustomWndProc;

            gcHandle = GCHandle.Alloc(_wndProcDelegate);

            WNDCLASS windClass = new WNDCLASS
            {
                lpszClassName = className,
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate)
            };

            ushort classAtom = User32.RegisterClassW(ref windClass);

            int lastError = Marshal.GetLastWin32Error();

            if (classAtom == 0 && lastError != ERROR_CLASS_ALREADY_EXISTS)
            {
                throw new Exception("Could not register window class");
            }

            uint extendedStyle = (uint)(
                WindowExStyles.WS_EX_LEFT |
                WindowExStyles.WS_EX_LTRREADING |
                WindowExStyles.WS_EX_RIGHTSCROLLBAR |
                WindowExStyles.WS_EX_TOOLWINDOW);




            const uint style = (uint)(
                WindowStyles.WS_CLIPSIBLINGS |
                WindowStyles.WS_CLIPCHILDREN |
                WindowStyles.WS_POPUP);


            // Create window
            Handle = User32.CreateWindowExW(
                extendedStyle,
                className,
                className,
                style,
                0,
                0,
                0,
                0,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero
            );

            if (Handle == IntPtr.Zero)
            {
                return;
            }

            var styles = (int)User32.GetWindowLongPtr(Handle, WindowLongFlags.GWL_EXSTYLE);

            //var owner = User32.GetWindow(_parentHandle, 4);

            //User32.SetWindowLong(Handle, GetWindowLongFlags.GWL_HWNDPARENT, owner);

            styles |= (int)(WindowExStyles.WS_EX_LAYERED | WindowExStyles.WS_EX_NOACTIVATE | WindowExStyles.WS_EX_NOPARENTNOTIFY);

            if (!_decorator.Resizable)
            {
                styles |= (int)WindowExStyles.WS_EX_TRANSPARENT;
            }

            User32.SetWindowLongPtr(Handle, WindowLongFlags.GWL_EXSTYLE, new IntPtr(styles));

            _screenDC = User32.GetDC(IntPtr.Zero);
            _memDC = Gdi32.CreateCompatibleDC(_screenDC);

            D2D1.D2D1CreateFactory(FactoryType.SingleThreaded, out _d2dFactory);

        }


        private IntPtr CustomWndProc(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam)
        {

            var msg = (WindowsMessages)message;



            if (msg == WindowsMessages.WM_LBUTTONDOWN)
            {
                var point = Win32.GetPostionFromPtr(lParam);
                User32.ClientToScreen(hWnd, ref point);

                if (User32.GetActiveWindow() != _parentHandle)
                {
                    User32.SetFocus(_parentHandle);
                }

                CastMouseDown(new Point(point.x, point.y));
            }

            if (msg == WindowsMessages.WM_SETFOCUS)
            {
                User32.SendMessage(_parentHandle, message, hWnd, IntPtr.Zero);
                UpdateZOrder();
            }

            if (msg == WindowsMessages.WM_SIZE)
            {
                int width = Win32.SignedLOWORD(lParam);
                int height = Win32.SignedHIWORD(lParam);

                if (width != _lastUpdateWidth || height != _lastUpdateHeight)
                {
                    UpdateLayeredWindow();
                }
            }


            if (msg == WindowsMessages.WM_SETCURSOR)
            {
                SetCursor();
                return new IntPtr(1);
            }

            return User32.DefWindowProcW(hWnd, message, wParam, lParam);
        }


        private (Rectangle srcNearCornerRect, Rectangle srcFarCornerRect, Rectangle srcRect, Rectangle destNearCornerRect, Rectangle destFarCornerRect, Rectangle destRect) GetShadowMetrics(Bitmap cachedBmp, int width, int height)
        {
            switch (_side)
            {
                case ShadowDockPositon.Left:
                    {
                        var srcNearCornerRect = new Rectangle(0, ShadowSize, ShadowSize, ShadowSize);
                        var destNearCornerRect = new Rectangle(0, 0, ShadowSize, ShadowSize);

                        var srcFarCornerRect = new Rectangle(0, cachedBmp.Height - ShadowSize * 2, ShadowSize, ShadowSize);
                        var destFarCornerRect = new Rectangle(0, height - ShadowSize, ShadowSize, ShadowSize);

                        var srcRect = new Rectangle(0, ShadowSize * 2, ShadowSize, cachedBmp.Height - ShadowSize * 4);
                        var destRect = new Rectangle(0, ShadowSize, ShadowSize, height - ShadowSize * 2);



                        return (srcNearCornerRect, srcFarCornerRect, srcRect, destNearCornerRect, destFarCornerRect, destRect);
                    }

                case ShadowDockPositon.Right:
                    {
                        var srcNearCornerRect = new Rectangle(cachedBmp.Width - ShadowSize, ShadowSize, ShadowSize, ShadowSize);
                        var destNearCornerRect = new Rectangle(width - ShadowSize, 0, ShadowSize, ShadowSize);

                        var srcFarCornerRect = new Rectangle(cachedBmp.Width - ShadowSize, cachedBmp.Height - ShadowSize * 2, ShadowSize, ShadowSize);
                        var destFarCornerRect = new Rectangle(width - ShadowSize, height - ShadowSize, ShadowSize, ShadowSize);

                        var srcRect = new Rectangle(cachedBmp.Width - ShadowSize, ShadowSize * 2, ShadowSize, cachedBmp.Height - ShadowSize * 4);
                        var destRect = new Rectangle(width - ShadowSize, ShadowSize, ShadowSize, height - ShadowSize * 2);



                        return (srcNearCornerRect, srcFarCornerRect, srcRect, destNearCornerRect, destFarCornerRect, destRect);
                    }

                case ShadowDockPositon.Top:
                    {
                        var srcNearCornerRect = new Rectangle(0, 0, ShadowSize * 2, ShadowSize);
                        var destNearCornerRect = new Rectangle(0, 0, ShadowSize * 2, ShadowSize);

                        var srcFarCornerRect = new Rectangle(cachedBmp.Width - ShadowSize * 2, 0, ShadowSize * 2, ShadowSize);
                        var destFarCornerRect = new Rectangle(width - ShadowSize * 2, 0, ShadowSize * 2, ShadowSize);

                        var srcRect = new Rectangle(ShadowSize * 2, 0, cachedBmp.Width - ShadowSize * 4, ShadowSize);
                        var destRect = new Rectangle(ShadowSize * 2, 0, width - ShadowSize * 4, ShadowSize);

                        return (srcNearCornerRect, srcFarCornerRect, srcRect, destNearCornerRect, destFarCornerRect, destRect);
                    }
                case ShadowDockPositon.Bottom:
                    {
                        var srcNearCornerRect = new Rectangle(0, cachedBmp.Height - ShadowSize, ShadowSize * 2, ShadowSize);
                        var destNearCornerRect = new Rectangle(0, height - ShadowSize, ShadowSize * 2, ShadowSize);

                        var srcFarCornerRect = new Rectangle(cachedBmp.Width - ShadowSize * 2, cachedBmp.Height - ShadowSize, ShadowSize * 2, ShadowSize);
                        var destFarCornerRect = new Rectangle(width - ShadowSize * 2, height - ShadowSize, ShadowSize * 2, ShadowSize);

                        var srcRect = new Rectangle(ShadowSize * 2, cachedBmp.Height - ShadowSize, cachedBmp.Width - ShadowSize * 4, ShadowSize);
                        var destRect = new Rectangle(ShadowSize * 2, height - ShadowSize, width - ShadowSize * 4, ShadowSize);

                        return (srcNearCornerRect, srcFarCornerRect, srcRect, destNearCornerRect, destFarCornerRect, destRect);
                    }
            }

            return (srcNearCornerRect: Rectangle.Empty, srcFarCornerRect: Rectangle.Empty, srcRect: Rectangle.Empty, destNearCornerRect: Rectangle.Empty, destFarCornerRect: Rectangle.Empty, destRect: Rectangle.Empty);
        }

        private ID2D1Bitmap LoadD2D1BitmapFromBitmap(ID2D1RenderTarget renderTarget, Bitmap origin)
        {
            Bitmap destBitmap;


            if (origin.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
            {
                destBitmap = new Bitmap(origin.Width, origin.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (Graphics g = Graphics.FromImage(destBitmap))
                {
                    g.DrawImage(origin, 0, 0);
                    g.Flush();
                }
            }
            else
            {
                destBitmap = (Bitmap)origin.Clone();
            }

            var bmpData = destBitmap.LockBits(new Rectangle(0, 0, destBitmap.Width, destBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, destBitmap.PixelFormat);

            int buffSize = bmpData.Stride * destBitmap.Height;

            byte[] byteData = new byte[buffSize];

            Marshal.Copy(bmpData.Scan0, byteData, 0, buffSize);

            destBitmap.UnlockBits(bmpData);


            var bmpProps = new BitmapProperties
            {
                PixelFormat = new Vortice.Direct2D1.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied),
                DpiX = 96,
                DpiY = 96
            };

            var d2d1Bmp = renderTarget.CreateBitmap(new Vortice.Mathematics.Size(destBitmap.Width, destBitmap.Height), IntPtr.Zero, bmpData.Stride, bmpProps);

            d2d1Bmp.CopyFromMemory(byteData, bmpData.Stride);

            return d2d1Bmp;

        }

        private void CreateDeviceResource()
        {
            if (_renderTarget == null)
            {

                var width = _view_width;
                var height = _view_height;

                _cacheBmp = new Bitmap(width, height);

                _hBitmap = _cacheBmp.GetHbitmap(Color.FromArgb(0, 0, 0, 0));
                _hOldBitmap = Gdi32.SelectObject(_memDC, _hBitmap);


                var renderProps = new RenderTargetProperties()
                {
                    Type = RenderTargetType.Hardware,
                    Usage = RenderTargetUsage.None,
                    PixelFormat = new Vortice.Direct2D1.PixelFormat(Vortice.DXGI.Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied),
                    MinLevel = FeatureLevel.Default
                };

                _renderTarget = _d2dFactory.CreateDCRenderTarget(renderProps);

                if (_cachedActiveBmp == null)
                {
                    var bmp = LoadD2D1BitmapFromBitmap(_renderTarget, _decorator.ActiveBitmapTemplate);
                    _cachedActiveBmp = _renderTarget.CreateSharedBitmap(bmp, new BitmapProperties
                    {
                        PixelFormat = bmp.PixelFormat
                    });
                }

                if (_cachedInactiveBmp == null)
                {
                    var bmp = LoadD2D1BitmapFromBitmap(_renderTarget, _decorator.InactiveBitmapTemplate);
                    _cachedInactiveBmp = _renderTarget.CreateSharedBitmap(bmp, new BitmapProperties
                    {
                        PixelFormat = bmp.PixelFormat
                    });
                }


                if (width > 0 && height > 0)
                {
                    _renderTarget.BindDC(_memDC, new Vortice.RawRect(0, 0, width, height));
                }




            }
        }

        private void DiscardDeviceResource()
        {
            _renderTarget?.Dispose();
            _renderTarget = null;

            if (_memDC != IntPtr.Zero && _hBitmap != IntPtr.Zero && _hOldBitmap != IntPtr.Zero)
            {
                Gdi32.SelectObject(_memDC, _hOldBitmap);
                Gdi32.DeleteObject(_hBitmap);
            }


            _hOldBitmap = IntPtr.Zero;
            _hBitmap = IntPtr.Zero;



            GC.Collect();

        }

        private void UpdateLayeredWindow()
        {
            unsafe
            {
                var rect = new RECT();
                User32.GetWindowRect(Handle, ref rect);


                if (rect.Width == 0 || rect.Height == 0)
                {
                    return;
                }

                var newLocation = new POINT(rect.left, rect.top);
                var newSize = new SIZE(rect.Width, rect.Height);
                var zeroPoint = new POINT(0, 0);

                if (rect.Width == 0 || rect.Height == 0)
                    return;


                var blend = new BLENDFUNCTION
                {
                    BlendOp = AcSrcOver,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = AcSrcAlpha
                };

                var ulwi = new UPDATELAYEREDWINDOWINFO
                {
                    cbSize = Marshal.SizeOf(typeof(UPDATELAYEREDWINDOWINFO)),
                    hdcDst = _screenDC,
                    pptDst = &newLocation,
                    psize = &newSize,
                    hdcSrc = _memDC,
                    pptSrc = &zeroPoint,
                    //crKey = new COLORREF(0),
                    pblend = &blend,
                    dwFlags = BlendFlags.ULW_ALPHA,
                    prcDirty = null

                };


                User32.UpdateLayeredWindowIndirect(Handle, ref ulwi);

                _lastUpdateHeight = rect.Height;
                _lastUpdateWidth = rect.Width;
            }
        }


        private Bitmap _cacheBmp;
        private IntPtr _hBitmap;
        private IntPtr _hOldBitmap;

        ID2D1Bitmap _cachedActiveBmp, _cachedInactiveBmp;

        private void Render(bool forceUpdateWindow = false)
        {
            if (_view_height == 0 || _view_width == 0)
            {
                return;
            }

            var templateBmp = _parentWindowIsFocused ? _decorator.ActiveBitmapTemplate : _decorator.InactiveBitmapTemplate;

            var matrix = GetShadowMetrics(templateBmp, _view_width, _view_height);

            CreateDeviceResource();

            var tplBitmap = _parentWindowIsFocused ? _cachedActiveBmp : _cachedInactiveBmp;

            _renderTarget.BeginDraw();

            _renderTarget.Clear(Color.Transparent);

            if (_side == ShadowDockPositon.Bottom || _side == ShadowDockPositon.Top)
            {
                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destNearCornerRect.X, matrix.destNearCornerRect.Y, matrix.destNearCornerRect.Right, matrix.destNearCornerRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcNearCornerRect.X, matrix.srcNearCornerRect.Y, matrix.srcNearCornerRect.Right, matrix.srcNearCornerRect.Bottom));

                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destFarCornerRect.X, matrix.destFarCornerRect.Y, matrix.destFarCornerRect.Right, matrix.destFarCornerRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcFarCornerRect.X, matrix.srcFarCornerRect.Y, matrix.srcFarCornerRect.Right, matrix.srcFarCornerRect.Bottom));

                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destRect.X, matrix.destRect.Y, matrix.destRect.Right, matrix.destRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcRect.X, matrix.srcRect.Y, matrix.srcRect.Right, matrix.srcRect.Bottom));
            }
            else
            {
                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destNearCornerRect.X, matrix.destNearCornerRect.Y, matrix.destNearCornerRect.Right, matrix.destNearCornerRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcNearCornerRect.X, matrix.srcNearCornerRect.Y, matrix.srcNearCornerRect.Right, matrix.srcNearCornerRect.Bottom));

                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destFarCornerRect.X, matrix.destFarCornerRect.Y, matrix.destFarCornerRect.Right, matrix.destFarCornerRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcFarCornerRect.X, matrix.srcFarCornerRect.Y, matrix.srcFarCornerRect.Right, matrix.srcFarCornerRect.Bottom));

                _renderTarget.DrawBitmap(tplBitmap, new RawRectF(matrix.destRect.X, matrix.destRect.Y, matrix.destRect.Right, matrix.destRect.Bottom), 1.0f, BitmapInterpolationMode.Linear, new RawRectF(matrix.srcRect.X, matrix.srcRect.Y, matrix.srcRect.Right, matrix.srcRect.Bottom));
            }


            if (_renderTarget.EndDraw().Failure)
            {
                DiscardDeviceResource();
            }

            GC.Collect();

            if (forceUpdateWindow)
            {
                UpdateLayeredWindow();
            }
        }

        private void SetCursor()
        {
            if (!ExternalResizeEnable)
            {
                return;
            }

            IntPtr handle = IntPtr.Zero; //User32.LoadCursor(IntPtr.Zero, (int)IDC_STANDARD_CURSORS.IDC_HAND);
            HitTest mode = GetResizeMode();
            switch (mode)
            {
                case HitTest.HTTOP:
                case HitTest.HTBOTTOM:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IDC_STANDARD_CURSORS.IDC_SIZENS);
                    break;
                case HitTest.HTLEFT:
                case HitTest.HTRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IDC_STANDARD_CURSORS.IDC_SIZEWE);
                    break;
                case HitTest.HTTOPLEFT:
                case HitTest.HTBOTTOMRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IDC_STANDARD_CURSORS.IDC_SIZENWSE);
                    break;
                case HitTest.HTTOPRIGHT:
                case HitTest.HTBOTTOMLEFT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IDC_STANDARD_CURSORS.IDC_SIZENESW);
                    break;
            }

            if (handle != IntPtr.Zero)
            {
                User32.SetCursor(handle);
            }
        }

        private void CastMouseDown(Point point)
        {

            if (!ExternalResizeEnable)
            {
                return;
            }

            HitTest mode = GetResizeMode();




            if (MouseDown != null)
            {
                FormShadowResizeArgs args = new FormShadowResizeArgs(_side, mode, point);
                MouseDown(this, args);
            }
        }

        private POINT GetRelativeMousePosition()
        {
            POINT point = new POINT();
            User32.GetCursorPos(ref point);
            User32.ScreenToClient(Handle, ref point);
            return point;
        }

        private HitTest GetResizeMode()
        {
            HitTest mode = HitTest.HTNOWHERE;

            RECT rect = new RECT();
            POINT point = GetRelativeMousePosition();
            User32.GetWindowRect(Handle, ref rect);
            switch (_side)
            {
                case ShadowDockPositon.Top:
                    int width = rect.right - rect.left;
                    if (point.x < ShadowSize)
                        mode = HitTest.HTTOPLEFT;
                    else if (point.x > width - ShadowSize)
                        mode = HitTest.HTTOPRIGHT;
                    else
                        mode = HitTest.HTTOP;
                    break;
                case ShadowDockPositon.Bottom:
                    width = rect.right - rect.left;
                    if (point.x < ShadowSize)
                        mode = HitTest.HTBOTTOMLEFT;
                    else if (point.x > width - ShadowSize)
                        mode = HitTest.HTBOTTOMRIGHT;
                    else
                        mode = HitTest.HTBOTTOM;
                    break;
                case ShadowDockPositon.Left:
                    mode = HitTest.HTLEFT;

                    break;
                case ShadowDockPositon.Right:
                    mode = HitTest.HTRIGHT;

                    break;
            }

            return mode;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;

            if (Handle == IntPtr.Zero)
                return;

            if (_renderTarget != null)
            {
                _renderTarget.Dispose();
                _renderTarget = null;
            }

            _d2dFactory.Dispose();

            _d2dFactory = null;


            if (_memDC != IntPtr.Zero)
            {
                Gdi32.DeleteDC(_memDC);
            }

            if (_screenDC != IntPtr.Zero)
            {
                User32.ReleaseDC(IntPtr.Zero, _screenDC);
            }

            _memDC = IntPtr.Zero;
            _screenDC = IntPtr.Zero;


            User32.DestroyWindow(Handle);
            Handle = IntPtr.Zero;
            gcHandle.Free();
        }

        #endregion

    }
}
