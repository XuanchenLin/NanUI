// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {
        
        /// <summary>
        /// 32-bit ARGB color value, not premultiplied. The color components are always
        /// in a known order. Equivalent to the SkColor type.
        /// </summary>
    public struct CfxColor {

        internal static CfxColor Wrap(uint value) {
            return new CfxColor(value);
        }

        internal static uint Unwrap(CfxColor value) {
            return value.color;
        }


        internal uint color;

        /// <summary>
        /// Return an CfxColor with the specified value.
        /// A is the highest byte, b is the lowest.
        /// </summary>
        public CfxColor(uint argb) {
            this.color = argb;
        }

        /// <summary>
        /// Return an CfxColor with the specified byte component values.
        /// </summary>
        public CfxColor(byte a, byte r, byte g, byte b) {
            this.color = (uint)((a << 24) | (r << 16) | (g << 8) | b);
        }

        /// <summary>
        /// Get the ARGB value of this CfxColor.
        /// A is the highest byte, b is the lowest.
        /// </summary>
        public uint Argb { get { return color; } }

        /// <summary>
        /// Get the A value of this CfxColor.
        /// </summary>
        public byte A { get { return (byte)((color >> 24) & 0xFF); } }

        /// <summary>
        /// Get the R value of this CfxColor.
        /// </summary>
        public byte R { get { return (byte)((color >> 16) & 0xFF); } }

        /// <summary>
        /// Get the G value of this CfxColor.
        /// </summary>
        public byte G { get { return (byte)((color >> 8) & 0xFF); } }

        /// <summary>
        /// Get the B value of this CfxColor.
        /// </summary>
        public byte B { get { return (byte)(color & 0xFF); } }

    }
}
