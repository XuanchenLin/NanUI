// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to provide handler implementations. The handler
/// instance will not be released until all objects related to the context have
/// been destroyed.
/// </summary>
public abstract unsafe partial class CefRequestContextHandler
{
    private void on_request_context_initialized(cef_request_context_handler_t* self, cef_request_context_t* request_context)
    {
        CheckSelf(self);

        var mRequestContext = CefRequestContext.FromNative(request_context);
        OnRequestContextInitialized(mRequestContext);
    }

    /// <summary>
    /// Called on the browser process UI thread immediately after the request
    /// context has been initialized.
    /// </summary>
    protected virtual void OnRequestContextInitialized(CefRequestContext requestContext) { }


    private cef_resource_request_handler_t* get_resource_request_handler(cef_request_context_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_request_t* request, int is_navigation, int is_download, cef_string_t* request_initiator, int* disable_default_handling)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNativeOrNull(browser);
        var m_frame = CefFrame.FromNativeOrNull(frame);
        var m_request = CefRequest.FromNative(request);
        var m_isNavigation = is_navigation != 0;
        var m_isDownload = is_download != 0;
        var m_requestInitiator = cef_string_t.ToString(request_initiator);
        var m_disableDefaultHandling = *disable_default_handling != 0;

        var m_result = GetResourceRequestHandler(m_browser, m_frame, m_request, m_isNavigation, m_isDownload, m_requestInitiator, ref m_disableDefaultHandling);

        *disable_default_handling = m_disableDefaultHandling ? 1 : 0;

        return m_result != null ? m_result.ToNative() : null;
    }

    /// <summary>
    /// Called on the browser process IO thread before a resource request is
    /// initiated. The |browser| and |frame| values represent the source of the
    /// request, and may be NULL for requests originating from service workers or
    /// CefURLRequest. |request| represents the request contents and cannot be
    /// modified in this callback. |is_navigation| will be true if the resource
    /// request is a navigation. |is_download| will be true if the resource
    /// request is a download. |request_initiator| is the origin (scheme + domain)
    /// of the page that initiated the request. Set |disable_default_handling| to
    /// true to disable default handling of the request, in which case it will
    /// need to be handled via CefResourceRequestHandler::GetResourceHandler or it
    /// will be canceled. To allow the resource load to proceed with default
    /// handling return NULL. To specify a handler for the resource return a
    /// CefResourceRequestHandler object. This method will not be called if the
    /// client associated with |browser| returns a non-NULL value from
    /// CefRequestHandler::GetResourceRequestHandler for the same request
    /// (identified by CefRequest::GetIdentifier).
    /// </summary>
    protected abstract CefResourceRequestHandler GetResourceRequestHandler(CefBrowser browser, CefFrame frame, CefRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling);
}
