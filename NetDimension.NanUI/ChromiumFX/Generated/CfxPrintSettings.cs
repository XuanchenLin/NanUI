// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure representing print settings.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
    /// </remarks>
    public class CfxPrintSettings : CfxBaseLibrary {

        internal static CfxPrintSettings Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxPrintSettings)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxPrintSettings(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxPrintSettings(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxPrintSettings object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public static CfxPrintSettings Create() {
            return CfxPrintSettings.Wrap(CfxApi.PrintSettings.cfx_print_settings_create());
        }

        /// <summary>
        /// Returns true (1) if this object is valid. Do not call any other functions
        /// if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.PrintSettings.cfx_print_settings_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the values of this object are read-only. Some APIs may
        /// expose read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.PrintSettings.cfx_print_settings_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the orientation is landscape.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public bool IsLandscape {
            get {
                return 0 != CfxApi.PrintSettings.cfx_print_settings_is_landscape(NativePtr);
            }
        }

        /// <summary>
        /// Get or set the device name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public string DeviceName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.PrintSettings.cfx_print_settings_get_device_name(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.PrintSettings.cfx_print_settings_set_device_name(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Get or set the DPI (dots per inch).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public int Dpi {
            get {
                return CfxApi.PrintSettings.cfx_print_settings_get_dpi(NativePtr);
            }
            set {
                CfxApi.PrintSettings.cfx_print_settings_set_dpi(NativePtr, value);
            }
        }

        /// <summary>
        /// Returns the number of page ranges that currently exist.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public ulong PageRangesCount {
            get {
                return (ulong)CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_count(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if only the selection will be printed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public bool IsSelectionOnly {
            get {
                return 0 != CfxApi.PrintSettings.cfx_print_settings_is_selection_only(NativePtr);
            }
        }

        /// <summary>
        /// Get or set the color model.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public CfxColorModel ColorModel {
            get {
                return (CfxColorModel)CfxApi.PrintSettings.cfx_print_settings_get_color_model(NativePtr);
            }
            set {
                CfxApi.PrintSettings.cfx_print_settings_set_color_model(NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Get or set the number of copies.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public int Copies {
            get {
                return CfxApi.PrintSettings.cfx_print_settings_get_copies(NativePtr);
            }
            set {
                CfxApi.PrintSettings.cfx_print_settings_set_copies(NativePtr, value);
            }
        }

        /// <summary>
        /// Get or set the duplex mode.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public CfxDuplexMode DuplexMode {
            get {
                return (CfxDuplexMode)CfxApi.PrintSettings.cfx_print_settings_get_duplex_mode(NativePtr);
            }
            set {
                CfxApi.PrintSettings.cfx_print_settings_set_duplex_mode(NativePtr, (int)value);
            }
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public CfxPrintSettings Copy() {
            return CfxPrintSettings.Wrap(CfxApi.PrintSettings.cfx_print_settings_copy(NativePtr));
        }

        /// <summary>
        /// Set the page orientation.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public void SetOrientation(bool landscape) {
            CfxApi.PrintSettings.cfx_print_settings_set_orientation(NativePtr, landscape ? 1 : 0);
        }

        /// <summary>
        /// Set the printer printable area in device units. Some platforms already
        /// provide flipped area. Set |landscapeNeedsFlip| to false (0) on those
        /// platforms to avoid double flipping.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public void SetPrinterPrintableArea(CfxSize physicalSizeDeviceUnits, CfxRect printableAreaDeviceUnits, bool landscapeNeedsFlip) {
            CfxApi.PrintSettings.cfx_print_settings_set_printer_printable_area(NativePtr, CfxSize.Unwrap(physicalSizeDeviceUnits), CfxRect.Unwrap(printableAreaDeviceUnits), landscapeNeedsFlip ? 1 : 0);
        }

        /// <summary>
        /// Set the page ranges.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public void SetPageRanges(CfxRange[] ranges) {
            UIntPtr ranges_length;
            IntPtr[] ranges_ptrs;
            if(ranges != null) {
                ranges_length = (UIntPtr)ranges.Length;
                ranges_ptrs = new IntPtr[ranges.Length];
                for(int i = 0; i < ranges.Length; ++i) {
                    ranges_ptrs[i] = CfxRange.Unwrap(ranges[i]);
                }
            } else {
                ranges_length = UIntPtr.Zero;
                ranges_ptrs = null;
            }
            PinnedObject ranges_pinned = new PinnedObject(ranges_ptrs);
            int ranges_nomem;
            CfxApi.PrintSettings.cfx_print_settings_set_page_ranges(NativePtr, ranges_length, ranges_pinned.PinnedPtr, out ranges_nomem);
            ranges_pinned.Free();
            if(ranges_nomem != 0) {
                throw new OutOfMemoryException();
            }
        }

        /// <summary>
        /// Retrieve the page ranges.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public CfxRange[] GetPageRanges() {
            var rangesCount = CfxApi.PrintSettings.cfx_print_settings_get_page_ranges_count(NativePtr);
            IntPtr[] pp = new IntPtr[(ulong)rangesCount];
            PinnedObject pp_pinned = new PinnedObject(pp);
            int ranges_nomem;
            CfxApi.PrintSettings.cfx_print_settings_get_page_ranges(NativePtr, ref rangesCount, pp_pinned.PinnedPtr, out ranges_nomem);
            pp_pinned.Free();
            if(ranges_nomem != 0) {
                throw new OutOfMemoryException();
            }
            var retval = new CfxRange[(ulong)rangesCount];
            for(ulong i = 0; i < (ulong)rangesCount; ++i) {
                retval[i] = CfxRange.WrapOwned(pp[i]);
            }
            return retval;
        }

        /// <summary>
        /// Set whether only the selection will be printed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public void SetSelectionOnly(bool selectionOnly) {
            CfxApi.PrintSettings.cfx_print_settings_set_selection_only(NativePtr, selectionOnly ? 1 : 0);
        }

        /// <summary>
        /// Set whether pages will be collated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public void SetCollate(bool collate) {
            CfxApi.PrintSettings.cfx_print_settings_set_collate(NativePtr, collate ? 1 : 0);
        }

        /// <summary>
        /// Returns true (1) if pages will be collated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_print_settings_capi.h">cef/include/capi/cef_print_settings_capi.h</see>.
        /// </remarks>
        public bool WillCollate() {
            return 0 != CfxApi.PrintSettings.cfx_print_settings_will_collate(NativePtr);
        }
    }
}
