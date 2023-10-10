// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser.DevTools;
internal class DevToolsClient : CefClient
{
    public DevToolsWindow DevToolsWindow { get; }

    public DevToolsClient(DevToolsWindow devToolsWindow)
    {
        DevToolsWindow = devToolsWindow;
    }

    protected override CefLifeSpanHandler? GetLifeSpanHandler()
    {
        return new DevToolsLifeSpanHandler(DevToolsWindow);
    }

}
