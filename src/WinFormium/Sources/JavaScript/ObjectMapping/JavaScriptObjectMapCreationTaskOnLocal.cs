// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptObjectMapCreationTaskOnLocal : CefTask
{
    public JavaScriptObjectMappingBridge Bridge { get; }
    public required CefFrame Frame { get; init; }
    public required Dictionary<string, JavaScriptObject> Objects { get; init; }

    public JavaScriptObjectMapCreationTaskOnLocal(JavaScriptObjectMappingBridge bridge)
    {
        Bridge = bridge;
    }

    protected override void Execute()
    {
        var message = new BridgeMessage(JavaScriptObjectMappingBridge.CREATE_MAPPED_JAVASCRIPT_OBJECTS_MESSAGE);

        var objects = new JavaScriptObject();

        objects.AssociateToFrame(Frame);

        foreach (var item in Objects)
        {
            objects.Add(item.Key, item.Value);
        }

        message.SetData(objects.ToJson());


        MessageBridge.SendMessageToRemote(Frame, message);
    }
}