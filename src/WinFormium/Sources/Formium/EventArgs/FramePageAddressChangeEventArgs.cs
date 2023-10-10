// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class FramePageAddressChangeEventArgs : EventArgs
{
    public CefBrowser Browser { get; }
    public CefFrame Frame { get; }
    public string Address { get; }

    public FramePageAddressChangeEventArgs(CefBrowser browser, CefFrame frame, string address)
    {
        Browser = browser;
        Frame = frame;
        Address = address;
    }
}
