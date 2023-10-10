// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Implement this interface to handle events related to CefFrame life span. The
/// order of callbacks is:
/// (1) During initial CefBrowserHost creation and navigation of the main frame:
/// - CefFrameHandler::OnFrameCreated => The initial main frame object has been
/// created. Any commands will be queued until the frame is attached.
/// - CefFrameHandler::OnMainFrameChanged => The initial main frame object has
/// been assigned to the browser.
/// - CefLifeSpanHandler::OnAfterCreated => The browser is now valid and can be
/// used.
/// - CefFrameHandler::OnFrameAttached => The initial main frame object is now
/// connected to its peer in the renderer process. Commands can be routed.
/// (2) During further CefBrowserHost navigation/loading of the main frame
/// and/or sub-frames:
/// - CefFrameHandler::OnFrameCreated => A new main frame or sub-frame object
/// has been created. Any commands will be queued until the frame is attached.
/// - CefFrameHandler::OnFrameAttached => A new main frame or sub-frame object
/// is now connected to its peer in the renderer process. Commands can be
/// routed.
/// - CefFrameHandler::OnFrameDetached => An existing main frame or sub-frame
/// object has lost its connection to the renderer process. If multiple
/// objects are detached at the same time then notifications will be sent for
/// any sub-frame objects before the main frame object. Commands can no longer
/// be routed and will be discarded.
/// - CefFrameHandler::OnMainFrameChanged => A new main frame object has been
/// assigned to the browser. This will only occur with cross-origin navigation
/// or re-navigation after renderer process termination (due to crashes, etc).
/// (3) During final CefBrowserHost destruction of the main frame:
/// - CefFrameHandler::OnFrameDetached => Any sub-frame objects have lost their
/// connection to the renderer process. Commands can no longer be routed and
/// will be discarded.
/// - CefLifeSpanHandler::OnBeforeClose => The browser has been destroyed.
/// - CefFrameHandler::OnFrameDetached => The main frame object have lost its
/// connection to the renderer process. Notifications will be sent for any
/// sub-frame objects before the main frame object. Commands can no longer be
/// routed and will be discarded.
/// - CefFrameHandler::OnMainFrameChanged => The final main frame object has
/// been removed from the browser.
/// Cross-origin navigation and/or loading receives special handling.
/// When the main frame navigates to a different origin the OnMainFrameChanged
/// callback (2) will be executed with the old and new main frame objects.
/// When a new sub-frame is loaded in, or an existing sub-frame is navigated to,
/// a different origin from the parent frame, a temporary sub-frame object will
/// first be created in the parent's renderer process. That temporary sub-frame
/// will then be discarded after the real cross-origin sub-frame is created in
/// the new/target renderer process. The client will receive cross-origin
/// navigation callbacks (2) for the transition from the temporary sub-frame to
/// the real sub-frame. The temporary sub-frame will not recieve or execute
/// commands during this transitional period (any sent commands will be
/// discarded).
/// When a new popup browser is created in a different origin from the parent
/// browser, a temporary main frame object for the popup will first be created
/// in the parent's renderer process. That temporary main frame will then be
/// discarded after the real cross-origin main frame is created in the
/// new/target renderer process. The client will recieve creation and initial
/// navigation callbacks (1) for the temporary main frame, followed by
/// cross-origin navigation callbacks (2) for the transition from the temporary
/// main frame to the real main frame. The temporary main frame may receive and
/// execute commands during this transitional period (any sent commands may be
/// executed, but the behavior is potentially undesirable since they execute in
/// the parent browser's renderer process and not the new/target renderer
/// process).
/// Callbacks will not be executed for placeholders that may be created during
/// pre-commit navigation for sub-frames that do not yet exist in the renderer
/// process. Placeholders will have CefFrame::GetIdentifier() == -4.
/// The methods of this class will be called on the UI thread unless otherwise
/// indicated.
/// </summary>
public abstract unsafe partial class CefFrameHandler
{
    private void on_frame_created(cef_frame_handler_t* self, cef_browser_t* browser, cef_frame_t* frame)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        OnFrameCreated(mBrowser, mFrame);
    }

    /// <summary>
    /// Called when a new frame is created. This will be the first notification
    /// that references |frame|. Any commands that require transport to the
    /// associated renderer process (LoadRequest, SendProcessMessage, GetSource,
    /// etc.) will be queued until OnFrameAttached is called for |frame|.
    /// </summary>
    protected virtual void OnFrameCreated(CefBrowser browser, CefFrame frame)
    { }


    private void on_frame_attached(cef_frame_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, int reattached)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        OnFrameAttached(mBrowser, mFrame, reattached != 0);
    }

    /// <summary>
    /// Called when a frame can begin routing commands to/from the associated
    /// renderer process. |reattached| will be true if the frame was re-attached
    /// after exiting the BackForwardCache. Any commands that were queued have now
    /// been dispatched.
    /// </summary>
    protected virtual void OnFrameAttached(CefBrowser browser, CefFrame frame, bool reattached)
    { }


    private void on_frame_detached(cef_frame_handler_t* self, cef_browser_t* browser, cef_frame_t* frame)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mFrame = CefFrame.FromNative(frame);
        OnFrameDetached(mBrowser, mFrame);
    }
    
    /// <summary>
    /// Called when a frame loses its connection to the renderer process and will
    /// be destroyed. Any pending or future commands will be discarded and
    /// CefFrame::IsValid() will now return false for |frame|. If called after
    /// CefLifeSpanHandler::OnBeforeClose() during browser destruction then
    /// CefBrowser::IsValid() will return false for |browser|.
    /// </summary>
    protected virtual void OnFrameDetached(CefBrowser browser, CefFrame frame)
    { }


    private void on_main_frame_changed(cef_frame_handler_t* self, cef_browser_t* browser, cef_frame_t* old_frame, cef_frame_t* new_frame)
    {
        CheckSelf(self);

        var mBrowser = CefBrowser.FromNative(browser);
        var mOldFrame = CefFrame.FromNativeOrNull(old_frame);
        var mNewFrame = CefFrame.FromNativeOrNull(new_frame);
        OnMainFrameChanged(mBrowser, mOldFrame, mNewFrame);
    }

    /// <summary>
    /// Called when the main frame changes due to (a) initial browser creation,
    /// (b) final browser destruction, (c) cross-origin navigation or (d)
    /// re-navigation after renderer process termination (due to crashes, etc).
    /// |old_frame| will be NULL and |new_frame| will be non-NULL when a main
    /// frame is assigned to |browser| for the first time. |old_frame| will be
    /// non-NULL and |new_frame| will be NULL and  when a main frame is removed
    /// from |browser| for the last time. Both |old_frame| and |new_frame| will be
    /// non-NULL for cross-origin navigations or re-navigation after renderer
    /// process termination. This method will be called after OnFrameCreated() for
    /// |new_frame| and/or after OnFrameDetached() for |old_frame|. If called
    /// after CefLifeSpanHandler::OnBeforeClose() during browser destruction then
    /// CefBrowser::IsValid() will return false for |browser|.
    /// </summary>
    protected virtual void OnMainFrameChanged(CefBrowser browser, CefFrame? oldFrame, CefFrame? newFrame)
    { }
}
