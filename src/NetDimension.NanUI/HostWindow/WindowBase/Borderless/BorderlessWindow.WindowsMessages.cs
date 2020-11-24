using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

    partial class BorderlessWindow
    {
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
    }
}
