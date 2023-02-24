using NetDimension.Shiva;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow
{
    using System.Runtime.InteropServices;
    using Vanara.PInvoke;

    using static Vanara.PInvoke.DwmApi;
    using static Vanara.PInvoke.User32;


    public class AcrylicStyleHostWindow : SystemWindow, IFormiumHostWindow
    {
        public WindowMessageDelegate OnWindowsMessage { get; set; }

        public WindowMessageDelegate OnDefWindowsMessage { get; set; }

        public Formium Formium { get; }

        private CefBrowserHost BrowserHost => Formium?.Browser?.GetHost();

        public AcrylicStyleHostWindow(Formium formium)
        {
            Formium = formium;
        }

        protected override void WndProc(ref Message m)
        {
            var handled = OnWindowsMessage?.Invoke(ref m) ?? false;

            var msg = (WindowMessage)m.Msg;

            switch (msg)
            {

                case WindowMessage.WM_IME_STARTCOMPOSITION:
                    {

                    }
                    break;

                case WindowMessage.WM_IME_ENDCOMPOSITION:
                    {

                    }
                    break;
                case WindowMessage.WM_IME_COMPOSITION:
                    {

                    }
                    break;


            }

            if (!handled)
            {
                base.WndProc(ref m);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_NCCALCSIZE && m.WParam != IntPtr.Zero)
            {
                if (IsZoomed(hWnd))
                {
                    var nccsp = Marshal.PtrToStructure<BorderlessWindow.NCCALCSIZE_PARAMS>(m.LParam);
                    var ncBorders = GetNonClientAeraBorders();
                    nccsp.rgrc1 = nccsp.rgrc0;
                    nccsp.rgrc0.top -= ncBorders.Top;
                    nccsp.rgrc0.top += ncBorders.Bottom;
                    Marshal.StructureToPtr(nccsp, m.LParam, false);
                    
                    m.Result = (IntPtr)0x0400;
                    //base.WndProc(ref m);
                }
                else
                {
                    m.Result = IntPtr.Zero;
                }

                return;
            }

            var handled = OnDefWindowsMessage?.Invoke(ref m) ?? false;

            if (!handled)
            {
                base.DefWndProc(ref m);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // Add the layered extended style (WS_EX_LAYERED) to this window.
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x0020_0000;
                return createParams;
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            try
            {
                //DwmSetWindowAttribute(hWnd, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, DWMNCRENDERINGPOLICY.DWMNCRP_ENABLED);

                DwmExtendFrameIntoClientArea(hWnd, new MARGINS(0, 2, 0, 2));


                SetWindowPos(hWnd, HWND.NULL, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_FRAMECHANGED);
                //WindowUtils.EnableAcrylic(this);
            }
            catch (Exception ex)
            {
                WinFormium.GetLogger().Error(ex);
            }
        }

        private void AdjustWindowRect(ref RECT rect, WindowStyles style, WindowStylesEx exStyle)
        {
            if (DpiHelper.IsPerMonitorV2Awareness)
            {
                AdjustWindowRectExForDpi(ref rect, style, false, exStyle, (uint)DpiHelper.GetDpiForWindow(hWnd));
            }
            else
            {
                AdjustWindowRectEx(ref rect, style, false, exStyle);
            }
        }
        internal Padding GetNonClientAeraBorders()
        {
            var rect = RECT.Empty;

            var screenRect = ClientRectangle;

            screenRect.Offset(-Bounds.Left, -Bounds.Top);

            rect.top = screenRect.Top;
            rect.left = screenRect.Left;
            rect.bottom = screenRect.Bottom;
            rect.right = screenRect.Right;

            AdjustWindowRect(ref rect, (WindowStyles)CreateParams.Style, (WindowStylesEx)CreateParams.ExStyle);

            return new Padding
            {
                Top = screenRect.Top - rect.top,
                Left = screenRect.Left - rect.left,
                Bottom = rect.bottom - screenRect.Bottom,
                Right = rect.right - screenRect.Right
            };
        }


        public HitTestValues HitTest(Point point)
        {
            return HitTestValues.HTNOWHERE;
        }
    }
}
