// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;

public class OkResult : StatusCodeResult
{
    private const int DefaultStatusCode = StatusCodes.Status200OK;

    /// <summary>
    /// Initializes a new instance of the <see cref="OkResult"/> class.
    /// </summary>
    public OkResult()
        : base(DefaultStatusCode)
    {
    }
}
