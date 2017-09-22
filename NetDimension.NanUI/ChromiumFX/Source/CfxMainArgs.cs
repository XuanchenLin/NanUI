// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {
    internal class CfxMainArgs : CfxStructure {

        internal static CfxMainArgs ForLinux() {
            CfxMainArgsLinux mainArgsLinux = CfxMainArgsLinux.Create();
            return new CfxMainArgs(mainArgsLinux);
        }

        internal CfxMainArgsLinux mainArgsLinux;
        private CfxMainArgs(CfxMainArgsLinux mainArgsLinux) : base(mainArgsLinux.nativePtrUnchecked) {
            this.mainArgsLinux = mainArgsLinux;
        }
    }
}
