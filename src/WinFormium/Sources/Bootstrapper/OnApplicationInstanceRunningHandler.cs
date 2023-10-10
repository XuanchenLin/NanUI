// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Diagnostics;

namespace WinFormium;

public sealed class OnApplicationInstanceRunningHandler
{
    public int ProcessId { get; }
    public nint MainWindowHandle { get; }
    public Process RunningProcess { get; }

    public OnApplicationInstanceRunningHandler(int processId)
    {
        ProcessId = processId;
        RunningProcess = Process.GetProcessById(ProcessId);
        MainWindowHandle = RunningProcess.MainWindowHandle;
    }

    public void ActiveRunningInstance()
    {
        if (MainWindowHandle != 0)
        {
            User32.ShowWindowAsync(MainWindowHandle, ShowWindowCommand.SW_RESTORE);
            User32.SwitchToThisWindow(MainWindowHandle, false);
        }
    }
}
