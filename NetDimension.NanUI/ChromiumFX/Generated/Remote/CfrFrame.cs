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
            lock(weakCache) {
                var cfrObj = (CfrFrame)weakCache.Get(remotePtr.ptr);
                if(cfrObj == null) {
                    cfrObj = new CfrFrame(remotePtr);
                    weakCache.Add(remotePtr.ptr, cfrObj);
                }
                return cfrObj;
            }
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
                var call = new CfxFrameIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameIsMainRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameIsFocusedRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameGetNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameGetIdentifierRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameGetParentRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                return CfrFrame.Wrap(new RemotePtr(call.__retval));
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
                var call = new CfxFrameGetUrlRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
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
                var call = new CfxFrameGetBrowserRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                return CfrBrowser.Wrap(new RemotePtr(call.__retval));
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
                var call = new CfxFrameGetV8ContextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(RemotePtr.connection);
                return CfrV8Context.Wrap(new RemotePtr(call.__retval));
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
            var call = new CfxFrameUndoRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute redo in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Redo() {
            var call = new CfxFrameRedoRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute cut in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Cut() {
            var call = new CfxFrameCutRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute copy in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Copy() {
            var call = new CfxFrameCopyRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute paste in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Paste() {
            var call = new CfxFramePasteRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute delete in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void Delete() {
            var call = new CfxFrameDelRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Execute select all in this frame.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void SelectAll() {
            var call = new CfxFrameSelectAllRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(RemotePtr.connection);
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
            var call = new CfxFrameGetSourceRemoteCall();
            call.@this = RemotePtr.ptr;
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(RemotePtr.connection);
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
            var call = new CfxFrameGetTextRemoteCall();
            call.@this = RemotePtr.ptr;
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Load the request represented by the |request| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadRequest(CfrRequest request) {
            var call = new CfxFrameLoadRequestRemoteCall();
            call.@this = RemotePtr.ptr;
            call.request = CfrObject.Unwrap(request).ptr;
            call.RequestExecution(RemotePtr.connection);
        }

        /// <summary>
        /// Load the specified |url|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_frame_capi.h">cef/include/capi/cef_frame_capi.h</see>.
        /// </remarks>
        public void LoadUrl(string url) {
            var call = new CfxFrameLoadUrlRemoteCall();
            call.@this = RemotePtr.ptr;
            call.url = url;
            call.RequestExecution(RemotePtr.connection);
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
            var call = new CfxFrameLoadStringRemoteCall();
            call.@this = RemotePtr.ptr;
            call.stringVal = stringVal;
            call.url = url;
            call.RequestExecution(RemotePtr.connection);
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
            var call = new CfxFrameExecuteJavaScriptRemoteCall();
            call.@this = RemotePtr.ptr;
            call.code = code;
            call.scriptUrl = scriptUrl;
            call.startLine = startLine;
            call.RequestExecution(RemotePtr.connection);
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
            var call = new CfxFrameVisitDomRemoteCall();
            call.@this = RemotePtr.ptr;
            call.visitor = CfrObject.Unwrap(visitor).ptr;
            call.RequestExecution(RemotePtr.connection);
        }
    }
}
