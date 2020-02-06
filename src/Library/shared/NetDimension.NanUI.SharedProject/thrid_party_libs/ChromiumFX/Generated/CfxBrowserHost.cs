// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent the browser process aspects of a browser window.
    /// The functions of this structure can only be called in the browser process.
    /// They may be called on any thread in that process unless otherwise indicated
    /// in the comments.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxBrowserHost : CfxBaseLibrary {

        internal static CfxBrowserHost Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxBrowserHost)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxBrowserHost(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxBrowserHost(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new browser window using the window parameters specified by
        /// |windowInfo|. All values will be copied internally and the actual window will
        /// be created on the UI thread. If |requestContext| is NULL the global request
        /// context will be used. This function can be called on any browser process
        /// thread and will not block. The optional |extraInfo| parameter provides an
        /// opportunity to specify extra information specific to the created browser that
        /// will be passed to CfxRenderProcessHandler.OnBrowserCreated() in the
        /// render process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public static bool CreateBrowser(CfxWindowInfo windowInfo, CfxClient client, string url, CfxBrowserSettings settings, CfxDictionaryValue extraInfo, CfxRequestContext requestContext) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.BrowserHost.cfx_browser_host_create_browser(CfxWindowInfo.Unwrap(windowInfo), CfxClient.Unwrap(client), url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxBrowserSettings.Unwrap(settings), CfxDictionaryValue.Unwrap(extraInfo), CfxRequestContext.Unwrap(requestContext));
            url_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Create a new browser window using the window parameters specified by
        /// |windowInfo|. If |requestContext| is NULL the global request context will be
        /// used. This function can only be called on the browser process UI thread. The
        /// optional |extraInfo| parameter provides an opportunity to specify extra
        /// information specific to the created browser that will be passed to
        /// CfxRenderProcessHandler.OnBrowserCreated() in the render process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public static CfxBrowser CreateBrowserSync(CfxWindowInfo windowInfo, CfxClient client, string url, CfxBrowserSettings settings, CfxDictionaryValue extraInfo, CfxRequestContext requestContext) {
            var url_pinned = new PinnedString(url);
            var __retval = CfxApi.BrowserHost.cfx_browser_host_create_browser_sync(CfxWindowInfo.Unwrap(windowInfo), CfxClient.Unwrap(client), url_pinned.Obj.PinnedPtr, url_pinned.Length, CfxBrowserSettings.Unwrap(settings), CfxDictionaryValue.Unwrap(extraInfo), CfxRequestContext.Unwrap(requestContext));
            url_pinned.Obj.Free();
            return CfxBrowser.Wrap(__retval);
        }

        /// <summary>
        /// Returns the hosted browser object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxBrowser Browser {
            get {
                return CfxBrowser.Wrap(CfxApi.BrowserHost.cfx_browser_host_get_browser(NativePtr));
            }
        }

        /// <summary>
        /// Retrieve the window handle for this browser. If this browser is wrapped in
        /// a CfxBrowserView this function should be called on the browser process
        /// UI thread and it will return the handle for the top-level native window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public IntPtr WindowHandle {
            get {
                return CfxApi.BrowserHost.cfx_browser_host_get_window_handle(NativePtr);
            }
        }

        /// <summary>
        /// Retrieve the window handle of the browser that opened this browser. Will
        /// return NULL for non-popup windows or if this browser is wrapped in a
        /// CfxBrowserView. This function can be used in combination with custom
        /// handling of modal windows.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public IntPtr OpenerWindowHandle {
            get {
                return CfxApi.BrowserHost.cfx_browser_host_get_opener_window_handle(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this browser is wrapped in a CfxBrowserView.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool HasView {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_has_view(NativePtr);
            }
        }

        /// <summary>
        /// Returns the client for this browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxClient Client {
            get {
                return CfxClient.Wrap(CfxApi.BrowserHost.cfx_browser_host_get_client(NativePtr));
            }
        }

        /// <summary>
        /// Returns the request context for this browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxRequestContext RequestContext {
            get {
                return CfxRequestContext.Wrap(CfxApi.BrowserHost.cfx_browser_host_get_request_context(NativePtr));
            }
        }

        /// <summary>
        /// Get the current zoom level. The default zoom level is 0.0. This function
        /// can only be called on the UI thread.
        /// 
        /// Change the zoom level to the specified value. Specify 0.0 to reset the zoom
        /// level. If called on the UI thread the change will be applied immediately.
        /// Otherwise, the change will be applied asynchronously on the UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public double ZoomLevel {
            get {
                return CfxApi.BrowserHost.cfx_browser_host_get_zoom_level(NativePtr);
            }
            set {
                CfxApi.BrowserHost.cfx_browser_host_set_zoom_level(NativePtr, value);
            }
        }

        /// <summary>
        /// Returns true (1) if this browser currently has an associated DevTools
        /// browser. Must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool HasDevTools {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_has_dev_tools(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if mouse cursor change is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsMouseCursorChangeDisabled {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_is_mouse_cursor_change_disabled(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsWindowRenderingDisabled {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_is_window_rendering_disabled(NativePtr);
            }
        }

        /// <summary>
        /// Returns the maximum rate in frames per second (fps) that
        /// CfxRenderHandler:: OnPaint will be called for a windowless browser. The
        /// actual fps may be lower if the browser cannot generate frames at the
        /// requested rate. The minimum value is 1 and the maximum value is 60 (default
        /// 30). This function can only be called on the UI thread.
        /// 
        /// Set the maximum rate in frames per second (fps) that CfxRenderHandler::
        /// OnPaint will be called for a windowless browser. The actual fps may be
        /// lower if the browser cannot generate frames at the requested rate. The
        /// minimum value is 1 and the maximum value is 60 (default 30). Can also be
        /// set at browser creation via CfxBrowserSettings.WindowlessFrameRate.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public int WindowlessFrameRate {
            get {
                return CfxApi.BrowserHost.cfx_browser_host_get_windowless_frame_rate(NativePtr);
            }
            set {
                CfxApi.BrowserHost.cfx_browser_host_set_windowless_frame_rate(NativePtr, value);
            }
        }

        /// <summary>
        /// Returns the current visible navigation entry for this browser. This
        /// function can only be called on the UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxNavigationEntry VisibleNavigationEntry {
            get {
                return CfxNavigationEntry.Wrap(CfxApi.BrowserHost.cfx_browser_host_get_visible_navigation_entry(NativePtr));
            }
        }

        /// <summary>
        /// Returns the extension hosted in this browser or NULL if no extension is
        /// hosted. See CfxRequestContext.LoadExtension for details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxExtension Extension {
            get {
                return CfxExtension.Wrap(CfxApi.BrowserHost.cfx_browser_host_get_extension(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this browser is hosting an extension background script.
        /// Background hosts do not have a window and are not displayable. See
        /// CfxRequestContext.LoadExtension for details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsBackgroundHost {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_is_background_host(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the browser's audio is muted.  This function can only
        /// be called on the UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsAudioMuted {
            get {
                return 0 != CfxApi.BrowserHost.cfx_browser_host_is_audio_muted(NativePtr);
            }
        }

        /// <summary>
        /// Request that the browser close. The JavaScript 'onbeforeunload' event will
        /// be fired. If |forceClose| is false (0) the event handler, if any, will be
        /// allowed to prompt the user and the user can optionally cancel the close. If
        /// |forceClose| is true (1) the prompt will not be displayed and the close
        /// will proceed. Results in a call to CfxLifeSpanHandler.DoClose() if
        /// the event handler allows the close or if |forceClose| is true (1). See
        /// CfxLifeSpanHandler.DoClose() documentation for additional usage
        /// information.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void CloseBrowser(bool forceClose) {
            CfxApi.BrowserHost.cfx_browser_host_close_browser(NativePtr, forceClose ? 1 : 0);
        }

        /// <summary>
        /// Helper for closing a browser. Call this function from the top-level window
        /// close handler. Internally this calls CloseBrowser(false (0)) if the close
        /// has not yet been initiated. This function returns false (0) while the close
        /// is pending and true (1) after the close has completed. See close_browser()
        /// and CfxLifeSpanHandler.DoClose() documentation for additional usage
        /// information. This function must be called on the browser process UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool TryCloseBrowser() {
            return 0 != CfxApi.BrowserHost.cfx_browser_host_try_close_browser(NativePtr);
        }

        /// <summary>
        /// Set whether the browser is focused.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SetFocus(bool focus) {
            CfxApi.BrowserHost.cfx_browser_host_set_focus(NativePtr, focus ? 1 : 0);
        }

        /// <summary>
        /// Call to run a file chooser dialog. Only a single file chooser dialog may be
        /// pending at any given time. |mode| represents the type of dialog to display.
        /// |title| to the title to be used for the dialog and may be NULL to show the
        /// default title ("Open" or "Save" depending on the mode). |defaultFilePath|
        /// is the path with optional directory and/or file name component that will be
        /// initially selected in the dialog. |acceptFilters| are used to restrict the
        /// selectable file types and may any combination of (a) valid lower-cased MIME
        /// types (e.g. "text/*" or "image/*"), (b) individual file extensions (e.g.
        /// ".txt" or ".png"), or (c) combined description and file extension delimited
        /// using "|" and ";" (e.g. "Image Types|.png;.gif;.jpg").
        /// |selectedAcceptFilter| is the 0-based index of the filter that will be
        /// selected by default. |callback| will be executed after the dialog is
        /// dismissed or immediately if another dialog is already pending. The dialog
        /// will be initiated asynchronously on the UI thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void RunFileDialog(CfxFileDialogMode mode, string title, string defaultFilePath, System.Collections.Generic.List<string> acceptFilters, int selectedAcceptFilter, CfxRunFileDialogCallback callback) {
            var title_pinned = new PinnedString(title);
            var defaultFilePath_pinned = new PinnedString(defaultFilePath);
            PinnedString[] acceptFilters_handles;
            var acceptFilters_unwrapped = StringFunctions.UnwrapCfxStringList(acceptFilters, out acceptFilters_handles);
            CfxApi.BrowserHost.cfx_browser_host_run_file_dialog(NativePtr, (int)mode, title_pinned.Obj.PinnedPtr, title_pinned.Length, defaultFilePath_pinned.Obj.PinnedPtr, defaultFilePath_pinned.Length, acceptFilters_unwrapped, selectedAcceptFilter, CfxRunFileDialogCallback.Unwrap(callback));
            title_pinned.Obj.Free();
            defaultFilePath_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(acceptFilters_handles);
            StringFunctions.CfxStringListCopyToManaged(acceptFilters_unwrapped, acceptFilters);
            CfxApi.Runtime.cfx_string_list_free(acceptFilters_unwrapped);
        }

        /// <summary>
        /// Download the file at |url| using CfxDownloadHandler.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void StartDownload(string url) {
            var url_pinned = new PinnedString(url);
            CfxApi.BrowserHost.cfx_browser_host_start_download(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length);
            url_pinned.Obj.Free();
        }

        /// <summary>
        /// Download |imageUrl| and execute |callback| on completion with the images
        /// received from the renderer. If |isFavicon| is true (1) then cookies are
        /// not sent and not accepted during download. Images with density independent
        /// pixel (DIP) sizes larger than |maxImageSize| are filtered out from the
        /// image results. Versions of the image at different scale factors may be
        /// downloaded up to the maximum scale factor supported by the system. If there
        /// are no image results &lt;= |maxImageSize| then the smallest image is resized
        /// to |maxImageSize| and is the only result. A |maxImageSize| of 0 means
        /// unlimited. If |bypassCache| is true (1) then |imageUrl| is requested from
        /// the server even if it is present in the browser cache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DownloadImage(string imageUrl, bool isFavicon, uint maxImageSize, bool bypassCache, CfxDownloadImageCallback callback) {
            var imageUrl_pinned = new PinnedString(imageUrl);
            CfxApi.BrowserHost.cfx_browser_host_download_image(NativePtr, imageUrl_pinned.Obj.PinnedPtr, imageUrl_pinned.Length, isFavicon ? 1 : 0, maxImageSize, bypassCache ? 1 : 0, CfxDownloadImageCallback.Unwrap(callback));
            imageUrl_pinned.Obj.Free();
        }

        /// <summary>
        /// Print the current browser contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void Print() {
            CfxApi.BrowserHost.cfx_browser_host_print(NativePtr);
        }

        /// <summary>
        /// Print the current browser contents to the PDF file specified by |path| and
        /// execute |callback| on completion. The caller is responsible for deleting
        /// |path| when done. For PDF printing to work on Linux you must implement the
        /// CfxPrintHandler.GetPdfPaperSize function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void PrintToPdf(string path, CfxPdfPrintSettings settings, CfxPdfPrintCallback callback) {
            var path_pinned = new PinnedString(path);
            CfxApi.BrowserHost.cfx_browser_host_print_to_pdf(NativePtr, path_pinned.Obj.PinnedPtr, path_pinned.Length, CfxPdfPrintSettings.Unwrap(settings), CfxPdfPrintCallback.Unwrap(callback));
            path_pinned.Obj.Free();
        }

        /// <summary>
        /// Search for |searchText|. |identifier| must be a unique ID and these IDs
        /// must strictly increase so that newer requests always have greater IDs than
        /// older requests. If |identifier| is zero or less than the previous ID value
        /// then it will be automatically assigned a new valid ID. |forward| indicates
        /// whether to search forward or backward within the page. |matchCase|
        /// indicates whether the search should be case-sensitive. |findNext| indicates
        /// whether this is the first request or a follow-up. The CfxFindHandler
        /// instance, if any, returned via CfxClient.GetFindHandler will be called
        /// to report find results.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void Find(int identifier, string searchText, bool forward, bool matchCase, bool findNext) {
            var searchText_pinned = new PinnedString(searchText);
            CfxApi.BrowserHost.cfx_browser_host_find(NativePtr, identifier, searchText_pinned.Obj.PinnedPtr, searchText_pinned.Length, forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);
            searchText_pinned.Obj.Free();
        }

        /// <summary>
        /// Cancel all searches that are currently going on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void StopFinding(bool clearSelection) {
            CfxApi.BrowserHost.cfx_browser_host_stop_finding(NativePtr, clearSelection ? 1 : 0);
        }

        /// <summary>
        /// Open developer tools (DevTools) in its own browser. The DevTools browser
        /// will remain associated with this browser. If the DevTools browser is
        /// already open then it will be focused, in which case the |windowInfo|,
        /// |client| and |settings| parameters will be ignored. If |inspectElementAt|
        /// is non-NULL then the element at the specified (x,y) location will be
        /// inspected. The |windowInfo| parameter will be ignored if this browser is
        /// wrapped in a CfxBrowserView.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ShowDevTools(CfxWindowInfo windowInfo, CfxClient client, CfxBrowserSettings settings, CfxPoint inspectElementAt) {
            CfxApi.BrowserHost.cfx_browser_host_show_dev_tools(NativePtr, CfxWindowInfo.Unwrap(windowInfo), CfxClient.Unwrap(client), CfxBrowserSettings.Unwrap(settings), CfxPoint.Unwrap(inspectElementAt));
        }

        /// <summary>
        /// Explicitly close the associated DevTools browser, if any.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void CloseDevTools() {
            CfxApi.BrowserHost.cfx_browser_host_close_dev_tools(NativePtr);
        }

        /// <summary>
        /// Retrieve a snapshot of current navigation entries as values sent to the
        /// specified visitor. If |currentOnly| is true (1) only the current
        /// navigation entry will be sent, otherwise all navigation entries will be
        /// sent.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void GetNavigationEntries(CfxNavigationEntryVisitor visitor, bool currentOnly) {
            CfxApi.BrowserHost.cfx_browser_host_get_navigation_entries(NativePtr, CfxNavigationEntryVisitor.Unwrap(visitor), currentOnly ? 1 : 0);
        }

        /// <summary>
        /// Set whether mouse cursor change is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SetMouseCursorChangeDisabled(bool disabled) {
            CfxApi.BrowserHost.cfx_browser_host_set_mouse_cursor_change_disabled(NativePtr, disabled ? 1 : 0);
        }

        /// <summary>
        /// If a misspelled word is currently selected in an editable node calling this
        /// function will replace it with the specified |word|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ReplaceMisspelling(string word) {
            var word_pinned = new PinnedString(word);
            CfxApi.BrowserHost.cfx_browser_host_replace_misspelling(NativePtr, word_pinned.Obj.PinnedPtr, word_pinned.Length);
            word_pinned.Obj.Free();
        }

        /// <summary>
        /// Add the specified |word| to the spelling dictionary.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void AddWordToDictionary(string word) {
            var word_pinned = new PinnedString(word);
            CfxApi.BrowserHost.cfx_browser_host_add_word_to_dictionary(NativePtr, word_pinned.Obj.PinnedPtr, word_pinned.Length);
            word_pinned.Obj.Free();
        }

        /// <summary>
        /// Notify the browser that the widget has been resized. The browser will first
        /// call CfxRenderHandler.GetViewRect to get the new size and then call
        /// CfxRenderHandler.OnPaint asynchronously with the updated regions. This
        /// function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void WasResized() {
            CfxApi.BrowserHost.cfx_browser_host_was_resized(NativePtr);
        }

        /// <summary>
        /// Notify the browser that it has been hidden or shown. Layouting and
        /// CfxRenderHandler.OnPaint notification will stop when the browser is
        /// hidden. This function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void WasHidden(bool hidden) {
            CfxApi.BrowserHost.cfx_browser_host_was_hidden(NativePtr, hidden ? 1 : 0);
        }

        /// <summary>
        /// Send a notification to the browser that the screen info has changed. The
        /// browser will then call CfxRenderHandler.GetScreenInfo to update the
        /// screen information with the new values. This simulates moving the webview
        /// window from one display to another, or changing the properties of the
        /// current display. This function is only used when window rendering is
        /// disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void NotifyScreenInfoChanged() {
            CfxApi.BrowserHost.cfx_browser_host_notify_screen_info_changed(NativePtr);
        }

        /// <summary>
        /// Invalidate the view. The browser will call CfxRenderHandler.OnPaint
        /// asynchronously. This function is only used when window rendering is
        /// disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void Invalidate(CfxPaintElementType type) {
            CfxApi.BrowserHost.cfx_browser_host_invalidate(NativePtr, (int)type);
        }

        /// <summary>
        /// Issue a BeginFrame request to Chromium.  Only valid when
        /// CfxWindowInfo.ExternalBeginFrameEnabled is set to true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendExternalBeginFrame() {
            CfxApi.BrowserHost.cfx_browser_host_send_external_begin_frame(NativePtr);
        }

        /// <summary>
        /// Send a key event to the browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendKeyEvent(CfxKeyEvent @event) {
            CfxApi.BrowserHost.cfx_browser_host_send_key_event(NativePtr, CfxKeyEvent.Unwrap(@event));
        }

        /// <summary>
        /// Send a mouse click event to the browser. The |x| and |y| coordinates are
        /// relative to the upper-left corner of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendMouseClickEvent(CfxMouseEvent @event, CfxMouseButtonType type, bool mouseUp, int clickCount) {
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_click_event(NativePtr, CfxMouseEvent.Unwrap(@event), (int)type, mouseUp ? 1 : 0, clickCount);
        }

        /// <summary>
        /// Send a mouse move event to the browser. The |x| and |y| coordinates are
        /// relative to the upper-left corner of the view.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendMouseMoveEvent(CfxMouseEvent @event, bool mouseLeave) {
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_move_event(NativePtr, CfxMouseEvent.Unwrap(@event), mouseLeave ? 1 : 0);
        }

        /// <summary>
        /// Send a mouse wheel event to the browser. The |x| and |y| coordinates are
        /// relative to the upper-left corner of the view. The |deltaX| and |deltaY|
        /// values represent the movement delta in the X and Y directions respectively.
        /// In order to scroll inside select popups with window rendering disabled
        /// CfxRenderHandler.GetScreenPoint should be implemented properly.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendMouseWheelEvent(CfxMouseEvent @event, int deltaX, int deltaY) {
            CfxApi.BrowserHost.cfx_browser_host_send_mouse_wheel_event(NativePtr, CfxMouseEvent.Unwrap(@event), deltaX, deltaY);
        }

        /// <summary>
        /// Send a touch event to the browser for a windowless browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendTouchEvent(CfxTouchEvent @event) {
            CfxApi.BrowserHost.cfx_browser_host_send_touch_event(NativePtr, CfxTouchEvent.Unwrap(@event));
        }

        /// <summary>
        /// Send a focus event to the browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendFocusEvent(bool setFocus) {
            CfxApi.BrowserHost.cfx_browser_host_send_focus_event(NativePtr, setFocus ? 1 : 0);
        }

        /// <summary>
        /// Send a capture lost event to the browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SendCaptureLostEvent() {
            CfxApi.BrowserHost.cfx_browser_host_send_capture_lost_event(NativePtr);
        }

        /// <summary>
        /// Notify the browser that the window hosting it is about to be moved or
        /// resized. This function is only used on Windows and Linux.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void NotifyMoveOrResizeStarted() {
            CfxApi.BrowserHost.cfx_browser_host_notify_move_or_resize_started(NativePtr);
        }

        /// <summary>
        /// Begins a new composition or updates the existing composition. Blink has a
        /// special node (a composition node) that allows the input function to change
        /// text without affecting other DOM nodes. |text| is the optional text that
        /// will be inserted into the composition node. |underlines| is an optional set
        /// of ranges that will be underlined in the resulting text.
        /// |replacementRange| is an optional range of the existing text that will be
        /// replaced. |selectionRange| is an optional range of the resulting text that
        /// will be selected after insertion or replacement. The |replacementRange|
        /// value is only used on OS X.
        /// 
        /// This function may be called multiple times as the composition changes. When
        /// the client is done making changes the composition should either be canceled
        /// or completed. To cancel the composition call ImeCancelComposition. To
        /// complete the composition call either ImeCommitText or
        /// ImeFinishComposingText. Completion is usually signaled when:
        ///   A. The client receives a WM_IME_COMPOSITION message with a GCS_RESULTSTR
        ///      flag (on Windows), or;
        ///   B. The client receives a "commit" signal of GtkIMContext (on Linux), or;
        ///   C. insertText of NSTextInput is called (on Mac).
        /// 
        /// This function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ImeSetComposition(string text, CfxCompositionUnderline[] underlines, CfxRange replacementRange, CfxRange selectionRange) {
            var text_pinned = new PinnedString(text);
            UIntPtr underlines_length;
            IntPtr[] underlines_ptrs;
            if(underlines != null) {
                underlines_length = (UIntPtr)underlines.Length;
                underlines_ptrs = new IntPtr[underlines.Length];
                for(int i = 0; i < underlines.Length; ++i) {
                    underlines_ptrs[i] = CfxCompositionUnderline.Unwrap(underlines[i]);
                }
            } else {
                underlines_length = UIntPtr.Zero;
                underlines_ptrs = null;
            }
            PinnedObject underlines_pinned = new PinnedObject(underlines_ptrs);
            int underlines_nomem;
            CfxApi.BrowserHost.cfx_browser_host_ime_set_composition(NativePtr, text_pinned.Obj.PinnedPtr, text_pinned.Length, underlines_length, underlines_pinned.PinnedPtr, out underlines_nomem, CfxRange.Unwrap(replacementRange), CfxRange.Unwrap(selectionRange));
            text_pinned.Obj.Free();
            underlines_pinned.Free();
            if(underlines_nomem != 0) {
                throw new OutOfMemoryException();
            }
        }

        /// <summary>
        /// Completes the existing composition by optionally inserting the specified
        /// |text| into the composition node. |replacementRange| is an optional range
        /// of the existing text that will be replaced. |relativeCursorPos| is where
        /// the cursor will be positioned relative to the current cursor position. See
        /// comments on ImeSetComposition for usage. The |replacementRange| and
        /// |relativeCursorPos| values are only used on OS X. This function is only
        /// used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ImeCommitText(string text, CfxRange replacementRange, int relativeCursorPos) {
            var text_pinned = new PinnedString(text);
            CfxApi.BrowserHost.cfx_browser_host_ime_commit_text(NativePtr, text_pinned.Obj.PinnedPtr, text_pinned.Length, CfxRange.Unwrap(replacementRange), relativeCursorPos);
            text_pinned.Obj.Free();
        }

        /// <summary>
        /// Completes the existing composition by applying the current composition node
        /// contents. If |keepSelection| is false (0) the current selection, if any,
        /// will be discarded. See comments on ImeSetComposition for usage. This
        /// function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ImeFinishComposingText(bool keepSelection) {
            CfxApi.BrowserHost.cfx_browser_host_ime_finish_composing_text(NativePtr, keepSelection ? 1 : 0);
        }

        /// <summary>
        /// Cancels the existing composition and discards the composition node contents
        /// without applying them. See comments on ImeSetComposition for usage. This
        /// function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ImeCancelComposition() {
            CfxApi.BrowserHost.cfx_browser_host_ime_cancel_composition(NativePtr);
        }

        /// <summary>
        /// Call this function when the user drags the mouse into the web view (before
        /// calling DragTargetDragOver/DragTargetLeave/DragTargetDrop). |dragData|
        /// should not contain file contents as this type of data is not allowed to be
        /// dragged into the web view. File contents can be removed using
        /// CfxDragData.ResetFileContents (for example, if |dragData| comes from
        /// CfxRenderHandler.StartDragging). This function is only used when
        /// window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragTargetDragEnter(CfxDragData dragData, CfxMouseEvent @event, CfxDragOperationsMask allowedOps) {
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_enter(NativePtr, CfxDragData.Unwrap(dragData), CfxMouseEvent.Unwrap(@event), (int)allowedOps);
        }

        /// <summary>
        /// Call this function each time the mouse is moved across the web view during
        /// a drag operation (after calling DragTargetDragEnter and before calling
        /// DragTargetDragLeave/DragTargetDrop). This function is only used when window
        /// rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragTargetDragOver(CfxMouseEvent @event, CfxDragOperationsMask allowedOps) {
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_over(NativePtr, CfxMouseEvent.Unwrap(@event), (int)allowedOps);
        }

        /// <summary>
        /// Call this function when the user drags the mouse out of the web view (after
        /// calling DragTargetDragEnter). This function is only used when window
        /// rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragTargetDragLeave() {
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drag_leave(NativePtr);
        }

        /// <summary>
        /// Call this function when the user completes the drag operation by dropping
        /// the object onto the web view (after calling DragTargetDragEnter). The
        /// object being dropped is |dragData|, given as an argument to the previous
        /// DragTargetDragEnter call. This function is only used when window rendering
        /// is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragTargetDrop(CfxMouseEvent @event) {
            CfxApi.BrowserHost.cfx_browser_host_drag_target_drop(NativePtr, CfxMouseEvent.Unwrap(@event));
        }

        /// <summary>
        /// Call this function when the drag operation started by a
        /// CfxRenderHandler.StartDragging call has ended either in a drop or by
        /// being cancelled. |x| and |y| are mouse coordinates relative to the upper-
        /// left corner of the view. If the web view is both the drag source and the
        /// drag target then all DragTarget* functions should be called before
        /// DragSource* mthods. This function is only used when window rendering is
        /// disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragSourceEndedAt(int x, int y, CfxDragOperationsMask op) {
            CfxApi.BrowserHost.cfx_browser_host_drag_source_ended_at(NativePtr, x, y, (int)op);
        }

        /// <summary>
        /// Call this function when the drag operation started by a
        /// CfxRenderHandler.StartDragging call has completed. This function may
        /// be called immediately without first calling DragSourceEndedAt to cancel a
        /// drag operation. If the web view is both the drag source and the drag target
        /// then all DragTarget* functions should be called before DragSource* mthods.
        /// This function is only used when window rendering is disabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void DragSourceSystemDragEnded() {
            CfxApi.BrowserHost.cfx_browser_host_drag_source_system_drag_ended(NativePtr);
        }

        /// <summary>
        /// Set accessibility state for all frames. |accessibilityState| may be
        /// default, enabled or disabled. If |accessibilityState| is STATE_DEFAULT
        /// then accessibility will be disabled by default and the state may be further
        /// controlled with the "force-renderer-accessibility" and "disable-renderer-
        /// accessibility" command-line switches. If |accessibilityState| is
        /// STATE_ENABLED then accessibility will be enabled. If |accessibilityState|
        /// is STATE_DISABLED then accessibility will be completely disabled.
        /// 
        /// For windowed browsers accessibility will be enabled in Complete mode (which
        /// corresponds to kAccessibilityModeComplete in Chromium). In this mode all
        /// platform accessibility objects will be created and managed by Chromium's
        /// internal implementation. The client needs only to detect the screen reader
        /// and call this function appropriately. For example, on macOS the client can
        /// handle the @"AXEnhancedUserStructure" accessibility attribute to detect
        /// VoiceOver state changes and on Windows the client can handle WM_GETOBJECT
        /// with OBJID_CLIENT to detect accessibility readers.
        /// 
        /// For windowless browsers accessibility will be enabled in TreeOnly mode
        /// (which corresponds to kAccessibilityModeWebContentsOnly in Chromium). In
        /// this mode renderer accessibility is enabled, the full tree is computed, and
        /// events are passed to CfxAccessibiltyHandler, but platform accessibility
        /// objects are not created. The client may implement platform accessibility
        /// objects using CfxAccessibiltyHandler callbacks if desired.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SetAccessibilityState(CfxState accessibilityState) {
            CfxApi.BrowserHost.cfx_browser_host_set_accessibility_state(NativePtr, (int)accessibilityState);
        }

        /// <summary>
        /// Enable notifications of auto resize via
        /// CfxDisplayHandler.OnAutoResize. Notifications are disabled by default.
        /// |minSize| and |maxSize| define the range of allowed sizes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SetAutoResizeEnabled(bool enabled, CfxSize minSize, CfxSize maxSize) {
            CfxApi.BrowserHost.cfx_browser_host_set_auto_resize_enabled(NativePtr, enabled ? 1 : 0, CfxSize.Unwrap(minSize), CfxSize.Unwrap(maxSize));
        }

        /// <summary>
        ///  Set whether the browser's audio is muted.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void SetAudioMuted(bool mute) {
            CfxApi.BrowserHost.cfx_browser_host_set_audio_muted(NativePtr, mute ? 1 : 0);
        }
    }
}
