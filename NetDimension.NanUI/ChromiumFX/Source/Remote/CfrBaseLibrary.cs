// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium.Remote {
    /// <summary>
    /// Base class for all remote wrapper classes for CEF library structs.
    /// </summary>
    public abstract class CfrBaseLibrary : CfrBaseRefCounted {
        internal CfrBaseLibrary(RemotePtr remotePtr) : base(remotePtr) { }
    }
}
