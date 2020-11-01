using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal class WinFormiumFocusHandler : CefFocusHandler
    {
        private readonly Formium _owner;

        public WinFormiumFocusHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override void OnGotFocus(CefBrowser browser)
        {
            _owner.OnGotFocus(EventArgs.Empty);

        }

        protected override bool OnSetFocus(CefBrowser browser, CefFocusSource source)
        {
            var e = new SetFocusEventArgs(source);

            _owner.OnSetFocus(e);


            return !e.Cancel;
        }

        protected override void OnTakeFocus(CefBrowser browser, bool next)
        {
            var e = new TakeFocusEventArgs(next);

            _owner.OnTakeFocus(e);


        }
    }

    public sealed class SetFocusEventArgs : EventArgs
    { 
        public SetFocusEventArgs(CefFocusSource source)
        {
            Source = source;
        }

        public CefFocusSource Source { get; }

        public bool Cancel { get; set; } = false;
    }

    public sealed class TakeFocusEventArgs : EventArgs
    {
        public TakeFocusEventArgs(bool next)
        {
            Next = next;
        }

        public bool Next { get; }
    }
}
