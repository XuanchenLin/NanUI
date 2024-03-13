// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Browser.ContextMenu;
using WinFormium.Properties;

namespace WinFormium.Browser;
internal partial class WebView : IContextMenuHandler
{


    public void CloseContextMenu()
    {
        if (_contextMenu != null)
        {
            if (_contextMenu.InvokeRequired)
            {
                _contextMenu?.Invoke(new System.Windows.Forms.MethodInvoker(() => _contextMenu.Close(ToolStripDropDownCloseReason.AppClicked)));
            }
            else
            {
                _contextMenu.Close(ToolStripDropDownCloseReason.AppClicked);
            }
        }
    }

    #region interface
    void IContextMenuHandler.OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
    {
        if (WebViewHost.ContextMenuHandler != null)
        {
            WebViewHost.ContextMenuHandler.OnBeforeContextMenu(browser, frame, state, model);
            return;
        }

        OnBeforeContextMenu(browser, frame, state, model);
    }

    bool IContextMenuHandler.OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {

        if (WebViewHost.ContextMenuHandler != null)
        {
            return WebViewHost.ContextMenuHandler.OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
        }

        return OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
    }
    bool IContextMenuHandler.RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {

        if (WebViewHost.ContextMenuHandler != null)
        {
            return WebViewHost.ContextMenuHandler.RunContextMenu(browser, frame, parameters, model, callback);
        }

        return RunContextMenu(browser, frame, parameters, model, callback);
    }
    void IContextMenuHandler.OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        if (WebViewHost.ContextMenuHandler != null)
        {
            WebViewHost.ContextMenuHandler?.OnContextMenuDismissed(browser, frame);
            return;
        }

        CloseContextMenu();
    }

    bool IContextMenuHandler.OnQuickMenuCommand(CefBrowser browser, CefFrame frame, int commandId, CefEventFlags eventFlags)
    {
        return WebViewHost.ContextMenuHandler?.OnQuickMenuCommand(browser, frame, commandId, eventFlags) ?? false;
    }

    void IContextMenuHandler.OnQuickMenuDismissed(CefBrowser browser, CefFrame frame)
    {
        WebViewHost.ContextMenuHandler?.OnQuickMenuDismissed(browser, frame);
    }
    bool IContextMenuHandler.RunQuickMenu(CefBrowser browser, CefFrame frame, CefPoint location, CefSize size, CefQuickMenuEditStateFlags editStateFlags, CefRunQuickMenuCallback callback)
    {
        return WebViewHost.ContextMenuHandler?.RunQuickMenu(browser, frame, location, size, editStateFlags, callback) ?? false;
    }
    #endregion

    #region implements
    private static List<ContextMenuItem> _defaultContextMenuItems = new()
    {
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_UNDO, Text = Messages.ContextMenu_Undo, Icon = Resources.undo_16px, ShortKeys = Keys.Control | Keys.Z },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_REDO, Text = Messages.ContextMenu_Redo, Icon = Resources.redo_16px, /*ShortKeys = Keys.Control | Keys.Y*/ },

        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_CUT, Text = Messages.ContextMenu_Cut, Icon = Resources.cut_16px, ShortKeys = Keys.Control | Keys.X },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_COPY, Text = Messages.ContextMenu_Copy, Icon = Resources.copy_16px, ShortKeys = Keys.Control | Keys.C  },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_PASTE, Text = Messages.ContextMenu_Paste, Icon = Resources.paste_16px, ShortKeys = Keys.Control | Keys.V  },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_DELETE, Text = Messages.ContextMenu_Delete },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_SELECT_ALL, Text = Messages.ContextMenu_SelectAll, /*ShortKeys = Keys.Control | Keys.A */ },

        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_SHOW_DEVTOOLS, Text = Messages.ContextMenu_ShowDevTools, Icon = Resources.devtools_16px/*, ShortKeys = Keys.Control | Keys.Shift | Keys.C*/ },
        new ContextMenuItem{ CommandId = (int)CefMenuIdentifiers.MENU_ID_HIDE_DEVTOOLS, Text = Messages.ContextMenu_CloseDevTools, Icon = Resources.devtools_16px/*, ShortKeys = Keys.Control | Keys.Shift | Keys.C */},

    };

    private AnimatedContextMenuStrip? _contextMenu;

    private void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
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

        if (App.EnableDevTools)
        {

            if (model.Count > 0)
            {
                model.InsertSeparatorAt(0);
            }

            if (BrowserHost?.HasDevTools ?? false)
            {
                model.InsertItemAt(0, (int)CefMenuIdentifiers.MENU_ID_HIDE_DEVTOOLS, Messages.ContextMenu_CloseDevTools);
            }
            else
            {
                model.InsertItemAt(0, (int)CefMenuIdentifiers.MENU_ID_SHOW_DEVTOOLS, Messages.ContextMenu_ShowDevTools);
            }
        }

    }

    private bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
    {

        if (commandId == (int)CefMenuIdentifiers.MENU_ID_SHOW_DEVTOOLS)
        {
            ShowDevTools();
            return true;
        }

        if (commandId == (int)CefMenuIdentifiers.MENU_ID_HIDE_DEVTOOLS)
        {
            HideDevTools();
            return true;
        }

        return false;
    }


    private bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
    {

        var scaleFactor = WebViewHost.GetScaleFactor();

        var point = new POINT((int)(parameters.X * scaleFactor), (int)(parameters.Y * scaleFactor));

        User32.ClientToScreen(WindowHandle, ref point);

        var menuItems = CreateContextMenu(parameters, model);


        if (WebViewHost.IsOffscreenEnabled)
        {
            WebViewHost.InvokeOnUIThread(() =>
            {
                ShowContextMenu(callback, point, menuItems);
            });
        }
        else
        {
            ShowContextMenu(callback, point, menuItems);
        }

        return true;
    }

    private List<ContextMenuItem> CreateContextMenu(CefContextMenuParams menuParams, CefMenuModel model)
    {
        List<ContextMenuItem> items = new();

        CreateContentMenuItems(items, model);

        var item = items.SingleOrDefault(x => x.CommandId == (int)CefMenuIdentifiers.MENU_ID_REDO);

        if (item != null)
        {
            var idx = items.IndexOf(item);

            var place = idx + 1;

            if (place < items.Count - 1)
            {
                items.Insert(place, new ContextMenuItem { IsSeperator = true });
            }

        };
        return items;
    }


    private void CreateContentMenuItems(List<ContextMenuItem> items, CefMenuModel model)
    {
        for (var i = 0; i < (int)model.Count; i++)
        {
            var type = model.GetItemTypeAt((UIntPtr)i);

            bool? isChecked = null;

            if (type == CefMenuItemType.Check)
            {
                isChecked = model.IsCheckedAt((UIntPtr)i);
            }

            var cmdId = model.GetCommandIdAt((UIntPtr)i);

            var text = model.GetLabelAt((UIntPtr)i);

            var isEnabled = model.IsEnabledAt((UIntPtr)i);

            var defaultContextMenuItem = _defaultContextMenuItems.SingleOrDefault(x => x.CommandId == cmdId);

            if (defaultContextMenuItem != null)
            {
                defaultContextMenuItem.IsEnabled = isEnabled;
                defaultContextMenuItem.IsChecked = isChecked;
            }

            switch (type)
            {
                case CefMenuItemType.Separator:
                    items.Add(new() { IsSeperator = true });
                    break;
                case CefMenuItemType.Command:
                case CefMenuItemType.Check:
                case CefMenuItemType.Radio:
                    {
                        items.Add(defaultContextMenuItem ?? new ContextMenuItem
                        {
                            CommandId = cmdId,
                            Text = text,
                            IsEnabled = isEnabled,
                            IsChecked = isChecked,
                            MenuItemType = type,
                        });
                    }
                    break;
                case CefMenuItemType.SubMenu:
                    {


                        var subItems = model.GetSubMenuAt((UIntPtr)i);
                        if (subItems != null)
                        {
                            var subMenus = new List<ContextMenuItem>();
                            var menuItem = new ContextMenuItem
                            {
                                CommandId = cmdId,
                                Text = text,
                                IsEnabled = isEnabled,
                                IsChecked = isChecked,
                                MenuItemType = type,
                                SubMenus = new List<ContextMenuItem>()
                            };

                            CreateContentMenuItems(subMenus, subItems);

                            items.Add(menuItem);
                        }
                    }
                    break;
                case CefMenuItemType.None:
                default:
                    break;
            }
        }
    }



    private void ShowContextMenu(CefRunContextMenuCallback callback, Point point, List<ContextMenuItem> menuItems)
    {

        _contextMenu?.Close();
        _contextMenu?.Dispose();
        _contextMenu = null;

        var scaleFactor = WebViewHost.GetScaleFactor();

        var contextMenu = new AnimatedContextMenuStrip()
        {
            Renderer = new ContextMenuStripRenderer(ColorMode == WebViewColorMode.Dark),
            Font = new Font("Segoe UI", 10.25f * scaleFactor, FontStyle.Regular, GraphicsUnit.Point, 0),
        };

        ToolStripDropDownClosedEventHandler? closeHandler = null;
        ToolStripItemClickedEventHandler? clickHandler = null;

        clickHandler = (s, e) =>
        {
            var target = (AnimatedContextMenuStrip)s!;

            var targetItem = e.ClickedItem;

            if (targetItem != null)
            {
                var config = (ContextMenuItem)targetItem.Tag;

                callback?.Continue(config.CommandId, CefEventFlags.LeftMouseButton);
            }

            target.ItemClicked -= clickHandler;

            target.Close();
        };

        closeHandler = (s, e) =>
        {
            var target = (AnimatedContextMenuStrip)s!;

            if (callback != null)
            {
                callback.Cancel();
            }

            target.Closed -= closeHandler;
        };


        contextMenu.ItemClicked += clickHandler;
        contextMenu.Closed += closeHandler;

        contextMenu.Items.Clear();


        BuildContextMenu(contextMenu.Items, menuItems);


        contextMenu.Show(point);

        _contextMenu = contextMenu;

        //System.Diagnostics.Debug.WriteLine($"{nameof(ShowContextMenu)} -> Thread {Thread.CurrentThread.ManagedThreadId}");

    }

    private void BuildContextMenu(ToolStripItemCollection items, List<ContextMenuItem> menuItems)
    {
        foreach (var item in menuItems)
        {
            if (item.IsSeperator)
            {
                items.Add(new ToolStripSeparator());

                continue;
            }
            var menuItem = new ToolStripMenuItem
            {
                Name = $"{item.CommandId}",
                Text = item.Text,
                Image = item.Icon,
                Enabled = item.IsEnabled,
                Checked = item.IsChecked.GetValueOrDefault(),
                ShowShortcutKeys = item.ShortKeys.HasValue,
                ShortcutKeys = item.ShortKeys ?? Keys.None,
                Tag = item
            };

            if (item.SubMenus != null)
            {
                BuildContextMenu(menuItem.DropDownItems, item.SubMenus);
            }

            items.Add(menuItem);
        }
    }

    #endregion
}
