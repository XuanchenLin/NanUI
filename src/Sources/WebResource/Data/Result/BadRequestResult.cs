// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;

public class BadRequestResult : StatusCodeResult
{
    private const int DefaultStatusCode = StatusCodes.Status400BadRequest;

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestResult"/> class.
    /// </summary>
    public BadRequestResult()
        : base(DefaultStatusCode)
    {
    }
}
