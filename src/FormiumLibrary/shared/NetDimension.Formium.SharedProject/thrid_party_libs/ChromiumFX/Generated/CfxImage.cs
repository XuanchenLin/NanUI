// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Container for a single image represented at different scale factors. All
    /// image representations should be the same size in density independent pixel
    /// (DIP) units. For example, if the image at scale factor 1.0 is 100x100 pixels
    /// then the image at scale factor 2.0 should be 200x200 pixels -- both images
    /// will display with a DIP size of 100x100 units. The functions of this
    /// structure must be called on the browser process UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
    /// </remarks>
    public class CfxImage : CfxBaseLibrary {

        internal static CfxImage Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxImage)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxImage(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxImage(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxImage. It will initially be NULL. Use the Add*() functions
        /// to add representations at different scale factors.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public static CfxImage Create() {
            return CfxImage.Wrap(CfxApi.Image.cfx_image_create());
        }

        /// <summary>
        /// Returns true (1) if this Image is NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool IsEmpty {
            get {
                return 0 != CfxApi.Image.cfx_image_is_empty(NativePtr);
            }
        }

        /// <summary>
        /// Returns the image width in density independent pixel (DIP) units.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public ulong Width {
            get {
                return (ulong)CfxApi.Image.cfx_image_get_width(NativePtr);
            }
        }

        /// <summary>
        /// Returns the image height in density independent pixel (DIP) units.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public ulong Height {
            get {
                return (ulong)CfxApi.Image.cfx_image_get_height(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this Image and |that| Image share the same underlying
        /// storage. Will also return true (1) if both images are NULL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxImage that) {
            return 0 != CfxApi.Image.cfx_image_is_same(NativePtr, CfxImage.Unwrap(that));
        }

        /// <summary>
        /// Add a bitmap image representation for |scaleFactor|. Only 32-bit RGBA/BGRA
        /// formats are supported. |pixelWidth| and |pixelHeight| are the bitmap
        /// representation size in pixel coordinates. |pixelData| is the array of
        /// pixel data and should be |pixelWidth| x |pixelHeight| x 4 bytes in size.
        /// |colorType| and |alphaType| values specify the pixel format.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool AddBitmap(float scaleFactor, int pixelWidth, int pixelHeight, CfxColorType colorType, CfxAlphaType alphaType, IntPtr pixelData, ulong pixelDataSize) {
            return 0 != CfxApi.Image.cfx_image_add_bitmap(NativePtr, scaleFactor, pixelWidth, pixelHeight, (int)colorType, (int)alphaType, pixelData, (UIntPtr)pixelDataSize);
        }

        /// <summary>
        /// Add a PNG image representation for |scaleFactor|. |pngData| is the image
        /// data of size |pngDataSize|. Any alpha transparency in the PNG data will
        /// be maintained.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool AddPng(float scaleFactor, IntPtr pngData, ulong pngDataSize) {
            return 0 != CfxApi.Image.cfx_image_add_png(NativePtr, scaleFactor, pngData, (UIntPtr)pngDataSize);
        }

        /// <summary>
        /// Create a JPEG image representation for |scaleFactor|. |jpegData| is the
        /// image data of size |jpegDataSize|. The JPEG format does not support
        /// transparency so the alpha byte will be set to 0xFF for all pixels.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool AddJpeg(float scaleFactor, IntPtr jpegData, ulong jpegDataSize) {
            return 0 != CfxApi.Image.cfx_image_add_jpeg(NativePtr, scaleFactor, jpegData, (UIntPtr)jpegDataSize);
        }

        /// <summary>
        /// Returns true (1) if this image contains a representation for
        /// |scaleFactor|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool HasRepresentation(float scaleFactor) {
            return 0 != CfxApi.Image.cfx_image_has_representation(NativePtr, scaleFactor);
        }

        /// <summary>
        /// Removes the representation for |scaleFactor|. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool RemoveRepresentation(float scaleFactor) {
            return 0 != CfxApi.Image.cfx_image_remove_representation(NativePtr, scaleFactor);
        }

        /// <summary>
        /// Returns information for the representation that most closely matches
        /// |scaleFactor|. |actualScaleFactor| is the actual scale factor for the
        /// representation. |pixelWidth| and |pixelHeight| are the representation
        /// size in pixel coordinates. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public bool GetRepresentationInfo(float scaleFactor, out float actualScaleFactor, out int pixelWidth, out int pixelHeight) {
            return 0 != CfxApi.Image.cfx_image_get_representation_info(NativePtr, scaleFactor, out actualScaleFactor, out pixelWidth, out pixelHeight);
        }

        /// <summary>
        /// Returns the bitmap representation that most closely matches |scaleFactor|.
        /// Only 32-bit RGBA/BGRA formats are supported. |colorType| and |alphaType|
        /// values specify the desired output pixel format. |pixelWidth| and
        /// |pixelHeight| are the output representation size in pixel coordinates.
        /// Returns a CfxBinaryValue containing the pixel data on success or NULL
        /// on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue GetAsBitmap(float scaleFactor, CfxColorType colorType, CfxAlphaType alphaType, out int pixelWidth, out int pixelHeight) {
            return CfxBinaryValue.Wrap(CfxApi.Image.cfx_image_get_as_bitmap(NativePtr, scaleFactor, (int)colorType, (int)alphaType, out pixelWidth, out pixelHeight));
        }

        /// <summary>
        /// Returns the PNG representation that most closely matches |scaleFactor|. If
        /// |withTransparency| is true (1) any alpha transparency in the image will be
        /// represented in the resulting PNG data. |pixelWidth| and |pixelHeight| are
        /// the output representation size in pixel coordinates. Returns a
        /// CfxBinaryValue containing the PNG image data on success or NULL on
        /// failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue GetAsPng(float scaleFactor, bool withTransparency, out int pixelWidth, out int pixelHeight) {
            return CfxBinaryValue.Wrap(CfxApi.Image.cfx_image_get_as_png(NativePtr, scaleFactor, withTransparency ? 1 : 0, out pixelWidth, out pixelHeight));
        }

        /// <summary>
        /// Returns the JPEG representation that most closely matches |scaleFactor|.
        /// |quality| determines the compression level with 0 == lowest and 100 ==
        /// highest. The JPEG format does not support alpha transparency and the alpha
        /// channel, if any, will be discarded. |pixelWidth| and |pixelHeight| are
        /// the output representation size in pixel coordinates. Returns a
        /// CfxBinaryValue containing the JPEG image data on success or NULL on
        /// failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_image_capi.h">cef/include/capi/cef_image_capi.h</see>.
        /// </remarks>
        public CfxBinaryValue GetAsJpeg(float scaleFactor, int quality, out int pixelWidth, out int pixelHeight) {
            return CfxBinaryValue.Wrap(CfxApi.Image.cfx_image_get_as_jpeg(NativePtr, scaleFactor, quality, out pixelWidth, out pixelHeight));
        }
    }
}
