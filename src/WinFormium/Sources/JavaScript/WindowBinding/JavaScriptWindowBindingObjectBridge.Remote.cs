// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptWindowBindingObjectBridge
{
    private void HandlePostBrowserMessageOnRemote(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        var data = message.DeserializeData<JavaScriptPostBrowserMessageMessage>()!;

        CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptPostBrowserMessageTaskOnRemote(this) { Frame = frame, TaskData = data });
    }

    public override void OnRemoteContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    public override void OnRemoteContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }
}
