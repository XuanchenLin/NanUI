// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxSchemeRegistrarAddCustomSchemeRemoteCall : RemoteCall {

        internal CfxSchemeRegistrarAddCustomSchemeRemoteCall()
            : base(RemoteCallId.CfxSchemeRegistrarAddCustomSchemeRemoteCall) {}

        internal IntPtr @this;
        internal string schemeName;
        internal int options;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(schemeName);
            h.Write(options);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out schemeName);
            h.Read(out options);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var schemeName_pinned = new PinnedString(schemeName);
            __retval = 0 != CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme(@this, schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, options);
            schemeName_pinned.Obj.Free();
        }
    }

}
