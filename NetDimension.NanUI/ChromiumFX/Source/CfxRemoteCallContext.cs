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


using Chromium.Remote;
using System;
using System.Collections.Generic;

namespace Chromium
{

	/// <summary>
	/// Enables access to static members and constructors of remote (Cfr*) classes.
	/// In the scope of a remote callback event, the executing thread is always in 
	/// the context of the calling thread in the render process.
	/// </summary>
	public class CfxRemoteCallContext {

        internal static int currentThreadId {
            get {
                if(IsInContext)
                    return CurrentContext.ThreadId;
                else
                    return 0;
            }
        }

        /// <summary>
        /// The process id of the remote process.
        /// </summary>
        public int ProcessId {
            get {
                return connection.remoteProcessId;
            }
        }

        /// <summary>
        /// Within the scope of a render process callback, the managed thread id of the 
        /// calling thread in the render process. Zero if the context is not 
        /// in the scope of a render process callback.
        /// </summary>
        public int ThreadId { get; private set; }

        internal RemoteConnection connection { get; private set; }

        internal CfxRemoteCallContext(RemoteConnection connection, int threadId) {
            this.connection = connection;
            ThreadId = threadId;
        }


        [ThreadStatic]
        private static Stack<CfxRemoteCallContext> contextStack;

        /// <summary>
        /// Enter the context of a remote thread. Calls to Enter()/Exit() 
        /// must be balanced. Use try/finally constructs to make sure that 
        /// Exit() is called the same number of times as Enter().
        /// </summary>
        public void Enter() {
            if(contextStack == null) contextStack = new Stack<CfxRemoteCallContext>();
            contextStack.Push(this);
        }

        /// <summary>
        /// Exit the context of a remote thread. Throws an exception if the 
        /// calling thread is not currently in this remote thread context.
        /// </summary>
        public void Exit() {
            if(contextStack == null || contextStack.Count == 0 || this != contextStack.Peek())
                throw new CfxException("The calling thread is not currently in this remote call context");
            contextStack.Pop();
        }

        /// <summary>
        /// Returns the current context for the calling thread. Throws an exception if the 
        /// calling thread is not currently in a remote call context.
        /// </summary>
        public static CfxRemoteCallContext CurrentContext {
            get {
                if(contextStack != null && contextStack.Count > 0)
                    return contextStack.Peek();
                else
                    throw new CfxException("The calling thread is not currently in a remote call context");
            }
        }

        /// <summary>
        /// True if the calling thread is currently in a remote call context, false otherwise.
        /// </summary>
        public static bool IsInContext {
            get {
                return contextStack != null && contextStack.Count > 0;
            }
        }

        internal static int ContextStackCount {
            get {
                return contextStack == null ? 0 : contextStack.Count;
            }
        }

        internal static void resetStack(int count) {
            if(contextStack == null) return;
            while(contextStack.Count > count)
                contextStack.Pop();
        }
    }
}
