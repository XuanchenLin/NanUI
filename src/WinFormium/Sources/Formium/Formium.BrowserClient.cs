// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public partial class Formium
{
    /// <summary>
    /// Return the handler for audio rendering events.
    /// </summary>
    public AudioHandler? AudioHandler { get; set; }

    /// <summary>
    /// Return the handler for dialogs.
    /// </summary>
    public DialogHandler? DialogHandler { get; set; }

    /// <summary>
    /// Return the handler for browser display state events.
    /// </summary>
    public DisplayHandler? DisplayHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for download events.
    /// </summary>
    public DownloadHandler? DownloadHandler { get; set; }

    /// <summary>
    /// Return the handler for drag events.
    /// </summary>
    public DragHandler? DragHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for find result events.
    /// </summary>
    public FindHandler? FindHandler { get; set; }

    /// <summary>
    /// Return the handler for focus events.
    /// </summary>
    public FocusHandler? FocusHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for events related to CefFrame lifespan. This method will be called once during CefBrowser creation and the result will be cached for performance reasons.
    /// </summary>
    public FrameHandler? FrameHandler { get; set; }

    /// <summary>
    /// Return the handler for JavaScript dialogs.
    /// </summary>
    public JSDialogHandler? JSDialogHandler { get; set; }

    /// <summary>
    /// Return the handler for keyboard events.
    /// </summary>
    public KeyboardHandler? KeyboardHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for browser life span events.
    /// </summary>
    public LifeSpanHandler? LifeSpanHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for browser load status events.
    /// </summary>
    public LoadHandler? LoadHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for printing on Linux.
    /// </summary>
    public PrintHandler? PrintHandler { get; set; }

    /// <summary>
    /// Return the handler for off-screen rendering events.
    /// </summary>
    public RenderHandler? RenderHandler { get; set; }

    /// <summary>
    /// Return the handler for browser request events.
    /// </summary>
    public RequestHandler? RequestHandler { get; set; } // <--- this is the one of internal handlers

    /// <summary>
    /// Return the handler for permission requests.
    /// </summary>
    public PermissionHandler? PermissionHandler { get; set; }

    /// <summary>
    /// Return the handler for context menus. If no handler is provided the default implementation will be used.
    /// </summary>
    public ContextMenuHandler? ContextMenuHandler { get; set; } // <--- this is the one of internal handlers

    internal void OnBrowserClientCreatedCore()
    {
        WebViewHost.AudioHandler = AudioHandler;
        WebViewHost.ContextMenuHandler = ContextMenuHandler;
        WebViewHost.DialogHandler = DialogHandler;
        WebViewHost.DownloadHandler = this;
        WebViewHost.FindHandler = FindHandler;
        WebViewHost.FrameHandler = FrameHandler;
        WebViewHost.JSDialogHandler = JSDialogHandler;
        WebViewHost.PrintHandler = PrintHandler;
        WebViewHost.PermissionHandler = PermissionHandler;

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
