// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {
    internal class TimeFunctions {
        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
        internal static DateTime FromTimeT(ulong t) {
            return epoch.AddSeconds(t);
        }
        internal static ulong ToTimeT(DateTime t) {
            return (ulong)(t - epoch).TotalSeconds;
        }
    }
}
