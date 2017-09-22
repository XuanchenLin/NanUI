// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Chromium.Remote {
    internal class RemoteConnection {


        private readonly Stream pipeIn;
        private readonly Stream pipeOut;
        internal readonly StreamHandler streamHandler;

        internal int localProcessId { get; private set; }
        internal int remoteProcessId { get; private set; }

        private readonly bool isClient;
        private bool connected;

        private readonly Thread reader;

        private readonly object writeSyncRoot = new object();

        internal bool ShuttingDown { get; private set; }
        internal Exception connectionLostException { get; private set; }

        private readonly BlockingCollection<RemoteCall> newCalls = new BlockingCollection<RemoteCall>();
        private readonly Dictionary<int, Stack<RemoteCall>> threadCallStack = new Dictionary<int, Stack<RemoteCall>>();

        internal readonly RemoteWeakCache weakCache = new RemoteWeakCache();

        internal RemoteConnection(Stream pipeIn, Stream pipeOut, bool isClient) {

            this.pipeIn = pipeIn;
            this.pipeOut = pipeOut;
            this.isClient = isClient;

            localProcessId = Process.GetCurrentProcess().Id;

            streamHandler = new StreamHandler(pipeIn, pipeOut);

            if(!isClient) {
                CfxRuntime.OnCfxShutdown += new Action(CfxRuntime_OnCfxShutdown);
            }

            reader = new Thread(ReadLoopEntry);
            reader.Name = "cfx_rpc_reader";
            reader.IsBackground = true;
            reader.Start();
        }

        void CfxRuntime_OnCfxShutdown() {
            ShuttingDown = true;
            pipeIn.Close();
            pipeOut.Close();
            RemoteService.RemoveConnection(this);
        }

        internal void Write(Action<StreamHandler> callback) {
            Monitor.Enter(writeSyncRoot);
            try {
                if(!connected) {
                    Connect(pipeOut);
                    streamHandler.Write(localProcessId);
                    streamHandler.Flush();
                    connected = true;
                }
                callback.Invoke(streamHandler);
                streamHandler.Flush();
            } catch(EndOfStreamException) {
            } catch(IOException) {
            } catch(ObjectDisposedException) {
            } finally {
                Monitor.Exit(writeSyncRoot);
            }
        }


        internal void SendRequestAndWait(RemoteCall rc) {

            Debug.Assert(!rc.returnImmediately);

            lock(rc) {
                if(ShuttingDown || connectionLostException != null) return;
                newCalls.Add(rc);
                Write(rc.WriteRequest);
                Monitor.Wait(rc);
            }

            while(rc.nextCall != null) {
                var nextCall = rc.nextCall;
                rc.nextCall = null;
                nextCall.Execute(this);
                lock(rc) {
                    if(!nextCall.returnImmediately)
                        Write(nextCall.WriteResponse);
                    Monitor.Wait(rc);
                }
            }
        }

        private void ReadLoopEntry() {
            try {
                Connect(pipeIn);
                remoteProcessId = streamHandler.ReadInt32();
                ReadLoop();
            } catch(EndOfStreamException ex) {
                OnConnectionLost(ex);
            } catch(IOException ex) {
                OnConnectionLost(ex);
            } catch(ObjectDisposedException ex) {
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

        private void ReadLoop() {
            for(;;) {
                var callId = streamHandler.ReadUInt16();
                RemoteCall newCall;
                while(newCalls.TryTake(out newCall)) {
                    Stack<RemoteCall> stack;
                    if(!threadCallStack.TryGetValue(newCall.localThreadId, out stack)) {
                        stack = new Stack<RemoteCall>();
                        threadCallStack.Add(newCall.localThreadId, stack);
                    }
                    stack.Push(newCall);
                }
                if(callId == ushort.MaxValue) {
                    var threadId = streamHandler.ReadInt32();
                    var rc = threadCallStack[threadId].Pop();
                    rc.ReadResponse(streamHandler);
                    lock(rc) {
                        Monitor.PulseAll(rc);
                    }
                } else {
                    var call = RemoteCallFactory.ForCallId((RemoteCallId)callId);
                    call.ReadRequest(streamHandler);
                    if(call.localThreadId != 0) {
                        var rc = threadCallStack[call.localThreadId].Peek();
                        rc.nextCall = call;
                        lock(rc) {
                            Monitor.PulseAll(rc);
                        }
                    } else {
                        WorkerPool.EnqueueTask(() => {
                            call.Execute(this);
                            if(!call.returnImmediately)
                                Write(call.WriteResponse);
                        });
                    }
                }
            }
        }

        private void OnConnectionLost(Exception ex) {
            if(!ShuttingDown)
                connectionLostException = ex;
            foreach(var s in threadCallStack.Values) {
                if(s.Count > 0) {
                    var c = s.Peek();
                    lock(c) {
                        Monitor.PulseAll(c);
                    }
                }
            }
            if(!isClient) {
                RemoteService.RemoveConnection(this);
            }
        }
    }
}
