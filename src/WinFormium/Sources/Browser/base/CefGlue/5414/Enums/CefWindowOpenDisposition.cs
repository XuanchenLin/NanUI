// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// The manner in which a link click should be opened. These constants match
/// their equivalents in Chromium's window_open_disposition.h and should not be
/// renumbered.
/// </summary>
public enum CefWindowOpenDisposition
{
    Unknown = 0,

    /// <summary>
    /// Current tab. This is the default in most cases.
    /// </summary>
    CurrentTab,

    /// <summary>
    /// Indicates that only one tab with the url should exist in the same window.
    /// </summary>
    SingletonTab,

    /// <summary>
    /// Shift key + Middle mouse button or meta/ctrl key while clicking.
    /// </summary>
    NewForegroundTab,

    /// <summary>
    /// Middle mouse button or meta/ctrl key while clicking.
    /// </summary>
    NewBackgroundTab,

    /// <summary>
    /// New popup window.
    /// </summary>
    NewPopup,

    /// <summary>
    /// Shift key while clicking.
    /// </summary>
    NewWindow,

    /// <summary>
    /// Alt key while clicking.
    /// </summary>
    SaveToDisk,

    /// <summary>
    /// New off-the-record (incognito) window.
    /// </summary>
    OffTheRecord,

    /// <summary>
    /// Special case error condition from the renderer.
    /// </summary>
    IgnoreAction,

    /// <summary>
    /// Activates an existing tab containing the url, rather than navigating.
    /// This is similar to SINGLETON_TAB, but searches across all windows from
    /// the current profile and anonymity (instead of just the current one);
    /// closes the current tab on switching if the current tab was the NTP with
    /// no session history; and behaves like CURRENT_TAB instead of
    /// NEW_FOREGROUND_TAB when no existing tab is found.
    /// </summary>
    SwitchToTab,

    /// <summary>
    /// Creates a new document picture-in-picture window showing a child WebView.
    /// </summary>
    NewPictureInPicture,
}
