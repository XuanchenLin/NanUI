using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.Formium.Browser
{
    using NetDimension.Formium.Browser.Handlers;

    public interface IWebBrowserHandler
    {
        ChromiumContextMenuHandler ContextMenuHandler { get; }
        ChromiumDialogHandler DialogHandler { get; }
        ChromiumDisplayHandler DisplayHandler { get; }
        ChromiumDownloadHandler DownloadHandler { get; }
        ChromiumDragHandler DragHandler { get; }
        ChromiumFindHandler FindHandler { get; }
        ChromiumFocusHandler FocusHandler { get; }
        ChromiumJSDialogHandler JSDialogHandler { get; }
        ChromiumKeyboardHandler KeyboardHandler { get; }
        ChromiumLifeSpanHandler LifeSpanHandler { get; }
        ChromiumLoadHandler LoadHandler { get; }
        ChromiumRenderHandler RenderHandler { get; }
        ChromiumRequestHandler RequestHandler { get; }


    }
}
