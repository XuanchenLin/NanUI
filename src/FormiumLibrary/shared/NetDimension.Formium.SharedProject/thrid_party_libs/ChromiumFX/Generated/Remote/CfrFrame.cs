// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

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
    public class CfrFrame : CfrBaseLibrary {

        internal static CfrFrame Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrFrame)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrFrame(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }



        private CfrFrame(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// True if this object is currently attached to a valid frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxFrameIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxFrameIsMainRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxFrameIsFocusedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetIdentifierRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
        public CfrFrame Parent {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetParentRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrFrame.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the browser that this frame belongs to.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public CfrBrowser Browser {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetBrowserRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrBrowser.Wrap(new RemotePtr(connection, call.__retval));
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
        public CfrV8Context V8Context {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxFrameGetV8ContextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrV8Context.Wrap(new RemotePtr(connection, call.__retval));
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
            var connection = RemotePtr.connection;
            var call = new CfxFrameUndoRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute redo in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Redo() {
            var connection = RemotePtr.connection;
            var call = new CfxFrameRedoRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute cut in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Cut() {
            var connection = RemotePtr.connection;
            var call = new CfxFrameCutRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute copy in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Copy() {
            var connection = RemotePtr.connection;
            var call = new CfxFrameCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute paste in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Paste() {
            var connection = RemotePtr.connection;
            var call = new CfxFramePasteRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute delete in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Delete() {
            var connection = RemotePtr.connection;
            var call = new CfxFrameDelRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Execute select all in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void SelectAll() {
            var connection = RemotePtr.connection;
            var call = new CfxFrameSelectAllRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Retrieve this frame's HTML source as a string sent to the specified
        /// visitor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void GetSource(CfrStringVisitor visitor) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameGetSourceRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(visitor, connection)) throw new ArgumentException("Render process connection mismatch.", "visitor");
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Retrieve this frame's display text as a string sent to the specified
        /// visitor.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void GetText(CfrStringVisitor visitor) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameGetTextRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(visitor, connection)) throw new ArgumentException("Render process connection mismatch.", "visitor");
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Load the request represented by the |request| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadRequest(CfrRequest request) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameLoadRequestRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(request, connection)) throw new ArgumentException("Render process connection mismatch.", "request");
            call.request = CfrObject.Unwrap(request).ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Load the specified |url|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadUrl(string url) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameLoadUrlRemoteCall();
            call.@this = RemotePtr.ptr;
            call.url = url;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxFrameLoadStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.stringVal = stringVal;
            call.url = url;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxFrameExecuteJavaScriptRemoteCall();
            call.@this = RemotePtr.ptr;
            call.code = code;
            call.scriptUrl = scriptUrl;
            call.startLine = startLine;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Visit the DOM document. This function can only be called from the render
        /// process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void VisitDom(CfrDomVisitor visitor) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameVisitDomRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(visitor, connection)) throw new ArgumentException("Render process connection mismatch.", "visitor");
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Create a new URL request that will be treated as originating from this
        /// frame and the associated browser. This request may be intercepted by the
        /// client via CfrResourceRequestHandler or CfrSchemeHandlerFactory.
        /// Use CfrUrlRequest.Create instead if you do not want the request to have
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
        public CfrUrlRequest CreateUrlRequest(CfrRequest request, CfrUrlRequestClient client) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameCreateUrlRequestRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(request, connection)) throw new ArgumentException("Render process connection mismatch.", "request");
            call.request = CfrObject.Unwrap(request).ptr;
            if(!CfrObject.CheckConnection(client, connection)) throw new ArgumentException("Render process connection mismatch.", "client");
            call.client = CfrObject.Unwrap(client).ptr;
            call.RequestExecution(connection);
            return CfrUrlRequest.Wrap(new RemotePtr(connection, call.__retval));
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
        public void SendProcessMessage(CfxProcessId targetProcess, CfrProcessMessage message) {
            var connection = RemotePtr.connection;
            var call = new CfxFrameSendProcessMessageRemoteCall();
            call.@this = RemotePtr.ptr;
            call.targetProcess = (int)targetProcess;
            if(!CfrObject.CheckConnection(message, connection)) throw new ArgumentException("Render process connection mismatch.", "message");
            call.message = CfrObject.Unwrap(message).ptr;
            call.RequestExecution(connection);
        }
    }
}
