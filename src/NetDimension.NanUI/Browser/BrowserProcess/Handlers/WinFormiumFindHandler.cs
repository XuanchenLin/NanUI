using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumFindHandler : CefFindHandler
    {
        private readonly Formium _owner;

        public WinFormiumFindHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override void OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
        {
            var e = new FindResultEventArgs(count, selectionRect, activeMatchOrdinal, finalUpdate);
            _owner.OnFindResult(e);
        }

        
    }

    public sealed class FindResultEventArgs : EventArgs
    {
        internal FindResultEventArgs(int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
        {
            Count = count;
            SelectionRect = selectionRect;
            ActiveMatchOrdinal = activeMatchOrdinal;
            FinalUpdate = finalUpdate;
        }

        public int Index { get; }
        public int Count { get; }
        public CefRectangle SelectionRect { get; }
        public int ActiveMatchOrdinal { get; }
        public bool FinalUpdate { get; }
    }
}
