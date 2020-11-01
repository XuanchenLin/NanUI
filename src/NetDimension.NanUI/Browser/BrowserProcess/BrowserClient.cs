using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using NetDimension.NanUI.Browser.ProcessMessageBridge;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    public class BrowserClient : CefClient
    {
        private readonly Formium _owner;

        private readonly CefLifeSpanHandler _lifeSpanHandler;
        private readonly CefContextMenuHandler _contextMenuHandler;
        private readonly CefDialogHandler _dialogHandler;
        private readonly CefDisplayHandler _displayHandler;
        private readonly CefDownloadHandler _downloadHandler;
        private readonly CefDragHandler _dragHandler;
        private readonly CefFindHandler _findHandler;
        //private readonly CefFocusHandler _focusHandler;
        private readonly CefJSDialogHandler _jsDialogHandler;
        private readonly CefKeyboardHandler _keyboardHandler;
        private readonly CefLoadHandler _loadHandler;
        private readonly CefRequestHandler _requestHandler;

        private readonly CefRenderHandler _renderHandler;



        //public WinFormiumLifeSpanHandler LifeSpanHandler => (WinFormiumLifeSpanHandler)_lifeSpanHandler;

        //public WinFormiumLoadHandler LoadHandler => (WinFormiumLoadHandler)_loadHandler;


        internal BrowserClient(Formium formium)
        {
            _owner = formium;

            _lifeSpanHandler = new WinFormiumLifeSpanHandler(_owner);
            _loadHandler = new WinFormiumLoadHandler(_owner);
            _dragHandler = new WinFormiumDragHandler(_owner);
            _contextMenuHandler = new WinFormiumContextMenuHandler(_owner);
            _requestHandler = new WinFormiumRequestHandler(_owner);
            _displayHandler = new WinFormiumDisplayHandler(_owner);
            _dialogHandler = new WinFormiumDialogHandler(_owner);
            _downloadHandler = new WinFormiumDownloadHandler(_owner);
            //_focusHandler = new WinFormiumFocusHandler(_owner);
            _keyboardHandler = new WinFormiumKeyboardHandler(_owner);
            _jsDialogHandler = new WinFormiumJSDialogHandler(_owner);
            _findHandler = new WinFormiumFindHandler(_owner);

            if(formium.WindowType == HostWindow.HostWindowType.Acrylic)
            {
                _renderHandler = new WinFormiumRenderHandlerUsingHwnd(_owner);
            }
            

            if(formium.WindowType == HostWindow.HostWindowType.Layered)
            {
                _renderHandler = new WinFormiumRenderHandlerUsingDeviceContext(_owner);
            }

        }

        protected override CefDialogHandler GetDialogHandler() => _dialogHandler;
        protected override CefLifeSpanHandler GetLifeSpanHandler() => _lifeSpanHandler;
        //protected override CefFocusHandler GetFocusHandler() => _focusHandler;
        protected override CefLoadHandler GetLoadHandler() => _loadHandler;
        protected override CefDragHandler GetDragHandler() => _dragHandler;
        protected override CefContextMenuHandler GetContextMenuHandler() => _contextMenuHandler;
        protected override CefRequestHandler GetRequestHandler() => _requestHandler;
        protected override CefDisplayHandler GetDisplayHandler() => _displayHandler;
        protected override CefDownloadHandler GetDownloadHandler() => _downloadHandler;
        protected override CefKeyboardHandler GetKeyboardHandler() => _keyboardHandler;
        protected override CefJSDialogHandler GetJSDialogHandler() => _jsDialogHandler;
        protected override CefFindHandler GetFindHandler() => _findHandler;
        protected override CefRenderHandler GetRenderHandler() => _renderHandler;

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {

            if (_owner.WebView.ProcessMessageBridge.OnRenderProcessMessage(browser,frame,sourceProcess, message))
            {
                return true;
            }


            return false;
        }


    }
}
