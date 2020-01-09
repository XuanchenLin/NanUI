// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;

namespace Chromium {
    internal class CfxDebug {
        [Conditional("DEBUG")]
        internal static void Announce() {
            Debug.Print("Running ChromiumFX debug library.");
        }
        [Conditional("DEBUG")]
        internal static void Assert(bool condition) {
            Debug.Assert(condition);
        }
    }
}
