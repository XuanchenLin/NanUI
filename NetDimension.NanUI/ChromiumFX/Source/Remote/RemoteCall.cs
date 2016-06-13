// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.




using System.Diagnostics;

namespace Chromium.Remote
{
	internal abstract class RemoteCall {

        private readonly RemoteCallId callId;
        private readonly bool returnImmediately;

        internal readonly object waitLock = new object();

        private RemoteCall reentryCall;

        internal int localThreadId;
        private int remoteThreadId;

        private bool responseReceived;

        internal RemoteCall(RemoteCallId callId) {
            this.callId = callId;
            this.returnImmediately = false;
        }

        internal RemoteCall(RemoteCallId callId, bool returnImmediately) {
            this.callId = callId;
            this.returnImmediately = returnImmediately;
        }


        internal void RequestExecution(CfrObject owner) {
            RequestExecution(owner.connection);
        }

        internal void RequestExecution(RemoteConnection connection) {
            
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

            if(returnImmediately) {
                if(connection.ShuttingDown)
                    return;
                else if(connection.connectionLostException != null)
                    throw new CfxRemotingException("Remote connection lost.", connection.connectionLostException);
                connection.EnqueueWrite(WriteRequest);
                return;
            }


            lock(waitLock) {

                // The lock must begin here. Otherwise,
                // there is a race between Wait and PulseAll
                // causing this thread to wait forever
                // under some circumstances.

                localThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                connection.callStack.Push(this);

                remoteThreadId = CfxRemoteCallContext.currentThreadId;

                connection.EnqueueWrite(WriteRequest);

                for(; ; ) {

                    if(responseReceived) {
                        Debug.Assert(reentryCall == null);
                        return;
                    }

                    if(this.reentryCall != null) {
                        reentryCall.ExecutionThreadEntry(connection);
                        reentryCall = null;
                    }

                    if(!connection.ShuttingDown && connection.connectionLostException == null)
                        System.Threading.Monitor.Wait(waitLock);

                    if(connection.ShuttingDown)
                        return;
                    else if(connection.connectionLostException != null) {
                        if(RemoteClient.connection != null) {
                            // this is the render process calling back into the browser process
                            // reaching this point usually means the browser process crashed or was killed
                            // don't throw, just return so the process can exit gracefully
                            return;
                        }
                        throw new CfxRemotingException("Remote connection lost.", connection.connectionLostException);
                    }
                }
            }
        }


        internal void WriteRequest(StreamHandler h) {
            h.Write((ushort)callId);
            if(!returnImmediately) {
                h.Write(localThreadId);
                h.Write(remoteThreadId);
            }
            WriteArgs(h);
            h.Flush();
        }

        internal void ReadRequest(RemoteConnection connection) {

            if(returnImmediately) {
                ReadArgs(connection.streamHandler);
                WorkerPool.EnqueueTask(() => ExecutionThreadEntry(connection));
                return;
            }

            var h = connection.streamHandler;

            h.Read(out remoteThreadId);
            h.Read(out localThreadId);
            ReadArgs(h);

            if(localThreadId != 0) {
                var call = connection.callStack.Peek(localThreadId);
                lock(call.waitLock) {
                    call.reentryCall = this;
                    System.Threading.Monitor.PulseAll(call.waitLock);
                }
            } else {
                WorkerPool.EnqueueTask(() => ExecutionThreadEntry(connection));
            }
        }

        internal void WriteResponse(StreamHandler h) {
            h.Write(ushort.MaxValue);
            h.Write(remoteThreadId);
            WriteReturn(h);
            h.Flush();
        }

        internal void ReadResponse(StreamHandler h) {
            ReadReturn(h);
            lock(waitLock) {
                responseReceived = true;
                System.Threading.Monitor.PulseAll(waitLock);
            }
        }

        private void ExecutionThreadEntry(RemoteConnection connection) {

            if(returnImmediately) {
                // only happens in calls from the browser to the renderer
                CfxDebug.Assert(connection == RemoteClient.connection);
                ExecuteInTargetProcess(connection);
                return;
            }

            if(RemoteClient.connection == null) {
                if(!CfxRemoteCallbackManager.IncrementCallbackCount(connection.remoteProcessId)) {
                    // The application has suspended remote callbacks.
                    // Write the response without ececuting event handlers, returning default values.
                    connection.EnqueueWrite(WriteResponse);
                    return;
                }
            }

            var threadContext = new CfxRemoteCallContext(connection, remoteThreadId);
            threadContext.Enter();
            var threadStackCount = CfxRemoteCallContext.ContextStackCount;

            try {
                ExecuteInTargetProcess(connection);
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

            connection.EnqueueWrite(WriteResponse);
        }

        protected virtual void WriteArgs(StreamHandler h) { }
        protected virtual void ReadArgs(StreamHandler h) { }

        protected virtual void WriteReturn(StreamHandler h) { }
        protected virtual void ReadReturn(StreamHandler h) { }

        protected abstract void ExecuteInTargetProcess(RemoteConnection connection);

    }
}
