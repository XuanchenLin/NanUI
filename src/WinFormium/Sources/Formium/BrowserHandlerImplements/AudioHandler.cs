// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class AudioHandler : IAudioHandler
{
    bool IAudioHandler.GetAudioParameters(CefBrowser browser, CefAudioParameters parameters)
    {
        return GetAudioParameters(browser, parameters);
    }

    void IAudioHandler.OnAudioStreamPacket(CefBrowser browser, IntPtr data, int frames, long pts)
    {
        OnAudioStreamPacket(browser, data, frames, pts);
    }

    void IAudioHandler.OnAudioStreamStarted(CefBrowser browser, in CefAudioParameters parameters, int channels)
    {
        OnAudioStreamStarted(browser, parameters, channels);
    }

    void IAudioHandler.OnAudioStreamError(CefBrowser browser, string message)
    {
        OnAudioStreamError(browser, message);
    }

    void IAudioHandler.OnAudioStreamStopped(CefBrowser browser)
    {
        OnAudioStreamStopped(browser);
    }


    protected virtual bool GetAudioParameters(CefBrowser browser, CefAudioParameters parameters)
    {
        return false;
    }

    protected virtual void OnAudioStreamPacket(CefBrowser browser, IntPtr data, int frames, long pts)
    {
    }

    protected virtual void OnAudioStreamStarted(CefBrowser browser, in CefAudioParameters parameters, int channels)
    {
    }

    protected virtual void OnAudioStreamStopped(CefBrowser browser)
    {
    }

    protected virtual void OnAudioStreamError(CefBrowser browser, string message)
    {
    }


}
