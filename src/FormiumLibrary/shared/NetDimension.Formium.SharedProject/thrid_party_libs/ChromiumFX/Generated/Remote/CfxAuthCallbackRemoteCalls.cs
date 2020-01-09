// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxAuthCallbackContinueRemoteCall : RemoteCall {

        internal CfxAuthCallbackContinueRemoteCall()
            : base(RemoteCallId.CfxAuthCallbackContinueRemoteCall) {}

        internal IntPtr @this;
        internal string userName;
        internal string password;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(userName);
            h.Write(password);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out userName);
            h.Read(out password);
        }

        protected override void RemoteProcedure() {
            var userName_pinned = new PinnedString(userName);
            var password_pinned = new PinnedString(password);
            CfxApi.AuthCallback.cfx_auth_callback_cont(@this, userName_pinned.Obj.PinnedPtr, userName_pinned.Length, password_pinned.Obj.PinnedPtr, password_pinned.Length);
            userName_pinned.Obj.Free();
            password_pinned.Obj.Free();
        }
    }

    internal class CfxAuthCallbackCancelRemoteCall : RemoteCall {

        internal CfxAuthCallbackCancelRemoteCall()
            : base(RemoteCallId.CfxAuthCallbackCancelRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.AuthCallback.cfx_auth_callback_cancel(@this);
        }
    }

}
