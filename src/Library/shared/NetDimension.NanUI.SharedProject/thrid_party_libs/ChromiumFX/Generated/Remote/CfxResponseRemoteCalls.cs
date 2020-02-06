// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxResponseCreateRemoteCall : RemoteCall {

        internal CfxResponseCreateRemoteCall()
            : base(RemoteCallId.CfxResponseCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Response.cfx_response_create();
        }
    }

    internal class CfxResponseIsReadOnlyRemoteCall : RemoteCall {

        internal CfxResponseIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxResponseIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.Response.cfx_response_is_read_only(@this);
        }
    }

    internal class CfxResponseGetErrorRemoteCall : RemoteCall {

        internal CfxResponseGetErrorRemoteCall()
            : base(RemoteCallId.CfxResponseGetErrorRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

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
            __retval = CfxApi.Response.cfx_response_get_error(@this);
        }
    }

    internal class CfxResponseSetErrorRemoteCall : RemoteCall {

        internal CfxResponseSetErrorRemoteCall()
            : base(RemoteCallId.CfxResponseSetErrorRemoteCall) {}

        internal IntPtr @this;
        internal int value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            CfxApi.Response.cfx_response_set_error(@this, (int)value);
        }
    }

    internal class CfxResponseGetStatusRemoteCall : RemoteCall {

        internal CfxResponseGetStatusRemoteCall()
            : base(RemoteCallId.CfxResponseGetStatusRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

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
            __retval = CfxApi.Response.cfx_response_get_status(@this);
        }
    }

    internal class CfxResponseSetStatusRemoteCall : RemoteCall {

        internal CfxResponseSetStatusRemoteCall()
            : base(RemoteCallId.CfxResponseSetStatusRemoteCall) {}

        internal IntPtr @this;
        internal int value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            CfxApi.Response.cfx_response_set_status(@this, value);
        }
    }

    internal class CfxResponseGetStatusTextRemoteCall : RemoteCall {

        internal CfxResponseGetStatusTextRemoteCall()
            : base(RemoteCallId.CfxResponseGetStatusTextRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_status_text(@this));
        }
    }

    internal class CfxResponseSetStatusTextRemoteCall : RemoteCall {

        internal CfxResponseSetStatusTextRemoteCall()
            : base(RemoteCallId.CfxResponseSetStatusTextRemoteCall) {}

        internal IntPtr @this;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            CfxApi.Response.cfx_response_set_status_text(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxResponseGetMimeTypeRemoteCall : RemoteCall {

        internal CfxResponseGetMimeTypeRemoteCall()
            : base(RemoteCallId.CfxResponseGetMimeTypeRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_mime_type(@this));
        }
    }

    internal class CfxResponseSetMimeTypeRemoteCall : RemoteCall {

        internal CfxResponseSetMimeTypeRemoteCall()
            : base(RemoteCallId.CfxResponseSetMimeTypeRemoteCall) {}

        internal IntPtr @this;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            CfxApi.Response.cfx_response_set_mime_type(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxResponseGetCharsetRemoteCall : RemoteCall {

        internal CfxResponseGetCharsetRemoteCall()
            : base(RemoteCallId.CfxResponseGetCharsetRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_charset(@this));
        }
    }

    internal class CfxResponseSetCharsetRemoteCall : RemoteCall {

        internal CfxResponseSetCharsetRemoteCall()
            : base(RemoteCallId.CfxResponseSetCharsetRemoteCall) {}

        internal IntPtr @this;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            CfxApi.Response.cfx_response_set_charset(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxResponseGetHeaderRemoteCall : RemoteCall {

        internal CfxResponseGetHeaderRemoteCall()
            : base(RemoteCallId.CfxResponseGetHeaderRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_header(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length));
            name_pinned.Obj.Free();
        }
    }

    internal class CfxResponseGetHeaderMapRemoteCall : RemoteCall {

        internal CfxResponseGetHeaderMapRemoteCall()
            : base(RemoteCallId.CfxResponseGetHeaderMapRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string[]> __retval;

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
            __retval = new System.Collections.Generic.List<string[]>();
            var list = StringFunctions.AllocCfxStringMultimap();
            CfxApi.Response.cfx_response_get_header_map(@this, list);
            StringFunctions.CfxStringMultimapCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringMultimap(list);
        }
    }

    internal class CfxResponseSetHeaderMapRemoteCall : RemoteCall {

        internal CfxResponseSetHeaderMapRemoteCall()
            : base(RemoteCallId.CfxResponseSetHeaderMapRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string[]> headerMap;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(headerMap);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out headerMap);
        }

        protected override void RemoteProcedure() {
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Response.cfx_response_set_header_map(@this, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }
    }

    internal class CfxResponseGetUrlRemoteCall : RemoteCall {

        internal CfxResponseGetUrlRemoteCall()
            : base(RemoteCallId.CfxResponseGetUrlRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Response.cfx_response_get_url(@this));
        }
    }

    internal class CfxResponseSetUrlRemoteCall : RemoteCall {

        internal CfxResponseSetUrlRemoteCall()
            : base(RemoteCallId.CfxResponseSetUrlRemoteCall) {}

        internal IntPtr @this;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            CfxApi.Response.cfx_response_set_url(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

}
