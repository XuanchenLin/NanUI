// Copyright (c) 2014-2019 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Chromium.Remote {

    public partial class CfrRuntime {

        /// <summary>
        /// Provides access to the remote process.
        /// /// A thread must be in a remote context in order to access any functions in this class.
        /// </summary>
        public static class Process {

            /// <summary>
            /// Set the priority class in the target process.
            /// Returns true on success, false otherwise.
            /// </summary>
            public static bool SetPriorityClass(ProcessPriorityClass priorityClass) {
                var call = new CfrProcessSetPriorityClassRemoteCall();
                call.priorityClass = (int)priorityClass;
                call.RequestExecution();
                return call.__retval;
            }
        }
    }

    internal class CfrProcessSetPriorityClassRemoteCall : RemoteCall {

        internal int priorityClass;
        internal bool __retval;

        internal CfrProcessSetPriorityClassRemoteCall() : base(RemoteCallId.CfrProcessSetPriorityClassRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(priorityClass);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out priorityClass);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            try {
                var p = Process.GetCurrentProcess();
                p.PriorityClass = (ProcessPriorityClass)priorityClass;
                __retval = true;
            } catch {
                __retval = false;
            }
        }
    }
}
