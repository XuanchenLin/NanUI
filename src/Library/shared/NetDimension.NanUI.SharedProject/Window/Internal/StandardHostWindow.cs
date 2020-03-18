using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.Window
{
    [ToolboxItem(false)]
    internal class StandardHostWindow : Form, IStandardHostWindowStyle
    {
        #region Win10 High DPI
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private const int PROCESS_VM_READ = 0x0010;

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [DllImport("Kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        private const int S_OK = 0;
        private enum PROCESS_DPI_AWARENESS
        {
            PROCESS_DPI_UNAWARE = 0,
            PROCESS_SYSTEM_DPI_AWARE = 1,
            PROCESS_PER_MONITOR_DPI_AWARE = 2
        }
        [DllImport("Shcore.dll")]
        private static extern int GetProcessDpiAwareness(IntPtr hprocess, out PROCESS_DPI_AWARENESS value);

        [DllImport("user32.dll")]
        internal static extern int GetAwarenessFromDpiAwarenessContext(IntPtr dpiContext);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowDpiAwarenessContext(IntPtr hWnd);

        private PROCESS_DPI_AWARENESS GetDpiState(uint processId)
        {
            try
            {
                IntPtr handle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, false, processId);
                if (handle != IntPtr.Zero)
                {
                    PROCESS_DPI_AWARENESS value;
                    int result = GetProcessDpiAwareness(handle, out value);
                    if (result == S_OK)
                    {
                        System.Diagnostics.Debug.Print(value.ToString());
                    }
                    CloseHandle(handle);
                    if (result != S_OK)
                    {
                        throw new Win32Exception(result);
                    }
                    return value;
                }
            }
            catch
            {

            }
            return PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE;
        }

        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In]System.Drawing.Point pt, [In]uint dwFlags);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510(v=vs.85).aspx
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In]IntPtr hmonitor, [In]DpiType dpiType, [Out]out uint dpiX, [Out]out uint dpiY);
        private enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }

        private void GetDpiForScreen(System.Windows.Forms.Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
        {
            try
            {
                var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
                var mon = MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
                GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
            }
            catch
            {

                Graphics g = this.CreateGraphics();

                try
                {
                    dpiX = (uint)g.DpiX;
                    dpiY = (uint)g.DpiY;
                }
                catch
                {
                    dpiX = 96;
                    dpiY = 96;
                }
                finally
                {
                    g.Dispose();
                }
            }





        }

        #endregion

        private const int designTimeDpi = 96;
        private int startupDpi;
        private static bool? isDesingerProcess = null;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        protected static bool IsDesingerProcess
        {
            get
            {
                if (isDesingerProcess == null)
                {
                    isDesingerProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
                }

                return isDesingerProcess.Value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || IsDesingerProcess;
        public StandardHostWindow()
        {
            AutoScaleMode = AutoScaleMode.Dpi;



            if (FormStyleHelper.IsWindows8OrLower)
            {
                float dx, dy;
                Graphics g = this.CreateGraphics();

                try
                {
                    dx = g.DpiX;
                    dy = g.DpiY;
                }
                finally
                {
                    g.Dispose();
                }


                startupDpi =  (int)dx;

            }
            else
            {
                var currentScreen = Screen.FromHandle(Handle);

                GetDpiForScreen(currentScreen, DpiType.Effective, out var dpiX, out var dpiY);


                startupDpi = (int)dpiX;
            }

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (startupDpi != designTimeDpi && !DesignMode)
            {
                var factor = startupDpi / (float)designTimeDpi;
                this.Scale(new SizeF(factor, factor));
            }


            if (!IsDesignMode)
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

                    if (currentScreen != initScreen)
                    {
                        Location = new Point(Left + currentScreen.WorkingArea.Left, Top + currentScreen.WorkingArea.Top);
                    }

                    Location = new Point(currentScreen.WorkingArea.Left + (currentScreen.WorkingArea.Width / 2 - this.Width / 2), currentScreen.WorkingArea.Top + (currentScreen.WorkingArea.Height / 2 - this.Height / 2));

                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            bool processed = false;

            if (m.Msg == (int)WindowsMessages.WM_DPICHANGED)
            {
                processed = OnWMDpiChanged(ref m);

            }

            if (!processed)
                base.WndProc(ref m);
        }

        private bool OnWMDpiChanged(ref Message m)
        {
            var rect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
            User32.SetWindowPos(Handle, IntPtr.Zero, rect.left, rect.top, rect.Width, rect.Height, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOACTIVATE);
            return true;

        }


    }
}
