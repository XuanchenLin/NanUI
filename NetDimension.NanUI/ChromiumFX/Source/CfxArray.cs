// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chromium.Remote;

namespace Chromium {
    internal class CfxArray {

        internal static T[] GetCfrObjects<T>(RemoteConnection connection, IntPtr[] remotePtrs, Func<RemotePtr, T> wrapFunction) where T : CfrObject {
            if(remotePtrs == null) return null;
            var retval = new T[remotePtrs.Length];
            for(int i = 0; i < remotePtrs.Length; ++i)
                retval[i] = wrapFunction(new RemotePtr(connection, remotePtrs[i]));
            return retval;
        }

    }
}
