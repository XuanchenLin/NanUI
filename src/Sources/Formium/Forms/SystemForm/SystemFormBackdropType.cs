// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

public enum SystemFormBackdropType
{
    /// <summary>
    /// Don't draw any system backdrop.
    /// </summary>
    None,
    /// <summary>
    /// Draw the webpage on current device context to a normal window.
    /// </summary>
    Surface,
    /// <summary>
    /// Draw the webpage one the backdrop material effect corresponding to a transparent window.
    /// This value is supported starting with Windows 8.1 that supports WS_EX_NOREDIRECTIONBITMAP flag.
    /// </summary>
    Transparent,
    /// <summary>
    /// Draw the webpage on the backdrop material effect corresponding to a Acrylic window.
    /// This value is supported starting with Windows 10 Build 1809.
    /// </summary>
    Acrylic,
    /// <summary>
    /// Draw the webpage on the backdrop material effect corresponding to a long-lived window.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    Mica,
    /// <summary>
    /// Draw the webpage on the backdrop material effect corresponding to a transient window.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    Transient,
    /// <summary>
    /// Draw the webpage on the backdrop material effect corresponding to a window with a tabbed title bar.
    /// This value is supported starting with Windows 11 Build 22000.
    /// </summary>
    MicaAlt
}

internal enum SystemFormRenderType
{
    Hwnd,
    Offscreen,
}
