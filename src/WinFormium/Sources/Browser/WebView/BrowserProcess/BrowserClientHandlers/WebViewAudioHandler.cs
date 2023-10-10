// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class WebViewAudioHandler : CefAudioHandler
{
    public IAudioHandler Handler { get; }

    public WebViewAudioHandler(IAudioHandler handler)
    {
        Handler = handler;
    }


    protected override bool GetAudioParameters(CefBrowser browser, CefAudioParameters parameters)
    {
        return Handler.GetAudioParameters(browser, parameters);
    }

    protected override void OnAudioStreamError(CefBrowser browser, string message)
    {
        Handler.OnAudioStreamError(browser, message);
    }

    protected override void OnAudioStreamPacket(CefBrowser browser, nint data, int frames, long pts)
    {
        Handler.OnAudioStreamPacket(browser, data, frames, pts);
    }

    protected override void OnAudioStreamStarted(CefBrowser browser, in CefAudioParameters parameters, int channels)
    {
        Handler.OnAudioStreamStarted(browser, parameters, channels);
    }

    protected override void OnAudioStreamStopped(CefBrowser browser)
    {
        Handler.OnAudioStreamStopped(browser);
    }
}
