// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxAppCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxAppCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxAppCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.App.cfx_app_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxAppSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxAppSetCallbackRemoteCall()
            : base(RemoteCallId.CfxAppSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxAppRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxAppOnBeforeCommandLineProcessingRemoteEventCall : RemoteEventCall {

        internal CfxAppOnBeforeCommandLineProcessingRemoteEventCall()
            : base(RemoteCallId.CfxAppOnBeforeCommandLineProcessingRemoteEventCall) {}

        internal IntPtr process_type_str;
        internal int process_type_length;
        internal IntPtr command_line;
        internal int command_line_release;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(process_type_str);
            h.Write(process_type_length);
            h.Write(command_line);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out process_type_str);
            h.Read(out process_type_length);
            h.Read(out command_line);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(command_line_release);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out command_line_release);
        }

        protected override void RemoteProcedure() {
            var self = (CfrApp)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnBeforeCommandLineProcessingEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnBeforeCommandLineProcessing?.Invoke(self, e);
            e.connection = null;
            command_line_release = e.m_command_line_wrapped == null? 1 : 0;
        }
    }

    internal class CfxAppOnRegisterCustomSchemesRemoteEventCall : RemoteEventCall {

        internal CfxAppOnRegisterCustomSchemesRemoteEventCall()
            : base(RemoteCallId.CfxAppOnRegisterCustomSchemesRemoteEventCall) {}

        internal IntPtr registrar;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(registrar);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out registrar);
        }

        protected override void WriteReturn(StreamHandler h) {
        }

        protected override void ReadReturn(StreamHandler h) {
        }

        protected override void RemoteProcedure() {
            var self = (CfrApp)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrOnRegisterCustomSchemesEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_OnRegisterCustomSchemes?.Invoke(self, e);
            e.connection = null;
            if(e.m_registrar_wrapped != null) e.m_registrar_wrapped.Dispose();
        }
    }

    internal class CfxAppGetResourceBundleHandlerRemoteEventCall : RemoteEventCall {

        internal CfxAppGetResourceBundleHandlerRemoteEventCall()
            : base(RemoteCallId.CfxAppGetResourceBundleHandlerRemoteEventCall) {}


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
            var self = (CfrApp)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetResourceBundleHandlerEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetResourceBundleHandler?.Invoke(self, e);
            e.connection = null;
            __retval = CfrObject.Unwrap(e.m_returnValue).ptr;
        }
    }

    internal class CfxAppGetRenderProcessHandlerRemoteEventCall : RemoteEventCall {

        internal CfxAppGetRenderProcessHandlerRemoteEventCall()
            : base(RemoteCallId.CfxAppGetRenderProcessHandlerRemoteEventCall) {}


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
            var self = (CfrApp)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetRenderProcessHandlerEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetRenderProcessHandler?.Invoke(self, e);
            e.connection = null;
            __retval = CfrObject.Unwrap(e.m_returnValue).ptr;
        }
    }

}
