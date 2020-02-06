using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI.Window
{
    [ToolboxItem(false)]
    internal class BorderlessHostWindow : ModernUIForm, IBorderlessHostWindowStyle
    {
        protected bool Resizable => FormBorderStyle == FormBorderStyle.SizableToolWindow || FormBorderStyle == FormBorderStyle.Sizable;
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == (int)DefMessages.WM_DRAG_APP_REGION)
            {

                User32.ReleaseCapture();
                User32.SendMessage(Handle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)HitTest.HTCAPTION, (IntPtr)0);
            }

            if(m.Msg == (int)DefMessages.WM_BROWSER_MOUSE_MOVE)
            {
                var pt = Win32.GetPostionFromPtr(m.LParam);

                User32.PostMessage(Handle, (uint)WindowsMessages.WM_NCHITTEST, IntPtr.Zero, Win32.MakeParam((IntPtr)pt.x, (IntPtr)pt.y));
            }

            //if(Resizable && m.Msg == (int)DefMessages.WM_BROWSER_MOUSE_LBUTTON_DOWN)
            //{
            //    var screenPt = Win32.GetPostionFromPtr(m.LParam);
            //    var clientPt = new POINT(screenPt.x, screenPt.y);

            //    User32.ScreenToClient(Handle, ref clientPt);
            //    var mode = GetSizeMode(clientPt);
            //    if(mode!= HitTest.HTNOWHERE)
            //    {
            //        User32.SendMessage(Handle, (uint)WindowsMessages.WM_NCLBUTTONDOWN, (IntPtr)mode, Win32.MakeParam((IntPtr)clientPt.x, (IntPtr)clientPt.y));
            //    }
            //}

            base.DefWndProc(ref m);
        }

        protected override bool OnWMNCHITTEST(ref Message m)
        {
            if (Resizable)
            {
                var pt = Win32.GetPostionFromPtr(m.LParam);

                User32.ScreenToClient(Handle, ref pt);

                var mode = GetSizeMode(pt);

                //SetCursor(mode);

                m.Result = (IntPtr)mode;

            }

            return true;

        }

        //internal HitTest GetSizeMode(IntPtr handle, POINT point)
        //{
        //    HitTest mode = HitTest.HTNOWHERE;

        //    int x = point.x, y = point.y;

        //    const int CornerAreaSize = 4;

        //    var windowRect = new RECT();
        //    var clientRect = new RECT();

        //    User32.GetWindowRect(handle, ref windowRect);
        //    User32.GetClientRect(handle, ref clientRect);


        //    int left = 0 - Borders.Left + CornerAreaSize;
        //    int top = 0 - Borders.Top + CornerAreaSize;
        //    int right = clientRect.Width + Borders.Right - CornerAreaSize;
        //    int bottom = clientRect.Height + Borders.Bottom - CornerAreaSize;

        //    left = left < 0 ? 0 : left;
        //    top = top < 0 ? 0 : top;
        //    right = right > clientRect.Width ? clientRect.Width : right;
        //    bottom = bottom > clientRect.Height ? clientRect.Height : bottom;


        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        if (x < left & y < top)
        //        {
        //            mode = HitTest.HTTOPLEFT;
        //        }
        //        else if (x < left & y > bottom)
        //        {
        //            mode = HitTest.HTBOTTOMLEFT;

        //        }
        //        else if (x > right & y > bottom)
        //        {
        //            mode = HitTest.HTBOTTOMRIGHT;

        //        }
        //        else if (x > right & y < top)
        //        {
        //            mode = HitTest.HTTOPRIGHT;

        //        }
        //        else if (x < left)
        //        {
        //            mode = HitTest.HTLEFT;

        //        }
        //        else if (x > right)
        //        {
        //            mode = HitTest.HTRIGHT;

        //        }
        //        else if (y < top)
        //        {
        //            mode = HitTest.HTTOP;

        //        }
        //        else if (y > bottom)
        //        {
        //            mode = HitTest.HTBOTTOM;
        //        }

        //    }

        //    Console.WriteLine($"{mode} {point}");

        //    return mode;
        //}

        protected HitTest GetSizeMode(POINT point)
        {
            HitTest mode = HitTest.HTNOWHERE;

            int x = point.x, y = point.y;

            const int CornerAreaSize = 4;

            var windowRect = new RECT();
            var clientRect = new RECT();

            User32.GetWindowRect(Handle, ref windowRect);
            User32.GetClientRect(Handle, ref clientRect);


            int left = 0 - Borders.Left + CornerAreaSize;
            int top = 0 - Borders.Top + CornerAreaSize;
            int right = clientRect.Width + Borders.Right - CornerAreaSize;
            int bottom = clientRect.Height + Borders.Bottom - CornerAreaSize;

            left = left < 0 ? 0 : left;
            top = top < 0 ? 0 : top;
            right = right > clientRect.Width ? clientRect.Width : right;
            bottom = bottom > clientRect.Height ? clientRect.Height : bottom;
                                 

            if (WindowState == FormWindowState.Normal)
            {
                if (x < left & y < top)
                {
                    mode = HitTest.HTTOPLEFT;
                }
                else if (x < left & y > bottom)
                {
                    mode = HitTest.HTBOTTOMLEFT;

                }
                else if (x > right & y > bottom)
                {
                    mode = HitTest.HTBOTTOMRIGHT;

                }
                else if (x > right & y < top)
                {
                    mode = HitTest.HTTOPRIGHT;

                }
                else if (x < left)
                {
                    mode = HitTest.HTLEFT;

                }
                else if (x  > right)
                {
                    mode = HitTest.HTRIGHT;

                }
                else if (y < top)
                {
                    mode = HitTest.HTTOP;

                }
                else if (y > bottom)
                {
                    mode = HitTest.HTBOTTOM;
                }

            }

            return mode;
        }

        protected void SetCursor(HitTest mode)
        {


            IntPtr handle = IntPtr.Zero;

            switch (mode)
            {
                case HitTest.HTTOP:
                case HitTest.HTBOTTOM:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENS);
                    break;
                case HitTest.HTLEFT:
                case HitTest.HTRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZEWE);
                    break;
                case HitTest.HTTOPLEFT:
                case HitTest.HTBOTTOMRIGHT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENWSE);
                    break;
                case HitTest.HTTOPRIGHT:
                case HitTest.HTBOTTOMLEFT:
                    handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENESW);
                    break;
            }

            if (handle != IntPtr.Zero)
            {
                User32.SetCursor(handle);
            }
        }


    }
}
