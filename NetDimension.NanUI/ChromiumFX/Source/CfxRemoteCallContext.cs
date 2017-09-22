// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Chromium.Remote;

namespace Chromium {
    
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
