// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
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
    public class CfxWaitableEvent : CfxBaseLibrary {

        internal static CfxWaitableEvent Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxWaitableEvent)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxWaitableEvent(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxWaitableEvent(IntPtr nativePtr) : base(nativePtr) {}

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
        public static CfxWaitableEvent Create(bool automaticReset, bool initiallySignaled) {
            return CfxWaitableEvent.Wrap(CfxApi.WaitableEvent.cfx_waitable_event_create(automaticReset ? 1 : 0, initiallySignaled ? 1 : 0));
        }

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
                return 0 != CfxApi.WaitableEvent.cfx_waitable_event_is_signaled(NativePtr);
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
            CfxApi.WaitableEvent.cfx_waitable_event_reset(NativePtr);
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
            CfxApi.WaitableEvent.cfx_waitable_event_signal(NativePtr);
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
            CfxApi.WaitableEvent.cfx_waitable_event_wait(NativePtr);
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
            return 0 != CfxApi.WaitableEvent.cfx_waitable_event_timed_wait(NativePtr, maxMs);
        }
    }
}
