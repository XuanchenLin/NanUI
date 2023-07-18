//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_context_menu_media_type_t.
//
namespace Xilium.CefGlue
{
    using System;

    /// <summary>
    /// Supported context menu media types. These constants match their equivalents
    /// in Chromium's ContextMenuDataMediaType and should not be renumbered.
    /// </summary>
    public enum CefContextMenuMediaType
    {
        /// <summary>
        /// No special node is in context.
        /// </summary>
        None,

        /// <summary>
        /// An image node is selected.
        /// </summary>
        Image,

        /// <summary>
        /// A video node is selected.
        /// </summary>
        Video,

        /// <summary>
        /// An audio node is selected.
        /// </summary>
        Audio,

        /// <summary>
        /// An canvas node is selected.
        /// </summary>
        Canvas,

        /// <summary>
        /// A file node is selected.
        /// </summary>
        File,

        /// <summary>
        /// A plugin node is selected.
        /// </summary>
        Plugin,
    }
}
