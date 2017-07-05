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
