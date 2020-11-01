using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumDisplayHandler : CefDisplayHandler
    {
        private Formium _owner;

        public WinFormiumDisplayHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
        {


            var e = new AddressChangedEventArgs(frame, url);


            _owner.InvokeIfRequired(() => _owner.OnAddressChanged(e));


        }

        protected override bool OnConsoleMessage(CefBrowser browser, CefLogSeverity level, string message, string source, int line)
        {
            var e = new ConsoleMessageEventArgs(level, message, source, line);

            _owner.InvokeIfRequired(() => _owner.OnConsoleMessage(e));

            return e.Handled;

        }

        protected override void OnFullscreenModeChange(CefBrowser browser, bool fullscreen)
        {
            var e = new FullScreenModeChangedEventArgs(fullscreen);
            _owner.InvokeIfRequired(()=> _owner.OnFullscreenModeChanged(e));
        }

        protected override void OnLoadingProgressChange(CefBrowser browser, double progress)
        {
            var e = new LoadingProgressChangedEventArgs(progress);


            _owner.InvokeIfRequired(() => _owner.OnLoadingProgressChanged(e));

        }

        protected override void OnStatusMessage(CefBrowser browser, string value)
        {
            var e = new StatusMessageEventArgs(value);

            _owner.InvokeIfRequired(() => _owner.OnStatusMessage(e));

        }

        protected override void OnTitleChange(CefBrowser browser, string title)
        {
            var e = new DocumentTitleChangedEventArgs(title);

            _owner.InvokeIfRequired(() => _owner.OnDocumentTitleChanged(e));

        }

    }

    public sealed class AddressChangedEventArgs : EventArgs
    {
        internal AddressChangedEventArgs(CefFrame frame, string url)
        {
            Frame = frame;
            Url = url;
        }

        public CefFrame Frame { get; }
        public string Url { get; }
    }

    public sealed class ConsoleMessageEventArgs : EventArgs
    {
        internal ConsoleMessageEventArgs(CefLogSeverity level, string message, string source, int line)
        {
            Level = level;
            Message = message;
            Source = source;
            Line = line;
        }

        public CefLogSeverity Level { get; }
        public string Message { get; }
        public string Source { get; }
        public int Line { get; }

        public bool Handled { get; set; }
    }

    public sealed class FullScreenModeChangedEventArgs: EventArgs
    {
        internal FullScreenModeChangedEventArgs(bool fullscreen)
        {
            Fullscreen = fullscreen;
        }

        public bool Fullscreen { get; }
    }

    public sealed class LoadingProgressChangedEventArgs : EventArgs
    {
        internal LoadingProgressChangedEventArgs(double progress)
        {
            Progress = progress;
        }

        public double Progress { get; }
    }

    public sealed class StatusMessageEventArgs : EventArgs
    {
        internal StatusMessageEventArgs(string messageText)
        {
            MessageText = messageText;
        }

        public string MessageText { get; }
    }

    public sealed class DocumentTitleChangedEventArgs : EventArgs
    {
        internal DocumentTitleChangedEventArgs(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
