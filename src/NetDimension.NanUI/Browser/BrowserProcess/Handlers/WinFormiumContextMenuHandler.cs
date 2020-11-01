using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{

    internal static class ContextMenuHelper
    {

        const int MENU_ID_USER_FIRST = 26500;
        const int MENU_ID_USER_LAST = 28400;

        public enum MenuIdentifier
        {
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

        public WinFormiumContextMenuHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
        {
            

            for(var index = model.Count-1; index>=0; index--)
            {
                var nCmd = model.GetCommandIdAt(index);

                if(!ContextMenuHelper.IsEdition(nCmd) && !ContextMenuHelper.IsUserDefined(nCmd))
                {
                    model.Remove(nCmd);
                }
            }

            if (WinFormium.Runtime.IsDebuggingMode && (state.ContextMenuType & CefContextMenuTypeFlags.Editable) != CefContextMenuTypeFlags.Editable)
            {
                if(model.Count > 0)
                {
                    model.AddSeparator();
                }

                model.AddItem((int)((CefMenuId)ContextMenuHelper.MenuIdentifier.MENU_ID_SHOW_DEVTOOLS), Resources.Messages.ContextMenu_ShowDevTools);
                model.AddItem((int)((CefMenuId)ContextMenuHelper.MenuIdentifier.MENU_ID_HIDE_DEVTOOLS), Resources.Messages.ContextMenu_CloseDevTools);
            }

            var e = new BeforeContextMenuEventArgs(frame, state, model);



            _owner.InvokeIfRequired(() => _owner.OnBeforeContextMenu(e));

        }

        protected override bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
        {
            

            return false;
        }

        protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
        {
            base.OnContextMenuDismissed(browser, frame);
        }

        protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
        {
            if(commandId == (int)ContextMenuHelper.MenuIdentifier.MENU_ID_SHOW_DEVTOOLS)
            {
                _owner.ShowDevTools();
                return true;
            }

            if (commandId == (int)ContextMenuHelper.MenuIdentifier.MENU_ID_HIDE_DEVTOOLS)
            {
                _owner.WebView.BrowserHost.CloseDevTools();
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
}
