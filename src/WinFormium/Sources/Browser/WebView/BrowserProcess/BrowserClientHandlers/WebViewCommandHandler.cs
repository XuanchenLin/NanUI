// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Browser;
internal class WebViewCommandHandler : CefCommandHandler
{
    public ICommandHandler Handler { get; }

    public WebViewCommandHandler(ICommandHandler handler)
    {
        Handler = handler;
    }

    protected override bool OnChromeCommand(CefBrowser browser, int commandId, CefWindowOpenDisposition disposition)
    {
        return Handler.OnChromeCommand(browser, commandId, disposition);
    }

}
