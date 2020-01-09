// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Chromium.Remote {
    /// <summary>
    /// Collection of global static CEF functions acessible in the render process.
    /// A thread must be in a remote context in order to access these function.
    /// </summary>
    public static partial class CfrRuntime {

        /// <summary>
        /// This function should be called from the render process startup callback
        /// provided to CfxRuntime.Initialize() in the browser process. It will
        /// call into the render process passing in the provided |application| 
        /// object and block until the render process exits. 
        /// The |application| object will receive CEF framework callbacks 
        /// from within the render process.
        /// </summary>
        public static int ExecuteProcess(CfrApp application) {
            var call = new CfxRuntimeExecuteProcessRemoteCall();
            call.application = CfrObject.Unwrap(application).ptr;
            // Looks like this almost never returns with a value
            // from the call into the render process. Probably the
            // IPC connection doesn't get a chance to send over the
            // return value from CfxRuntime.ExecuteProcess() when the
            // render process exits. So we don't throw an exception but
            // use a return value of -2 to indicate connection lost.
            try {
                call.RequestExecution();
                return call.__retval;
            } catch(CfxException) {
                return -2;
            }
        }
    }

    internal class CfxRuntimeExecuteProcessRemoteCall : RemoteCall {

        internal CfxRuntimeExecuteProcessRemoteCall()
            : base(RemoteCallId.CfxRuntimeExecuteProcessRemoteCall) { }

        internal IntPtr application;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(application);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out application);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    __retval = CfxApi.Runtime.cfx_execute_process(IntPtr.Zero, application, IntPtr.Zero);
                    return;
                case CfxPlatformOS.Linux:
                    using(var mainArgs = CfxMainArgs.ForLinux()) {
                        __retval = CfxApi.Runtime.cfx_execute_process(CfxMainArgs.Unwrap(mainArgs), application, IntPtr.Zero);
                        mainArgs.mainArgsLinux.Free();
                    }
                    return;
                default:
                    throw new CfxException("Unsupported platform.");
            }
        }
    }
}
