// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Threading;

namespace Chromium.Remote {
    internal abstract class RemoteCall {

        private readonly RemoteCallId callId;
        internal readonly bool returnImmediately;

        internal RemoteCall nextCall;

        internal int localThreadId;
        private int remoteThreadId;

        internal RemoteCall(RemoteCallId callId) {
            this.callId = callId;
            this.returnImmediately = false;
        }

        internal RemoteCall(RemoteCallId callId, bool returnImmediately) {
            this.callId = callId;
            this.returnImmediately = returnImmediately;
        }


        internal void RequestExecution() {
            // in a render process, call on the render process' connection
            // in the browser process, try to get a connection from 
            // remote context (will throw CfxException if no context exists)
            if(RemoteClient.connection != null)
                RequestExecution(RemoteClient.connection);
            else
                RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
        }

        internal void RequestExecution(RemoteConnection connection) {

            if(returnImmediately) {
                connection.Write(WriteRequest);
                return;
            }

            if(CfxRemoteCallContext.IsInContext && CfxRemoteCallContext.CurrentContext.connection != connection) {
                // The thread is in a remote call context, but the requestor wants to call
                // on another connection. This can happen if a CfrObject method from one connection
                // is used within the scope of a callback from another connection.
                // In this case, the call has to be made in a temporary context with remote thread id zero.
                var ctx = new CfxRemoteCallContext(connection, 0);
                ctx.Enter();
                try {
                    RequestExecution(connection);
                } finally {
                    ctx.Exit();
                }
                return;
            }

            localThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            remoteThreadId = CfxRemoteCallContext.currentThreadId;

            connection.SendRequestAndWait(this);

            if(connection.connectionLostException != null) {
                if(RemoteClient.connection != null) {
                    // this is the render process calling back into the browser process
                    // reaching this point usually means the browser process crashed or was killed
                    // don't throw, just return so the process can exit gracefully
                    return;
                }
                // throw exception in the browser process
                throw new CfxRemotingException("Remote connection lost.", connection.connectionLostException);
            }
        }

        internal void WriteRequest(StreamHandler h) {
            h.Write((ushort)callId);
            if(!returnImmediately) {
                h.Write(localThreadId);
                h.Write(remoteThreadId);
            }
            WriteArgs(h);
        }

        internal void ReadRequest(StreamHandler h) {
            Debug.Assert(localThreadId == 0);
            // RemoteConnection reads callId before calling this
            if(!returnImmediately) {
                h.Read(out remoteThreadId);
                h.Read(out localThreadId);
            }
            ReadArgs(h);
        }

        internal void WriteResponse(StreamHandler h) {
            h.Write(ushort.MaxValue);
            h.Write(remoteThreadId);
            WriteReturn(h);
        }

        internal void ReadResponse(StreamHandler h) {
            // RemoteConnection reads callId and threadId before calling this
            ReadReturn(h);
        }

        /// <summary>
        /// Prepares and executes the remote procedure in the remote process
        /// </summary>
        internal void Execute(RemoteConnection connection) {

            if(returnImmediately) {
                RemoteProcedure();
                return;
            }

            if(RemoteClient.connection == null) {
                if(!CfxRemoteCallbackManager.IncrementCallbackCount(connection.remoteProcessId)) {
                    // The application has suspended remote callbacks.
                    // Return without ececuting event handlers, connection will return default values.
                    return;
                }
            }

            var threadContext = new CfxRemoteCallContext(connection, remoteThreadId);
            threadContext.Enter();
            var threadStackCount = CfxRemoteCallContext.ContextStackCount;

            try {
                RemoteProcedure();
            } finally {
                if(RemoteClient.connection == null) {
                    CfxRemoteCallbackManager.DecrementCallbackCount(connection.remoteProcessId);
                }
                if(threadStackCount != CfxRemoteCallContext.ContextStackCount || CfxRemoteCallContext.CurrentContext != threadContext) {
                    CfxRemoteCallContext.resetStack(threadStackCount - 1);
                    throw new CfxException("Unbalanced remote call context stack. Make sure to balance calls to CfxRemoteCallContext.Enter() and CfxRemoteCallContext.Exit() in all render process callback events.");
                }
                threadContext.Exit();
            }
        }

        protected virtual void WriteArgs(StreamHandler h) { }
        protected virtual void ReadArgs(StreamHandler h) { }

        protected virtual void WriteReturn(StreamHandler h) { }
        protected virtual void ReadReturn(StreamHandler h) { }

        protected abstract void RemoteProcedure();

    }
}
