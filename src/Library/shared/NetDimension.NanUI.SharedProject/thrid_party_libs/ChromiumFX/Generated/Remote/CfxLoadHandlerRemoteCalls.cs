// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxLoadHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxLoadHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxLoadHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.LoadHandler.cfx_load_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxLoadHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxLoadHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxLoadHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxLoadHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxLoadHandlerOnLoadingStateChangeRemoteEventCall : RemoteEventCall {

        internal CfxLoadHandlerOnLoadingStateChangeRemoteEventCall()
            : base(RemoteCallId.CfxLoadHandlerOnLoadingStateChangeRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal int isLoading;
        internal int canGoBack;
        internal int canGoForward;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(isLoading);
            h.Write(canGoBack);
            h.Write(canGoForward);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out isLoading);
            h.Read(out canGoBack);
            h.Read(out canGoForward);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnLoadingStateChangeEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnLoadingStateChange?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }
    }

    internal class CfxLoadHandlerOnLoadStartRemoteEventCall : RemoteEventCall {

        internal CfxLoadHandlerOnLoadStartRemoteEventCall()
            : base(RemoteCallId.CfxLoadHandlerOnLoadStartRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal int transition_type;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(transition_type);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out transition_type);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnLoadStartEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnLoadStart?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }
    }

    internal class CfxLoadHandlerOnLoadEndRemoteEventCall : RemoteEventCall {

        internal CfxLoadHandlerOnLoadEndRemoteEventCall()
            : base(RemoteCallId.CfxLoadHandlerOnLoadEndRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal int httpStatusCode;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(httpStatusCode);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out httpStatusCode);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnLoadEndEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnLoadEnd?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }
    }

    internal class CfxLoadHandlerOnLoadErrorRemoteEventCall : RemoteEventCall {

        internal CfxLoadHandlerOnLoadErrorRemoteEventCall()
            : base(RemoteCallId.CfxLoadHandlerOnLoadErrorRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal int errorCode;
        internal IntPtr errorText_str;
        internal int errorText_length;
        internal IntPtr failedUrl_str;
        internal int failedUrl_length;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(errorCode);
            h.Write(errorText_str);
            h.Write(errorText_length);
            h.Write(failedUrl_str);
            h.Write(failedUrl_length);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out errorCode);
            h.Read(out errorText_str);
            h.Read(out errorText_length);
            h.Read(out failedUrl_str);
            h.Read(out failedUrl_length);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrLoadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnLoadErrorEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnLoadError?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }
    }

}
