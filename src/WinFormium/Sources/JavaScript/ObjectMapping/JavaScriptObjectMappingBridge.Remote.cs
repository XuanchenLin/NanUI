// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptObjectMappingBridge
{
    public override void OnRemoteContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
        MapObjects(frame);
    }

    public override void OnRemoteContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
    {
    }

    private void HandleCreateMappedJavaScriptObjectMessageOnRemote(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        var data = message.DeserializeData<string>()!;

        //if(id == CefProcessId.Renderer)
        //{


        //}

        CefRuntime.PostTask(CefThreadId.Renderer, new JavaScriptObjectMapCreationTaskOnRemote(this, data)
        {
            Frame = frame,
        });

    }

}
