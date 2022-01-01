using NetDimension.NanUI.Browser.MessagePipe;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;

class MapObjectsToRenderTask : CefTask
{
    public MapObjectsToRenderTask(CefFrame frame, HashSet<MappedObject> mappedObjects)
    {
        Frame = frame;
        MappedObjects = mappedObjects;
    }

    public CefFrame Frame { get; }
    public HashSet<MappedObject> MappedObjects { get; }

    protected override void Execute()
    {
        var msg = new BridgeMessage(MapJavaScriptObjectHandler.MAP_OBJECTS);

        var objects = new JavaScriptObject();

        foreach (var item in MappedObjects)
        {
            objects.Add(item.Name, item.Object);
        }

        msg.Data = objects.ToJson();

        FormiumMessageBridge.SendBridgeMessage(CefProcessId.Renderer, Frame, msg);

    }
}
