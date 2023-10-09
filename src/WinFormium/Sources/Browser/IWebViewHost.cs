// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Browser;
public interface IWebViewHost : IWebViewClient
{
    WinFormiumApp ApplicationContext { get; }

    Formium Formium { get; }

    string Url { get; set; }

    IntPtr WindowHandle { get; }

    Region? DraggableRegion { get; set; }

    CefBrowser? Browser { get; }

    CefBrowserHost? BrowserHost { get; }

    float GetScaleFactor();

    void Close();

    void ContextCreated(CefBrowser browser, CefFrame frame);

    void InvokeOnUIThread(Action action);

    bool IsOffscreenEnabled { get; }

    void HandleException(Exception exception);

}
