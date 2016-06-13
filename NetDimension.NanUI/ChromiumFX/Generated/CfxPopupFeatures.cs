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

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Popup window features.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public sealed class CfxPopupFeatures : CfxStructure {

        static CfxPopupFeatures () {
            CfxApiLoader.LoadCfxPopupFeaturesApi();
        }

        internal static CfxPopupFeatures Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPopupFeatures(nativePtr);
        }

        internal static CfxPopupFeatures WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPopupFeatures(nativePtr, CfxApi.cfx_popup_features_dtor);
        }

        public CfxPopupFeatures() : base(CfxApi.cfx_popup_features_ctor, CfxApi.cfx_popup_features_dtor) {}
        internal CfxPopupFeatures(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxPopupFeatures(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int X {
            get {
                int value;
                CfxApi.cfx_popup_features_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_x(nativePtrUnchecked, value);
            }
        }

        public int XSet {
            get {
                int value;
                CfxApi.cfx_popup_features_get_xSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_xSet(nativePtrUnchecked, value);
            }
        }

        public int Y {
            get {
                int value;
                CfxApi.cfx_popup_features_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_y(nativePtrUnchecked, value);
            }
        }

        public int YSet {
            get {
                int value;
                CfxApi.cfx_popup_features_get_ySet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_ySet(nativePtrUnchecked, value);
            }
        }

        public int Width {
            get {
                int value;
                CfxApi.cfx_popup_features_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_width(nativePtrUnchecked, value);
            }
        }

        public int WidthSet {
            get {
                int value;
                CfxApi.cfx_popup_features_get_widthSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_widthSet(nativePtrUnchecked, value);
            }
        }

        public int Height {
            get {
                int value;
                CfxApi.cfx_popup_features_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_height(nativePtrUnchecked, value);
            }
        }

        public int HeightSet {
            get {
                int value;
                CfxApi.cfx_popup_features_get_heightSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_heightSet(nativePtrUnchecked, value);
            }
        }

        public int MenuBarVisible {
            get {
                int value;
                CfxApi.cfx_popup_features_get_menuBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_menuBarVisible(nativePtrUnchecked, value);
            }
        }

        public int StatusBarVisible {
            get {
                int value;
                CfxApi.cfx_popup_features_get_statusBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_statusBarVisible(nativePtrUnchecked, value);
            }
        }

        public int ToolBarVisible {
            get {
                int value;
                CfxApi.cfx_popup_features_get_toolBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_toolBarVisible(nativePtrUnchecked, value);
            }
        }

        public int LocationBarVisible {
            get {
                int value;
                CfxApi.cfx_popup_features_get_locationBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_locationBarVisible(nativePtrUnchecked, value);
            }
        }

        public int ScrollbarsVisible {
            get {
                int value;
                CfxApi.cfx_popup_features_get_scrollbarsVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_scrollbarsVisible(nativePtrUnchecked, value);
            }
        }

        public int Resizable {
            get {
                int value;
                CfxApi.cfx_popup_features_get_resizable(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_resizable(nativePtrUnchecked, value);
            }
        }

        public int Fullscreen {
            get {
                int value;
                CfxApi.cfx_popup_features_get_fullscreen(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_fullscreen(nativePtrUnchecked, value);
            }
        }

        public int Dialog {
            get {
                int value;
                CfxApi.cfx_popup_features_get_dialog(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.cfx_popup_features_set_dialog(nativePtrUnchecked, value);
            }
        }

        public System.Collections.Generic.List<string> AdditionalFeatures {
            get {
                IntPtr value;
                CfxApi.cfx_popup_features_get_additionalFeatures(nativePtrUnchecked, out value);
                return StringFunctions.WrapCfxStringList(value);
            }
            set {
                PinnedString[] value_handles;
                var value_unwrapped = StringFunctions.UnwrapCfxStringList(value, out value_handles);
                CfxApi.cfx_popup_features_set_additionalFeatures(nativePtrUnchecked, value_unwrapped);
                StringFunctions.FreePinnedStrings(value_handles);
                StringFunctions.CfxStringListCopyToManaged(value_unwrapped, value);
                CfxApi.cfx_string_list_free(value_unwrapped);
            }
        }

    }
}
