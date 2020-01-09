// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium.Remote {

    /// <summary>
    /// Base class for all wrapper classes for scoped CEF library structs.
    /// Objects of this type will be disposed when they go out of scope. 
    /// </summary>
    public class CfrBaseScoped : CfrObject {

        internal CfrBaseScoped(RemotePtr remotePtr) : base(remotePtr) { }

        internal override void OnDispose(RemotePtr nativePtr) {
            // do nothing
        }
    }
}
