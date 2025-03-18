// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;
public partial class Formium
{
    /// <summary>
    /// Return the handler for audio rendering events.
    /// </summary>
    public IAudioHandler? AudioHandler
    {
        get => WebViewHost.AudioHandler;
        set
        {
            WebViewHost.AudioHandler = value;
        }
    }

    /// <summary>
    /// Return the handler for dialogs.
    /// </summary>
    public IDialogHandler? DialogHandler
    {
        get => WebViewHost.DialogHandler;
        set => WebViewHost.DialogHandler = value;
    }


    /// <summary>
    /// Return the handler for browser display state events.
    /// </summary>
    public IDisplayHandler? DisplayHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for download events.
    /// </summary>
    public IDownloadHandler? DownloadHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for drag events.
    /// </summary>
    public IDragHandler? DragHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for find result events.
    /// </summary>
    public IFindHandler? FindHandler { get => WebViewHost.FindHandler; set => WebViewHost.FindHandler = value; }

    /// <summary>
    /// Return the handler for focus events.
    /// </summary>
    public IFocusHandler? FocusHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for events related to CefFrame lifespan. This method will be called once during CefBrowser creation and the result will be cached for performance reasons.
    /// </summary>
    public IFrameHandler? FrameHandler { get => WebViewHost.FrameHandler; set => WebViewHost.FrameHandler = value; }

    /// <summary>
    /// Return the handler for JavaScript dialogs.
    /// </summary>
    public IJSDialogHandler? JSDialogHandler { get => WebViewHost.JSDialogHandler; set => WebViewHost.JSDialogHandler = value; }

    /// <summary>
    /// Return the handler for keyboard events.
    /// </summary>
    public IKeyboardHandler? KeyboardHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for browser life span events.
    /// </summary>
    public ILifeSpanHandler? LifeSpanHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for browser load status events.
    /// </summary>
    public ILoadHandler? LoadHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for printing on Linux.
    /// </summary>
    public IPrintHandler? PrintHandler { get => WebViewHost.PrintHandler; set => WebViewHost.PrintHandler = value; }

    /// <summary>
    /// Return the handler for off-screen rendering events.
    /// </summary>
    public IRenderHandler? RenderHandler { get; set; }

    /// <summary>
    /// Return the handler for browser request events.
    /// </summary>
    public IRequestHandler? RequestHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for permission requests.
    /// </summary>
    public IPermissionHandler? PermissionHandler { get => WebViewHost.PermissionHandler; set => WebViewHost.PermissionHandler = value; }

    /// <summary>
    /// Return the handler for context menus. If no handler is provided the default implementation will be used.
    /// </summary>
    public IContextMenuHandler? ContextMenuHandler { get; set; } // <--- this is the one of internal handlers

    internal void OnBrowserClientCreatedCore()
    {
        WebViewHost.AudioHandler = AudioHandler;
        WebViewHost.DialogHandler = DialogHandler;
        WebViewHost.FindHandler = FindHandler;
        WebViewHost.FrameHandler = FrameHandler;
        WebViewHost.JSDialogHandler = JSDialogHandler;
        WebViewHost.PrintHandler = PrintHandler;
        WebViewHost.PermissionHandler = PermissionHandler;

        WebViewHost.ContextMenuHandler = ContextMenuHandler;
        WebViewHost.DownloadHandler = this;
        WebViewHost.LifeSpanHandler = this;
        WebViewHost.LoadHandler = this;
        WebViewHost.RequestHandler = this;
        WebViewHost.DragHandler = this;
        WebViewHost.KeyboardHandler = this;
        WebViewHost.FocusHandler = this;
        WebViewHost.DisplayHandler = this;
        WebViewHost.RenderHandler = this;

    }

}
