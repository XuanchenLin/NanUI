// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public abstract class FindHandler : IFindHandler
{
    bool IFindHandler.OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
    {
        return OnFindResult(browser, identifier, count, selectionRect, activeMatchOrdinal, finalUpdate);
    }

    protected virtual bool OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
    {
        return false;
    }
}
