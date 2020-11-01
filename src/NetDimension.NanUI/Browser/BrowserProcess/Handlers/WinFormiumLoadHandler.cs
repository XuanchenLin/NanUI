using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumLoadHandler : CefLoadHandler
    {
        private readonly Formium _owner;

        public WinFormiumLoadHandler(Formium owner)
        {
            _owner = owner;

        }

        protected override void OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
        {
            var e = new LoadStartEventArgs(frame, transitionType);
            _owner.InvokeIfRequired(()=>_owner.OnLoadStart(e));
        }

        protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            var e = new LoadEndEventArgs(frame, httpStatusCode);
            _owner.InvokeIfRequired(() => _owner.OnLoadEnd(e));

            if(frame.IsMain && httpStatusCode == 200)
            {
                frame.ExecuteJavaScript($"{JavaScript.JavaScriptCommunicationBridge.ROOT_OBJECT_KEY_TARGET}._setDomReady()", frame.Url, 0);
            }
        }

        protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
            var e = new LoadErrorEventArgs(frame, errorCode, errorText, failedUrl);
            _owner.InvokeIfRequired(() => _owner.OnLoadError(e));
        }

        protected override void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
        {
            var e = new LoadingStateChangeEventArgs(isLoading, canGoBack, canGoForward);
            _owner.InvokeIfRequired(() => _owner.OnLoadingStateChanged(e));
        }

    }

    public class LoadStartEventArgs : EventArgs
    {
        internal LoadStartEventArgs(
            CefFrame frame,
            CefTransitionType transitionType)
        {
            Frame = frame;
            TransitionType = transitionType;
        }

        public CefFrame Frame { get; }
        public CefTransitionType TransitionType { get; }
    }

    public sealed class LoadEndEventArgs : EventArgs
    {
        internal LoadEndEventArgs(CefFrame frame, int httpStatusCode)
        {
            Frame = frame;
            HttpStatusCode = httpStatusCode;
        }

        public CefFrame Frame { get; }
        public int HttpStatusCode { get; }
    }

    public sealed class LoadErrorEventArgs : EventArgs
    {
        internal LoadErrorEventArgs(CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
            Frame = frame;
            ErrorCode = errorCode;
            ErrorText = errorText;
            FailedUrl = failedUrl;
        }

        public CefFrame Frame { get; }
        public CefErrorCode ErrorCode { get; }
        public string ErrorText { get; }
        public string FailedUrl { get; }
    }

    public sealed class LoadingStateChangeEventArgs : EventArgs
    {
        internal LoadingStateChangeEventArgs(bool isLoading, bool canGoBack, bool canGoForward)
        {
            IsLoading = isLoading;
            CanGoBack = canGoBack;
            CanGoForward = canGoForward;
        }

        public bool IsLoading { get; }
        public bool CanGoBack { get; }
        public bool CanGoForward { get; }
    }
}
