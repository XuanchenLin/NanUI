// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class MediaAccessChangeEventArgs : EventArgs
{
    public MediaAccessChangeEventArgs(CefBrowser browser, bool hasVideoAccess, bool hasAudioAccess)
    {
        Browser = browser;
        HasVideoAccess = hasVideoAccess;
        HasAudioAccess = hasAudioAccess;
    }

    public CefBrowser Browser { get; }
    public bool HasVideoAccess { get; }
    public bool HasAudioAccess { get; }
}
