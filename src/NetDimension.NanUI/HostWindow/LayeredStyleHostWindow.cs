using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    public class LayeredStyleHostWindow : BorderlessWindow, IFormiumHostWindow
    {
        #region Default Staffs
        private readonly SynchronizationContext _uiThread;
        private readonly Formium _formium;

        private CefBrowserHost BrowserHost => _formium?.Browser?.GetHost();

        public OnWindowsMessageDelegate OnWindowsMessage { get; set; }

        public OnWindowsMessageDelegate OnDefWindowsMessage { get; set; }

        private LayeredStyleHostWindow() {
            BorderEffect = BorderEffect.None;
            ShadowEffect = ShadowEffect.None;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }


        internal LayeredStyleHostWindow(Formium formium) : this()
        {
            _formium = formium;
            _uiThread = WindowsFormsSynchronizationContext.Current;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 

            SystemDpiChanged += AcrylicStyleHostWindow_SystemDpiChanged;
        }

        private void AcrylicStyleHostWindow_SystemDpiChanged(object sender, WindowDpiChangedEventArgs e)
        {
            BrowserHost?.NotifyScreenInfoChanged();
        }

        public void PostUIThread(Action action)
        {
            _uiThread.Post(_state => {
                action?.Invoke();
            }, null);
        }

        protected override void WndProc(ref Message m)
        {
            var msg = (WindowsMessages)m.Msg;

            var retval = OnWindowsMessage?.Invoke(ref m);

            switch (msg)
            {
                case WindowsMessages.WM_LBUTTONDOWN:
                    retval = _formium?.OnBrowserWMLButtonDown(m);
                    break;
                case WindowsMessages.WM_RBUTTONDOWN:
                    retval = _formium?.OnBrowserWMRButtonDown(m);
                    break;
                case WindowsMessages.WM_RBUTTONUP:
                    retval = _formium?.OnBrowserWMRButtonUp(m);
                    break;
                case WindowsMessages.WM_LBUTTONDBLCLK:
                    retval = _formium?.OnBrowserWMLButtonDbClick(m);
                    break;
                case WindowsMessages.WM_MOUSEMOVE:
                    if (_formium != null && _formium.Resizable)
                    {
                        retval = _formium.OnBrowserWMMouseMove(m);
                    }
                    break;
                case WindowsMessages.WM_IME_STARTCOMPOSITION:
                    {

                    }
                    break;

                case WindowsMessages.WM_IME_ENDCOMPOSITION:
                    {

                    }
                    break;
                case WindowsMessages.WM_IME_COMPOSITION:
                    {

                    }
                    break;


            }


            if (retval == null || retval == false)
            {
                base.WndProc(ref m);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            var retval = OnDefWindowsMessage?.Invoke(ref m);

            if (retval == null || retval == false)
            {
                base.DefWndProc(ref m);
            }
        }

        #endregion

        #region OSR Event handlers
        private void GetPointInCurrentView(ref Point point)
        {
            point.X = (int)(point.X / ScaleFactor);
            point.Y = (int)(point.Y / ScaleFactor);
        }

        private static CefEventFlags GetMouseModifiers(MouseButtons mouseButtons)
        {
            CefEventFlags modifiers = new CefEventFlags();

            if (mouseButtons == MouseButtons.Left)
                modifiers |= CefEventFlags.LeftMouseButton;

            if (mouseButtons == MouseButtons.Middle)
                modifiers |= CefEventFlags.MiddleMouseButton;

            if (mouseButtons == MouseButtons.Right)
                modifiers |= CefEventFlags.RightMouseButton;

            return modifiers;
        }

        private static CefEventFlags GetKeyboardModifiers(Keys modifiers)
        {
            CefEventFlags result = new CefEventFlags();

            if (modifiers == Keys.Alt)
                result |= CefEventFlags.AltDown;

            if (modifiers == Keys.Control)
                result |= CefEventFlags.ControlDown;

            if (modifiers == Keys.Shift)
                result |= CefEventFlags.ShiftDown;

            return result;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            e.Handled = true;

            BrowserHost?.SendKeyEvent(new CefKeyEvent
            {
                EventType = CefKeyEventType.KeyDown,
                WindowsKeyCode = (int)e.KeyCode,
                Modifiers = GetKeyboardModifiers(e.Modifiers)
            });



        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            e.Handled = true;

            BrowserHost?.SendKeyEvent(new CefKeyEvent
            {
                EventType = CefKeyEventType.KeyUp,
                WindowsKeyCode = (int)e.KeyCode,
                Modifiers = GetKeyboardModifiers(e.Modifiers)
            });
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;

            BrowserHost?.SendKeyEvent(new CefKeyEvent
            {
                EventType = CefKeyEventType.Char,
                WindowsKeyCode = (int)e.KeyChar,
                FocusOnEditableField = true,
                Character = e.KeyChar
            });
            ;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var pt = e.Location;

            GetPointInCurrentView(ref pt);

            BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), false);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            BrowserHost?.SendMouseMoveEvent(new CefMouseEvent(0, 0, CefEventFlags.None), true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var pt = e.Location;

            GetPointInCurrentView(ref pt);

            CefMouseButtonType buttonType;

            switch (e.Button)
            {
                case MouseButtons.Right:
                    buttonType = CefMouseButtonType.Right;
                    break;
                case MouseButtons.Middle:
                    buttonType = CefMouseButtonType.Middle;
                    break;
                default:
                    buttonType = CefMouseButtonType.Left;
                    break;
            }

            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType, false, e.Clicks);
            BrowserHost?.SendFocusEvent(true);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var pt = e.Location;

            GetPointInCurrentView(ref pt);

            CefMouseButtonType buttonType;

            switch (e.Button)
            {
                case MouseButtons.Right:
                    buttonType = CefMouseButtonType.Right;
                    break;
                case MouseButtons.Middle:
                    buttonType = CefMouseButtonType.Middle;
                    break;
                default:
                    buttonType = CefMouseButtonType.Left;
                    break;
            }

            BrowserHost?.SendMouseClickEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), buttonType, true, e.Clicks);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            BrowserHost?.WasResized();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            var pt = ScreenToWindow(e.Location);

            GetPointInCurrentView(ref pt);

            BrowserHost?.SendMouseWheelEvent(new CefMouseEvent(pt.X, pt.Y, GetMouseModifiers(e.Button)), 0, e.Delta);



        }

        protected override void OnLostFocus(EventArgs e)
        {
            BrowserHost?.SendFocusEvent(false);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            BrowserHost?.SendFocusEvent(true);
        }
        #endregion

        const int WS_EX_LAYERED = 0x80000;

        protected override CreateParams CreateParams
        {
            get
            {
                // Add the layered extended style (WS_EX_LAYERED) to this window.
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_LAYERED;
                return createParams;
            }
        }
    }
}
