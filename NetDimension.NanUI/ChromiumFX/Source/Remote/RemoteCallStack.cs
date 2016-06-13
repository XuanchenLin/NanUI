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




using System.Collections.Generic;

namespace Chromium.Remote
{
	class RemoteCallStack {

        private readonly Dictionary<int, Stack<RemoteCall>> stacks = new Dictionary<int, Stack<RemoteCall>>();

        internal void Push(RemoteCall call) {
            lock(stacks) {
                Stack<RemoteCall> stack;
                if(!stacks.TryGetValue(call.localThreadId, out stack)) {
                    stack = new Stack<RemoteCall>();
                    stacks.Add(call.localThreadId, stack);
                }
                stack.Push(call);
            }
        }

        internal RemoteCall Peek(int threadId) {
            lock(stacks) {
                return stacks[threadId].Peek();
            }
        }

        internal RemoteCall Pop(int threadId) {
            lock(stacks) {
                return stacks[threadId].Pop();
            }
        }

        internal void ReleaseAll() {
            lock(stacks) {
                foreach(var stack in stacks.Values) {
                    if(stack.Count > 0) {
                        var call = stack.Peek();
                        // Lock with timeout: attempting a simple lock
                        // could hang forever in the browser process
                        // if the render process crashes or hangs.
                        bool lockTaken = false;
                        System.Threading.Monitor.TryEnter(call.waitLock, 100, ref lockTaken);
                        if(lockTaken) {
                            try {
                                System.Threading.Monitor.PulseAll(call.waitLock);
                            } finally {
                                System.Threading.Monitor.Exit(call.waitLock);
                            }
                        }
                    }
                }
            }
        }
    }
}
