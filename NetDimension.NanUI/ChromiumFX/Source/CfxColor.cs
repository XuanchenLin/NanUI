// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.




namespace Chromium
{

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
