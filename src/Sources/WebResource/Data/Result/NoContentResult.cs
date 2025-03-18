// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;

public class NoContentResult : StatusCodeResult
{
    private const int DefaultStatusCode = StatusCodes.Status204NoContent;
    public NoContentResult()
        : base(DefaultStatusCode)
    {
    }
}
