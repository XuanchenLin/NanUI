// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

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
