// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// WaitableEvent is a thread synchronization tool that allows one thread to wait
    /// for another thread to finish some work. This is equivalent to using a
    /// Lock+ConditionVariable to protect a simple boolean value. However, using
    /// WaitableEvent in conjunction with a Lock to wait for a more complex state
    /// change (e.g., for an item to be added to a queue) is not recommended. In that
    /// case consider using a ConditionVariable instead of a WaitableEvent. It is
    /// safe to create and/or signal a WaitableEvent from any thread. Blocking on a
    /// WaitableEvent by calling the *wait() functions is not allowed on the browser
    /// process UI or IO threads.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
    /// </remarks>
    public class CfrWaitableEvent : CfrBaseLibrary {

        internal static CfrWaitableEvent Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrWaitableEvent)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrWaitableEvent(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create a new waitable event. If |automaticReset| is true (1) then the event
        /// state is automatically reset to un-signaled after a single waiting thread has
        /// been released; otherwise, the state remains signaled until reset() is called
        /// manually. If |initiallySignaled| is true (1) then the event will start in
        /// the signaled state.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public static CfrWaitableEvent Create(bool automaticReset, bool initiallySignaled) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxWaitableEventCreateRemoteCall();
            call.automaticReset = automaticReset;
            call.initiallySignaled = initiallySignaled;
            call.RequestExecution(connection);
            return CfrWaitableEvent.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrWaitableEvent(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if the event is in the signaled state, else false (0). If
        /// the event was created with |automaticReset| set to true (1) then calling
        /// this function will also cause a reset.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public bool IsSignaled {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxWaitableEventIsSignaledRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Put the event in the un-signaled state.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public void Reset() {
            var connection = RemotePtr.connection;
            var call = new CfxWaitableEventResetRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Put the event in the signaled state. This causes any thread blocked on Wait
        /// to be woken up.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public void Signal() {
            var connection = RemotePtr.connection;
            var call = new CfxWaitableEventSignalRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Wait indefinitely for the event to be signaled. This function will not
        /// return until after the call to signal() has completed. This function cannot
        /// be called on the browser process UI or IO threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public void Wait() {
            var connection = RemotePtr.connection;
            var call = new CfxWaitableEventWaitRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }

        /// <summary>
        /// Wait up to |maxMs| milliseconds for the event to be signaled. Returns true
        /// (1) if the event was signaled. A return value of false (0) does not
        /// necessarily mean that |maxMs| was exceeded. This function will not return
        /// until after the call to signal() has completed. This function cannot be
        /// called on the browser process UI or IO threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_waitable_event_capi.h">cef/include/capi/cef_waitable_event_capi.h</see>.
        /// </remarks>
        public bool TimedWait(long maxMs) {
            var connection = RemotePtr.connection;
            var call = new CfxWaitableEventTimedWaitRemoteCall();
            call.@this = RemotePtr.ptr;
            call.maxMs = maxMs;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
