// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxPostDataCreateRemoteCall : RemoteCall {

        internal CfxPostDataCreateRemoteCall()
            : base(RemoteCallId.CfxPostDataCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.PostData.cfx_post_data_create();
        }
    }

    internal class CfxPostDataIsReadOnlyRemoteCall : RemoteCall {

        internal CfxPostDataIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxPostDataIsReadOnlyRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.PostData.cfx_post_data_is_read_only(@this);
        }
    }

    internal class CfxPostDataHasExcludedElementsRemoteCall : RemoteCall {

        internal CfxPostDataHasExcludedElementsRemoteCall()
            : base(RemoteCallId.CfxPostDataHasExcludedElementsRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.PostData.cfx_post_data_has_excluded_elements(@this);
        }
    }

    internal class CfxPostDataGetElementCountRemoteCall : RemoteCall {

        internal CfxPostDataGetElementCountRemoteCall()
            : base(RemoteCallId.CfxPostDataGetElementCountRemoteCall) {}

        internal IntPtr @this;
        internal ulong __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = (ulong)CfxApi.PostData.cfx_post_data_get_element_count(@this);
        }
    }

    internal class CfxPostDataGetElementsRemoteCall : RemoteCall {

        internal CfxPostDataGetElementsRemoteCall()
            : base(RemoteCallId.CfxPostDataGetElementsRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr[] __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var count = CfxApi.PostData.cfx_post_data_get_element_count(@this);
            __retval = new IntPtr[(ulong)count];
            if(__retval.Length == 0) return;
            var ptrs_p = new PinnedObject(__retval);
            CfxApi.PostData.cfx_post_data_get_elements(@this, count, ptrs_p.PinnedPtr);
            ptrs_p.Free();
            
        }
    }

    internal class CfxPostDataRemoveElementRemoteCall : RemoteCall {

        internal CfxPostDataRemoveElementRemoteCall()
            : base(RemoteCallId.CfxPostDataRemoveElementRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr element;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(element);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out element);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.PostData.cfx_post_data_remove_element(@this, element);
        }
    }

    internal class CfxPostDataAddElementRemoteCall : RemoteCall {

        internal CfxPostDataAddElementRemoteCall()
            : base(RemoteCallId.CfxPostDataAddElementRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr element;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(element);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out element);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.PostData.cfx_post_data_add_element(@this, element);
        }
    }

    internal class CfxPostDataRemoveElementsRemoteCall : RemoteCall {

        internal CfxPostDataRemoveElementsRemoteCall()
            : base(RemoteCallId.CfxPostDataRemoveElementsRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.PostData.cfx_post_data_remove_elements(@this);
        }
    }

}
