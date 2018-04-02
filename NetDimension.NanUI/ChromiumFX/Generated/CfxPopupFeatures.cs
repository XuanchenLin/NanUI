// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Popup window features.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfxPopupFeatures : CfxStructure {

        internal static CfxPopupFeatures Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPopupFeatures(nativePtr);
        }

        internal static CfxPopupFeatures WrapOwned(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            return new CfxPopupFeatures(nativePtr, CfxApi.PopupFeatures.cfx_popup_features_dtor);
        }

        public CfxPopupFeatures() : base(CfxApi.PopupFeatures.cfx_popup_features_ctor, CfxApi.PopupFeatures.cfx_popup_features_dtor) {}
        internal CfxPopupFeatures(IntPtr nativePtr) : base(nativePtr) {}
        internal CfxPopupFeatures(IntPtr nativePtr, CfxApi.cfx_dtor_delegate cfx_dtor) : base(nativePtr, cfx_dtor) {}

        public int X {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_x(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_x(nativePtrUnchecked, value);
            }
        }

        public int XSet {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_xSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_xSet(nativePtrUnchecked, value);
            }
        }

        public int Y {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_y(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_y(nativePtrUnchecked, value);
            }
        }

        public int YSet {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_ySet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_ySet(nativePtrUnchecked, value);
            }
        }

        public int Width {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_width(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_width(nativePtrUnchecked, value);
            }
        }

        public int WidthSet {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_widthSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_widthSet(nativePtrUnchecked, value);
            }
        }

        public int Height {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_height(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_height(nativePtrUnchecked, value);
            }
        }

        public int HeightSet {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_heightSet(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_heightSet(nativePtrUnchecked, value);
            }
        }

        public int MenuBarVisible {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_menuBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_menuBarVisible(nativePtrUnchecked, value);
            }
        }

        public int StatusBarVisible {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_statusBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_statusBarVisible(nativePtrUnchecked, value);
            }
        }

        public int ToolBarVisible {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_toolBarVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_toolBarVisible(nativePtrUnchecked, value);
            }
        }

        public int ScrollbarsVisible {
            get {
                int value;
                CfxApi.PopupFeatures.cfx_popup_features_get_scrollbarsVisible(nativePtrUnchecked, out value);
                return value;
            }
            set {
                CfxApi.PopupFeatures.cfx_popup_features_set_scrollbarsVisible(nativePtrUnchecked, value);
            }
        }

    }
}
