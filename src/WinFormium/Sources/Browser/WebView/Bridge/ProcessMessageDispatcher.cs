// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class ProcessMessageDispatcher
{
    private readonly Dictionary<string, Action<ProcessMessageReceivedEventArgs>> _messageHandlers = new();

    internal void DispatchMessage(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
    {
        if (_messageHandlers.TryGetValue(message.Name, out var existingHandler))
        {
            existingHandler(new ProcessMessageReceivedEventArgs(browser, frame, sourceProcess, message));
        }
    }

    public void SendMessage(CefProcessId targetProcess, CefFrame frame, CefProcessMessage message)
    {
        frame.SendProcessMessage(targetProcess, message);
    }

    public void RegisterMessageHandler(string messageName, Action<ProcessMessageReceivedEventArgs> handler)
    {
        _messageHandlers.TryGetValue(messageName, out var existingHandler);
        _messageHandlers[messageName] = existingHandler + handler;
    }
}
