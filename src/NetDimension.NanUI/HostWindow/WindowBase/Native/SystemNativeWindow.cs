using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    public class SystemNativeWindow : Form
    {
        private int _deviceDpi;
        


        internal protected new AutoScaleMode AutoScaleMode => AutoScaleMode.None;

        protected float ScaleFactor { get; private set; } = 1.0f;

        public SystemNativeWindow()
        {
            DpiHelper.InitializeDpiHelper();
            _deviceDpi = DpiHelper.DeviceDpi;
            base.AutoScaleMode = AutoScaleMode.None;
        }

        protected override void OnHandleCreated(EventArgs e)
        {

            ScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

            base.OnHandleCreated(e);

            CheckResetDPIAutoScale(true);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Scale(new SizeF(ScaleFactor, ScaleFactor));

            if (!DesignMode)
            {
                var currentScreenScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

                var primaryScreenScaleFactor = DpiHelper.GetScreenDpi(Screen.PrimaryScreen) / 96f;

                if (primaryScreenScaleFactor != 1.0f)
                {
                    Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size / primaryScreenScaleFactor), Font.Style);
                }

                Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size * currentScreenScaleFactor), Font.Style);

                CorrectFormPostion();
            }

        }

        protected override void WndProc(ref Message m)
        {
            switch ((WindowsMessages)m.Msg)
            {
                case WindowsMessages.WM_DPICHANGED:
                    {
                        WmDpiChanged(ref m);
                        break;
                    }
                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
            
        }

        protected FormWindowState MinMaxState
        {
            get
            {
                var s = User32.GetWindowLong(Handle, GetWindowLongFlags.GWL_STYLE);
                var max = (s & (int)WindowStyles.WS_MAXIMIZE) > 0;
                if (max)
                    return FormWindowState.Maximized;
                var min = (s & (int)WindowStyles.WS_MINIMIZE) > 0;
                if (min)
                    return FormWindowState.Minimized;
                return FormWindowState.Normal;
            }
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

        private void WmDpiChanged(ref Message m)
        {

            var oldDeviceDpi = _deviceDpi;
            var newDeviceDpi = Win32.SignedHIWORD(m.WParam);

            var suggestedRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

            ScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

            _deviceDpi = newDeviceDpi;

            User32.SetWindowPos(Handle, IntPtr.Zero, suggestedRect.left, suggestedRect.top, suggestedRect.Width, suggestedRect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);

            OnWmDpiChanged(oldDeviceDpi, newDeviceDpi, suggestedRect.ToRectangle());
        }

        public event EventHandler<WindowDpiChangedEventArgs> SystemDpiChanged;


        private void OnWmDpiChanged(int oldDeviceDpi, int newDeviceDpi, Rectangle suggestedRectangle)
        {

            //Debug.WriteLineIf(oldDeviceDpi != newDeviceDpi, $"[WM_DPI_CHANGED] {oldDeviceDpi} {suggestedRectangle}");


            CheckResetDPIAutoScale(true);
            PerformLayout();
            Update();

            SystemDpiChanged?.Invoke(this, new WindowDpiChangedEventArgs(oldDeviceDpi, newDeviceDpi));

        }

        private protected Rectangle RealFormRectangle
        {
            get
            {
                var windowRect = new RECT();

                User32.GetWindowRect(Handle, ref windowRect);

                return new Rectangle(0, 0, windowRect.Width, windowRect.Height);
            }
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

                if (currentScreen != initScreen)
                {
                    screenLeft += currentScreen.WorkingArea.Left;
                    screenTop += currentScreen.WorkingArea.Top;
                }

                User32.SetWindowPos(Handle, IntPtr.Zero, screenLeft + (currentScreen.WorkingArea.Width - w) / 2, screenTop + (currentScreen.WorkingArea.Height - h) / 2, RealFormRectangle.Width, RealFormRectangle.Height, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
            }

        }
    }
}
