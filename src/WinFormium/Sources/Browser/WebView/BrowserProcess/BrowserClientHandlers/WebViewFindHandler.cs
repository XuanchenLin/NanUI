// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Browser;
internal class WebViewFindHandler : CefFindHandler
{
    public IFindHandler Handler { get; }

    public WebViewFindHandler(IFindHandler handler)
    {
        Handler = handler;
    }

    protected override void OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
    {
        Handler.OnFindResult(browser, identifier, count, selectionRect, activeMatchOrdinal, finalUpdate);
    }

}
