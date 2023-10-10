// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
internal partial class JavaScriptObjectMappingBridge
{
    public override void OnBeforeBrowse(CefBrowser browser, CefFrame frame, CefRequest request, bool userGesture, bool isRedirect)
    {
    }

    public override void OnBeforeClose(CefBrowser browser)
    {
    }



    public override void OnRenderProcessTerminated(CefBrowser browser)
    {
    }


    private void HandleInitializeJavaScriptObjectMessageOnLocal(CefBrowser browser, CefFrame frame, CefProcessId id, BridgeMessage message)
    {
        CefRuntime.PostTask(CefThreadId.UI, new JavaScriptObjectMapCreationTaskOnLocal(this)
        {
            Frame = frame,
            Objects = Objects.Where(x => x.Key.frame.Identifier == frame.Identifier).ToDictionary(k => k.Key.name, v => v.Value)
        });

        IsObjectsInitialized = true;
    }

}

