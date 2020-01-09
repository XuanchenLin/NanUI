// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
namespace Chromium {
    /// <summary>
    /// Class for ChromiumFX related exceptions.
    /// </summary>
    public class CfxException : Exception {
        internal CfxException() : base() { }
        internal CfxException(string message) : base(message) { }
        internal CfxException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// The exception that is thrown when an error in the remote layer occurs.
    /// </summary>
    public class CfxRemotingException : CfxException {
        internal CfxRemotingException() : base() { }
        internal CfxRemotingException(string message) : base(message) { }
        internal CfxRemotingException(string message, Exception inner) : base(message, inner) { }
    }
}

