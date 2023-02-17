using Vanara.Extensions;
using Vanara.PInvoke;

using static Vanara.PInvoke.DwmApi;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

internal partial class _FackUnusedClass
{

}

internal partial class BorderlessWindow
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        public RECT rgrc0, rgrc1, rgrc2;
        public WINDOWPOS lppos;
    }

    internal protected bool IsApplicationForeground { get; private set; }


    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case (int)WindowMessage.WM_CREATE:

                if (!WmCreate(ref m))
                {
                    base.WndProc(ref m);
                }

                break;

            case (int)WindowMessage.WM_NCCALCSIZE:
                {
                    if (!WmNCCalcSize(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            case (int)WindowMessage.WM_ACTIVATE:
                {
                    base.WndProc(ref m);
                    DwmExtendFrameIntoClientArea(hWnd, new MARGINS(0));

                }
                break;
            case (int)WindowMessage.WM_PAINT:
                {
                    if(!WmPaint(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            case (int)WindowMessage.WM_NCPAINT:
                {
                    if (!WmNCPaint(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            case (int)WindowMessage.WM_SIZE:
                {
                    if (!WmSize(ref m))
                    {

                        base.WndProc(ref m);

                    }
                }
                break;
            case (int)WindowMessage.WM_WINDOWPOSCHANGED:
                {

                    if (!WmWindowPosChanged(ref m))
                    {
                        base.WndProc(ref m);
                    }

                }
                break;
            case (int)WindowMessage.WM_ACTIVATEAPP:
                {
                    if (!WmActiveApp(ref m))
                    {
                        base.WndProc(ref m);
                    }

                    InvalidateNonClientArea();
                    SendFrameChangedMessage();
                }
                break;
            case (int)WindowMessage.WM_SHOWWINDOW:
                {
                    base.WndProc(ref m);


                    if (WindowState == FormWindowState.Normal)
                    {

                        System.Diagnostics.Debug.WriteLine("111");
                        using var roundedRect = GetWindowBorderPath();
                        SetWindowRegion(roundedRect);
                    }


                }
                break;
            case (int)WindowMessage.WM_NCACTIVATE:
                {
                    if (!WmNCActive(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            case (int)WindowMessage.WM_NCHITTEST:
                {
                    var x = Macros.GET_X_LPARAM(m.LParam);

                    var y = Macros.GET_Y_LPARAM(m.LParam);

                    var pt = new POINT(x, y);

                    ScreenToClient(hWnd, ref pt);

                    var mode = HitTest(pt);

                    if (mode == HitTestValues.HTCLIENT)
                        mode = HitTestValues.HTCAPTION;

                    m.Result = (IntPtr)mode;

                    base.WndProc(ref m);
                }
                break;
            case (int)WindowMessage.WM_NCMOUSEMOVE:
            case (int)WindowMessage.WM_NCMOUSELEAVE:
            case (int)WindowMessage.WM_NCLBUTTONDOWN:
            case (int)WindowMessage.WM_NCRBUTTONDOWN:
            case (int)WindowMessage.WM_NCLBUTTONDBLCLK:
            case (int)WindowMessage.WM_NCRBUTTONDBLCLK:
                {
                    InvalidateNonClientArea();
                    SendFrameChangedMessage();
                    base.WndProc(ref m);

                }
                break;

            case 0x00AE: //WM_NCUAHDRAWCAPTION:
            case 0x00AF: //WM_NCUAHDRAWFRAME:
            case 0xC1BC: //WM_UNKNOWN_GHOST
                {
                    InvalidateNonClientArea();
                    SendFrameChangedMessage();
                    m.Result = TRUE;
                }
                break;
            case (int)WindowMessage.WM_DPICHANGED:
                {
                    if (!WmDpiChanged(ref m))
                    {
                        base.WndProc(ref m);
                    }
                }
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }



    private bool WmActiveApp(ref Message m)
    {

        if (m.WParam == IntPtr.Zero)
        {
            IsApplicationForeground = false;
            KillApplicationFocus();
        }
        else
        {
            IsApplicationForeground = true;
            SetApplicationFocus();
        }

        return false;
    }

    private bool WmNCActive(ref Message m)
    {
        var isActive = IsWindowFocused = (m.WParam == TRUE);




        if (MinMaxState == FormWindowState.Minimized)
        {
            DefWndProc(ref m);
        }
        else
        {


            m.Result = MESSAGE_HANDLED;

            InvalidateNonClientArea();

            SendFrameChangedMessage();
            if (isActive)
            {
                SetWindowFocus();


            }
            else
            {
                KillWindowFocus();
            }
            UpdateShadowZOrder();
        }



        return true;
    }

    private bool WmWindowPosChanged(ref Message m)
    {
        var windowpos = m.LParam.ToStructure<WINDOWPOS>();

        if (!IsIconic(hWnd))
        {
            UpdateShadowPos(windowpos);
        }


        return false;
    }

    private bool WmPaint(ref Message m)
    {
        if (WindowState == FormWindowState.Maximized)
        {
            _shouldPerformMaximiazedState = true;

            var screen = Screen.FromHandle(Handle);

            var bounds = FormBorderStyle == FormBorderStyle.None ? screen.Bounds : screen.WorkingArea;

            var regionBounds = new Rectangle(bounds.X - Bounds.X, bounds.Y - Bounds.Y, Bounds.Width - (Bounds.Width - bounds.Width), Bounds.Height - (Bounds.Height - bounds.Height));

            SetWindowRegion(regionBounds);
        }
        else if (WindowState == FormWindowState.Normal)
        {
            using var roundedRect = GetWindowBorderPath();
            SetWindowRegion(roundedRect);
        }
        else
        {
            RemoveWindowRegion();
        }

        return false;
    }



    private bool WmSize(ref Message m)
    {
        if (!_isLoaded)
            return false;

        SendFrameChangedMessage();

        ResizeShadow(ref m);

        return false;
    }

    private bool WmCreate(ref Message m)
    {
        GetWindowRect(m.HWnd, out var rcClient);

        //SetWindowPos(m.HWnd, HWND.NULL, rcClient.left, rcClient.top, rcClient.Width, rcClient.Height, SetWindowPosFlags.SWP_FRAMECHANGED);

        SetWindowPos(m.HWnd, HWND.NULL, Location.X, Location.Y, rcClient.Width, rcClient.Height, SetWindowPosFlags.SWP_FRAMECHANGED);

        return false;
    }

    private bool WmNCCalcSize(ref Message m)
    {
        if (m.WParam == TRUE)
        {
            var nccsp = Marshal.PtrToStructure<NCCALCSIZE_PARAMS>(m.LParam);
            var ncBorders = GetNonClientAeraBorders();

            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized)
            {
                //nccsp.rgrc0.top -= 1;
                //nccsp.rgrc0.bottom += 1;
                //nccsp.rgrc0.left -= 1;
                //nccsp.rgrc0.right += 1;

                m.Result = MESSAGE_PROCESS;

                //Marshal.StructureToPtr(nccsp, m.LParam, true);


                return true;
            }
            else if (WindowState == FormWindowState.Maximized)
            {


                nccsp.rgrc0.top -= ncBorders.Top;
                nccsp.rgrc0.top += ncBorders.Bottom;

                Marshal.StructureToPtr(nccsp, m.LParam, false);
                m.Result = MESSAGE_PROCESS;
            }
        }

        return false;
    }


    private bool WmNCPaint(ref Message m)
    {
        if (!IsHandleCreated)
        {
            return false;
        }

        m.Result = MESSAGE_PROCESS;

        return true;
    }


}
