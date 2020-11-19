using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NetDimension.NanUI.Resources;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumLifeSpanHandler : CefLifeSpanHandler
    {
        private readonly Formium _owner;

        public WinFormiumLifeSpanHandler(Formium owner)
        {
            _owner = owner;

        }

        protected override void OnAfterCreated(CefBrowser browser)
        {
            base.OnAfterCreated(browser);

            _owner.WebView.OnBrowserCreated(browser);
        }

        protected override void OnBeforeClose(CefBrowser browser)
        {
            _owner.WebView.ProcessMessageBridge.OnBeforeClose(browser);

            _owner.InvokeIfRequired(() => _owner?.HostWindowInternal?.Close());
            
        }

        protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess)
        {

            var e = new BeforePopupEventArgs(frame, targetUrl, targetFrameName, userGesture, popupFeatures, windowInfo, client, settings, noJavascriptAccess);

            _owner.InvokeIfRequired(() => _owner.OnBeforePopup(e));


            if (e.Handled == false)
            {
                if (popupFeatures.X.HasValue)
                {
                    windowInfo.X = popupFeatures.X.Value;
                }


                if (popupFeatures.Y.HasValue)
                {
                    windowInfo.Y = popupFeatures.Y.Value;
                }

                if (popupFeatures.Width.HasValue)
                {
                    windowInfo.Width = popupFeatures.Width.Value;
                }
                else
                {
                    windowInfo.Width = _owner.Width;
                }

                if (popupFeatures.Height.HasValue)
                {
                    windowInfo.Height = popupFeatures.Height.Value;
                }
                else
                {
                    windowInfo.Height = _owner.Height;
                }



                windowInfo.SetAsPopup(IntPtr.Zero, $"{Messages.Browser_Loading} - {_owner.Title}");

                client = new PopupBrowserClient(_owner);
            }


            return e.Handled;
        }
    }

    internal class PopupBrowserClient : CefClient
    {
        class PopupBrowserLifeSpanHandler : CefLifeSpanHandler
        {
            const int ICO_BIG = 1;

            private Formium _formium;

            public PopupBrowserLifeSpanHandler(Formium formium)
            {
                _formium = formium;
            }

            protected override void OnAfterCreated(CefBrowser browser)
            {
                var hostHandle = browser.GetHost().GetWindowHandle();

                var hIcon = _formium.Icon.Handle;

                User32.SendMessage(hostHandle, (uint)WindowsMessages.WM_SETICON, (IntPtr)ICO_BIG, hIcon);

                base.OnAfterCreated(browser);
            }
        }

        class PopupBrowserDisplayHandler : CefDisplayHandler
        {
            private Formium _formium;

            public PopupBrowserDisplayHandler(Formium formium)
            {
                _formium = formium;
            }

            protected override void OnTitleChange(CefBrowser browser, string title)
            {
                var hWindow = browser.GetHost().GetWindowHandle();

                var caption = $"{title} - {_formium.Title}";

                var hText = Marshal.StringToCoTaskMemAuto(caption);

                User32.SendMessage(hWindow, (uint)WindowsMessages.WM_SETTEXT, IntPtr.Zero, hText);

                Marshal.FreeCoTaskMem(hText);
            }
        }

        private readonly Formium _formium;
        private readonly CefLifeSpanHandler _lifeSpanHandler;
        private readonly CefDisplayHandler _displayHandler;



        public PopupBrowserClient(Formium formium)
        {
            _formium = formium;
            _lifeSpanHandler = new PopupBrowserLifeSpanHandler(formium);
            _displayHandler = new PopupBrowserDisplayHandler(formium);
        }

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return _displayHandler;
        }
    }

    public sealed class FormiumCloseEventArgs : EventArgs
    {
        public bool Canceled { get; set; } = false;

    }

    public sealed class BeforePopupEventArgs : EventArgs
    {
        internal BeforePopupEventArgs(
            CefFrame frame,
            string targetUrl,
            string targetFrameName,
            bool userGesture,
            CefPopupFeatures popupFeatures,
            CefWindowInfo windowInfo,
            CefClient client,
            CefBrowserSettings settings,
            bool noJavascriptAccess)
        {
            Frame = frame;
            TargetUrl = targetUrl;
            TargetFrameName = targetFrameName;
            UserGesture = userGesture;
            PopupFeatures = popupFeatures;
            WindowInfo = windowInfo;
            Client = client;
            Settings = settings;
            NoJavascriptAccess = noJavascriptAccess;
        }

        public CefFrame Frame { get; }
        public string TargetUrl { get; }
        public string TargetFrameName { get; }
        public bool UserGesture { get; }
        public CefPopupFeatures PopupFeatures { get; }
        public CefWindowInfo WindowInfo { get; }
        public CefClient Client { get; set; }
        public CefBrowserSettings Settings { get; }
        public bool NoJavascriptAccess { get; set; }
        public bool Handled { get; set; } = false;

    }

}
