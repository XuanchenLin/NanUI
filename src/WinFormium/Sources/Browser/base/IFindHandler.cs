// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
public interface IFindHandler
{
    bool OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate);
}
