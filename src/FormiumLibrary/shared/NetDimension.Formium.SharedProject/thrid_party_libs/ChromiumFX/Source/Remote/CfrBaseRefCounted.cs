// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium.Remote {
    /// <summary>
    /// Base class for all remote wrapper classes for ref counted CEF structs.
    /// </summary>
    public abstract class CfrBaseRefCounted : CfrObject {

        static internal CfrBaseRefCounted Cast(RemotePtr nativePtr) {
            throw new Exception("Implement this");
        }

        internal CfrBaseRefCounted() { }
        internal CfrBaseRefCounted(RemotePtr remotePtr) : base(remotePtr) { }

        internal override void OnDispose(RemotePtr remotePtr) {
            if (remotePtr.connection.connectionLostException != null){
                return;
            }
            var call = new CfxApiReleaseRemoteCall();
            call.nativePtr = remotePtr.ptr;
            try {
                call.RequestExecution(remotePtr.connection);
            } catch {
                // if the remote process is gone do nothing
            }
        }
    }

    internal class CfxApiReleaseRemoteCall : DtorRemoteCall {
        internal CfxApiReleaseRemoteCall() : base(RemoteCallId.CfxApiReleaseRemoteCall) { }
        protected override void RemoteProcedure() {
            CfxApi.cfx_release(nativePtr);
        }
    }
}
