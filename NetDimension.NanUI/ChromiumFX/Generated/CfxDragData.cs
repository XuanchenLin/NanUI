// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent drag data. The functions of this structure may be
    /// called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
    /// </remarks>
    public class CfxDragData : CfxBaseLibrary {

        internal static CfxDragData Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxDragData)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxDragData(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxDragData(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxDragData object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public static CfxDragData Create() {
            return CfxDragData.Wrap(CfxApi.DragData.cfx_drag_data_create());
        }

        /// <summary>
        /// Returns true (1) if this object is read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.DragData.cfx_drag_data_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the drag data is a link.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsLink {
            get {
                return 0 != CfxApi.DragData.cfx_drag_data_is_link(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the drag data is a text or html fragment.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsFragment {
            get {
                return 0 != CfxApi.DragData.cfx_drag_data_is_fragment(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the drag data is a file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool IsFile {
            get {
                return 0 != CfxApi.DragData.cfx_drag_data_is_file(NativePtr);
            }
        }

        /// <summary>
        /// Return the link URL that is being dragged.
        /// 
        /// Set the link URL that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_link_url(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_link_url(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the title associated with the link being dragged.
        /// 
        /// Set the title associated with the link being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkTitle {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_link_title(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_link_title(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the metadata, if any, associated with the link being dragged.
        /// 
        /// Set the metadata associated with the link being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string LinkMetadata {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_link_metadata(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_link_metadata(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the plain text fragment that is being dragged.
        /// 
        /// Set the plain text fragment that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_fragment_text(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_fragment_text(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the text/html fragment that is being dragged.
        /// 
        /// Set the text/html fragment that is being dragged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentHtml {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_fragment_html(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_fragment_html(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the base URL that the fragment came from. This value is used for
        /// resolving relative URLs and may be NULL.
        /// 
        /// Set the base URL that the fragment came from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FragmentBaseUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_fragment_base_url(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.DragData.cfx_drag_data_set_fragment_base_url(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Return the name of the file being dragged out of the browser window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public string FileName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DragData.cfx_drag_data_get_file_name(NativePtr));
            }
        }

        /// <summary>
        /// Get the image representation of drag data. May return NULL if no image
        /// representation is available.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public CfxImage Image {
            get {
                return CfxImage.Wrap(CfxApi.DragData.cfx_drag_data_get_image(NativePtr));
            }
        }

        /// <summary>
        /// Get the image hotspot (drag start location relative to image dimensions).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public CfxPoint ImageHotspot {
            get {
                var __retval = CfxApi.DragData.cfx_drag_data_get_image_hotspot(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxPoint.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Returns true (1) if an image representation of drag data is available.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool HasImage {
            get {
                return 0 != CfxApi.DragData.cfx_drag_data_has_image(NativePtr);
            }
        }

        /// <summary>
        /// Returns a copy of the current object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public CfxDragData Clone() {
            return CfxDragData.Wrap(CfxApi.DragData.cfx_drag_data_clone(NativePtr));
        }

        /// <summary>
        /// Write the contents of the file being dragged out of the web view into
        /// |writer|. Returns the number of bytes sent to |writer|. If |writer| is NULL
        /// this function will return the size of the file contents in bytes. Call
        /// get_file_name() to get a suggested name for the file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public ulong GetFileContents(CfxStreamWriter writer) {
            return (ulong)CfxApi.DragData.cfx_drag_data_get_file_contents(NativePtr, CfxStreamWriter.Unwrap(writer));
        }

        /// <summary>
        /// Retrieve the list of file names that are being dragged into the browser
        /// window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public bool GetFileNames(System.Collections.Generic.List<string> names) {
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            var __retval = CfxApi.DragData.cfx_drag_data_get_file_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.Runtime.cfx_string_list_free(names_unwrapped);
            return 0 != __retval;
        }

        /// <summary>
        /// Reset the file contents. You should do this before calling
        /// CfxBrowserHost.DragTargetDragEnter as the web view does not allow us
        /// to drag in this kind of data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public void ResetFileContents() {
            CfxApi.DragData.cfx_drag_data_reset_file_contents(NativePtr);
        }

        /// <summary>
        /// Add a file that is being dragged into the webview.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_drag_data_capi.h">cef/include/capi/cef_drag_data_capi.h</see>.
        /// </remarks>
        public void AddFile(string path, string displayName) {
            var path_pinned = new PinnedString(path);
            var displayName_pinned = new PinnedString(displayName);
            CfxApi.DragData.cfx_drag_data_add_file(NativePtr, path_pinned.Obj.PinnedPtr, path_pinned.Length, displayName_pinned.Obj.PinnedPtr, displayName_pinned.Length);
            path_pinned.Obj.Free();
            displayName_pinned.Obj.Free();
        }
    }
}
