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

namespace Chromium
{
	internal class WeakCacheBase {

        protected readonly Dictionary<IntPtr, WeakReference> cache = new Dictionary<IntPtr, WeakReference>();

        internal object Get(IntPtr key) {
            // always locked by caller
            WeakReference r;
            if(cache.TryGetValue(key, out r)) {
                var retval = r.Target;
                if(retval == null) {
                    // Happens if the object was collected but not yet finalized.
                    // Remove the key so the subsequent call to Add won't fail.
                    cache.Remove(key);
                }
                return retval;
            } else {
                return null;
            }
        }

        internal void Remove(IntPtr key) {
            lock(this) {
                cache.Remove(key);
            }
        }
    }

    internal class WeakCache : WeakCacheBase {

        internal WeakCache() {
            CfxRuntime.OnCfxShutdown += this.OnShutdown;
        }

        internal void Add(CfxBase obj) {
            // always locked by caller
            cache.Add(obj.nativePtrUnchecked, new WeakReference(obj, false));
        }

        private void OnShutdown() {
            lock(this) {
                // cannot use foreach on cache because obj.Dispose() will cause Remove()
                // to be called modifying the collection
                WeakReference[] refs = new WeakReference[cache.Count];
                cache.Values.CopyTo(refs, 0);
                foreach(WeakReference r in refs) {
                    var obj = (CfxBase)r.Target;
                    if(obj != null) obj.Dispose();
                }
            }
        }
    }

    namespace Remote
	{
		internal class RemoteWeakCache : WeakCacheBase {
            internal void Add(IntPtr key, object obj) {
                // always locked by caller
                cache.Add(key, new WeakReference(obj, false));
            }
        }
    }
}
