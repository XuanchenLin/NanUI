// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxRequestCreateRemoteCall : RemoteCall {

        internal CfxRequestCreateRemoteCall()
            : base(RemoteCallId.CfxRequestCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Request.cfx_request_create();
        }
    }

    internal class CfxRequestIsReadOnlyRemoteCall : RemoteCall {

        internal CfxRequestIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxRequestIsReadOnlyRemoteCall) {}

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
            __retval = 0 != CfxApi.Request.cfx_request_is_read_only(@this);
        }
    }

    internal class CfxRequestGetUrlRemoteCall : RemoteCall {

        internal CfxRequestGetUrlRemoteCall()
            : base(RemoteCallId.CfxRequestGetUrlRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_url(@this));
        }
    }

    internal class CfxRequestSetUrlRemoteCall : RemoteCall {

        internal CfxRequestSetUrlRemoteCall()
            : base(RemoteCallId.CfxRequestSetUrlRemoteCall) {}

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
            CfxApi.Request.cfx_request_set_url(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxRequestGetMethodRemoteCall : RemoteCall {

        internal CfxRequestGetMethodRemoteCall()
            : base(RemoteCallId.CfxRequestGetMethodRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_method(@this));
        }
    }

    internal class CfxRequestSetMethodRemoteCall : RemoteCall {

        internal CfxRequestSetMethodRemoteCall()
            : base(RemoteCallId.CfxRequestSetMethodRemoteCall) {}

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
            CfxApi.Request.cfx_request_set_method(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxRequestSetReferrerRemoteCall : RemoteCall {

        internal CfxRequestSetReferrerRemoteCall()
            : base(RemoteCallId.CfxRequestSetReferrerRemoteCall) {}

        internal IntPtr @this;
        internal string referrerUrl;
        internal int policy;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(referrerUrl);
            h.Write(policy);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out referrerUrl);
            h.Read(out policy);
        }

        protected override void RemoteProcedure() {
            var referrerUrl_pinned = new PinnedString(referrerUrl);
            CfxApi.Request.cfx_request_set_referrer(@this, referrerUrl_pinned.Obj.PinnedPtr, referrerUrl_pinned.Length, (int)policy);
            referrerUrl_pinned.Obj.Free();
        }
    }

    internal class CfxRequestGetReferrerUrlRemoteCall : RemoteCall {

        internal CfxRequestGetReferrerUrlRemoteCall()
            : base(RemoteCallId.CfxRequestGetReferrerUrlRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_referrer_url(@this));
        }
    }

    internal class CfxRequestGetReferrerPolicyRemoteCall : RemoteCall {

        internal CfxRequestGetReferrerPolicyRemoteCall()
            : base(RemoteCallId.CfxRequestGetReferrerPolicyRemoteCall) {}

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
            __retval = CfxApi.Request.cfx_request_get_referrer_policy(@this);
        }
    }

    internal class CfxRequestGetPostDataRemoteCall : RemoteCall {

        internal CfxRequestGetPostDataRemoteCall()
            : base(RemoteCallId.CfxRequestGetPostDataRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.Request.cfx_request_get_post_data(@this);
        }
    }

    internal class CfxRequestSetPostDataRemoteCall : RemoteCall {

        internal CfxRequestSetPostDataRemoteCall()
            : base(RemoteCallId.CfxRequestSetPostDataRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            CfxApi.Request.cfx_request_set_post_data(@this, value);
        }
    }

    internal class CfxRequestGetHeaderMapRemoteCall : RemoteCall {

        internal CfxRequestGetHeaderMapRemoteCall()
            : base(RemoteCallId.CfxRequestGetHeaderMapRemoteCall) {}

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
            CfxApi.Request.cfx_request_get_header_map(@this, list);
            StringFunctions.CfxStringMultimapCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringMultimap(list);
        }
    }

    internal class CfxRequestSetHeaderMapRemoteCall : RemoteCall {

        internal CfxRequestSetHeaderMapRemoteCall()
            : base(RemoteCallId.CfxRequestSetHeaderMapRemoteCall) {}

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
            CfxApi.Request.cfx_request_set_header_map(@this, headerMap_unwrapped);
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }
    }

    internal class CfxRequestGetHeaderByNameRemoteCall : RemoteCall {

        internal CfxRequestGetHeaderByNameRemoteCall()
            : base(RemoteCallId.CfxRequestGetHeaderByNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_header_by_name(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length));
            name_pinned.Obj.Free();
        }
    }

    internal class CfxRequestSetHeaderByNameRemoteCall : RemoteCall {

        internal CfxRequestSetHeaderByNameRemoteCall()
            : base(RemoteCallId.CfxRequestSetHeaderByNameRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal string value;
        internal bool overwrite;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
            h.Write(value);
            h.Write(overwrite);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
            h.Read(out value);
            h.Read(out overwrite);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            var value_pinned = new PinnedString(value);
            CfxApi.Request.cfx_request_set_header_by_name(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length, overwrite ? 1 : 0);
            name_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }
    }

    internal class CfxRequestSetRemoteCall : RemoteCall {

        internal CfxRequestSetRemoteCall()
            : base(RemoteCallId.CfxRequestSetRemoteCall) {}

        internal IntPtr @this;
        internal string url;
        internal string method;
        internal IntPtr postData;
        internal System.Collections.Generic.List<string[]> headerMap;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(url);
            h.Write(method);
            h.Write(postData);
            h.Write(headerMap);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out url);
            h.Read(out method);
            h.Read(out postData);
            h.Read(out headerMap);
        }

        protected override void RemoteProcedure() {
            var url_pinned = new PinnedString(url);
            var method_pinned = new PinnedString(method);
            PinnedString[] headerMap_handles;
            var headerMap_unwrapped = StringFunctions.UnwrapCfxStringMultimap(headerMap, out headerMap_handles);
            CfxApi.Request.cfx_request_set(@this, url_pinned.Obj.PinnedPtr, url_pinned.Length, method_pinned.Obj.PinnedPtr, method_pinned.Length, postData, headerMap_unwrapped);
            url_pinned.Obj.Free();
            method_pinned.Obj.Free();
            StringFunctions.FreePinnedStrings(headerMap_handles);
            StringFunctions.CfxStringMultimapCopyToManaged(headerMap_unwrapped, headerMap);
            CfxApi.Runtime.cfx_string_multimap_free(headerMap_unwrapped);
        }
    }

    internal class CfxRequestGetFlagsRemoteCall : RemoteCall {

        internal CfxRequestGetFlagsRemoteCall()
            : base(RemoteCallId.CfxRequestGetFlagsRemoteCall) {}

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
            __retval = CfxApi.Request.cfx_request_get_flags(@this);
        }
    }

    internal class CfxRequestSetFlagsRemoteCall : RemoteCall {

        internal CfxRequestSetFlagsRemoteCall()
            : base(RemoteCallId.CfxRequestSetFlagsRemoteCall) {}

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
            CfxApi.Request.cfx_request_set_flags(@this, value);
        }
    }

    internal class CfxRequestGetFirstPartyForCookiesRemoteCall : RemoteCall {

        internal CfxRequestGetFirstPartyForCookiesRemoteCall()
            : base(RemoteCallId.CfxRequestGetFirstPartyForCookiesRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Request.cfx_request_get_first_party_for_cookies(@this));
        }
    }

    internal class CfxRequestSetFirstPartyForCookiesRemoteCall : RemoteCall {

        internal CfxRequestSetFirstPartyForCookiesRemoteCall()
            : base(RemoteCallId.CfxRequestSetFirstPartyForCookiesRemoteCall) {}

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
            CfxApi.Request.cfx_request_set_first_party_for_cookies(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxRequestGetResourceTypeRemoteCall : RemoteCall {

        internal CfxRequestGetResourceTypeRemoteCall()
            : base(RemoteCallId.CfxRequestGetResourceTypeRemoteCall) {}

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
            __retval = CfxApi.Request.cfx_request_get_resource_type(@this);
        }
    }

    internal class CfxRequestGetTransitionTypeRemoteCall : RemoteCall {

        internal CfxRequestGetTransitionTypeRemoteCall()
            : base(RemoteCallId.CfxRequestGetTransitionTypeRemoteCall) {}

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
            __retval = CfxApi.Request.cfx_request_get_transition_type(@this);
        }
    }

    internal class CfxRequestGetIdentifierRemoteCall : RemoteCall {

        internal CfxRequestGetIdentifierRemoteCall()
            : base(RemoteCallId.CfxRequestGetIdentifierRemoteCall) {}

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
            __retval = CfxApi.Request.cfx_request_get_identifier(@this);
        }
    }

}
