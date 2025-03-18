// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms.OffscreenRender;
internal interface IOffscreenRender
{
    void Paint(CefPaintElementType type, nint bufferPtr, int width, int height, bool isPopupShown, CefRectangle? popupRect = null);

}
