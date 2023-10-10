// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.DevTools;
internal class DevToolsWindow : StandardWindowForm
{
    public WebView WebView { get; }

    public IntPtr? BrowserWindowHandle { get; internal set; }

    public DevToolsWindow(WebView webview)
        : base(false, false)
    {

        WebView = webview;

        User32.GetWindowRect(webview.WindowHandle, out var rect);


        var screen = Screen.FromRectangle(rect);

        var width = 1440;
        var height = 900;

        if(width > screen.WorkingArea.Width) width = screen.WorkingArea.Width - 20;

        if(height > screen.WorkingArea.Height) height = screen.WorkingArea.Height - 20;


        Size = new Size(width, height);

        Icon = Properties.Resources.DevToolsIcon;

        Text = $"DevTools - {Properties.Messages.DevTools_Window_Title}";




        SizeChanged += (_, _) =>
        {
            if (BrowserWindowHandle != null)
            {
                User32.SetWindowPos(BrowserWindowHandle.Value, HWND.NULL, 0, 0, ClientSize.Width, ClientSize.Height, User32.SetWindowPosFlags.SWP_NOMOVE | User32.SetWindowPosFlags.SWP_NOZORDER | User32.SetWindowPosFlags.SWP_NOACTIVATE);

            }
        };
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        //System.Diagnostics.Debug.WriteLine($"{nameof(OnShown)} -> Thread {Thread.CurrentThread.ManagedThreadId}");

    }

}
