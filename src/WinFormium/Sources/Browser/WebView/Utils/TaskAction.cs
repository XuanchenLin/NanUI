// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
internal sealed class TaskAction : CefTask
{
    private Action? _action;

    public TaskAction(Action action)
    {
        _action = action;
    }

    protected override void Execute()
    {
        _action?.Invoke();
        _action = null;
    }

    public static void Run(Action action, CefThreadId threadId = CefThreadId.UI)
    {
        CefRuntime.PostTask(threadId, new TaskAction(action));
    }
}
