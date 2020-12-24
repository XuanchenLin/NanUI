using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumRequestHandler : CefRequestHandler
    {
        private Formium _owner;

        public WinFormiumRequestHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override CefResourceRequestHandler GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            var e = new GetResourceRequestHandlerEventArgs(browser, frame, request, isNavigation, isDownload, requestInitiator);

            _owner.OnGetResourceRequestHandler(e);

            disableDefaultHandling = e.DisableDefaultHandling;

            return e.Handler;
        }

        protected override bool OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
        {

            if (frame.IsMain)
            {
                var region = _owner.WebView?.DraggableRegion;

                if (region != null)
                {
                    region.Dispose();
                    _owner.WebView.DraggableRegion = null;
                }

                //_owner.WebView.WebViewIsReady = false;
            }

            _owner.WebView.ProcessMessageBridge.OnBeforeBrowse(browser, frame);


            var e = new BeforeBrowseEventArgs(browser, frame, request, userGesture, isRedirect);


            _owner.InvokeIfRequired(() => _owner.OnBeforeBrowse(e));

            return e.Cancelled;
        }

        protected override bool GetAuthCredentials(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
        {
            //TODO: A custom dialog should be implemented to get username and password here.

            var e = new AuthCredentialsEventArgs(originUrl, isProxy, host, port, realm, scheme,callback);

            _owner.InvokeIfRequired(() => _owner.OnGetAuthCredentials(e));



            return !e.CancelRequestImmediately;
        }

        protected override bool OnCertificateError(CefBrowser browser, CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefRequestCallback callback)
        {

            var e = new CertificateErrorEventArgs(certError, requestUrl, sslInfo, callback);

            _owner.InvokeIfRequired(() => _owner.OnCertificateError(e));

            return !e.CancelRequestImmediately;
        }

        protected override void OnRenderProcessTerminated(CefBrowser browser, CefTerminationStatus status)
        {

            var e = new RenderProcessTerminatedEventArgs(browser, status);

            _owner.InvokeIfRequired(() => _owner.OnRenderProcessTerminated(e));

            _owner.WebView.ProcessMessageBridge.OnRenderProcessTerminated(browser);

            if (e.ShouldTryResetProcess && status != CefTerminationStatus.Termination)
            {
                browser.Reload();

                _owner.AttachChromeWidgetMessageHandler();
            }
        }

        //protected override bool OnSelectClientCertificate(CefBrowser browser, bool isProxy, string host, int port, CefX509Certificate[] certificates, CefSelectClientCertificateCallback callback)
        //{
        //    return base.OnSelectClientCertificate(browser, isProxy, host, port, certificates, callback);
        //}
    }


    public sealed class GetResourceRequestHandlerEventArgs : EventArgs
    {
        private readonly CefBrowser _browser;

        internal GetResourceRequestHandlerEventArgs(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator)
        {
            _browser = browser;
            Frame = frame;
            Request = request;
            IsNavigation = isNavigation;
            IsDownload = isDownload;
            RequestInitiator = requestInitiator;
        }

        public bool DisableDefaultHandling { get; set; } = false;
        public CefFrame Frame { get; }
        public CefRequest Request { get; }
        public bool IsNavigation { get; }
        public bool IsDownload { get; }
        public string RequestInitiator { get; }

        public CefResourceRequestHandler Handler { get; set; }
    }

    public sealed class BeforeBrowseEventArgs: EventArgs
    {
        internal BeforeBrowseEventArgs(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
        {
            _browser = browser;
            Frame = frame;
            Request = request;
            UserGesture = userGesture;
            IsRedirect = isRedirect;
        }

        private readonly CefBrowser _browser;
        public CefFrame Frame { get; }
        public CefRequest Request { get; }
        public bool UserGesture { get; }
        public bool IsRedirect { get; }

        public bool Cancelled { get; set; } = false;
    }

    public sealed class RenderProcessTerminatedEventArgs : EventArgs
    {
        private readonly CefBrowser _browser;

        internal RenderProcessTerminatedEventArgs(CefBrowser browser, CefTerminationStatus status)
        {
            _browser = browser;
            Status = status;
        }

        public bool ShouldTryResetProcess { get; set; }

        public CefTerminationStatus Status { get; }
    }

    public sealed class CertificateErrorEventArgs : EventArgs
    {
        private readonly CefRequestCallback _callback;

        internal CertificateErrorEventArgs(CefErrorCode certError, string requestUrl, CefSslInfo sslInfo, CefRequestCallback callback)
        {
            CertError = certError;
            RequestUrl = requestUrl;
            SslInfo = sslInfo;
            _callback = callback;
        }

        public CefErrorCode CertError { get; }
        public string RequestUrl { get; }
        public CefSslInfo SslInfo { get; }
        public void Continue(bool requestAllowed) => _callback?.Continue(requestAllowed);

        public void Cancel() => _callback?.Cancel();

        public bool CancelRequestImmediately { get; set; } = false;

    }

    public sealed class AuthCredentialsEventArgs : EventArgs
    {
        private readonly CefAuthCallback _callback;

        internal AuthCredentialsEventArgs(string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
        {
            OriginUrl = originUrl;
            IsProxy = isProxy;
            Host = host;
            Port = port;
            Realm = realm;
            Scheme = scheme;
            _callback = callback;
        }

        public string OriginUrl { get; }
        public bool IsProxy { get; }
        public string Host { get; }
        public int Port { get; }
        public string Realm { get; }
        public string Scheme { get; }
        public void Continue(string userName, string password) => _callback?.Continue(userName, password);
        public void Cancel() => _callback?.Cancel();

        public bool CancelRequestImmediately { get; set; } = false;
    }
}
