// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;

public class HttpGetMethodAttribute : HttpMethodAttribute
{
    public HttpGetMethodAttribute(string? path = null) : base(ResourceRequestMethod.GET, path)
    {

    }
}

