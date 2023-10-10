// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.DevTools;
internal class DevToolsLifeSpanHandler : CefLifeSpanHandler
{
    private DevToolsWindow _hostWindow;

    public DevToolsLifeSpanHandler(DevToolsWindow hostWindow)
    {
        _hostWindow = hostWindow;
    }

    protected override void OnAfterCreated(CefBrowser browser)
    {
        base.OnAfterCreated(browser);

        var window = _hostWindow;

        var initAction = new Action(() =>
        {
            window.BrowserWindowHandle = browser.GetHost().GetWindowHandle();
            window.SizeChanged += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
            window.ResizeBegin += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
            window.ResizeEnd += (_, _) => browser?.GetHost()?.WasResized();
            window.Move += (_, _) => browser?.GetHost()?.NotifyMoveOrResizeStarted();
        });


        if(window.InvokeRequired)
        {
            window.Invoke(initAction);
        }
        else
        {
            initAction.Invoke();
        }



    }

}
