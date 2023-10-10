// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
public abstract unsafe partial class CefClient
{
    private cef_audio_handler_t* get_audio_handler(cef_client_t* self)
    {
        CheckSelf(self);
        var result = GetAudioHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for audio rendering events.
    /// </summary>
    protected virtual CefAudioHandler? GetAudioHandler() => null;


    private cef_command_handler_t* get_command_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetCommandHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for commands. If no handler is provided the default
    /// implementation will be used.
    /// </summary>
    protected virtual CefCommandHandler? GetCommandHandler() => null;


    private cef_context_menu_handler_t* get_context_menu_handler(cef_client_t* self)
    {
        CheckSelf(self);
        var result = GetContextMenuHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for context menus. If no handler is provided the
    /// default implementation will be used.
    /// </summary>
    protected virtual CefContextMenuHandler? GetContextMenuHandler() => null;


    private cef_dialog_handler_t* get_dialog_handler(cef_client_t* self)
    {
        CheckSelf(self);
        var result = GetDialogHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for dialogs. If no handler is provided the default
    /// implementation will be used.
    /// </summary>
    protected virtual CefDialogHandler? GetDialogHandler() => null;


    private cef_display_handler_t* get_display_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetDisplayHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for browser display state events.
    /// </summary>
    protected virtual CefDisplayHandler? GetDisplayHandler() => null;


    private cef_download_handler_t* get_download_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetDownloadHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for download events. If no handler is returned
    /// downloads will not be allowed.
    /// </summary>
    protected virtual CefDownloadHandler? GetDownloadHandler() => null;


    private cef_drag_handler_t* get_drag_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetDragHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for drag events.
    /// </summary>
    protected virtual CefDragHandler? GetDragHandler() => null;


    private cef_find_handler_t* get_find_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetFindHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for find result events.
    /// </summary>
    protected virtual CefFindHandler? GetFindHandler() => null;


    private cef_focus_handler_t* get_focus_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetFocusHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for focus events.
    /// </summary>
    protected virtual CefFocusHandler? GetFocusHandler() => null;


    private cef_frame_handler_t* get_frame_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetFrameHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for events related to CefFrame lifespan. This method
    /// will be called once during CefBrowser creation and the result will be
    /// cached for performance reasons.
    /// </summary>
    protected virtual CefFrameHandler? GetFrameHandler() => null;


    private cef_permission_handler_t* get_permission_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetPermissionHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for permission requests.
    /// </summary>
    protected virtual CefPermissionHandler? GetPermissionHandler() => null;


    private cef_jsdialog_handler_t* get_jsdialog_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetJSDialogHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for JavaScript dialogs. If no handler is provided the
    /// default implementation will be used.
    /// </summary>
    protected virtual CefJSDialogHandler? GetJSDialogHandler() => null;


    private cef_keyboard_handler_t* get_keyboard_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetKeyboardHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for keyboard events.
    /// </summary>
    protected virtual CefKeyboardHandler? GetKeyboardHandler() => null;


    private cef_life_span_handler_t* get_life_span_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetLifeSpanHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for browser life span events.
    /// </summary>
    protected virtual CefLifeSpanHandler? GetLifeSpanHandler() => null;


    private cef_load_handler_t* get_load_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetLoadHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for browser load status events.
    /// </summary>
    protected virtual CefLoadHandler? GetLoadHandler() => null;


    private cef_print_handler_t* get_print_handler(cef_client_t* self)
    {
        CheckSelf(self);
        var result = GetPrintHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for printing on Linux. If a print handler is not
    /// provided then printing will not be supported on the Linux platform.
    /// </summary>
    protected virtual CefPrintHandler? GetPrintHandler() => null;


    private cef_render_handler_t* get_render_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetRenderHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for off-screen rendering events.
    /// </summary>
    protected virtual CefRenderHandler? GetRenderHandler() => null;


    private cef_request_handler_t* get_request_handler(cef_client_t* self)
    {
        CheckSelf(self);

        var result = GetRequestHandler();
        return result != null ? result.ToNative() : null;
    }

    /// <summary>
    /// Return the handler for browser request events.
    /// </summary>
    protected virtual CefRequestHandler? GetRequestHandler() => null;


    private int on_process_message_received(cef_client_t* self, cef_browser_t* browser, cef_frame_t* frame, CefProcessId source_process, cef_process_message_t* message)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNative(browser);
        var m_frame = CefFrame.FromNative(frame);
        var m_message = CefProcessMessage.FromNative(message);

        var result = OnProcessMessageReceived(m_browser, m_frame, source_process, m_message);

        m_message.Dispose();

        return result ? 1 : 0;
    }

    /// <summary>
    /// Called when a new message is received from a different process. Return
    /// true if the message was handled or false otherwise.  It is safe to keep a
    /// reference to |message| outside of this callback.
    /// </summary>
    protected virtual bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        return false;
    }
}
