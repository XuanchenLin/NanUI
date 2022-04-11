using Vanara.PInvoke;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser;

internal static class ContextMenuHelper
{

    const int MENU_ID_USER_FIRST = 26500;
    const int MENU_ID_USER_LAST = 28400;

    public enum MenuIdentifier
    {
        NOT_FOUND = -1,

        // Navigation.
        MENU_ID_BACK = 100,
        MENU_ID_FORWARD = 101,
        MENU_ID_RELOAD = 102,
        MENU_ID_RELOAD_NOCACHE = 103,
        MENU_ID_STOPLOAD = 104,

        // Editing.
        MENU_ID_UNDO = 110,
        MENU_ID_REDO = 111,
        MENU_ID_CUT = 112,
        MENU_ID_COPY = 113,
        MENU_ID_PASTE = 114,
        MENU_ID_DELETE = 115,
        MENU_ID_SELECT_ALL = 116,

        // Miscellaneous.
        MENU_ID_FIND = 130,
        MENU_ID_PRINT = 131,
        MENU_ID_VIEW_SOURCE = 132,

        // All user-defined menu IDs should come between MENU_ID_USER_FIRST and
        // MENU_ID_USER_LAST to avoid overlapping the Chromium and CEF ID ranges
        // defined in the tools/gritsettings/resource_ids file.
        //MENU_ID_USER_FIRST = 26500,
        //MENU_ID_USER_LAST = 28500,

        MENU_ID_SHOW_DEVTOOLS = 28500,
        MENU_ID_HIDE_DEVTOOLS = 28499
    }


    public static bool IsEdition(MenuIdentifier contextMenuId)
    {
        var intValue = (int)contextMenuId;
        return IsEdition(intValue);
    }

    public static bool IsEdition(int intValue)
    {
        return (intValue >= (int)MenuIdentifier.MENU_ID_UNDO) && (intValue <= (int)MenuIdentifier.MENU_ID_SELECT_ALL);
    }

    public static bool IsUserDefined(int intValue)
    {
        return (intValue > MENU_ID_USER_FIRST) && (intValue < MENU_ID_USER_LAST);
    }



}

internal sealed class WinFormiumContextMenuHandler : CefContextMenuHandler
{
    private readonly Formium _owner;
    private readonly BrowserClient browserClient;

    public WinFormiumContextMenuHandler(Formium owner, BrowserClient browserClient)
    {
        _owner = owner;
        this.browserClient = browserClient;
    }

    protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {


        for (var index = model.Count - 1; index >= 0; index--)
        {
            var nCmd = model.GetCommandIdAt(index);

            if (!ContextMenuHelper.IsEdition(nCmd) && !ContextMenuHelper.IsUserDefined(nCmd))
            {
                model.Remove(nCmd);
            }
        }

        if (WinFormium.Runtime.IsDebuggingMode && (state.ContextMenuType & CefContextMenuTypeFlags.Editable) != CefContextMenuTypeFlags.Editable)
        {
            if (model.Count > 0)
            {
                model.AddSeparator();
            }

            model.AddItem((int)((CefMenuId)ContextMenuHelper.MenuIdentifier.MENU_ID_SHOW_DEVTOOLS), Resources.Messages.ContextMenu_ShowDevTools);
            model.AddItem((int)((CefMenuId)ContextMenuHelper.MenuIdentifier.MENU_ID_HIDE_DEVTOOLS), Resources.Messages.ContextMenu_CloseDevTools);
        }

        var e = new BeforeContextMenuEventArgs(frame, state, model);


        if (browserClient._renderHandler == null)
        {
            _owner.OnBeforeContextMenu(e);
        }
        else
        {
            _owner.InvokeIfRequired(() => _owner.OnBeforeContextMenu(e));
        }

        //

    }

    internal class NanUIMenuStripRenderer : ToolStripProfessionalRenderer
    {
        public class MyColorTable : ProfessionalColorTable
        {
            //public override Color MenuItemBorder
            //{
            //    get { return Color.WhiteSmoke; }
            //}
            //public override Color MenuItemSelected
            //{
            //    get { return Color.WhiteSmoke; }
            //}
            public override Color ToolStripDropDownBackground
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
        }

        public NanUIMenuStripRenderer()
            : base(new MyColorTable())
        {
        }
    }

    protected override bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {

        var scaleFactor = DpiHelper.GetScaleFactorForWindow(_owner.HostWindowHandle);

        var point = new POINT((int)(parameters.X * scaleFactor), (int)(parameters.Y * scaleFactor));

        User32.ClientToScreen(_owner.HostWindowHandle, ref point);

        var selectedText = parameters.SelectionText;

        var menuItems = GenerateMenuItem(model);

        if(browserClient._renderHandler == null)
        {
            ShowContextMenu(callback, point, menuItems);
        }
        else
        {
            _owner.InvokeIfRequired(() =>
            {
                ShowContextMenu(callback, point, menuItems);
            });
        }

        return true;
    }

    private void ShowContextMenu(CefRunContextMenuCallback callback, Point point, List<MenuItemConfigurattion> menuItems)
    {
        var contextMenu = new ContextMenuStrip
        {
            Renderer = new NanUIMenuStripRenderer()
        };

        ToolStripDropDownClosedEventHandler closeHandler = null;
        ToolStripItemClickedEventHandler clickHandler = null;

        clickHandler = (sender, e) =>
        {
            clickHandler -= clickHandler;
            var targetItem = e.ClickedItem;
            var config = (MenuItemConfigurattion)targetItem.Tag;
            if (config != null)
            {
                callback.Continue(config.CommandId, CefEventFlags.LeftMouseButton);
            }


        };

        closeHandler = (s, e) =>
        {
            contextMenu.Closed -= closeHandler;

            if (callback != null)
            {
                callback.Cancel();
            }


        };

        contextMenu.ItemClicked += clickHandler;
        contextMenu.Closed += closeHandler;

        contextMenu.Items.Clear();

        GenerateContextMenuItems(contextMenu, null, menuItems);

        contextMenu.Show(point);
    }

    private void GenerateContextMenuItems(ContextMenuStrip contextMenu, ToolStripMenuItem parent, IEnumerable<MenuItemConfigurattion> config)
    {


        foreach (var item in config)
        {
            if (item.CommandId == (int)ContextMenuHelper.MenuIdentifier.NOT_FOUND)
            {
                continue;
            }

            if (item.IsSeperator)
            {
                if (contextMenu != null)
                {
                    contextMenu.Items.Add(new ToolStripSeparator());
                }
                else
                {
                    parent.DropDownItems.Add(new ToolStripSeparator());
                }
                continue;
            }

            var menuItem = new ToolStripMenuItem
            {
                Name = $"{item.CommandId}",
                Text = item.Text,
                Enabled = item.IsEnabled,
                Checked = item.IsChecked.GetValueOrDefault(),
                Tag = item
            };

            if (item.SubMenus != null && item.SubMenus.Count > 0)
            {
                GenerateContextMenuItems(null, menuItem, item.SubMenus);
            }

            if (contextMenu != null)
            {
                contextMenu.Items.Add(menuItem);
            }
            else
            {
                parent.DropDownItems.Add(menuItem);
            }
        }
    }


    class MenuItemConfigurattion
    {
        public string Text { get; set; }
        public int CommandId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSeperator { get; set; }
        public bool? IsChecked { get; set; }
        public CefMenuItemType MenuItemType { get; set; }
        public List<MenuItemConfigurattion> SubMenus { get; set; }
    }

    private List<MenuItemConfigurattion> GenerateMenuItem(CefMenuModel model)
    {
        var retval = new List<MenuItemConfigurattion>();


        for (var i = 0; i < model.Count; i++)
        {
            var type = model.GetItemTypeAt(i);
            bool? isChecked = null;

            if (type == CefMenuItemType.Check)
            {
                isChecked = model.IsCheckedAt(i);
            }

            var subItems = model.GetSubMenuAt(i);

            List<MenuItemConfigurattion> subMenus = subItems == null ? null : GenerateMenuItem(subItems);

            retval.Add(new MenuItemConfigurattion
            {
                Text = model.GetLabelAt(i),
                CommandId = model.GetCommandIdAt(i),
                IsEnabled = model.IsEnabledAt(i),
                IsChecked = isChecked,
                MenuItemType = type,
                SubMenus = subMenus,
                IsSeperator = type == CefMenuItemType.Separator
            });

        }

        return retval;
    }

    protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        base.OnContextMenuDismissed(browser, frame);

        //var menu = _owner.FormHostWindow.ContextMenuStrip;

        //if (menu != null)
        //{
        //    _owner.InvokeIfRequired(() => {
        //        menu.Close();
        //        menu.Dispose();
        //        _owner.FormHostWindow.ContextMenuStrip = null;
        //    });

        //}
    }

    protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {
        if (commandId == (int)ContextMenuHelper.MenuIdentifier.MENU_ID_SHOW_DEVTOOLS)
        {
            _owner.ShowDevTools();
            return true;
        }

        if (commandId == (int)ContextMenuHelper.MenuIdentifier.MENU_ID_HIDE_DEVTOOLS)
        {
            _owner.CloseDevTools();
            return true;
        }

        var e = new ContextMenuCommandEventArgs(frame, state, commandId, eventFlags);

        _owner.InvokeIfRequired(() => _owner.OnContextMenuCommand(e));

        return e.Handled;
    }
}

public sealed class BeforeContextMenuEventArgs : EventArgs
{
    public const int UserCustomMenuItemIdLowerBound = 26500;
    public const int UserCustomMenuItemIdUpperBound = 28400;

    internal BeforeContextMenuEventArgs(CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
        Frame = frame;
        State = state;
        Model = model;
    }

    public CefFrame Frame { get; }
    public CefContextMenuParams State { get; }
    public CefMenuModel Model { get; }
}

public sealed class ContextMenuCommandEventArgs : EventArgs
{
    internal ContextMenuCommandEventArgs(CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlag)
    {
        Frame = frame;
        State = state;
        CommandId = commandId;
        EventFlag = eventFlag;
    }

    public CefFrame Frame { get; }
    public CefContextMenuParams State { get; }
    public int CommandId { get; }
    public CefEventFlags EventFlag { get; }

    public bool Handled { get; set; } = false;

}
