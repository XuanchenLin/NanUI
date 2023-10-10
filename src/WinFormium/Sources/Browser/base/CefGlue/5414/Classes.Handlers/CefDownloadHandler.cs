// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class used to handle file downloads. The methods of this class will called
/// on the browser process UI thread.
/// </summary>
public abstract unsafe partial class CefDownloadHandler
{
    private int can_download(cef_download_handler_t* self, cef_browser_t* browser, cef_string_t* url, cef_string_t* request_method)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNative(browser);
        var m_url = cef_string_t.ToString(url);
        var m_requestMethod = cef_string_t.ToString(request_method);
        return CanDownload(m_browser, m_url, m_requestMethod) ? 1 : 0;
    }

    /// <summary>
    /// Called before a download begins in response to a user-initiated action
    /// (e.g. alt + link click or link click that returns a `Content-Disposition:
    /// attachment` response from the server). |url| is the target download URL
    /// and |request_method| is the target method (GET, POST, etc). Return true to
    /// proceed with the download or false to cancel the download.
    /// </summary>
    protected virtual bool CanDownload(CefBrowser browser, string url, string requestMethod)
        => true;


    private void on_before_download(cef_download_handler_t* self, cef_browser_t* browser, cef_download_item_t* download_item, cef_string_t* suggested_name, cef_before_download_callback_t* callback)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNative(browser);
        var m_download_item = CefDownloadItem.FromNative(download_item);
        var m_suggested_name = cef_string_t.ToString(suggested_name);
        var m_callback = CefBeforeDownloadCallback.FromNative(callback);

        OnBeforeDownload(m_browser, m_download_item, m_suggested_name, m_callback);

        m_download_item.Dispose();
    }

    /// <summary>
    /// Called before a download begins. |suggested_name| is the suggested name
    /// for the download file. By default the download will be canceled. Execute
    /// |callback| either asynchronously or in this method to continue the
    /// download if desired. Do not keep a reference to |download_item| outside of
    /// this method.
    /// </summary>
    protected virtual void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
    {
    }


    private void on_download_updated(cef_download_handler_t* self, cef_browser_t* browser, cef_download_item_t* download_item, cef_download_item_callback_t* callback)
    {
        CheckSelf(self);

        var m_browser = CefBrowser.FromNative(browser);
        var m_download_item = CefDownloadItem.FromNative(download_item);
        var m_callback = CefDownloadItemCallback.FromNative(callback);

        OnDownloadUpdated(m_browser, m_download_item, m_callback);

        m_download_item.Dispose();
    }

    /// <summary>
    /// Called when a download's status or progress information has been updated.
    /// This may be called multiple times before and after OnBeforeDownload().
    /// Execute |callback| either asynchronously or in this method to cancel the
    /// download if desired. Do not keep a reference to |download_item| outside of
    /// this method.
    /// </summary>
    protected virtual void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
    {
    }
}
