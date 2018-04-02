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
using System.IO.Pipes;

namespace Chromium.Remote {
    internal class RemoteConnection {

        private static PipeStream CreateServerInputStream(string name) {
            return new NamedPipeServerStream(name, PipeDirection.In, 1);
        }

        private static PipeStream CreateServerOutputStream(string name) {
            return new NamedPipeServerStream(name, PipeDirection.Out, 1);
        }

        private static PipeStream CreateClientInputStream(string name) {
            return new NamedPipeClientStream(".", name, PipeDirection.In);
        }

        private static PipeStream CreateClientOutputStream(string name) {
            return new NamedPipeClientStream(".", name, PipeDirection.Out);
        }

        internal static void Connect(PipeStream pipe) {
            if(pipe is NamedPipeServerStream)
                (pipe as NamedPipeServerStream).WaitForConnection();
            else
                (pipe as NamedPipeClientStream).Connect();
        }

        private readonly PipeStream pipeIn;
        private readonly PipeStream pipeOut;
        private readonly StreamHandler streamHandler;

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

        internal readonly WeakCache weakCache = new WeakCache();

        internal RemoteConnection(string pipeName, bool isClient) {

            this.isClient = isClient;

            if(isClient) {
                pipeIn = CreateClientInputStream(pipeName + "so");
                pipeOut = CreateClientOutputStream(pipeName + "si");
            } else {
                pipeIn = CreateServerInputStream(pipeName + "si");
                pipeOut = CreateServerOutputStream(pipeName + "so");
            }

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

        internal unsafe void Write(Action<StreamHandler> callback) {
            Monitor.Enter(writeSyncRoot);
            try {
                fixed (byte* buf = &streamHandler.writeBuffer[0]) {
                    streamHandler.fixedWriteBuffer = buf;
                    if(!connected) {
                        Connect(pipeOut);
                        streamHandler.Write(localProcessId);
                        streamHandler.Flush();
                        connected = true;
                    }
                    callback.Invoke(streamHandler);
                    streamHandler.Flush();
                    streamHandler.fixedWriteBuffer = null;
                }
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
                newCalls.Add(rc);
                if(ShuttingDown || connectionLostException != null) return;
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

        private unsafe void ReadLoopEntry() {
            try {
                Connect(pipeIn);
                int pid;
                fixed (byte* buf = &streamHandler.readBuffer[0]) {
                    streamHandler.fixedReadBuffer = buf;
                    streamHandler.Read(out pid);
                    streamHandler.fixedReadBuffer = null;
                }
                remoteProcessId = pid;
                ReadLoop();
            } catch(EndOfStreamException ex) {
                OnConnectionLost(ex);
            } catch(IOException ex) {
                OnConnectionLost(ex);
            } catch(ObjectDisposedException ex) {
                OnConnectionLost(ex);
            }
        }

        private unsafe void ReadLoop() {
            for(;;) {
                streamHandler.FillReadBuffer(sizeof(ushort));
                fixed (byte* buf = &streamHandler.readBuffer[0]) {
                    streamHandler.fixedReadBuffer = buf;
                    ushort callId;
                    streamHandler.Read(out callId);
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
                        int threadId;
                        streamHandler.Read(out threadId);
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
                    streamHandler.fixedReadBuffer = null;
                }
            }
        }

        private void OnConnectionLost(Exception ex) {
            if(!ShuttingDown)
                connectionLostException = ex;
            RemoteCall c;
            while(newCalls.TryTake(out c)) {
                lock(c) {
                    Monitor.PulseAll(c);
                }
            }
            foreach(var s in threadCallStack.Values) {
                if(s.Count > 0) {
                    c = s.Peek();
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
