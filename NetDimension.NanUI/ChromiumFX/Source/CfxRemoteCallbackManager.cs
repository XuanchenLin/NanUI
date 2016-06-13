using System.Collections.Generic;
using System.Threading;

namespace Chromium
{

	/// <summary>
	/// Provides methods and events for managing the remote callback interface.
	/// </summary>
	public static class CfxRemoteCallbackManager {

        private static readonly object syncLock = new object();

        private static readonly Dictionary<int, int> callbackCount = new Dictionary<int, int>();
        private static readonly Dictionary<int, int> suspensionCount = new Dictionary<int, int>();

        /// <summary>
        /// Cancel the callback if this returns false.
        /// </summary>
        internal static bool IncrementCallbackCount(int processId) {
            lock(syncLock) {
                int s;
                suspensionCount.TryGetValue(processId, out s);
                //if(s > 0) Debug.Print("IncrementCallbackCount: callbacks suspended process id {0}", processId);
                if(s > 0) return false;
                int c;
                callbackCount.TryGetValue(processId, out c);
                callbackCount[processId] = c + 1;
                //Debug.Print("IncrementCallbackCount: callbackCount[{0}] = {1}", processId, c + 1);
                return true;
            }
        }

        internal static void DecrementCallbackCount(int processId) {
            lock (syncLock) {
                var c = callbackCount[processId];
                CfxDebug.Assert(c > 0);
                //Debug.Print("DecrementCallbackCount: callbackCount[{0}] = {1}", processId, c - 1);

                if(c == 1) {
                    // The main callback returned
                    callbackCount.Remove(processId);
                    suspensionCount.Remove(processId);
                    return;
                }

                callbackCount[processId] = c - 1;
                if(c == 2) {
                    // All callbacks except the main callback returned,
                    // release any threads waiting in SuspendCallbacks.
                    Monitor.PulseAll(syncLock);
                }
            }
        }


        /// <summary>
        /// Suspend all callbacks from the given process.
        /// If one or more callbacks from the given process are currently running, 
        /// this function will block and wait until the last callback returns.
        /// After calling this function, all callbacks from the given process
        /// will be cancelled and return to the render process without executing
        /// any application defined event handlers, delivering default values for
        /// return value and out parameters.
        /// 
        /// Calls to SuspendCallbacks/ResumeCallbacks can be nested. ResumeCallbacks
        /// must be called the same number of times as SuspendCallbacks in order to
        /// resume execution of callbacks from the given process.
        /// </summary>
        public static void SuspendCallbacks(int processId) {
            lock(syncLock) {
                int s;
                suspensionCount.TryGetValue(processId, out s);
                suspensionCount[processId] = s + 1;
                int c;
                callbackCount.TryGetValue(processId, out c);
                //Debug.Print("SuspendCallbacks: callbackCount[{0}] = {1}", processId, c);

                // Block until all callbacks but one return.
                // The last callback is the render process main callback and not
                // handled by the application.
                while(c > 1) {
                    Monitor.Wait(syncLock);
                    c = callbackCount[processId];
                }
            }
        }

        /// <summary>
        /// Resume all callbacks from the given process.
        /// This function returns immedeately.
        /// 
        /// Calls to SuspendCallbacks/ResumeCallbacks can be nested. ResumeCallbacks
        /// must be called at least the same number of times as SuspendCallbacks 
        /// in order to resume execution of callbacks from the given process.
        /// </summary>
        public static void ResumeCallbacks(int processId) {
            lock(syncLock) {
                int s;
                suspensionCount.TryGetValue(processId, out s);
                if(s > 0) {
                    suspensionCount[processId] = s - 1;
                }
            }
        }
    }
}
