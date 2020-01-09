// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxResourceBundleGetGlobalRemoteCall : RemoteCall {

        internal CfxResourceBundleGetGlobalRemoteCall()
            : base(RemoteCallId.CfxResourceBundleGetGlobalRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.ResourceBundle.cfx_resource_bundle_get_global();
        }
    }

    internal class CfxResourceBundleGetLocalizedStringRemoteCall : RemoteCall {

        internal CfxResourceBundleGetLocalizedStringRemoteCall()
            : base(RemoteCallId.CfxResourceBundleGetLocalizedStringRemoteCall) {}

        internal IntPtr @this;
        internal int stringId;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(stringId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out stringId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.ResourceBundle.cfx_resource_bundle_get_localized_string(@this, stringId));
        }
    }

    internal class CfxResourceBundleGetDataResourceRemoteCall : RemoteCall {

        internal CfxResourceBundleGetDataResourceRemoteCall()
            : base(RemoteCallId.CfxResourceBundleGetDataResourceRemoteCall) {}

        internal IntPtr @this;
        internal int resourceId;
        internal IntPtr data;
        internal ulong dataSize;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(resourceId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out resourceId);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(data);
            h.Write(dataSize);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out data);
            h.Read(out dataSize);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            UIntPtr dataSize_tmp = UIntPtr.Zero;
            __retval = 0 != CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource(@this, resourceId, out data, out dataSize_tmp);
            dataSize = (ulong)dataSize_tmp;
        }
    }

    internal class CfxResourceBundleGetDataResourceForScaleRemoteCall : RemoteCall {

        internal CfxResourceBundleGetDataResourceForScaleRemoteCall()
            : base(RemoteCallId.CfxResourceBundleGetDataResourceForScaleRemoteCall) {}

        internal IntPtr @this;
        internal int resourceId;
        internal int scaleFactor;
        internal IntPtr data;
        internal ulong dataSize;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(resourceId);
            h.Write(scaleFactor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out resourceId);
            h.Read(out scaleFactor);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(data);
            h.Write(dataSize);
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out data);
            h.Read(out dataSize);
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            UIntPtr dataSize_tmp = UIntPtr.Zero;
            __retval = 0 != CfxApi.ResourceBundle.cfx_resource_bundle_get_data_resource_for_scale(@this, resourceId, (int)scaleFactor, out data, out dataSize_tmp);
            dataSize = (ulong)dataSize_tmp;
        }
    }

}
