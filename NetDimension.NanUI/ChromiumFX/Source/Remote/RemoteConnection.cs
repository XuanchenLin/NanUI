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



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Chromium.Remote
{
	internal class RemoteConnection {


        private readonly Stream pipeIn;
        private readonly Stream pipeOut;
        internal readonly StreamHandler streamHandler;

        internal int localProcessId { get; private set; }
        internal int remoteProcessId { get; private set; }

        private readonly bool isClient;

        private readonly Queue<Action<StreamHandler>> writeQueue = new Queue<Action<StreamHandler>>();

        private readonly Thread writer;
        private readonly Thread reader;

        private readonly object syncRoot = new object();

        internal bool ShuttingDown { get; private set; }
        internal Exception connectionLostException { get; private set; }

        internal readonly RemoteCallStack callStack;

        internal readonly RemoteWeakCache weakCache = new RemoteWeakCache();


        internal RemoteConnection(Stream pipeIn, Stream pipeOut, bool isClient) {

            this.pipeIn = pipeIn;
            this.pipeOut = pipeOut;
            this.isClient = isClient;

            localProcessId = Process.GetCurrentProcess().Id;
            callStack = new RemoteCallStack();

            streamHandler = new StreamHandler(pipeIn, pipeOut);

            if(!isClient) {
                CfxRuntime.OnCfxShutdown += new Action(CfxRuntime_OnCfxShutdown);
            }

            writer = new Thread(WriteLoopEntry);
            reader = new Thread(ReadLoopEntry);

            writer.Name = "cfx_rpc_writer";
            reader.Name = "cfx_rpc_reader";

            writer.IsBackground = true;
            reader.IsBackground = true;

            writer.Start();
            reader.Start();
        }

        void CfxRuntime_OnCfxShutdown() {
            ShuttingDown = true;
            callStack.ReleaseAll();
            // The connection may have already been removed
            // in OnConnectionLost
            if(RemoteService.connections.Contains(this))
                RemoteService.connections.Remove(this);
        }

        internal void EnqueueWrite(Action<StreamHandler> callback) {
            lock(syncRoot) {
                if(writeQueue.Count == 0)
                    Monitor.PulseAll(syncRoot);
                writeQueue.Enqueue(callback);
            }
        }

        internal void WriteLoopEntry() {
            try {
                Connect(pipeOut);
                streamHandler.Write(localProcessId);
                streamHandler.Flush();
                WriteLoop();
            } catch(EndOfStreamException ex) {
                OnConnectionLost(ex);
            } catch(IOException ex) {
                OnConnectionLost(ex);
            }
        }

        internal void ReadLoopEntry() {
            try {
                Connect(pipeIn);
                remoteProcessId = streamHandler.ReadInt32();
                ReadLoop();
            } catch(EndOfStreamException ex) {
                OnConnectionLost(ex);
            } catch(IOException ex) {
                OnConnectionLost(ex);
            }
        }

        private void Connect(Stream stream) {
            if(isClient) {
                PipeFactory.Instance.Connect(stream);
            } else {
                PipeFactory.Instance.WaitForConnection(stream);
            }
        }

        private void WriteLoop() {
            for(; ; ) {
                Action<StreamHandler> writeCallback = null;
                lock(syncRoot) {
                    if(writeQueue.Count == 0) {
                        Monitor.Wait(syncRoot);
                        if(writeQueue.Count == 0)
                            return;
                    }
                    writeCallback = writeQueue.Dequeue();
                }
                writeCallback.Invoke(streamHandler);
            }
        }

        private void ReadLoop() {
            for(; ; ) {
                var callId = streamHandler.ReadUInt16();
                if(callId == ushort.MaxValue) {
                    var threadId = streamHandler.ReadInt32();
                    var call = callStack.Pop(threadId);
                    call.ReadResponse(streamHandler);
                } else {
                    var call = RemoteCallFactory.ForCallId((RemoteCallId)callId);
                    call.ReadRequest(this);
                }
            }
        }


        private void OnConnectionLost(Exception ex) {
            // When a connection is lost, both the 
            // reader and the writer thread can
            // reach this code under some
            // conditions.
            lock(syncRoot) {
                if(connectionLostException != null)
                    return;
                connectionLostException = ex;
                callStack.ReleaseAll();
                if(!isClient) {
                    // The connection may have already been removed
                    // in CfxRuntime_OnCfxShutdown
                    if(RemoteService.connections.Contains(this))
                        RemoteService.connections.Remove(this);
                }
            }
        }
    }
}
