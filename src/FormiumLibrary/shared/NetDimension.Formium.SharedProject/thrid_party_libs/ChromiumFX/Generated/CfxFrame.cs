// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a frame in the browser window. When used in the
    /// browser process the functions of this structure may be called on any thread
    /// unless otherwise indicated in the comments. When used in the render process
    /// the functions of this structure may only be called on the main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
    /// </remarks>
    public class CfxFrame : CfxBaseLibrary {

        internal static CfxFrame Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxFrame)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxFrame(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxFrame(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// True if this object is currently attached to a valid frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.Frame.cfx_frame_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is the main (top-level) frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public bool IsMain {
            get {
                return 0 != CfxApi.Frame.cfx_frame_is_main(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is the focused frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public bool IsFocused {
            get {
                return 0 != CfxApi.Frame.cfx_frame_is_focused(NativePtr);
            }
        }

        /// <summary>
        /// Returns the name for this frame. If the frame has an assigned name (for
        /// example, set via the iframe "name" attribute) then that value will be
        /// returned. Otherwise a unique name will be constructed based on the frame
        /// parent hierarchy. The main (top-level) frame will always have an NULL name
        /// value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public string Name {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Frame.cfx_frame_get_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the globally unique identifier for this frame or &lt; 0 if the
        /// underlying frame does not yet exist.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public long Identifier {
            get {
                return CfxApi.Frame.cfx_frame_get_identifier(NativePtr);
            }
        }

        /// <summary>
        /// Returns the parent of this frame or NULL if this is the main (top-level)
        /// frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public CfxFrame Parent {
            get {
                return CfxFrame.Wrap(CfxApi.Frame.cfx_frame_get_parent(NativePtr));
            }
        }

        /// <summary>
        /// Returns the URL currently loaded in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public string Url {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.Frame.cfx_frame_get_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the browser that this frame belongs to.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public CfxBrowser Browser {
            get {
                return CfxBrowser.Wrap(CfxApi.Frame.cfx_frame_get_browser(NativePtr));
            }
        }

        /// <summary>
        /// Get the V8 context associated with the frame. This function can only be
        /// called from the render process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public CfxV8Context V8Context {
            get {
                return CfxV8Context.Wrap(CfxApi.Frame.cfx_frame_get_v8context(NativePtr));
            }
        }

        /// <summary>
        /// Execute undo in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Undo() {
            CfxApi.Frame.cfx_frame_undo(NativePtr);
        }

        /// <summary>
        /// Execute redo in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Redo() {
            CfxApi.Frame.cfx_frame_redo(NativePtr);
        }

        /// <summary>
        /// Execute cut in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Cut() {
            CfxApi.Frame.cfx_frame_cut(NativePtr);
        }

        /// <summary>
        /// Execute copy in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Copy() {
            CfxApi.Frame.cfx_frame_copy(NativePtr);
        }

        /// <summary>
        /// Execute paste in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Paste() {
            CfxApi.Frame.cfx_frame_paste(NativePtr);
        }

        /// <summary>
        /// Execute delete in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Delete() {
            CfxApi.Frame.cfx_frame_del(NativePtr);
        }

        /// <summary>
        /// Execute select all in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void SelectAll() {
            CfxApi.Frame.cfx_frame_select_all(NativePtr);
        }

        /// <summary>
        /// Save this frame's HTML source to a temporary file and open it in the
        /// default text viewing application. This function can only be called from the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void ViewSource() {
            CfxApi.Frame.cfx_frame_view_source(NativePtr);
        }

        /// <summary>
        /// Retrieve this frame's HTML source as a string sent to the specified
        /// visitor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void GetSource(CfxStringVisitor visitor) {
            CfxApi.Frame.cfx_frame_get_source(NativePtr, CfxStringVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Retrieve this frame's display text as a string sent to the specified
        /// visitor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void GetText(CfxStringVisitor visitor) {
            CfxApi.Frame.cfx_frame_get_text(NativePtr, CfxStringVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Load the request represented by the |request| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadRequest(CfxRequest request) {
            CfxApi.Frame.cfx_frame_load_request(NativePtr, CfxRequest.Unwrap(request));
        }

        /// <summary>
        /// Load the specified |url|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadUrl(string url) {
            var url_pinned = new PinnedString(url);
            CfxApi.Frame.cfx_frame_load_url(NativePtr, url_pinned.Obj.PinnedPtr, url_pinned.Length);
            url_pinned.Obj.Free();
        }

        /// <summary>
        /// Load the contents of |stringVal| with the specified dummy |url|. |url|
        /// should have a standard scheme (for example, http scheme) or behaviors like
        /// link clicks and web security restrictions may not behave as expected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadString(string stringVal, string url) {
            var stringVal_pinned = new PinnedString(stringVal);
            var url_pinned = new PinnedString(url);
            CfxApi.Frame.cfx_frame_load_string(NativePtr, stringVal_pinned.Obj.PinnedPtr, stringVal_pinned.Length, url_pinned.Obj.PinnedPtr, url_pinned.Length);
            stringVal_pinned.Obj.Free();
            url_pinned.Obj.Free();
        }

        /// <summary>
        /// Execute a string of JavaScript code in this frame. The |scriptUrl|
        /// parameter is the URL where the script in question can be found, if any. The
        /// renderer may request this URL to show the developer the source of the
        /// error.  The |startLine| parameter is the base line number to use for error
        /// reporting.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void ExecuteJavaScript(string code, string scriptUrl, int startLine) {
            var code_pinned = new PinnedString(code);
            var scriptUrl_pinned = new PinnedString(scriptUrl);
            CfxApi.Frame.cfx_frame_execute_java_script(NativePtr, code_pinned.Obj.PinnedPtr, code_pinned.Length, scriptUrl_pinned.Obj.PinnedPtr, scriptUrl_pinned.Length, startLine);
            code_pinned.Obj.Free();
            scriptUrl_pinned.Obj.Free();
        }

        /// <summary>
        /// Visit the DOM document. This function can only be called from the render
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void VisitDom(CfxDomVisitor visitor) {
            CfxApi.Frame.cfx_frame_visit_dom(NativePtr, CfxDomVisitor.Unwrap(visitor));
        }

        /// <summary>
        /// Create a new URL request that will be treated as originating from this
        /// frame and the associated browser. This request may be intercepted by the
        /// client via CfxResourceRequestHandler or CfxSchemeHandlerFactory.
        /// Use CfxUrlRequest.Create instead if you do not want the request to have
        /// this association, in which case it may be handled differently (see
        /// documentation on that function). Requests may originate from both the
        /// browser process and the render process.
        /// 
        /// For requests originating from the browser process:
        ///   - POST data may only contain a single element of type PDE_TYPE_FILE or
        ///     PDE_TYPE_BYTES.
        /// For requests originating from the render process:
        ///   - POST data may only contain a single element of type PDE_TYPE_BYTES.
        ///   - If the response contains Content-Disposition or Mime-Type header values
        ///     that would not normally be rendered then the response may receive
        ///     special handling inside the browser (for example, via the file download
        ///     code path instead of the URL request code path).
        /// 
        /// The |request| object will be marked as read-only after calling this
        /// function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public CfxUrlRequest CreateUrlRequest(CfxRequest request, CfxUrlRequestClient client) {
            return CfxUrlRequest.Wrap(CfxApi.Frame.cfx_frame_create_urlrequest(NativePtr, CfxRequest.Unwrap(request), CfxUrlRequestClient.Unwrap(client)));
        }

        /// <summary>
        /// Send a message to the specified |targetProcess|. Message delivery is not
        /// guaranteed in all cases (for example, if the browser is closing,
        /// navigating, or if the target process crashes). Send an ACK message back
        /// from the target process if confirmation is required.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void SendProcessMessage(CfxProcessId targetProcess, CfxProcessMessage message) {
            CfxApi.Frame.cfx_frame_send_process_message(NativePtr, (int)targetProcess, CfxProcessMessage.Unwrap(message));
        }
    }
}
