// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public delegate bool ShouldExitIfSubprocessNotExist(PlatformArchitecture architecture, string? subprocessFilePath);
public class SubprocessOptions
{
    public PlatformArchitecture Architecture
    {
        get; internal set;
    }

    public ShouldExitIfSubprocessNotExist? SubprocessNotExists { internal get; set; }

    public string? SubprocessFilePath { get; set; }


}
