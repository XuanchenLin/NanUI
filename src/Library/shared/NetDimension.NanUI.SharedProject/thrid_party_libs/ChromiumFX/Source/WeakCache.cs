// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chromium {

    internal class WeakCache {

        private readonly ConcurrentDictionary<IntPtr, WeakReference> cache = new ConcurrentDictionary<IntPtr, WeakReference>();
        private readonly object synclock = new object();

        internal WeakCache() {
            CfxRuntime.OnCfxShutdown += this.OnShutdown;
        }

        internal void Add(IntPtr key, object obj) {
            cache[key] = new WeakReference(obj, false);
        }

        internal object GetOrAdd(IntPtr key, Func<object> ctor) {

            // ConcurrentDictionary.GetOrAdd is not atomic, 
            // so we have to implement atomic behaviour

            WeakReference weakRef;

            if(cache.TryGetValue(key, out weakRef)) {
                var obj = weakRef.Target;
                if(obj != null) return obj;
            }

            lock(synclock) {
                // more than one thread might reach this so
                // check first if another thread already created the object
                if(cache.TryGetValue(key, out weakRef)) {
                    var obj = weakRef.Target;
                    if(obj != null) return obj;
                }
                var newObj = ctor();
                weakRef = new WeakReference(newObj, false);
                cache[key] = weakRef;
                return newObj;
            }
        }

        internal void Remove(IntPtr key) {
            WeakReference weakRef;
            cache.TryRemove(key, out weakRef);
        }

        private void OnShutdown() {
            lock(synclock) {
                // cannot use foreach on cache because obj.Dispose() will cause Remove()
                // to be called modifying the collection
                WeakReference[] refs = new WeakReference[cache.Count];
                cache.Values.CopyTo(refs, 0);
                foreach(WeakReference r in refs) {
                    var obj = r.Target;
                    if(obj != null && obj is CfxBaseRefCounted) {
                        (obj as CfxBaseRefCounted).Dispose();
                    }
                }
            }
        }
    }
}
