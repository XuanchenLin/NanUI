using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Window
{
    public enum DefMessages
    {
        /// <summary>
        /// 拖动CEF指定的APP可拖动范围
        /// </summary>
        WM_DRAG_APP_REGION = WindowsMessages.WM_USER + 1000,
        /// <summary>
        /// 可拖动范围左键双击
        /// </summary>
        WM_BROWSER_MOUSE_MOVE = WindowsMessages.WM_USER + 1001,
        /// <summary>
        /// 可拖动范围右键单击
        /// </summary>
        WM_BROWSER_MOUSE_LBUTTON_DOWN = WindowsMessages.WM_USER + 1002
    }
}
