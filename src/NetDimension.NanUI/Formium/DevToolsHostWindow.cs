using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;
using Xilium.CefGlue;

namespace NetDimension.NanUI;

internal class DevToolsHostWindow : Form
{
    private readonly Formium owner;

    public DevToolsHostWindow(Formium owner)
    {
        Icon = Properties.Resources.DevToolsIcon;
        Text = Resources.Messages.HostWindow_DevToolsTitle;

        var screen = Screen.FromRectangle(owner.FormHostWindow.Bounds);

        var width = screen.WorkingArea.Width /2;
        var height = screen.WorkingArea.Height / 2;


        Size = new Size(width, height);

        this.owner = owner;

        SizeChanged += ResizeDevTools;


        Move += (_,_)=> Browser?.GetHost()?.NotifyMoveOrResizeStarted();
    }


    public IntPtr? BrowserWindowHandle { get; internal set; }
    public CefBrowser Browser { get; internal set; }

    private void ResizeDevTools(object sender, EventArgs e)
    {
        if (BrowserWindowHandle != null)
        {
            User32.SetWindowPos(BrowserWindowHandle.Value, HWND.NULL, 0, 0, this.ClientSize.Width, ClientSize.Height, User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOZORDER | User32.SetWindowPosFlags.SWP_NOACTIVATE);
        }

        Browser?.GetHost()?.NotifyMoveOrResizeStarted();


    }
}
