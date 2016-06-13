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
using System.Threading;

namespace Chromium.Remote
{
	internal static class WorkerPool {

        static readonly object syncLock = new object();
        static readonly Queue<Action> tasks = new Queue<Action>();
        static int waitingThreads;
        static int totalThreads;

        internal static void EnqueueTask(Action task) {
            lock(syncLock) {
                if(waitingThreads == 0) {
                    ++totalThreads;
                    var t = new Thread(Pool);
                    t.IsBackground = true;
                    t.Name = "cfx_rpc_worker";
                    t.Start();
                } else {
                    Monitor.Pulse(syncLock);
                }
                tasks.Enqueue(task);
            }
        }

        static void Pool() {
            for(; ; ) {
                Action task = null;
                lock(syncLock) {
                    ++waitingThreads;
                    while(tasks.Count == 0)
                        Monitor.Wait(syncLock);
                    --waitingThreads;
                    task = tasks.Dequeue();
                }
                task.Invoke();
            }
        }
    }
}
