// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Browser.ContextMenu;

namespace WinFormium.Browser.EmbeddedBrowser;
internal class EmbeddedBrowserContextMenuHandler : CefContextMenuHandler
{

    public EmbeddedlBrowserClient BrowserClient { get; }

    public EmbeddedBrowserContextMenuHandler(EmbeddedlBrowserClient browserClient)
    {
        BrowserClient = browserClient;
    }

    protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
        List<int> removeCmds = new();

        for (var i = 0; i < (int)model.Count; i++)
        {
            var nCmd = model.GetCommandIdAt((nuint)i);


            if (!ContextMenuHelper.IsEditingItem(nCmd) && !ContextMenuHelper.IsUserDefinedItem(nCmd))
            {
                removeCmds.Add(nCmd);
            }
        }

        foreach (var cmdId in removeCmds)
        {
            model.Remove(cmdId);
        }
    }

    protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        return base.OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
    }

    protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        base.OnContextMenuDismissed(browser, frame);
    }

    protected override bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {
        return base.RunContextMenu(browser, frame, parameters, model, callback);
    }

}
