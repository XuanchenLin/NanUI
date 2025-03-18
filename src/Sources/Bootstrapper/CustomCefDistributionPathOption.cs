// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI;

public class CustomCefDistributionPathOption
{
    internal CustomCefDistributionPathOption(PlatformArchitecture architecture)
    {
        Architecture = architecture;
    }

    public PlatformArchitecture Architecture { get; }

    public string? LibCefPath { get; set; }
    public string? ResourceFilePath { get; set; }
}
