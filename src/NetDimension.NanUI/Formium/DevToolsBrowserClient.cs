using Xilium.CefGlue;
using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI;
internal sealed class DevToolsBrowserClient : CefClient
{

    class DevToolsBrowserLifeSpanHandler : CefLifeSpanHandler
    {
        private DevToolsHostWindow hostWindow;

        public DevToolsBrowserLifeSpanHandler(DevToolsHostWindow hostWindow)
        {
            this.hostWindow = hostWindow;
        }

        //const int ICO_BIG = 1;
        //const int ICO_SMALL = 0;


        protected override void OnAfterCreated(CefBrowser browser)
        {
            base.OnAfterCreated(browser);

            hostWindow.BrowserWindowHandle = browser.GetHost().GetWindowHandle();

            hostWindow.Browser = browser;

            //var hostHandle = browser.GetHost().GetWindowHandle();

            //var iconHandle = Properties.Resources.DevToolsIcon.Handle;

            //SetClassLong(hostHandle, -14, iconHandle);

            //SendMessage(hostHandle, (uint)WindowMessage.WM_SETICON, (IntPtr)ICO_BIG, iconHandle);

            //SendMessage(hostHandle, (uint)WindowMessage.WM_SETICON, (IntPtr)ICO_SMALL, iconHandle);
        }
    }

    private readonly CefLifeSpanHandler _lifeSpanHandler;

    public DevToolsHostWindow HostWindow { get; }

    public DevToolsBrowserClient(DevToolsHostWindow hostWindow)
    {
        _lifeSpanHandler = new DevToolsBrowserLifeSpanHandler(hostWindow);
        HostWindow = hostWindow;
    }

    protected override CefLifeSpanHandler GetLifeSpanHandler()
    {
        return _lifeSpanHandler;
    }
}
