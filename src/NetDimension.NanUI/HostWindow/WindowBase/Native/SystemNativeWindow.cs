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

            CorrectFormPostion();



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
                case WindowsMessages.WM_SYSCOMMAND:
                    {
                        WmSystemCommand(ref m);

                        break;
                    }
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

                    var factor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);


                    //var screenDpi = DpiHelper.GetScreenDpiFromPoint(MousePosition);

                    //var screenScaleFactor = (screenDpi / 96f) / ScaleFactor;

                    var bounds = GetScaledBounds(RealFormRectangle, new SizeF(factor, factor), BoundsSpecified.Size);

                    w = bounds.Width;
                    h = bounds.Height;
                }

                if (currentScreen.DeviceName != initScreen.DeviceName)
                {
                    
                }

                screenLeft += currentScreen.WorkingArea.Left;
                screenTop += currentScreen.WorkingArea.Top;

                User32.SetWindowPos(Handle, IntPtr.Zero, screenLeft + (currentScreen.WorkingArea.Width - w) / 2, screenTop + (currentScreen.WorkingArea.Height - h) / 2, RealFormRectangle.Width, RealFormRectangle.Height, SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
            }

        }
    }
}
