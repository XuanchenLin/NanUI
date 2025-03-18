// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;

public sealed class DataResourceContext
{
    public required ResourceRequest Request { get; init; }
    public required ResourceResponse Response { get; init; }
    public required DataResourceRoute Route { get; init; }

    public DataResourceContext()
    {

    }
}
