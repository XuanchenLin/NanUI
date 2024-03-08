// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WinFormium.WebResource;

namespace MinimalWinFormiumApp;

[RoutePath("/config")]
public class TestService : DataResourceService
{
    public TestService()
    {
    }

    [HttpGetMethod("hi")]
    public IResourceResult TestMethod()
    {
        return Text("OK");
    }
}
