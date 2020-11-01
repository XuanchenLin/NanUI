using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumKeyboardHandler : CefKeyboardHandler
    {
        private readonly Formium _owner;

        public WinFormiumKeyboardHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override bool OnKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, IntPtr osEvent)
        {
            var e = new KeyEventArgs(keyEvent, osEvent);

            _owner.OnKeyEvent(e);

            return e.Handled;
        }

        protected override bool OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, IntPtr os_event, out bool isKeyboardShortcut)
        {
            var e = new PreKeyEventArgs(keyEvent, os_event);

            _owner.OnPreKeyEvent(e);

            isKeyboardShortcut = e.IsKeyboardShortcut;

            return e.Handled;
        }
    }

    public sealed class KeyEventArgs: EventArgs
    {
        internal KeyEventArgs(CefKeyEvent keyEvent, IntPtr osEvent)
        {
            KeyEvent = keyEvent;
            OsEvent = osEvent;
        }

        public bool Handled { get; set; } = false;
        public CefKeyEvent KeyEvent { get; }
        public IntPtr OsEvent { get; }
    }

    public sealed class PreKeyEventArgs : EventArgs
    {
        internal PreKeyEventArgs(CefKeyEvent keyEvent, IntPtr osEvent)
        {
            KeyEvent = keyEvent;
            OsEvent = osEvent;
        }

        public bool IsKeyboardShortcut { get; set; } = false;

        public bool Handled { get; set; } = false;
        public CefKeyEvent KeyEvent { get; }
        public IntPtr OsEvent { get; }
    }
}
