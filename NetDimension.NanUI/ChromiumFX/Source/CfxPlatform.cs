// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

namespace Chromium {
    /// <summary>
    /// Operating systems supported by CEF.
    /// </summary>
    public enum CfxPlatformOS {
        /// <summary>
        /// Windows (see CEF documentation for supported versions).
        /// </summary>
        Windows = 0,
        /// <summary>
        /// Linux. Not yet supported by ChromiumFX.
        /// </summary>
        Linux,
        /// <summary>
        /// MacOSX. Not yet supported by ChromiumFX.
        /// </summary>
        MacOSX
    }

    /// <summary>
    /// Supported architectures.
    /// </summary>
    public enum CfxPlatformArch {
        /// <summary>
        /// The x86 architecture (32-bit).
        /// </summary>
        x86,
        /// <summary>
        /// The x64 architecture (64-bit).
        /// </summary>
        x64
    }
}
