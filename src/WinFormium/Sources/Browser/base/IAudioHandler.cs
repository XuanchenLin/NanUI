// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IAudioHandler
{
    bool GetAudioParameters(CefBrowser browser, CefAudioParameters parameters);
    void OnAudioStreamError(CefBrowser browser, string message);

    void OnAudioStreamStarted(CefBrowser browser, in CefAudioParameters parameters, int channels);

    void OnAudioStreamPacket(CefBrowser browser, nint data, int frames, long pts);
    void OnAudioStreamStopped(CefBrowser browser);
}
