// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxRenderProcessHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxRenderProcessHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxRenderProcessHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.RenderProcessHandler.cfx_render_process_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxRenderProcessHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxRenderProcessHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxRenderProcessHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxRenderProcessHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall) {}

        internal IntPtr extra_info;
        internal int extra_info_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(extra_info);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out extra_info);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(extra_info_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out extra_info_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnRenderThreadCreatedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnRenderThreadCreated?.Invoke(self, e);
            e.connection = null;
            extra_info_release = e.m_extra_info_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnWebKitInitializedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnWebKitInitializedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnWebKitInitializedRemoteEventCall) {}


        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
        }

        protected override void ReadReturn(StreamHandler h) {
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrEventArgs();
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnWebKitInitialized?.Invoke(self, e);
            e.connection = null;
        }
    }

    internal class CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr extra_info;
        internal int extra_info_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(extra_info);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out extra_info);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(extra_info_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out extra_info_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnBrowserCreatedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnBrowserCreated?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            extra_info_release = e.m_extra_info_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnBrowserDestroyedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnBrowserDestroyed?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall) {}


        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetLoadHandlerEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetLoadHandler?.Invoke(self, e);
            e.connection = null;
            __retval = CfrObject.Unwrap(e.m_returnValue).ptr;
        }
    }

    internal class CfxRenderProcessHandlerOnContextCreatedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnContextCreatedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnContextCreatedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal IntPtr context;
        internal int context_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(context);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out context);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
            h.Write(context_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
            h.Read(out context_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnContextCreatedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnContextCreated?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnContextReleasedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnContextReleasedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnContextReleasedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal IntPtr context;
        internal int context_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(context);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out context);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
            h.Write(context_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
            h.Read(out context_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnContextReleasedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnContextReleased?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal IntPtr context;
        internal int context_release;
        internal IntPtr exception;
        internal int exception_release;
        internal IntPtr stackTrace;
        internal int stackTrace_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(context);
            h.Write(exception);
            h.Write(stackTrace);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out context);
            h.Read(out exception);
            h.Read(out stackTrace);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
            h.Write(context_release);
            h.Write(exception_release);
            h.Write(stackTrace_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
            h.Read(out context_release);
            h.Read(out exception_release);
            h.Read(out stackTrace_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnUncaughtExceptionEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnUncaughtException?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            context_release = e.m_context_wrapped == null? 1 : 0;
            exception_release = e.m_exception_wrapped == null? 1 : 0;
            stackTrace_release = e.m_stackTrace_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal IntPtr node;
        internal int node_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(node);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out node);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
            h.Write(node_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
            h.Read(out node_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnFocusedNodeChangedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnFocusedNodeChanged?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            node_release = e.m_node_wrapped == null? 1 : 0;
        }
    }

    internal class CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall : RemoteEventCall {

        internal CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall()
            : base(RemoteCallId.CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall) {}

        internal IntPtr browser;
        internal int browser_release;
        internal IntPtr frame;
        internal int frame_release;
        internal int source_process;
        internal IntPtr message;
        internal int message_release;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(browser);
            h.Write(frame);
            h.Write(source_process);
            h.Write(message);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out browser);
            h.Read(out frame);
            h.Read(out source_process);
            h.Read(out message);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(browser_release);
            h.Write(frame_release);
            h.Write(message_release);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out browser_release);
            h.Read(out frame_release);
            h.Read(out message_release);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrRenderProcessHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnProcessMessageReceivedEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnProcessMessageReceived?.Invoke(self, e);
            e.connection = null;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            message_release = e.m_message_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
