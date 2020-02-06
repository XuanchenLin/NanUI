// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    internal class CfxResourceBundleHandlerCtorWithGCHandleRemoteCall : CtorWithGCHandleRemoteCall {

        internal CfxResourceBundleHandlerCtorWithGCHandleRemoteCall()
            : base(RemoteCallId.CfxResourceBundleHandlerCtorWithGCHandleRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_ctor(gcHandlePtr, 1);
        }
    }

    internal class CfxResourceBundleHandlerSetCallbackRemoteCall : SetCallbackRemoteCall {

        internal CfxResourceBundleHandlerSetCallbackRemoteCall()
            : base(RemoteCallId.CfxResourceBundleHandlerSetCallbackRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxResourceBundleHandlerRemoteClient.SetCallback(self, index, active);
        }
    }

    internal class CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall : RemoteEventCall {

        internal CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall()
            : base(RemoteCallId.CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall) {}

        internal int string_id;
        internal string @string;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(string_id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out string_id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(@string);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out @string);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetLocalizedStringEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetLocalizedString?.Invoke(self, e);
            e.connection = null;
            @string = e.m_string_wrapped;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxResourceBundleHandlerGetDataResourceRemoteEventCall : RemoteEventCall {

        internal CfxResourceBundleHandlerGetDataResourceRemoteEventCall()
            : base(RemoteCallId.CfxResourceBundleHandlerGetDataResourceRemoteEventCall) {}

        internal int resource_id;
        internal IntPtr data;
        internal UIntPtr data_size;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(resource_id);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out resource_id);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(data);
            h.Write(data_size);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out data);
            h.Read(out data_size);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetDataResourceEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetDataResource?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

    internal class CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall : RemoteEventCall {

        internal CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall()
            : base(RemoteCallId.CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall) {}

        internal int resource_id;
        internal int scale_factor;
        internal IntPtr data;
        internal UIntPtr data_size;

        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gcHandlePtr);
            h.Write(resource_id);
            h.Write(scale_factor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gcHandlePtr);
            h.Read(out resource_id);
            h.Read(out scale_factor);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(data);
            h.Write(data_size);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out data);
            h.Read(out data_size);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var self = (CfrResourceBundleHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfrGetDataResourceForScaleEventArgs(this);
            e.connection = CfxRemoteCallContext.CurrentContext.connection;
            self.m_GetDataResourceForScale?.Invoke(self, e);
            e.connection = null;
            __retval = e.m_returnValue ? 1 : 0;
        }
    }

}
