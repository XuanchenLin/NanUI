// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class FullscreenModeChangeEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public bool Fullscreen { get; }

    public FullscreenModeChangeEventArgs(CefBrowser browser, bool fullscreen)
    {
        Browser = browser;
        Fullscreen = fullscreen;
    }

    public bool Cancel { get; set; } = false;

}
