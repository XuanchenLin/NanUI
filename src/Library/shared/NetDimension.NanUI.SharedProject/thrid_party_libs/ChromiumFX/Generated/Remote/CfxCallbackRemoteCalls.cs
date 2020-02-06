// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxCallbackContinueRemoteCall : RemoteCall {

        internal CfxCallbackContinueRemoteCall()
            : base(RemoteCallId.CfxCallbackContinueRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Callback.cfx_callback_cont(@this);
        }
    }

    internal class CfxCallbackCancelRemoteCall : RemoteCall {

        internal CfxCallbackCancelRemoteCall()
            : base(RemoteCallId.CfxCallbackCancelRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Callback.cfx_callback_cancel(@this);
        }
    }

}
